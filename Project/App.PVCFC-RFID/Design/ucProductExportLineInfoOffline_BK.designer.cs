namespace App.PVCFC_RFID.Design
{
    partial class ucProductExportLineInfoOffline_BK
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
            this.tblControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.grSchedules = new System.Windows.Forms.GroupBox();
            this.tblSyncSchedules = new System.Windows.Forms.TableLayoutPanel();
            this.txtAgent = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblAgent = new System.Windows.Forms.Label();
            this.grSchedulesInfo = new System.Windows.Forms.GroupBox();
            this.tblSchedulesInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalExport = new System.Windows.Forms.Label();
            this.lblWarehouseReceiptCode = new System.Windows.Forms.Label();
            this.lblDeliveryOrderCode = new System.Windows.Forms.Label();
            this.lblLOTNo = new System.Windows.Forms.Label();
            this.lblMFG = new System.Windows.Forms.Label();
            this.lblEXP = new System.Windows.Forms.Label();
            this.txtDeliveryOrderCode = new System.Windows.Forms.TextBox();
            this.txtWarehouseReceiptCode = new System.Windows.Forms.TextBox();
            this.txtLOTNo = new System.Windows.Forms.TextBox();
            this.dateMFG = new System.Windows.Forms.DateTimePicker();
            this.numTotalExport = new System.Windows.Forms.NumericUpDown();
            this.dateEXP = new System.Windows.Forms.DateTimePicker();
            this.tblControls.SuspendLayout();
            this.grSchedules.SuspendLayout();
            this.tblSyncSchedules.SuspendLayout();
            this.grSchedulesInfo.SuspendLayout();
            this.tblSchedulesInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalExport)).BeginInit();
            this.SuspendLayout();
            // 
            // tblControls
            // 
            this.tblControls.ColumnCount = 3;
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblControls.Controls.Add(this.btnStop, 0, 0);
            this.tblControls.Controls.Add(this.btnStart, 0, 0);
            this.tblControls.Controls.Add(this.btnTrigger, 1, 0);
            this.tblControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblControls.Location = new System.Drawing.Point(0, 700);
            this.tblControls.Margin = new System.Windows.Forms.Padding(4);
            this.tblControls.Name = "tblControls";
            this.tblControls.RowCount = 1;
            this.tblControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControls.Size = new System.Drawing.Size(507, 86);
            this.tblControls.TabIndex = 13;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Image = global::App.PVCFC_RFID.Properties.Resources.stop65x65;
            this.btnStop.Location = new System.Drawing.Point(172, 3);
            this.btnStop.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(163, 80);
            this.btnStop.TabIndex = 4;
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Image = global::App.PVCFC_RFID.Properties.Resources.start65x65;
            this.btnStart.Location = new System.Drawing.Point(0, 3);
            this.btnStart.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnStart.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(166, 80);
            this.btnStart.TabIndex = 0;
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnTrigger
            // 
            this.btnTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrigger.Image = global::App.PVCFC_RFID.Properties.Resources.trigger65x65;
            this.btnTrigger.Location = new System.Drawing.Point(341, 3);
            this.btnTrigger.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnTrigger.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(166, 80);
            this.btnTrigger.TabIndex = 3;
            this.btnTrigger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrigger.UseVisualStyleBackColor = true;
            // 
            // grSchedules
            // 
            this.grSchedules.Controls.Add(this.tblSyncSchedules);
            this.grSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grSchedules.Location = new System.Drawing.Point(0, 0);
            this.grSchedules.Margin = new System.Windows.Forms.Padding(11, 3, 11, 3);
            this.grSchedules.Name = "grSchedules";
            this.grSchedules.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grSchedules.Size = new System.Drawing.Size(507, 700);
            this.grSchedules.TabIndex = 14;
            this.grSchedules.TabStop = false;
            this.grSchedules.Text = "Schedules";
            // 
            // tblSyncSchedules
            // 
            this.tblSyncSchedules.ColumnCount = 1;
            this.tblSyncSchedules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSyncSchedules.Controls.Add(this.txtAgent, 0, 5);
            this.tblSyncSchedules.Controls.Add(this.lblProductName, 0, 1);
            this.tblSyncSchedules.Controls.Add(this.txtProductName, 0, 2);
            this.tblSyncSchedules.Controls.Add(this.lblAgent, 0, 4);
            this.tblSyncSchedules.Controls.Add(this.grSchedulesInfo, 0, 7);
            this.tblSyncSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSyncSchedules.Location = new System.Drawing.Point(4, 19);
            this.tblSyncSchedules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tblSyncSchedules.Name = "tblSyncSchedules";
            this.tblSyncSchedules.RowCount = 8;
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSyncSchedules.Size = new System.Drawing.Size(499, 678);
            this.tblSyncSchedules.TabIndex = 10;
            // 
            // txtAgent
            // 
            this.txtAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgent.Location = new System.Drawing.Point(4, 243);
            this.txtAgent.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.txtAgent.Multiline = true;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(495, 182);
            this.txtAgent.TabIndex = 14;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(4, 10);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(96, 16);
            this.lblProductName.TabIndex = 10;
            this.lblProductName.Text = "Product name";
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.Location = new System.Drawing.Point(4, 29);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(495, 182);
            this.txtProductName.TabIndex = 11;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(4, 224);
            this.lblAgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(45, 16);
            this.lblAgent.TabIndex = 13;
            this.lblAgent.Text = "Agent";
            // 
            // grSchedulesInfo
            // 
            this.grSchedulesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grSchedulesInfo.Controls.Add(this.tblSchedulesInfo);
            this.grSchedulesInfo.Location = new System.Drawing.Point(4, 441);
            this.grSchedulesInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grSchedulesInfo.Name = "grSchedulesInfo";
            this.grSchedulesInfo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grSchedulesInfo.Size = new System.Drawing.Size(491, 233);
            this.grSchedulesInfo.TabIndex = 16;
            this.grSchedulesInfo.TabStop = false;
            this.grSchedulesInfo.Text = "Schedules info";
            // 
            // tblSchedulesInfo
            // 
            this.tblSchedulesInfo.ColumnCount = 2;
            this.tblSchedulesInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSchedulesInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSchedulesInfo.Controls.Add(this.lblTotalExport, 0, 10);
            this.tblSchedulesInfo.Controls.Add(this.lblWarehouseReceiptCode, 0, 2);
            this.tblSchedulesInfo.Controls.Add(this.lblDeliveryOrderCode, 0, 0);
            this.tblSchedulesInfo.Controls.Add(this.lblLOTNo, 0, 4);
            this.tblSchedulesInfo.Controls.Add(this.lblMFG, 0, 6);
            this.tblSchedulesInfo.Controls.Add(this.lblEXP, 0, 8);
            this.tblSchedulesInfo.Controls.Add(this.txtDeliveryOrderCode, 1, 0);
            this.tblSchedulesInfo.Controls.Add(this.txtWarehouseReceiptCode, 1, 2);
            this.tblSchedulesInfo.Controls.Add(this.txtLOTNo, 1, 4);
            this.tblSchedulesInfo.Controls.Add(this.dateMFG, 1, 6);
            this.tblSchedulesInfo.Controls.Add(this.numTotalExport, 1, 10);
            this.tblSchedulesInfo.Controls.Add(this.dateEXP, 1, 8);
            this.tblSchedulesInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSchedulesInfo.Location = new System.Drawing.Point(4, 19);
            this.tblSchedulesInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tblSchedulesInfo.Name = "tblSchedulesInfo";
            this.tblSchedulesInfo.RowCount = 13;
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSchedulesInfo.Size = new System.Drawing.Size(483, 211);
            this.tblSchedulesInfo.TabIndex = 0;
            // 
            // lblTotalExport
            // 
            this.lblTotalExport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalExport.AutoSize = true;
            this.lblTotalExport.Location = new System.Drawing.Point(4, 181);
            this.lblTotalExport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalExport.Name = "lblTotalExport";
            this.lblTotalExport.Size = new System.Drawing.Size(38, 16);
            this.lblTotalExport.TabIndex = 16;
            this.lblTotalExport.Text = "Total";
            // 
            // lblWarehouseReceiptCode
            // 
            this.lblWarehouseReceiptCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWarehouseReceiptCode.AutoSize = true;
            this.lblWarehouseReceiptCode.Location = new System.Drawing.Point(4, 41);
            this.lblWarehouseReceiptCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWarehouseReceiptCode.Name = "lblWarehouseReceiptCode";
            this.lblWarehouseReceiptCode.Size = new System.Drawing.Size(162, 16);
            this.lblWarehouseReceiptCode.TabIndex = 12;
            this.lblWarehouseReceiptCode.Text = "Warehouse receipt code";
            // 
            // lblDeliveryOrderCode
            // 
            this.lblDeliveryOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDeliveryOrderCode.AutoSize = true;
            this.lblDeliveryOrderCode.Location = new System.Drawing.Point(4, 6);
            this.lblDeliveryOrderCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeliveryOrderCode.Name = "lblDeliveryOrderCode";
            this.lblDeliveryOrderCode.Size = new System.Drawing.Size(132, 16);
            this.lblDeliveryOrderCode.TabIndex = 11;
            this.lblDeliveryOrderCode.Text = "Delivery order code";
            // 
            // lblLOTNo
            // 
            this.lblLOTNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLOTNo.AutoSize = true;
            this.lblLOTNo.Location = new System.Drawing.Point(4, 76);
            this.lblLOTNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLOTNo.Name = "lblLOTNo";
            this.lblLOTNo.Size = new System.Drawing.Size(56, 16);
            this.lblLOTNo.TabIndex = 13;
            this.lblLOTNo.Text = "LOT no";
            // 
            // lblMFG
            // 
            this.lblMFG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMFG.AutoSize = true;
            this.lblMFG.Location = new System.Drawing.Point(4, 111);
            this.lblMFG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMFG.Name = "lblMFG";
            this.lblMFG.Size = new System.Drawing.Size(39, 16);
            this.lblMFG.TabIndex = 14;
            this.lblMFG.Text = "MFG";
            // 
            // lblEXP
            // 
            this.lblEXP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEXP.AutoSize = true;
            this.lblEXP.Location = new System.Drawing.Point(4, 146);
            this.lblEXP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEXP.Name = "lblEXP";
            this.lblEXP.Size = new System.Drawing.Size(34, 16);
            this.lblEXP.TabIndex = 15;
            this.lblEXP.Text = "EXP";
            // 
            // txtDeliveryOrderCode
            // 
            this.txtDeliveryOrderCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryOrderCode.Location = new System.Drawing.Point(174, 3);
            this.txtDeliveryOrderCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeliveryOrderCode.Name = "txtDeliveryOrderCode";
            this.txtDeliveryOrderCode.Size = new System.Drawing.Size(305, 23);
            this.txtDeliveryOrderCode.TabIndex = 17;
            // 
            // txtWarehouseReceiptCode
            // 
            this.txtWarehouseReceiptCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarehouseReceiptCode.Location = new System.Drawing.Point(174, 38);
            this.txtWarehouseReceiptCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWarehouseReceiptCode.Name = "txtWarehouseReceiptCode";
            this.txtWarehouseReceiptCode.Size = new System.Drawing.Size(305, 23);
            this.txtWarehouseReceiptCode.TabIndex = 18;
            // 
            // txtLOTNo
            // 
            this.txtLOTNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLOTNo.Location = new System.Drawing.Point(174, 73);
            this.txtLOTNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLOTNo.Name = "txtLOTNo";
            this.txtLOTNo.Size = new System.Drawing.Size(305, 23);
            this.txtLOTNo.TabIndex = 19;
            // 
            // dateMFG
            // 
            this.dateMFG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateMFG.Location = new System.Drawing.Point(174, 108);
            this.dateMFG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateMFG.Name = "dateMFG";
            this.dateMFG.Size = new System.Drawing.Size(305, 23);
            this.dateMFG.TabIndex = 20;
            // 
            // numTotalExport
            // 
            this.numTotalExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numTotalExport.Location = new System.Drawing.Point(174, 178);
            this.numTotalExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numTotalExport.Name = "numTotalExport";
            this.numTotalExport.Size = new System.Drawing.Size(305, 23);
            this.numTotalExport.TabIndex = 17;
            // 
            // dateEXP
            // 
            this.dateEXP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEXP.Location = new System.Drawing.Point(174, 143);
            this.dateEXP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateEXP.Name = "dateEXP";
            this.dateEXP.Size = new System.Drawing.Size(305, 23);
            this.dateEXP.TabIndex = 21;
            // 
            // ucProductExportLineInfoOffline_BK
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grSchedules);
            this.Controls.Add(this.tblControls);
            this.Font = new System.Drawing.Font("Arial", 10.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ucProductExportLineInfoOffline_BK";
            this.Size = new System.Drawing.Size(507, 786);
            this.tblControls.ResumeLayout(false);
            this.grSchedules.ResumeLayout(false);
            this.tblSyncSchedules.ResumeLayout(false);
            this.tblSyncSchedules.PerformLayout();
            this.grSchedulesInfo.ResumeLayout(false);
            this.tblSchedulesInfo.ResumeLayout(false);
            this.tblSchedulesInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblControls;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.GroupBox grSchedules;
        private System.Windows.Forms.TableLayoutPanel tblSyncSchedules;
        private System.Windows.Forms.TextBox txtAgent;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.GroupBox grSchedulesInfo;
        private System.Windows.Forms.TableLayoutPanel tblSchedulesInfo;
        private System.Windows.Forms.Label lblTotalExport;
        private System.Windows.Forms.Label lblWarehouseReceiptCode;
        private System.Windows.Forms.Label lblDeliveryOrderCode;
        private System.Windows.Forms.Label lblLOTNo;
        private System.Windows.Forms.Label lblMFG;
        private System.Windows.Forms.Label lblEXP;
        private System.Windows.Forms.TextBox txtDeliveryOrderCode;
        private System.Windows.Forms.TextBox txtWarehouseReceiptCode;
        private System.Windows.Forms.TextBox txtLOTNo;
        private System.Windows.Forms.DateTimePicker dateMFG;
        private System.Windows.Forms.NumericUpDown numTotalExport;
        private System.Windows.Forms.DateTimePicker dateEXP;

    }
}
