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
using ML.DeviceTransfer.PVCFCRFID.DataType;

namespace App.PVCFC_RFID.Design
{
    public partial class ucStationInfo_230905 : UserControl
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
                    pnlTotalExportDetails.Visible =
                    btnCheckSuccessDetails.Visible =
                    btnCheckFailedDetails.Visible =
                    btnActiveSuccessDetails.Visible =
                    btnActiveFailedDetails.Visible = !_IsHideDetails;
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
                        gStationStatus.Font = new System.Drawing.Font(gStationStatus.Font.FontFamily, gStationStatus.Font.Size, FontStyle.Bold);
                        tblHomeStatusMain.BackColor = SystemColors.Highlight;
                    }
                    else
                    {
                        gStationStatus.Font = new System.Drawing.Font(gStationStatus.Font.FontFamily, gStationStatus.Font.Size, FontStyle.Regular);
                        tblHomeStatusMain.BackColor = SystemColors.Control;
                    }
                }));
            }
        }
        //
        private bool _IsBinding = false;
        #endregion//End Properties

        public ucStationInfo_230905()
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
        }

        private void InitLanguages()
        {

        }

        private void InitEvents()
        {
            this.Load+=ucStationInfo_Load;
            //
            btnCheckSuccessDetails.Click += btnDetails_Click;
            btnCheckFailedDetails.Click += btnDetails_Click;
            btnActiveSuccessDetails.Click += btnDetails_Click;
            btnActiveFailedDetails.Click += btnDetails_Click;

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
        #endregion//End Events

        #region Methods
        public void LoadData(int success, int failed, int activeSucess, int activeFailed)
        {
            CommonFunctions.Invoke(this, new Action(() =>
                {
                    lblCheckSuccess.Text = success.ToString("N0");
                    lblCheckFailed.Text = success.ToString("N0");
                    lblActiveSuccess.Text = success.ToString("N0");
                    lblActiveFailed.Text = success.ToString("N0");
                }));
        }

        private void ShowFormDetails(PVCFCProductItemStatusEnum status)
        {
            frmProductDetails frm = new frmProductDetails(_Index, new Point(0, 0), new System.Drawing.Size(500, 500), status);
            frm.ShowDialog();
        }
        #endregion//End Methods
    }
}
