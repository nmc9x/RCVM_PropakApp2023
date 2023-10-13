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
using ML.DeviceTransfer.PVCFCRFID.APISAASModel;
using System.Threading;
using ML.Controls;
using Symbol.RFID3;

namespace App.PVCFC_RFID.Design
{
    public partial class ucProductExportLineInfo : UserControl
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
        public ucProductExportLineInfo()
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
                   //
                   numTotalExport.Minimum = 0;
                   numTotalExport.Maximum = 100000;
                   //Hide NSX - HSD
                   lblMFG.Visible =
                   dateMFG.Visible =
                       //
                   lblEXP.Visible =
                   dateEXP.Visible = false;

                   tblSchedulesInfo.RowStyles[6].SizeType =
                   tblSchedulesInfo.RowStyles[7].SizeType =
                   tblSchedulesInfo.RowStyles[8].SizeType =
                   tblSchedulesInfo.RowStyles[9].SizeType = SizeType.AutoSize;
                   //
                   grSchedulesInfo.Height = 168;
                   //End Hide MSX - HSD
                   //
                   //
                   if (SharedValues.Running.IsOffline)
                   {
                       lblProductName.Visible =
                       txtProductNameSearch.Visible =
                       btnProductNameSearch.Visible =
                       btnProductNameReload.Visible =
                       listBoxProductName.Visible = false;
                       ////
                       lblAgent.Visible =
                       txtAgentSearch.Visible =
                       btnAgentSearch.Visible =
                       btnAgentReload.Visible =
                       listBoxAgentLevel1.Visible = false;
                       //
                       tblExportSchedules.RowStyles[0].SizeType =
                       tblExportSchedules.RowStyles[3].SizeType =
                       tblExportSchedules.RowStyles[4].SizeType =
                       tblExportSchedules.RowStyles[7].SizeType = SizeType.AutoSize;
                       //
                   }
                   else
                   {
                       lblProductNameOffline.Visible =
                       txtProductNameOffline.Visible = false;
                       //
                       lblAgentOffline.Visible =
                       txtAgentOffline.Visible = false;
                       //
                       tblExportSchedules.RowStyles[8].SizeType =
                       tblExportSchedules.RowStyles[10].SizeType =
                       tblExportSchedules.RowStyles[11].SizeType =
                       tblExportSchedules.RowStyles[13].SizeType = SizeType.AutoSize;
                   }
               }));
        }

        private void InitLanguages()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    grSchedules.Text = Languages.ActivationParameters;
                    lblProductNameOffline.Text = Languages.ProductionName;
                    lblAgentOffline.Text = Languages.AgencyLevel1;
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
            //btnStart.Click += btnControls_Click;
            //btnStop.Click += btnControls_Click;
            
            btnStart.Click += StartPrintProcess;
            btnStop.Click += StopPrintProcess;
            btnTrigger.Click += TriggerClick;
            //
            txtProductNameSearch.TextChanged += btnProductNameSearch_Click;
            btnProductNameSearch.Click+=btnProductNameSearch_Click;
            txtAgentSearch.TextChanged += btnAgentSearch_Click;
            btnAgentSearch.Click+=btnAgentSearch_Click;
            //
            btnProductNameReload.Click+=btnProductNameReload_Click;
            btnAgentReload.Click+=btnAgentReload_Click;
        }

        private void TriggerClick(object sender, EventArgs e)
        {
            ControlsEvent((new Tuple<int, ControlsEventEnum>(_Index, ControlsEventEnum.Trigger)), EventArgs.Empty);
        }

        private void StopPrintProcess(object sender, EventArgs e)
        {
            CommonFunctions.SetToMemoryFile("mmf_StartProcess_" + _Index, 1, "0");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            
        }

        private void StartPrintProcess(object sender, EventArgs e)
        {
            CommonFunctions.SetToMemoryFile("mmf_StartProcess_" + _Index, 1, "1");
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            
        }

        private void InitData()
        {

        }
        #endregion//End Inits

        #region Events
        private void btnControls_Click(object sender, EventArgs e)
        {
            //frmSettingDM60X vv = new frmSettingDM60X();
            //vv.ShowDialog();
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    ControlsEventEnum events = ControlsEventEnum.Stop;
                    if (sender == btnStart)
                    {
                        SetData();
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

        private void btnProductNameSearch_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            string strSearching = txtProductNameSearch.Text;
                            listBoxProductName.Items.Clear();
                            foreach(APIGetProductInfoModel.Datum items in SharedValues.Running.StationList[_Index].Schedules.APIProductList.data)
                            {
                                if ((items.PCode + " - " + items.PName).ToUpper().Contains(strSearching.ToUpper()))
                                {
                                    listBoxProductName.Items.Add(items.PCode + " - " + items.PName);
                                }
                            }
                            lblProductName.Text = Languages.ProductionName + " (" + listBoxProductName.Items.Count + "/" + SharedValues.Running.StationList[_Index].Schedules.APIProductList.data.Count.ToString("N0") + ")";
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

        private void btnAgentSearch_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        string strSearching = txtAgentSearch.Text;
                        listBoxAgentLevel1.Items.Clear();
                        foreach (ML.DeviceTransfer.PVCFCRFID.APISAASModel.APIGetAgentInforByConditionModel.Datum items in SharedValues.Running.StationList[_Index].Schedules.APIAgentLevel1List.data)
                        {
                            if ((items.AgentCode + " - " + items.AgentName).ToUpper().Contains(strSearching.ToUpper()))
                            {
                                listBoxAgentLevel1.Items.Add(items.AgentCode + " - " + items.AgentName);
                            }
                        }
                        lblAgent.Text = Languages.AgencyLevel1 + " (" + listBoxAgentLevel1.Items.Count + "/" + SharedValues.Running.StationList[_Index].Schedules.APIAgentLevel1List.data.Count.ToString("N0") + ")";
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

        private void btnProductNameReload_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    LoadProductList(true);
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

        private void btnAgentReload_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    LoadAgentLevel1List(true);
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
                            //
                            LoadProductList();
                            LoadAgentLevel1List();
                            //
                            PVCFCDistributionSchedulesModel schedules = SharedValues.Running.StationList[_Index].Schedules;
                            txtProductNameOffline.Text = schedules.ProductNameOffline;
                            txtAgentOffline.Text = schedules.AgencyLevel1;
                            txtDeliveryOrderCode.Text = schedules.DeliveryBill;
                            txtWarehouseReceiptCode.Text = schedules.Ordered;
                            txtLOTNo.Text = schedules.LOTNo;
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
            try
            {
                SharedFunctions.Invoke(this, new Action(() =>
                {
                    //
                    SharedValues.Running.StationList[_Index].Schedules.Line = _Index;
                    SharedValues.Running.StationList[_Index].Schedules.ProductName = (listBoxProductName.SelectedItem != null) ? listBoxProductName.SelectedItem.ToString() : "";
                    SharedValues.Running.StationList[_Index].Schedules.AgencyLevel1 = (listBoxAgentLevel1.SelectedItem != null) ? listBoxAgentLevel1.SelectedItem.ToString() : "";
                    SharedValues.Running.StationList[_Index].Schedules.ProductNameOffline = txtProductNameOffline.Text;
                    SharedValues.Running.StationList[_Index].Schedules.AgencyLevel1Offline = txtAgentOffline.Text;
                    //
                    SharedValues.Running.StationList[_Index].Schedules.DeliveryBill = txtDeliveryOrderCode.Text;
                    SharedValues.Running.StationList[_Index].Schedules.Ordered = txtWarehouseReceiptCode.Text;
                    SharedValues.Running.StationList[_Index].Schedules.LOTNo = txtLOTNo.Text;
                    SharedValues.Running.StationList[_Index].Schedules.DateManufacture = dateMFG.Value;
                    SharedValues.Running.StationList[_Index].Schedules.Expiry = dateEXP.Value;
                    SharedValues.Running.StationList[_Index].Schedules.OrderedTotal = (int)numTotalExport.Value;
                    //
                    //Get API Params
                    string pName = SharedValues.Running.StationList[_Index].Schedules.ProductName;
                    string agentName = SharedValues.Running.StationList[_Index].Schedules.AgencyLevel1;
                    //
                    APIGetProductInfoModel.Datum productItems = SharedValues.Running.StationList[_Index].Schedules.APIProductList.data.Where(r => (r.PCode + " - " + r.PName).Equals(pName)).FirstOrDefault();
                    APIGetAgentInforByConditionModel.Datum agenItems = SharedValues.Running.StationList[_Index].Schedules.APIAgentLevel1List.data.Where(r => (r.AgentCode + " - " + r.AgentName).Equals(agentName)).FirstOrDefault();
                    //
                    SharedValues.Running.StationList[_Index].Schedules.ProCode = productItems != null ? productItems.PCode : "";
                    SharedValues.Running.StationList[_Index].Schedules.AgentCodeTo = agenItems != null ? agenItems.AgentCode : "";
                    //End Get API Params
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetData: " + ex.Message);
            }
            finally
            {

            }
        }

        public string CheckInput()
        {
            string strErrors = "";
            int intErrors = 1;
            SharedFunctions.Invoke(this, new Action(() =>
            {
                if ((listBoxProductName.SelectedItems.Count <= 0) && !SharedValues.Running.IsOffline)
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.ProductionName.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((listBoxAgentLevel1.SelectedItems.Count <= 0) && !SharedValues.Running.IsOffline)
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.AgencyLevel1.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((txtProductNameOffline.Text.Trim().Length <= 0 ) && SharedValues.Running.IsOffline)
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.ProductionName.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((txtAgentOffline.Text.Trim().Length <= 0) && SharedValues.Running.IsOffline)
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.AgencyLevel1.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((txtDeliveryOrderCode.Text.Trim().Length <= 0))
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.DeliveryBill.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((txtWarehouseReceiptCode.Text.Trim().Length <= 0))
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.Ordered.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((txtLOTNo.Text.Trim().Length <= 0))
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.LOTNo.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((dateMFG.Value == null))
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.DateOfManufacture.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((dateEXP.Value == null))
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.DateOfExpiry.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                }
                if ((numTotalExport.Value <= 0))
                {
                    strErrors += strErrors.Length > 0 ? "\n" : "";
                    strErrors += (intErrors++).ToString() + ". " + Languages.Quantity.ToUpper() + " " + Languages.MustBeGreaterThan0;
                }
                
            }));
            if (strErrors.Length > 0)
            {
                strErrors = Languages.PleaseCheckYourData + ":\n" + strErrors;
            }
            return strErrors;
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
                        txtProductNameSearch.Enabled =
                        btnProductNameReload.Enabled =
                        listBoxProductName.Enabled =
                        //
                        txtAgentSearch.Enabled =
                        btnAgentReload.Enabled =
                        listBoxAgentLevel1.Enabled =

                        txtProductNameOffline.Enabled =
                        txtAgentOffline.Enabled =
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
                       //
                       txtProductNameSearch.Enabled =
                       btnProductNameReload.Enabled =
                       listBoxProductName.Enabled =
                           //
                       txtAgentSearch.Enabled =
                       btnAgentReload.Enabled =
                       listBoxAgentLevel1.Enabled =
                       //
                       txtProductNameOffline.Enabled =
                       txtAgentOffline.Enabled =
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

        private void LoadProductList(bool isReload = false)
        {
            (new Thread(() =>
            {
                
                    if (isReload) ControlFunctions.ShowLoading(this.ParentForm);
                    //
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        txtProductNameSearch.Enabled =
                        listBoxProductName.Enabled = false;

                    }));
                    try
                    {
                        //
                        string strErrors = SharedValues.Running.StationList[_Index].Schedules.GetProductList();
                        if (strErrors != null && strErrors.Length > 0)
                        {
                            if (isReload)
                            {
                                ControlFunctions.CloseLoading();
                                MessageBox.Show(strErrors, Languages.Load + " " + Languages.ProductionName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            SharedFunctions.Invoke(this, new Action(() =>
                            {
                                listBoxProductName.Items.Clear();
                                foreach (ML.DeviceTransfer.PVCFCRFID.APISAASModel.APIGetProductInfoModel.Datum items in SharedValues.Running.StationList[_Index].Schedules.APIProductList.data)
                                {

                                    listBoxProductName.Items.Add(items.PCode + " - " + items.PName);
                                }
                                //
                                lblProductName.Text = Languages.ProductionName + " (" + SharedValues.Running.StationList[_Index].Schedules.APIProductList.data.Count.ToString("N0") + ")";

                            }));
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        SharedFunctions.Invoke(this, new Action(() =>
                        {
                            txtProductNameSearch.Enabled =
                            listBoxProductName.Enabled = true;

                        }));
                        ControlFunctions.CloseLoading();
                    }
                //

            })).Start();
        }

        private void LoadAgentLevel1List(bool isReload = false)
        {
            (new Thread(() =>
            {

                if (isReload) ControlFunctions.ShowLoading(this.ParentForm);
                SharedFunctions.Invoke(this, new Action(() =>
                {
                    txtAgentSearch.Enabled =
                    listBoxAgentLevel1.Enabled = false;
                }));
                //
                try
                {
                    string strErrors = SharedValues.Running.StationList[_Index].Schedules.GetAgentLevel1List();
                    if (strErrors != null && strErrors.Length > 0)
                    {
                        if (isReload)
                        {
                            ControlFunctions.CloseLoading();
                            MessageBox.Show(strErrors, Languages.Load + " " + Languages.ProductionName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        SharedFunctions.Invoke(this, new Action(() =>
                       {
                           //
                           listBoxAgentLevel1.Items.Clear();
                           foreach (ML.DeviceTransfer.PVCFCRFID.APISAASModel.APIGetAgentInforByConditionModel.Datum items in SharedValues.Running.StationList[_Index].Schedules.APIAgentLevel1List.data)
                           {
                               listBoxAgentLevel1.Items.Add(items.AgentCode + " - " + items.AgentName);
                           }
                           lblAgent.Text = Languages.AgencyLevel1 + " (" + SharedValues.Running.StationList[_Index].Schedules.APIAgentLevel1List.data.Count.ToString("N0") + ")";
                           //
                       }));
                    }
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        txtAgentSearch.Enabled =
                        listBoxAgentLevel1.Enabled = true;

                    }));
                    ControlFunctions.CloseLoading();
                }
            })).Start();
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
