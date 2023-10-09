namespace App.PVCFC_RFID.Design
{
    partial class ucSettingSystemsJobItems
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
            this.gRFIDConfig = new System.Windows.Forms.GroupBox();
            this.tblServerConfig = new System.Windows.Forms.TableLayoutPanel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnWebConfig = new System.Windows.Forms.Button();
            this.lblIPAddressRequired = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIPAddrress = new System.Windows.Forms.TextBox();
            this.btnPingIP = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblPortRequired = new System.Windows.Forms.Label();
            this.btnPingUrl = new System.Windows.Forms.Button();
            this.gRFIDConfig.SuspendLayout();
            this.tblServerConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gRFIDConfig
            // 
            this.gRFIDConfig.Controls.Add(this.tblServerConfig);
            this.gRFIDConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gRFIDConfig.Location = new System.Drawing.Point(0, 0);
            this.gRFIDConfig.Margin = new System.Windows.Forms.Padding(4);
            this.gRFIDConfig.Name = "gRFIDConfig";
            this.gRFIDConfig.Padding = new System.Windows.Forms.Padding(4);
            this.gRFIDConfig.Size = new System.Drawing.Size(1166, 102);
            this.gRFIDConfig.TabIndex = 2;
            this.gRFIDConfig.TabStop = false;
            this.gRFIDConfig.Text = "RFID Config";
            // 
            // tblServerConfig
            // 
            this.tblServerConfig.ColumnCount = 13;
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblServerConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblServerConfig.Controls.Add(this.btnSettings, 10, 1);
            this.tblServerConfig.Controls.Add(this.btnWebConfig, 12, 1);
            this.tblServerConfig.Controls.Add(this.lblIPAddressRequired, 2, 1);
            this.tblServerConfig.Controls.Add(this.lblIP, 0, 1);
            this.tblServerConfig.Controls.Add(this.txtIPAddrress, 3, 1);
            this.tblServerConfig.Controls.Add(this.btnPingIP, 7, 1);
            this.tblServerConfig.Controls.Add(this.txtURL, 6, 3);
            this.tblServerConfig.Controls.Add(this.lblURL, 5, 3);
            this.tblServerConfig.Controls.Add(this.lblPort, 0, 3);
            this.tblServerConfig.Controls.Add(this.numPort, 3, 3);
            this.tblServerConfig.Controls.Add(this.lblPortRequired, 1, 3);
            this.tblServerConfig.Controls.Add(this.btnPingUrl, 9, 3);
            this.tblServerConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblServerConfig.Location = new System.Drawing.Point(4, 17);
            this.tblServerConfig.Margin = new System.Windows.Forms.Padding(5);
            this.tblServerConfig.Name = "tblServerConfig";
            this.tblServerConfig.RowCount = 6;
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblServerConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblServerConfig.Size = new System.Drawing.Size(1158, 81);
            this.tblServerConfig.TabIndex = 122;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.Image = global::App.PVCFC_RFID.Properties.Resources.config56x56;
            this.btnSettings.Location = new System.Drawing.Point(1016, 8);
            this.btnSettings.MaximumSize = new System.Drawing.Size(64, 0);
            this.btnSettings.MinimumSize = new System.Drawing.Size(64, 32);
            this.btnSettings.Name = "btnSettings";
            this.tblServerConfig.SetRowSpan(this.btnSettings, 3);
            this.btnSettings.Size = new System.Drawing.Size(64, 64);
            this.btnSettings.TabIndex = 128;
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnWebConfig
            // 
            this.btnWebConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWebConfig.Image = global::App.PVCFC_RFID.Properties.Resources.webConfig56x56;
            this.btnWebConfig.Location = new System.Drawing.Point(1091, 8);
            this.btnWebConfig.MaximumSize = new System.Drawing.Size(64, 0);
            this.btnWebConfig.MinimumSize = new System.Drawing.Size(64, 32);
            this.btnWebConfig.Name = "btnWebConfig";
            this.tblServerConfig.SetRowSpan(this.btnWebConfig, 3);
            this.btnWebConfig.Size = new System.Drawing.Size(64, 64);
            this.btnWebConfig.TabIndex = 129;
            this.btnWebConfig.UseVisualStyleBackColor = true;
            // 
            // lblIPAddressRequired
            // 
            this.lblIPAddressRequired.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIPAddressRequired.AutoSize = true;
            this.lblIPAddressRequired.ForeColor = System.Drawing.Color.Red;
            this.lblIPAddressRequired.Location = new System.Drawing.Point(61, 12);
            this.lblIPAddressRequired.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblIPAddressRequired.Name = "lblIPAddressRequired";
            this.lblIPAddressRequired.Size = new System.Drawing.Size(11, 13);
            this.lblIPAddressRequired.TabIndex = 130;
            this.lblIPAddressRequired.Text = "*";
            // 
            // lblIP
            // 
            this.lblIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIP.AutoSize = true;
            this.tblServerConfig.SetColumnSpan(this.lblIP, 2);
            this.lblIP.Location = new System.Drawing.Point(4, 12);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(57, 13);
            this.lblIP.TabIndex = 121;
            this.lblIP.Text = "IP address";
            // 
            // txtIPAddrress
            // 
            this.txtIPAddrress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblServerConfig.SetColumnSpan(this.txtIPAddrress, 4);
            this.txtIPAddrress.Location = new System.Drawing.Point(79, 9);
            this.txtIPAddrress.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPAddrress.Name = "txtIPAddrress";
            this.txtIPAddrress.Size = new System.Drawing.Size(850, 20);
            this.txtIPAddrress.TabIndex = 122;
            this.txtIPAddrress.Text = "192.168.0.201";
            // 
            // btnPingIP
            // 
            this.btnPingIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPingIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPingIP.Location = new System.Drawing.Point(936, 8);
            this.btnPingIP.MaximumSize = new System.Drawing.Size(64, 0);
            this.btnPingIP.MinimumSize = new System.Drawing.Size(64, 32);
            this.btnPingIP.Name = "btnPingIP";
            this.tblServerConfig.SetRowSpan(this.btnPingIP, 3);
            this.btnPingIP.Size = new System.Drawing.Size(64, 64);
            this.btnPingIP.TabIndex = 123;
            this.btnPingIP.Text = "Ping";
            this.btnPingIP.UseVisualStyleBackColor = true;
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(682, 50);
            this.txtURL.Margin = new System.Windows.Forms.Padding(4);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(247, 20);
            this.txtURL.TabIndex = 113;
            this.txtURL.Text = "192.168.0.201";
            // 
            // lblURL
            // 
            this.lblURL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(616, 53);
            this.lblURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(58, 13);
            this.lblURL.TabIndex = 115;
            this.lblURL.Text = "Host name";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(4, 53);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 126;
            this.lblPort.Text = "Port";
            // 
            // numPort
            // 
            this.numPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numPort.Location = new System.Drawing.Point(78, 50);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(161, 20);
            this.numPort.TabIndex = 127;
            // 
            // lblPortRequired
            // 
            this.lblPortRequired.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPortRequired.AutoSize = true;
            this.lblPortRequired.ForeColor = System.Drawing.Color.Red;
            this.lblPortRequired.Location = new System.Drawing.Point(30, 53);
            this.lblPortRequired.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblPortRequired.Name = "lblPortRequired";
            this.lblPortRequired.Size = new System.Drawing.Size(11, 13);
            this.lblPortRequired.TabIndex = 131;
            this.lblPortRequired.Text = "*";
            // 
            // btnPingUrl
            // 
            this.btnPingUrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPingUrl.AutoSize = true;
            this.btnPingUrl.Location = new System.Drawing.Point(1006, 48);
            this.btnPingUrl.Name = "btnPingUrl";
            this.btnPingUrl.Size = new System.Drawing.Size(4, 24);
            this.btnPingUrl.TabIndex = 120;
            this.btnPingUrl.Text = "Ping";
            this.btnPingUrl.UseVisualStyleBackColor = true;
            // 
            // ucSettingSystemsJobItems
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gRFIDConfig);
            this.Name = "ucSettingSystemsJobItems";
            this.Size = new System.Drawing.Size(1166, 102);
            this.gRFIDConfig.ResumeLayout(false);
            this.tblServerConfig.ResumeLayout(false);
            this.tblServerConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gRFIDConfig;
        private System.Windows.Forms.TableLayoutPanel tblServerConfig;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnPingUrl;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIPAddrress;
        private System.Windows.Forms.Button btnPingIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnWebConfig;
        private System.Windows.Forms.Label lblIPAddressRequired;
        private System.Windows.Forms.Label lblPortRequired;
    }
}
