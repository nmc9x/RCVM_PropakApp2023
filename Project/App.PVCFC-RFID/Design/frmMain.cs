using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.Model;
using ML.AccountManagements.Controller;
using ML.AccountManagements.DataType;
using ML.Common.Controller;
using ML.Common.Enum;
using ML.Connections.DataType;
using ML.Controls;
using ML.DeviceTransfer.PVCFCRFID.APISAASModel;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using ML.Languages;
using ML.LoggingControls.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmMain : Form
    {
        #region Properties
        private bool _IsExc = false;
        private bool _IsClosed = false;
        private bool _IsFirstShowForm = false;
        private bool _IsRestart = false;
        List<StationUICls> _StationUIList = new List<StationUICls>();
        private Size _ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        private FormWindowState _LastWindowState = FormWindowState.Minimized;
        //
        private frmSyncDataWithServer _FrmSyncData = null;
        private frmViewLogs _FrmViewLogs = null;
        #endregion//End Properties

        public frmMain()
        {
            ControlFunctions.ShowLoading(new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            InitializeComponent();
            //
            InitControls();
            InitLanguages();
            InitEvents();
            InitData();
            InitStations();
            InitDebug();
        }

        #region Inits
        private void InitControls()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                btnDebug.Visible = Properties.Settings.Default.ZIsMonitor;
                //
                #region Linh.Tran_230406: UI
                //this.Size = _ScreenSize;
                this.MinimumSize = new Size(1366, 768);
                this.WindowState = FormWindowState.Maximized;
                //this.StartPosition = FormStartPosition.CenterScreen;
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.Font = new System.Drawing.Font(Properties.Settings.Default.FontFamily, Properties.Settings.Default.FontSize);
                //
                //Hide Alarm
                picHomeAlarmGreen.Visible =
                picHomeAlarmRed.Visible =
                picHomeAlarmYellow.Visible = false;
                picHomeServer.Visible = true;
                //End Hide Alarm
                //
                pnlMenuLeftUIExtents.BackColor = pnlContent.BackColor;
                //
                //
                btnHome.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnSyncData.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnSettings.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnAccount.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnViewLogs.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnAbout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                //
                btnHome.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnSyncData.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnSettings.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnAccount.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnViewLogs.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                btnAbout.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                //
                pnlMenuLeftBtnHome.Margin =
                pnlMenuLeftBtnSyncData.Margin =
                pnlMenuLeftBtnSettings.Margin =
                pnlMenuLeftBtnAbout.Margin =
                pnlMenuLeftBtnAccount.Margin =
                pnlMenuLeftBtnViewLog.Margin =
                pnlMenuLeftUIExtents.Margin = new Padding(0, 0, 0, 0);
                //
                #endregion //End Linh.Tran_230406: UI
                //
                #region Init Station UI
                _StationUIList.Add(new StationUICls()
                {
                    Index = 0,
                    UcInfo = ucStationInfo1,
                    TabPageParameters = tabControlPage1,
                    UcExportParameters = ucProductExportLineInfoOffline1,
                    ToolstripStatus = toolStripStatusStation1,
                });
                //End add Station 1
                //
                //Table layout
                this.tblStationInfo.RowCount = Properties.Settings.Default.NumberOfStation;
                for (int i = 1; i < tblStationInfo.RowCount; i++)
                {
                    tblStationInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                }
                //End Table layoutf
                //
                for (int i = 1; i < 2; i++) // tblStationInfo.RowCount
                {
                    #region Station Parameters
                    //Export Parameters
                    ucProductExportLineInfo ucParams = new ucProductExportLineInfo();
                    ucParams.Name = "ucStationInfo" + (i + 1).ToString();
                    ucParams.Index = i;
                    ucParams.Dock = this.ucProductExportLineInfoOffline1.Dock;
                    ucParams.Font = this.ucProductExportLineInfoOffline1.Font;
                    ucParams.Location = this.ucProductExportLineInfoOffline1.Location;
                    ucParams.Margin = this.ucProductExportLineInfoOffline1.Margin;
                    ucParams.Size = this.ucProductExportLineInfoOffline1.Size;
                    ucParams.TabIndex = i;
                    //End Export Parameters

                    //Tab page
                    TabPage tabpage = new TabPage();
                    tabpage.Name = "tabControlPage" + (i + 1).ToString();
                    tabpage.Text = SharedFunctions.GetStationName(i);
                    tabpage.Controls.Add(ucParams);
                    tabpage.Location = this.tabControlPage1.Location;
                    tabpage.Padding = this.tabControlPage1.Padding;
                    tabpage.Size = this.tabControlPage1.Size;
                    tabpage.TabIndex = this.tabControlPage1.TabIndex = i;
                    tabpage.UseVisualStyleBackColor = this.tabControlPage1.UseVisualStyleBackColor;
                    //End Tab page
                    this.tabControlActiveParameters.Controls.Add(tabpage);//Add to tabControls

                    #endregion//End Station Parameters

                    #region Station info
                    ucStationInfo uc = new ucStationInfo();
                    uc.Index = 0;
                    uc.Name = "ucStationInfo" + (i + 1).ToString();
                    uc.Title = SharedFunctions.GetStationName(i);
                    uc.TabIndex = i;
                    // make sure these are the same
                    uc.Dock = this.ucStationInfo1.Dock;
                    uc.Font = this.ucStationInfo1.Font;
                    uc.Location = this.ucStationInfo1.Location;
                    uc.Margin = this.ucStationInfo1.Margin;
                    //
                    //Add to Table layout
                    tblStationInfo.Controls.Add(uc, 0, i);
                    #endregion//End Station info

                    #region Tooltip
                    ToolStripStatusLabel tooltip = new ToolStripStatusLabel();
                    tooltip.Name = "toolStripStatusStation" + (i + 1).ToString();
                    tooltip.Image = toolStripStatusStation1.Image;
                    tooltip.Margin = this.toolStripStatusStation1.Margin;
                    tooltip.Padding = this.toolStripStatusStation1.Padding;
                    tooltip.Size = this.toolStripStatusStation1.Size;
                    //
                    this.statusBottom.Items.Insert((1 + i), tooltip);//1 is index of toolStripStatusStation1 in ToolStripItem[] of statusBottom
                    #endregion//End Tooltip
                    //
                    //Add to UI List
                    _StationUIList.Add(new StationUICls()
                    {
                        Index = i,
                        UcInfo = uc,
                        TabPageParameters = tabpage,
                        UcExportParameters = ucParams,
                        ToolstripStatus = tooltip
                    });
                }
                //End Add Station UI

                #region Set Station List
                foreach (StationUICls station in _StationUIList)
                {
                    station.TabPageParameters.Tag =
                    station.UcInfo.Index =
                    station.UcExportParameters.Index = station.Index;
                    //
                    station.TabPageParameters.Text =
                    station.UcInfo.Title =
                    station.ToolstripStatus.Text = SharedFunctions.GetStationName(station.Index);
                }
                tabControlPage1.Text =
                ucStationInfo1.Title = SharedFunctions.GetStationName(0);
                #endregion//End Set Station List
                #endregion//End Init Station
            }));
            //
            #region Thread Refresh UI
            Thread tRefreshUI = new Thread(() =>
            {
                //
                bool isOldServerStatus = false;
                //
                while (!_IsClosed)
                {
                    #region Update station status
                    foreach (RunningStationModel model in SharedValues.Running.StationList)
                    {
                        _StationUIList[model.Index].UcInfo.RefreshData();
                    }
                    #endregion//End Update station status
                    //
                    #region Check server
                    //if (!SharedValues.Running.IsOffline)
                    //{
                    bool newServerStatus = SharedFunctions.PingURLAdrress(APIController.LinkAPI, 1000);
                    if (isOldServerStatus != newServerStatus)
                    {
                        isOldServerStatus = newServerStatus;
                        if (isOldServerStatus)
                        {
                            SharedFunctions.Invoke(this, new Action(() =>
                            {
                                picHomeServer.Image = Properties.Resources.serverok64x64;
                            }));
                        }
                        else
                        {
                            SharedFunctions.Invoke(this, new Action(() =>
                            {
                                picHomeServer.Image = Properties.Resources.serverfailed64x64;
                            }));
                        }
                    }
                    //}
                    #endregion//End Check server
                    #region Update Datetime
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            toolStripStatusDatetime.Text = DateTime.Now.ToString(Properties.Settings.Default.DateFormatFull);
                        }));
                    #endregion//End Update Datetime
                    //
                    Thread.Sleep(1000);//1s
                }
            });
            tRefreshUI.IsBackground = true;
            tRefreshUI.Start();
            #endregion//End Thread Refresh UI
        }
        private void InitLanguages()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    #region Linh.Tran_230731: Software name - Version
                    this.Text = Properties.Settings.Default.SoftwareName + " - " + Properties.Settings.Default.Version;
                    toolStripStatusVersion.Text = Properties.Settings.Default.Version;
                    toolStripStatusBottom.Text = "";
                    lblServerStatus.Text = Languages.Server;
                    #endregion//End Linh.Tran_230731: Software name - Version
                    //
                    lblTitle.Text = GetCaptions().ToUpper();
                }));
        }
        private void InitEvents()
        {
            this.SizeChanged += frmMain_SizeChanged;
            this.FormClosing+=frmMain_FormClosing;
            this.FormClosed += frmMain_FormClosed;
            this.Load += frmMain_Load;
            this.Shown += frmMain_Shown;
            //
            //Linh.Tran_230410: UI
            btnHome.Click += btnMenuLeft_CheckedChanged;
            btnSyncData.Click += btnMenuLeft_CheckedChanged;
            btnSettings.Click += btnMenuLeft_CheckedChanged;
            btnAccount.Click += btnMenuLeft_CheckedChanged;
            btnViewLogs.Click += btnMenuLeft_CheckedChanged;
            btnAbout.Click += btnMenuLeft_CheckedChanged;
            //
            mlTabMain.SelectedIndexChanged+=mlTabMain_SelectedIndexChanged;
            //End Linh.Tran_230410: UI
            //Station UI Events
            tabControlActiveParameters.SelectedIndexChanged += tabControlActiveParameters_SelectedIndexChanged;
            //End Station UI Events
            //Station events
            foreach (StationUICls station in _StationUIList)
            {
                station.UcExportParameters.ControlsEvent += UcExportParameters_ControlsEvent;
                station.UcInfo.ControlEvents += UcInfo_ControlEvents;
                station.UcInfo.DetailsEvents += UcInfo_DetailsEvents;
            }
            //End Station events
            //
            SharedEvents.StartFeedbackFromTransferEvents+=SharedEvents_StartFeedbackFromTransferEvents;
            SharedEvents.StopFeedbackFromTransferEvents+=SharedEvents_StopFeedbackFromTransferEvents;
            SharedEvents.PageFeedbackFromTransferEvents+=SharedEvents_PageFeedbackFromTransferEvents;
            //
            SharedEvents.StartSyncDataEvents+=SharedEvents_StartSyncDataEvents;
            SharedEvents.StopSyncDataEvents+=SharedEvents_StopSyncDataEvents;
            //
            SharedEvents.RestartAppEvents+=SharedEvents_RestartAppEvents;
            SharedEvents.StationDeviceStatusChanged += SharedEvents_StationDeviceStatusChanged;
            //
        }
        private void InitData()
        {
            try
            {
                _IsExc = true;
                //
                tabControlActiveParameters.SelectedTab = tabControlPage1;
                ucStationInfo1.IsSelected = true;
                //
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, true);
                BtnMenuLeftSelected(btnSyncData, pnlMenuLeftBtnSyncData, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAccount, pnlMenuLeftBtnAccount, false);
                BtnMenuLeftSelected(btnViewLogs, pnlMenuLeftBtnViewLog, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                btnHome.Visible = AccountController.LoginUser.FunctionsList.Contains(FunctionsEnum.Controls);
                btnSyncData.Visible = AccountController.LoginUser.FunctionsList.Contains(FunctionsEnum.SyncData);
                btnSettings.Visible = AccountController.LoginUser.FunctionsList.Contains(FunctionsEnum.Setting);
                btnAccount.Visible = AccountController.LoginUser.FunctionsList.Contains(FunctionsEnum.Account);
                btnViewLogs.Visible = AccountController.LoginUser.FunctionsList.Contains(FunctionsEnum.Viewlog);
                btnAbout.Visible = AccountController.LoginUser.FunctionsList.Contains(FunctionsEnum.Controls);
                //
                toolStripStatusVersion.Text = Languages.LoginAccount + ": " + AccountController.LogedInUserName;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _IsExc = false;
            }
        }
        private void InitStations()
        {
            SharedControlHandler.KillDeviceTransferBefore();
            //
            SharedControlHandler.InitDeviceTransfer();
        }
        private void InitDebug()
        {
            new Thread((() =>
                {
                    //
                })).Start();
        }
        #endregion//End Inits

        #region Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Default status
            foreach (StationUICls station in _StationUIList)
            {
                station.UcExportParameters.LoadData();
                //
                station.UcExportParameters.StatusChanged(RunningStatusEnum.Disconnected);
                station.UcInfo.StatusChanged(RunningStatusEnum.Disconnected);
                //
            }
            //End Default status
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            #region Close loadings
            new Thread(() =>
            {
                CommonFunctions.Invoke(this, new Action(() =>
                {
                    //this.WindowState = FormWindowState.Maximized;
                    _LastWindowState = this.WindowState;
                    _IsFirstShowForm = true;
                }));
                Thread.Sleep(1000);
                //
                ControlFunctions.CloseLoading();
            }).Start();
            #endregion//End Close loadings
            //
            GetChildFormStartPositions();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (!_IsExc && _IsFirstShowForm)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                        {
                            // When window state changes
                            if (WindowState != _LastWindowState)
                            {
                                _LastWindowState = WindowState;
                                switch (_LastWindowState)
                                {
                                    case FormWindowState.Maximized:
                                    default:
                                        // Maximized!
                                        new Thread(() =>
                                        {
                                            ControlFunctions.ShowLoading(this);
                                            Thread.Sleep(100);
                                            CommonFunctions.Invoke(this, new Action(() =>
                                            {
                                                pnlMain.Visible = true;
                                            }));
                                            ControlFunctions.CloseLoading();
                                        }).Start();
                                        break;
                                    case FormWindowState.Normal:
                                        // Restored!
                                        new Thread(() =>
                                        {
                                            if (!pnlMain.Visible)
                                            {
                                                ControlFunctions.ShowLoading(this);
                                                Thread.Sleep(100);
                                                CommonFunctions.Invoke(this, new Action(() =>
                                                {
                                                    pnlMain.Visible = true;
                                                }));
                                                ControlFunctions.CloseLoading();
                                            }
                                        }).Start();
                                        break;
                                    case FormWindowState.Minimized:
                                        // Minimized!
                                        CommonFunctions.Invoke(this, new Action(() =>
                                        {
                                            pnlMain.Visible = false;
                                        }));
                                        break;
                                }
                            }
                            //End When window state changes
                            //
                            GetChildFormStartPositions();
                            //
                            int with = this.Size.Width;
                            if (with <= 1024)
                            {

                            }
                            else
                            {

                            }
                        }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Languages.Errors, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_IsRestart)
            {
                if (MessageBox.Show(Languages.MsgAreYouSureToCloseApplications, Properties.Settings.Default.SoftwareName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                if (!e.Cancel)
                {
                    e.Cancel = SharedFunctions.CheckingBeforeCloseForm();
                    if (!e.Cancel)
                    {
                        string curUser = AccountController.LogedInUserName;
                        //Log out
                        AccountController.Logout();
                        //Write logs
                        ML.LoggingControls.Controller.LoggingController.AddHistory(Languages.CloseApplications,
                            Languages.CloseApplications,
                            Languages.CloseApplications,
                            curUser,
                            ML.LoggingControls.Model.LoggingType.Info);
                        //
                        //End Write logs
                    }
                }
            }
        }

        private void frmMain_FormClosed(object sender, EventArgs e)
        {
            _IsClosed = true;
            for (int i = 0; i < _StationUIList.Count; i++)
            {
                SharedControlHandler.StopProductDelivery(i);
            }
            SharedControlHandler.KillDeviceTransfer();
            
        }

        private void mlTabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    if (mlTabMain.SelectedTab == mlTabMainPageSyncData)
                    {
                        if (_FrmSyncData == null)
                        {
                            _FrmSyncData = new frmSyncDataWithServer();
                            _FrmSyncData.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                            _FrmSyncData.Dock = DockStyle.Fill;
                            _FrmSyncData.TopLevel = false;
                            _FrmSyncData.AutoScroll = true;
                            mlTabMainPageSyncData.Controls.Add(_FrmSyncData);
                            _FrmSyncData.Show();
                        }
                    }
                    else if (mlTabMain.SelectedTab == mlTabMainPageViewLogs)
                    {
                        if (_FrmViewLogs == null)
                        {
                            _FrmViewLogs = new frmViewLogs(false);
                            _FrmViewLogs.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                            _FrmViewLogs.Dock = DockStyle.Fill;
                            _FrmViewLogs.Size = mlTabMainPageViewLogs.Size;
                            _FrmViewLogs.TopLevel = false;
                            _FrmViewLogs.AutoScroll = true;
                            mlTabMainPageViewLogs.Controls.Add(_FrmViewLogs);
                            _FrmViewLogs.Show();
                        }
                        else
                        {
                            _FrmViewLogs.ReLoadData();
                        }
                    }
                }));
        }

        private void tabControlActiveParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            int selectTabIndex = (int)tabControlActiveParameters.SelectedTab.Tag;
                            foreach (StationUICls station in _StationUIList)
                            {
                                station.UcInfo.IsSelected = (station.Index == selectTabIndex);
                            }
                        }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        #region Station events
        private void UcExportParameters_ControlsEvent(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                string strErrors = "";
                try
                {
                    _IsExc = true;
                    Tuple<int, ControlsEventEnum> tuple = (sender as Tuple<int, ControlsEventEnum>);
                    int index = tuple.Item1;
                    ControlsEventEnum events = tuple.Item2;
                    string msg = "";
                    DialogResult digConfirm = System.Windows.Forms.DialogResult.No;
                    string captions = GetCaptions(index);
                    switch (events)
                    {
                        case ControlsEventEnum.Start:
                            if (Properties.Settings.Default.ZIsExportModel)
                            {
                                SharedValues.Running.StationList[index].IsReplyStart = false;
                                SharedValues.Running.StationList[index].IsReplyStop = false;
                                #region Export product
                                #region Check Input
                                strErrors = _StationUIList[index].UcExportParameters.CheckInput();
                                if (strErrors.Length > 0)
                                {
                                    return;
                                }
                                #endregion//End Check Input

                                #region Check Transfer
                                if (SharedValues.Running.StationList[index].TransferStatus != ConnectionsType.StatusEnum.Connected)
                                {
                                    strErrors = _StationUIList[index].UcInfo.Title + " " + LanguagesFunctions.GetTranslate(SharedValues.Running.StationList[index].TransferStatus.ToString()).ToLower();
                                    strErrors += "\n" + Languages.MsgPleaseCheckYourSystems;
                                    return;
                                }
                                #endregion//End Check Transfer

                                #region Check server
                                if (!SharedValues.Running.IsOffline)
                                {
                                    if (!SharedFunctions.PingURLAdrress(APIController.LinkAPI))
                                    {
                                        strErrors = Languages.Status + " :  " + Languages.Failed + "\n" + Languages.PleaseCheckYourServer + "\n" + APIController.LinkAPI;
                                    }
                                }
                                if (strErrors.Length > 0) return;
                                #endregion//End Check server

                                #region Confirm
                                msg = Languages.MsgPleaseConfirmThisInformation + ": ";
                                if (SharedValues.Running.IsOffline)
                                {
                                    msg += "\r\n" + Languages.ProductionName + ": " + SharedValues.Running.StationList[index].Schedules.ProductNameOffline;
                                    msg += "\r\n" + Languages.AgencyLevel1 + ": " + SharedValues.Running.StationList[index].Schedules.AgencyLevel1Offline;
                                }
                                else
                                {
                                    msg += "\r\n" + Languages.ProductionName + ": " + SharedValues.Running.StationList[index].Schedules.ProductName;
                                    msg += "\r\n" + Languages.AgencyLevel1 + ": " + SharedValues.Running.StationList[index].Schedules.AgencyLevel1;
                                }
                                msg += "\r\n" + Languages.MsgDoYouWantToContinue;
                                //
                                //Display messagebox
                                digConfirm = MessageBox.Show(msg, captions, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                #endregion//End Confirm

                                #region Start
                                if (digConfirm == System.Windows.Forms.DialogResult.Yes)
                                {
                                    SharedValues.Running.StationList[index].Status = RunningStatusEnum.Processing;
                                    UpdateStationStatus(index);
                                    //
                                    //Init Schedules
                                    SharedValues.Running.StationList[index].Schedules.ResetProucts();
                                    //Create Delivery code
                                    if (!SharedValues.Running.IsOffline)
                                    {
                                        strErrors = SharedValues.Running.StationList[index].Schedules.GetDeliveryAPI();
                                        if (strErrors.Length > 0)
                                        {
                                            return;
                                        }
                                    }
                                    //Write logs
                                    string command = SharedValues.Settings.Model.GetText() + " " + ((SharedValues.Running.IsOffline) ? Languages.Offline : Languages.Online);
                                    string strMsg = SharedValues.Running.StationList[index].Schedules.GetInfo(";", SharedValues.Running.IsOffline);

                                    ML.LoggingControls.Controller.LoggingController.AddHistory(SharedValues.Running.StationList[index].Schedules.DeliveryID, command, strMsg, AccountController.LogedInUserName, ML.LoggingControls.Model.LoggingType.Started);
                                    //End Write logs
                                    StartProductDelivery(index);
                                }
                                #endregion//End Start

                                #endregion//End Export product
                            }

                            break;
                        case ControlsEventEnum.Stop:
                            //Confirm
                            msg = Languages.MsgDoYouWantToStopThisProcess;
                            //
                            //Confirm messagebox
                            if (MessageBox.Show(msg, captions, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                            {
                                StopProductDelivery(index);
                                ////Write logs
                                string command = SharedValues.Settings.Model.GetText() + " " + ((SharedValues.Running.IsOffline) ? Languages.Offline : Languages.Online);
                                string strMsg = _StationUIList[index].UcInfo.Title + ": " + Languages.Stop + "." + SharedValues.Running.StationList[index].Schedules.GetResult(";");

                                ML.LoggingControls.Controller.LoggingController.AddHistory(SharedValues.Running.StationList[index].Schedules.DeliveryID, command, strMsg, AccountController.LogedInUserName, ML.LoggingControls.Model.LoggingType.Stoped);
                                //End Write logs
                            }
                            break;
                        case ControlsEventEnum.Trigger:
                            //MinhChau05102023
                            //frmTrigger frm = new frmTrigger(tuple.Item1, SharedValues.Running.DetailsFormLocations, SharedValues.Running.DetailsFormSize);
                            //frm.ShowDialog(); 
                            var frmTrigger = new frmTriggerFormDM(tuple.Item1);
                           
                            frmTrigger.ShowDialog();
                            break;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                    if ((strErrors != null) && (strErrors.Length > 0))
                    {
                        MessageBox.Show(strErrors, lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UcInfo_ControlEvents(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    int selectIndex = (int)sender;
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            tabControlActiveParameters.SelectedIndex = selectIndex;
                        }));
                    _IsExc = false;
                    tabControlActiveParameters_SelectedIndexChanged(sender, e);
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

        private void UcInfo_DetailsEvents(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    Tuple<int, PVCFCProductItemStatusEnum> tuple = (sender as Tuple<int, PVCFCProductItemStatusEnum>);
                    frmProductDetails frm = new frmProductDetails(tuple.Item1, SharedValues.Running.DetailsFormLocations, SharedValues.Running.DetailsFormSize, tuple.Item2);
                    frm.ShowDialog();
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

        #endregion//End Station events

        #region Public events
        private void SharedEvents_StartFeedbackFromTransferEvents(object sender, EventArgs e)
        {
            try
            {
                Tuple<int, bool, string> tpResult = (Tuple<int, bool, string>)sender;
                //
                int index = tpResult.Item1;
                bool isStartFeebackSuccess = tpResult.Item2;
                string strErrors = tpResult.Item3;
#if DEBUG
                isStartFeebackSuccess = true;
#endif
                //
                if (isStartFeebackSuccess)
                {
                    SharedValues.Running.StationList[index].Status = RunningStatusEnum.Ready;
                    UpdateStationStatus(index);
                }
                else
                {
                    SharedValues.Running.StationList[index].Status = RunningStatusEnum.Stop;
                    UpdateStationStatus(index);
                    //
                    string captions = captions = GetCaptions(index);
                    MessageBox.Show(new Form { TopMost = true }, strErrors, captions, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, "StartFeedbackFromTransferEvents", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void SharedEvents_StopFeedbackFromTransferEvents(object sender, EventArgs e)
        {
            try
            {
                int index = (int)sender;
                //
                SharedValues.Running.StationList[index].Status = SharedValues.Running.StationList[index].RefreshStatus(RunningStatusEnum.Stop);
                UpdateStationStatus(index);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, "StartFeedbackFromTransferEvents", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void SharedEvents_PageFeedbackFromTransferEvents(object sender, EventArgs e)
        {
            try
            {
                int index = (int)sender;
                switch (SharedValues.Running.StationList[index].Status)
                {
                    case RunningStatusEnum.Processing:
                    case RunningStatusEnum.Ready:
                    case RunningStatusEnum.Starting:
                        if (SharedValues.Running.StationList[index].Schedules.Total >= SharedValues.Running.StationList[index].Schedules.OrderedTotal)
                        {
                            StopProductDelivery(index);
                            _StationUIList[index].UcInfo.RefreshData();
                            //
                            ////Write logs
                            string command = SharedValues.Settings.Model.GetText() + " " + ((SharedValues.Running.IsOffline) ? Languages.Offline : Languages.Online);
                            string strMsg = _StationUIList[index].UcInfo.Title + ": " + Languages.YouHaveCompletedTheQuantityToBeDistributed + "." + SharedValues.Running.StationList[index].Schedules.GetResult(";");

                            ML.LoggingControls.Controller.LoggingController.AddHistory(SharedValues.Running.StationList[index].Schedules.DeliveryID, command, strMsg, AccountController.LogedInUserName, ML.LoggingControls.Model.LoggingType.Stoped);
                            //End Write logs
                            new Thread(() =>
                                {
                                    MessageBox.Show(new Form { TopMost = true }, Languages.YouHaveCompletedTheQuantityToBeDistributed
                                + "\n" + Languages.TheSystemHasStopped, GetCaptions(index), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }).Start();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, "StartFeedbackFromTransferEvents", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void SharedEvents_StartSyncDataEvents(object sender, EventArgs e)
        {
            UpdateStationStatus(-1);
            //
        }
        private void SharedEvents_StopSyncDataEvents(object sender, EventArgs e)
        {
            UpdateStationStatus(-1);
            //
        }
        private void SharedEvents_RestartAppEvents(object sender, EventArgs e)
        {
            _IsRestart = true;
            SharedControlHandler.KillDeviceTransfer();
            Application.Restart();
        }
        private void SharedEvents_StationDeviceStatusChanged(object sender, EventArgs e)
        {
            int index = (int)sender;
            RunningStationModel model = SharedValues.Running.StationList[index];
            switch (model.TransferStatus)
            {
                case ConnectionsType.StatusEnum.Connected:
                    Thread.Sleep(2000);
                    SharedControlHandler.SendRFIDSettings(index);//MinhChau.Nguyen_230915
                    break;
                default:
                    switch (model.Status)
                    {
                        case RunningStatusEnum.Processing:
                        case RunningStatusEnum.Ready:
                        case RunningStatusEnum.Starting:
                            StopProductDelivery(index);
                            model.Status = model.RefreshStatus(RunningStatusEnum.Stop);
                            ////Write logs
                            string command = SharedValues.Settings.Model.GetText();
                            string strMsg = _StationUIList[index].UcInfo.Title + ": " + Languages.RFID + " " + LanguagesFunctions.GetTranslate(model.TransferStatus.ToString());

                            ML.LoggingControls.Controller.LoggingController.AddHistory(SharedValues.Running.StationList[index].Schedules.DeliveryID, command, strMsg, AccountController.LogedInUserName, ML.LoggingControls.Model.LoggingType.Stoped);
                            //End Write logs
                            new Thread(() =>
                                {
                                    MessageBox.Show(new Form { TopMost = true }, Languages.RFID + " " + LanguagesFunctions.GetTranslate(model.TransferStatus.ToString()) + "\n" + Languages.PleaseCheckYourSystems,
                                        GetCaptions(index), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }).Start();
                            break;
                    }
                    break;
            }
            //
            UpdateTransferStatus((int)sender);
            //
            UpdateStationStatus((int)sender);
        }
        #endregion//End Public events

        #region Linh.Tran_230410: UI
        private void btnMenuLeft_CheckedChanged(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            if (btn == btnHome)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, true);
                BtnMenuLeftSelected(btnSyncData, pnlMenuLeftBtnSyncData, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAccount, pnlMenuLeftBtnAccount, false);
                BtnMenuLeftSelected(btnViewLogs, pnlMenuLeftBtnViewLog, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                mlTabMain.SelectedTab = mlTabMainPageExport;

            }
            else if (btn == btnSyncData)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, false);
                BtnMenuLeftSelected(btnSyncData, pnlMenuLeftBtnSyncData, true);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAccount, pnlMenuLeftBtnAccount, false);
                BtnMenuLeftSelected(btnViewLogs, pnlMenuLeftBtnViewLog, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                mlTabMain.SelectedTab = mlTabMainPageSyncData;
            }
            else if (btn == btnSettings)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, false);
                BtnMenuLeftSelected(btnSyncData, pnlMenuLeftBtnSyncData, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, true);
                BtnMenuLeftSelected(btnAccount, pnlMenuLeftBtnAccount, false);
                BtnMenuLeftSelected(btnViewLogs, pnlMenuLeftBtnViewLog, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                mlTabMain.SelectedTab = mlTabMainPageConfig;
            }
            else if (btn == btnAccount)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, false);
                BtnMenuLeftSelected(btnSyncData, pnlMenuLeftBtnSyncData, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAccount, pnlMenuLeftBtnAccount, true);
                BtnMenuLeftSelected(btnViewLogs, pnlMenuLeftBtnViewLog, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                mlTabMain.SelectedTab = mlTabMainPageAccount;
            }
            else if (btn == btnViewLogs)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, false);
                BtnMenuLeftSelected(btnSyncData, pnlMenuLeftBtnSyncData, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAccount, pnlMenuLeftBtnAccount, false);
                BtnMenuLeftSelected(btnViewLogs, pnlMenuLeftBtnViewLog, true);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                mlTabMain.SelectedTab = mlTabMainPageViewLogs;
            }
            else if (btn == btnAbout)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, false);
                BtnMenuLeftSelected(btnSyncData, pnlMenuLeftBtnSyncData, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAccount, pnlMenuLeftBtnAccount, false);
                BtnMenuLeftSelected(btnViewLogs, pnlMenuLeftBtnViewLog, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, true);
                //
                mlTabMain.SelectedTab = mlTabMainPageAbout;
            }
        }
        #endregion//End Linh.Tran_230410: UI

        #endregion//End Events

        #region Methods
        private void UpdateTransferStatus(int stationIndex)
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    switch (SharedValues.Running.StationList[stationIndex].TransferStatus)
                    {
                        case ConnectionsType.StatusEnum.Connected:
                            _StationUIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_on216x216;
                            break;
                        case ConnectionsType.StatusEnum.DisConnected:
                            _StationUIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_off216x216;
                            break;
                        case ConnectionsType.StatusEnum.Unknown:
                            _StationUIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_unknown216x216;
                            break;
                        default:
                            break;
                        case ConnectionsType.StatusEnum.Processing:
                            _StationUIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_warn216x216;
                            break;
                    }
                }));
            //
        }

        private void UpdateStationStatus(int stationIndex)
        {
            bool isEnable = !SharedValues.Running.IsStarting();
            if(isEnable)
            {
                isEnable = !SharedValues.Running.IsSyncData;
            }
            //
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    tblMenuLeft.Enabled = isEnable;
                }));
            //
            if (stationIndex >= 0)
            {
                _StationUIList[stationIndex].UcInfo.RefreshData();
                //Change status
                _StationUIList[stationIndex].UcExportParameters.StatusChanged(SharedValues.Running.StationList[stationIndex].Status);
                _StationUIList[stationIndex].UcInfo.StatusChanged(SharedValues.Running.StationList[stationIndex].Status);
            }
        }

        private void GetChildFormStartPositions()
        {
            //Get Location, size of child form
            CommonFunctions.Invoke(this, new Action(() =>
            {
                SharedValues.Running.DetailsFormLocations = tblStationInfo.PointToScreen(Point.Empty);
                SharedValues.Running.DetailsFormSize = tblStationInfo.Size;
                //
                SharedValues.Running.ChildFormLocations = mlTabMain.PointToScreen(Point.Empty);
                SharedValues.Running.ChildFormSize = mlTabMain.Size;
            }));
            //End Get Location, size of child form
            //
        }

        private string GetCaptions(int index = -1)
        {
            string captions = "";
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    captions = index >= 0 ? _StationUIList[index].UcInfo.Title + " - " : "";
                    captions += SharedValues.Settings.Model.GetText() + " ";
                    captions += SharedValues.Running.IsOffline ? Languages.Offline : Languages.Online;
                }));
            return captions;
        }

        #region Delivery Online - Offline
        private void StartProductDelivery(int index)
        {
            RunningStationModel model = SharedValues.Running.StationList[index];
            model.Status = RunningStatusEnum.Processing;
            UpdateStationStatus(index);
            //
            //Save Schedules
            string fullPath = model.Schedules.GetSettingName(SharedValues.Settings.SysDisShInfoPath, index, SharedValues.Settings.Model);
            SharedValues.Running.StationList[index].Schedules.SaveFiles = fullPath;
            SharedValues.Running.StationList[index].Schedules.SaveSettings();
            //
            //Send Settings
            SharedControlHandler.SendRFIDSettings(index);//MinhChau.Nguyen_230915
            //
            SharedControlHandler.StartProductDelivery(index);
        }

        private void StopProductDelivery(int index)
        {
            SharedControlHandler.StopProductDelivery(index);
        }
        #endregion//End Delivery Online - Offline

        #region Linh.Tran_230410: UI
        private void BtnMenuLeftSelected(Button btn, Panel pnl, bool isSelected)
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                Size btnSize = new System.Drawing.Size(56, 56);
                Padding btnPadding = new System.Windows.Forms.Padding(3, 1, 3, 1);
                //
                if (isSelected)
                {
                    pnl.BackColor = pnlMenuLeftUIExtents.BackColor;
                    pnl.Padding = new System.Windows.Forms.Padding(1, 1, 0, 1);
                    //
                    btn.Location = new Point(1, btnPadding.Top);
                    btn.Size = new System.Drawing.Size(btnSize.Width + ((btnPadding.Left + btnPadding.Right) - (pnl.Padding.Left + pnl.Padding.Right)), btnSize.Height + ((btnPadding.Top + btnPadding.Bottom) - (pnl.Padding.Top + pnl.Padding.Bottom)));
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.BorderColor = pnlMenuLeftUIExtents.BackColor;
                    btn.BackColor = tblMenuLeft.BackColor;
                }
                else
                {
                    pnl.BackColor = pnlMenuLeftUIExtentsSub.BackColor;
                    pnl.Padding = new System.Windows.Forms.Padding(btnPadding.Left, 0, 0, 0);
                    //
                    btn.Location = new Point(btnPadding.Left, 0);
                    btn.Size = new System.Drawing.Size(btnSize.Width + ((btnPadding.Left + btnPadding.Right) - (pnl.Padding.Left + pnl.Padding.Right)),
                                                       btnSize.Height + ((btnPadding.Top + btnPadding.Bottom) - (pnl.Padding.Top + pnl.Padding.Bottom)));
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = pnlMenuLeftUIExtents.BackColor;
                    btn.BackColor = Color.LightGray;
                }
            }));
        }
        #endregion//End Linh.Tran_230410: UI
        #endregion//End Methods

        protected override bool ProcessCmdKey(ref Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Enter)
            {
                CommonFunctions.Invoke(this, new Action(() =>
                {
                    //if (txtScanQRCode.Focused)
                    //{
                    //    //
                    //}
                }));
                return true;//Linh.Tran_220317: Add to fix errors 
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            //
        }

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

        #region Class UI
        protected class StationUICls
        {
            private int _Index = -1;
            public int Index
            {
                get { return _Index; }
                set { _Index = value; }
            }

            private ToolStripStatusLabel _ToolstripStatus;
            public ToolStripStatusLabel ToolstripStatus
            {
                get { return _ToolstripStatus; }
                set { _ToolstripStatus = value; }
            }

            private ucStationInfo _UcInfo;
            public ucStationInfo UcInfo
            {
                get { return _UcInfo; }
                set { _UcInfo = value; }
            }

            private TabPage _TabPageParameters;
            public TabPage TabPageParameters
            {
                get { return _TabPageParameters; }
                set { _TabPageParameters = value; }
            }

            private ucProductExportLineInfo _UcExportParameters;
            public ucProductExportLineInfo UcExportParameters
            {
                get { return _UcExportParameters; }
                set { _UcExportParameters = value; }
            }
        }
        #endregion//End Class UI
    }
}
