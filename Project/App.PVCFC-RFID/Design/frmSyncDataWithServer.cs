using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.DataType;
using App.PVCFC_RFID.Model;
using ML.AccountManagements.Controller;
using ML.Common.Controller;
using ML.Controls;
using ML.DeviceTransfer.PVCFCRFID.APISAASModel;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using ML.DeviceTransfer.PVCFCRFID.Model;
using ML.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmSyncDataWithServer : Form
    {
        #region Properties
        private bool _IsStop = false;
        private bool _IsExc = false;
        private bool _IsSelectLastRow = true;
        private Color _TitleColor = Color.Green;
        private int _TotalRecord = 0;
        private int _SyncIndex = 0;
        private int _SelectRow = 0;
        private int _ProductIndex = -1;
        private int _AgentIndex = -1;
        private string _SelectSyncFiles = "";
        private List<string> _ListSchedulessName = new List<string>();//Linh.Tran_210914
        private PVCFCDistributionSchedulesModel _SyncSchedules = new PVCFCDistributionSchedulesModel();
        private BindingList<PVCFCProductItemModel> mMyList = new BindingList<PVCFCProductItemModel>();
        #endregion//End Properties

        public frmSyncDataWithServer()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.rfid;
            this.MinimumSize = new Size(1024, 768);
            //
            InitControls();
            InitLanguages();
            InitEvents();
            InitData();
        }

        #region Inits
        private void InitControls()
        {
            ucStationInfo1.IsHideDetails = false;
            ucStationInfo1.IsHideStatus = true;
            //
            CommonFunctions.Invoke(this, new Action(() =>
            {
                //Only read info
                txtDeliveryOrderCode.Enabled =
                txtWarehouseReceiptCode.Enabled =
                txtLOTNo.Enabled =
                    //dateMFG.Enabled =
                    //dateEXP.Enabled =
                numTotalExport.Enabled = false;
                numTotalExport.Minimum = 0;
                numTotalExport.Maximum = 100000;
                //End Only read info
                //
                lblNoteProductNameValues.AutoEllipsis = true;
                lblNoteProductNameValues.AutoSize = false;
                lblNoteProductNameValues.UseCompatibleTextRendering = true;
                //
                lblNoteAgentValues.AutoEllipsis = true;
                lblNoteAgentValues.AutoSize = false;
                lblNoteAgentValues.UseCompatibleTextRendering = true;
                //
                //dateMFG.Format = DateTimePickerFormat.Custom;
                //dateMFG.CustomFormat = Properties.Settings.Default.DateFormat;
                //dateEXP.Format = DateTimePickerFormat.Custom;
                //dateEXP.CustomFormat = Properties.Settings.Default.DateFormat;
                //
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersWidth = 84;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //
                lblTotalRows.Text = Languages.CodeCount + ": " + dataGridView1.RowCount.ToString("N0");
            }));

            UIEnables(false);
        }

        private void InitLanguages()
        {
            this.Text = Languages.SyncDataWithServer;
            lblTitle.Text = Languages.SyncData.ToUpper() + " - " + PVCFCOperationEnum.Export.GetText().ToUpper();
            //
            tabControlSyncPageExport.Text = PVCFCOperationEnum.Export.GetText();
            tabControlSyncPageImport.Text = PVCFCOperationEnum.Import.GetText();
            //

            grSyncSchedules.Text = Languages.ActivationParameters;
            lblSchedules.Text = Languages.DistributionSchedules;
            btnPreview.Text = Languages.Preview;
            lblProductName.Text = Languages.ProductionName;
            lblAgent.Text = Languages.AgencyLevel1;
            //
            grSchedulesInfo.Text = Languages.SchedulesInfo;
            lblDeliveryOrderCode.Text = Languages.DeliveryBill;
            lblWarehouseReceiptCode.Text = Languages.Ordered;
            lblLOTNo.Text = Languages.LOTNo;
            //lblMFG.Text = Languages.DateOfManufacture;
            //lblEXP.Text = Languages.DateOfExpiry;
            lblTotalExport.Text = Languages.Quantity;
            //
            grNote.Text = Languages.Note;
            lblNoteProductName.Text = Languages.ProductionName;
            lblNoteAgent.Text = Languages.AgencyLevel1;
            lblDeliveryCode.Text = Languages.DistributionCode;
            lblNoteProductNameValues.Text = "-";
            lblNoteAgentValues.Text = "-";
            lblDeliveryCodeValues.Text = "-";
            //
            grDataDetails.Text = Languages.Details;
            lblTotalRows.Text = Languages.CodeCount + ": 0";
            //
            CommonFunctions.Invoke(this, new Action(() =>
            {
                //switch (SharedValues.Settings.Model)
                //{
                //    case PVCFCOperationEnum.Export:
                //        tabControlSync.TabPages.Remove(tabControlSyncPageImport);
                //        break;
                //    case PVCFCOperationEnum.Import:
                //        tabControlSync.TabPages.Remove(tabControlSyncPageExport);
                //        break;
                //}
            }));
        }

        private void InitEvents()
        {
            this.Load+=frmSyncDataWithServer_Load;
            this.FormClosed += frmProductSyncWithServer_FormClosed;
            //
            btnPreview.Click+=btnPreview_Click;
            btnStart.Click += btnStart_Click;
            btnSTOP.Click += btnSTOP_Click;
            //
            txtSchedulesSearch.TextChanged+=txtSchedulesSearch_TextChanged;
            txtProductNameSearch.TextChanged+=txtProductNameSearch_TextChanged;
            txtAgentSearch.TextChanged+=txtAgentSearch_TextChanged;
            //
            btnFirst.Click += btnControls_Click;
            btnBack.Click += btnControls_Click;
            btnNext.Click += btnControls_Click;
            btnLast.Click += btnControls_Click;
            //
            btnReloadSchedules.Click+=btnReloadSchedules_Click;
            btnReloadProductName.Click += btnReloadProductName_Click;
            btnReloadAgent.Click += btnReloadAgent_Click;
            //
            tabControlSync.SelectedIndexChanged+=tabControlSync_SelectedIndexChanged;
            //Data gridView
            dataGridView1.Click += dataGridView1_Click;
            dataGridView1.RowPostPaint += dgvUser_RowPostPaint;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvUser_CellFormatting);
            dataGridView1.SelectionChanged += dgvUser_SelectionChanged;
            //
        }

        private void InitData()
        {
            LoadSchedules();
            LoadProductList();
            LoadAgentLevel1List();
            ucStationInfo1.RefreshData();
        }
        #endregion//End Inits

        #region Events
        private void frmSyncDataWithServer_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void frmProductSyncWithServer_FormClosed(object sender, EventArgs e)
        {
            //_IsClosed = true;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(!_IsExc)
            {
                bool isEnableListProductAndAgent = true;
                try
                {
                    _IsExc = true;
                    if (listBoxSchedules.SelectedItem != null)
                    {
                       
                        ListBoxItemsCls selectSchedules = new ListBoxItemsCls();
                        selectSchedules = (ListBoxItemsCls)listBoxSchedules.SelectedItem;
                        _SelectSyncFiles = selectSchedules.ValueMember;
                        LoadSyncFiles();
                        //Check Distributions code - DeliveryID
                        isEnableListProductAndAgent = (_SyncSchedules.DeliveryCode == "");
                        //
                        //End Check Distributions code
                        //
                        LoadProductList();
                        LoadAgentLevel1List();
                        //
                    }
                    else
                    {
                        MessageBox.Show(Languages.PleaseSelectTheFilesToPreview, Languages.Preview + " " + Languages.DistributionSchedules, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                }
                finally
                {
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        txtProductNameSearch.Enabled =
                        listBoxProductName.Enabled =
                            //
                        txtAgentSearch.Enabled =
                        listBoxAgentLevel1.Enabled = isEnableListProductAndAgent;
                    }));
                    _IsExc = false;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                string strErrors = "";
                int intErrors = 1;
                DialogResult digConfirm = System.Windows.Forms.DialogResult.No;
                try
                {
                    _IsExc = true;
                    ControlFunctions.ShowLoading(this);
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            btnStart.Enabled = false;
                            btnSTOP.Enabled = false;
                        }));
                    //Check data
                    #region Check data
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            if ((listBoxProductName.SelectedItems.Count <= 0))
                            {
                                strErrors += strErrors.Length > 0 ? "\n" : "";
                                strErrors += (intErrors++).ToString() + ". " + Languages.ProductionName.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                            }
                            if ((listBoxAgentLevel1.SelectedItems.Count <= 0))
                            {
                                strErrors += strErrors.Length > 0 ? "\n" : "";
                                strErrors += (intErrors++).ToString() + ". " + Languages.AgencyLevel1.ToUpper() + " " + Languages.CannotBeNull.ToLower();
                            }
                        }));
                    if (strErrors.Length > 0) return;
                    #endregion//Check data
                    //End Check data
                    //
                    //Check server
                    #region Check server
                    if (!SharedFunctions.PingURLAdrress(APIController.LinkAPI))
                    {
                        strErrors = Languages.Status + " :  " + Languages.Failed + "\n" + Languages.PleaseCheckYourServer + "\n" + APIController.LinkAPI;
                    }
                    if (strErrors.Length > 0) return;
                    #endregion//End Check server
                    //End Check server
                    //Get Params
                    _SyncSchedules.ProductName = (listBoxProductName.SelectedItem != null) ? listBoxProductName.SelectedItem.ToString() : "";
                    _SyncSchedules.AgencyLevel1 = (listBoxAgentLevel1.SelectedItem != null) ? listBoxAgentLevel1.SelectedItem.ToString() : "";
                    //End Get Params
                    //
                    //Get API Params
                    if (_SyncSchedules.ProCode.Length == 0)
                    {
                        string pName = _SyncSchedules.ProductName;
                        string agentName = _SyncSchedules.AgencyLevel1;
                        //
                        APIGetProductInfoModel.Datum productItems = _SyncSchedules.APIProductList.data.Where(r => (r.PCode + " - " + r.PName).Equals(pName)).FirstOrDefault();
                        APIGetAgentInforByConditionModel.Datum agenItems = _SyncSchedules.APIAgentLevel1List.data.Where(r => (r.AgentCode + " - " + r.AgentName).Equals(agentName)).FirstOrDefault();
                        //
                        _SyncSchedules.ProCode = productItems != null ? productItems.PCode : "";
                        _SyncSchedules.AgentCodeTo = agenItems != null ? agenItems.AgentCode : "";
                    }
                    //End Get API Params
                    //
                    
                    //
                    //Display confirm
                    #region Confirm
                    string msg = Languages.MsgPleaseConfirmThisInformation + ": ";
                    msg += "\r\n" + Languages.ProductionName + ": " + _SyncSchedules.ProductName;
                    msg += "\r\n" + Languages.AgencyLevel1 + ": " + _SyncSchedules.AgencyLevel1;
                    msg += "\r\n" + Languages.MsgDoYouWantToContinue;
                    //
                    //Display messagebox
                    ControlFunctions.CloseLoading();
                    digConfirm = MessageBox.Show(msg, lblTitle.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    #endregion//End Confirm

                    #region Start
                    if (digConfirm == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Create schedules
                        if (_SyncSchedules.DeliveryID.Length == 0)
                        {
                            //Create Delivery code
                            strErrors = _SyncSchedules.GetDeliveryAPI();
                        }
                        if (strErrors.Length > 0) return;
                        //Write logs
                      //  string command = Languages.SyncDataWithServer + " " + SharedValues.Settings.Model.GetText();
                        string strMsg = Languages.FileData + ": " + GetSyncFileName(_SelectSyncFiles) + "; " + _SyncSchedules.GetInfo(";", false);

                       // ML.LoggingControls.Controller.LoggingController.AddHistory(_SyncSchedules.DeliveryID, command, strMsg, AccountController.LogedInUserName, ML.LoggingControls.Model.LoggingType.Started);
                        //End Write logs
                        //Load data agains
                        LoadSchedulesInfo();
                        //Sync data
                        SyncData();
                    }
                    #endregion//End Start
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    ControlFunctions.CloseLoading();
                    if ((strErrors != null) && (strErrors.Length > 0))
                    {
                        MessageBox.Show(strErrors, lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    UIEnables(SharedValues.Running.IsSyncData);
                    _IsExc = false;
                }
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //Display confirm
                    if(MessageBox.Show(Languages.MsgDoYouWantToStopThisProcess,lblTitle.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SharedValues.Running.IsSyncData = false;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsStop = true;
                    _IsExc = false;
                }
            }
        }

        private void txtSchedulesSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        string strSearching = txtSchedulesSearch.Text;
                        listBoxSchedules.Items.Clear();
                        foreach (string file in _ListSchedulessName)
                        {
                            string strTemp = GetSyncFileName(file);
                            if (strTemp.ToUpper().Contains(strSearching.ToUpper()))
                            {
                                listBoxSchedules.Items.Add(new ListBoxItemsCls() { DisplayMember = strTemp, ValueMember = file });
                            }
                        }
                        lblSchedules.Text = Languages.DistributionSchedules + " (" + listBoxSchedules.Items.Count + "/" + _ListSchedulessName.Count.ToString("N0") + ")";
                    }));
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void txtProductNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        string strSearching = txtProductNameSearch.Text;
                        listBoxProductName.Items.Clear();
                        foreach (APIGetProductInfoModel.Datum items in _SyncSchedules.APIProductList.data)
                        {
                            if ((items.PCode + " - " + items.PName).ToUpper().Contains(strSearching.ToUpper()))
                            {
                                listBoxProductName.Items.Add(items.PCode + " - " + items.PName);
                            }
                        }
                        lblProductName.Text = Languages.ProductionName + " (" + listBoxProductName.Items.Count + "/" + _SyncSchedules.APIProductList.data.Count.ToString("N0") + ")";
                    }));
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void txtAgentSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        string strSearching = txtAgentSearch.Text;
                        listBoxAgentLevel1.Items.Clear();
                        foreach (APIGetAgentInforByConditionModel.Datum items in _SyncSchedules.APIAgentLevel1List.data)
                        {
                            if ((items.AgentCode + " - " + items.AgentName).ToUpper().Contains(strSearching.ToUpper()))
                            {
                                listBoxAgentLevel1.Items.Add(items.AgentCode + " - " + items.AgentName);
                            }
                        }
                        lblAgent.Text = Languages.AgencyLevel1 + " (" + listBoxAgentLevel1.Items.Count + "/" + _SyncSchedules.APIAgentLevel1List.data.Count.ToString("N0") + ")";
                    }));
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void btnReloadSchedules_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    LoadSchedules();
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void btnReloadProductName_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    LoadProductList(true);
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void btnReloadAgent_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    LoadAgentLevel1List(true);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void tabControlSync_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        if(tabControlSync.SelectedTab == tabControlSyncPageExport)
                        {
                            lblTitle.Text = Languages.SyncData.ToUpper() + " - " + PVCFCOperationEnum.Export.GetText().ToUpper();
                        }
                        else if (tabControlSync.SelectedTab == tabControlSyncPageImport)
                        {
                            lblTitle.Text = Languages.SyncData.ToUpper() + " - " + PVCFCOperationEnum.Import.GetText().ToUpper();
                        }
                    }));
                }
                catch (Exception ex)
                { }
                finally
                { _IsExc = false; }
            }
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        int selectRow = _SelectRow;
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            selectRow = dataGridView1.SelectedRows[0].Index;
                        }
                        switch ((sender as Button).Name)
                        {
                            case "btnFirst":
                                _IsSelectLastRow = false;
                                _SelectRow = 0;
                                break;
                            case "btnBack":
                                _IsSelectLastRow = false;
                                _SelectRow = _SelectRow > 0 ? (_SelectRow - 1) : 0;
                                break;
                            case "btnNext":
                                _IsSelectLastRow = false;
                                _SelectRow = _SelectRow < (dataGridView1.Rows.Count - 1) ? (_SelectRow + 1) : (dataGridView1.Rows.Count - 1);
                                break;
                            case "btnLast":
                                _IsSelectLastRow = true;
                                _SelectRow = (dataGridView1.Rows.Count - 1);
                                break;
                        }
                        SelectProductItems(_SelectRow);
                    }));
                }
                catch (Exception ex)
                { }
                finally
                { _IsExc = false; }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                _IsSelectLastRow = false;
                _SelectRow = dataGridView1.CurrentCell.RowIndex;
                SelectProductItems(_SelectRow);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Draw number of rows of datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            //
        }
        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }
            #region Linh.Tran_230619: Translate status
            //If formatting your desired column, set the value
            if (e.ColumnIndex == dataGridView1.Columns["Results"].Index)
            {
                //You can put your dynamic logic here
                //and use different values based on other cell values, for example cell 2
                PVCFCProductItemResultEnum status = PVCFCProductItemResultEnum.None;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string strStatus = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    Color clrStatus = Color.Red;
                    Enum.TryParse(strStatus, out status);
                    //
                    strStatus = status.GetText();
                    clrStatus = status.GetColor();
                    //
                    e.Value = strStatus;
                    e.CellStyle.ForeColor = clrStatus;
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Errors"].Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    e.CellStyle.ForeColor = PVCFCProductItemStatusEnum.ActivedFailed.GetColor();
                }
            }
            #endregion//End Linh.Tran_230619: Translate status
        }
        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        //                        

                    }));
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message, "dataGridView1_SelectionChanged");
#endif
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }
        #endregion//End Events

        #region Methods
        private void LoadSyncFiles()
        {
            ControlFunctions.ShowLoading(this);
            SharedFunctions.Invoke(this, new Action(() =>
            {
                _SyncSchedules = PVCFCDistributionSchedulesModel.LoadSetting(_SelectSyncFiles);
                mMyList = new BindingList<PVCFCProductItemModel>(_SyncSchedules.ProductItemsList);
                //
                dataGridView1.DataSource = mMyList;
                //
                dataGridView1.Columns["IsPalletCode"].Visible = false;
                dataGridView1.Columns["PalletCode"].Visible = false;
                dataGridView1.Columns["Status"].Visible = false;
                //
                dataGridView1.Columns["TagID"].HeaderText = Languages.TagID;
                dataGridView1.Columns["ProductCode"].HeaderText = Languages.ProductCode;
                dataGridView1.Columns["PalletCode"].HeaderText = Languages.PalletCode;
                dataGridView1.Columns["Results"].HeaderText = Languages.Status;
                dataGridView1.Columns["Errors"].HeaderText = Languages.Errors;
                dataGridView1.Columns["ScanDatetime"].HeaderText = Languages.ScanDatetime;
                //
                dataGridView1.Columns["TagID"].ReadOnly = true;
                dataGridView1.Columns["ProductCode"].ReadOnly = true;
                dataGridView1.Columns["PalletCode"].ReadOnly = true;
                dataGridView1.Columns["Status"].ReadOnly = true;
                dataGridView1.Columns["ScanDatetime"].ReadOnly = true;
                //
                _TotalRecord = _SyncSchedules.ProductItemsList.Count();
                if (_IsSelectLastRow)
                {
                    _SelectRow = mMyList.Count() - 1;
                    SelectProductItems(_SelectRow);
                    //
                    lblTotalRows.Text = Languages.CodeCount + ": " + dataGridView1.RowCount.ToString("N0");
                }
               //
                //
            }));
            LoadSchedulesInfo();
            //
            //
            ControlFunctions.CloseLoading();
        }

        private void LoadSchedulesInfo()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    //Load Sync schedules infor
                    //
                    txtDeliveryOrderCode.Text = _SyncSchedules.DeliveryBill;
                    txtWarehouseReceiptCode.Text = _SyncSchedules.Ordered;
                    txtLOTNo.Text = _SyncSchedules.LOTNo;
                    numTotalExport.Value = (int)_SyncSchedules.OrderedTotal;
                    lblNoteProductNameValues.Text = _SyncSchedules.ProductNameOffline;
                    lblNoteAgentValues.Text = _SyncSchedules.AgencyLevel1Offline;
                    lblDeliveryCodeValues.Text = _SyncSchedules.DeliveryCode;
                    //
                    ucStationInfo1.LoadData(_SyncSchedules);
                    //
                    //End Load Sync schedules info
                }));
        }

        private void LoadSchedules()
        {
            //new Thread(() =>
            //{
            //    DirectoryInfo d = new DirectoryInfo(SharedValues.Settings.SysDisShInfoPath); //Assuming Test is your Folder
            //    FileInfo[] Files = d.GetFiles("*.sch", SearchOption.AllDirectories); //Getting Text files
            //    SharedFunctions.Invoke(this, new Action(() =>
            //        {
            //            _ListSchedulessName = new List<string>();
            //            listBoxSchedules.Items.Clear();
            //            foreach (FileInfo file in Files)
            //            {
            //                if (Regex.IsMatch(file.FullName, @".$"))
            //                {
            //                    //Schedule - also SCD, SKED, S and Sch
            //                    string strTemp = GetSyncFileName(file.FullName);
            //                    _ListSchedulessName.Add(file.FullName);
            //                    listBoxSchedules.Items.Add(new ListBoxItemsCls() { DisplayMember = strTemp, ValueMember = file.FullName });
            //                }
            //            }
            //            listBoxSchedules.DisplayMember = "DisplayMember";
            //            lblSchedules.Text = Languages.DistributionSchedules + " (" + listBoxSchedules.Items.Count + "/" + _ListSchedulessName.Count.ToString("N0") + ")";
            //        }));

            //}).Start();
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
                    string strErrors = _SyncSchedules.GetProductList();
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
                            foreach (ML.DeviceTransfer.PVCFCRFID.APISAASModel.APIGetProductInfoModel.Datum items in _SyncSchedules.APIProductList.data)
                            {
                                listBoxProductName.Items.Add((items.PCode + " - " + items.PName));
                            }
                            //
                            //Find index
                            int index = -1;
                            if(_SyncSchedules.ProductName!="")
                            {
                                index = _SyncSchedules.APIProductList.data.FindIndex(a => (a.PCode + " - " + a.PName).Equals(_SyncSchedules.ProductName));
                            }
                            //
                            listBoxProductName.SelectedIndex = index;
                            //End Find index
                            //
                            lblProductName.Text = Languages.ProductionName + " (" + _SyncSchedules.APIProductList.data.Count.ToString("N0") + ")";

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
                        listBoxProductName.Enabled = (_SyncSchedules.DeliveryCode == "");

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
                    string strErrors = _SyncSchedules.GetAgentLevel1List();
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
                            foreach (ML.DeviceTransfer.PVCFCRFID.APISAASModel.APIGetAgentInforByConditionModel.Datum items in _SyncSchedules.APIAgentLevel1List.data)
                            {
                                listBoxAgentLevel1.Items.Add((items.AgentCode + " - " + items.AgentName));
                            }
                            //
                            //Find index
                            int index = -1;
                            if (_SyncSchedules.AgencyLevel1 != "")
                            {
                                index = _SyncSchedules.APIAgentLevel1List.data.FindIndex(a => (a.AgentCode + " - " + a.AgentName).Equals(_SyncSchedules.AgencyLevel1));
                            }
                            //
                            listBoxAgentLevel1.SelectedIndex = index;
                            //End Find index
                            //
                            lblAgent.Text = Languages.AgencyLevel1 + " (" + _SyncSchedules.APIAgentLevel1List.data.Count.ToString("N0") + ")";
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
                        listBoxAgentLevel1.Enabled = (_SyncSchedules.DeliveryCode == "");

                    }));
                    ControlFunctions.CloseLoading();
                }
            })).Start();
        }

        private void SyncData()
        {
            Thread tThread = new Thread(() =>
            {
                SharedValues.Running.IsSyncData = true;
                SharedEvents.RaiseStartSyncDataEvents(null);
                UIEnables(SharedValues.Running.IsSyncData);
                _SyncIndex = 0;
                _SyncSchedules.Total = 0;//Reset Totals
                try
                {
                    while (SharedValues.Running.IsSyncData && (_SyncIndex < _TotalRecord))
                    {
                        SharedFunctions.Invoke(this, new Action(() =>
                            {
                                PVCFCProductItemModel productItems = _SyncSchedules.ProductItemsList[_SyncIndex];
                                PVCFCProductItemStatusEnum oldStatus = productItems.Status;
                                switch (productItems.Results)
                                {
                                    case PVCFCProductItemResultEnum.WaitToSync:
                                    case PVCFCProductItemResultEnum.ActivedFailed:
                                        _SyncSchedules.SyncDeliveryDataToServer(ref productItems);
                                        //
                                        //Check new record datagridview
                                        dataGridView1.Refresh();//Linh.Tran_230904: Refresh when values has been changes in BindingListChanges
                                        if (_IsSelectLastRow)
                                        {
                                            _SelectRow = _SyncIndex;
                                            SelectProductItems(_SelectRow);
                                        }
                                        //The datagrid will show automatically the new added/updated items, no need to do anything else
                                        break;
                                }
                                //
                                switch (oldStatus)
                                {
                                    case PVCFCProductItemStatusEnum.ActivedFailed:
                                        _SyncSchedules.ActiveFailed--;
                                        break;
                                }
                                //
                                switch(productItems.Status)
                                {
                                    case PVCFCProductItemStatusEnum.ActivedFailed:
                                        _SyncSchedules.ActiveFailed++;
                                        break;
                                    case PVCFCProductItemStatusEnum.ActivedSuccess:
                                        _SyncSchedules.ActiveSuccess++;
                                        break;
                                }
                                //
                                _SyncSchedules.Total++;
                                ucStationInfo1.LoadData(_SyncSchedules);
                            }));

                        //Save settings
                        if (_SyncIndex % 10 == 0)
                        {
                            _SyncSchedules.SaveSettings();
                        }
                        //
                        _SyncIndex++;
                        //
                        Thread.Sleep(10);
                    }
                    _SyncSchedules.SaveSettings();
                    ////Write logs
                  //  string command = Languages.SyncDataWithServer + " " + SharedValues.Settings.Model.GetText();
                    string strMsg = Languages.FileData + ": " + GetSyncFileName(_SelectSyncFiles) + "; " + _SyncSchedules.GetResult(";");

                   // ML.LoggingControls.Controller.LoggingController.AddHistory(_SyncSchedules.DeliveryID, command, strMsg, AccountController.LogedInUserName, ML.LoggingControls.Model.LoggingType.Stoped);
                    //End Write logs
                    new Thread(() =>
                    {
                        MessageBox.Show(new Form { TopMost = true }, Languages.SyncData + " " + Languages.Success.ToLower()
                    + "\n" + Languages.TheSystemHasStopped, lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }).Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Languages.SyncData, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SharedValues.Running.IsSyncData = false;
                    UIEnables(SharedValues.Running.IsSyncData);
                    SharedEvents.RaiseStopSyncDataEvents(null);
                }
            });
            tThread.Start();
        }

        private void SelectProductItems(int index)
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        if (index < 0 || index >= dataGridView1.Rows.Count)
                        {
                            index = 0;
                        }
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[index].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }));
        }

        private void UIEnables(bool isStart)
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    btnStart.Enabled = !isStart;
                    btnSTOP.Enabled = isStart;
                }));
        }

        private string GetSyncFileName(string fullFilesName)
        {
            return Path.GetFileName(fullFilesName).Replace(".sch", "");
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

        private class ListBoxItemsCls
        {
            public string DisplayMember { get; set; }
            public string ValueMember { get; set; }
        }

    }
}
