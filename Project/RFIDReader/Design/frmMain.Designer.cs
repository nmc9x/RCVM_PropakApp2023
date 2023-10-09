namespace App.DevCodeActivatorRFID.Design
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
            this.toolStripStatusStation2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusStation3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusStation4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusStation5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusDatetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.mlTabMain = new ML.Controls.MLTabControl();
            this.mlTabMainPageHome = new System.Windows.Forms.TabPage();
            this.mlTabMainPageConfig = new System.Windows.Forms.TabPage();
            this.mlTabMainPageAbout = new System.Windows.Forms.TabPage();
            this.pnlMenuLeft = new System.Windows.Forms.Panel();
            this.tblMenuLeft = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenuLeftBtnAbout = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlMenuLeftBtnSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlMenuLeftUIExtents = new System.Windows.Forms.Panel();
            this.pnlMenuLeftUIExtentsSub = new System.Windows.Forms.Panel();
            this.tblAlarm = new System.Windows.Forms.TableLayoutPanel();
            this.picHomeAlarmYellow = new System.Windows.Forms.PictureBox();
            this.picHomeAlarmRed = new System.Windows.Forms.PictureBox();
            this.picHomeAlarmGreen = new System.Windows.Forms.PictureBox();
            this.btnDebug = new System.Windows.Forms.Button();
            this.pnlMenuLeftBtnHome = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.statusBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.mlTabMain.SuspendLayout();
            this.pnlMenuLeft.SuspendLayout();
            this.tblMenuLeft.SuspendLayout();
            this.pnlMenuLeftBtnAbout.SuspendLayout();
            this.pnlMenuLeftBtnSettings.SuspendLayout();
            this.pnlMenuLeftUIExtents.SuspendLayout();
            this.pnlMenuLeftUIExtentsSub.SuspendLayout();
            this.tblAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmGreen)).BeginInit();
            this.pnlMenuLeftBtnHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBottom
            // 
            this.statusBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusVersion,
            this.toolStripStatusStation1,
            this.toolStripStatusStation2,
            this.toolStripStatusStation3,
            this.toolStripStatusStation4,
            this.toolStripStatusStation5,
            this.toolStripStatusBottom,
            this.toolStripStatusDatetime});
            this.statusBottom.Location = new System.Drawing.Point(0, 539);
            this.statusBottom.Name = "statusBottom";
            this.statusBottom.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
            this.statusBottom.Size = new System.Drawing.Size(1008, 22);
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
            this.toolStripStatusStation1.Image = global::App.DevCodeActivatorRFID.Properties.Resources.connection_unknown216x216;
            this.toolStripStatusStation1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusStation1.Name = "toolStripStatusStation1";
            this.toolStripStatusStation1.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.toolStripStatusStation1.Size = new System.Drawing.Size(81, 22);
            this.toolStripStatusStation1.Text = "Station 1";
            // 
            // toolStripStatusStation2
            // 
            this.toolStripStatusStation2.Image = global::App.DevCodeActivatorRFID.Properties.Resources.connection_unknown216x216;
            this.toolStripStatusStation2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusStation2.Name = "toolStripStatusStation2";
            this.toolStripStatusStation2.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.toolStripStatusStation2.Size = new System.Drawing.Size(81, 22);
            this.toolStripStatusStation2.Text = "Station 2";
            // 
            // toolStripStatusStation3
            // 
            this.toolStripStatusStation3.Image = global::App.DevCodeActivatorRFID.Properties.Resources.connection_unknown216x216;
            this.toolStripStatusStation3.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusStation3.Name = "toolStripStatusStation3";
            this.toolStripStatusStation3.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.toolStripStatusStation3.Size = new System.Drawing.Size(81, 22);
            this.toolStripStatusStation3.Text = "Station 3";
            // 
            // toolStripStatusStation4
            // 
            this.toolStripStatusStation4.Image = global::App.DevCodeActivatorRFID.Properties.Resources.connection_unknown216x216;
            this.toolStripStatusStation4.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusStation4.Name = "toolStripStatusStation4";
            this.toolStripStatusStation4.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.toolStripStatusStation4.Size = new System.Drawing.Size(81, 22);
            this.toolStripStatusStation4.Text = "Station 4";
            // 
            // toolStripStatusStation5
            // 
            this.toolStripStatusStation5.Image = global::App.DevCodeActivatorRFID.Properties.Resources.connection_unknown216x216;
            this.toolStripStatusStation5.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusStation5.Name = "toolStripStatusStation5";
            this.toolStripStatusStation5.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.toolStripStatusStation5.Size = new System.Drawing.Size(81, 22);
            this.toolStripStatusStation5.Text = "Station 5";
            // 
            // toolStripStatusBottom
            // 
            this.toolStripStatusBottom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusBottom.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusBottom.Name = "toolStripStatusBottom";
            this.toolStripStatusBottom.Size = new System.Drawing.Size(352, 22);
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
            this.pnlMain.Size = new System.Drawing.Size(1008, 539);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.mlTabMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(63, 1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.pnlContent.Size = new System.Drawing.Size(944, 537);
            this.pnlContent.TabIndex = 10;
            // 
            // mlTabMain
            // 
            this.mlTabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.mlTabMain.Controls.Add(this.mlTabMainPageHome);
            this.mlTabMain.Controls.Add(this.mlTabMainPageConfig);
            this.mlTabMain.Controls.Add(this.mlTabMainPageAbout);
            this.mlTabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlTabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mlTabMain.ItemSize = new System.Drawing.Size(0, 1);
            this.mlTabMain.Location = new System.Drawing.Point(0, 1);
            this.mlTabMain.Name = "mlTabMain";
            this.mlTabMain.SelectedIndex = 0;
            this.mlTabMain.Size = new System.Drawing.Size(943, 535);
            this.mlTabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mlTabMain.SkinColor = System.Drawing.Color.Transparent;
            this.mlTabMain.TabIndex = 10;
            // 
            // mlTabMainPageHome
            // 
            this.mlTabMainPageHome.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageHome.Name = "mlTabMainPageHome";
            this.mlTabMainPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageHome.Size = new System.Drawing.Size(935, 526);
            this.mlTabMainPageHome.TabIndex = 0;
            this.mlTabMainPageHome.Text = "tabPage1";
            // 
            // mlTabMainPageConfig
            // 
            this.mlTabMainPageConfig.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageConfig.Name = "mlTabMainPageConfig";
            this.mlTabMainPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageConfig.Size = new System.Drawing.Size(935, 526);
            this.mlTabMainPageConfig.TabIndex = 1;
            this.mlTabMainPageConfig.Text = "tabPage2";
            this.mlTabMainPageConfig.UseVisualStyleBackColor = true;
            // 
            // mlTabMainPageAbout
            // 
            this.mlTabMainPageAbout.Location = new System.Drawing.Point(4, 5);
            this.mlTabMainPageAbout.Name = "mlTabMainPageAbout";
            this.mlTabMainPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.mlTabMainPageAbout.Size = new System.Drawing.Size(935, 526);
            this.mlTabMainPageAbout.TabIndex = 2;
            this.mlTabMainPageAbout.Text = "tabPage1";
            this.mlTabMainPageAbout.UseVisualStyleBackColor = true;
            // 
            // pnlMenuLeft
            // 
            this.pnlMenuLeft.Controls.Add(this.tblMenuLeft);
            this.pnlMenuLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLeft.Location = new System.Drawing.Point(1, 1);
            this.pnlMenuLeft.Name = "pnlMenuLeft";
            this.pnlMenuLeft.Size = new System.Drawing.Size(62, 537);
            this.pnlMenuLeft.TabIndex = 7;
            // 
            // tblMenuLeft
            // 
            this.tblMenuLeft.AutoSize = true;
            this.tblMenuLeft.BackColor = System.Drawing.SystemColors.Control;
            this.tblMenuLeft.ColumnCount = 1;
            this.tblMenuLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnAbout, 0, 2);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnSettings, 0, 1);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftUIExtents, 0, 2);
            this.tblMenuLeft.Controls.Add(this.pnlMenuLeftBtnHome, 0, 0);
            this.tblMenuLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMenuLeft.Location = new System.Drawing.Point(0, 0);
            this.tblMenuLeft.Name = "tblMenuLeft";
            this.tblMenuLeft.RowCount = 4;
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMenuLeft.Size = new System.Drawing.Size(62, 537);
            this.tblMenuLeft.TabIndex = 6;
            // 
            // pnlMenuLeftBtnAbout
            // 
            this.pnlMenuLeftBtnAbout.AutoSize = true;
            this.pnlMenuLeftBtnAbout.Controls.Add(this.btnAbout);
            this.pnlMenuLeftBtnAbout.Location = new System.Drawing.Point(0, 114);
            this.pnlMenuLeftBtnAbout.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftBtnAbout.Name = "pnlMenuLeftBtnAbout";
            this.pnlMenuLeftBtnAbout.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMenuLeftBtnAbout.Size = new System.Drawing.Size(62, 56);
            this.pnlMenuLeftBtnAbout.TabIndex = 8;
            // 
            // btnAbout
            // 
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Image = global::App.DevCodeActivatorRFID.Properties.Resources.about32x32;
            this.btnAbout.Location = new System.Drawing.Point(3, 0);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(56, 56);
            this.btnAbout.TabIndex = 0;
            this.btnAbout.UseVisualStyleBackColor = true;
            // 
            // pnlMenuLeftBtnSettings
            // 
            this.pnlMenuLeftBtnSettings.AutoSize = true;
            this.pnlMenuLeftBtnSettings.Controls.Add(this.btnSettings);
            this.pnlMenuLeftBtnSettings.Location = new System.Drawing.Point(0, 58);
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
            this.btnSettings.Image = global::App.DevCodeActivatorRFID.Properties.Resources.settings32x32;
            this.btnSettings.Location = new System.Drawing.Point(3, 0);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(56, 56);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // pnlMenuLeftUIExtents
            // 
            this.pnlMenuLeftUIExtents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenuLeftUIExtents.AutoSize = true;
            this.pnlMenuLeftUIExtents.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlMenuLeftUIExtents.Controls.Add(this.pnlMenuLeftUIExtentsSub);
            this.pnlMenuLeftUIExtents.Location = new System.Drawing.Point(0, 170);
            this.pnlMenuLeftUIExtents.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuLeftUIExtents.Name = "pnlMenuLeftUIExtents";
            this.pnlMenuLeftUIExtents.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.pnlMenuLeftUIExtents.Size = new System.Drawing.Size(62, 367);
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
            this.pnlMenuLeftUIExtentsSub.Size = new System.Drawing.Size(61, 367);
            this.pnlMenuLeftUIExtentsSub.TabIndex = 0;
            // 
            // tblAlarm
            // 
            this.tblAlarm.ColumnCount = 1;
            this.tblAlarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAlarm.Controls.Add(this.picHomeAlarmYellow, 0, 2);
            this.tblAlarm.Controls.Add(this.picHomeAlarmRed, 0, 2);
            this.tblAlarm.Controls.Add(this.picHomeAlarmGreen, 0, 1);
            this.tblAlarm.Controls.Add(this.btnDebug, 0, 0);
            this.tblAlarm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblAlarm.Location = new System.Drawing.Point(0, 137);
            this.tblAlarm.Name = "tblAlarm";
            this.tblAlarm.RowCount = 5;
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblAlarm.Size = new System.Drawing.Size(61, 230);
            this.tblAlarm.TabIndex = 0;
            // 
            // picHomeAlarmYellow
            // 
            this.picHomeAlarmYellow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHomeAlarmYellow.Image = global::App.DevCodeActivatorRFID.Properties.Resources.yellow64x64;
            this.picHomeAlarmYellow.Location = new System.Drawing.Point(6, 117);
            this.picHomeAlarmYellow.Name = "picHomeAlarmYellow";
            this.picHomeAlarmYellow.Size = new System.Drawing.Size(48, 48);
            this.picHomeAlarmYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHomeAlarmYellow.TabIndex = 2;
            this.picHomeAlarmYellow.TabStop = false;
            // 
            // picHomeAlarmRed
            // 
            this.picHomeAlarmRed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHomeAlarmRed.Image = global::App.DevCodeActivatorRFID.Properties.Resources.red64x64;
            this.picHomeAlarmRed.Location = new System.Drawing.Point(6, 171);
            this.picHomeAlarmRed.Name = "picHomeAlarmRed";
            this.picHomeAlarmRed.Size = new System.Drawing.Size(48, 48);
            this.picHomeAlarmRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHomeAlarmRed.TabIndex = 1;
            this.picHomeAlarmRed.TabStop = false;
            // 
            // picHomeAlarmGreen
            // 
            this.picHomeAlarmGreen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHomeAlarmGreen.Image = global::App.DevCodeActivatorRFID.Properties.Resources.green64x64;
            this.picHomeAlarmGreen.Location = new System.Drawing.Point(6, 63);
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
            this.btnDebug.Size = new System.Drawing.Size(55, 54);
            this.btnDebug.TabIndex = 3;
            this.btnDebug.Text = "Debugs";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
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
            this.btnHome.Image = global::App.DevCodeActivatorRFID.Properties.Resources.house32x32;
            this.btnHome.Location = new System.Drawing.Point(1, 1);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(61, 56);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusBottom);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "RFID reader v1.0.0.0";
            this.statusBottom.ResumeLayout(false);
            this.statusBottom.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.mlTabMain.ResumeLayout(false);
            this.pnlMenuLeft.ResumeLayout(false);
            this.pnlMenuLeft.PerformLayout();
            this.tblMenuLeft.ResumeLayout(false);
            this.tblMenuLeft.PerformLayout();
            this.pnlMenuLeftBtnAbout.ResumeLayout(false);
            this.pnlMenuLeftBtnSettings.ResumeLayout(false);
            this.pnlMenuLeftUIExtents.ResumeLayout(false);
            this.pnlMenuLeftUIExtentsSub.ResumeLayout(false);
            this.tblAlarm.ResumeLayout(false);
            this.tblAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeAlarmGreen)).EndInit();
            this.pnlMenuLeftBtnHome.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlContent;
        private ML.Controls.MLTabControl mlTabMain;
        private System.Windows.Forms.TabPage mlTabMainPageHome;
        private System.Windows.Forms.TabPage mlTabMainPageConfig;
        private System.Windows.Forms.TabPage mlTabMainPageAbout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStation1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStation5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusVersion;
        private System.Windows.Forms.TableLayoutPanel tblAlarm;
        private System.Windows.Forms.PictureBox picHomeAlarmGreen;
        private System.Windows.Forms.PictureBox picHomeAlarmYellow;
        private System.Windows.Forms.PictureBox picHomeAlarmRed;
        private System.Windows.Forms.StatusStrip statusBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDatetime;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStation2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStation3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStation4;

    }
}