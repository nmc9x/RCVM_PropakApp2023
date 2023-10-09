namespace ML.LoggingControls.View
{
    partial class frmViewLogs
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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblButtonControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrevious = new ML.Controls.MLButton();
            this.btnNext = new ML.Controls.MLButton();
            this.btnLast = new ML.Controls.MLButton();
            this.btnFirst = new ML.Controls.MLButton();
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.btnRefresh = new ML.Controls.MLButton();
            this.btnClearLog = new ML.Controls.MLButton();
            this.btnExport = new ML.Controls.MLButton();
            this.dgrHistory = new System.Windows.Forms.DataGridView();
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.tblFilter = new System.Windows.Forms.TableLayoutPanel();
            this.dateTo = new ML.Controls.MLDateTimePicker();
            this.dateFrom = new ML.Controls.MLDateTimePicker();
            this.tblFilterChk = new System.Windows.Forms.TableLayoutPanel();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.chkWarning = new System.Windows.Forms.CheckBox();
            this.chkInfo = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.chkStop = new System.Windows.Forms.CheckBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.tblButtonControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrHistory)).BeginInit();
            this.grbFilter.SuspendLayout();
            this.tblFilter.SuspendLayout();
            this.tblFilterChk.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tblButtonControls, 0, 2);
            this.tblMain.Controls.Add(this.dgrHistory, 0, 1);
            this.tblMain.Controls.Add(this.grbFilter, 0, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Font = new System.Drawing.Font("Arial", 10.25F);
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.Size = new System.Drawing.Size(897, 493);
            this.tblMain.TabIndex = 0;
            // 
            // tblButtonControls
            // 
            this.tblButtonControls.ColumnCount = 8;
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtonControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtonControls.Controls.Add(this.btnPrevious, 1, 0);
            this.tblButtonControls.Controls.Add(this.btnNext, 2, 0);
            this.tblButtonControls.Controls.Add(this.btnLast, 3, 0);
            this.tblButtonControls.Controls.Add(this.btnFirst, 0, 0);
            this.tblButtonControls.Controls.Add(this.lblRowsCount, 5, 0);
            this.tblButtonControls.Controls.Add(this.btnRefresh, 7, 1);
            this.tblButtonControls.Controls.Add(this.btnClearLog, 5, 1);
            this.tblButtonControls.Controls.Add(this.btnExport, 6, 1);
            this.tblButtonControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblButtonControls.Location = new System.Drawing.Point(3, 381);
            this.tblButtonControls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblButtonControls.Name = "tblButtonControls";
            this.tblButtonControls.RowCount = 3;
            this.tblButtonControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblButtonControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblButtonControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtonControls.Size = new System.Drawing.Size(891, 110);
            this.tblButtonControls.TabIndex = 23;
            // 
            // btnPrevious
            // 
            this.btnPrevious.AllowLoopEvents = false;
            this.btnPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrevious.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnPrevious.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnPrevious.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnPrevious.BorderSizeInNoneStyle = 0;
            this.btnPrevious.ButtonStyle = ML.Controls.ButtonStylesEnum.Default;
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrevious.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnPrevious.IsStandardButton = true;
            this.btnPrevious.Location = new System.Drawing.Point(84, 3);
            this.btnPrevious.MinimumSize = new System.Drawing.Size(0, 48);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 48);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.AllowLoopEvents = false;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnNext.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnNext.BorderSizeInNoneStyle = 0;
            this.btnNext.ButtonStyle = ML.Controls.ButtonStylesEnum.Default;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnNext.IsStandardButton = true;
            this.btnNext.Location = new System.Drawing.Point(165, 3);
            this.btnNext.MinimumSize = new System.Drawing.Size(0, 48);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 48);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            this.btnLast.AllowLoopEvents = false;
            this.btnLast.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLast.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnLast.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnLast.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnLast.BorderSizeInNoneStyle = 0;
            this.btnLast.ButtonStyle = ML.Controls.ButtonStylesEnum.Default;
            this.btnLast.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnLast.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.btnLast.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.btnLast.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLast.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnLast.IsStandardButton = true;
            this.btnLast.Location = new System.Drawing.Point(246, 3);
            this.btnLast.MinimumSize = new System.Drawing.Size(0, 48);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 48);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // btnFirst
            // 
            this.btnFirst.AllowLoopEvents = false;
            this.btnFirst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFirst.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnFirst.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnFirst.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnFirst.BorderSizeInNoneStyle = 0;
            this.btnFirst.ButtonStyle = ML.Controls.ButtonStylesEnum.Default;
            this.btnFirst.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnFirst.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.btnFirst.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.btnFirst.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFirst.ForeColorInInNoneStyle = System.Drawing.Color.Empty;
            this.btnFirst.IsStandardButton = true;
            this.btnFirst.Location = new System.Drawing.Point(3, 3);
            this.btnFirst.MinimumSize = new System.Drawing.Size(0, 48);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 48);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRowsCount.AutoSize = true;
            this.tblButtonControls.SetColumnSpan(this.lblRowsCount, 3);
            this.lblRowsCount.Location = new System.Drawing.Point(806, 19);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(82, 16);
            this.lblRowsCount.TabIndex = 6;
            this.lblRowsCount.Text = "[Row count]";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AllowLoopEvents = false;
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnRefresh.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnRefresh.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnRefresh.BorderSizeInNoneStyle = 0;
            this.btnRefresh.ButtonStyle = ML.Controls.ButtonStylesEnum.Success;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(174)))), ((int)(((byte)(76)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnRefresh.IsStandardButton = false;
            this.btnRefresh.Location = new System.Drawing.Point(788, 57);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(100, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 48);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.AllowLoopEvents = false;
            this.btnClearLog.AutoSize = true;
            this.btnClearLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnClearLog.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnClearLog.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnClearLog.BorderSizeInNoneStyle = 0;
            this.btnClearLog.ButtonStyle = ML.Controls.ButtonStylesEnum.Danger;
            this.btnClearLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(63)))), ((int)(((byte)(58)))));
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnClearLog.IsStandardButton = false;
            this.btnClearLog.Location = new System.Drawing.Point(576, 57);
            this.btnClearLog.MinimumSize = new System.Drawing.Size(100, 48);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(100, 48);
            this.btnClearLog.TabIndex = 7;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.AllowLoopEvents = false;
            this.btnExport.AutoSize = true;
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnExport.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnExport.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.btnExport.BorderSizeInNoneStyle = 0;
            this.btnExport.ButtonStyle = ML.Controls.ButtonStylesEnum.Primary;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(109)))), ((int)(((byte)(164)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnExport.IsStandardButton = false;
            this.btnExport.Location = new System.Drawing.Point(682, 57);
            this.btnExport.MinimumSize = new System.Drawing.Size(100, 48);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 48);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // dgrHistory
            // 
            this.dgrHistory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgrHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrHistory.Location = new System.Drawing.Point(2, 113);
            this.dgrHistory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgrHistory.Name = "dgrHistory";
            this.dgrHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrHistory.Size = new System.Drawing.Size(893, 263);
            this.dgrHistory.TabIndex = 22;
            // 
            // grbFilter
            // 
            this.grbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMain.SetColumnSpan(this.grbFilter, 4);
            this.grbFilter.Controls.Add(this.tblFilter);
            this.grbFilter.Location = new System.Drawing.Point(3, 3);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(891, 104);
            this.grbFilter.TabIndex = 21;
            this.grbFilter.TabStop = false;
            this.grbFilter.Text = "Filter";
            // 
            // tblFilter
            // 
            this.tblFilter.ColumnCount = 5;
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.Controls.Add(this.dateTo, 4, 1);
            this.tblFilter.Controls.Add(this.dateFrom, 2, 1);
            this.tblFilter.Controls.Add(this.tblFilterChk, 0, 0);
            this.tblFilter.Controls.Add(this.lblFrom, 1, 1);
            this.tblFilter.Controls.Add(this.lblTo, 3, 1);
            this.tblFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFilter.Location = new System.Drawing.Point(3, 19);
            this.tblFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblFilter.Name = "tblFilter";
            this.tblFilter.RowCount = 3;
            this.tblFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFilter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFilter.Size = new System.Drawing.Size(885, 82);
            this.tblFilter.TabIndex = 3;
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd/MM/yyyy";
            this.dateTo.DatetimeMask = "dd/MM/yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.IsShowCalendarButton = true;
            this.dateTo.Location = new System.Drawing.Point(682, 49);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 23);
            this.dateTo.TabIndex = 9;
            this.dateTo.TitleName = "";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yyyy";
            this.dateFrom.DatetimeMask = "dd/MM/yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.IsShowCalendarButton = true;
            this.dateFrom.Location = new System.Drawing.Point(454, 49);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(193, 23);
            this.dateFrom.TabIndex = 8;
            this.dateFrom.TitleName = "";
            // 
            // tblFilterChk
            // 
            this.tblFilterChk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblFilterChk.ColumnCount = 7;
            this.tblFilter.SetColumnSpan(this.tblFilterChk, 5);
            this.tblFilterChk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilterChk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilterChk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilterChk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilterChk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilterChk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilterChk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFilterChk.Controls.Add(this.chkError, 0, 0);
            this.tblFilterChk.Controls.Add(this.chkWarning, 1, 0);
            this.tblFilterChk.Controls.Add(this.chkInfo, 2, 0);
            this.tblFilterChk.Controls.Add(this.chkStart, 3, 0);
            this.tblFilterChk.Controls.Add(this.chkStop, 4, 0);
            this.tblFilterChk.Location = new System.Drawing.Point(3, 3);
            this.tblFilterChk.Name = "tblFilterChk";
            this.tblFilterChk.RowCount = 2;
            this.tblFilterChk.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFilterChk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFilterChk.Size = new System.Drawing.Size(879, 40);
            this.tblFilterChk.TabIndex = 10;
            // 
            // chkError
            // 
            this.chkError.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkError.AutoSize = true;
            this.chkError.FlatAppearance.BorderSize = 0;
            this.chkError.Image = global::ML.LoggingControls.Properties.Resources.error24x24;
            this.chkError.Location = new System.Drawing.Point(3, 3);
            this.chkError.MinimumSize = new System.Drawing.Size(100, 32);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(100, 32);
            this.chkError.TabIndex = 0;
            this.chkError.Text = "Error";
            this.chkError.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkError.UseVisualStyleBackColor = true;
            // 
            // chkWarning
            // 
            this.chkWarning.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkWarning.AutoSize = true;
            this.chkWarning.Image = global::ML.LoggingControls.Properties.Resources.waring24x24;
            this.chkWarning.Location = new System.Drawing.Point(109, 3);
            this.chkWarning.MinimumSize = new System.Drawing.Size(100, 32);
            this.chkWarning.Name = "chkWarning";
            this.chkWarning.Size = new System.Drawing.Size(100, 32);
            this.chkWarning.TabIndex = 1;
            this.chkWarning.Text = "Warning";
            this.chkWarning.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkWarning.UseVisualStyleBackColor = true;
            // 
            // chkInfo
            // 
            this.chkInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInfo.AutoSize = true;
            this.chkInfo.Image = global::ML.LoggingControls.Properties.Resources.info24x24;
            this.chkInfo.Location = new System.Drawing.Point(215, 3);
            this.chkInfo.MinimumSize = new System.Drawing.Size(100, 32);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.Size = new System.Drawing.Size(100, 32);
            this.chkInfo.TabIndex = 2;
            this.chkInfo.Text = "infor";
            this.chkInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkInfo.UseVisualStyleBackColor = true;
            // 
            // chkStart
            // 
            this.chkStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStart.AutoSize = true;
            this.chkStart.Image = global::ML.LoggingControls.Properties.Resources.start24x24;
            this.chkStart.Location = new System.Drawing.Point(321, 3);
            this.chkStart.MinimumSize = new System.Drawing.Size(100, 32);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(100, 32);
            this.chkStart.TabIndex = 3;
            this.chkStart.Text = "Start";
            this.chkStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkStart.UseVisualStyleBackColor = true;
            // 
            // chkStop
            // 
            this.chkStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStop.AutoSize = true;
            this.chkStop.Image = global::ML.LoggingControls.Properties.Resources.stop24x24;
            this.chkStop.Location = new System.Drawing.Point(427, 3);
            this.chkStop.MinimumSize = new System.Drawing.Size(100, 32);
            this.chkStop.Name = "chkStop";
            this.chkStop.Size = new System.Drawing.Size(100, 32);
            this.chkStop.TabIndex = 4;
            this.chkStop.Text = "Stop";
            this.chkStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkStop.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(407, 52);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 16);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(653, 52);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 16);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To";
            // 
            // frmViewLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 493);
            this.Controls.Add(this.tblMain);
            this.Name = "frmViewLogs";
            this.Text = "View logs";
            this.tblMain.ResumeLayout(false);
            this.tblButtonControls.ResumeLayout(false);
            this.tblButtonControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrHistory)).EndInit();
            this.grbFilter.ResumeLayout(false);
            this.tblFilter.ResumeLayout(false);
            this.tblFilter.PerformLayout();
            this.tblFilterChk.ResumeLayout(false);
            this.tblFilterChk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.GroupBox grbFilter;
        private System.Windows.Forms.TableLayoutPanel tblFilter;
        private System.Windows.Forms.Label lblTo;
        private Controls.MLDateTimePicker dateTo;
        private System.Windows.Forms.TableLayoutPanel tblButtonControls;
        private System.Windows.Forms.DataGridView dgrHistory;
        private Controls.MLButton btnFirst;
        private Controls.MLButton btnPrevious;
        private Controls.MLButton btnNext;
        private Controls.MLButton btnLast;
        private System.Windows.Forms.Label lblRowsCount;
        private Controls.MLDateTimePicker dateFrom;
        private System.Windows.Forms.TableLayoutPanel tblFilterChk;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.CheckBox chkWarning;
        private System.Windows.Forms.CheckBox chkInfo;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.CheckBox chkStop;
        private System.Windows.Forms.Label lblFrom;
        private Controls.MLButton btnRefresh;
        private Controls.MLButton btnClearLog;
        private Controls.MLButton btnExport;
    }
}

