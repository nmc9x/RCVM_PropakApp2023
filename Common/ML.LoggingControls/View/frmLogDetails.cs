using ML.LoggingControls.Controller;
using ML.LoggingControls.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ML.LoggingControls.View
{
    public partial class frmLogDetails : Form
    {
        #region Properties
        //
        #endregion//End Properties
        public frmLogDetails(LoggingModel logs)
        {
            InitializeComponent();
            LoggingController.UpdateIcon(this);
            lblCommand.Visible =
            lblCommandValue.Visible = false;
            SetLanguage();
            DataBinding(logs);
            InitEvents();
        }

        #region Init
        private void InitEvents()
        {
            this.Load+=frmLogDetails_Load;
            btnOK.Click+=btnOK_Click;
        }
        #endregion//End Inits

        #region Events
        private void frmLogDetails_Load(object sender, EventArgs e)
        {
            //
            lblUser.Visible =
            lblUserValue.Visible = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion//End Events

        #region Methods
        public void SetLanguage()
        {
            this.Text =
            lblTitle.Text = ML.Languages.Languages.LogDetails;
            lblDateTime.Text = ML.Languages.Languages.DateTime;
            lblKeyword.Text = ML.Languages.Languages.KeyInformation;
            lblCommand.Text = ML.Languages.Languages.Command;
            lblMessage.Text = ML.Languages.Languages.Message;
            lblUser.Text = ML.Languages.Languages.Username;
            //
        }

        private void DataBinding(LoggingModel log)
        {
            string strLogType = log.LogType.ToString();
            switch(log.LogType)
            {
                case LoggingType.Error:
                    picType.Image = Properties.Resources.error24x24;
                    strLogType = ML.Languages.Languages.Errors;
                    break;
                case LoggingType.Info:
                default:
                    picType.Image = Properties.Resources.info24x24;
                    strLogType = ML.Languages.Languages.Info;
                    break;
                //case LoggingType.LogedIn:
                //    e.Value = Properties.Resources.Enter16;
                //    break;
                //case LoggingType.LogedOut:
                //    e.Value = Properties.Resources.Exit16;
                //    break;
                case LoggingType.Started:
                    picType.Image = Properties.Resources.start24x24;
                    strLogType = ML.Languages.Languages.Start;
                    break;
                case LoggingType.Stoped:
                    picType.Image = Properties.Resources.stop24x24;
                    strLogType = ML.Languages.Languages.Stop;
                    break;
                case LoggingType.Warning:
                    picType.Image = Properties.Resources.warning24x24;
                    strLogType = ML.Languages.Languages.Warning;
                    break;
            }
            lblTypeValue.Text = strLogType;
            lblDateTimeValue.Text = log.Date.ToString();
            lblKeywordValue.Text = log.KeyWord;
            lblCommandValue.Text = log.Command;
            lblMessageValue.Text = log.Message;
            lblUserValue.Text = log.User;
        }
        #endregion//End Methods
        
    }
}