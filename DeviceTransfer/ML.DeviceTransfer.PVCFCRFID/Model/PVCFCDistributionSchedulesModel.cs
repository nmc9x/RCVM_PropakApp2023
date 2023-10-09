using ML.Common.Controller;
using ML.DeviceTransfer.PVCFCRFID.APISAASModel;
using ML.DeviceTransfer.PVCFCRFID.Controller;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ML.DeviceTransfer.PVCFCRFID.Model
{
    public class PVCFCDistributionSchedulesModel
    {
        #region Delivery bills
        private bool _IsCheckPallet = false;
        public bool IsCheckPallet
        {
            get { return _IsCheckPallet; }
            set { _IsCheckPallet = value; }
        }

        private int _Line = 0;
        public int Line
        {
            get { return _Line; }
            set { _Line = value; }
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

        private string _ProductNameOffline = "";
        public string ProductNameOffline
        {
            get { return _ProductNameOffline; }
            set { _ProductNameOffline = value; }
        }

        private string _AgencyLevel1Offline = "";
        public string AgencyLevel1Offline
        {
            get { return _AgencyLevel1Offline; }
            set { _AgencyLevel1Offline = value; }
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

        #region API Params
        private string _AgentCodeFrom = "";
        public string AgentCodeFrom
        {
            get { return _AgentCodeFrom; }
            set { _AgentCodeFrom = value; }
        }

        private string _AgentCodeTo = "";
        public string AgentCodeTo
        {
            get { return _AgentCodeTo; }
            set { _AgentCodeTo = value; }
        }

        private string _ProCode = "";
        public string ProCode
        {
            get { return _ProCode; }
            set { _ProCode = value; }
        }

        private string _CreateBy_UserCode = "";
        public string CreateBy_UserCode
        {
            get { return _CreateBy_UserCode; }
            set { _CreateBy_UserCode = value; }
        }
        #endregion//End API Params

        #region API reponse
        private APIGetProductInfoModel.Root _APIProductList = new APIGetProductInfoModel.Root();
        [XmlIgnore]
        public APIGetProductInfoModel.Root APIProductList
        {
            get { return _APIProductList; }
            set { _APIProductList = value; }
        }

        private APIGetAgentInforByConditionModel.Root _APIAgentLevel1List = new APIGetAgentInforByConditionModel.Root();
        [XmlIgnore]
        public APIGetAgentInforByConditionModel.Root APIAgentLevel1List
        {
            get { return _APIAgentLevel1List; }
            set { _APIAgentLevel1List = value; }
        }
        private string _DeliveryCode = "";
        public string DeliveryCode
        {
            get { return _DeliveryCode; }
            set { _DeliveryCode = value; }
        }
        private string _DeliveryID = "";
        public string DeliveryID
        {
            get { return _DeliveryID; }
            set { _DeliveryID = value; }
        }

        #endregion//End API Response

        #region Scan data
        private string _ScanQRCode = "";
        public string ScanQRCode
        {
            get { return _ScanQRCode; }
            set { _ScanQRCode = value; }
        }

        private List<PVCFCProductItemModel> _ProductItemsList = new List<PVCFCProductItemModel>();
        public List<PVCFCProductItemModel> ProductItemsList
        {
            get { return _ProductItemsList; }
            set { _ProductItemsList = value; }
        }

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

        #region Save files
        private string _SaveFiles = "";
        public string SaveFiles
        {
            get { return _SaveFiles; }
            set { _SaveFiles = value; }
        }

        #endregion//End Save files

        #region Methods
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

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(_SaveFiles);
        }

        public static PVCFCDistributionSchedulesModel LoadSetting(String fileName)
        {
            PVCFCDistributionSchedulesModel info = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(PVCFCDistributionSchedulesModel);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        info = (PVCFCDistributionSchedulesModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                return new PVCFCDistributionSchedulesModel();
            }

            return info;
        }

        public void ResetDefaults()
        {
            _IsCheckPallet = false;
            _Line = 0;
            _No = "";
            _ProductName = "";
            _AgencyLevel1 = "";
            _ProductNameOffline = "";
            _AgencyLevel1Offline = "";
            _DateManufacture = DateTime.Now;
            _Expiry = DateTime.Now;
            _LOTNo = "";
            _Ordered = "";
            _DeliveryBill = "";
            _OrderedTotal = 0;
            _IsConfirm = false;
            //
            _APIProductList = new APIGetProductInfoModel.Root();
            _APIAgentLevel1List = new APIGetAgentInforByConditionModel.Root();
            _DeliveryCode = "";
            _DeliveryID = "";
            //
            _AgentCodeFrom = "";
            _AgentCodeTo = "";
            _ProCode = "";
            _CreateBy_UserCode = "";
            //
            _SaveFiles = "";
            //
            _ScanQRCode = "";
            _ProductItemsList = new List<PVCFCProductItemModel>();
            _PalletCode = "";
            _PalletProductCount = 0;
            //
            _ScanSucess = 0;
            _ScanFailed = 0;
            _ActiveSuccess = 0;
            _ActiveFailed = 0;
            _Total = 0;

        }

        public void ResetProucts()
        {
            //
            _DeliveryCode = "";
            _DeliveryID = "";
            _ProductItemsList = new List<PVCFCProductItemModel>();
            //
            _ScanSucess = 0;
            _ScanFailed = 0;
            _ActiveSuccess = 0;
            _ActiveFailed = 0;
            _Total = 0;
        }

        public string GetSettingName(string path, int index, PVCFCOperationEnum model)
        {
            if (_LOTNo.Length > 0)
            {
                return String.Format("{0}\\{1}\\{2}_{3}\\{2}_{3}_{4}_{5}.sch", path, model.ToString(), PVCFCSharedValues.StationName, (index + 1), _DeliveryBill, DateTime.Now.ToString("yyyyMMdd_hhmmss"));
            }
            else
            {
                return String.Format("{0}\\{1}\\{2}\\{3}\\{2}_{3}_{4}.sch", path, model.ToString(), PVCFCSharedValues.StationName, (index + 1), DateTime.Now.ToString("yyyyMMdd_hhmmss"));
            }
        }

        public string GetInfo(string separate, bool isOffline)
        {
            string info = "";// Languages.Languages.DeliveryID + ": " + _DeliveryID + separate + " ";
            if (isOffline)
            {
                info = ML.Languages.Languages.ProductionName + ": " + _ProductName;
                info += separate + " " + ML.Languages.Languages.AgencyLevel1 + ": " + _AgencyLevel1;
            }
            else
            {
                info = ML.Languages.Languages.ProductionName + ": " + _ProductNameOffline;
                info += separate + " " + ML.Languages.Languages.AgencyLevel1 + ": " + _AgencyLevel1Offline;
            }
            //
            info += separate + " " + Languages.Languages.DistributionCode + ": " + _DeliveryCode;
            info += separate + " " + ML.Languages.Languages.DeliveryBill + ": " + _DeliveryBill;
            info += separate + " " + ML.Languages.Languages.Ordered + ": " + _Ordered;
            info += separate + " " + ML.Languages.Languages.LOTNo + ": " + _LOTNo;
            info += separate + " " + ML.Languages.Languages.DateOfManufacture + ": " + _DateManufacture.ToString("dd/MM/yyyy");
            info += separate + " " + ML.Languages.Languages.DateOfExpiry + ": " + _Expiry.ToString("dd/MM/yyyy");
            info += separate + " " + ML.Languages.Languages.Quantity + ": " + _OrderedTotal.ToString("N0");
            return info;
        }

        public string GetResult(string separate)
        {
            string info = "";// Languages.Languages.DeliveryID + ": " + _DeliveryID + separate + " ";
            info += Languages.Languages.DistributionCode + ": " + _DeliveryCode;
            info += separate + " " + ML.Languages.Languages.DeliveryBill + ": " + _DeliveryBill;
            info += separate + " " + ML.Languages.Languages.ScanSuccess + ": " + ScanSucess.ToString("N0");
            info += separate + " " + ML.Languages.Languages.ScanFailed + ": " + ScanFailed.ToString("N0");
            info += separate + " " + ML.Languages.Languages.ActivedFailed + ": " + _ActiveSuccess.ToString("N0");
            info += separate + " " + ML.Languages.Languages.ActivedSuccess + ": " + _ActiveFailed.ToString("N0");
            info += separate + " " + ML.Languages.Languages.TotalExport + ": " + _Total.ToString("N0");
            return info;
        }

        public string GetProductList()
        {
            string strErrors = "";
            try
            {
                if (Common.Controller.CommonFunctions.PingURLAdrress(APIController.LinkAPI))
                {
                    _APIProductList = APIController.APIGetProductInfo();
                    if (_APIProductList == null)
                    {
                        strErrors = ML.Languages.Languages.YouHaveSomeTIMEOUTIssue + "\n" + ML.Languages.Languages.PleaseCheckYourServer;
                    }
                    else if (!_APIProductList.success)
                    {
                        strErrors = ML.Languages.Languages.Failed + ".\n" + ML.Languages.Languages.ResponseFromServer + ": " + _APIProductList.errcode + "\n" + _APIProductList.error;
                    }
                }
                else
                {
                    strErrors = ML.Languages.Languages.Failed + "\n" + ML.Languages.Languages.PleaseCheckYourServer;
                }

            }
            catch (Exception ex)
            {
                strErrors = ex.Message;
            }
            finally
            {

            }
            return strErrors;
        }

        public string GetAgentLevel1List()
        {
            string strErrors = "";
            try
            {
                if (Common.Controller.CommonFunctions.PingURLAdrress(APIController.LinkAPI))
                {
                    _APIAgentLevel1List = APIController.APIGetAgentInfo(0);//100ms => Datetime will errors

                    if (_APIProductList == null)
                    {
                        strErrors = ML.Languages.Languages.YouHaveSomeTIMEOUTIssue + "\n" + ML.Languages.Languages.PleaseCheckYourServer;
                    }
                    else if (!_APIAgentLevel1List.success)
                    {
                        strErrors = ML.Languages.Languages.Failed + ".\n" + ML.Languages.Languages.ResponseFromServer + ": " + _APIAgentLevel1List.errcode + "\n" + _APIAgentLevel1List.error;
                    }
                }
                else
                {
                    strErrors = ML.Languages.Languages.Failed + "\n" + ML.Languages.Languages.PleaseCheckYourServer;
                }
            }
            catch (Exception ex)
            {
                strErrors = ex.Message;
            }
            finally
            {

            }
            return strErrors;
        }

        public string GetDeliveryAPI()
        {
            string strErrors = "";
            APIInsertAgentProductModel.Root a5 = APIController.APInsertAgentProduct(_AgentCodeFrom, _AgentCodeTo, _ProCode, DateTime.Now, _OrderedTotal, _CreateBy_UserCode);//Failed ~30ms
            if (a5 != null)
            {
                if (!a5.success)
                {
                    strErrors = ML.Languages.Languages.Failed + ".\n" + ML.Languages.Languages.ResponseFromServer + ": " + a5.errcode + "\n" + a5.error;
                }
                else
                {
                    _DeliveryID = a5._id;
                    //
                    //Get Delivery Code
                    APIGetAgentProductByIdModel.Root a8 = APIController.APIGetAgentProductById(_DeliveryID);
                    if (a8 != null)
                    {
                        if (!a8.success)
                        {
                            strErrors = ML.Languages.Languages.Failed + ".\n" + ML.Languages.Languages.ResponseFromServer + ": " + "\n" + a5.error;
                        }
                        else
                        {
                            _DeliveryCode = a8.data.Code;
                        }
                    }
                    else
                    {
                        strErrors = ML.Languages.Languages.Failed + ".\n" + ML.Languages.Languages.NoResponseFromServer;
                    }
                }
            }
            else
            {
                strErrors = ML.Languages.Languages.Failed + ".\n" + ML.Languages.Languages.NoResponseFromServer;
            }
            return strErrors;
        }

        public PVCFCProductItemModel GetNewProductItems(ML.SDK.RDIF_FX9600.Model.TagModel tagData)
        {
            PVCFCProductItemResultEnum result = PVCFCProductItemResultEnum.Unknown;
            //Check Miss
            if (tagData.TIDCode == "")
            {
                result = PVCFCProductItemResultEnum.MissProduct;
            }
            else
            {
                //Check Dupplicate: EPC is same have Duplicate code
                if (_ProductItemsList.Count(p => p.ProductCode == tagData.EPCCode) > 0)
                {
                    result = PVCFCProductItemResultEnum.DuplicateCode;
                }
                else
                {
                    //Check Wrong data
                    //Linh.Tran_230916: Command
                    /*
                    if (tagData.TIDCode.Length != PVCFCSharedValues.TIDLength)
                    {
                        result = PVCFCProductItemResultEnum.WrongIDCode;
                    }

                    else if (tagData.EPCCode.Length != PVCFCSharedValues.EPCLength)
                    {
                        result = PVCFCProductItemResultEnum.WrongProductCode;
                    }
                    else
                    {
                        result = PVCFCProductItemResultEnum.WaitToSync;
                    }
                    //End Linh.Tran_230916: Command
                     * */
                    result = PVCFCProductItemResultEnum.WaitToSync;
                }
            }
            //
            PVCFCProductItemModel newProductItems = new PVCFCProductItemModel();
            newProductItems.TagID = tagData.TIDCode;
            newProductItems.ProductCode = tagData.EPCCode;
            newProductItems.PalletCode = "";
            newProductItems.ScanDatetime = DateTime.Now;
            //
            newProductItems.Results = result;
            newProductItems.Status = result.GetStatus();
            //
            //Add to files
            //_ProductItemsList.Add(newProductItems);
            //
            return newProductItems;
        }

        public string SyncDeliveryDataToServer(ref PVCFCProductItemModel product)
        {
            string strErrors = "";
            switch (product.Results)
            {
                case PVCFCProductItemResultEnum.WaitToSync:
                    //
                    //APIInsertDistributorAndActiveModel.Root a6 = APIController.APIInsertDistributorAndActive(_DeliveryID, product.ProductCode, "", _DateManufacture, _Expiry, _CreateBy_UserCode);//Failed ~30ms//Linh.Tran_230912: Command//Hiden NSX, HSD
                    APIInsertDistributorAndActiveModel.Root a6 = APIController.APIInsertDistributorAndActive(_DeliveryID, product.ProductCode, "", null, null, _CreateBy_UserCode);//Failed ~30ms//Linh.Tran_230912: Command//Hiden NSX, HSD
                    if (a6 != null)
                    {
                        if (!a6.success)
                        {
                            strErrors = a6.errcode + " (" + a6.error + ")";
                        }
                    }
                    else
                    {
                        strErrors = ML.Languages.Languages.Failed + ".\n" + ML.Languages.Languages.NoResponseFromServer;
                    }
                    //Add new results
                    product.Results = strErrors.Length > 0 ? PVCFCProductItemResultEnum.ActivedFailed : PVCFCProductItemResultEnum.ActivedSuccess;
                    product.Status = strErrors.Length > 0 ? PVCFCProductItemStatusEnum.ActivedFailed : PVCFCProductItemStatusEnum.ActivedSuccess;
                    product.Errors = strErrors;
                    break;
                default:
                    //
                    break;
            }
            return strErrors;
        }

        public int GetCheckSuccess()
        {
            if (_ProductItemsList != null && _ProductItemsList.Count > 0)
            {
                //return _ProductItemsList.Count(p => p.IsCheckSuccess);
                return _ProductItemsList.Count(p => (PVCFCProductItemStatusEnum.CheckedSuccess.GetResult().Contains(p.Results)));
            }
            //
            return 0;
        }

        public int GetCheckFailed()
        {
            if (_ProductItemsList != null && _ProductItemsList.Count > 0)
            {
                return _ProductItemsList.Count(p => (PVCFCProductItemStatusEnum.CheckedFailed.GetResult().Contains(p.Results)));
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
                return _ProductItemsList.Count(p => (PVCFCProductItemStatusEnum.ActivedSuccess.GetResult().Contains(p.Results)));
            }
            //
            return 0;
        }

        public int GetActiveFailed()
        {
            if (_ProductItemsList != null && _ProductItemsList.Count > 0)
            {
                return _ProductItemsList.Count(p => (PVCFCProductItemStatusEnum.ActivedFailed.GetResult().Contains(p.Results)));
            }
            //
            return 0;
        }


        public bool IsExitSettingFile(string path, int stationIndex, PVCFCOperationEnum model)
        {
            //
            string fullPath = GetSettingName(path, stationIndex, model);
            if (File.Exists(fullPath))
            {
                return true;
            }
            //
            return false;
        }
        #endregion//End Methods
    }
}
