using ML.Common.Controller;
using ML.DatabaseConnections;
using ML.Languages;
using App.DevCodeActivatorRFID.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Controller
{
    public class SharedFunctions: CommonFunctions
    {
        public new static void SetPath(string rootpath)
        {
            CommonFunctions.SetPath(rootpath);
            //
            SharedValues.DisShInfoPath = rootpath + "DisShInfo\\";
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
                String fullPath = GetSettingsName();
                //
                SettingsModel loadSettings = SettingsModel.LoadSetting(fullPath);
                //
                if (loadSettings.StationList == null)
                {
                    loadSettings.StationList = new List<StationModel>(numberOfStations);
                }
                //Linh.Tran_230731: Station Model
                if (loadSettings.StationList.Count < numberOfStations)
                {
                    for (int i = loadSettings.StationList.Count; i < numberOfStations; i++)
                    {
                        StationModel stationItems = new StationModel();
                        stationItems.Index = i;
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
        }

        /// <summary>
        /// Save setting to temp directory function
        /// </summary>
        public static void SaveSettings()
        {
            try
            {
                //String path = settingsPath + "Settings\\";
                String path = CommonValues.SettingsPath;
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                //SharedValues.Settings.SaveSettings(path += "settings.xml");
                SharedValues.Settings.SaveSettings(GetSettingsName());
            }
            catch { }
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
        #endregion//End Distribution schedule model

    }
}
