using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace App.DevCodeActivatorRFID.Model
{
    public class DistributionSchedulesModel
    {
        #region Delivery bills
        private bool _IsCheckPallet = false;
        public bool IsCheckPallet
        {
            get { return _IsCheckPallet; }
            set { _IsCheckPallet = value; }
        }

        private string _No = "";
        public string No
        {
            get { return _No; }
            set { _No = value; }
        }

        private string _ProductName = "";
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        private string _AgencyLevel1 = "";
        public string AgencyLevel1
        {
            get { return _AgencyLevel1; }
            set { _AgencyLevel1 = value; }
        }

        private DateTime _DateManufacture = DateTime.Now;
        public DateTime DateManufacture
        {
            get { return _DateManufacture; }
            set { _DateManufacture = value; }
        }

        private DateTime _Expiry = DateTime.Now;
        public DateTime Expiry
        {
            get { return _Expiry; }
            set { _Expiry = value; }
        }

        private string _LOTNo = "";
        public string LOTNo
        {
            get { return _LOTNo; }
            set { _LOTNo = value; }
        }

        private string _Ordered = "";
        public string Ordered
        {
            get { return _Ordered; }
            set { _Ordered = value; }
        }

        private string _DeliveryBill = "";
        public string DeliveryBill
        {
            get { return _DeliveryBill; }
            set { _DeliveryBill = value; }
        }

        private int _OrderedTotal = 0;
        public int OrderedTotal
        {
            get { return _OrderedTotal; }
            set { _OrderedTotal = value; }
        }

        private bool _IsConfirm = false;
        public bool IsConfirm
        {
            get { return _IsConfirm; }
            set { _IsConfirm = value; }
        }
        #endregion //End Delivery bills

        #region Scan data
        private string _ScanQRCode = "";
        public string ScanQRCode
        {
            get { return _ScanQRCode; }
            set { _ScanQRCode = value; }
        }


        private List<ProductItemModel> _ProductItemsList = new List<ProductItemModel>();
        public List<ProductItemModel> ProductItemsList
        {
            get { return _ProductItemsList; }
            set { _ProductItemsList = value; }
        }

        private string _PalletCode = "";
        public string PalletCode
        {
            get { return _PalletCode; }
            set { _PalletCode = value; }
        }

        private int _PalletProductCount = 0;
        public int PalletProductCount
        {
            get { return _PalletProductCount; }
            set { _PalletProductCount = value; }
        }
        #endregion//End Scan data

        #region Methods
        public virtual void SaveSettings(String fileName)
        {
            try
            {
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

        public static DistributionSchedulesModel LoadSetting(String fileName)
        {
            DistributionSchedulesModel info = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(DistributionSchedulesModel);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        info = (DistributionSchedulesModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                return new DistributionSchedulesModel();
            }

            return info;
        }

        public void ResetDefaults()
        {
            _IsCheckPallet = false;
            _No = "";
            _ProductName = "";
            _AgencyLevel1 = "";
            _DateManufacture = DateTime.Now;
            _Expiry = DateTime.Now;
            _LOTNo = "";
            _Ordered = "";
            _DeliveryBill = "";
            _OrderedTotal = 0;
            _IsConfirm = false;
            //
            _ScanQRCode = "";
            _ProductItemsList = new List<ProductItemModel>();
            _PalletCode = "";
            _PalletProductCount = 0;
            
        }

        public string GetSettingName(string path)
        {
            if (_LOTNo.Length > 0)
            {
                return String.Format("{1}\\{0}.xml", _LOTNo, path);
            }
            else
            {
                return String.Format("{1}\\{0}.xml", DateTime.Now.ToString("yyyyMMdd_hhmmss"), path);
            }
        }

        public int GetCheckSuccess()
        {
            if (_ProductItemsList != null && _ProductItemsList.Count > 0)
            {
                //return _ProductItemsList.Count(p => p.IsCheckSuccess);
                return _ProductItemsList.Count(p => (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.Unknown)
                                                || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.DuplicateCode)
                                                || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.WrongPallet)
                                                || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.WrongProductName)
                                                || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedSuccess)
                                                || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.UnknownPallet));
            }
            //
            return 0;
        }

        public int GetCheckFailed()
        {
            if (_ProductItemsList != null && _ProductItemsList.Count > 0)
            {
                return _ProductItemsList.Count(p => (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.MissProduct)
                                                 || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.MissPallet)
                                                 || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.PalletLackQuantity));
                //if (_PalletProductCount > 0)
                //{
                //    //return _ProductItemsList.Count(p => p.IsCheckSuccess== false);
                //    int countCheckedSuccess = GetCheckSuccess();
                //    return Math.Abs((_PalletProductCount - countCheckedSuccess));
                //}
                //else
                //{
                //    return _ProductItemsList.Count(p => (p.Status == ProductItemStatusEnum.MissProduct));
                //}
            }
            //
            return 0;
        }

        public int GetExportTotal()
        {
            return this._OrderedTotal;
        }

        public int GetActivedSuccess()
        {
            if (_ProductItemsList != null && _ProductItemsList.Count > 0)
            {
                //return _ProductItemsList.Count(p => p.IsActivedSuccess);
                return _ProductItemsList.Count(p => (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedSuccess));
            }
            //
            return 0;
        }

        public int GetActiveFailed()
        {
            if (_ProductItemsList != null && _ProductItemsList.Count > 0)
            {
                //return _ProductItemsList.Count(p => (p.IsCheckSuccess) && (p.IsActivedSuccess == false));
                return _ProductItemsList.Count(p => (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.Unknown)
                                               || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.DuplicateCode)
                                               || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.WrongPallet)
                                               || (p.Status == App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.WrongProductName));
            }
            //
            return 0;
        }

        public bool IsExitSettingFile(string path)
        {
            //
            string fullPath = GetSettingName(path);
            if(File.Exists(fullPath))
            {
                return true;
            }
            //
            return false;
        }

        public bool IsExitSettingFile(string path, string strLOTNo)
        {
            //
            string fullPath = "";
            if (_LOTNo.Length > 0)
            {
                fullPath = String.Format("{1}\\{0}.xml", _LOTNo, path);
            }
            else
            {
                fullPath = String.Format("{1}\\{0}.xml", DateTime.Now.ToString("yyyyMMdd_hhmmss"), path);
            }
            //
            if (File.Exists(fullPath))
            {
                return true;
            }
            //
            return false;
        }

        public ProductItemModel AddNewProductItems(string chipID, string productCode, string palletCode, bool isCheckedSuccess)
        {
            bool isSameCode = false;
            bool isActivedSuccess = false;
            //Status: Wrong Product name
            App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum status = isCheckedSuccess ? App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.CheckedSuccess : App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.WrongProductName;
            //
            if (isCheckedSuccess)
            {
                //Status: Dupplicate code
                int isExits = _ProductItemsList.Count(p => p.ProductCode == productCode);
                isSameCode = (isExits > 0) ? true : false;// Linh.Tran_230610: Same code
                //
                isActivedSuccess = !isSameCode;
                //
                if (isSameCode)
                {
                    status = App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.DuplicateCode;
                }
                else if (isActivedSuccess)
                {
                    //Status: Actived success
                    status = App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedSuccess;
                }
            }
            //
            ProductItemModel newProductItems = new ProductItemModel();
            newProductItems.ChipID = chipID;
            newProductItems.ProductCode = productCode;
            newProductItems.PalletCode = palletCode;
            newProductItems.IsCheckSuccess = isCheckedSuccess;
            newProductItems.ScanDatetime = DateTime.Now;
            //
            newProductItems.IsActivedSuccess = isActivedSuccess;
            newProductItems.Status = status;
            //
            //Add to files
            _ProductItemsList.Add(newProductItems);
            //
            return newProductItems;
        }
        #endregion//End Methods
    }
}
