using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.DataType;
using App.PVCFC_RFID.Model;
using ML.Common.Controller;
using ML.Controls;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using ML.DeviceTransfer.PVCFCRFID.Model;
using ML.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmProductDetails : Form
    {
        #region Properties
        private int _Index = 0;
        private bool _IsClosed = false;
        private bool _IsExc = false;
        private bool _IsSelectLastRow = true;
        private Color _TitleColor = Color.Green;
        private string _TitleStr = "";
        private PVCFCProductItemStatusEnum _FilterStatus = PVCFCProductItemStatusEnum.None;
        private int _TotalRecord = 0;
        private int _SelectRow = 0;
        //declare your list
        private BindingList<PVCFCProductItemModel> mMyList = new BindingList<PVCFCProductItemModel>();
       
        #endregion//End Properties

        public frmProductDetails(int index, Point location, Size size, PVCFCProductItemStatusEnum filterStatus = PVCFCProductItemStatusEnum.None)
        {
            _Index = index;
            _FilterStatus = filterStatus;
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
                _TitleStr = PVCFCProductItemStatusExtensions.GetText(_FilterStatus);
                _TitleColor = PVCFCProductItemStatusExtensions.GetColor(_FilterStatus);
                //
                lblTitle.Text = _TitleStr.ToUpper();
                lblTitle.ForeColor = _TitleColor;
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
            this.Text = Languages.ProductDetails;
        }

        private void InitEvents()
        {
            this.Load+=frmProductDetails_Load;
            this.FormClosed+=frmProductDetails_FormClosed;
            this.Shown+=frmProductDetails_Shown;
            btnFirst.Click+=btnControls_Click;
            btnBack.Click += btnControls_Click;
            btnNext.Click += btnControls_Click;
            btnLast.Click += btnControls_Click;
            //Data gridView
            dataGridView1.Click+=dataGridView1_Click;
            dataGridView1.RowPostPaint += dgvUser_RowPostPaint;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvUser_CellFormatting);
            dataGridView1.SelectionChanged += dgvUser_SelectionChanged; 
            //
        }

        private void InitData()
        {
            Thread tThread = new Thread(() =>
            {
                try
                {
                    CommonFunctions.Invoke(this, new Action(() =>
                        {
                            //Linh.Tran_230904: Binding data
                            List<PVCFCProductItemModel> cloneList = new List<PVCFCProductItemModel>(SharedValues.Running.StationList[_Index].Schedules.ProductItemsList);
                            mMyList = new BindingList<PVCFCProductItemModel>(cloneList.Where(p => (_FilterStatus.GetResult().Contains(p.Results))).ToList());//Avoid find when list add new items
                            //mMyList = new BindingList<PVCFCProductItemModel>(SharedValues.Running.StationList[_Index].Schedules.ProductItemsList.Where(p => (p.Status == _FilterStatus)).ToList());
                            dataGridView1.DataSource = mMyList;
                            //
                            dataGridView1.Columns["IsPalletCode"].Visible = false;
                            dataGridView1.Columns["PalletCode"].Visible = false;
                            dataGridView1.Columns["Status"].Visible = false;
                            //
                            dataGridView1.Columns["TagID"].HeaderText = Languages.TagID;
                            dataGridView1.Columns["ProductCode"].HeaderText = Languages.ProductCode;
                            dataGridView1.Columns["PalletCode"].HeaderText = Languages.PalletCode;
                            dataGridView1.Columns["Results"].HeaderText = Languages.Status;
                            dataGridView1.Columns["ScanDatetime"].HeaderText = Languages.ScanDatetime;
                            dataGridView1.Columns["Errors"].HeaderText = Languages.Errors;
                            //
                            dataGridView1.Columns["TagID"].ReadOnly = true;
                            dataGridView1.Columns["ProductCode"].ReadOnly = true;
                            dataGridView1.Columns["PalletCode"].ReadOnly = true;
                            dataGridView1.Columns["Status"].ReadOnly = true;
                            dataGridView1.Columns["ScanDatetime"].ReadOnly = true;
                            //
                            if (_IsSelectLastRow)
                            {
                                _SelectRow = mMyList.Count() - 1;
                                SelectProductItems(_SelectRow);
                            }
                            _TotalRecord = cloneList.Count;
                        }));
                    //
                    while (!_IsClosed)
                    {
                        try
                        {
                            //Check new record
                            if (_TotalRecord < SharedValues.Running.StationList[_Index].Schedules.ProductItemsList.Count)
                            {
                                int countItems = SharedValues.Running.StationList[_Index].Schedules.ProductItemsList.Count - _TotalRecord;
                                //
                                for (int i = _TotalRecord; i < (_TotalRecord + countItems); i++)
                                {
                                    //if (SharedValues.Running.StationList[_Index].Schedules.ProductItemsList[i].Status == _FilterStatus)
                                    if (_FilterStatus.GetResult().Contains(SharedValues.Running.StationList[_Index].Schedules.ProductItemsList[i].Results))
                                    {
                                        CommonFunctions.Invoke(this, new Action(() =>
                                        {
                                            mMyList.Add(SharedValues.Running.StationList[_Index].Schedules.ProductItemsList[i]);
                                            //dataGridView1.Refresh();//Linh.Tran_230904: Refresh when values has been changes in BindingListChanges
                                            //The datagrid will show automatically the new added/updated items, no need to do anything else
                                        }));
                                    }
                                }
                                CommonFunctions.Invoke(this, new Action(() =>
                                {
                                    if (_IsSelectLastRow)
                                    {
                                        _SelectRow = mMyList.Count() - 1;
                                        SelectProductItems(_SelectRow);
                                    }
                                    //
                                    lblTotalRows.Text = Languages.CodeCount + ": " + dataGridView1.RowCount.ToString("N0");
                                }));
                                _TotalRecord += countItems;
                            }
                        }
                        catch(Exception ex)
                        {
#if DEBUG
                            Console.WriteLine("Load details: " + ex.Message);
#endif
                        }
                        //End Check new record
                        Thread.Sleep(10);
                    }
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
        private void frmProductDetails_FormClosed(object sender, EventArgs e)
        {
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
            if (e.RowIndex == -1 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }
            #region Linh.Tran_230619: Translate status
            //If formatting your desired column, set the value
            if (e.ColumnIndex == dataGridView1.Columns["Results"].Index)
            {
                //You can put your dynamic logic here
                //and use different values based on other cell values, for example cell 2
                PVCFCProductItemResultEnum status = PVCFCProductItemResultEnum.None;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string strStatus = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    Color clrStatus = Color.Red;
                    Enum.TryParse(strStatus, out status);
                    //
                    strStatus = status.GetText();
                    clrStatus = status.GetColor();
                    //
                    e.Value = strStatus;
                    e.CellStyle.ForeColor = clrStatus;
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Errors"].Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    e.CellStyle.ForeColor = PVCFCProductItemStatusEnum.ActivedFailed.GetColor();
                }
            }
            #endregion//End Linh.Tran_230619: Translate status
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
