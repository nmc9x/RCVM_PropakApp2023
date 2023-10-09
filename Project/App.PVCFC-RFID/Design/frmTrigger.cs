using App.PVCFC_RFID.Controller;
using ML.Common.Controller;
using ML.Controls;
using ML.Languages;
using ML.SDK.DM60X.Model;
using ML.SDK.RDIF_FX9600.DataType;
using Symbol.RFID3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmTrigger : Form
    {
        #region Properties
        private int _Index = 0;
        private bool _IsClosed = false;
        private bool _IsExc = false;
        private bool _IsSelectLastRow = true;
        private bool _IsReading = false;
        private Color _TitleColor = Color.Green;
        private string _TitleStr = "";
        private int _TotalRecord = 0;
        private int _SelectRow = 0;
        //declare your list
        private BindingList<GotCodeModel> _TagList = new BindingList<GotCodeModel>();
        #endregion//End Properties

        public frmTrigger(int index, Point location, Size size)
        {
            _Index = index;
            //
            InitializeComponent();
            //
            this.Icon = Properties.Resources.rfid;
            this.MinimumSize = new Size(1024, 768);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = location;
            this.Size = size;
            //
            ControlFunctions.ShowLoading(this);
            //
            InitControls();
            InitLanguages();
            InitEvents();
        }

        #region Inits
        private void InitControls()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                btnTrigger.Tag = false;
                //
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersWidth = 84;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //
                lblTotalRows.Text = Languages.CodeCount + ": " + dataGridView1.RowCount.ToString("N0");
            }));
        }

        private void InitLanguages()
        {
            this.Text = Languages.ScanData;
            //
            lblTitle.Text = SharedFunctions.GetStationName(_Index) + " - " + Languages.ScanData.ToUpper();
            lblTimeout.Text = Languages.Timeout + " (ms)";
            btnRead.Text = Languages.Read;
            //btnReadDetail.Text = Languages.ManualReading;
            btnClear.Text = Languages.Clear;
        }

        private void InitEvents()
        {
            FileMonitor();
            this.Load+=frmProductDetails_Load;
            this.FormClosing+=frmTrigger_FormClosing;
            this.FormClosed+=frmProductDetails_FormClosed;
            this.Shown+=frmProductDetails_Shown;
            btnFirst.Click+=btnControls_Click;
            btnBack.Click += btnControls_Click;
            btnNext.Click += btnControls_Click;
            btnLast.Click += btnControls_Click;

            //
            //btnReadDetail.Click+=btnReadDetail_Click;
            btnRead.Click+= btnRead_Click;
            btnTrigger.Click+=btnTrigger_Click;
            btnClear.Click+=btnClear_Click;

            //
            //Data gridView
            dataGridView1.Click+=dataGridView1_Click;
            dataGridView1.RowPostPaint += dgvUser_RowPostPaint;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvUser_CellFormatting);
            dataGridView1.SelectionChanged += dgvUser_SelectionChanged;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
           
            //
            //SharedValues.Running.StationList[_Index].DataRawList.ListChanged += DataRawList_ListChanged;
            //
           
        }

        private void FileMonitor()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ImagesCognex";

            // Tạo một thể hiện của FileSystemWatcher để theo dõi thư mục.
            FileSystemWatcher watcher = new FileSystemWatcher();

            // Thiết lập thư mục để theo dõi
            watcher.Path = folderPath;

            // Chỉ theo dõi các tập tin có đuôi là .jpg
            watcher.Filter = "*.jpg";

            // Đăng ký sự kiện thêm tập tin mới
            watcher.Created += new FileSystemEventHandler(OnImageAdded);

            // Bắt đầu theo dõi
            watcher.EnableRaisingEvents = true;

        }

        private void OnImageAdded(object sender, FileSystemEventArgs e)
        {
            LoadLastedImage();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void InitData()
        {
            Thread tThread = new Thread(() =>
            {
                try
                {
                    CommonFunctions.Invoke(this, new Action(() =>
                        {
                            numTimeoutMan.Value = 0;// SharedValues.Settings.StationList[_Index].RFID.DurationStop;
                            //Linh.Tran_230904: Binding data
                            //Linh.Tran_230904: Binding data
                            List<GotCodeModel> cloneList = new List<GotCodeModel>(SharedValues.Running.StationList[_Index].DataRawList);
                            _TagList = new BindingList<GotCodeModel>(cloneList);//Avoid find when list add new items    
                            dataGridView1.DataSource = _TagList;
                            //
                            dataGridView1.Columns["ID"].HeaderText = "ID";//Languages.TagID;
                            dataGridView1.Columns["Code"].HeaderText = "Code";//Languages.ProductCode;
                            dataGridView1.Columns["Symbol"].HeaderText = "Symbol";//Languages.AntennaID;
                            dataGridView1.Columns["DecodeTime"].HeaderText = "Decode Time";//Languages.RSSI;
                            dataGridView1.Columns["Status"].HeaderText = "Status";//Languages.TotalTagCount;
                            //
                            dataGridView1.Columns["ID"].ReadOnly = true;
                            dataGridView1.Columns["Code"].ReadOnly = true;
                            dataGridView1.Columns["Symbol"].ReadOnly = true;
                            dataGridView1.Columns["DecodeTime"].ReadOnly = true;
                            dataGridView1.Columns["Status"].ReadOnly = true;
                            //
                            if (_IsSelectLastRow)
                            {
                                _SelectRow = _TagList.Count - 1;
                                SelectProductItems(_SelectRow);
                            }
                            _TotalRecord = _TagList.Count;
                            lblTotalRows.Text = Languages.CodeCount + ": " + _TagList.Count.ToString("N0");
                        }));
                    //
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
            });
            tThread.Start();
        }
        #endregion//End Inits

        #region Events
        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void frmProductDetails_Shown(object sender, EventArgs e)
        {
            ControlFunctions.CloseLoading();
        }
        private void frmTrigger_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_IsReading)
            {
                MessageBox.Show(Languages.PleasetStopTriggerBeforeClose, lblTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private void frmProductDetails_FormClosed(object sender, EventArgs e)
        {
            //SharedValues.Running.StationList[_Index].DataRawList.ListChanged -= DataRawList_ListChanged;
            SharedValues.Running.StationList[_Index].DataRawList.Clear();
            _IsClosed = true;
        }
        private void btnControls_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        int selectRow = _SelectRow;
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            selectRow = dataGridView1.SelectedRows[0].Index;
                        }
                        switch ((sender as Button).Name)
                        {
                            case "btnFirst":
                                _IsSelectLastRow = false;
                                _SelectRow = 0;
                                break;
                            case "btnBack":
                                _IsSelectLastRow = false;
                                _SelectRow = _SelectRow > 0 ? (_SelectRow - 1) : 0;
                                break;
                            case "btnNext":
                                _IsSelectLastRow = false;
                                _SelectRow = _SelectRow < (dataGridView1.Rows.Count - 1) ? (_SelectRow + 1) : (dataGridView1.Rows.Count - 1);
                                break;
                            case "btnLast":
                                _IsSelectLastRow = true;
                                _SelectRow = (dataGridView1.Rows.Count - 1);
                                break;
                        }
                        SelectProductItems(_SelectRow);
                    }));
                }
                catch (Exception ex)
                { }
                finally
                { _IsExc = false; }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //if(!_IsExc)
            //{
            //    _IsReading = true;
            //    START_TRIGGER_TYPE curModeStart = SharedValues.Settings.StationList[_Index].RFID.ModeStart;
            //    STOP_TRIGGER_TYPE curModeStop = SharedValues.Settings.StationList[_Index].RFID.ModeStop;
            //    int curDurationStop = SharedValues.Settings.StationList[_Index].RFID.DurationStop;
            //    try
            //    {
            //        _IsExc = true;
            //        ControlFunctions.ShowLoading(this);
            //        #region Set Config
            //        //
            //        //Setting RFID
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStart = START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE;
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
            //        SharedValues.Settings.StationList[_Index].RFID.DurationStop = (int)numTimeoutMan.Value;
            //        SharedControlHandler.SendRFIDSettings(_Index); // no save xml
            //        Thread.Sleep(2000);
            //        ControlFunctions.CloseLoading();
            //        if (SharedFunctions.ConfigResultNotify(_Index, false, false))
            //        {
            //            #region Read data
            //            SharedValues.Settings.StationList[_Index].RFID.TypeOfOperation = RFID_OPERATION_TYPE.StartRead;
            //            SharedControlHandler.SendRFIDOperationCmd(_Index);
            //            #endregion//End Read
            //        }
            //        #endregion//End set Confif
            //    }
            //    catch (Exception ex)
            //    {
            //        //
            //    }
            //    finally
            //    {
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStart = curModeStart;
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = curModeStop;
            //        SharedValues.Settings.StationList[_Index].RFID.DurationStop = curDurationStop;
            //        SharedValues.Settings.StationList[_Index].RFID.TypeOfOperation = RFID_OPERATION_TYPE.StopRead;
            //        //
            //        ControlFunctions.CloseLoading();
            //        _IsExc = false;
            //        _IsReading = false;
            //    }
            //}
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {

            SharedControlHandler.SendRFIDOperationCmd(_Index);


            //if (!_IsExc)
            //{
            //    START_TRIGGER_TYPE curModeStart = SharedValues.Settings.StationList[_Index].RFID.ModeStart;
            //    STOP_TRIGGER_TYPE curModeStop = SharedValues.Settings.StationList[_Index].RFID.ModeStop;
            //    int curDurationStop = SharedValues.Settings.StationList[_Index].RFID.DurationStop;
            //    try
            //    {
            //        _IsExc = true;
            //        //
            //        ControlFunctions.ShowLoading(this);
            //        if ((bool)btnTrigger.Tag)
            //        {
            //            //Is Start read
            //            #region Stop data
            //            SharedValues.Settings.StationList[_Index].RFID.TypeOfOperation = RFID_OPERATION_TYPE.StopRead;
            //            SharedControlHandler.SendRFIDOperationCmd(_Index);
            //            SharedFunctions.Invoke(this, new Action(() =>
            //                {
            //                    btnTrigger.Tag = false;
            //                }));
            //            #endregion//End Stop read
            //        }
            //        else
            //        {
            //            //Is Stop
            //            //
            //            #region Set Config
            //            //Setting RFID
            //            SharedValues.Settings.StationList[_Index].RFID.ModeStart = START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI;
            //            SharedValues.Settings.StationList[_Index].RFID.ModeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
            //            SharedValues.Settings.StationList[_Index].RFID.DurationStop = (int)numTimeoutMan.Value;
            //            SharedControlHandler.SendRFIDSettings(_Index); // no save xml
            //            Thread.Sleep(2000);
            //            #endregion//End set Confif
            //            ControlFunctions.CloseLoading();
            //            if (SharedFunctions.ConfigResultNotify(_Index, false, false))
            //            {
            //                //
            //                #region Read data
            //                SharedValues.Settings.StationList[_Index].RFID.TypeOfOperation = RFID_OPERATION_TYPE.StartRead;
            //                SharedControlHandler.SendRFIDOperationCmd(_Index);
            //                #endregion//End Read
            //                //
            //                SharedFunctions.Invoke(this, new Action(() =>
            //                {
            //                    btnTrigger.Tag = true;
            //                }));
            //                //
            //            }
            //            //
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //
            //    }
            //    finally
            //    {
            //        //
            //        SharedFunctions.Invoke(this, new Action(() =>
            //        {
            //            if ((bool)btnTrigger.Tag)
            //            {
            //                btnTrigger.Text = Languages.StopTrigger;
            //                btnRead.Enabled = false;
            //                numTimeoutMan.Enabled = false;
            //                //
            //                _IsReading = true;
            //            }
            //            else
            //            {
            //                btnTrigger.Text = Languages.StartTrigger;
            //                btnRead.Enabled = true;
            //                numTimeoutMan.Enabled = true;
            //                //
            //                _IsReading = false;
            //            }
            //        }));
            //        //
            //        //
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStart = curModeStart;
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = curModeStop;
            //        SharedValues.Settings.StationList[_Index].RFID.DurationStop = curDurationStop;
            //        //
            //        ControlFunctions.CloseLoading();
            //        _IsExc = false;
            //    }
            //}


        }
        private void LoadLastedImage()
        {
            try
            {
                var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ImagesCognex";
                if (Directory.Exists(folderPath))
                {
                    var directory = new DirectoryInfo(folderPath);
                    var files = directory.GetFiles("*.jpg")  // Chỉ lấy các tập tin .jpg
                                               .OrderByDescending(f => f.CreationTime)
                                               .ToArray();
                    if (files.Length > 0)
                    {
                        var latestFile = files[0];
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = Image.FromFile(latestFile.FullName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("LoadLastedImage: "+ex.Message);
#endif
            }
        }

        private void btnReadDetail_Click(object sender, EventArgs e)
        {
            //if (!_IsExc)
            //{
            //    START_TRIGGER_TYPE curModeStart = SharedValues.Settings.StationList[_Index].RFID.ModeStart;
            //    STOP_TRIGGER_TYPE curModeStop = SharedValues.Settings.StationList[_Index].RFID.ModeStop;
            //    int curDurationStop = SharedValues.Settings.StationList[_Index].RFID.DurationStop;
            //    try
            //    {
            //        _IsExc = true;
            //        ControlFunctions.ShowLoading(this);
            //        //

            //        //
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStart = START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI;
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
            //        SharedValues.Settings.StationList[_Index].RFID.DurationStop = (int)numTimeoutMan.Value;
            //        SharedControlHandler.SendRFIDSettings(_Index); // no save xml
            //        //
            //        SharedControlHandler.SendRFIDSettings(_Index);
            //        Thread.Sleep(2000);
            //        SharedFunctions.ConfigResultNotify(_Index, true, false);
            //        Thread.Sleep(10);
            //        #region Read data
            //        SharedValues.Settings.StationList[_Index].RFID.TypeOfOperation = RFID_OPERATION_TYPE.StartRead;
            //        SharedControlHandler.SendRFIDOperationCmd(_Index);
            //        #endregion//End Read
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //    finally
            //    {
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStart = curModeStart;
            //        SharedValues.Settings.StationList[_Index].RFID.ModeStop = curModeStop;
            //        SharedValues.Settings.StationList[_Index].RFID.DurationStop = curDurationStop;
            //        //
            //        ControlFunctions.CloseLoading();
            //        _IsExc = false;
            //    }
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    SharedValues.Running.StationList[_Index].DataRawList.Clear();
                    _TagList.Clear();
                    _TotalRecord = 0;
                    lblTotalRows.Text = Languages.CodeCount + ": " + dataGridView1.RowCount.ToString("N0");
                }));
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                _IsSelectLastRow = false;
                _SelectRow = dataGridView1.CurrentCell.RowIndex;
                SelectProductItems(_SelectRow);
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// Draw number of rows of datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
            //
        }
        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //
        }
        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        //                        

                    }));
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message, "dataGridView1_SelectionChanged");
#endif
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void DataRawList_ListChanged(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        _TagList.Add(SharedValues.Running.StationList[_Index].DataRawList[_TotalRecord]);
                        if (_IsSelectLastRow && dataGridView1.RowCount > 0)
                        {
                            _SelectRow = dataGridView1.RowCount - 1;
                            SelectProductItems(_SelectRow);
                        }
                        _TotalRecord = _TagList.Count;
                        //
                        lblTotalRows.Text = Languages.CodeCount + ": " + dataGridView1.RowCount.ToString("N0");
                    }));
                    break;
                case ListChangedType.ItemChanged:
                case ListChangedType.Reset:
                    SharedFunctions.Invoke(this, new Action(() =>
                    {
                        dataGridView1.Refresh();
                    }));
                    break;
                case ListChangedType.ItemDeleted:
                case ListChangedType.ItemMoved:
                default:
                    MessageBox.Show(e.ListChangedType.ToString());
                    break;
            }
        }
        #endregion//End Events

        #region Methods

        private void SelectProductItems(int index)
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        if (index < 0 || index >= dataGridView1.Rows.Count)
                        {
                            index = 0;
                        }
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[index].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }));
        }
        #endregion//End Methods

        #region Fixed flickering forms - https://www.youtube.com/watch?v=_h-UXxp3cd0&t=116s

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

        #endregion//End Fixed flickering forms
    }
}
