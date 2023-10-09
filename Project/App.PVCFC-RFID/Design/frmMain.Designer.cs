namespace App.PVCFC_RFID.Design
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusStation1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusDatetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.mlTabMain = new ML.Controls.MLTabControl();
            this.mlTabMainPageExport = new System.Windows.Forms.TabPage();
            this.tblMains = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlActiveParameters = new System.Windows.Forms.TabControl();
            this.tabControlPage1 = new System.Windows.Forms.TabPage();
            this.tblStationInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mlTabMainPageConfig = new System.Windows.Forms.TabPage();
            this.mlTabMainPageAbout = new System.Windows.Forms.TabPage();
            this.mlTabMainPageAccount = new System.Windows.Forms.TabPage();
            this.mlTabMainPageSyncData = new System.Windows.Forms.TabPage();
            this.mlTabMainPageViewLogs = new System.Windows.Forms.TabPage();
            this.pnlMenuLeft = new System.Windows.Forms.Panel();
            this.tblMenuLeft = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenuLeftBtnViewLog = new System.Windows.Forms.Panel();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.pnlMenuLeftBtnSyncData = new System.Windows.Forms.Panel();
            this.btnSyncData = new System.Windows.Forms.Button();
            this.pnlMenuLeftBtnAccount = new System.Windows.Forms.Panel();
            this.btnAccount = new System.Windows.Forms.Button();
            this.pnlMenuLeftBtnSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlMenuLeftUIExtents = new System.Windows.Forms.Panel();
            this.pnlMenuLeftUIExtentsSub = new System.Windows.Forms.Panel();
            this.tblAlarm = new System.Windows.Forms.TableLayoutPanel();
            this.picHomeServer = new System.Windows.Forms.PictureBox();
            this.picHomeAlarmYellow = new System.Windows.Forms.PictureBox();
            this.picHomeAlarmRed = new System.Windows.Forms.PictureBox();
            this.picHomeAlarmGreen = new System.Windows.Forms.PictureBox();
            this.btnDebug = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.pnlMenuLeftBtnHome = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlMenuLeftBtnAbout = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.ucProductExportLineInfoOffline1 = new App.PVCFC_RFID.Design.ucProductExportLineInfo();
            this.ucStationInfo1 = new App.PVCFC_RFID.Design.ucStationInfo();
            this.ucSettingSystem1 = new App.PVCFC_RFID.Design.ucSettingSystems();
            this.ucAbout1 = new App.PVCFC_RFID.Design.ucAbout();
            this.ucSettingAccounts1 = new App.PVCFC_RFID.Design.ucSettingAccounts();
            this.statusBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.mlTabMain.SuspendLayout();
            this.mlTabMainPageExport.SuspendLayout();
            this.tblMains.SuspendLayout();
            this.tabControlActiveParameters.SuspendLayout();
            this.tabControlPage1.SuspendLayout();
            this.tblStationInfo.SuspendLayout();
            this.mlTabMainPageConfig.SuspendLayout();
            this.mlTabMainPageAbout.SuspendLayout();
            this.mlTabMainPageAccount.SuspendLayout();
            this.pnlMenuLeft.SuspendLayout();
            this.tblMenuLeft.SuspendLayout();
            this.pnlMenuLeftBtnViewLog.SuspendLayout();
            this.pnlMenuLeftBtnSyncData.SuspendLayout();
            this.pnlMenuLeftBtnAccount.SuspendLayout();
            this.pnlMenuLeftBtnSettings.SuspendLayout();
            this.pnlMenuLeftUIExtents.SuspendLayout();
            this.pnlMenuLeftUIExtentsSub.SuspendLayout();
            this.tblAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmGreen)).BeginInit();
            this.pnlMenuLeftBtnHome.SuspendLayout();
            this.pnlMenuLeftBtnAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBottom
            // 
            this.statusBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusVersion,
            this.toolStripStatusStation1,
            this.toolStripStatusBottom,
            this.toolStripStatusDatetime});
            this.statusBottom.Location = new System.Drawing.Point(0, 701);
            this.statusBottom.Name = "statusBottom";
            this.statusBottom.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
            this.statusBottom.Size = new System.Drawing.Size(1238, 22);
            this.statusBottom.SizingGrip = false;
            this.statusBottom.TabIndex = 0;
            this.statusBottom.Text = "statusStrip1";
            // 
            // toolStripStatusVersion
            // 
            this.toolStripStatusVersion.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusVersion.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusVersion.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusVersion.Name = "toolStripStatusVersion";
            this.toolStripStatusVersion.Size = new System.Drawing.Size(136, 22);
            this.toolStripStatusVersion.Text = "1.0.0.0 build 190619 1025";
            // 
            // toolStripStatusStation1
            // 
            this.toolStripStatusStation1.Image = global::App.PVCFC_RFID.Properties.Resources.connection_unknown216x216;
            this.toolStripStatusStation1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusStation1.Name = "toolStripStatusStation1";
            this.toolStripStatusStation1.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.toolStripStatusStation1.Size = new System.Drawing.Size(81, 22);
            this.toolStripStatusStation1.Text = "Station 1";
            // 
            // toolStripStatusBottom
            // 
            this.toolStripStatusBottom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusBottom.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusBottom.Name = "toolStripStatusBottom";
            this.toolStripStatusBottom.Size = new System.Drawing.Size(937, 22);
            this.toolStripStatusBottom.Spring = true;
            this.toolStripStatusBottom.Text = "[Status]";
            // 
            // toolStripStatusDatetime
            // 
            this.toolStripStatusDatetime.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusDatetime.Name = "toolStripStatusDatetime";
            this.toolStripStatusDatetime.Size = new System.Drawing.Size(63, 22);
            this.toolStripStatusDatetime.Text = "[Datetime]";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlMenuLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlMain.Size = new System.Drawing.Size(1238, 701);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.mlTabMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(63, 1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.pnlContent.Size = new System.Drawing.Size(1174, 699);
            this.pnlContent.TabIndex = 10;
            // 
            // mlTabMain
            // 
            this.mlTabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.mlTabMain.Controls.Add(this.mlTabMainPageExport);
            this.mlTabMain.Controls.Add(this.mlTabMainPageConfig);
            this.mlTabMain.Controls.Add(this.mlTabMainPageAbout);
            this.mlTabMain.Controls.Add(this.mlTabMainPageAccount);
            this.mlTabMain.Controls.Add(this.mlTabMainPageSyncData);
            this.mlTabMain.Controls.Add(this.mlTabMainPageViewLogs);
            this.mlTabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlTabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mlTabMain.ItemSize = new System.Drawing.Size(0, 1);
            this.mlTabMain.Location = new System.Drawing.Point(0, 1);
            this.mlTabMain.Name = "mlTabMain";
            this.mlTabMain.SelectedIndex = 0;
            this.mlTabMain.Size = new System.Drawing.Size(1173, 697);
            this.mlTabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mlTabMain.SkinColor = System.Drawing.Color.Transparent;
            this.mlTabMain.TabIndex = 10;
            // 
            // mlTabMainPageExport
            // 
            this.mlTabMainPageExport.Controls.Add(this.tblMains);
            this.mlTabMainPageExport.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageExport.Name = "mlTabMainPageExport";
            this.mlTabMainPageExport.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageExport.Size = new System.Drawing.Size(1165, 688);
            this.mlTabMainPageExport.TabIndex = 0;
            this.mlTabMainPageExport.Text = "tabPage1";
            // 
            // tblMains
            // 
            this.tblMains.ColumnCount = 2;
            this.tblMains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.Controls.Add(this.tabControlActiveParameters, 0, 1);
            this.tblMains.Controls.Add(this.tblStationInfo, 1, 2);
            this.tblMains.Controls.Add(this.lblTitle, 1, 1);
            this.tblMains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMains.Font = new System.Drawing.Font("Arial", 10.25F);
            this.tblMains.Location = new System.Drawing.Point(3, 3);
            this.tblMains.Margin = new System.Windows.Forms.Padding(4);
            this.tblMains.Name = "tblMains";
            this.tblMains.RowCount = 3;
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMains.Size = new System.Drawing.Size(1159, 682);
            this.tblMains.TabIndex = 1;
            // 
            // tabControlActiveParameters
            // 
            this.tabControlActiveParameters.Controls.Add(this.tabControlPage1);
            this.tabControlActiveParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlActiveParameters.Location = new System.Drawing.Point(3, 8);
            this.tabControlActiveParameters.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.tabControlActiveParameters.Name = "tabControlActiveParameters";
            this.tblMains.SetRowSpan(this.tabControlActiveParameters, 2);
            this.tabControlActiveParameters.SelectedIndex = 0;
            this.tabControlActiveParameters.Size = new System.Drawing.Size(394, 668);
            this.tabControlActiveParameters.TabIndex = 7;
            // 
            // tabControlPage1
            // 
            this.tabControlPage1.Controls.Add(this.ucProductExportLineInfoOffline1);
            this.tabControlPage1.Location = new System.Drawing.Point(4, 25);
            this.tabControlPage1.Name = "tabControlPage1";
            this.tabControlPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlPage1.Size = new System.Drawing.Size(386, 639);
            this.tabControlPage1.TabIndex = 0;
            this.tabControlPage1.Text = "tabPage1";
            this.tabControlPage1.UseVisualStyleBackColor = true;
            // 
            // tblStationInfo
            // 
            this.tblStationInfo.ColumnCount = 1;
            this.tblStationInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStationInfo.Controls.Add(this.ucStationInfo1, 0, 0);
            this.tblStationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStationInfo.Location = new System.Drawing.Point(403, 30);
            this.tblStationInfo.Name = "tblStationInfo";
            this.tblStationInfo.RowCount = 1;
            this.tblStationInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStationInfo.Size = new System.Drawing.Size(753, 649);
            this.tblStationInfo.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(734, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 22);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "EXPORT";
            // 
            // mlTabMainPageConfig
            // 
            this.mlTabMainPageConfig.Controls.Add(this.ucSettingSystem1);
            this.mlTabMainPageConfig.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageConfig.Name = "mlTabMainPageConfig";
            this.mlTabMainPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageConfig.Size = new System.Drawing.Size(1165, 688);
            this.mlTabMainPageConfig.TabIndex = 1;
            this.mlTabMainPageConfig.Text = "tabPage2";
            this.mlTabMainPageConfig.UseVisualStyleBackColor = true;
            // 
            // mlTabMainPageAbout
            // 
            this.mlTabMainPageAbout.Controls.Add(this.ucAbout1);
            this.mlTabMainPageAbout.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageAbout.Name = "mlTabMainPageAbout";
            this.mlTabMainPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageAbout.Size = new System.Drawing.Size(1165, 688);
            this.mlTabMainPageAbout.TabIndex = 2;
            this.mlTabMainPageAbout.Text = "tabPage1";
            this.mlTabMainPageAbout.UseVisualStyleBackColor = true;
            // 
            // mlTabMainPageAccount
            // 
            this.mlTabMainPageAccount.Controls.Add(this.ucSettingAccounts1);
            this.mlTabMainPageAccount.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageAccount.Name = "mlTabMainPageAccount";
            this.mlTabMainPageAccount.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageAccount.Size = new System.Drawing.Size(1165, 688);
            this.mlTabMainPageAccount.TabIndex = 3;
            this.mlTabMainPageAccount.Text = "tabPage1";
            this.mlTabMainPageAccount.UseVisualStyleBackColor = true;
            // 
            // mlTabMainPageSyncData
            // 
            this.mlTabMainPageSyncData.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageSyncData.Name = "mlTabMainPageSyncData";
            this.mlTabMainPageSyncData.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageSyncData.Size = new System.Drawing.Size(1165, 688);
            this.mlTabMainPageSyncData.TabIndex = 4;
            this.mlTabMainPageSyncData.Text = "tabPage1";
            this.mlTabMainPageSyncData.UseVisualStyleBackColor = true;
            // 
            // mlTabMainPageViewLogs
            // 
            this.mlTabMainPageViewLogs.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageViewLogs.Name = "mlTabMainPageViewLogs";
            this.mlTabMainPageViewLogs.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageViewLogs.Size = new System.Drawing.Size(1165, 688);
            this.mlTabMainPageViewLogs.TabIndex = 5;
            this.mlTabMainPageViewLogs.Text = "tabPage1";
            this.mlTabMainPageViewLogs.UseVisualStyleBackColor = true;
            // 
            // pnlMenuLeft
            // 
            this.pnlMenuLeft.Controls.Add(this.tblMenuLeft);
            this.pnlMenuLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLeft.Location = new System.Drawing.Point(1, 1);
            this.pnlMenuLeft.Name = "pnlMenuLeft";
            this.pnlMenuLeft.Size = new System.Drawing.Size(62, 699);
            this.pnlMenuLeft.TabIndex = 7;
            // 
            // tblMenuLeft
            // 
            this.tblMenuLeft.AutoSize = true;
            this.tblMenuLeft.BackColor = System.Drawing.SystemColors.Control;
            this.tblMenuLeft.ColumnCount = 1;
            this.tblMenuLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnViewLog, 0, 3);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnSyncData, 0, 1);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnAccount, 0, 4);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnSettings, 0, 2);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftUIExtents, 0, 6);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnHome, 0, 0);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnAbout, 0, 5);
            this.tblMenuLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMenuLeft.Location = new System.Drawing.Point(0, 0);
            this.tblMenuLeft.Name = "tblMenuLeft";
            this.tblMenuLeft.RowCount = 7;
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMenuLeft.Size = new System.Drawing.Size(62, 699);
            this.tblMenuLeft.TabIndex = 6;
            // 
            // pnlMenuLeftBtnViewLog
            // 
            this.pnlMenuLeftBtnViewLog.AutoSize = true;
            this.pnlMenuLeftBtnViewLog.Controls.Add(this.btnViewLogs);
            this.pnlMenuLeftBtnViewLog.Location = new System.Drawing.Point(0, 170);
            this.pnlMenuLeftBtnViewLog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftBtnViewLog.Name = "pnlMenuLeftBtnViewLog";
            this.pnlMenuLeftBtnViewLog.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMenuLeftBtnViewLog.Size = new System.Drawing.Size(62, 56);
            this.pnlMenuLeftBtnViewLog.TabIndex = 11;
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.AutoSize = true;
            this.btnViewLogs.BackColor = System.Drawing.Color.LightGray;
            this.btnViewLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLogs.Image = global::App.PVCFC_RFID.Properties.Resources.logs32x37;
            this.btnViewLogs.Location = new System.Drawing.Point(3, 0);
            this.btnViewLogs.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(56, 56);
            this.btnViewLogs.TabIndex = 0;
            this.btnViewLogs.UseVisualStyleBackColor = false;
            // 
            // pnlMenuLeftBtnSyncData
            // 
            this.pnlMenuLeftBtnSyncData.AutoSize = true;
            this.pnlMenuLeftBtnSyncData.Controls.Add(this.btnSyncData);
            this.pnlMenuLeftBtnSyncData.Location = new System.Drawing.Point(0, 58);
            this.pnlMenuLeftBtnSyncData.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftBtnSyncData.Name = "pnlMenuLeftBtnSyncData";
            this.pnlMenuLeftBtnSyncData.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMenuLeftBtnSyncData.Size = new System.Drawing.Size(62, 56);
            this.pnlMenuLeftBtnSyncData.TabIndex = 10;
            // 
            // btnSyncData
            // 
            this.btnSyncData.BackColor = System.Drawing.Color.LightGray;
            this.btnSyncData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyncData.Image = global::App.PVCFC_RFID.Properties.Resources.sync32x32;
            this.btnSyncData.Location = new System.Drawing.Point(3, 0);
            this.btnSyncData.Margin = new System.Windows.Forms.Padding(0);
            this.btnSyncData.Name = "btnSyncData";
            this.btnSyncData.Size = new System.Drawing.Size(56, 56);
            this.btnSyncData.TabIndex = 0;
            this.btnSyncData.UseVisualStyleBackColor = false;
            // 
            // pnlMenuLeftBtnAccount
            // 
            this.pnlMenuLeftBtnAccount.AutoSize = true;
            this.pnlMenuLeftBtnAccount.Controls.Add(this.btnAccount);
            this.pnlMenuLeftBtnAccount.Location = new System.Drawing.Point(0, 226);
            this.pnlMenuLeftBtnAccount.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftBtnAccount.Name = "pnlMenuLeftBtnAccount";
            this.pnlMenuLeftBtnAccount.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMenuLeftBtnAccount.Size = new System.Drawing.Size(62, 56);
            this.pnlMenuLeftBtnAccount.TabIndex = 9;
            // 
            // btnAccount
            // 
            this.btnAccount.AutoSize = true;
            this.btnAccount.BackColor = System.Drawing.Color.LightGray;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Image = global::App.PVCFC_RFID.Properties.Resources.user32x38;
            this.btnAccount.Location = new System.Drawing.Point(3, 0);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(56, 56);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.UseVisualStyleBackColor = false;
            // 
            // pnlMenuLeftBtnSettings
            // 
            this.pnlMenuLeftBtnSettings.AutoSize = true;
            this.pnlMenuLeftBtnSettings.Controls.Add(this.btnSettings);
            this.pnlMenuLeftBtnSettings.Location = new System.Drawing.Point(0, 114);
            this.pnlMenuLeftBtnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftBtnSettings.Name = "pnlMenuLeftBtnSettings";
            this.pnlMenuLeftBtnSettings.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMenuLeftBtnSettings.Size = new System.Drawing.Size(62, 56);
            this.pnlMenuLeftBtnSettings.TabIndex = 7;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.LightGray;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Image = global::App.PVCFC_RFID.Properties.Resources.settings32x32;
            this.btnSettings.Location = new System.Drawing.Point(3, 0);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(56, 56);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // pnlMenuLeftUIExtents
            // 
            this.pnlMenuLeftUIExtents.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlMenuLeftUIExtents.Controls.Add(this.pnlMenuLeftUIExtentsSub);
            this.pnlMenuLeftUIExtents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuLeftUIExtents.Location = new System.Drawing.Point(0, 338);
            this.pnlMenuLeftUIExtents.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftUIExtents.Name = "pnlMenuLeftUIExtents";
            this.pnlMenuLeftUIExtents.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.pnlMenuLeftUIExtents.Size = new System.Drawing.Size(62, 361);
            this.pnlMenuLeftUIExtents.TabIndex = 4;
            // 
            // pnlMenuLeftUIExtentsSub
            // 
            this.pnlMenuLeftUIExtentsSub.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMenuLeftUIExtentsSub.Controls.Add(this.tblAlarm);
            this.pnlMenuLeftUIExtentsSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuLeftUIExtentsSub.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuLeftUIExtentsSub.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftUIExtentsSub.Name = "pnlMenuLeftUIExtentsSub";
            this.pnlMenuLeftUIExtentsSub.Size = new System.Drawing.Size(61, 361);
            this.pnlMenuLeftUIExtentsSub.TabIndex = 0;
            // 
            // tblAlarm
            // 
            this.tblAlarm.ColumnCount = 1;
            this.tblAlarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAlarm.Controls.Add(this.picHomeServer, 0, 1);
            this.tblAlarm.Controls.Add(this.picHomeAlarmYellow, 0, 4);
            this.tblAlarm.Controls.Add(this.picHomeAlarmRed, 0, 4);
            this.tblAlarm.Controls.Add(this.picHomeAlarmGreen, 0, 3);
            this.tblAlarm.Controls.Add(this.btnDebug, 0, 0);
            this.tblAlarm.Controls.Add(this.lblServerStatus, 0, 2);
            this.tblAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAlarm.Location = new System.Drawing.Point(0, 0);
            this.tblAlarm.Name = "tblAlarm";
            this.tblAlarm.RowCount = 6;
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.Size = new System.Drawing.Size(61, 361);
            this.tblAlarm.TabIndex = 1;
            // 
            // picHomeServer
            // 
            this.picHomeServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHomeServer.Image = global::App.PVCFC_RFID.Properties.Resources.serverfailed64x64;
            this.picHomeServer.Location = new System.Drawing.Point(6, 135);
            this.picHomeServer.Name = "picHomeServer";
            this.picHomeServer.Size = new System.Drawing.Size(48, 48);
            this.picHomeServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHomeServer.TabIndex = 5;
            this.picHomeServer.TabStop = false;
            // 
            // picHomeAlarmYellow
            // 
            this.picHomeAlarmYellow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHomeAlarmYellow.Image = global::App.PVCFC_RFID.Properties.Resources.yellow64x64;
            this.picHomeAlarmYellow.Location = new System.Drawing.Point(6, 310);
            this.picHomeAlarmYellow.Name = "picHomeAlarmYellow";
            this.picHomeAlarmYellow.Size = new System.Drawing.Size(48, 48);
            this.picHomeAlarmYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHomeAlarmYellow.TabIndex = 2;
            this.picHomeAlarmYellow.TabStop = false;
            // 
            // picHomeAlarmRed
            // 
            this.picHomeAlarmRed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHomeAlarmRed.Image = global::App.PVCFC_RFID.Properties.Resources.red64x64;
            this.picHomeAlarmRed.Location = new System.Drawing.Point(6, 256);
            this.picHomeAlarmRed.Name = "picHomeAlarmRed";
            this.picHomeAlarmRed.Size = new System.Drawing.Size(48, 48);
            this.picHomeAlarmRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHomeAlarmRed.TabIndex = 1;
            this.picHomeAlarmRed.TabStop = false;
            // 
            // picHomeAlarmGreen
            // 
            this.picHomeAlarmGreen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHomeAlarmGreen.Image = global::App.PVCFC_RFID.Properties.Resources.green64x64;
            this.picHomeAlarmGreen.Location = new System.Drawing.Point(6, 202);
            this.picHomeAlarmGreen.Name = "picHomeAlarmGreen";
            this.picHomeAlarmGreen.Size = new System.Drawing.Size(48, 48);
            this.picHomeAlarmGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHomeAlarmGreen.TabIndex = 0;
            this.picHomeAlarmGreen.TabStop = false;
            // 
            // btnDebug
            // 
            this.btnDebug.AutoSize = true;
            this.btnDebug.Location = new System.Drawing.Point(3, 3);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(55, 27);
            this.btnDebug.TabIndex = 3;
            this.btnDebug.Text = "Debugs";
            this.btnDebug.UseVisualStyleBackColor = true;
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(6, 186);
            this.lblServerStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(48, 13);
            this.lblServerStatus.TabIndex = 4;
            this.lblServerStatus.Text = "Máy chủ";
            // 
            // pnlMenuLeftBtnHome
            // 
            this.pnlMenuLeftBtnHome.AutoSize = true;
            this.pnlMenuLeftBtnHome.Controls.Add(this.btnHome);
            this.pnlMenuLeftBtnHome.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuLeftBtnHome.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftBtnHome.Name = "pnlMenuLeftBtnHome";
            this.pnlMenuLeftBtnHome.Padding = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.pnlMenuLeftBtnHome.Size = new System.Drawing.Size(62, 58);
            this.pnlMenuLeftBtnHome.TabIndex = 6;
            // 
            // btnHome
            // 
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Image = global::App.PVCFC_RFID.Properties.Resources.house32x32;
            this.btnHome.Location = new System.Drawing.Point(1, 1);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(61, 56);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // pnlMenuLeftBtnAbout
            // 
            this.pnlMenuLeftBtnAbout.AutoSize = true;
            this.pnlMenuLeftBtnAbout.Controls.Add(this.btnAbout);
            this.pnlMenuLeftBtnAbout.Location = new System.Drawing.Point(0, 282);
            this.pnlMenuLeftBtnAbout.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftBtnAbout.Name = "pnlMenuLeftBtnAbout";
            this.pnlMenuLeftBtnAbout.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMenuLeftBtnAbout.Size = new System.Drawing.Size(62, 56);
            this.pnlMenuLeftBtnAbout.TabIndex = 8;
            // 
            // btnAbout
            // 
            this.btnAbout.AutoSize = true;
            this.btnAbout.BackColor = System.Drawing.Color.LightGray;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Image = global::App.PVCFC_RFID.Properties.Resources.about32x32;
            this.btnAbout.Location = new System.Drawing.Point(3, 0);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(56, 56);
            this.btnAbout.TabIndex = 0;
            this.btnAbout.UseVisualStyleBackColor = false;
            // 
            // ucProductExportLineInfoOffline1
            // 
            this.ucProductExportLineInfoOffline1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProductExportLineInfoOffline1.Font = new System.Drawing.Font("Arial", 10.25F);
            this.ucProductExportLineInfoOffline1.Index = 0;
            this.ucProductExportLineInfoOffline1.Location = new System.Drawing.Point(3, 3);
            this.ucProductExportLineInfoOffline1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucProductExportLineInfoOffline1.Name = "ucProductExportLineInfoOffline1";
            this.ucProductExportLineInfoOffline1.Size = new System.Drawing.Size(380, 633);
            this.ucProductExportLineInfoOffline1.TabIndex = 1;
            this.ucProductExportLineInfoOffline1.Title = "";
            // 
            // ucStationInfo1
            // 
            this.ucStationInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStationInfo1.Font = new System.Drawing.Font("Arial", 10.25F);
            this.ucStationInfo1.Index = 0;
            this.ucStationInfo1.IsHideDetails = false;
            this.ucStationInfo1.IsHideStatus = false;
            this.ucStationInfo1.IsSelected = false;
            this.ucStationInfo1.Location = new System.Drawing.Point(3, 3);
            this.ucStationInfo1.Name = "ucStationInfo1";
            this.ucStationInfo1.Size = new System.Drawing.Size(747, 643);
            this.ucStationInfo1.TabIndex = 0;
            this.ucStationInfo1.Title = "";
            // 
            // ucSettingSystem1
            // 
            this.ucSettingSystem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettingSystem1.Font = new System.Drawing.Font("Arial", 10.25F);
            this.ucSettingSystem1.Location = new System.Drawing.Point(3, 3);
            this.ucSettingSystem1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSettingSystem1.Name = "ucSettingSystem1";
            this.ucSettingSystem1.Size = new System.Drawing.Size(1159, 682);
            this.ucSettingSystem1.TabIndex = 0;
            // 
            // ucAbout1
            // 
            this.ucAbout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAbout1.Font = new System.Drawing.Font("Arial", 10.25F);
            this.ucAbout1.Location = new System.Drawing.Point(3, 3);
            this.ucAbout1.Name = "ucAbout1";
            this.ucAbout1.Padding = new System.Windows.Forms.Padding(12);
            this.ucAbout1.Size = new System.Drawing.Size(1159, 682);
            this.ucAbout1.TabIndex = 0;
            // 
            // ucSettingAccounts1
            // 
            this.ucSettingAccounts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettingAccounts1.Location = new System.Drawing.Point(3, 3);
            this.ucSettingAccounts1.Name = "ucSettingAccounts1";
            this.ucSettingAccounts1.Size = new System.Drawing.Size(1159, 682);
            this.ucSettingAccounts1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1238, 723);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFID reader v1.0.0.0";
            this.statusBottom.ResumeLayout(false);
            this.statusBottom.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.mlTabMain.ResumeLayout(false);
            this.mlTabMainPageExport.ResumeLayout(false);
            this.tblMains.ResumeLayout(false);
            this.tblMains.PerformLayout();
            this.tabControlActiveParameters.ResumeLayout(false);
            this.tabControlPage1.ResumeLayout(false);
            this.tblStationInfo.ResumeLayout(false);
            this.mlTabMainPageConfig.ResumeLayout(false);
            this.mlTabMainPageAbout.ResumeLayout(false);
            this.mlTabMainPageAccount.ResumeLayout(false);
            this.pnlMenuLeft.ResumeLayout(false);
            this.pnlMenuLeft.PerformLayout();
            this.tblMenuLeft.ResumeLayout(false);
            this.tblMenuLeft.PerformLayout();
            this.pnlMenuLeftBtnViewLog.ResumeLayout(false);
            this.pnlMenuLeftBtnViewLog.PerformLayout();
            this.pnlMenuLeftBtnSyncData.ResumeLayout(false);
            this.pnlMenuLeftBtnAccount.ResumeLayout(false);
            this.pnlMenuLeftBtnAccount.PerformLayout();
            this.pnlMenuLeftBtnSettings.ResumeLayout(false);
            this.pnlMenuLeftUIExtents.ResumeLayout(false);
            this.pnlMenuLeftUIExtentsSub.ResumeLayout(false);
            this.tblAlarm.ResumeLayout(false);
            this.tblAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmGreen)).EndInit();
            this.pnlMenuLeftBtnHome.ResumeLayout(false);
            this.pnlMenuLeftBtnAbout.ResumeLayout(false);
            this.pnlMenuLeftBtnAbout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlMenuLeft;
        private System.Windows.Forms.TableLayoutPanel tblMenuLeft;
        private System.Windows.Forms.Panel pnlMenuLeftUIExtents;
        private System.Windows.Forms.Panel pnlMenuLeftUIExtentsSub;
        private System.Windows.Forms.Panel pnlMenuLeftBtnHome;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlMenuLeftBtnAbout;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlMenuLeftBtnSettings;
        private System.Windows.Forms.Panel pnlContent;
        private ML.Controls.MLTabControl mlTabMain;
        private System.Windows.Forms.TabPage mlTabMainPageExport;
        private System.Windows.Forms.TabPage mlTabMainPageConfig;
        private System.Windows.Forms.TabPage mlTabMainPageAbout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStation1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusVersion;
        private System.Windows.Forms.StatusStrip statusBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDatetime;
        private System.Windows.Forms.TableLayoutPanel tblMains;
        private System.Windows.Forms.TabControl tabControlActiveParameters;
        private System.Windows.Forms.TabPage tabControlPage1;
        private System.Windows.Forms.TableLayoutPanel tblStationInfo;
        private System.Windows.Forms.Label lblTitle;
        private ucProductExportLineInfo ucProductExportLineInfoOffline1;
        private System.Windows.Forms.TableLayoutPanel tblAlarm;
        private System.Windows.Forms.PictureBox picHomeAlarmYellow;
        private System.Windows.Forms.PictureBox picHomeAlarmRed;
        private System.Windows.Forms.PictureBox picHomeAlarmGreen;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Panel pnlMenuLeftBtnAccount;
        private System.Windows.Forms.Button btnAccount;
        private ucSettingSystems ucSettingSystem1;
        private System.Windows.Forms.TabPage mlTabMainPageAccount;
        private ucSettingAccounts ucSettingAccounts1;
        private System.Windows.Forms.Panel pnlMenuLeftBtnSyncData;
        private System.Windows.Forms.Button btnSyncData;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TabPage mlTabMainPageSyncData;
        private System.Windows.Forms.Panel pnlMenuLeftBtnViewLog;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.TabPage mlTabMainPageViewLogs;
        private ucAbout ucAbout1;
        private ucStationInfo ucStationInfo1;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.PictureBox picHomeServer;

    }
}