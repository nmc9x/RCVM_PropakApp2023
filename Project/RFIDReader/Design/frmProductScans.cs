using ML.Common.Controller;
using ML.Connections.DataType;
using ML.Languages;
using App.DevCodeActivatorRFID.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.SDK.RFID.Model;

namespace App.DevCodeActivatorRFID.Design
{
    public partial class frmProductScans : Form
    {
        #region Properties
        private bool _IsExc = false;
        private bool _IsCloseForm = false;
        private Thread _ThreadLoadData = null;
        private int _OldCountDataScanned = -1;
        #endregion//End Properties

        public frmProductScans()
        {
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
            txtCheckDataValue.Text = "PL001";
        }

        private void InitLanguages()
        {
            this.Text = Languages.DataScannedResults;
            lblTitle.Text = Languages.DataScannedResults;
            chkShowAll.Text = Languages.ShowAll;
            btnReadRFID.Text = Languages.ReadRFID;
            btnClear.Text = Languages.Clear;
            btnCheckData.Text = Languages.CheckData;
        }

        private void InitEvents()
        {
            this.FormClosed+=frmProductScans_FormClosed;
            //
            chkShowAll.CheckedChanged+=chkShowAll_CheckedChanged;
            btnClear.Click+=btnClear_Click;
            btnReadRFID.Click +=btnReadRFID_Click;
            btnCheckData.Click+=btnCheckData_Click;
            //
            btnFirst.Click+=btnControls_Click;
            btnBack.Click += btnControls_Click;
            btnNext.Click += btnControls_Click;
            btnLast.Click += btnControls_Click;
            //Data gridView
            dataGridView1.RowPostPaint += dgvUser_RowPostPaint;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvUser_CellFormatting);
            dataGridView1.SelectionChanged += dgvUser_SelectionChanged;
            //
            SharedEvents.RFIDDeviceDataReceived += SharedEvents_RFIDEventsDataReceived;
        }

        private void InitData()
        {
            Thread threadLoadData = new Thread(() =>
            {
                while (!_IsCloseForm)
                {
                    //
                    Thread.Sleep(200);//Linh.Tran_230622: 1s update scan data
                }
            });
            threadLoadData.IsBackground = true;
            threadLoadData.Start();
        }
        #endregion//End Inits

        #region Events

        private void frmProductScans_FormClosed(object sender, EventArgs e)
        {
            //Kill thread insert database
            _IsCloseForm = true;
            //
            if (_ThreadLoadData != null && _ThreadLoadData.IsAlive)
            {
                //release thread
                _ThreadLoadData.Abort();
                _ThreadLoadData = null;
                //
            }
            //
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Languages.Errors, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _IsExc = false;
                }
            }
        }
    
        private void btnReadRFID_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    
                }
                catch (Exception ex) { }
                finally
                {
                    _IsExc = false;
                }
            }
            //SharedValues.Settings.PLC.SendCommand(PLCEnum.CommandEnum.SetTrigger);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //
                    //
                    //LoadData();
                    _OldCountDataScanned =-1;

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                }
            }
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //
                    //LoadData();
                    _OldCountDataScanned = -1;

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                }
            }
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

        }
        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        //
        private void SharedEvents_RFIDEventsDataReceived(object sender, EventArgs e)
        {
            if(!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //LoadData();
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    _IsExc = false;
                }
            }
        }
        #endregion//End Events

        #region Methods

        private void LoadData()
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
                    List<RFIDScanDataModel> tempDataList = null;
                    //Binding data to data gridview
                    if (chkShowAll.Checked)
                    {
                        
                    }
                    else
                    {
                        
                    }
                    dataGridView1.DataSource = null;
                    //
                    dataGridView1.DataSource = tempDataList;
                    //
                    dataGridView1.AllowUserToAddRows = false;
                    //
                    dataGridView1.Columns["ChipID"].HeaderText = Languages.ChipID;
                    dataGridView1.Columns["Data"].HeaderText = Languages.Data;
                    //
                    dataGridView1.Columns["ChipID"].ReadOnly = true;
                    dataGridView1.Columns["Data"].ReadOnly = true;
                    //
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //
                    //lblTotalRows.Text = ML.Languages.KeysCodeCount + ": " + dataGridView1.RowCount.ToString("N0");
                    //lblTotalRows.Text = Languages.CodeCount + ": " + tempDataList.Count.ToString("N0") + "/" + SharedValues.Running.RFID.ScanDataList.Count().ToString("N0");
                    SelectProductItems(tempDataList.Count - 1);
                }));
                //
                //SelectProductItems(dataGridView1.RowCount - 1);
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
    }
}
