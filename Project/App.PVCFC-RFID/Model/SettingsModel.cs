using App.PVCFC_RFID.DataType;
using ML.Common.Model;
using ML.DatabaseConnections.Model;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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

        //private PVCFCOperationEnum _Model = PVCFCOperationEnum.Export;
        //public PVCFCOperationEnum Model
        //{
        //    get { return _Model; }
        //    set { _Model = value; }
        //}
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
            //_Model = PVCFCOperationEnum.Export;
            //
            _SysNumberOfStations = Properties.Settings.Default.NumberOfStation;
           
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
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;
                using (var read = new StringReader(xmlString))
                {
                    var outType = typeof(SettingsModel);
                    var serializer = new XmlSerializer(outType);
                    using (var reader = new XmlTextReader(read))
                    {
                        info = (SettingsModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception)
            {
                return new SettingsModel();
            }
            return info;
        }

        #endregion//End Methods
    }
}
