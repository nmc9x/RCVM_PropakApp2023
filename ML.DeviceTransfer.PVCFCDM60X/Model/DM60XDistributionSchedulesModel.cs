using ML.SDK.DM60X.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace ML.DeviceTransfer.PVCFCDM60X.Model
{
    public class DM60XDistributionSchedulesModel
    {
        private int _ScanSucess = 0;
        public int ScanSucess
        {
            get { return _ScanSucess; }
            set { _ScanSucess = value; }
        }

        private int _ScanFailed = 0;
        public int ScanFailed
        {
            get { return _ScanFailed; }
            set { _ScanFailed = value; }
        }

        private int _ActiveSuccess = 0;
        public int ActiveSuccess
        {
            get { return _ActiveSuccess; }
            set { _ActiveSuccess = value; }
        }

        private int _ActiveFailed = 0;
        public int ActiveFailed
        {
            get { return _ActiveFailed; }
            set { _ActiveFailed = value; }
        }
        private int _Total = 0;
        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        private string _SaveFiles = "";
        public string SaveFiles
        {
            get { return _SaveFiles; }
            set { _SaveFiles = value; }
        }
        private List<DM60XProductItemModel> _ProductItemsList = new List<DM60XProductItemModel>();
        public List<DM60XProductItemModel> ProductItemsList
        {
            get { return _ProductItemsList; }
            set { _ProductItemsList = value; }
        }
        
        public DM60XProductItemModel GetNewProductItems(CodeModel codeData)
        {
            return null;
        }

        internal string SyncDeliveryDataToServer(ref DM60XProductItemModel productItems)
        {
            return null;
        }
        public virtual void SaveSettings(String fileName)
        {
            try
            {
                string path = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
        public void SaveSettings()
        {
            SaveSettings(_SaveFiles);
        }
    }
}
