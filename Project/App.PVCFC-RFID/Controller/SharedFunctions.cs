using App.PVCFC_RFID.Model;
using ML.Common.Controller;
using ML.DatabaseConnections;
using ML.Languages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Controller
{
    public class SharedFunctions : CommonFunctions
    {
        public new static void SetPath(string rootpath)
        {
            CommonFunctions.SetPath(rootpath);
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
        public static void LoadSettings()
        {
            try
            {
                int numberOfStations = SharedControlHandler.NumberOfStation;
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
                        var stationItems = new SettingsStationModel(); // station : Camera cognex, keyence
                        stationItems.Index = i;
                        //
                        string[] numIPArr = Properties.Settings.Default.DM60XIP.Split('.');
                        string newNumIP = (Convert.ToInt32(numIPArr[numIPArr.Length - 1]) + i).ToString();
                        numIPArr[numIPArr.Length - 1] = newNumIP;
                        //
                        stationItems.DMCamera.IPAddress = string.Join(".", numIPArr);
                        stationItems.DMCamera.Port = "21";//(int.Parse(Properties.Settings.Default.DM60XPort) + i).ToString();
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
           // ML.DeviceTransfer.PVCFCRFID.APISAASModel.APIController.LinkAPI = SharedValues.Settings.SysServerURL + ":" + SharedValues.Settings.SysServerPort.ToString();// http://113.163.69.8:9594";
        }

        /// <summary>
        /// Save setting to temp directory function
        /// </summary>
        public static bool SaveSettingsFunc()
        {
            try
            {
                string path = CommonValues.SettingsPath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                SharedValues.Settings.SaveSettings(GetSettingsName());
                return true;
            }
            catch
            {
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
                    SaveSettingsFunc();
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

        //#region LINE Info
        //public static string GetStationName(int index)
        //{
        //    string strStationName = "";
        //    switch (SharedValues.Settings.Model)
        //    {
        //        case ML.DeviceTransfer.PVCFCRFID.DataType.PVCFCOperationEnum.Export:
        //            strStationName = Properties.Settings.Default.StationName + " " + Convert.ToChar(index + 65);//Start is A(65), B(66), C(67),...
        //            break;
        //        case ML.DeviceTransfer.PVCFCRFID.DataType.PVCFCOperationEnum.Import:
        //            strStationName = Properties.Settings.Default.StationName + " " + Convert.ToChar(index + 65);//Start is A(65), B(66), C(67),...
        //            break;
        //    }
        //    return strStationName;
        //}
        //#endregion//End LINE Info
    }
}
