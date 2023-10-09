namespace App.PVCFC_RFID.Design
{
    partial class ucProductExportLineInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProductExportLineInfo));
            this.tblControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.grSchedules = new System.Windows.Forms.GroupBox();
            this.tblExportSchedules = new System.Windows.Forms.TableLayoutPanel();
            this.txtAgentSearch = new System.Windows.Forms.TextBox();
            this.txtAgentOffline = new System.Windows.Forms.TextBox();
            this.btnAgentReload = new System.Windows.Forms.Button();
            this.btnAgentSearch = new System.Windows.Forms.Button();
            this.lblAgent = new System.Windows.Forms.Label();
            this.txtProductNameSearch = new System.Windows.Forms.TextBox();
            this.txtProductNameOffline = new System.Windows.Forms.TextBox();
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnProductNameSearch = new System.Windows.Forms.Button();
            this.btnProductNameReload = new System.Windows.Forms.Button();
            this.lblProductNameOffline = new System.Windows.Forms.Label();
            this.lblAgentOffline = new System.Windows.Forms.Label();
            this.listBoxProductName = new System.Windows.Forms.ListBox();
            this.listBoxAgentLevel1 = new System.Windows.Forms.ListBox();
            this.tblControls.SuspendLayout();
            this.grSchedules.SuspendLayout();
            this.tblExportSchedules.SuspendLayout();
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
            this.grSchedules.Controls.Add(this.tblExportSchedules);
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
            // tblExportSchedules
            // 
            this.tblExportSchedules.ColumnCount = 3;
            this.tblExportSchedules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblExportSchedules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblExportSchedules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblExportSchedules.Controls.Add(this.txtAgentSearch, 0, 6);
            this.tblExportSchedules.Controls.Add(this.txtAgentOffline, 0, 13);
            this.tblExportSchedules.Controls.Add(this.btnAgentReload, 2, 6);
            this.tblExportSchedules.Controls.Add(this.btnAgentSearch, 1, 6);
            this.tblExportSchedules.Controls.Add(this.lblAgent, 0, 5);
            this.tblExportSchedules.Controls.Add(this.txtProductNameSearch, 0, 2);
            this.tblExportSchedules.Controls.Add(this.txtProductNameOffline, 0, 10);
            this.tblExportSchedules.Controls.Add(this.grSchedulesInfo, 0, 15);
            this.tblExportSchedules.Controls.Add(this.lblProductName, 0, 1);
            this.tblExportSchedules.Controls.Add(this.btnProductNameSearch, 1, 2);
            this.tblExportSchedules.Controls.Add(this.btnProductNameReload, 2, 2);
            this.tblExportSchedules.Controls.Add(this.lblProductNameOffline, 0, 9);
            this.tblExportSchedules.Controls.Add(this.lblAgentOffline, 0, 12);
            this.tblExportSchedules.Controls.Add(this.listBoxProductName, 0, 3);
            this.tblExportSchedules.Controls.Add(this.listBoxAgentLevel1, 0, 7);
            this.tblExportSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblExportSchedules.Location = new System.Drawing.Point(4, 19);
            this.tblExportSchedules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tblExportSchedules.Name = "tblExportSchedules";
            this.tblExportSchedules.RowCount = 16;
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblExportSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportSchedules.Size = new System.Drawing.Size(499, 678);
            this.tblExportSchedules.TabIndex = 10;
            // 
            // txtAgentSearch
            // 
            this.txtAgentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgentSearch.Location = new System.Drawing.Point(4, 150);
            this.txtAgentSearch.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.txtAgentSearch.Name = "txtAgentSearch";
            this.txtAgentSearch.Size = new System.Drawing.Size(398, 23);
            this.txtAgentSearch.TabIndex = 2;
            // 
            // txtAgentOffline
            // 
            this.txtAgentOffline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblExportSchedules.SetColumnSpan(this.txtAgentOffline, 3);
            this.txtAgentOffline.Location = new System.Drawing.Point(4, 363);
            this.txtAgentOffline.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.txtAgentOffline.Multiline = true;
            this.txtAgentOffline.Name = "txtAgentOffline";
            this.txtAgentOffline.Size = new System.Drawing.Size(495, 60);
            this.txtAgentOffline.TabIndex = 5;
            // 
            // btnAgentReload
            // 
            this.btnAgentReload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgentReload.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAgentReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgentReload.Image = global::App.PVCFC_RFID.Properties.Resources.reload16x16;
            this.btnAgentReload.Location = new System.Drawing.Point(452, 150);
            this.btnAgentReload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAgentReload.Name = "btnAgentReload";
            this.btnAgentReload.Size = new System.Drawing.Size(43, 23);
            this.btnAgentReload.TabIndex = 22;
            this.btnAgentReload.UseVisualStyleBackColor = true;
            // 
            // btnAgentSearch
            // 
            this.btnAgentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgentSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgentSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAgentSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgentSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnAgentSearch.Image")));
            this.btnAgentSearch.Location = new System.Drawing.Point(402, 150);
            this.btnAgentSearch.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnAgentSearch.Name = "btnAgentSearch";
            this.btnAgentSearch.Size = new System.Drawing.Size(43, 23);
            this.btnAgentSearch.TabIndex = 19;
            this.btnAgentSearch.UseVisualStyleBackColor = false;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(4, 131);
            this.lblAgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(44, 16);
            this.lblAgent.TabIndex = 13;
            this.lblAgent.Text = "Agent";
            // 
            // txtProductNameSearch
            // 
            this.txtProductNameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductNameSearch.Location = new System.Drawing.Point(4, 29);
            this.txtProductNameSearch.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.txtProductNameSearch.Name = "txtProductNameSearch";
            this.txtProductNameSearch.Size = new System.Drawing.Size(398, 23);
            this.txtProductNameSearch.TabIndex = 0;
            // 
            // txtProductNameOffline
            // 
            this.txtProductNameOffline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblExportSchedules.SetColumnSpan(this.txtProductNameOffline, 3);
            this.txtProductNameOffline.Location = new System.Drawing.Point(4, 271);
            this.txtProductNameOffline.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.txtProductNameOffline.Multiline = true;
            this.txtProductNameOffline.Name = "txtProductNameOffline";
            this.txtProductNameOffline.Size = new System.Drawing.Size(495, 60);
            this.txtProductNameOffline.TabIndex = 4;
            // 
            // grSchedulesInfo
            // 
            this.grSchedulesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblExportSchedules.SetColumnSpan(this.grSchedulesInfo, 3);
            this.grSchedulesInfo.Controls.Add(this.tblSchedulesInfo);
            this.grSchedulesInfo.Location = new System.Drawing.Point(4, 439);
            this.grSchedulesInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grSchedulesInfo.Name = "grSchedulesInfo";
            this.grSchedulesInfo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grSchedulesInfo.Size = new System.Drawing.Size(491, 234);
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
            this.tblSchedulesInfo.Size = new System.Drawing.Size(483, 212);
            this.tblSchedulesInfo.TabIndex = 0;
            // 
            // lblTotalExport
            // 
            this.lblTotalExport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalExport.AutoSize = true;
            this.lblTotalExport.Location = new System.Drawing.Point(4, 181);
            this.lblTotalExport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalExport.Name = "lblTotalExport";
            this.lblTotalExport.Size = new System.Drawing.Size(37, 16);
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
            this.lblWarehouseReceiptCode.Size = new System.Drawing.Size(161, 16);
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
            this.lblDeliveryOrderCode.Size = new System.Drawing.Size(131, 16);
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
            this.lblLOTNo.Size = new System.Drawing.Size(55, 16);
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
            this.lblMFG.Size = new System.Drawing.Size(38, 16);
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
            this.lblEXP.Size = new System.Drawing.Size(33, 16);
            this.lblEXP.TabIndex = 15;
            this.lblEXP.Text = "EXP";
            // 
            // txtDeliveryOrderCode
            // 
            this.txtDeliveryOrderCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryOrderCode.Location = new System.Drawing.Point(173, 3);
            this.txtDeliveryOrderCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeliveryOrderCode.Name = "txtDeliveryOrderCode";
            this.txtDeliveryOrderCode.Size = new System.Drawing.Size(306, 23);
            this.txtDeliveryOrderCode.TabIndex = 6;
            // 
            // txtWarehouseReceiptCode
            // 
            this.txtWarehouseReceiptCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarehouseReceiptCode.Location = new System.Drawing.Point(173, 38);
            this.txtWarehouseReceiptCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWarehouseReceiptCode.Name = "txtWarehouseReceiptCode";
            this.txtWarehouseReceiptCode.Size = new System.Drawing.Size(306, 23);
            this.txtWarehouseReceiptCode.TabIndex = 7;
            // 
            // txtLOTNo
            // 
            this.txtLOTNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLOTNo.Location = new System.Drawing.Point(173, 73);
            this.txtLOTNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLOTNo.Name = "txtLOTNo";
            this.txtLOTNo.Size = new System.Drawing.Size(306, 23);
            this.txtLOTNo.TabIndex = 8;
            // 
            // dateMFG
            // 
            this.dateMFG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateMFG.Location = new System.Drawing.Point(173, 108);
            this.dateMFG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateMFG.Name = "dateMFG";
            this.dateMFG.Size = new System.Drawing.Size(306, 23);
            this.dateMFG.TabIndex = 9;
            // 
            // numTotalExport
            // 
            this.numTotalExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numTotalExport.Location = new System.Drawing.Point(173, 178);
            this.numTotalExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numTotalExport.Name = "numTotalExport";
            this.numTotalExport.Size = new System.Drawing.Size(306, 23);
            this.numTotalExport.TabIndex = 11;
            // 
            // dateEXP
            // 
            this.dateEXP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEXP.Location = new System.Drawing.Point(173, 143);
            this.dateEXP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateEXP.Name = "dateEXP";
            this.dateEXP.Size = new System.Drawing.Size(306, 23);
            this.dateEXP.TabIndex = 10;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(4, 10);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(95, 16);
            this.lblProductName.TabIndex = 10;
            this.lblProductName.Text = "Product name";
            // 
            // btnProductNameSearch
            // 
            this.btnProductNameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProductNameSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnProductNameSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProductNameSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductNameSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnProductNameSearch.Image")));
            this.btnProductNameSearch.Location = new System.Drawing.Point(402, 29);
            this.btnProductNameSearch.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnProductNameSearch.Name = "btnProductNameSearch";
            this.btnProductNameSearch.Size = new System.Drawing.Size(43, 23);
            this.btnProductNameSearch.TabIndex = 18;
            this.btnProductNameSearch.UseVisualStyleBackColor = false;
            // 
            // btnProductNameReload
            // 
            this.btnProductNameReload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProductNameReload.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProductNameReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductNameReload.Image = global::App.PVCFC_RFID.Properties.Resources.reload16x16;
            this.btnProductNameReload.Location = new System.Drawing.Point(452, 29);
            this.btnProductNameReload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnProductNameReload.Name = "btnProductNameReload";
            this.btnProductNameReload.Size = new System.Drawing.Size(43, 23);
            this.btnProductNameReload.TabIndex = 21;
            this.btnProductNameReload.UseVisualStyleBackColor = true;
            // 
            // lblProductNameOffline
            // 
            this.lblProductNameOffline.AutoSize = true;
            this.tblExportSchedules.SetColumnSpan(this.lblProductNameOffline, 3);
            this.lblProductNameOffline.Location = new System.Drawing.Point(3, 252);
            this.lblProductNameOffline.Name = "lblProductNameOffline";
            this.lblProductNameOffline.Size = new System.Drawing.Size(95, 16);
            this.lblProductNameOffline.TabIndex = 24;
            this.lblProductNameOffline.Text = "Product name";
            // 
            // lblAgentOffline
            // 
            this.lblAgentOffline.AutoSize = true;
            this.tblExportSchedules.SetColumnSpan(this.lblAgentOffline, 3);
            this.lblAgentOffline.Location = new System.Drawing.Point(3, 344);
            this.lblAgentOffline.Name = "lblAgentOffline";
            this.lblAgentOffline.Size = new System.Drawing.Size(44, 16);
            this.lblAgentOffline.TabIndex = 23;
            this.lblAgentOffline.Text = "Agent";
            // 
            // listBoxProductName
            // 
            this.listBoxProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblExportSchedules.SetColumnSpan(this.listBoxProductName, 3);
            this.listBoxProductName.FormattingEnabled = true;
            this.listBoxProductName.ItemHeight = 16;
            this.listBoxProductName.Location = new System.Drawing.Point(3, 58);
            this.listBoxProductName.Name = "listBoxProductName";
            this.listBoxProductName.Size = new System.Drawing.Size(493, 52);
            this.listBoxProductName.TabIndex = 1;
            // 
            // listBoxAgentLevel1
            // 
            this.listBoxAgentLevel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblExportSchedules.SetColumnSpan(this.listBoxAgentLevel1, 3);
            this.listBoxAgentLevel1.FormattingEnabled = true;
            this.listBoxAgentLevel1.ItemHeight = 16;
            this.listBoxAgentLevel1.Location = new System.Drawing.Point(3, 179);
            this.listBoxAgentLevel1.Name = "listBoxAgentLevel1";
            this.listBoxAgentLevel1.Size = new System.Drawing.Size(493, 52);
            this.listBoxAgentLevel1.TabIndex = 3;
            // 
            // ucProductExportLineInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grSchedules);
            this.Controls.Add(this.tblControls);
            this.Font = new System.Drawing.Font("Arial", 10.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ucProductExportLineInfo";
            this.Size = new System.Drawing.Size(507, 786);
            this.tblControls.ResumeLayout(false);
            this.grSchedules.ResumeLayout(false);
            this.tblExportSchedules.ResumeLayout(false);
            this.tblExportSchedules.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tblExportSchedules;
        private System.Windows.Forms.TextBox txtAgentOffline;
        private System.Windows.Forms.TextBox txtProductNameOffline;
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
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnProductNameSearch;
        private System.Windows.Forms.Button btnProductNameReload;
        private System.Windows.Forms.TextBox txtProductNameSearch;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.TextBox txtAgentSearch;
        private System.Windows.Forms.Button btnAgentSearch;
        private System.Windows.Forms.Button btnAgentReload;
        private System.Windows.Forms.Label lblAgentOffline;
        private System.Windows.Forms.Label lblProductNameOffline;
        private System.Windows.Forms.ListBox listBoxProductName;
        private System.Windows.Forms.ListBox listBoxAgentLevel1;

    }
}
