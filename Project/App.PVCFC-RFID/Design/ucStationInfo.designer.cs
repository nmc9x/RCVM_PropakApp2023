namespace App.PVCFC_RFID.Design
{
    partial class ucStationInfo
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
            this.gStationStatus = new System.Windows.Forms.GroupBox();
            this.tblHomeStatusMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblMainStatus = new System.Windows.Forms.TableLayoutPanel();
            this.mbtnStatus = new ML.Controls.MLButton();
            this.tblMainActiveFailed = new System.Windows.Forms.TableLayoutPanel();
            this.tblActiveFailed = new System.Windows.Forms.TableLayoutPanel();
            this.lblActiveFailed = new System.Windows.Forms.Label();
            this.lblActiveFailedValues = new System.Windows.Forms.Label();
            this.btnActiveFailedDetails = new System.Windows.Forms.Button();
            this.tblMainCheckFailed = new System.Windows.Forms.TableLayoutPanel();
            this.tblCheckFailed = new System.Windows.Forms.TableLayoutPanel();
            this.lblCheckFailed = new System.Windows.Forms.Label();
            this.btnCheckFailedDetails = new System.Windows.Forms.Button();
            this.lblCheckFailedValues = new System.Windows.Forms.Label();
            this.tblMainExportTotal = new System.Windows.Forms.TableLayoutPanel();
            this.tblExportTotal = new System.Windows.Forms.TableLayoutPanel();
            this.lblExportTotalValues = new System.Windows.Forms.Label();
            this.lblExportTotal = new System.Windows.Forms.Label();
            this.tblMainCheckSuccess = new System.Windows.Forms.TableLayoutPanel();
            this.tblCheckSuccess = new System.Windows.Forms.TableLayoutPanel();
            this.lblCheckSuccessValues = new System.Windows.Forms.Label();
            this.btnCheckSuccessDetails = new System.Windows.Forms.Button();
            this.lblCheckSuccess = new System.Windows.Forms.Label();
            this.tblMainActiveSuccess = new System.Windows.Forms.TableLayoutPanel();
            this.tblActiveSuccess = new System.Windows.Forms.TableLayoutPanel();
            this.lblActiveSuccess = new System.Windows.Forms.Label();
            this.lblActiveSuccessValues = new System.Windows.Forms.Label();
            this.btnActiveSuccessDetails = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gStationStatus.SuspendLayout();
            this.tblHomeStatusMain.SuspendLayout();
            this.tblMainStatus.SuspendLayout();
            this.tblMainActiveFailed.SuspendLayout();
            this.tblActiveFailed.SuspendLayout();
            this.tblMainCheckFailed.SuspendLayout();
            this.tblCheckFailed.SuspendLayout();
            this.tblMainExportTotal.SuspendLayout();
            this.tblExportTotal.SuspendLayout();
            this.tblMainCheckSuccess.SuspendLayout();
            this.tblCheckSuccess.SuspendLayout();
            this.tblMainActiveSuccess.SuspendLayout();
            this.tblActiveSuccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // gStationStatus
            // 
            this.gStationStatus.Controls.Add(this.tblHomeStatusMain);
            this.gStationStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gStationStatus.Location = new System.Drawing.Point(0, 0);
            this.gStationStatus.Name = "gStationStatus";
            this.gStationStatus.Padding = new System.Windows.Forms.Padding(2, 0, 2, 3);
            this.gStationStatus.Size = new System.Drawing.Size(857, 219);
            this.gStationStatus.TabIndex = 1;
            this.gStationStatus.TabStop = false;
            this.gStationStatus.Text = "Status";
            // 
            // tblHomeStatusMain
            // 
            this.tblHomeStatusMain.ColumnCount = 6;
            this.tblHomeStatusMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblHomeStatusMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblHomeStatusMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblHomeStatusMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblHomeStatusMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblHomeStatusMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblHomeStatusMain.Controls.Add(this.tblMainStatus, 0, 0);
            this.tblHomeStatusMain.Controls.Add(this.tblMainActiveFailed, 5, 0);
            this.tblHomeStatusMain.Controls.Add(this.tblMainCheckFailed, 2, 0);
            this.tblHomeStatusMain.Controls.Add(this.tblMainExportTotal, 3, 0);
            this.tblHomeStatusMain.Controls.Add(this.tblMainCheckSuccess, 1, 0);
            this.tblHomeStatusMain.Controls.Add(this.tblMainActiveSuccess, 4, 0);
            this.tblHomeStatusMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblHomeStatusMain.Location = new System.Drawing.Point(2, 16);
            this.tblHomeStatusMain.Margin = new System.Windows.Forms.Padding(0);
            this.tblHomeStatusMain.Name = "tblHomeStatusMain";
            this.tblHomeStatusMain.RowCount = 1;
            this.tblHomeStatusMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHomeStatusMain.Size = new System.Drawing.Size(853, 200);
            this.tblHomeStatusMain.TabIndex = 0;
            // 
            // tblMainStatus
            // 
            this.tblMainStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tblMainStatus.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMainStatus.ColumnCount = 1;
            this.tblMainStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainStatus.Controls.Add(this.mbtnStatus, 0, 0);
            this.tblMainStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainStatus.Location = new System.Drawing.Point(3, 3);
            this.tblMainStatus.Name = "tblMainStatus";
            this.tblMainStatus.RowCount = 1;
            this.tblMainStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainStatus.Size = new System.Drawing.Size(136, 194);
            this.tblMainStatus.TabIndex = 15;
            // 
            // mbtnStatus
            // 
            this.mbtnStatus.AllowLoopEvents = false;
            this.mbtnStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtnStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.mbtnStatus.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.mbtnStatus.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.mbtnStatus.BorderSizeInNoneStyle = 0;
            this.mbtnStatus.ButtonStyle = ML.Controls.ButtonStylesEnum.Danger;
            this.mbtnStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbtnStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(63)))), ((int)(((byte)(58)))));
            this.mbtnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbtnStatus.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.mbtnStatus.ForeColor = System.Drawing.Color.White;
            this.mbtnStatus.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.mbtnStatus.IsStandardButton = false;
            this.mbtnStatus.Location = new System.Drawing.Point(4, 4);
            this.mbtnStatus.MinimumSize = new System.Drawing.Size(0, 32);
            this.mbtnStatus.Name = "mbtnStatus";
            this.mbtnStatus.Size = new System.Drawing.Size(128, 186);
            this.mbtnStatus.TabIndex = 2;
            this.mbtnStatus.Text = "STOP";
            this.mbtnStatus.UseVisualStyleBackColor = false;
            // 
            // tblMainActiveFailed
            // 
            this.tblMainActiveFailed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tblMainActiveFailed.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMainActiveFailed.ColumnCount = 1;
            this.tblMainActiveFailed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainActiveFailed.Controls.Add(this.tblActiveFailed, 0, 0);
            this.tblMainActiveFailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainActiveFailed.Location = new System.Drawing.Point(713, 3);
            this.tblMainActiveFailed.Name = "tblMainActiveFailed";
            this.tblMainActiveFailed.RowCount = 1;
            this.tblMainActiveFailed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainActiveFailed.Size = new System.Drawing.Size(137, 194);
            this.tblMainActiveFailed.TabIndex = 12;
            // 
            // tblActiveFailed
            // 
            this.tblActiveFailed.ColumnCount = 1;
            this.tblActiveFailed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActiveFailed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblActiveFailed.Controls.Add(this.lblActiveFailed, 0, 0);
            this.tblActiveFailed.Controls.Add(this.lblActiveFailedValues, 0, 1);
            this.tblActiveFailed.Controls.Add(this.btnActiveFailedDetails, 0, 2);
            this.tblActiveFailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblActiveFailed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblActiveFailed.Location = new System.Drawing.Point(4, 4);
            this.tblActiveFailed.Name = "tblActiveFailed";
            this.tblActiveFailed.RowCount = 3;
            this.tblActiveFailed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblActiveFailed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActiveFailed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblActiveFailed.Size = new System.Drawing.Size(129, 186);
            this.tblActiveFailed.TabIndex = 7;
            // 
            // lblActiveFailed
            // 
            this.lblActiveFailed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveFailed.AutoEllipsis = true;
            this.lblActiveFailed.Location = new System.Drawing.Point(0, 4);
            this.lblActiveFailed.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblActiveFailed.Name = "lblActiveFailed";
            this.lblActiveFailed.Size = new System.Drawing.Size(129, 16);
            this.lblActiveFailed.TabIndex = 1;
            this.lblActiveFailed.Text = "Active failed";
            this.lblActiveFailed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblActiveFailedValues
            // 
            this.lblActiveFailedValues.AutoEllipsis = true;
            this.lblActiveFailedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActiveFailedValues.Font = new System.Drawing.Font("Arial", 40.25F, System.Drawing.FontStyle.Bold);
            this.lblActiveFailedValues.ForeColor = System.Drawing.Color.Red;
            this.lblActiveFailedValues.Location = new System.Drawing.Point(0, 24);
            this.lblActiveFailedValues.Margin = new System.Windows.Forms.Padding(0);
            this.lblActiveFailedValues.Name = "lblActiveFailedValues";
            this.lblActiveFailedValues.Size = new System.Drawing.Size(129, 135);
            this.lblActiveFailedValues.TabIndex = 5;
            this.lblActiveFailedValues.Text = "90000";
            this.lblActiveFailedValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActiveFailedDetails
            // 
            this.btnActiveFailedDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveFailedDetails.AutoSize = true;
            this.btnActiveFailedDetails.Font = new System.Drawing.Font("Arial", 9.25F);
            this.btnActiveFailedDetails.Location = new System.Drawing.Point(71, 162);
            this.btnActiveFailedDetails.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.btnActiveFailedDetails.MaximumSize = new System.Drawing.Size(0, 24);
            this.btnActiveFailedDetails.Name = "btnActiveFailedDetails";
            this.btnActiveFailedDetails.Size = new System.Drawing.Size(58, 24);
            this.btnActiveFailedDetails.TabIndex = 1;
            this.btnActiveFailedDetails.Text = "Details";
            this.btnActiveFailedDetails.UseVisualStyleBackColor = true;
            // 
            // tblMainCheckFailed
            // 
            this.tblMainCheckFailed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tblMainCheckFailed.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMainCheckFailed.ColumnCount = 1;
            this.tblMainCheckFailed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainCheckFailed.Controls.Add(this.tblCheckFailed, 0, 0);
            this.tblMainCheckFailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainCheckFailed.Location = new System.Drawing.Point(287, 3);
            this.tblMainCheckFailed.Name = "tblMainCheckFailed";
            this.tblMainCheckFailed.RowCount = 1;
            this.tblMainCheckFailed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainCheckFailed.Size = new System.Drawing.Size(136, 194);
            this.tblMainCheckFailed.TabIndex = 10;
            // 
            // tblCheckFailed
            // 
            this.tblCheckFailed.ColumnCount = 1;
            this.tblCheckFailed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCheckFailed.Controls.Add(this.lblCheckFailed, 0, 0);
            this.tblCheckFailed.Controls.Add(this.btnCheckFailedDetails, 0, 2);
            this.tblCheckFailed.Controls.Add(this.lblCheckFailedValues, 0, 1);
            this.tblCheckFailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCheckFailed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblCheckFailed.Location = new System.Drawing.Point(4, 4);
            this.tblCheckFailed.Name = "tblCheckFailed";
            this.tblCheckFailed.RowCount = 3;
            this.tblCheckFailed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckFailed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCheckFailed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckFailed.Size = new System.Drawing.Size(128, 186);
            this.tblCheckFailed.TabIndex = 3;
            // 
            // lblCheckFailed
            // 
            this.lblCheckFailed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckFailed.AutoEllipsis = true;
            this.lblCheckFailed.Location = new System.Drawing.Point(0, 4);
            this.lblCheckFailed.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCheckFailed.Name = "lblCheckFailed";
            this.lblCheckFailed.Size = new System.Drawing.Size(128, 16);
            this.lblCheckFailed.TabIndex = 1;
            this.lblCheckFailed.Text = "Check failed";
            this.lblCheckFailed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCheckFailedDetails
            // 
            this.btnCheckFailedDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckFailedDetails.AutoSize = true;
            this.btnCheckFailedDetails.Font = new System.Drawing.Font("Arial", 9.25F);
            this.btnCheckFailedDetails.Location = new System.Drawing.Point(70, 162);
            this.btnCheckFailedDetails.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.btnCheckFailedDetails.MaximumSize = new System.Drawing.Size(0, 24);
            this.btnCheckFailedDetails.Name = "btnCheckFailedDetails";
            this.btnCheckFailedDetails.Size = new System.Drawing.Size(58, 24);
            this.btnCheckFailedDetails.TabIndex = 1;
            this.btnCheckFailedDetails.Text = "Details";
            this.btnCheckFailedDetails.UseVisualStyleBackColor = true;
            // 
            // lblCheckFailedValues
            // 
            this.lblCheckFailedValues.AutoEllipsis = true;
            this.lblCheckFailedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckFailedValues.Font = new System.Drawing.Font("Arial", 40.25F, System.Drawing.FontStyle.Bold);
            this.lblCheckFailedValues.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCheckFailedValues.Location = new System.Drawing.Point(0, 24);
            this.lblCheckFailedValues.Margin = new System.Windows.Forms.Padding(0);
            this.lblCheckFailedValues.Name = "lblCheckFailedValues";
            this.lblCheckFailedValues.Size = new System.Drawing.Size(128, 135);
            this.lblCheckFailedValues.TabIndex = 2;
            this.lblCheckFailedValues.Text = "90000";
            this.lblCheckFailedValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblMainExportTotal
            // 
            this.tblMainExportTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tblMainExportTotal.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMainExportTotal.ColumnCount = 1;
            this.tblMainExportTotal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainExportTotal.Controls.Add(this.tblExportTotal, 0, 0);
            this.tblMainExportTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainExportTotal.Location = new System.Drawing.Point(429, 3);
            this.tblMainExportTotal.Name = "tblMainExportTotal";
            this.tblMainExportTotal.RowCount = 1;
            this.tblMainExportTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainExportTotal.Size = new System.Drawing.Size(136, 194);
            this.tblMainExportTotal.TabIndex = 7;
            // 
            // tblExportTotal
            // 
            this.tblExportTotal.ColumnCount = 1;
            this.tblExportTotal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblExportTotal.Controls.Add(this.lblExportTotalValues, 0, 1);
            this.tblExportTotal.Controls.Add(this.lblExportTotal, 0, 0);
            this.tblExportTotal.Controls.Add(this.lblTotal, 0, 3);
            this.tblExportTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblExportTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblExportTotal.Location = new System.Drawing.Point(4, 4);
            this.tblExportTotal.Name = "tblExportTotal";
            this.tblExportTotal.RowCount = 4;
            this.tblExportTotal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblExportTotal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportTotal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblExportTotal.Size = new System.Drawing.Size(128, 186);
            this.tblExportTotal.TabIndex = 5;
            // 
            // lblExportTotalValues
            // 
            this.lblExportTotalValues.AutoEllipsis = true;
            this.lblExportTotalValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExportTotalValues.Font = new System.Drawing.Font("Arial", 40.25F, System.Drawing.FontStyle.Bold);
            this.lblExportTotalValues.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblExportTotalValues.Location = new System.Drawing.Point(0, 24);
            this.lblExportTotalValues.Margin = new System.Windows.Forms.Padding(0);
            this.lblExportTotalValues.Name = "lblExportTotalValues";
            this.lblExportTotalValues.Size = new System.Drawing.Size(128, 138);
            this.lblExportTotalValues.TabIndex = 3;
            this.lblExportTotalValues.Text = "90000";
            this.lblExportTotalValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExportTotal
            // 
            this.lblExportTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExportTotal.AutoEllipsis = true;
            this.lblExportTotal.Location = new System.Drawing.Point(0, 4);
            this.lblExportTotal.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblExportTotal.Name = "lblExportTotal";
            this.lblExportTotal.Size = new System.Drawing.Size(128, 16);
            this.lblExportTotal.TabIndex = 1;
            this.lblExportTotal.Text = "Total export";
            this.lblExportTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblMainCheckSuccess
            // 
            this.tblMainCheckSuccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tblMainCheckSuccess.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMainCheckSuccess.ColumnCount = 1;
            this.tblMainCheckSuccess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainCheckSuccess.Controls.Add(this.tblCheckSuccess, 0, 0);
            this.tblMainCheckSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainCheckSuccess.Location = new System.Drawing.Point(145, 3);
            this.tblMainCheckSuccess.Name = "tblMainCheckSuccess";
            this.tblMainCheckSuccess.RowCount = 1;
            this.tblMainCheckSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainCheckSuccess.Size = new System.Drawing.Size(136, 194);
            this.tblMainCheckSuccess.TabIndex = 8;
            // 
            // tblCheckSuccess
            // 
            this.tblCheckSuccess.ColumnCount = 1;
            this.tblCheckSuccess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCheckSuccess.Controls.Add(this.lblCheckSuccessValues, 0, 1);
            this.tblCheckSuccess.Controls.Add(this.btnCheckSuccessDetails, 0, 2);
            this.tblCheckSuccess.Controls.Add(this.lblCheckSuccess, 0, 0);
            this.tblCheckSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCheckSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblCheckSuccess.Location = new System.Drawing.Point(4, 4);
            this.tblCheckSuccess.Name = "tblCheckSuccess";
            this.tblCheckSuccess.RowCount = 3;
            this.tblCheckSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCheckSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCheckSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCheckSuccess.Size = new System.Drawing.Size(128, 186);
            this.tblCheckSuccess.TabIndex = 3;
            // 
            // lblCheckSuccessValues
            // 
            this.lblCheckSuccessValues.AutoEllipsis = true;
            this.lblCheckSuccessValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckSuccessValues.Font = new System.Drawing.Font("Arial", 40.25F, System.Drawing.FontStyle.Bold);
            this.lblCheckSuccessValues.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCheckSuccessValues.Location = new System.Drawing.Point(0, 24);
            this.lblCheckSuccessValues.Margin = new System.Windows.Forms.Padding(0);
            this.lblCheckSuccessValues.Name = "lblCheckSuccessValues";
            this.lblCheckSuccessValues.Size = new System.Drawing.Size(128, 135);
            this.lblCheckSuccessValues.TabIndex = 3;
            this.lblCheckSuccessValues.Text = "90000";
            this.lblCheckSuccessValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheckSuccessDetails
            // 
            this.btnCheckSuccessDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckSuccessDetails.AutoSize = true;
            this.btnCheckSuccessDetails.Font = new System.Drawing.Font("Arial", 9.25F);
            this.btnCheckSuccessDetails.Location = new System.Drawing.Point(70, 162);
            this.btnCheckSuccessDetails.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.btnCheckSuccessDetails.MaximumSize = new System.Drawing.Size(0, 24);
            this.btnCheckSuccessDetails.Name = "btnCheckSuccessDetails";
            this.btnCheckSuccessDetails.Size = new System.Drawing.Size(58, 24);
            this.btnCheckSuccessDetails.TabIndex = 1;
            this.btnCheckSuccessDetails.Text = "Details";
            this.btnCheckSuccessDetails.UseVisualStyleBackColor = true;
            // 
            // lblCheckSuccess
            // 
            this.lblCheckSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckSuccess.AutoEllipsis = true;
            this.lblCheckSuccess.Location = new System.Drawing.Point(0, 4);
            this.lblCheckSuccess.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCheckSuccess.Name = "lblCheckSuccess";
            this.lblCheckSuccess.Size = new System.Drawing.Size(128, 16);
            this.lblCheckSuccess.TabIndex = 0;
            this.lblCheckSuccess.Text = "Check success";
            this.lblCheckSuccess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblMainActiveSuccess
            // 
            this.tblMainActiveSuccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tblMainActiveSuccess.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMainActiveSuccess.ColumnCount = 1;
            this.tblMainActiveSuccess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainActiveSuccess.Controls.Add(this.tblActiveSuccess, 0, 0);
            this.tblMainActiveSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainActiveSuccess.Location = new System.Drawing.Point(571, 3);
            this.tblMainActiveSuccess.Name = "tblMainActiveSuccess";
            this.tblMainActiveSuccess.RowCount = 1;
            this.tblMainActiveSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainActiveSuccess.Size = new System.Drawing.Size(136, 194);
            this.tblMainActiveSuccess.TabIndex = 9;
            // 
            // tblActiveSuccess
            // 
            this.tblActiveSuccess.ColumnCount = 1;
            this.tblActiveSuccess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActiveSuccess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblActiveSuccess.Controls.Add(this.lblActiveSuccess, 0, 0);
            this.tblActiveSuccess.Controls.Add(this.lblActiveSuccessValues, 0, 1);
            this.tblActiveSuccess.Controls.Add(this.btnActiveSuccessDetails, 0, 2);
            this.tblActiveSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblActiveSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblActiveSuccess.Location = new System.Drawing.Point(4, 4);
            this.tblActiveSuccess.Name = "tblActiveSuccess";
            this.tblActiveSuccess.RowCount = 3;
            this.tblActiveSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblActiveSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActiveSuccess.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblActiveSuccess.Size = new System.Drawing.Size(128, 186);
            this.tblActiveSuccess.TabIndex = 7;
            // 
            // lblActiveSuccess
            // 
            this.lblActiveSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveSuccess.AutoEllipsis = true;
            this.lblActiveSuccess.Location = new System.Drawing.Point(0, 4);
            this.lblActiveSuccess.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblActiveSuccess.Name = "lblActiveSuccess";
            this.lblActiveSuccess.Size = new System.Drawing.Size(128, 16);
            this.lblActiveSuccess.TabIndex = 1;
            this.lblActiveSuccess.Text = "Active success";
            this.lblActiveSuccess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblActiveSuccessValues
            // 
            this.lblActiveSuccessValues.AutoEllipsis = true;
            this.lblActiveSuccessValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActiveSuccessValues.Font = new System.Drawing.Font("Arial", 40.25F, System.Drawing.FontStyle.Bold);
            this.lblActiveSuccessValues.ForeColor = System.Drawing.Color.Green;
            this.lblActiveSuccessValues.Location = new System.Drawing.Point(0, 24);
            this.lblActiveSuccessValues.Margin = new System.Windows.Forms.Padding(0);
            this.lblActiveSuccessValues.Name = "lblActiveSuccessValues";
            this.lblActiveSuccessValues.Size = new System.Drawing.Size(128, 135);
            this.lblActiveSuccessValues.TabIndex = 4;
            this.lblActiveSuccessValues.Text = "90000";
            this.lblActiveSuccessValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActiveSuccessDetails
            // 
            this.btnActiveSuccessDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveSuccessDetails.AutoSize = true;
            this.btnActiveSuccessDetails.Font = new System.Drawing.Font("Arial", 9.25F);
            this.btnActiveSuccessDetails.Location = new System.Drawing.Point(70, 162);
            this.btnActiveSuccessDetails.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.btnActiveSuccessDetails.MaximumSize = new System.Drawing.Size(0, 24);
            this.btnActiveSuccessDetails.Name = "btnActiveSuccessDetails";
            this.btnActiveSuccessDetails.Size = new System.Drawing.Size(58, 24);
            this.btnActiveSuccessDetails.TabIndex = 1;
            this.btnActiveSuccessDetails.Text = "Details";
            this.btnActiveSuccessDetails.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Location = new System.Drawing.Point(3, 162);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(122, 24);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "[Total]";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucStationInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gStationStatus);
            this.Font = new System.Drawing.Font("Arial", 10.25F);
            this.Name = "ucStationInfo";
            this.Size = new System.Drawing.Size(857, 219);
            this.gStationStatus.ResumeLayout(false);
            this.tblHomeStatusMain.ResumeLayout(false);
            this.tblMainStatus.ResumeLayout(false);
            this.tblMainActiveFailed.ResumeLayout(false);
            this.tblActiveFailed.ResumeLayout(false);
            this.tblActiveFailed.PerformLayout();
            this.tblMainCheckFailed.ResumeLayout(false);
            this.tblCheckFailed.ResumeLayout(false);
            this.tblCheckFailed.PerformLayout();
            this.tblMainExportTotal.ResumeLayout(false);
            this.tblExportTotal.ResumeLayout(false);
            this.tblMainCheckSuccess.ResumeLayout(false);
            this.tblCheckSuccess.ResumeLayout(false);
            this.tblCheckSuccess.PerformLayout();
            this.tblMainActiveSuccess.ResumeLayout(false);
            this.tblActiveSuccess.ResumeLayout(false);
            this.tblActiveSuccess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gStationStatus;
        private System.Windows.Forms.TableLayoutPanel tblHomeStatusMain;
        private System.Windows.Forms.TableLayoutPanel tblMainCheckFailed;
        private System.Windows.Forms.TableLayoutPanel tblCheckFailed;
        private System.Windows.Forms.Label lblCheckFailed;
        private System.Windows.Forms.Button btnCheckFailedDetails;
        private System.Windows.Forms.Label lblCheckFailedValues;
        private System.Windows.Forms.TableLayoutPanel tblMainExportTotal;
        private System.Windows.Forms.TableLayoutPanel tblExportTotal;
        private System.Windows.Forms.Label lblExportTotalValues;
        private System.Windows.Forms.Label lblExportTotal;
        private System.Windows.Forms.TableLayoutPanel tblMainCheckSuccess;
        private System.Windows.Forms.TableLayoutPanel tblCheckSuccess;
        private System.Windows.Forms.Label lblCheckSuccessValues;
        private System.Windows.Forms.Button btnCheckSuccessDetails;
        private System.Windows.Forms.Label lblCheckSuccess;
        private System.Windows.Forms.TableLayoutPanel tblMainActiveSuccess;
        private System.Windows.Forms.TableLayoutPanel tblActiveSuccess;
        private System.Windows.Forms.Label lblActiveSuccess;
        private System.Windows.Forms.Label lblActiveSuccessValues;
        private System.Windows.Forms.Button btnActiveSuccessDetails;
        private System.Windows.Forms.TableLayoutPanel tblMainActiveFailed;
        private System.Windows.Forms.TableLayoutPanel tblActiveFailed;
        private System.Windows.Forms.Label lblActiveFailed;
        private System.Windows.Forms.Label lblActiveFailedValues;
        private System.Windows.Forms.Button btnActiveFailedDetails;
        private System.Windows.Forms.TableLayoutPanel tblMainStatus;
        private ML.Controls.MLButton mbtnStatus;
        private System.Windows.Forms.Label lblTotal;
    }
}
