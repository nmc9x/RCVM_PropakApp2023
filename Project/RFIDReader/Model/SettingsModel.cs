using ML.Common.Model;
using ML.DatabaseConnections.Model;
using App.DevCodeActivatorRFID.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ML.SDK.RFID.Model;

namespace App.DevCodeActivatorRFID.Model
{
    public class SettingsModel: CommonSettingsModel
    {
        private int _NumberOfStations = Properties.Settings.Default.NumberOfStation;
        public int NumberOfStations
        {
            get { return _NumberOfStations; }
            set { _NumberOfStations = value; }
        }

        private List<StationModel> _StationList = new List<StationModel>();
        public List<StationModel> StationList
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
            _NumberOfStations = Properties.Settings.Default.NumberOfStation;
            //
            _StationList = new List<StationModel>(_NumberOfStations);
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
