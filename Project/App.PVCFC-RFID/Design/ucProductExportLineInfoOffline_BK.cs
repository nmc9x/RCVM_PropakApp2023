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
using ML.Languages;
using ML.Common.Enum;
using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.Model;
using ML.DeviceTransfer.PVCFCRFID.Model;

namespace App.PVCFC_RFID.Design
{
    public partial class ucProductExportLineInfoOffline_BK : UserControl
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
                    //
                }));
            }
        }
        private bool _IsBinding = false;
        #endregion//End Properties

        #region Event Handler
        public event EventHandler ControlsEvent;
        #endregion//End Event Handler
        public ucProductExportLineInfoOffline_BK()
        {
            InitializeComponent();
            InitControls();
            InitLanguages();
            InitEvents();
            InitData();
        }

        #region Inits
        private void InitControls()
        {
            SharedFunctions.Invoke(this, new Action(() =>
               {
                   //
                   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                   //
                   dateMFG.Format = DateTimePickerFormat.Custom;
                   dateMFG.CustomFormat = Properties.Settings.Default.DateFormat;
                   dateEXP.Format = DateTimePickerFormat.Custom;
                   dateEXP.CustomFormat = Properties.Settings.Default.DateFormat;
                   //
                   numTotalExport.Minimum = 0;
                   numTotalExport.Maximum = 100000;
               }));
        }

        private void InitLanguages()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    grSchedules.Text = Languages.ActivationParameters;
                    lblProductName.Text = Languages.ProductionName;
                    lblAgent.Text = Languages.AgencyLevel1;
                    //
                    grSchedulesInfo.Text = Languages.SchedulesInfo;
                    lblDeliveryOrderCode.Text = Languages.DeliveryBill;
                    lblWarehouseReceiptCode.Text = Languages.Ordered;
                    lblLOTNo.Text = Languages.LOTNo;
                    lblMFG.Text = Languages.DateOfManufacture;
                    lblEXP.Text = Languages.DateOfExpiry;
                    lblTotalExport.Text = Languages.Quantity;
                }));
        }

        private void InitEvents()
        {
            btnStart.Click += btnControls_Click;
            btnStop.Click += btnControls_Click;
            btnTrigger.Click += btnControls_Click;
        }

        private void InitData()
        {

        }
        #endregion//End Inits

        #region Events
        private void btnControls_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    ControlsEventEnum events = ControlsEventEnum.Stop;
                    if (sender == btnStart)
                    {
                        events = ControlsEventEnum.Start;
                    }
                    else if (sender == btnStop)
                    {
                        events = ControlsEventEnum.Stop;
                    }
                    else if (sender == btnTrigger)
                    {
                        events = ControlsEventEnum.Trigger;
                    }
                    if (ControlsEvent != null)
                    {
                        ControlsEvent((new Tuple<int, ControlsEventEnum>(_Index, events)), EventArgs.Empty);
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
        public void LoadData()
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            PVCFCDistributionSchedulesModel schedules = SharedValues.Running.StationList[_Index].Schedules;
                            txtProductName.Text = schedules.ProductNameOffline;
                            txtAgent.Text = schedules.AgencyLevel1;
                            txtDeliveryOrderCode.Text = schedules.DeliveryBill;
                            txtWarehouseReceiptCode.Text = schedules.Ordered;
                            dateMFG.Value = schedules.DateManufacture;
                            dateEXP.Value = schedules.Expiry;
                            numTotalExport.Value = schedules.OrderedTotal;
                        }));
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

        public void SetData()
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        PVCFCDistributionSchedulesModel schedules = SharedValues.Running.StationList[_Index].Schedules;
                        SharedValues.Running.StationList[_Index].Schedules.ProductNameOffline = txtProductName.Text;
                        SharedValues.Running.StationList[_Index].Schedules.AgencyLevel1 = txtAgent.Text;
                        SharedValues.Running.StationList[_Index].Schedules.DeliveryBill = txtDeliveryOrderCode.Text;
                        SharedValues.Running.StationList[_Index].Schedules.Ordered = txtWarehouseReceiptCode.Text;
                        SharedValues.Running.StationList[_Index].Schedules.DateManufacture = dateMFG.Value;
                        dateEXP.Value = schedules.Expiry;
                        SharedValues.Running.StationList[_Index].Schedules.OrderedTotal = (int)numTotalExport.Value;
                    }));
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

        public void StatusChanged(RunningStatusEnum status)
        {
            switch (status)
            {
                case RunningStatusEnum.Connected:
                case RunningStatusEnum.Stop:
                case RunningStatusEnum.Disconnected:
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        btnStart.Enabled = true;
                        btnStop.Enabled = false;
                        btnTrigger.Enabled = true;
                        //
                        txtProductName.Enabled =
                        txtAgent.Enabled =
                        txtDeliveryOrderCode.Enabled =
                        txtWarehouseReceiptCode.Enabled =
                        txtLOTNo.Enabled =
                        dateMFG.Enabled =
                        dateEXP.Enabled =
                        numTotalExport.Enabled = true;
                    }));
                    //
                    break;
                case RunningStatusEnum.Processing:
                case RunningStatusEnum.Ready:
                case RunningStatusEnum.Starting:
                    SharedFunctions.Invoke(this, new Action(() =>
                   {
                       btnStart.Enabled = false;
                       btnStop.Enabled = true;
                       btnTrigger.Enabled = false;
                       //
                       txtProductName.Enabled =
                       txtAgent.Enabled =
                       txtDeliveryOrderCode.Enabled =
                       txtWarehouseReceiptCode.Enabled =
                       txtLOTNo.Enabled =
                       dateMFG.Enabled =
                       dateEXP.Enabled =
                       numTotalExport.Enabled = false;
                   }));
                    break;
            }
        }
        #endregion//End Methods
    }
}
