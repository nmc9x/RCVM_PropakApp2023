using ML.AccountManagements.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ML.AccountManagements.Design
{
    public partial class frmAccountDetails : Form
    {
        #region Properties
        #endregion//End Properties
        public frmAccountDetails()
        {
            InitializeComponent();
            //
            InitControls();
            InitLanguges();
            InitEvents();
            InitData();
        }

        #region Inits
        private void InitControls()
        {
            //Default form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            //End Default form

        }

        private void InitLanguges()
        {
            this.Text = AccountController.SWName;
            lblLogin.Text = AccountController.SWName + " - " + Languages.Languages.Login.ToUpper();
            //Online
            tabControlMainPageLoginOnline.Text = Languages.Languages.Online;
            lblUserNameOnline.Text = Languages.Languages.Username;
            lblPasswordOnline.Text = Languages.Languages.Password;
            
            //Offline
            tabControlMainPageLoginOffline.Text = Languages.Languages.Offline;
            lblUserNameOffline.Text = Languages.Languages.Username;
            lblPasswordOffline.Text = Languages.Languages.Password;
            //
            chkRememberAccountOnline.Text = Languages.Languages.RememberLogin;
            //Button controls
            mlBtnLogin.Text = Languages.Languages.Login;
            mlBtnCancel.Text = Languages.Languages.Cancel;
        }

        private void InitEvents()
        {

        }

        private void InitData()
        {

        }
        #endregion//End Inits

        #region Events
        #endregion//End Events

        #region Methods
        #endregion//End Methods
    }
}
