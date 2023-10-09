using App.PVCFC_RFID.Controller;
using ML.Common.Controller;
using ML.SDK.RDIF_FX9600.DataType;
using ML.Languages;
using Symbol.RFID3;
using System;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.PVCFC_RFID.Design
{
    public partial class ucSettingsItemsRFIDZebraFX9600 : UserControl
    {
        #region Field
        private int _MinValueTagReport = 0;
        private int _MinValueMaxTagCount = 0;
        private int _MinValueMaxTagIDLength = 0;
        private int _MinValueMaxSizeMemoryBank = 7;
        private int _MinValueDurationStop = 0;
        private int _MinValueGPITimeoutStop = 0;
        private int _MinValueRssiValue = -100;

        private int _MaxValueTagReport = 1000;
        private int _MaxValueMaxTagCount = 4096;
        private int _MaxValueMaxTagIDLength = 100;
        private int _MaxValueMaxSizeMemoryBank = 100;
        private int _MaxValueDurationStop = 30000;
        private int _MaxValueGPITimeoutStop = 30000;
        private int _MaxValueRssiValue = 0;
        #endregion

        #region Properties
        private int _Index = 0;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        private string _Title = "";
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;

                CommonFunctions.Invoke(this, new Action(() =>
                {
                    //gRFIDConfig.Text = _Title;
                }));
            }
        }

        private bool _IsBinding = false;
        #endregion//End Properties

        public ucSettingsItemsRFIDZebraFX9600()
        {
            InitializeComponent();
            InitControls();
            InitLanguages();
            InitEvents();
        }

        #region Inits
        private void InitLanguages()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                lblAnthennaID.Text = Languages.AntennaID;
                lblTransmitPower.Text = Languages.TransmitPower;
                lblGpiEn.Text = Languages.GPIEnable;
                lblGpoSts.Text = Languages.GPOStates;
                lblStartTriggerType.Text = Languages.TriggerType;
                lblGPIPortStart.Text = Languages.Port;
                lblGPIEventStart.Text = Languages.Event;
                radioButtonLHStart.Text = Languages.LH;
                radioButtonHLStart.Text = Languages.HL;
                lblRSSIMode.Text = Languages.Mode;
                chkRSSIMode.Text = Languages.Filter;
                lblMaxTagCount.Text = Languages.MaxTagCount;
                lblMaxTbIDLength.Text = Languages.MaxTagIDLength;
                lblMaxSizeMemoryBank.Text = Languages.MaxSizeMemoryBank;
                lblStopTriggerType.Text = Languages.TriggerType;
                lblGPIPortStop.Text = Languages.Port;
                lblGPIEventStop.Text = Languages.Event;
                lblGPITimeoutStop.Text = Languages.Timeout;
                radioButtonLHStop.Text = Languages.LH;
                radioButtonHLStop.Text = Languages.HL;
                grbTagStorage.Text = Languages.TAGSTORAGE;
                grbTriggers.Text = Languages.TRIGGERS;
                grbFilterData.Text = Languages.FilterData;
                grbStopTrigger.Text = Languages.StopTrigger;
                grbGPIParams.Text = Languages.GPIParams;
                grbStartTrigger.Text = Languages.StartTrigger;
                lblTagRpTrigger.Text = Languages.TagReportTrigger;
                btnApply.Text = Languages.Apply;
            }));

        }
        private void InitControls()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.Font = new System.Drawing.Font(Properties.Settings.Default.FontFamily, Properties.Settings.Default.FontSize);
                //
                btnStartRead.Visible =
                btnStopRead.Visible = false;
            }));
        }
        private void InitEvents()
        {
            this.Load += UcSettingsItemsRFIDZebraFX9600_Load;
            //
            btnApply.Click += btnApply_Click;
            btnStartRead.Click += BtnStartRead_Click;
            btnStopRead.Click += BtnStopRead_Click;
            cbxTriggerTypeStop.SelectedIndexChanged += CbxTriggerTypeStop_SelectedIndexChanged;
            cbxTriggerTypeStart.SelectedIndexChanged += CbxTriggerTypeStart_SelectedIndexChanged;
            chkRSSIMode.CheckedChanged+=chkRSSIMode_CheckedChanged;

            // validating
            textBoxTagReportTrigger.Validating += TextBoxTagRpTrig_Validating;
            numlblMaxTagCount.Validating += NumlblMaxTagCount_Validating;
            numMaxTbIDLength.Validating += NumMaxTbIDLength_Validating;
            numMaxSizeMemoryBank.Validating += NumMaxSizeMemoryBank_Validating;
            numDurationStop.Validating += NumDurationStop_Validating;
            numGPITimeoutStop.Validating += NumGPITimeoutStop_Validating;
            textBoxRssiVal.Validating += NumRSSIFilter_Validating;
        }

        private void InitData()
        {
            #region FirstLoad Value
            GetSavedValueSettingToElement();
            #endregion
        }
        #endregion//End Inits

        #region Events
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    GetElementValueToSetting();
                    SharedControlHandler.SendRFIDSettings(_Index);
                    Thread.Sleep(2000); // Wait for RFID Apply setting
                    SharedFunctions.ConfigResultNotify(_Index,true);
                }
                catch (Exception)
                {
                    //
                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }
        private void BtnStartRead_Click(object sender, EventArgs e)
        {
            //if (!_IsBinding)
            //{
            //    try
            //    {
            //        _IsBinding = true;
            //        SharedValues.Settings.StationList[_Index].RFID.TypeOfOperation = RFID_OPERATION_TYPE.StartRead;
            //        SharedControlHandler.SendRFIDOperationCmd(_Index);
            //    }
            //    catch (Exception)
            //    {

            //    }
            //    finally
            //    {
            //        _IsBinding = false;
            //    }
            //}
           
        }
        private void BtnStopRead_Click(object sender, EventArgs e)
        {
            //if (!_IsBinding)
            //{
            //    try
            //    {
            //        _IsBinding = true;
            //        SharedValues.Settings.StationList[_Index].RFID.TypeOfOperation = RFID_OPERATION_TYPE.StopRead;
            //        SharedControlHandler.SendRFIDOperationCmd(_Index);
            //    }
            //    catch (Exception)
            //    {

            //    }
            //    finally
            //    {
            //        _IsBinding = false;
            //    }
            //}
        }

        #region Control Event
        private void UcSettingsItemsRFIDZebraFX9600_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //
            InitData();
        }

        private void CbxTriggerTypeStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = (System.Windows.Forms.ComboBox)sender;
            grbGPIParams.Visible = obj.SelectedIndex == 1;
        }

        private void chkRSSIMode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRSSIStatus();
        }

        private void CbxTriggerTypeStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = (System.Windows.Forms.ComboBox)sender;
            grbGPIWithTimeout.Visible = obj.SelectedIndex == 2;
            numDurationStop.Visible = obj.SelectedIndex == 1;
            lblTriggerTypeStopUnit.Visible = obj.SelectedIndex == 1;
        }

        #region Valid Value Event
        private void NumRSSIFilter_Validating(object sender, CancelEventArgs e)
        {
            MessageBoxValueValid(sender, e, _MinValueRssiValue, _MaxValueRssiValue);
        }

        private void NumGPITimeoutStop_Validating(object sender, CancelEventArgs e)
        {
            MessageBoxValueValid(sender, e, _MinValueGPITimeoutStop, _MaxValueGPITimeoutStop);
        }

        private void NumDurationStop_Validating(object sender, CancelEventArgs e)
        {
            MessageBoxValueValid(sender, e, _MinValueDurationStop, _MaxValueDurationStop);
        }

        private void NumMaxSizeMemoryBank_Validating(object sender, CancelEventArgs e)
        {
            MessageBoxValueValid(sender, e, _MinValueMaxSizeMemoryBank, _MaxValueMaxSizeMemoryBank);
        }

        private void NumMaxTbIDLength_Validating(object sender, CancelEventArgs e)
        {
            MessageBoxValueValid(sender, e, _MinValueMaxTagIDLength, _MaxValueMaxTagIDLength);
        }

        private void NumlblMaxTagCount_Validating(object sender, CancelEventArgs e)
        {
            MessageBoxValueValid(sender, e, _MinValueMaxTagCount, _MaxValueMaxTagCount);
        }

        private void TextBoxTagRpTrig_Validating(object sender, CancelEventArgs e)
        {
            MessageBoxValueValid(sender, e, _MinValueTagReport, _MaxValueTagReport);
        }

        private void MessageBoxValueValid(object sender, CancelEventArgs e, int valMin, int valMax)
        {
            var objType = sender.GetType();
            switch (objType.FullName)
            {
                case "System.Windows.Forms.TextBox":
                    try
                    {
                        var obj = (System.Windows.Forms.TextBox)sender;
                        if (string.IsNullOrEmpty(obj.Text))
                            e.Cancel = true;
                        var val = int.Parse(obj.Text.ToString());
                        if (val < valMin || val > valMax)
                        {
                            MessageBoxWarning(string.Format(Languages.MsgValueMustBe, valMin, valMax));
                            e.Cancel = true;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBoxWarning(Languages.MsgFailFormat);
                        e.Cancel = true;
                    }
                    break;
                case "System.Windows.Forms.NumericUpDown":
                    try
                    {
                        var obj = (NumericUpDown)sender;
                        if (string.IsNullOrEmpty(obj.Text))
                            e.Cancel = true;
                        var val = int.Parse(obj.Text.ToString());
                        if (val < valMin || val > valMax)
                        {
                            MessageBoxWarning(string.Format(Languages.MsgValueMustBe, valMin, valMax));
                            e.Cancel = true;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBoxWarning(Languages.MsgFailFormat);
                        e.Cancel = true;
                    }
                    break;
            }


        }
        private void MessageBoxWarning(string input)
        {
            MessageBox.Show(
                            input,
                            Languages.MsgValueValidate,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1
                            );
        }

        #endregion

        #endregion
        #region Helper Method
        private void GetSavedValueSettingToElement()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                #region RFID 
                //cbxAnthennaID.SelectedIndex = SharedValues.Settings.StationList[_Index].RFID.AntennaID;
                //cbxTransmitPower.SelectedIndex = SharedValues.Settings.StationList[_Index].RFID.TransPowerID;
                //cbxTriggerTypeStart.SelectedIndex = SharedValues.Settings.StationList[_Index].RFID.ModeStart == START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE ? 0 : 1;
                //cbxGPIPortStart.SelectedIndex = SharedValues.Settings.StationList[_Index].RFID.GpiStartPin - 1;
                //radioButtonLHStart.Checked = SharedValues.Settings.StationList[_Index].RFID.GpiStartEvent == 0;
                //textBoxTagReportTrigger.Text = SharedValues.Settings.StationList[_Index].RFID.TagReportTrigger.ToString();
                //switch (SharedValues.Settings.StationList[_Index].RFID.ModeStop)
                //{
                //    case STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE:
                //        cbxTriggerTypeStop.SelectedIndex = 0;
                //        break;
                //    case STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION:
                //        cbxTriggerTypeStop.SelectedIndex = 1;
                //        break;
                //    case STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_GPI_WITH_TIMEOUT:
                //        cbxTriggerTypeStop.SelectedIndex = 2;
                //        break;
                //}
                //numDurationStop.Value = SharedValues.Settings.StationList[_Index].RFID.DurationStop;
                //numlblMaxTagCount.Value = SharedValues.Settings.StationList[_Index].RFID.MaxTagCount;
                //numMaxTbIDLength.Value = SharedValues.Settings.StationList[_Index].RFID.MaxTagIDLength;
                //numMaxSizeMemoryBank.Value = SharedValues.Settings.StationList[_Index].RFID.MaxSizeMemoryBank;

                //checkBoxGPI1.Checked = SharedValues.Settings.StationList[_Index].RFID.GPIArray[0] == 1;
                //checkBoxGPI2.Checked = SharedValues.Settings.StationList[_Index].RFID.GPIArray[1] == 1;
                //checkBoxGPI3.Checked = SharedValues.Settings.StationList[_Index].RFID.GPIArray[2] == 1;
                //checkBoxGPI4.Checked = SharedValues.Settings.StationList[_Index].RFID.GPIArray[3] == 1;

                //checkBoxGPO1.Checked = SharedValues.Settings.StationList[_Index].RFID.GPOArray[0] == 1;
                //checkBoxGPO2.Checked = SharedValues.Settings.StationList[_Index].RFID.GPOArray[1] == 1;
                //checkBoxGPO3.Checked = SharedValues.Settings.StationList[_Index].RFID.GPOArray[2] == 1;
                //checkBoxGPO4.Checked = SharedValues.Settings.StationList[_Index].RFID.GPOArray[3] == 1;

                //chkRSSIMode.Checked = SharedValues.Settings.StationList[_Index].RFID.RSSIFilterOn == 1;
                //textBoxRssiVal.Text = SharedValues.Settings.StationList[_Index].RFID.RSSI_Filter.ToString();
                //UpdateRSSIStatus();
                ////

                //cbxGPIPortStop.SelectedIndex = SharedValues.Settings.StationList[_Index].RFID.GPIStopPin - 1;
                //radioButtonLHStop.Checked = SharedValues.Settings.StationList[_Index].RFID.GPIStopEvent == 0;
                //numGPITimeoutStop.Value = SharedValues.Settings.StationList[_Index].RFID.GPIStopTimeout;
                ////
                #endregion
            }));
        }
        private void GetElementValueToSetting()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                #region RFID
                //SharedValues.Settings.StationList[_Index].RFID.AntennaID = cbxAnthennaID.SelectedIndex; // 0
                //SharedValues.Settings.StationList[_Index].RFID.TransPowerID = cbxTransmitPower.SelectedIndex; //0
                //SharedValues.Settings.StationList[_Index].RFID.ModeStart = cbxTriggerTypeStart.SelectedIndex
                //== 0 ? START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE : START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI;
                //SharedValues.Settings.StationList[_Index].RFID.GpiStartPin = cbxGPIPortStart.SelectedIndex + 1;
                //SharedValues.Settings.StationList[_Index].RFID.GpiStartEvent = radioButtonLHStart.Checked ? 0 : 1;
                //SharedValues.Settings.StationList[_Index].RFID.TagReportTrigger = int.Parse(textBoxTagReportTrigger.Text);
                //switch (cbxTriggerTypeStop.SelectedIndex)
                //{
                //    case 0:
                //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE;
                //        break;
                //    case 1:
                //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                //        break;
                //    case 2:
                //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_GPI_WITH_TIMEOUT;
                //        break;
                //}
                //SharedValues.Settings.StationList[_Index].RFID.DurationStop = (int)numDurationStop.Value;

                //SharedValues.Settings.StationList[_Index].RFID.MaxTagCount = (int)numlblMaxTagCount.Value;
                //SharedValues.Settings.StationList[_Index].RFID.MaxTagIDLength = (int)numMaxTbIDLength.Value;
                //SharedValues.Settings.StationList[_Index].RFID.MaxSizeMemoryBank = (int)numMaxSizeMemoryBank.Value;

                //SharedValues.Settings.StationList[_Index].RFID.GPIArray[0] = checkBoxGPI1.Checked ? 1 : 0;
                //SharedValues.Settings.StationList[_Index].RFID.GPIArray[1] = checkBoxGPI2.Checked ? 1 : 0;
                //SharedValues.Settings.StationList[_Index].RFID.GPIArray[2] = checkBoxGPI3.Checked ? 1 : 0;
                //SharedValues.Settings.StationList[_Index].RFID.GPIArray[3] = checkBoxGPI4.Checked ? 1 : 0;

                //SharedValues.Settings.StationList[_Index].RFID.GPOArray[0] = checkBoxGPO1.Checked ? 1 : 0;
                //SharedValues.Settings.StationList[_Index].RFID.GPOArray[1] = checkBoxGPO2.Checked ? 1 : 0;
                //SharedValues.Settings.StationList[_Index].RFID.GPOArray[2] = checkBoxGPO3.Checked ? 1 : 0;
                //SharedValues.Settings.StationList[_Index].RFID.GPOArray[3] = checkBoxGPO4.Checked ? 1 : 0;

                //SharedValues.Settings.StationList[_Index].RFID.RSSI_Filter = int.Parse(textBoxRssiVal.Text.ToString());
                //SharedValues.Settings.StationList[_Index].RFID.RSSIFilterOn = chkRSSIMode.Checked ? 1 : 0;


                //SharedValues.Settings.StationList[_Index].RFID.GPIStopPin = cbxGPIPortStop.SelectedIndex + 1;
                //SharedValues.Settings.StationList[_Index].RFID.GPIStopEvent = radioButtonLHStop.Checked ? 0 : 1;
                //SharedValues.Settings.StationList[_Index].RFID.GPIStopTimeout = (int)numGPITimeoutStop.Value;

                #endregion
            }));
        }
        #endregion

        #endregion//End Events

        #region Methods
        /// <summary>
        /// Null is success
        /// </summary>
        /// <returns></returns>
        private string CheckData()
        {
            //
            //
            return null;
        }
        private void LoadData()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                //Set settings to controls
                //Ex
                //cbxAnthennaID.SelectedIndex = SharedValues.Settings.StationList[_Index].RFID.AntennaID;
                //
            }));
        }
        private void UpdateRSSIStatus()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    textBoxRssiVal.Enabled = chkRSSIMode.Checked;
                }));
        }

        #endregion//End Methods

        #region Fixed flickering forms - https://www.youtube.com/watch?v=_h-UXxp3cd0&t=116s

        /// <summary>
        /// Linh.Tran
        /// On 190904
        /// Methods override is fix error Controls in usercontrol flicker while usercontrol visiblity changes
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion//End Fixed flickering forms

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
