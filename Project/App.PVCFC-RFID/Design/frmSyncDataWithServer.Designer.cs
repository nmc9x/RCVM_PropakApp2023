namespace App.PVCFC_RFID.Design
{
    partial class frmSyncDataWithServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyncDataWithServer));
            this.tblMains = new System.Windows.Forms.TableLayoutPanel();
            this.grDataDetails = new System.Windows.Forms.GroupBox();
            this.tblDataDetails = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblControlBtn = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControlSync = new System.Windows.Forms.TabControl();
            this.tabControlSyncPageExport = new System.Windows.Forms.TabPage();
            this.grSyncSchedules = new System.Windows.Forms.GroupBox();
            this.tblSyncSchedules = new System.Windows.Forms.TableLayoutPanel();
            this.txtAgentSearch = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblSchedules = new System.Windows.Forms.Label();
            this.txtSchedulesSearch = new System.Windows.Forms.TextBox();
            this.txtProductNameSearch = new System.Windows.Forms.TextBox();
            this.lblAgent = new System.Windows.Forms.Label();
            this.grSchedulesInfo = new System.Windows.Forms.GroupBox();
            this.tblSchedulesInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalExport = new System.Windows.Forms.Label();
            this.lblWarehouseReceiptCode = new System.Windows.Forms.Label();
            this.lblDeliveryOrderCode = new System.Windows.Forms.Label();
            this.lblLOTNo = new System.Windows.Forms.Label();
            this.txtDeliveryOrderCode = new System.Windows.Forms.TextBox();
            this.txtWarehouseReceiptCode = new System.Windows.Forms.TextBox();
            this.txtLOTNo = new System.Windows.Forms.TextBox();
            this.numTotalExport = new System.Windows.Forms.NumericUpDown();
            this.grNote = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNoteAgent = new System.Windows.Forms.Label();
            this.lblNoteAgentValues = new System.Windows.Forms.Label();
            this.lblNoteProductName = new System.Windows.Forms.Label();
            this.lblNoteProductNameValues = new System.Windows.Forms.Label();
            this.lblDeliveryCode = new System.Windows.Forms.Label();
            this.lblDeliveryCodeValues = new System.Windows.Forms.Label();
            this.btnSearchSchedules = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnReloadSchedules = new System.Windows.Forms.Button();
            this.btnReloadProductName = new System.Windows.Forms.Button();
            this.btnReloadAgent = new System.Windows.Forms.Button();
            this.listBoxProductName = new System.Windows.Forms.ListBox();
            this.listBoxAgentLevel1 = new System.Windows.Forms.ListBox();
            this.listBoxSchedules = new System.Windows.Forms.ListBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.tblControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.tabControlSyncPageImport = new System.Windows.Forms.TabPage();
            this.tblMains.SuspendLayout();
            this.grDataDetails.SuspendLayout();
            this.tblDataDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tblControlBtn.SuspendLayout();
            this.tabControlSync.SuspendLayout();
            this.tabControlSyncPageExport.SuspendLayout();
            this.grSyncSchedules.SuspendLayout();
            this.tblSyncSchedules.SuspendLayout();
            this.grSchedulesInfo.SuspendLayout();
            this.tblSchedulesInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalExport)).BeginInit();
            this.grNote.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMains
            // 
            this.tblMains.ColumnCount = 2;
            this.tblMains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.Controls.Add(this.grDataDetails, 1, 3);
            this.tblMains.Controls.Add(this.lblTitle, 1, 1);
            this.tblMains.Controls.Add(this.tabControlSync, 0, 1);
            this.tblMains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMains.Font = new System.Drawing.Font("Arial", 10.25F);
            this.tblMains.Location = new System.Drawing.Point(0, 0);
            this.tblMains.Margin = new System.Windows.Forms.Padding(4);
            this.tblMains.Name = "tblMains";
            this.tblMains.RowCount = 4;
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMains.Size = new System.Drawing.Size(1281, 739);
            this.tblMains.TabIndex = 0;
            // 
            // grDataDetails
            // 
            this.grDataDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grDataDetails.Controls.Add(this.tblDataDetails);
            this.grDataDetails.Location = new System.Drawing.Point(403, 272);
            this.grDataDetails.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.grDataDetails.Name = "grDataDetails";
            this.grDataDetails.Size = new System.Drawing.Size(875, 460);
            this.grDataDetails.TabIndex = 8;
            this.grDataDetails.TabStop = false;
            this.grDataDetails.Text = "Details";
            // 
            // tblDataDetails
            // 
            this.tblDataDetails.ColumnCount = 1;
            this.tblDataDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDataDetails.Controls.Add(this.dataGridView1, 0, 0);
            this.tblDataDetails.Controls.Add(this.tblControlBtn, 0, 2);
            this.tblDataDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDataDetails.Location = new System.Drawing.Point(3, 19);
            this.tblDataDetails.Name = "tblDataDetails";
            this.tblDataDetails.RowCount = 3;
            this.tblDataDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDataDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblDataDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDataDetails.Size = new System.Drawing.Size(869, 438);
            this.tblDataDetails.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(861, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // tblControlBtn
            // 
            this.tblControlBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblControlBtn.ColumnCount = 5;
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControlBtn.Controls.Add(this.btnNext, 3, 0);
            this.tblControlBtn.Controls.Add(this.btnBack, 2, 0);
            this.tblControlBtn.Controls.Add(this.btnFirst, 1, 0);
            this.tblControlBtn.Controls.Add(this.btnLast, 4, 0);
            this.tblControlBtn.Controls.Add(this.lblTotalRows, 0, 0);
            this.tblControlBtn.Location = new System.Drawing.Point(4, 380);
            this.tblControlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.tblControlBtn.Name = "tblControlBtn";
            this.tblControlBtn.RowCount = 1;
            this.tblControlBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControlBtn.Size = new System.Drawing.Size(861, 54);
            this.tblControlBtn.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(692, 3);
            this.btnNext.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 48);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(606, 3);
            this.btnBack.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 48);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(520, 3);
            this.btnFirst.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(80, 48);
            this.btnFirst.TabIndex = 2;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(778, 3);
            this.btnLast.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(80, 48);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Font = new System.Drawing.Font("Arial", 12.25F);
            this.lblTotalRows.Location = new System.Drawing.Point(3, 17);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(86, 19);
            this.lblTotalRows.TabIndex = 4;
            this.lblTotalRows.Text = "Tổng số: 0";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(781, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(119, 22);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "SYNC DATA";
            // 
            // tabControlSync
            // 
            this.tabControlSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSync.Controls.Add(this.tabControlSyncPageExport);
            this.tabControlSync.Controls.Add(this.tabControlSyncPageImport);
            this.tabControlSync.Location = new System.Drawing.Point(3, 8);
            this.tabControlSync.Name = "tabControlSync";
            this.tblMains.SetRowSpan(this.tabControlSync, 3);
            this.tabControlSync.SelectedIndex = 0;
            this.tabControlSync.Size = new System.Drawing.Size(394, 728);
            this.tabControlSync.TabIndex = 13;
            // 
            // tabControlSyncPageExport
            // 
            this.tabControlSyncPageExport.Controls.Add(this.grSyncSchedules);
            this.tabControlSyncPageExport.Controls.Add(this.tblControls);
            this.tabControlSyncPageExport.Location = new System.Drawing.Point(4, 25);
            this.tabControlSyncPageExport.Name = "tabControlSyncPageExport";
            this.tabControlSyncPageExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlSyncPageExport.Size = new System.Drawing.Size(386, 699);
            this.tabControlSyncPageExport.TabIndex = 0;
            this.tabControlSyncPageExport.Text = "Export";
            this.tabControlSyncPageExport.UseVisualStyleBackColor = true;
            // 
            // grSyncSchedules
            // 
            this.grSyncSchedules.Controls.Add(this.tblSyncSchedules);
            this.grSyncSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grSyncSchedules.Location = new System.Drawing.Point(3, 3);
            this.grSyncSchedules.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.grSyncSchedules.Name = "grSyncSchedules";
            this.grSyncSchedules.Size = new System.Drawing.Size(380, 607);
            this.grSyncSchedules.TabIndex = 14;
            this.grSyncSchedules.TabStop = false;
            this.grSyncSchedules.Text = "Schedules";
            // 
            // tblSyncSchedules
            // 
            this.tblSyncSchedules.ColumnCount = 3;
            this.tblSyncSchedules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSyncSchedules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSyncSchedules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSyncSchedules.Controls.Add(this.txtAgentSearch, 0, 11);
            this.tblSyncSchedules.Controls.Add(this.lblProductName, 0, 6);
            this.tblSyncSchedules.Controls.Add(this.lblSchedules, 0, 1);
            this.tblSyncSchedules.Controls.Add(this.txtSchedulesSearch, 0, 2);
            this.tblSyncSchedules.Controls.Add(this.txtProductNameSearch, 0, 7);
            this.tblSyncSchedules.Controls.Add(this.lblAgent, 0, 10);
            this.tblSyncSchedules.Controls.Add(this.grSchedulesInfo, 0, 14);
            this.tblSyncSchedules.Controls.Add(this.btnSearchSchedules, 1, 2);
            this.tblSyncSchedules.Controls.Add(this.button2, 1, 7);
            this.tblSyncSchedules.Controls.Add(this.button3, 1, 11);
            this.tblSyncSchedules.Controls.Add(this.btnReloadSchedules, 2, 2);
            this.tblSyncSchedules.Controls.Add(this.btnReloadProductName, 2, 7);
            this.tblSyncSchedules.Controls.Add(this.btnReloadAgent, 2, 11);
            this.tblSyncSchedules.Controls.Add(this.listBoxProductName, 0, 8);
            this.tblSyncSchedules.Controls.Add(this.listBoxAgentLevel1, 0, 12);
            this.tblSyncSchedules.Controls.Add(this.listBoxSchedules, 0, 3);
            this.tblSyncSchedules.Controls.Add(this.btnPreview, 0, 4);
            this.tblSyncSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSyncSchedules.Location = new System.Drawing.Point(3, 19);
            this.tblSyncSchedules.Name = "tblSyncSchedules";
            this.tblSyncSchedules.RowCount = 15;
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblSyncSchedules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSyncSchedules.Size = new System.Drawing.Size(374, 585);
            this.tblSyncSchedules.TabIndex = 10;
            // 
            // txtAgentSearch
            // 
            this.txtAgentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgentSearch.Location = new System.Drawing.Point(3, 219);
            this.txtAgentSearch.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txtAgentSearch.Name = "txtAgentSearch";
            this.txtAgentSearch.Size = new System.Drawing.Size(285, 23);
            this.txtAgentSearch.TabIndex = 14;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(3, 124);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(95, 16);
            this.lblProductName.TabIndex = 10;
            this.lblProductName.Text = "Product name";
            // 
            // lblSchedules
            // 
            this.lblSchedules.AutoSize = true;
            this.lblSchedules.Location = new System.Drawing.Point(3, 10);
            this.lblSchedules.Name = "lblSchedules";
            this.lblSchedules.Size = new System.Drawing.Size(73, 16);
            this.lblSchedules.TabIndex = 3;
            this.lblSchedules.Text = "Schedules";
            // 
            // txtSchedulesSearch
            // 
            this.txtSchedulesSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchedulesSearch.Location = new System.Drawing.Point(3, 29);
            this.txtSchedulesSearch.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txtSchedulesSearch.Name = "txtSchedulesSearch";
            this.txtSchedulesSearch.Size = new System.Drawing.Size(285, 23);
            this.txtSchedulesSearch.TabIndex = 4;
            // 
            // txtProductNameSearch
            // 
            this.txtProductNameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductNameSearch.Location = new System.Drawing.Point(3, 143);
            this.txtProductNameSearch.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txtProductNameSearch.Name = "txtProductNameSearch";
            this.txtProductNameSearch.Size = new System.Drawing.Size(285, 23);
            this.txtProductNameSearch.TabIndex = 11;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(3, 200);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(44, 16);
            this.lblAgent.TabIndex = 13;
            this.lblAgent.Text = "Agent";
            // 
            // grSchedulesInfo
            // 
            this.grSchedulesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSyncSchedules.SetColumnSpan(this.grSchedulesInfo, 3);
            this.grSchedulesInfo.Controls.Add(this.tblSchedulesInfo);
            this.grSchedulesInfo.Location = new System.Drawing.Point(3, 279);
            this.grSchedulesInfo.Name = "grSchedulesInfo";
            this.grSchedulesInfo.Size = new System.Drawing.Size(368, 302);
            this.grSchedulesInfo.TabIndex = 16;
            this.grSchedulesInfo.TabStop = false;
            this.grSchedulesInfo.Text = "Schedules info";
            // 
            // tblSchedulesInfo
            // 
            this.tblSchedulesInfo.ColumnCount = 2;
            this.tblSchedulesInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSchedulesInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSchedulesInfo.Controls.Add(this.lblTotalExport, 0, 6);
            this.tblSchedulesInfo.Controls.Add(this.lblWarehouseReceiptCode, 0, 2);
            this.tblSchedulesInfo.Controls.Add(this.lblDeliveryOrderCode, 0, 0);
            this.tblSchedulesInfo.Controls.Add(this.lblLOTNo, 0, 4);
            this.tblSchedulesInfo.Controls.Add(this.txtDeliveryOrderCode, 1, 0);
            this.tblSchedulesInfo.Controls.Add(this.txtWarehouseReceiptCode, 1, 2);
            this.tblSchedulesInfo.Controls.Add(this.txtLOTNo, 1, 4);
            this.tblSchedulesInfo.Controls.Add(this.numTotalExport, 1, 6);
            this.tblSchedulesInfo.Controls.Add(this.grNote, 0, 7);
            this.tblSchedulesInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSchedulesInfo.Location = new System.Drawing.Point(3, 19);
            this.tblSchedulesInfo.Name = "tblSchedulesInfo";
            this.tblSchedulesInfo.RowCount = 8;
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSchedulesInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSchedulesInfo.Size = new System.Drawing.Size(362, 280);
            this.tblSchedulesInfo.TabIndex = 0;
            // 
            // lblTotalExport
            // 
            this.lblTotalExport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalExport.AutoSize = true;
            this.lblTotalExport.Location = new System.Drawing.Point(3, 108);
            this.lblTotalExport.Name = "lblTotalExport";
            this.lblTotalExport.Size = new System.Drawing.Size(37, 16);
            this.lblTotalExport.TabIndex = 16;
            this.lblTotalExport.Text = "Total";
            // 
            // lblWarehouseReceiptCode
            // 
            this.lblWarehouseReceiptCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWarehouseReceiptCode.AutoSize = true;
            this.lblWarehouseReceiptCode.Location = new System.Drawing.Point(3, 40);
            this.lblWarehouseReceiptCode.Name = "lblWarehouseReceiptCode";
            this.lblWarehouseReceiptCode.Size = new System.Drawing.Size(161, 16);
            this.lblWarehouseReceiptCode.TabIndex = 12;
            this.lblWarehouseReceiptCode.Text = "Warehouse receipt code";
            // 
            // lblDeliveryOrderCode
            // 
            this.lblDeliveryOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDeliveryOrderCode.AutoSize = true;
            this.lblDeliveryOrderCode.Location = new System.Drawing.Point(3, 6);
            this.lblDeliveryOrderCode.Name = "lblDeliveryOrderCode";
            this.lblDeliveryOrderCode.Size = new System.Drawing.Size(131, 16);
            this.lblDeliveryOrderCode.TabIndex = 11;
            this.lblDeliveryOrderCode.Text = "Delivery order code";
            // 
            // lblLOTNo
            // 
            this.lblLOTNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLOTNo.AutoSize = true;
            this.lblLOTNo.Location = new System.Drawing.Point(3, 74);
            this.lblLOTNo.Name = "lblLOTNo";
            this.lblLOTNo.Size = new System.Drawing.Size(55, 16);
            this.lblLOTNo.TabIndex = 13;
            this.lblLOTNo.Text = "LOT no";
            // 
            // txtDeliveryOrderCode
            // 
            this.txtDeliveryOrderCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryOrderCode.Location = new System.Drawing.Point(170, 3);
            this.txtDeliveryOrderCode.Name = "txtDeliveryOrderCode";
            this.txtDeliveryOrderCode.Size = new System.Drawing.Size(189, 23);
            this.txtDeliveryOrderCode.TabIndex = 17;
            // 
            // txtWarehouseReceiptCode
            // 
            this.txtWarehouseReceiptCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarehouseReceiptCode.Location = new System.Drawing.Point(170, 37);
            this.txtWarehouseReceiptCode.Name = "txtWarehouseReceiptCode";
            this.txtWarehouseReceiptCode.Size = new System.Drawing.Size(189, 23);
            this.txtWarehouseReceiptCode.TabIndex = 18;
            // 
            // txtLOTNo
            // 
            this.txtLOTNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLOTNo.Location = new System.Drawing.Point(170, 71);
            this.txtLOTNo.Name = "txtLOTNo";
            this.txtLOTNo.Size = new System.Drawing.Size(189, 23);
            this.txtLOTNo.TabIndex = 19;
            // 
            // numTotalExport
            // 
            this.numTotalExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numTotalExport.Location = new System.Drawing.Point(170, 105);
            this.numTotalExport.Name = "numTotalExport";
            this.numTotalExport.Size = new System.Drawing.Size(189, 23);
            this.numTotalExport.TabIndex = 17;
            // 
            // grNote
            // 
            this.grNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSchedulesInfo.SetColumnSpan(this.grNote, 2);
            this.grNote.Controls.Add(this.tableLayoutPanel1);
            this.grNote.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Italic);
            this.grNote.ForeColor = System.Drawing.SystemColors.Highlight;
            this.grNote.Location = new System.Drawing.Point(3, 134);
            this.grNote.Name = "grNote";
            this.grNote.Size = new System.Drawing.Size(356, 143);
            this.grNote.TabIndex = 27;
            this.grNote.TabStop = false;
            this.grNote.Text = "Note";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblNoteAgent, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNoteAgentValues, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNoteProductName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNoteProductNameValues, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDeliveryCode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDeliveryCodeValues, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 121);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNoteAgent
            // 
            this.lblNoteAgent.AutoSize = true;
            this.lblNoteAgent.Location = new System.Drawing.Point(3, 26);
            this.lblNoteAgent.Name = "lblNoteAgent";
            this.lblNoteAgent.Size = new System.Drawing.Size(44, 16);
            this.lblNoteAgent.TabIndex = 26;
            this.lblNoteAgent.Text = "Agent";
            // 
            // lblNoteAgentValues
            // 
            this.lblNoteAgentValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoteAgentValues.AutoSize = true;
            this.lblNoteAgentValues.Location = new System.Drawing.Point(104, 26);
            this.lblNoteAgentValues.Name = "lblNoteAgentValues";
            this.lblNoteAgentValues.Size = new System.Drawing.Size(243, 16);
            this.lblNoteAgentValues.TabIndex = 25;
            this.lblNoteAgentValues.Text = "[Agent code]";
            // 
            // lblNoteProductName
            // 
            this.lblNoteProductName.AutoSize = true;
            this.lblNoteProductName.Location = new System.Drawing.Point(3, 0);
            this.lblNoteProductName.Name = "lblNoteProductName";
            this.lblNoteProductName.Size = new System.Drawing.Size(95, 16);
            this.lblNoteProductName.TabIndex = 23;
            this.lblNoteProductName.Text = "Product name";
            // 
            // lblNoteProductNameValues
            // 
            this.lblNoteProductNameValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoteProductNameValues.AutoSize = true;
            this.lblNoteProductNameValues.Location = new System.Drawing.Point(104, 0);
            this.lblNoteProductNameValues.Name = "lblNoteProductNameValues";
            this.lblNoteProductNameValues.Size = new System.Drawing.Size(243, 16);
            this.lblNoteProductNameValues.TabIndex = 24;
            this.lblNoteProductNameValues.Text = "[Product name]";
            // 
            // lblDeliveryCode
            // 
            this.lblDeliveryCode.AutoSize = true;
            this.lblDeliveryCode.Location = new System.Drawing.Point(3, 52);
            this.lblDeliveryCode.Name = "lblDeliveryCode";
            this.lblDeliveryCode.Size = new System.Drawing.Size(44, 16);
            this.lblDeliveryCode.TabIndex = 27;
            this.lblDeliveryCode.Text = "Agent";
            // 
            // lblDeliveryCodeValues
            // 
            this.lblDeliveryCodeValues.AutoSize = true;
            this.lblDeliveryCodeValues.Location = new System.Drawing.Point(104, 52);
            this.lblDeliveryCodeValues.Name = "lblDeliveryCodeValues";
            this.lblDeliveryCodeValues.Size = new System.Drawing.Size(44, 16);
            this.lblDeliveryCodeValues.TabIndex = 28;
            this.lblDeliveryCodeValues.Text = "Agent";
            // 
            // btnSearchSchedules
            // 
            this.btnSearchSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchSchedules.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchSchedules.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearchSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSchedules.Image = global::App.PVCFC_RFID.Properties.Resources.search16x16;
            this.btnSearchSchedules.Location = new System.Drawing.Point(288, 29);
            this.btnSearchSchedules.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnSearchSchedules.Name = "btnSearchSchedules";
            this.btnSearchSchedules.Size = new System.Drawing.Size(32, 23);
            this.btnSearchSchedules.TabIndex = 17;
            this.btnSearchSchedules.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(288, 143);
            this.button2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(288, 219);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 23);
            this.button3.TabIndex = 19;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnReloadSchedules
            // 
            this.btnReloadSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReloadSchedules.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReloadSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadSchedules.Image = global::App.PVCFC_RFID.Properties.Resources.reload16x16;
            this.btnReloadSchedules.Location = new System.Drawing.Point(327, 29);
            this.btnReloadSchedules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReloadSchedules.Name = "btnReloadSchedules";
            this.btnReloadSchedules.Size = new System.Drawing.Size(43, 23);
            this.btnReloadSchedules.TabIndex = 20;
            this.btnReloadSchedules.UseVisualStyleBackColor = true;
            // 
            // btnReloadProductName
            // 
            this.btnReloadProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReloadProductName.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReloadProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadProductName.Image = global::App.PVCFC_RFID.Properties.Resources.reload16x16;
            this.btnReloadProductName.Location = new System.Drawing.Point(327, 143);
            this.btnReloadProductName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReloadProductName.Name = "btnReloadProductName";
            this.btnReloadProductName.Size = new System.Drawing.Size(43, 23);
            this.btnReloadProductName.TabIndex = 21;
            this.btnReloadProductName.UseVisualStyleBackColor = true;
            // 
            // btnReloadAgent
            // 
            this.btnReloadAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReloadAgent.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReloadAgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadAgent.Image = global::App.PVCFC_RFID.Properties.Resources.reload16x16;
            this.btnReloadAgent.Location = new System.Drawing.Point(327, 219);
            this.btnReloadAgent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReloadAgent.Name = "btnReloadAgent";
            this.btnReloadAgent.Size = new System.Drawing.Size(43, 23);
            this.btnReloadAgent.TabIndex = 22;
            this.btnReloadAgent.UseVisualStyleBackColor = true;
            // 
            // listBoxProductName
            // 
            this.listBoxProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSyncSchedules.SetColumnSpan(this.listBoxProductName, 3);
            this.listBoxProductName.FormattingEnabled = true;
            this.listBoxProductName.ItemHeight = 16;
            this.listBoxProductName.Location = new System.Drawing.Point(3, 172);
            this.listBoxProductName.Name = "listBoxProductName";
            this.listBoxProductName.Size = new System.Drawing.Size(368, 4);
            this.listBoxProductName.TabIndex = 23;
            // 
            // listBoxAgentLevel1
            // 
            this.listBoxAgentLevel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSyncSchedules.SetColumnSpan(this.listBoxAgentLevel1, 3);
            this.listBoxAgentLevel1.FormattingEnabled = true;
            this.listBoxAgentLevel1.ItemHeight = 16;
            this.listBoxAgentLevel1.Location = new System.Drawing.Point(3, 248);
            this.listBoxAgentLevel1.Name = "listBoxAgentLevel1";
            this.listBoxAgentLevel1.Size = new System.Drawing.Size(368, 4);
            this.listBoxAgentLevel1.TabIndex = 24;
            // 
            // listBoxSchedules
            // 
            this.listBoxSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSyncSchedules.SetColumnSpan(this.listBoxSchedules, 3);
            this.listBoxSchedules.FormattingEnabled = true;
            this.listBoxSchedules.ItemHeight = 16;
            this.listBoxSchedules.Location = new System.Drawing.Point(3, 58);
            this.listBoxSchedules.Name = "listBoxSchedules";
            this.listBoxSchedules.Size = new System.Drawing.Size(368, 4);
            this.listBoxSchedules.TabIndex = 25;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.AutoSize = true;
            this.tblSyncSchedules.SetColumnSpan(this.btnPreview, 3);
            this.btnPreview.Location = new System.Drawing.Point(296, 79);
            this.btnPreview.MinimumSize = new System.Drawing.Size(0, 32);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 32);
            this.btnPreview.TabIndex = 26;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // tblControls
            // 
            this.tblControls.ColumnCount = 2;
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControls.Controls.Add(this.btnStart, 0, 0);
            this.tblControls.Controls.Add(this.btnSTOP, 1, 0);
            this.tblControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblControls.Location = new System.Drawing.Point(3, 610);
            this.tblControls.Name = "tblControls";
            this.tblControls.RowCount = 1;
            this.tblControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControls.Size = new System.Drawing.Size(380, 86);
            this.tblControls.TabIndex = 13;
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
            this.btnStart.Size = new System.Drawing.Size(187, 80);
            this.btnStart.TabIndex = 0;
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnSTOP
            // 
            this.btnSTOP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSTOP.Image = global::App.PVCFC_RFID.Properties.Resources.stop65x65;
            this.btnSTOP.Location = new System.Drawing.Point(193, 3);
            this.btnSTOP.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnSTOP.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(187, 80);
            this.btnSTOP.TabIndex = 3;
            this.btnSTOP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSTOP.UseVisualStyleBackColor = true;
            // 
            // tabControlSyncPageImport
            // 
            this.tabControlSyncPageImport.Location = new System.Drawing.Point(4, 25);
            this.tabControlSyncPageImport.Name = "tabControlSyncPageImport";
            this.tabControlSyncPageImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlSyncPageImport.Size = new System.Drawing.Size(386, 699);
            this.tabControlSyncPageImport.TabIndex = 1;
            this.tabControlSyncPageImport.Text = "Import";
            this.tabControlSyncPageImport.UseVisualStyleBackColor = true;
            // 
            // frmSyncDataWithServer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1281, 739);
            this.Controls.Add(this.tblMains);
            this.Font = new System.Drawing.Font("Arial", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSyncDataWithServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProductSyncWithServer";
            this.tblMains.ResumeLayout(false);
            this.tblMains.PerformLayout();
            this.grDataDetails.ResumeLayout(false);
            this.tblDataDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tblControlBtn.ResumeLayout(false);
            this.tblControlBtn.PerformLayout();
            this.tabControlSync.ResumeLayout(false);
            this.tabControlSyncPageExport.ResumeLayout(false);
            this.grSyncSchedules.ResumeLayout(false);
            this.tblSyncSchedules.ResumeLayout(false);
            this.tblSyncSchedules.PerformLayout();
            this.grSchedulesInfo.ResumeLayout(false);
            this.tblSchedulesInfo.ResumeLayout(false);
            this.tblSchedulesInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalExport)).EndInit();
            this.grNote.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tblControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMains;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tblControlBtn;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grDataDetails;
        private System.Windows.Forms.TableLayoutPanel tblDataDetails;
        private ucStationInfo ucStationInfo1;
        private System.Windows.Forms.TabControl tabControlSync;
        private System.Windows.Forms.TabPage tabControlSyncPageExport;
        private System.Windows.Forms.TabPage tabControlSyncPageImport;
        private System.Windows.Forms.GroupBox grSyncSchedules;
        private System.Windows.Forms.TableLayoutPanel tblSyncSchedules;
        private System.Windows.Forms.TextBox txtAgentSearch;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblSchedules;
        private System.Windows.Forms.TextBox txtSchedulesSearch;
        private System.Windows.Forms.TextBox txtProductNameSearch;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.GroupBox grSchedulesInfo;
        private System.Windows.Forms.TableLayoutPanel tblSchedulesInfo;
        private System.Windows.Forms.Label lblWarehouseReceiptCode;
        private System.Windows.Forms.Label lblDeliveryOrderCode;
        private System.Windows.Forms.Label lblLOTNo;
        private System.Windows.Forms.TextBox txtDeliveryOrderCode;
        private System.Windows.Forms.TextBox txtWarehouseReceiptCode;
        private System.Windows.Forms.TextBox txtLOTNo;
        private System.Windows.Forms.GroupBox grNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNoteAgent;
        private System.Windows.Forms.Label lblNoteAgentValues;
        private System.Windows.Forms.Label lblNoteProductName;
        private System.Windows.Forms.Label lblNoteProductNameValues;
        private System.Windows.Forms.Button btnSearchSchedules;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnReloadSchedules;
        private System.Windows.Forms.Button btnReloadProductName;
        private System.Windows.Forms.Button btnReloadAgent;
        private System.Windows.Forms.TableLayoutPanel tblControls;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.ListBox listBoxProductName;
        private System.Windows.Forms.ListBox listBoxAgentLevel1;
        private System.Windows.Forms.ListBox listBoxSchedules;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblTotalExport;
        private System.Windows.Forms.NumericUpDown numTotalExport;
        private System.Windows.Forms.Label lblDeliveryCode;
        private System.Windows.Forms.Label lblDeliveryCodeValues;
    }
}