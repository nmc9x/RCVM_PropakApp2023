namespace App.PVCFC_RFID.Design
{
    partial class ucSettingSystems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFileDataPath = new System.Windows.Forms.Label();
            this.btnFileDataBrowser = new System.Windows.Forms.Button();
            this.tblFileData = new System.Windows.Forms.TableLayoutPanel();
            this.txtFileDataPath = new System.Windows.Forms.TextBox();
            this.gSaveDataConfig = new System.Windows.Forms.GroupBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtIPAddressURL = new System.Windows.Forms.TextBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbJobConfig = new System.Windows.Forms.TableLayoutPanel();
            this.ucSettingSystemsJobItems1 = new App.PVCFC_RFID.Design.ucSettingSystemsJobItems();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.tblServerConfig = new System.Windows.Forms.TableLayoutPanel();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new ML.Controls.MLButton();
            this.btnRestore = new ML.Controls.MLButton();
            this.btnBackup = new ML.Controls.MLButton();
            this.gServerConfig = new System.Windows.Forms.GroupBox();
            this.gJobConfig = new System.Windows.Forms.GroupBox();
            this.tblFileData.SuspendLayout();
            this.gSaveDataConfig.SuspendLayout();
            this.tbJobConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tblServerConfig.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tblControls.SuspendLayout();
            this.gServerConfig.SuspendLayout();
            this.gJobConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileDataPath
            // 
            this.lblFileDataPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFileDataPath.AutoSize = true;
            this.lblFileDataPath.Location = new System.Drawing.Point(4, 17);
            this.lblFileDataPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileDataPath.Name = "lblFileDataPath";
            this.lblFileDataPath.Size = new System.Drawing.Size(37, 16);
            this.lblFileDataPath.TabIndex = 115;
            this.lblFileDataPath.Text = "Path";
            // 
            // btnFileDataBrowser
            // 
            this.btnFileDataBrowser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFileDataBrowser.Location = new System.Drawing.Point(923, 13);
            this.btnFileDataBrowser.Name = "btnFileDataBrowser";
            this.btnFileDataBrowser.Size = new System.Drawing.Size(72, 24);
            this.btnFileDataBrowser.TabIndex = 120;
            this.btnFileDataBrowser.Text = "...";
            this.btnFileDataBrowser.UseVisualStyleBackColor = true;
            // 
            // tblFileData
            // 
            this.tblFileData.ColumnCount = 3;
            this.tblFileData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFileData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFileData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFileData.Controls.Add(this.lblFileDataPath, 0, 1);
            this.tblFileData.Controls.Add(this.txtFileDataPath, 1, 1);
            this.tblFileData.Controls.Add(this.btnFileDataBrowser, 2, 1);
            this.tblFileData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFileData.Location = new System.Drawing.Point(4, 20);
            this.tblFileData.Margin = new System.Windows.Forms.Padding(5);
            this.tblFileData.Name = "tblFileData";
            this.tblFileData.RowCount = 4;
            this.tblFileData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblFileData.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFileData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblFileData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFileData.Size = new System.Drawing.Size(998, 56);
            this.tblFileData.TabIndex = 120;
            // 
            // txtFileDataPath
            // 
            this.txtFileDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileDataPath.Location = new System.Drawing.Point(49, 14);
            this.txtFileDataPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileDataPath.Name = "txtFileDataPath";
            this.txtFileDataPath.Size = new System.Drawing.Size(867, 23);
            this.txtFileDataPath.TabIndex = 113;
            this.txtFileDataPath.Text = "192.168.0.201";
            // 
            // gSaveDataConfig
            // 
            this.gSaveDataConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gSaveDataConfig.Controls.Add(this.tblFileData);
            this.gSaveDataConfig.Location = new System.Drawing.Point(4, 97);
            this.gSaveDataConfig.Margin = new System.Windows.Forms.Padding(4);
            this.gSaveDataConfig.Name = "gSaveDataConfig";
            this.gSaveDataConfig.Padding = new System.Windows.Forms.Padding(4);
            this.gSaveDataConfig.Size = new System.Drawing.Size(1006, 80);
            this.gSaveDataConfig.TabIndex = 3;
            this.gSaveDataConfig.TabStop = false;
            this.gSaveDataConfig.Text = "Save schedules locations";
            // 
            // lblURL
            // 
            this.lblURL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(4, 17);
            this.lblURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(106, 16);
            this.lblURL.TabIndex = 115;
            this.lblURL.Text = "IP Address/URL";
            // 
            // txtIPAddressURL
            // 
            this.txtIPAddressURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIPAddressURL.Location = new System.Drawing.Point(118, 14);
            this.txtIPAddressURL.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPAddressURL.Name = "txtIPAddressURL";
            this.txtIPAddressURL.Size = new System.Drawing.Size(522, 23);
            this.txtIPAddressURL.TabIndex = 113;
            this.txtIPAddressURL.Text = "192.168.0.201";
            // 
            // btnPing
            // 
            this.btnPing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPing.Location = new System.Drawing.Point(923, 13);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(72, 24);
            this.btnPing.TabIndex = 120;
            this.btnPing.Text = "Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(706, 17);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 16);
            this.lblPort.TabIndex = 121;
            this.lblPort.Text = "Port";
            // 
            // tbJobConfig
            // 
            this.tbJobConfig.ColumnCount = 1;
            this.tbJobConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbJobConfig.Controls.Add(this.ucSettingSystemsJobItems1, 0, 0);
            this.tbJobConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbJobConfig.Location = new System.Drawing.Point(4, 20);
            this.tbJobConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tbJobConfig.Name = "tbJobConfig";
            this.tbJobConfig.RowCount = 2;
            this.tbJobConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbJobConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbJobConfig.Size = new System.Drawing.Size(998, 326);
            this.tbJobConfig.TabIndex = 1;
            // 
            // ucSettingSystemsJobItems1
            // 
            this.ucSettingSystemsJobItems1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSettingSystemsJobItems1.Index = 0;
            this.ucSettingSystemsJobItems1.Location = new System.Drawing.Point(4, 4);
            this.ucSettingSystemsJobItems1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSettingSystemsJobItems1.MaximumSize = new System.Drawing.Size(0, 135);
            this.ucSettingSystemsJobItems1.Name = "ucSettingSystemsJobItems1";
            this.ucSettingSystemsJobItems1.Size = new System.Drawing.Size(990, 103);
            this.ucSettingSystemsJobItems1.TabIndex = 0;
            this.ucSettingSystemsJobItems1.Title = "";
            // 
            // numPort
            // 
            this.numPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numPort.Location = new System.Drawing.Point(747, 14);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(170, 23);
            this.numPort.TabIndex = 122;
            // 
            // tblServerConfig
            // 
            this.tblServerConfig.ColumnCount = 5;
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.Controls.Add(this.lblURL, 0, 1);
            this.tblServerConfig.Controls.Add(this.txtIPAddressURL, 1, 1);
            this.tblServerConfig.Controls.Add(this.btnPing, 4, 1);
            this.tblServerConfig.Controls.Add(this.lblPort, 2, 1);
            this.tblServerConfig.Controls.Add(this.numPort, 3, 1);
            this.tblServerConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblServerConfig.Location = new System.Drawing.Point(4, 20);
            this.tblServerConfig.Margin = new System.Windows.Forms.Padding(5);
            this.tblServerConfig.Name = "tblServerConfig";
            this.tblServerConfig.RowCount = 4;
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblServerConfig.Size = new System.Drawing.Size(998, 51);
            this.tblServerConfig.TabIndex = 122;
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tblControls, 0, 4);
            this.tblMain.Controls.Add(this.gServerConfig, 0, 0);
            this.tblMain.Controls.Add(this.gJobConfig, 0, 3);
            this.tblMain.Controls.Add(this.gSaveDataConfig, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(4);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 6;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblMain.Size = new System.Drawing.Size(1014, 604);
            this.tblMain.TabIndex = 1;
            // 
            // tblControls
            // 
            this.tblControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblControls.ColumnCount = 4;
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControls.Controls.Add(this.btnApply, 3, 0);
            this.tblControls.Controls.Add(this.btnRestore, 2, 0);
            this.tblControls.Controls.Add(this.btnBackup, 1, 0);
            this.tblControls.Location = new System.Drawing.Point(3, 542);
            this.tblControls.Name = "tblControls";
            this.tblControls.RowCount = 1;
            this.tblControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControls.Size = new System.Drawing.Size(1008, 54);
            this.tblControls.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.AllowLoopEvents = false;
            this.btnApply.AutoSize = true;
            this.btnApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnApply.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnApply.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnApply.BorderSizeInNoneStyle = 0;
            this.btnApply.ButtonStyle = ML.Controls.ButtonStylesEnum.Primary;
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(109)))), ((int)(((byte)(164)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Arial", 10.25F);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnApply.IsStandardButton = false;
            this.btnApply.Location = new System.Drawing.Point(882, 3);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnApply.MinimumSize = new System.Drawing.Size(120, 48);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(120, 48);
            this.btnApply.TabIndex = 36;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // btnRestore
            // 
            this.btnRestore.AllowLoopEvents = false;
            this.btnRestore.AutoSize = true;
            this.btnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnRestore.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnRestore.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnRestore.BorderSizeInNoneStyle = 0;
            this.btnRestore.ButtonStyle = ML.Controls.ButtonStylesEnum.Warning;
            this.btnRestore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(162)))), ((int)(((byte)(54)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Arial", 10.25F);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnRestore.IsStandardButton = false;
            this.btnRestore.Location = new System.Drawing.Point(753, 3);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnRestore.MinimumSize = new System.Drawing.Size(120, 48);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(120, 48);
            this.btnRestore.TabIndex = 37;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            // 
            // btnBackup
            // 
            this.btnBackup.AllowLoopEvents = false;
            this.btnBackup.AutoSize = true;
            this.btnBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnBackup.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnBackup.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnBackup.BorderSizeInNoneStyle = 0;
            this.btnBackup.ButtonStyle = ML.Controls.ButtonStylesEnum.Success;
            this.btnBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(174)))), ((int)(((byte)(76)))));
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Arial", 10.25F);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnBackup.IsStandardButton = false;
            this.btnBackup.Location = new System.Drawing.Point(624, 3);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnBackup.MinimumSize = new System.Drawing.Size(120, 48);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(120, 48);
            this.btnBackup.TabIndex = 38;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            // 
            // gServerConfig
            // 
            this.gServerConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gServerConfig.Controls.Add(this.tblServerConfig);
            this.gServerConfig.Location = new System.Drawing.Point(4, 4);
            this.gServerConfig.Margin = new System.Windows.Forms.Padding(4);
            this.gServerConfig.Name = "gServerConfig";
            this.gServerConfig.Padding = new System.Windows.Forms.Padding(4);
            this.gServerConfig.Size = new System.Drawing.Size(1006, 75);
            this.gServerConfig.TabIndex = 1;
            this.gServerConfig.TabStop = false;
            this.gServerConfig.Text = "SAAS Config";
            // 
            // gJobConfig
            // 
            this.gJobConfig.Controls.Add(this.tbJobConfig);
            this.gJobConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gJobConfig.Location = new System.Drawing.Point(4, 185);
            this.gJobConfig.Margin = new System.Windows.Forms.Padding(4);
            this.gJobConfig.Name = "gJobConfig";
            this.gJobConfig.Padding = new System.Windows.Forms.Padding(4);
            this.gJobConfig.Size = new System.Drawing.Size(1006, 350);
            this.gJobConfig.TabIndex = 0;
            this.gJobConfig.TabStop = false;
            this.gJobConfig.Text = "RFID Config";
            // 
            // ucSettingSystems
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Arial", 10.25F);
            this.Margin = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.Name = "ucSettingSystems";
            this.Size = new System.Drawing.Size(1014, 604);
            this.tblFileData.ResumeLayout(false);
            this.tblFileData.PerformLayout();
            this.gSaveDataConfig.ResumeLayout(false);
            this.tbJobConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tblServerConfig.ResumeLayout(false);
            this.tblServerConfig.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblControls.ResumeLayout(false);
            this.tblControls.PerformLayout();
            this.gServerConfig.ResumeLayout(false);
            this.gJobConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFileDataPath;
        private System.Windows.Forms.Button btnFileDataBrowser;
        private System.Windows.Forms.TableLayoutPanel tblFileData;
        private System.Windows.Forms.TextBox txtFileDataPath;
        private System.Windows.Forms.GroupBox gSaveDataConfig;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtIPAddressURL;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Label lblPort;
        private ucSettingSystemsJobItems ucSettingSystemsJobItems1;
        private System.Windows.Forms.TableLayoutPanel tbJobConfig;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TableLayoutPanel tblServerConfig;
        private ML.Controls.MLButton btnApply;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.GroupBox gServerConfig;
        private System.Windows.Forms.GroupBox gJobConfig;
        private System.Windows.Forms.TableLayoutPanel tblControls;
        private ML.Controls.MLButton btnRestore;
        private ML.Controls.MLButton btnBackup;

    }
}
