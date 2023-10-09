using ML.Controls;
using ML.LoggingControls.Controller;
using ML.LoggingControls.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ML.LoggingControls.View
{
    /// <summary>
    /// Authour: Linh.Tran
    /// </summary>
    public partial class frmViewLogs : Form
    {
        #region Properties
        //private string _LogedInUsername = "Administrator";
        private string _LogedInUsername = "";
        public string LogedInUsername
        {
            get { return _LogedInUsername; }
            set { _LogedInUsername = value; }
        }

        private bool _IsExc = false;
        private int _SelectRow = -1;
        
        //End Translate
        private List<LoggingModel> _ListHistory = new List<LoggingModel>();
        private Point _MouseDownLocation;
        private bool _MouseDown = false;
        private bool _OnlyUSB = false;
        private bool _IsAdministrator = false;
        private List<string> _Command = null;
        private FileSystemWatcher _WatcherTemplateFile = null;//Linh.Tran_210524
        #endregion Properties

        public frmViewLogs(bool isAdministrator)
        {
            if (!LoggingController.AllowAccess)
            {
                return;
            }
            _IsAdministrator = isAdministrator;
            InitializeComponent();
            //
            InitLayout();
            SetLanguage();
            InitControls();
            InitEvents();
            LogsViewFileWatcher();
        }

        public frmViewLogs(String key, string logedUserName, bool onlyUSB = false, List<string> command = null)
        {
            _LogedInUsername = logedUserName;
            InitializeComponent();
            _OnlyUSB = onlyUSB;
            _Command = command;
            //
            InitLayout();
            SetLanguage();
            if (LoggingController.LoginToAccess(key))
            {
                InitControls();
                InitEvents();
            }
            LogsViewFileWatcher();
            //
        }

        #region Inits
        private void InitLayout()
        {
            LoggingController.UpdateIcon(this);
        }
        private void InitControls()
        {
            chkError.Checked = true;
            chkInfo.Checked = true;
            chkWarning.Checked = true;
            chkStart.Checked = true;
            chkStop.Checked = true;
            dgrHistory.ReadOnly = true;
            //
            if (_LogedInUsername == "Administrator")
            {
                btnClearLog.Visible = true;
            }
            else
            {
                btnClearLog.Visible = false;
            }

        }
        private void InitEvents()
        {
            this.Load += frmViewLogsNew_Load;
            this.FormClosed += frmViewLogsNew_FormClosed;//Linh.Tran_210524
            //
            chkError.CheckedChanged += AdjustData;
            chkInfo.CheckedChanged += AdjustData;
            chkWarning.CheckedChanged += AdjustData;
            chkStart.CheckedChanged += AdjustData;
            chkStop.CheckedChanged += AdjustData;

            dateFrom.CloseUp += AdjustData;//Linh.Tran_210524//dateFrom.ValueChanged += AdjustData;
            dateTo.CloseUp += AdjustData;//Linh.Tran_210524//dateTo.ValueChanged += AdjustData;

            btnRefresh.Click += AdjustData;
            btnClearLog.Click += ButtonClicked;
            //
            btnFirst.Click += BtnGoto_Click;
            btnPrevious.Click += BtnGoto_Click;
            btnNext.Click += BtnGoto_Click;
            btnLast.Click += BtnGoto_Click;
            //
            dgrHistory.RowPostPaint += dgrHistory_RowPostPaint;
            dgrHistory.CellFormatting += new DataGridViewCellFormattingEventHandler(dgrHistory_CellFormatting);
            dgrHistory.CellDoubleClick += dgrHistory_CellDoubleClick;
            dgrHistory.SelectionChanged += dgrHistory_SelectionChanged;
            //
            //Linh.Tran_220509: Cannot allow move form
            /*
            lblTitle.MouseDown += lblTitle_MouseDown;
            lblTitle.MouseMove += lblTitle_MouseMove;
            lblTitle.MouseUp += lblTitle_MouseUp;
             * */
            //End Linh.Tran_220509: Cannot allow move form
        }
        #endregion//End Inits

        #region Events
        private void frmViewLogsNew_Load(object sender, EventArgs e)
        {
            //Load default data
            AdjustData(null, EventArgs.Empty);//btnRefresh.PerformClick();//Linh.Tran_210524
        }

        private void frmViewLogsNew_FormClosed(object sender, EventArgs e)
        {
            LoggingController.LogedInUsername = "";
            _ListHistory = null;
            // Begin watching.
            if (_WatcherTemplateFile != null)
            {
                _WatcherTemplateFile.EnableRaisingEvents = false;
                // Add event handlers.
                _WatcherTemplateFile.Changed -= new FileSystemEventHandler(LogsFilesOnChanged);
                _WatcherTemplateFile.Created -= new FileSystemEventHandler(LogsFilesOnChanged);
                _WatcherTemplateFile.Deleted -= new FileSystemEventHandler(LogsFilesOnChanged);
                //_WatcherTemplateFile.Renamed += new RenamedEventHandler(OnRenamed);
            }
        }

        private void AdjustData(object sender, EventArgs e)
        {
            if (!_IsExc)//Linh.Tran_210524: _IsExc set in LoadData
            {
                List<LoggingType> searchTypes = new List<LoggingType>();
                if (chkError.Checked)
                {
                    searchTypes.Add(LoggingType.Error);
                }
                if (chkInfo.Checked)
                {
                    searchTypes.Add(LoggingType.Info);
                }
                if (chkWarning.Checked)
                {
                    searchTypes.Add(LoggingType.Warning);
                }
                if (chkStart.Checked)
                {
                    searchTypes.Add(LoggingType.Started);
                }
                if (chkStop.Checked)
                {
                    searchTypes.Add(LoggingType.Stoped);
                }
                DateTime dateFromValue = dateFrom.Value;
                DateTime dateToValue = dateTo.Value;
                LoadData(searchTypes, dateFromValue, dateToValue);
            }
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    if (sender == btnExport)
                    {
                        ExportData(_OnlyUSB);
                    }
                    else if (sender == btnClearLog)
                    {
                        if (MessageBox.Show(ML.Languages.Languages.MsgDoYouWantToContinue, ML.Languages.Languages.ClearLogs, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            ClearData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }
        private void BtnGoto_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    switch ((sender as Button).Name)
                    {
                        case "btnFirst":
                            _SelectRow = 0;
                            break;
                        case "btnPrevious":
                            if (dgrHistory.SelectedRows.Count > 0)
                            {
                                _SelectRow = dgrHistory.SelectedRows[0].Index - 1;
                            }
                            break;
                        case "btnNext":
                            if (dgrHistory.SelectedRows.Count > 0)
                            {
                                _SelectRow = dgrHistory.SelectedRows[0].Index + 1;
                            }
                            break;
                        case "btnLast":
                            _SelectRow = dgrHistory.Rows.Count - 1;
                            break;
                    }
                    if (_SelectRow < 0 || _SelectRow >= dgrHistory.Rows.Count)
                    {
                        _SelectRow = 0;
                    }
                    dgrHistory.ClearSelection();
                    dgrHistory.Rows[_SelectRow].Selected = true;
                    dgrHistory.FirstDisplayedScrollingRowIndex = dgrHistory.SelectedRows[0].Index;
                }
                catch (Exception ex)
                { }
                finally
                { _IsExc = false; }
            }
        }
        /// <summary>
        /// Draw number of rows of datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrHistory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgrHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex >= _ListHistory.Count)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                switch (_ListHistory[e.RowIndex].LogType)
                {
                    case LoggingType.Error:
                        e.Value = Properties.Resources.error16x16;
                        break;
                    case LoggingType.Info:
                    default:
                        e.Value = Properties.Resources.infor16x16;
                        break;
                    //case LoggingType.LogedIn:
                    //    e.Value = Properties.Resources.Enter16;
                    //    break;
                    //case LoggingType.LogedOut:
                    //    e.Value = Properties.Resources.Exit16;
                    //    break;
                    case LoggingType.Started:
                        e.Value = Properties.Resources.start16x16;
                        break;
                    case LoggingType.Stoped:
                        e.Value = Properties.Resources.stop16x16;
                        break;
                    case LoggingType.Warning:
                        e.Value = Properties.Resources.warning16x16;
                        break;
                }
            }
        }
        private void dgrHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //LoggingModel logs = (LoggingModel)_ListHistory.Where(l => l.Id == (int)dgrHistory[1, e.RowIndex].Value).FirstOrDefault();//Linh.Tran_221013: Command
                LoggingModel logs = (LoggingModel)_ListHistory[e.RowIndex];//Linh.Tran_221013: Update fix errors cannot show true details of messages

                //
                frmLogDetails frmDetails = new frmLogDetails(logs);
                frmDetails.ShowDialog();
            }
            catch (Exception ex)
            {
                //
            }
        }
        private void dgrHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                if (dgrHistory.SelectedRows.Count > 0)
                {
                    _SelectRow = dgrHistory.SelectedRows[0].Index;
                }
            }
        }
        //
        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            _MouseDown = false;
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            _MouseDownLocation = e.Location;
            _MouseDown = true;
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_MouseDown)
            {
                this.Left = e.X + this.Left - _MouseDownLocation.X;
                this.Top = e.Y + this.Top - _MouseDownLocation.Y;
            }
        }

        private void LogsFilesOnChanged(object sender, EventArgs e)
        {
            LoggingController.Invoke(this, new Action(() =>
            {
                btnRefresh.PerformClick();
            }));
        }
        #endregion//End Events

        #region Methods
        public void SetLanguage()
        {
            this.Text =ML.Languages.Languages.ViewLog;
            //
            chkError.Text = ML.Languages.Languages.Errors;
            chkWarning.Text = ML.Languages.Languages.Warning;
            chkInfo.Text = ML.Languages.Languages.Info;
            chkStart.Text = ML.Languages.Languages.Started;

            //Font font = chkStop.Font;
            //Size sizeOfText = System.Windows.Forms.TextRenderer.MeasureText(Language.InternalLanguage.StopPrint, font);
            chkStop.Text = ML.Languages.Languages.Stoped;
            lblFrom.Text = ML.Languages.Languages.From;
            lblTo.Text = ML.Languages.Languages.To;
            btnExport.Text = ML.Languages.Languages.Export;
            btnRefresh.Text = ML.Languages.Languages.Refresh;
            btnClearLog.Text = ML.Languages.Languages.ClearLog;
            lblRowsCount.Text = ML.Languages.Languages.RowsCount + " 0";
            //
            dateFrom.TitleName = ML.Languages.Languages.DateTime + ": " + ML.Languages.Languages.From;
            dateTo.TitleName = ML.Languages.Languages.DateTime + ": " + ML.Languages.Languages.To;
            //
            grbFilter.Text = ML.Languages.Languages.Filter;
            //
            try
            {
                //
                dgrHistory.Columns["KeyWord"].HeaderText = ML.Languages.Languages.KeyWord;
                dgrHistory.Columns["Command"].HeaderText = ML.Languages.Languages.Command;
                dgrHistory.Columns["Date"].HeaderText = ML.Languages.Languages.DateTime;
                dgrHistory.Columns["Message"].HeaderText = ML.Languages.Languages.Message;
                dgrHistory.Columns["User"].HeaderText = ML.Languages.Languages.Username;
                //
            }
            catch (Exception ex)
            {
                //
            }
            //
        }

        public void ReLoadData()
        {
            AdjustData(null, EventArgs.Empty);
        }

        private void LoadData(List<LoggingType> searchTypes, DateTime dateFrom, DateTime dateTo)
        {
            new Thread(() =>//Linh.Tran_210524
            {
                try
                {
                    _IsExc = true;
                    //
                    //Linh.Tran_210524
                    //Point ptControls = new Point(this.DesktopLocation.X + dgrHistory.Location.X, this.DesktopLocation.Y + 94 + pnldgrHistory.Location.Y);//Linh.Tran_211222: Command
                    //CommonAlarm.ShowLoading(ptControls, pnldgrHistory.Size);//Command
                    //Point ptControls = new Point((this.Location.X), (this.Location.Y));//Linh.Tran_211222: Update
                    //ControlFunctions.ShowLoading(ptControls, this.Size);
                    ControlFunctions.ShowLoading(this);
                    //End Linh.Tran_210524
                    //
                    ControlFunctions.Invoke(this, new Action(() =>
                    {
                        dgrHistory.Visible = false;
                        tblMain.Enabled = false;//Linh.Tran_210524
                    }));
                    // LoggingViewlogController.ClearHistory(dateFrom, dateTo, type);
                    //if (_IsShowErrorPrintedPage)
                    //{
                    //    _ListHistory = LoggingController.LoadHistory(dateFrom, dateTo, searchTypes, _Command);
                    //}
                    //else
                    //{
                    //    _ListHistory = LoggingController.LoadHistory(dateFrom, dateTo, searchTypes);
                    //}
                    _ListHistory = LoggingController.LoadHistory(dateFrom, dateTo, searchTypes);

                    if (_ListHistory != null)
                    {
                        LoggingController.Invoke(this, new Action(() =>
                        {
                            if (!dgrHistory.Columns.Contains("image_column"))
                            {
                                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                                imageCol.Name = "image_column";
                                imageCol.DisplayIndex = 0;
                                imageCol.HeaderText = "";
                                imageCol.Width = 35;
                                dgrHistory.Columns.Insert(0, imageCol);
                            }
                            //
                            //dgrHistory.DataSource = _ListHistory.OrderByDescending(l => l.Date).ToList();//Linh.Tran_210518: Apply but wrong icon
                            dgrHistory.DataSource = _ListHistory;
                            //
                            //dgrHistory.Columns["Id"] = new DataGridViewImageColumn();
                            dgrHistory.Columns["Id"].Visible = false;
                            dgrHistory.Columns["LogType"].Visible = false;
                            dgrHistory.Columns["Command"].Visible = false;//Linh.Tran_200303
                            //
                            dgrHistory.Columns["KeyWord"].HeaderText = ML.Languages.Languages.KeyWord;
                            dgrHistory.Columns["Command"].HeaderText = ML.Languages.Languages.Command;
                            dgrHistory.Columns["Date"].HeaderText = ML.Languages.Languages.DateTime;
                            dgrHistory.Columns["Message"].HeaderText = ML.Languages.Languages.Message;
                            dgrHistory.Columns["User"].HeaderText = ML.Languages.Languages.Username;
                            //
                            dgrHistory.Columns["KeyWord"].Width = 150;
                            dgrHistory.Columns["Command"].Width = 180;
                            dgrHistory.Columns["Date"].Width = 150;
                            dgrHistory.Columns["Message"].Width = this.Width - (dgrHistory.Columns["KeyWord"].Width + dgrHistory.Columns["Command"].Width + dgrHistory.Columns["Date"].Width + dgrHistory.Columns["User"].Width + 35 + 65);
                            //
                            lblRowsCount.Text = ML.Languages.Languages.RowsCount + ": " + _ListHistory.Count.ToString("n0");
                            chkError.Text = String.Format(String.Format("{0} {1:N0}", ML.Languages.Languages.Errors,
                                _ListHistory.Where(l => l.LogType == LoggingType.Error).ToList().Count()));
                            chkWarning.Text = String.Format(String.Format("{0} {1:N0}", ML.Languages.Languages.Warning,
                                //(from myRow in _DtHistory.AsEnumerable() where myRow.Field<LoggingProgramsTypeEnum>("programstatus") == LoggingProgramsTypeEnum.Waiting select myRow).Count());
                                _ListHistory.Where(l => l.LogType == LoggingType.Warning).ToList().Count()));
                            chkInfo.Text = String.Format(String.Format("{0} {1:N0}", ML.Languages.Languages.Info,
                                //(from myRow in _DtHistory.AsEnumerable() where myRow.Field<LoggingProgramsTypeEnum>("programstatus") == LoggingProgramsTypeEnum.Failed select myRow).Count());
                                _ListHistory.Where(l => l.LogType == LoggingType.Info).ToList().Count()));
                            //
                            Font font = chkStart.Font;
                            Size sizeOfTextStart = System.Windows.Forms.TextRenderer.MeasureText(ML.Languages.Languages.Started, font);
                            chkStart.Text = String.Format(String.Format("{0} {1:N0}", (sizeOfTextStart.Width < 121) ? ML.Languages.Languages.Started : ML.Languages.Languages.Started.Substring(0, ML.Languages.Languages.Started.Length - 8) + "...",
                                //(from myRow in _DtHistory.AsEnumerable() where myRow.Field<LoggingProgramsTypeEnum>("programstatus") == LoggingProgramsTypeEnum.Invalid select myRow).Count());
                                _ListHistory.Where(l => l.LogType == LoggingType.Started).ToList().Count()));
                            //
                            font = chkStop.Font;
                            Size sizeOfTextStop = System.Windows.Forms.TextRenderer.MeasureText(ML.Languages.Languages.Stoped, font);
                            chkStop.Text = String.Format(String.Format("{0} {1:N0}", (sizeOfTextStop.Width < 121) ? ML.Languages.Languages.Stoped : ML.Languages.Languages.Stoped.Substring(0, ML.Languages.Languages.Stoped.Length - 8) + "...",
                                //(from myRow in _DtHistory.AsEnumerable() where myRow.Field<LoggingProgramsTypeEnum>("programstatus") == LoggingProgramsTypeEnum.Invalid select myRow).Count());
                                _ListHistory.Where(l => l.LogType == LoggingType.Stoped).ToList().Count()));
                            //
                            //
                            if (dgrHistory.Rows.Count > 0)
                            {
                                dgrHistory.ClearSelection();
                                dgrHistory.Rows[_ListHistory.Count - 1].Selected = true;
                                dgrHistory.FirstDisplayedScrollingRowIndex = dgrHistory.SelectedRows[0].Index;
                            }
                            //
                            //
                        }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ML.Languages.Languages.Errors, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LoggingController.Invoke(this, new Action(() =>
                    {
                        dgrHistory.Visible = true;
                        tblMain.Enabled = true;
                    }));
                    ControlFunctions.CloseLoading();
                    _IsExc = false;
                }
            }).Start();
        }

        

        private void ExportData(bool onlyUSB)
        {
            try
            {
                if (onlyUSB)
                {
                    //
                }
                else
                {
                    #region Normal
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV|*.csv";
                    sfd.ShowDialog();
                    if (sfd.FileName == "")
                    {
                        return;
                    }
                    //
                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine(LoggingModel.ExportHeader());
                    foreach (LoggingModel mode in _ListHistory)
                    {
                        csv.AppendLine(mode.ExportStringData());
                    }

                    //FileStream fs = File.Create(sfd.FileName);
                    File.WriteAllText(sfd.FileName, csv.ToString());

                    Process.Start(sfd.FileName);
                    #endregion//end Normal
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void ClearData()
        {
            List<LoggingType> searchTypes = new List<LoggingType>();
            if (chkError.Checked)
            {
                searchTypes.Add(LoggingType.Error);
            }
            if (chkInfo.Checked)
            {
                searchTypes.Add(LoggingType.Info);
            }
            if (chkWarning.Checked)
            {
                searchTypes.Add(LoggingType.Warning);
            }
            if (chkStart.Checked)
            {
                searchTypes.Add(LoggingType.Started);
            }
            if (chkStop.Checked)
            {
                searchTypes.Add(LoggingType.Stoped);
            }
            DateTime dateFromValue = dateFrom.Value;
            DateTime dateToValue = dateTo.Value;
            //clear data first
            switch (_LogedInUsername)
            {
                case "Administrator":
                    LoggingController.ClearHistory(dateFromValue, dateToValue);
                    break;
                default:
                    //
                    break;
            }
            //

            //refresh datasource
            LoadData(searchTypes, dateFromValue, dateToValue);
        }

        public void LogsViewFileWatcher()
        {
            string logsName = LoggingController.LoggingPath;
            if (LoggingController.LoggingPath.Equals(""))
            {
                return;
            }
            string fileName = Path.GetFileName(logsName);
            string folderPath = Path.GetDirectoryName(logsName);
            // Create a new FileSystemWatcher and set its properties.
            _WatcherTemplateFile = new FileSystemWatcher();
            //watcher.Path = path;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            _WatcherTemplateFile.Path = folderPath;
            /* Watch for changes in LastAccess and LastWrite times, and 
               the renaming of files or directories. */
            //watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
            //   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            _WatcherTemplateFile.NotifyFilter = NotifyFilters.LastWrite;
            // Only watch text files.
            //watcher.Filter = "*.dsj";
            _WatcherTemplateFile.Filter = fileName;

            // Add event handlers.
            _WatcherTemplateFile.Changed += new FileSystemEventHandler(LogsFilesOnChanged);
            _WatcherTemplateFile.Created += new FileSystemEventHandler(LogsFilesOnChanged);
            _WatcherTemplateFile.Deleted += new FileSystemEventHandler(LogsFilesOnChanged);
            //_WatcherTemplateFile.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            _WatcherTemplateFile.EnableRaisingEvents = true;
        }
        #endregion//End Methods

        /// <summary>
        /// Linh.Tran
        /// On 190904
        /// Methods override is fix error Controls in usercontrol flicker while usercontrol visiblity changes
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
