using ML.Common.Model;
using ML.DatabaseConnections.Model;
using App.PVCFC_RFID.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ML.DeviceTransfer.PVCFCRFID.DataType;

namespace App.PVCFC_RFID.Model
{
    public class SettingsModel: CommonSettingsModel
    {
        private int _SysNumberOfStations = Properties.Settings.Default.NumberOfStation;
        public int SysNumberOfStations
        {
            get { return _SysNumberOfStations; }
            set { _SysNumberOfStations = value; }
        }

        #region System settings
        private string _SysServerURL = Properties.Settings.Default.ServerURL;
        public string SysServerURL
        {
            get { return _SysServerURL; }
            set { _SysServerURL = value; }
        }

        private int _SysServerPort = Properties.Settings.Default.ServerPort;
        public int SysServerPort
        {
            get { return _SysServerPort; }
            set { _SysServerPort = value; }
        }

        private string _SysDisShInfoPath = SharedValues.DisShInfoPath;
        public string SysDisShInfoPath
        {
            get { return _SysDisShInfoPath; }
            set { _SysDisShInfoPath = value; }
        }

        private PVCFCOperationEnum _Model = PVCFCOperationEnum.Export;
        public PVCFCOperationEnum Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        #endregion//End System settings


        private List<SettingsStationModel> _StationList = new List<SettingsStationModel>();
        public List<SettingsStationModel> StationList
        {
            get { return _StationList; }
            set { _StationList = value; }
        }

        private DatabaseSettingsModel _Database = new DatabaseSettingsModel();
        public DatabaseSettingsModel Database
        {
            get { return _Database; }
            set { _Database = value; }
        }

        
        #region Methods
        public void ResetDefault()
        {
            _Model = PVCFCOperationEnum.Export;
            //
            _SysNumberOfStations = Properties.Settings.Default.NumberOfStation;
            //System settings
            _SysServerURL = Properties.Settings.Default.ServerURL;
            _SysServerPort = Properties.Settings.Default.ServerPort;
            _SysDisShInfoPath = SharedValues.DisShInfoPath;
            //End System settings
            //
            _StationList = new List<SettingsStationModel>(_SysNumberOfStations);
            for (int i = 0; i < _StationList.Count; i++)
            {
                _StationList[i].Index = i;
            }
            //
            _Database = new DatabaseSettingsModel();
        }

        public static SettingsModel LoadSetting(String fileName)
        {
            SettingsModel info = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(SettingsModel);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        info = (SettingsModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                return new SettingsModel();
            }
            //
            return info;
        }

        #endregion//End Methods
    }
}
