using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.Common.Controller;
using App.PVCFC_RFID.DataType;
using ML.Languages;
using ML.Common.Enum;
using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.Model;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using ML.DeviceTransfer.PVCFCRFID.Model;

namespace App.PVCFC_RFID.Design
{
    public partial class ucStationInfo : UserControl
    {
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
                    gStationStatus.Text = _Title;
                }));
            }
        }

        private bool _IsHideDetails = false;
        public bool IsHideDetails
        {
            get { return _IsHideDetails; }
            set
            {
                _IsHideDetails = value;
                CommonFunctions.Invoke(this, new Action(() =>
                {
                    lblTotal.Visible =
                    btnCheckSuccessDetails.Visible =
                    btnCheckFailedDetails.Visible =
                    btnActiveSuccessDetails.Visible =
                    btnActiveFailedDetails.Visible = !_IsHideDetails;
                }));
            }
        }

        private bool _IsHideStatus = false;
        public bool IsHideStatus
        {
            get { return _IsHideStatus; }
            set
            {
                _IsHideStatus = value;
                CommonFunctions.Invoke(this, new Action(() =>
                {
                    tblMainStatus.Visible = !_IsHideStatus;
                    if (_IsHideStatus)
                    {
                        tblHomeStatusMain.ColumnStyles[0] = new ColumnStyle(SizeType.AutoSize);
                    }
                }));
            }
        }


        private bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                CommonFunctions.Invoke(this, new Action(() =>
                {
                    if (_IsSelected)
                    {
                        gStationStatus.Font = new System.Drawing.Font(this.Font.FontFamily, (this.Font.Size + 4), FontStyle.Bold);
                        gStationStatus.ForeColor = SystemColors.HotTrack;
                        //
                        //lblStatus.Font =
                        lblCheckSuccess.Font =
                        lblCheckFailed.Font =
                        lblExportTotal.Font =
                        lblActiveSuccess.Font =
                        lblActiveFailed.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
                        //
                        tblHomeStatusMain.BackColor =
                            //
                        tblMainStatus.BackColor =
                        tblMainCheckSuccess.BackColor =
                        tblMainCheckFailed.BackColor =
                        tblMainExportTotal.BackColor =
                        tblMainActiveSuccess.BackColor =
                            //tblMainActiveFailed.BackColor = Color.FromArgb(198, 234, 237);//Color.FromArgb(136, 211, 225);//SystemColors.GradientActiveCaption;
                            //tblMainActiveFailed.BackColor = Color.FromArgb(200, 247, 215);//Color.FromArgb(136, 211, 225);//SystemColors.GradientActiveCaption;
                            //tblMainActiveFailed.BackColor = Color.FromArgb(204, 247, 255);//Color.FromArgb(136, 211, 225);//MediumAquamarineSystemColors.GradientActiveCaption;
                            //tblMainActiveFailed.BackColor = Color.Azure;//Color.FromArgb(136, 211, 225);//SystemColors.GradientActiveCaption;
                            //tblMainActiveFailed.BackColor = Color.MediumAquamarine;//Color.FromArgb(136, 211, 225);//MediumAquamarineSystemColors.GradientActiveCaption;
                        //tblMainActiveFailed.BackColor = Color.FromArgb(196, 255, 196);//Color.FromArgb(136, 211, 225);//MediumAquamarineSystemColors.GradientActiveCaption;
                        //tblMainActiveFailed.BackColor = Color.FromArgb(204, 247, 255);
                        //tblMainActiveFailed.BackColor = Color.FromArgb(85, 175, 249);
                        //tblMainActiveFailed.BackColor = Color.Honeydew;
                        //tblMainActiveFailed.BackColor = Color.FromArgb(204, 247, 255);
                        tblMainActiveFailed.BackColor = Color.FromArgb(196, 255, 196);
                    }
                    else
                    {
                        gStationStatus.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, FontStyle.Regular);
                        gStationStatus.ForeColor = SystemColors.ControlText;
                        //
                        //lblStatus.Font =
                        lblCheckSuccess.Font =
                        lblCheckFailed.Font =
                        lblExportTotal.Font =
                        lblActiveSuccess.Font =
                        lblActiveFailed.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, FontStyle.Regular);
                        //
                        tblHomeStatusMain.BackColor = SystemColors.Control;
                        //
                        tblMainStatus.BackColor =
                        tblMainCheckSuccess.BackColor =
                        tblMainCheckFailed.BackColor =
                        tblMainExportTotal.BackColor =
                        tblMainActiveSuccess.BackColor =
                            //tblMainActiveFailed.BackColor = Color.WhiteSmoke;ControlLightLight
                            //tblMainActiveFailed.BackColor = SystemColors.ControlLightLight;
                        tblMainActiveFailed.BackColor = Color.FromArgb(251, 251, 251);
                    }
                }));
            }
        }
        //
        private bool _IsBinding = false;
        #endregion//End Properties

        #region Events
        public event EventHandler ControlEvents;
        public event EventHandler DetailsEvents;
        #endregion//End Events

        public ucStationInfo()
        {
            InitializeComponent();
            //
            InitControls();
            InitLanguages();
            InitEvents();
        }

        #region Inits
        private void InitControls()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            //
            mbtnStatus.AutoEllipsis = false;
        }

        private void InitLanguages()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                gStationStatus.Text = "";
                lblCheckSuccess.Text = Languages.ScanSuccess;
                lblCheckSuccessValues.Text = "0";
                lblCheckFailed.Text = Languages.ScanFailed;
                lblCheckFailedValues.Text = "0";
                //switch(SharedValues.Settings.Model)
                //{
                //    case PVCFCOperationEnum.Export:
                //        lblExportTotal.Text = Languages.QuantityToExport;
                //        break;
                //    case PVCFCOperationEnum.Import:
                //        lblExportTotal.Text = Languages.QuantityToImport;
                //        break;
                //}
                lblExportTotal.Text = Languages.Quantity;
                lblExportTotalValues.Text = "0";
                lblTotal.Text = "0";
                lblActiveSuccess.Text = Languages.ActivedSuccess;
                lblActiveSuccessValues.Text = "0";
                lblActiveFailed.Text = Languages.ActivedFailed;
                lblActiveFailedValues.Text = "0";
                //
                btnCheckSuccessDetails.Text =
                btnCheckFailedDetails.Text =
                btnActiveSuccessDetails.Text =
                btnActiveFailedDetails.Text = Languages.Details;
                //
                mbtnStatus.Text = Languages.Stop.ToUpper();
            }));
        }

        private void InitEvents()
        {
            this.Load+=ucStationInfo_Load;
            //
            btnCheckSuccessDetails.Click += btnDetails_Click;
            btnCheckFailedDetails.Click += btnDetails_Click;
            btnActiveSuccessDetails.Click += btnDetails_Click;
            btnActiveFailedDetails.Click += btnDetails_Click;
            //
            mbtnStatus.Click+=mbtnStatus_Click;
        }

        private void InitData()
        {
            if(!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }
        #endregion//End Inits

        #region Events
        private void ucStationInfo_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    PVCFCProductItemStatusEnum status =PVCFCProductItemStatusEnum.None;
                    if(sender == btnCheckSuccessDetails)
                    {
                        status = PVCFCProductItemStatusEnum.CheckedSuccess;
                    }
                    else if(sender == btnCheckFailedDetails)
                    {
                        status =PVCFCProductItemStatusEnum.CheckedFailed;
                    }
                    else if (sender == btnActiveSuccessDetails)
                    {
                        status = PVCFCProductItemStatusEnum.ActivedSuccess;
                    }
                    else if (sender == btnActiveFailedDetails)
                    {
                        status = PVCFCProductItemStatusEnum.ActivedFailed;
                    }
                    //
                    if(DetailsEvents!=null)
                    {
                        Tuple<int, PVCFCProductItemStatusEnum> tuple = new Tuple<int,PVCFCProductItemStatusEnum>(_Index, status);
                        DetailsEvents(tuple, EventArgs.Empty);
                    }
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }

        private void mbtnStatus_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    if(ControlEvents!=null)
                    {
                        ControlEvents(_Index, EventArgs.Empty);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }
        #endregion//End Events

        #region Methods
        public void LoadData(PVCFCDistributionSchedulesModel schedules)
        {
            CommonFunctions.Invoke(this, new Action(() =>
                {
                    lblCheckSuccessValues.Text = schedules.ScanSucess.ToString("N0");
                    lblCheckFailedValues.Text = schedules.ScanFailed.ToString("N0");
                    lblActiveSuccessValues.Text = schedules.ActiveSuccess.ToString("N0");
                    lblActiveFailedValues.Text = schedules.ActiveFailed.ToString("N0");
                    lblExportTotalValues.Text = schedules.Total.ToString("N0");
                }));
        }

        public void LoadData()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                lblCheckSuccessValues.Text = SharedValues.Running.StationList[_Index].Schedules.ScanSucess.ToString("N0");
                lblCheckFailedValues.Text = SharedValues.Running.StationList[_Index].Schedules.ScanFailed.ToString("N0");
                lblActiveSuccessValues.Text = SharedValues.Running.StationList[_Index].Schedules.ActiveSuccess.ToString("N0");
                lblActiveFailedValues.Text = SharedValues.Running.StationList[_Index].Schedules.ActiveFailed.ToString("N0");
                lblExportTotalValues.Text = SharedValues.Running.StationList[_Index].Schedules.Total.ToString("N0");
                lblExportTotalValues.Text = SharedValues.Running.StationList[_Index].Schedules.OrderedTotal.ToString("N0");
            }));
        }

        public void StatusChanged(RunningStatusEnum status)
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                switch (status)
                {
                    case RunningStatusEnum.Connected:
                    case RunningStatusEnum.Stop:
                        mbtnStatus.ButtonStyle = ML.Controls.ButtonStylesEnum.Danger;
                        break;

                    case RunningStatusEnum.Disconnected:
                    case RunningStatusEnum.Block:
                    case RunningStatusEnum.Error:
                    default:
                        mbtnStatus.ButtonStyle = ML.Controls.ButtonStylesEnum.Default;
                        break;
                    case RunningStatusEnum.Processing:
                        mbtnStatus.ButtonStyle = ML.Controls.ButtonStylesEnum.Warning;
                        break;
                    case RunningStatusEnum.Ready:
                        mbtnStatus.ButtonStyle = ML.Controls.ButtonStylesEnum.Success;
                        break;
                    case RunningStatusEnum.Starting:
                        mbtnStatus.ButtonStyle = ML.Controls.ButtonStylesEnum.Success;
                        break;
                }
                mbtnStatus.Text = LanguagesFunctions.GetTranslate(status.ToString()).ToUpper();
            }));

        }

        public void RefreshData()
        {
            LoadData();
            StatusChanged(SharedValues.Running.StationList[_Index].Status);
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

    }
}
