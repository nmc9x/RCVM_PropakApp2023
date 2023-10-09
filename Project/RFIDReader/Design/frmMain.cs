using ML.Common.Controller;
using ML.DatabaseConnections;
using ML.DatabaseConnections.Controller;
using App.DevCodeActivatorRFID.Controller;
using App.DevCodeActivatorRFID.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.Languages;
using ML.Common.Enum;
using ML.Connections.DataType;
using System.Reflection;

namespace App.DevCodeActivatorRFID.Design
{
    public partial class frmMain : Form
    {
        #region Properties
        private bool _IsExc = false;
        private bool _IsClosed = false;
        private List<UIMainCls> _UIList;

        #endregion//End Properties

        public frmMain()
        {
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
            btnDebug.Visible = Properties.Settings.Default.IsMonitor;
            //
            #region Hide UI
            toolStripStatusStation1.Visible =
            toolStripStatusStation2.Visible =
            toolStripStatusStation3.Visible =
            toolStripStatusStation4.Visible =
            toolStripStatusStation5.Visible = false;
            #endregion//End Hide UI
            //
            #region Inits List UI
            _UIList = new List<UIMainCls>();
            for (int i = 0; i < Properties.Settings.Default.NumberOfStation; i++)
            {
                UIMainCls items = new UIMainCls();
                items.Index = i;
                items.ToolstripStatus = (ToolStripStatusLabel)this.statusBottom.Items[String.Format("toolStripStatusStation{0}", (i + 1).ToString())];
                items.ToolstripStatus.Visible = true;
                _UIList.Add(items);
            }
            #endregion//End Inits List UI
            //
            #region Linh.Tran_230406: UI
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            //
            pnlMenuLeftUIExtents.BackColor = pnlContent.BackColor;
            //
            //
            btnHome.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnSettings.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnAbout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            //
            btnHome.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnSettings.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnAbout.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            //
            pnlMenuLeftBtnHome.Margin =
            pnlMenuLeftBtnSettings.Margin =
            pnlMenuLeftBtnAbout.Margin =
            pnlMenuLeftUIExtents.Margin = new Padding(0, 0, 0, 0);
            //
            #endregion //End Linh.Tran_230406: UI

            #region Thread Refresh UI
            Thread tRefreshUI = new Thread(() =>
            {
                while (!_IsClosed)
                {
                    #region Update Datetime
                    SharedFunctions.Invoke(this, new Action(() =>
                        {
                            toolStripStatusDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                        }));
                    #endregion//End Update Datetime
                    Thread.Sleep(1000);//1s
                }
            });
            tRefreshUI.IsBackground = true;
            tRefreshUI.Start();
            #endregion//End Thread Refresh UI
        }
        private void InitLanguages()
        {
            #region Linh.Tran_230731: Software name - Version
            this.Text = Properties.Settings.Default.SoftwareName;
            toolStripStatusVersion.Text = Properties.Settings.Default.Version;
            toolStripStatusBottom.Text = "";
            #endregion//End Linh.Tran_230731: Software name - Version

            #region Stations name
            foreach (UIMainCls uiClss in _UIList)
            {
                uiClss.ToolstripStatus.Text = Languages.Station + " " + (uiClss.Index + 1).ToString();
            }
            #endregion//End Station name
        }
        private void InitEvents()
        {
            this.SizeChanged+=frmMain_SizeChanged;
            this.FormClosed += frmMain_FormClosed;
            //
            //Linh.Tran_230410: UI
            btnHome.Click += btnMenuLeft_CheckedChanged;
            btnSettings.Click += btnMenuLeft_CheckedChanged;
            btnAbout.Click += btnMenuLeft_CheckedChanged;
            //End Linh.Tran_230410: UI
            //
            SharedEvents.StationDeviceStatusChanged+=SharedEvents_StationDeviceStatusChanged;
            //
        }
        private void InitData()
        {
            try
            {
                _IsExc = true;
                //
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, true);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                _IsExc = false;
            }
        }
        private void InitStations()
        {
            SharedControlHandler.InitDeviceTransfer();
        }
        private void InitDebug()
        {
            new Thread((() =>
                {
                    string filesName = @"C:\Users\mailinh.tran\Desktop\New folder (4)\a.xml";
                    ML.DatabaseConnections.ConnectionDatabase temp = new ConnectionDatabaseXML(filesName);
                    List<ProductItemModel> tempProductItems = new List<ProductItemModel>();
                    int index = 0;
                    while(!_IsClosed)
                    {
                        index++;
                        tempProductItems.Add(new ProductItemModel() { ChipID = index.ToString(),
                                                                      PalletCode = "P" + index.ToString()});
                        //temp.Tables= tempProductItems.Tota => Làm database
                        temp.SaveDatabase();
                        Thread.Sleep(1);
                    }
                })).Start();
        }
        #endregion//End Inits

        #region Events

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                        {
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

        private void frmMain_FormClosed(object sender, EventArgs e)
        {
            _IsClosed = true;
            SharedControlHandler.StopScan();
            SharedControlHandler.KillDeviceTransfer();
        }



        #region Public events
        private void SharedEvents_StationDeviceStatusChanged(object sender, EventArgs e)
        {
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
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                mlTabMain.SelectedTab = mlTabMainPageHome;
            }
            else if (btn == btnSettings)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, true);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, false);
                //
                mlTabMain.SelectedTab = mlTabMainPageConfig;
            }
            else if (btn == btnAbout)
            {
                BtnMenuLeftSelected(btnHome, pnlMenuLeftBtnHome, false);
                BtnMenuLeftSelected(btnSettings, pnlMenuLeftBtnSettings, false);
                BtnMenuLeftSelected(btnAbout, pnlMenuLeftBtnAbout, true);
                //
                mlTabMain.SelectedTab = mlTabMainPageAbout;
            }
        }
        #endregion//End Linh.Tran_230410: UI
        #endregion//End Events

        #region Methods
        private void UpdateStationStatus(int stationIndex)
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    switch (SharedValues.Running.StationList[stationIndex].TransferStatus)
                    {
                        case ConnectionsType.StatusEnum.Connected:
                            //SharedControlHandler.SendRFIDSettings(stationIndex);//MinhChau.Nguyen_230915
                            _UIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_on216x216;
                            break;
                        case ConnectionsType.StatusEnum.DisConnected:
                            _UIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_off216x216;
                            break;
                        case ConnectionsType.StatusEnum.Unknown:
                            _UIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_unknown216x216;
                            break;
                        default:
                            break;
                        case ConnectionsType.StatusEnum.Processing:
                            _UIList[stationIndex].ToolstripStatus.Image = Properties.Resources.connection_warn216x216;
                            break;
                    }
                }));
        }

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


        #region Class UI
        protected class UIMainCls
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

        }
        #endregion//End Class UI
    }
}
