using ML.Common.Controller;
using ML.DatabaseConnections;
using ML.Languages;
using App.PVCFC_RFID.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.AccountManagements.Controller;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Controller
{
    public class SharedFunctions : CommonFunctions
    {
        public new static void SetPath(string rootpath)
        {
            CommonFunctions.SetPath(rootpath);
            //
            //SharedValues.DisShInfoPath = rootpath + "DisShInfo\\";
            SharedValues.DisShInfoPath = "C:\\" + "DisShInfo\\";
        }

        public static string LoadDatabase()
        {
            string strErrrors = "";
            if (File.Exists(SharedValues.Settings.Database.FullPath))
            {
                SharedValues.DatabaseObj = new ConnectionDatabaseCSV(SharedValues.Settings.Database.FullPath, SharedValues.Settings.Database.CodePage);
                SharedValues.DatabaseObj.ConnectDatabase();
                SharedValues.DatabaseObj.LoadToDatatable();
            }
            else
            {
                strErrrors = Languages.MsgDontHaveDatabase;
            }
            return strErrrors;
        }

        #region Settings
        /// <summary>
        /// Load setting from temp directory function
        /// </summary>
        public static void LoadSettings()
        {
            try
            {
                int numberOfStations = Properties.Settings.Default.NumberOfStation;
                //String path = settingsPath + "Settings\\";
                string fullPath = GetSettingsName();
                //
                var loadSettings = SettingsModel.LoadSetting(fullPath);
                //
                if (loadSettings.StationList == null)
                {
                    loadSettings.StationList = new List<SettingsStationModel>(numberOfStations);
                }
                //Linh.Tran_230731: Station Model
                if (loadSettings.StationList.Count < numberOfStations)
                {
                    for (int i = loadSettings.StationList.Count; i < numberOfStations; i++)
                    {
                        var stationItems = new SettingsStationModel();
                        stationItems.Index = i;
                        //
                        string[] numIPArr = Properties.Settings.Default.DM60XIP.Split('.');
                        string newNumIP = (Convert.ToInt32(numIPArr[numIPArr.Length - 1]) + i).ToString();
                        numIPArr[numIPArr.Length - 1] = newNumIP;
                        //
                        stationItems.DM60X.IPAddress = string.Join(".", numIPArr);
                        stationItems.DM60X.Port = (int.Parse(Properties.Settings.Default.DM60XPort) + i).ToString();
                        //
                        loadSettings.StationList.Add(stationItems);
                    }
                }
                //End Linh.Tran_230731: Station Model
                //
                SharedValues.Settings = loadSettings;
            }
            catch
            {
                SettingsModel initSettings = new SettingsModel();
                SharedValues.Settings = initSettings;
            }
            //
            ML.DeviceTransfer.PVCFCRFID.APISAASModel.APIController.LinkAPI = SharedValues.Settings.SysServerURL + ":" + SharedValues.Settings.SysServerPort.ToString();// http://113.163.69.8:9594";
        }

        /// <summary>
        /// Save setting to temp directory function
        /// </summary>
        public static bool SaveSettings()
        {
            try
            {
                //String path = settingsPath + "Settings\\";
                String path = CommonValues.SettingsPath;
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                SharedValues.Settings.SaveSettings(GetSettingsName());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ConfigResultNotify(int index, bool enableSave, bool isDisplayMsg = true)
        {
            if (SharedValues.Running.StationList[index].RFID_FX9600Feedback.GPIOConfigFeedback &&
                SharedValues.Running.StationList[index].RFID_FX9600Feedback.AntennaConfigFeedback &&
                SharedValues.Running.StationList[index].RFID_FX9600Feedback.TagStorageConfigFeedback &&
                SharedValues.Running.StationList[index].RFID_FX9600Feedback.TriggerConfigFeedback)
            {
                if (enableSave)
                {
                    SaveSettings();
                }
                if (isDisplayMsg)
                {
                    MessageBox.Show(
                    Languages.MsgRFIDSettingSuccessfully,
                    Languages.MsgSettingNotification,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1
                        );
                }
                return true;
            }
            else
            {
                MessageBox.Show(
                  Languages.MsgRFIDSettingUnsuccessfully,
                  Languages.MsgSettingNotification,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning,
                  MessageBoxDefaultButton.Button1
                  );
                return false;
            }

        }
        public static bool DM60XConfigResultNotify(int index, bool enableSave, bool isDisplayMsg = true)
        {
            if (SharedValues.Running.StationList[index].DM60XFeedback.TriggerConfFeedback &&
                SharedValues.Running.StationList[index].DM60XFeedback.NetworkConfFeebback &&
                SharedValues.Running.StationList[index].DM60XFeedback.SymbolicConfFeebback &&
                SharedValues.Running.StationList[index].DM60XFeedback.RebootFeedback &&
                SharedValues.Running.StationList[index].DM60XFeedback.ResetAndRebootFeedback)
            {
                if (enableSave)
                {
                    SaveSettings();
                }
                if (isDisplayMsg)
                {
                    MessageBox.Show(
                    "DM60X Setting Successfully",
                    Languages.MsgSettingNotification,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1
                        );
                }
                return true;
            }
            else
            {
                MessageBox.Show(
                  "DM60X Setting Unsuccessfully",
                  Languages.MsgSettingNotification,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning,
                  MessageBoxDefaultButton.Button1
                  );
                return false;
            }

        }
        #endregion//End Settings

        #region Distribution schedule model
        /// <summary>
        /// Load setting from temp directory function
        /// </summary>
        public static void LoadDisShedulesSettings()
        {
            try
            {

            }
            catch
            {
                //
            }
        }

        /// <summary>
        /// Save setting to temp directory function
        /// </summary>
        public static void SaveDisShedulesSettings()
        {
            try
            {

            }
            catch { }
        }

        public static void GetDeliveryParamets(int index)
        {
            SharedValues.Running.StationList[index].Schedules.AgentCodeFrom = AccountController.LoginUserInfoOnline.data.AgentCode;
            SharedValues.Running.StationList[index].Schedules.CreateBy_UserCode = AccountController.LoginUserInfoOnline.data.UserCode;
        }
        #endregion//End Distribution schedule model

        #region Others
        public static bool CheckingBeforeCloseForm()
        {
            if (SharedValues.Running.IsStarting())
            {
                string msg = Languages.CannotCloseApplications + "\n";
                msg += SharedValues.Running.IsSyncData ? Languages.SyncDataWithServer : String.Format(Languages.TheXAreRunning, Properties.Settings.Default.StationName);
                MessageBox.Show(new Form { TopMost = true }, msg, Languages.CloseApplications, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;//Canel
            }
            return false;//OK
        }
        #endregion//End Others

        #region LINE Info
        public static string GetStationName(int index)
        {
            string strStationName = "";
            switch (SharedValues.Settings.Model)
            {
                case ML.DeviceTransfer.PVCFCRFID.DataType.PVCFCOperationEnum.Export:
                    strStationName = Properties.Settings.Default.StationName + " " + Convert.ToChar(index + 65);//Start is A(65), B(66), C(67),...
                    break;
                case ML.DeviceTransfer.PVCFCRFID.DataType.PVCFCOperationEnum.Import:
                    strStationName = Properties.Settings.Default.StationName + " " + Convert.ToChar(index + 65);//Start is A(65), B(66), C(67),...
                    break;
            }
            return strStationName;
        }
        #endregion//End LINE Info
    }
}
