using ML.LoggingControls.Controller;
using ML.SolutionsProject.Controller;
using ML.SolutionsProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ML.SolutionsProject.View
{
    public partial class frmMain : Form
    {
        #region Properties
        private bool _IsExc = false;
        #endregion//End Properties
        public frmMain()
        {
            InitializeComponent();
            InitControls();
            InitEvents();
            InitData();
        }

        #region Inits
        /// <summary>
        /// Linh.Tran_230808
        /// Init UI - Default values of controls
        /// </summary>
        private void InitControls()
        {

        }

        /// <summary>
        /// Linh.Tran_230808: Init Events
        /// </summary>
        private void InitEvents()
        {
            btnViewLogs.Click+=btnViewLogs_Click;
            btnHots.Click+=btnHots_Click;
        }

        /// <summary>
        /// Linh.Tran_230808: Init Data
        /// </summary>
        private void InitData()
        {

        }

        #endregion//End Inits

        #region Events
        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            if(!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //Do task
                    LoggingController.ShowViewLogs(false);
                    //End Do task
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

        private void btnHots_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //Do task
                    APIController.LinkAPI = "http://113.163.69.8:9594";
                    Stopwatch st = Stopwatch.StartNew();
                    //Step 1
                    APILoginModel.Root a1 = APIController.APILogin("123456", "123456");//300ms
                    //Step 2
                    APIGetUserNameInfoModel.Root a2 = APIController.APIGetUserNameInfo("123456");//20ms
                    string createBy_UserCode = a2.data.UserCode;
                    string createBy_UserName = a2.data.UserName;
                    string agentCodeFrom = a2.data.AgentCode;
                    string branhCode = a2.data.BranchCode;
                    //Step 3: Get Agent to
                    APIGetAgentInforByConditionModel.Root a3 = APIController.APIGetAgentInfo(0);//100ms => Datetime will errors
                    string agentCodeTo = a3.data[0].AgentCode;
                    string branhCodeTo = a3.data[0].BranchCode;
                    //Step 4: Get list product
                    //APIGetProductInfoModel.Root a4 = APIController.APIGetProductInfo("PDateCreate", 1, -1, 1, 1000, "DCM002");//~300ms
                    APIGetProductInfoModel.Root a4 = APIController.APIGetProductInfo();//~300ms
                    string proCode = a4.data[0].PCode;
                    string Pdate = a4.data[0].PDateCreate;
                    //=> Submits - Start
                    //Step 5: Get ID schedule
                    APIInsertAgentProductModel.Root a5 = APIController.APInsertAgentProduct(agentCodeFrom, agentCodeTo, proCode, DateTime.Now, 100, createBy_UserCode);//Failed ~30ms
                    string id = a5._id;
                    //Step 6: Send Serial number to Distribution
                    APIInsertDistributorAndActiveModel.Root a6 = APIController.APIInsertDistributorAndActive(id, "07300M01C1", "", DateTime.Now, DateTime.Now, createBy_UserName);//Failed ~30ms
                    //-----
                    //Step 5 - 1: Active chip
                    //APIActiveSerialProductModel.Root a7 = APIController.APIActiveSerialProduct("07300M01C1", DateTime.Now, DateTime.Now, "");//10545ms
                    APIActiveSerialProductModel.Root a7 = APIController.APIActiveSerialProduct("07300M01C1",null, null, "");//10545ms with have datetime, 7s with only PBarData
                    st.Stop();
                    label1.Text = st.ElapsedMilliseconds.ToString();
                    //End Do task
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
        #endregion//End Events

        #region Methods
        #endregion//End Methods

       
    }
}
