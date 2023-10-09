using ML.AccountManagements.Controller;
using ML.Common.Controller;
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
    public partial class frmChangePassword : Form
    {
        #region Properties
        #endregion//End Properties

        public frmChangePassword()
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
            pictureBox1.Visible = false;
            lblMessage.Visible = false;
            //
            //Default form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            //End Default form

        }

        private void InitLanguges()
        {
            this.Text = AccountController.SWName;
            lblTitle.Text = AccountController.SWName + " - " + Languages.Languages.ChangePassword.ToUpper();
            //
            lblUserName.Text = Languages.Languages.Username;
            lblCurPassword.Text = Languages.Languages.CurrentPassword;
            lblNewPassword.Text = Languages.Languages.NewPassword;
            lblRetypePassword.Text = Languages.Languages.RetypePassword;
            //Button controls
            mlBtnOK.Text = Languages.Languages.OK;
            mlBtnCancel.Text = Languages.Languages.Cancel;
        }

        private void InitEvents()
        {
            mlBtnOK.Click += button_Click;
            mlBtnCancel.Click += button_Click;
        }

        private void InitData()
        {
            CommonFunctions.Invoke(this, new Action(() =>
                {
                    txtUserNameUserName.Text = AccountController.LoginUser.UserName;
                    txtUserNameUserName.Enabled = false;
                    txtCurrentPassword.Focus();
                }));
        }
        #endregion//End Inits

        #region Events
        private void button_Click(object sender, EventArgs e)
        {
            if (sender == mlBtnCancel)
            {
                Close();
            }
            else if (sender == mlBtnOK)
            {
                ProcessChangePassword();
            }
        }
        #endregion//End Events

        #region Methods
        private void ProcessChangePassword()
        {
            lblMessage.ForeColor = Color.Red;
            //check current password
            string strErrors = "";
            String currentUser = AccountController.LoginUser.UserName;
            String olPassword = txtCurrentPassword.Text;
            int userIndex = AccountController.User.UserModelList.FindIndex(u => u.UserName.Equals(currentUser));
            if (userIndex >= 0)
            {
                if (AccountController.User.UserModelList[userIndex].Password != txtCurrentPassword.Text.Trim())
                {
                    strErrors = Languages.Languages.MsgPasswordIsIncorrect;
                    txtCurrentPassword.Focus();
                    //
                    lblMessage.Text = strErrors;
                    lblMessage.Visible = true;
                    return;
                }
            }
            else
            {
                strErrors = (strErrors.Length > 0) ? Languages.Languages.AccountIsNotExist : (Languages.Languages.AccountIsNotExist + "\r\n" + strErrors);
                //
                lblMessage.Text = strErrors;
                lblMessage.Visible = true;
                return;
            }

            //check password length
            String newPass = txtNewPassword.Text;
            if (newPass.Length < 0)
            {
                lblMessage.Text = Languages.Languages.Password + " " + Languages.Languages.CannotBeNull.ToLower();
                lblMessage.Visible = true;
                return;
            }

            //check re-type password
            String retypePass = txtRetypePassword.Text;
            if (retypePass != newPass)
            {
                lblMessage.Text = Languages.Languages.MsgPasswordNotMatch;
                lblMessage.Visible = true;
                return;
            }

            //do change password
            try
            {
                AccountController.ChangePasswordUser(AccountController.LoginUser.UserName, newPass);
                lblMessage.Text = Languages.Languages.ChangePassword + " " + Languages.Languages.Success.ToLower();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Visible = true;
                //
                LoggingControls.Controller.LoggingController.AddHistory(
                                    Languages.Languages.ChangePassword,
                                     Languages.Languages.ChangePassword,
                                    Languages.Languages.ChangePassword + " " + Languages.Languages.Success.ToLower(),
                                    AccountController.LogedInUserName, LoggingControls.Model.LoggingType.Info);
            }
            catch (Exception ex)
            {
                LoggingControls.Controller.LoggingController.AddHistory(
                                    Languages.Languages.ChangePassword,
                                    Languages.Languages.ChangePassword,
                                    Languages.Languages.ChangePassword + " " + Languages.Languages.Failed.ToLower(),
                                    AccountController.LogedInUserName, LoggingControls.Model.LoggingType.Error);
                lblMessage.Visible = true;
            }
            //Close();
        }

        #endregion//End Methods

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                    ProcessChangePassword();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
