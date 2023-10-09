using ML.Common.Controller;
using ML.Languages;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace App.DevCodeActivatorRFID.Design
{
    public partial class frmProductDetails : Form
    {
        #region Properties
        private bool _IsExc = false;
        private Color _TitleColor = Color.Green;
        private string _TitleStr = "";
        private App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum _FilterStatus = App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.Success;
        #endregion//End Properties

        public frmProductDetails(App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum filterStatus = App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.Unknown)
        {
            _FilterStatus = filterStatus;
            //
            InitializeComponent();
            //
            InitControls();
            InitLanguages();
            InitEvents();
            InitData();
        }

        #region Inits
        private void InitControls()
        {
            
        }

        private void InitLanguages()
        {
            this.Text = Languages.ProductDetails;
        }

        private void InitEvents()
        {
            btnFirst.Click+=btnControls_Click;
            btnBack.Click += btnControls_Click;
            btnNext.Click += btnControls_Click;
            btnLast.Click += btnControls_Click;
            //Data gridView
            dataGridView1.RowPostPaint += dgvUser_RowPostPaint;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvUser_CellFormatting);
            dataGridView1.SelectionChanged += dgvUser_SelectionChanged;
            //
        }

        private void InitData()
        {
            LoadDisplayTitle();
            LoadData();
        }
        #endregion//End Inits

        #region Events
        private void btnControls_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        int selectRow = 0;
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            selectRow = dataGridView1.SelectedRows[0].Index;
                        }
                        switch ((sender as Button).Name)
                        {
                            case "btnFirst":
                                selectRow = 0;
                                break;
                            case "btnBack":
                                selectRow = selectRow > 0 ? (selectRow - 1) : 0;
                                break;
                            case "btnNext":
                                selectRow = selectRow < (dataGridView1.Rows.Count - 1) ? (selectRow + 1) : (dataGridView1.Rows.Count - 1);
                                break;
                            case "btnLast":
                                selectRow = (dataGridView1.Rows.Count - 1);
                                break;
                        }
                        SelectProductItems(selectRow);
                    }));
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
            if (e.ColumnIndex == dataGridView1.Columns["status"].Index)
            {
                //You can put your dynamic logic here
                //and use different values based on other cell values, for example cell 2
                App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum status = App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.Unknown;
                string strStatus = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                Enum.TryParse(strStatus, out status);
                //
                strStatus = Languages.Unknown;
                Color clrStatus = Color.Red;
                switch(status)
                {
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.CheckedSuccess:
                        strStatus = Languages.CheckedSuccess;
                        clrStatus = Color.LightSeaGreen;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.CheckedFailed:
                        strStatus = Languages.CheckedFailed;
                        clrStatus = Color.Maroon;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedSuccess:
                        strStatus = Languages.ActivedSuccess;
                        clrStatus = Color.Green;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedFailed:
                        strStatus = Languages.ActivedFailed;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.DuplicateCode:
                        strStatus = Languages.DuplicateCode;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.Unknown:
                        strStatus = Languages.Unknown;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.WrongProductName:
                        strStatus = Languages.WrongProductName;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.WrongPallet:
                        strStatus = Languages.WrongPallet;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.PalletExcessQuantity:
                        strStatus = Languages.MsgPalletExcessQuantity;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.PalletLackQuantity:
                        strStatus = Languages.MsgPalletLackQuantity;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.MissProduct:
                        strStatus = Languages.MissProduct;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.UnknownPallet:
                        strStatus = Languages.UnknownPallet;
                        clrStatus = Color.Red;
                        break;
                    case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.MissPallet:
                        strStatus = Languages.MissPallet;
                        clrStatus = Color.Red;
                        break;
                }
                //
                e.Value = strStatus;
                e.CellStyle.ForeColor = clrStatus;
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
        private void LoadDisplayTitle()
        {
            CommonFunctions.Invoke(this, new Action(() =>
                {
                    switch (_FilterStatus)
                    {
                        case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.CheckedSuccess:
                            _TitleStr = Languages.CheckedSuccess;
                            _TitleColor = Color.LightSeaGreen;
                            break;
                        case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.CheckedFailed:
                            _TitleStr = Languages.CheckedFailed;
                            _TitleColor = Color.Maroon;
                            break;
                        case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedSuccess:
                            _TitleStr = Languages.ActivedSuccess;
                            _TitleColor = Color.Green;
                            break;
                        case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedFailed:
                            _TitleStr = Languages.ActivedFailed;
                            _TitleColor = Color.Red;
                            break;
                        case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.DuplicateCode:
                            _TitleStr = Languages.DuplicateCode;
                            _TitleColor = Color.Red;
                            break;
                    }
                    //
                    lblTitle.Text = _TitleStr.ToUpper();
                    lblTitle.ForeColor = _TitleColor;
                }));
        }

        private void LoadData()
        {
            Thread tThread = new Thread(() =>
            {
                try
                {
                    //Loading
                    //
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        dataGridView1.Visible = false;
                    }));
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        //Binding data to data gridview
                        switch (_FilterStatus)
                        {
                            case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.CheckedSuccess:
                                
                                break;
                            case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.CheckedFailed:
                                
                                break;
                            case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedSuccess:
                                
                                break;
                            case App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum.ActivedFailed:
                                
                                break;
                        }
                        //
                        dataGridView1.AllowUserToAddRows = false;
                        //
                        dataGridView1.Columns["IsCheckSuccess"].Visible = false;
                        dataGridView1.Columns["IsActivedSuccess"].Visible = false;
                        dataGridView1.Columns["IsPalletCode"].Visible = false;
                        //
                        dataGridView1.Columns["ChipID"].HeaderText = Languages.ChipID;
                        dataGridView1.Columns["ProductCode"].HeaderText = Languages.ProductCode;
                        dataGridView1.Columns["PalletCode"].HeaderText = Languages.PalletCode;
                        dataGridView1.Columns["Status"].HeaderText = Languages.Status;
                        dataGridView1.Columns["ScanDatetime"].HeaderText = Languages.ScanDatetime;
                        //
                        dataGridView1.Columns["ChipID"].ReadOnly = true;
                        dataGridView1.Columns["ProductCode"].ReadOnly = true;
                        dataGridView1.Columns["PalletCode"].ReadOnly = true;
                        dataGridView1.Columns["Status"].ReadOnly = true;
                        dataGridView1.Columns["ScanDatetime"].ReadOnly = true;
                        //
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        //
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        //
                        lblTotalRows.Text = Languages.CodeCount + ": " + dataGridView1.RowCount.ToString("N0");
                    }));
                    //
                    SelectProductItems(0);
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message, "LoadUserAccount");
#endif
                }
                finally
                {
                    CommonFunctions.Invoke(this, new Action(() =>
                    {
                        dataGridView1.Visible = true;
                    }));
                    //CommonAlarm.CloseLoading();
                    //_IsBinding = false;
                }

            });
            tThread.IsBackground = true;
            tThread.Start();
        }

        private void SelectProductItems(int index)
        {
            CommonFunctions.Invoke(this, new Action(() =>
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
            }));
        }
        #endregion//End Methods
    }
}
