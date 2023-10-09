using ML.Common.Controller;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace App.PVCFC_RFID.Controller
{
    public class SettingViewModel : ViewModelBase
    {
        public int Index { get;set; }
        public SettingViewModel()
        {
            GetSavedValueSettingToElement(Index);
        }
        #region Properties
        private int _CbbTriggerTypeIndex = 0;
        public int CbbTriggerTypeIndex
        {
            get { return _CbbTriggerTypeIndex; }
            set => SetProperty(ref _CbbTriggerTypeIndex, value);
        }
        private Visibility _TbDelayTimeVis;

        public Visibility TbDelayTimeVis
        {
            get { return _TbDelayTimeVis; }
            set => SetProperty(ref _TbDelayTimeVis, value);   
        }

        private int _CbbDelayTypeIndex = 0;
        public int CbbDelayTypeIndex
        {
            get { return _CbbDelayTypeIndex; }
            set {
                SetProperty(ref _CbbDelayTypeIndex, value);
                TbDelayTimeVis = _CbbDelayTypeIndex == 1 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private string _TbDecodeTimeValue = "50";
        public string TbDecodeTimeValue
        {
            get { return _TbDecodeTimeValue; }
            set => SetProperty(ref _TbDecodeTimeValue, value);
        }

        private string _TbPortValue;
        public string TbPortValue
        {
            get { return _TbPortValue; }
            set { _TbPortValue = value; }
        }

        private string _TbDelayTimeValue = "2000";
        public string TbDelayTimeValue
        {
            get { return _TbDelayTimeValue; }
            set
            {
                if (_TbDelayTimeValue != value)
                {
                    _TbDelayTimeValue = value; OnPropertyChanged();
                }
            }
        }

        private string _TbIPAddressValue = "169.254.10.11";
        public string TbIPAddressValue
        {
            get { return _TbIPAddressValue; }
            set
            {
                _TbIPAddressValue = value;
                OnPropertyChanged();
            }
        }

        private string _TbSubnetValue = "255.255.0.0";
        public string TbSubnetValue
        {
            get { return _TbSubnetValue; }
            set { _TbSubnetValue = value; OnPropertyChanged(); }
        }

        private string _TbDefaultGatewayValue = "0.0.0.0";
        public string TbDefaultGatewayValue
        {
            get { return _TbDefaultGatewayValue; }
            set { _TbDefaultGatewayValue = value; OnPropertyChanged(); }
        }

        private bool _ChkBoxDHCP_Sts = false;
        public bool ChkBoxDHCP_Sts
        {
            get { return _ChkBoxDHCP_Sts; }
            set { _ChkBoxDHCP_Sts = value; OnPropertyChanged(); }
        }

        #region CheckBoxSymbolState

        private bool _CheckBoxDataMatrix_Sts = false;
        public bool CheckBoxDataMatrix_Sts
        {
            get { return _CheckBoxDataMatrix_Sts; }
            set { _CheckBoxDataMatrix_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxQR_Sts = false;
        public bool CheckBoxQR_Sts
        {
            get { return _CheckBoxQR_Sts; }
            set { _CheckBoxQR_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxMaxi_Sts = false;
        public bool CheckBoxMaxi_Sts
        {
            get { return _CheckBoxMaxi_Sts; }
            set { _CheckBoxMaxi_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxAztec_Sts = false;
        public bool CheckBoxAztec_Sts
        {
            get { return _CheckBoxAztec_Sts; }
            set { _CheckBoxAztec_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBox128_Sts = false;

        public bool CheckBox128_Sts
        {
            get { return _CheckBox128_Sts; }
            set
            {
                _CheckBox128_Sts = value;

                OnPropertyChanged();

                if (!_CheckBox128_Sts && !_CheckBoxGS1_Sts)
                {
                    CheckBoxEANUCC_Sts = false;
                    CheckBoxEANUCC_EnSts= CheckBoxStacked_EnSts = false;
                }
                else
                    CheckBoxEANUCC_EnSts = CheckBoxStacked_EnSts = true;
            }
        }

        private bool _CheckBoxStacked_EnSts = false;

        public bool CheckBoxStacked_EnSts
        {
            get { return _CheckBoxStacked_EnSts; }
            set { _CheckBoxStacked_EnSts = value; OnPropertyChanged(); }
        }


        private bool _CheckBox25_Sts = false;

        public bool CheckBox25_Sts
        {
            get { return _CheckBox25_Sts; }
            set { _CheckBox25_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBox93_Sts = false;

        public bool CheckBox93_Sts
        {
            get { return _CheckBox93_Sts; }
            set { _CheckBox93_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBox39_Sts = false;

        public bool CheckBox39_Sts
        {
            get { return _CheckBox39_Sts; }
            set { _CheckBox39_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxPharma_Sts = false;

        public bool CheckBoxPharma_Sts
        {
            get { return _CheckBoxPharma_Sts; }
            set { _CheckBoxPharma_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxCodabar_Sts = false;

        public bool CheckBoxCodabar_Sts
        {
            get { return _CheckBoxCodabar_Sts; }
            set { _CheckBoxCodabar_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxInterleaved_Sts = false;

        public bool CheckBoxInterleaved_Sts
        {
            get { return _CheckBoxInterleaved_Sts; }
            set { _CheckBoxInterleaved_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxUPCEAN_Sts = false;

        public bool CheckBoxUPCEAN_Sts
        {
            get { return _CheckBoxUPCEAN_Sts; }
            set { _CheckBoxUPCEAN_Sts = value; OnPropertyChanged(); }
        }
        private bool _CheckBoxMsi_Sts = false;

        public bool CheckBoxMsi_Sts
        {
            get { return _CheckBoxMsi_Sts; }
            set { _CheckBoxMsi_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxStacked_Sts = false;

        public bool CheckBoxStacked_Sts
        {
            get { return _CheckBoxStacked_Sts; }
            set { _CheckBoxStacked_Sts = value; OnPropertyChanged(); SymbolGroupSelectChecked("Stacked"); }
        }

        private bool _CheckBoxPDF_Sts = false;

        public bool CheckBoxPDF_Sts
        {
            get { return _CheckBoxPDF_Sts; }
            set { _CheckBoxPDF_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxEANUCC_Sts = false;

        public bool CheckBoxEANUCC_Sts
        {
            get { return _CheckBoxEANUCC_Sts; }
            set { _CheckBoxEANUCC_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxMicro_Sts = false;

        public bool CheckBoxMicro_Sts
        {
            get { return _CheckBoxMicro_Sts; }
            set { _CheckBoxMicro_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxGS1_Sts = false;

        public bool CheckBoxGS1_Sts
        {
            get { return _CheckBoxGS1_Sts; }
            set
            {
                if(_CheckBoxGS1_Sts != value)
                {
                    _CheckBoxGS1_Sts = value;
                    if (!CheckBox128_Sts && !_CheckBoxGS1_Sts)
                    {
                        CheckBoxEANUCC_EnSts = CheckBoxStacked_EnSts = false;
                        CheckBoxEANUCC_Sts = CheckBoxStacked_Sts = false;
                    }
                    else
                        CheckBoxEANUCC_EnSts = CheckBoxStacked_EnSts = true;
                }
                
                OnPropertyChanged();
            }
        }

        private bool _CheckBoxPostal_Sts = false;

        public bool CheckBoxPostal_Sts
        {
            get { return _CheckBoxPostal_Sts; }
            set { _CheckBoxPostal_Sts = value; OnPropertyChanged(); SymbolGroupSelectChecked("Postal"); }
        }

        private bool _CheckBoxPostnet_Sts = false;

        public bool CheckBoxPostnet_Sts
        {
            get { return _CheckBoxPostnet_Sts; }
            set { _CheckBoxPostnet_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxPlanet_Sts = false;

        public bool CheckBoxPlanet_Sts
        {
            get { return _CheckBoxPlanet_Sts; }
            set { _CheckBoxPlanet_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxJap_Sts = false;

        public bool CheckBoxJap_Sts
        {
            get { return _CheckBoxJap_Sts; }
            set { _CheckBoxJap_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxUPU_Sts = false;

        public bool CheckBoxUPU_Sts
        {
            get { return _CheckBoxUPU_Sts; }
            set { _CheckBoxUPU_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxAus_Sts = false;

        public bool CheckBoxAus_Sts
        {
            get { return _CheckBoxAus_Sts; }
            set { _CheckBoxAus_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBoxIntel_Sts = false;
        public bool CheckBoxIntel_Sts
        {
            get { return _CheckBoxIntel_Sts; }
            set { _CheckBoxIntel_Sts = value; OnPropertyChanged(); }
        }

        private bool _CheckBox2D_Sts = false;

        public bool CheckBox2D_Sts
        {
            get { return _CheckBox2D_Sts; }
            set
            {
                if (_CheckBox2D_Sts != value)
                {
                    _CheckBox2D_Sts = value;
                    
                    OnPropertyChanged();
                    SymbolGroupSelectChecked("2D");
                }
            }
        }

        private bool _CheckBox1D_Sts = false;

        public bool CheckBox1D_Sts
        {
            get { return _CheckBox1D_Sts; }
            set { _CheckBox1D_Sts = value; OnPropertyChanged(); SymbolGroupSelectChecked("1D"); }
        }

        private bool _CheckBoxEANUCC_EnSts = false;

        public bool CheckBoxEANUCC_EnSts
        {
            get { return _CheckBoxEANUCC_EnSts; }
            set
            {
                _CheckBoxEANUCC_EnSts = value;
                OnPropertyChanged();
            }
        }

        
        public string ButtonApplyText => ML.Languages.Languages.Apply;
        public string ButtonRebootText => ML.Languages.Languages.Reboot;
        public string ButtonResetText => ML.Languages.Languages.Reset;


        #endregion

        #endregion

        public void UpdateCurrentSettingValue(int index)
        {
            // Get Trigger Config
            SharedValues.Settings.StationList[index].DM60X.TriggerTypeIndex = CbbTriggerTypeIndex;
            SharedValues.Settings.StationList[index].DM60X.DelayTypeIndex = CbbDelayTypeIndex;
            SharedValues.Settings.StationList[index].DM60X.DecodeTime = int.Parse(TbDecodeTimeValue);
            SharedValues.Settings.StationList[index].DM60X.DelayTime = int.Parse(TbDelayTimeValue);

            // Get Network Parameter
            SharedValues.Settings.StationList[index].DM60X.IPAddress = TbIPAddressValue;
            SharedValues.Settings.StationList[index].DM60X.Port = TbPortValue;
            SharedValues.Settings.StationList[index].DM60X.SubnetMask = TbSubnetValue;

            // Get Symbol Config
            SharedValues.Settings.StationList[index].DM60X.SymbolState = new bool[]
            {
                CheckBoxDataMatrix_Sts,
                CheckBoxQR_Sts,
                CheckBoxMaxi_Sts,
                CheckBoxAztec_Sts,

                CheckBox128_Sts,
                CheckBox25_Sts,
                CheckBox93_Sts,
                CheckBox39_Sts,
                CheckBoxPharma_Sts,
                CheckBoxCodabar_Sts,
                CheckBoxInterleaved_Sts,
                CheckBoxUPCEAN_Sts,
                CheckBoxMsi_Sts,

                CheckBoxPDF_Sts,
                CheckBoxEANUCC_Sts,
                CheckBoxMicro_Sts,
                CheckBoxGS1_Sts,

                CheckBoxPostnet_Sts,
                CheckBoxPlanet_Sts,
                CheckBoxJap_Sts,
                CheckBoxUPU_Sts,
                CheckBoxAus_Sts,
                CheckBoxIntel_Sts,
                false,
                false
            };
        }

        public void GetDeviceSettingValue()
        {
            //try
            //{
            //    var objectList = DM60XSharedValues.DeviceHandler.GetSettingValues();
            //    if (objectList != null)
            //    {
            //        #region Trigger Type [0] 
            //        if ((string)objectList[0] == "0")
            //            CbbTriggerTypeIndex = 0;
            //        else if ((string)objectList[0] == "3")
            //            CbbTriggerTypeIndex = 1;
            //        else
            //            CbbTriggerTypeIndex = -1;
            //        #endregion

            //        #region Delay Type [1] 
            //        if ((string)objectList[1] == "0")
            //            CbbDelayTypeIndex = 0;
            //        else if ((string)objectList[1] == "1")
            //            CbbDelayTypeIndex = 1;
            //        else
            //            CbbTriggerTypeIndex = -1;
            //        #endregion

            //        #region Decoder Timeout [2]
            //        TbDecodeTimeValue = (string)objectList[2];
            //        #endregion

            //        #region IP Address [3] 
            //        TbIPAddressValue = (string)objectList[3];
            //        #endregion

            //        #region SubnetMask [4] 
            //        TbSubnetValue = (string)(objectList[4]);
            //        #endregion

            //        #region Port [5] 
            //        TbPortValue = (string)objectList[5];
            //        #endregion

            //        #region Port [6-28] 
            //        _CheckBoxDataMatrix_Sts = (string)objectList[6] == "ON";
            //        _CheckBoxQR_Sts = (string)objectList[7] == "ON";
            //        _CheckBoxMaxi_Sts = (string)objectList[8] == "ON";
            //        _CheckBoxAztec_Sts = (string)objectList[9] == "ON";
            //        _CheckBox128_Sts = (string)objectList[10] == "ON";
            //        _CheckBox25_Sts = (string)objectList[11] == "ON";
            //        _CheckBox93_Sts = (string)objectList[12] == "ON";
            //        _CheckBox39_Sts = (string)objectList[13] == "ON";
            //        _CheckBoxPharma_Sts = (string)objectList[14] == "ON";
            //        _CheckBoxCodabar_Sts = (string)objectList[15] == "ON";
            //        _CheckBoxInterleaved_Sts = (string)objectList[16] == "ON";
            //        _CheckBoxUPCEAN_Sts = (string)objectList[17] == "ON";
            //        _CheckBoxMsi_Sts = (string)objectList[18] == "ON";
            //        _CheckBoxPDF_Sts = (string)objectList[19] == "ON";
            //        _CheckBoxEANUCC_Sts = (string)objectList[20] == "ON";
            //        _CheckBoxMicro_Sts = (string)objectList[21] == "ON";
            //        _CheckBoxGS1_Sts = (string)objectList[22] == "ON";
            //        _CheckBoxPostnet_Sts = (string)objectList[23] == "ON";
            //        _CheckBoxPlanet_Sts = (string)objectList[24] == "ON";
            //        _CheckBoxJap_Sts = (string)objectList[25] == "ON";
            //        _CheckBoxUPU_Sts = (string)objectList[26] == "ON";
            //        _CheckBoxAus_Sts = (string)objectList[27] == "ON";
            //        _CheckBoxIntel_Sts = (string)objectList[28] == "ON";
            //        #endregion
            //    }
            //}
            //catch (Exception)
            //{
            //}

        }

        internal void GetSavedValueSettingToElement(int index)
        {
            // Get Trigger Config
            CbbTriggerTypeIndex = SharedValues.Settings.StationList[index].DM60X.TriggerTypeIndex;
            CbbDelayTypeIndex = SharedValues.Settings.StationList[index].DM60X.DelayTypeIndex;
            TbDecodeTimeValue = SharedValues.Settings.StationList[index].DM60X.DecodeTime.ToString();
            TbDelayTimeValue = SharedValues.Settings.StationList[index].DM60X.DelayTime.ToString();

            // Get Network Parameter
            TbIPAddressValue = SharedValues.Settings.StationList[index].DM60X.IPAddress;
            TbPortValue = SharedValues.Settings.StationList[index].DM60X.Port;
            TbSubnetValue = SharedValues.Settings.StationList[index].DM60X.SubnetMask;

            //GetSymbol
            _CheckBoxDataMatrix_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[0];
            _CheckBoxQR_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[1];
            _CheckBoxMaxi_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[2];
            _CheckBoxAztec_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[3];
            _CheckBox128_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[4];
            _CheckBox25_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[5];
            _CheckBox93_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[6];
            _CheckBox39_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[7];
            _CheckBoxPharma_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[8];
            _CheckBoxCodabar_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[9];
            _CheckBoxInterleaved_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[10];
            _CheckBoxUPCEAN_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[11];
            _CheckBoxMsi_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[12];
            _CheckBoxPDF_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[13];
            _CheckBoxEANUCC_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[14];
            _CheckBoxMicro_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[15];
            _CheckBoxGS1_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[16];
            _CheckBoxPostnet_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[17];
            _CheckBoxPlanet_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[18];
            _CheckBoxJap_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[19];
            _CheckBoxUPU_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[20];
            _CheckBoxAus_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[21];
            _CheckBoxIntel_Sts = SharedValues.Settings.StationList[index].DM60X.SymbolState[22];
        }
        internal void SymbolGroupSelectChecked(string groupName)
        {
            //if(groupName == "2D")
            //{
            //    CheckBoxDataMatrix_Sts = CheckBox2D_Sts;
            //    CheckBoxQR_Sts = CheckBox2D_Sts;
            //    CheckBoxMaxi_Sts = CheckBox2D_Sts;
            //    CheckBoxAztec_Sts = CheckBox2D_Sts;
            //}
            //if (groupName == "1D")
            //{
            //    CheckBox128_Sts = CheckBox1D_Sts;
            //    CheckBox25_Sts = CheckBox1D_Sts;
            //    CheckBox93_Sts = CheckBox1D_Sts;
            //    CheckBox39_Sts = CheckBox1D_Sts;
            //    CheckBoxPharma_Sts = CheckBox1D_Sts;
            //    CheckBoxCodabar_Sts = CheckBox1D_Sts;
            //    CheckBoxInterleaved_Sts = CheckBox1D_Sts;
            //    CheckBoxUPCEAN_Sts = CheckBox1D_Sts;
            //    CheckBoxMsi_Sts = CheckBox1D_Sts;
            //}
            //if (groupName == "Stacked")
            //{
            //    CheckBoxPDF_Sts = CheckBoxStacked_Sts;
            //    CheckBoxEANUCC_Sts = CheckBoxStacked_Sts;
            //    CheckBoxMicro_Sts = CheckBoxStacked_Sts;
            //    CheckBoxGS1_Sts = CheckBoxStacked_Sts;
            //}
            //if (groupName == "Postal")
            //{
            //    CheckBoxPostnet_Sts = CheckBoxPostal_Sts;
            //    CheckBoxPlanet_Sts = CheckBoxPostal_Sts;
            //    CheckBoxJap_Sts = CheckBoxPostal_Sts;
            //    CheckBoxUPU_Sts = CheckBoxPostal_Sts;
            //    CheckBoxAus_Sts = CheckBoxPostal_Sts;
            //    CheckBoxIntel_Sts = CheckBoxPostal_Sts;
            //}
        }
       
        internal void RebootDevice() 
        {
            CommonFunctions.SetToMemoryFile("memoryMapFile_Reboot", 1, "1");
        }
        internal void ResetParams()
        {
            CommonFunctions.SetToMemoryFile("memoryMapFile_Reset", 1, "1");
        }
        public void ApplySettingFunction(int index)
        {
            try
            {
                UpdateCurrentSettingValue(index);
                CommonFunctions.GetFromMemoryFile("memoryMapFile_IP", 15, out string ip,out _);
                CommonFunctions.GetFromMemoryFile("memoryMapFile_Subnet", 15, out string subnet, out _);
                CommonFunctions.GetFromMemoryFile("memoryMapFile_Port", 4, out string port, out _);
                if(TbIPAddressValue != ip || TbPortValue != port || TbSubnetValue != subnet) 
                {
                    var dialougeRes = MessageBox.Show(
                        "Network params changed need restart !",
                        "Notify",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if(dialougeRes == MessageBoxResult.Yes)
                    {
                        CommonFunctions.SetToMemoryFile("memoryMapFile_isChangeNetwork", 1, "1");
                    }
                    else
                    {
                        CommonFunctions.SetToMemoryFile("memoryMapFile_isChangeNetwork", 1, "0");
                    }
                }
                SharedControlHandler.SendDM60XSettings(index);
                Thread.Sleep(1500);
                SharedFunctions.DM60XConfigResultNotify(index, true);
            }
            catch (Exception)
            {
                return;
            }

        }

        
    }
    #region TextUppercase
    [ValueConversion(typeof(string), typeof(string))]
    public class CapitalizationConverter : MarkupExtension, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value as string)?.ToUpper() ?? value; // If it's a string, call ToUpper(), otherwise, pass it through as-is.

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
    #endregion

}
