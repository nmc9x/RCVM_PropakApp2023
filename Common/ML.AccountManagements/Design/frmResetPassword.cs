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
    public partial class frmResetPassword : Form
    {
        #region Properties
        private bool _IsBinding = false;
        private AccountItemModel _User = null;
        #endregion//End Properties

        public frmResetPassword()
        {
            _User = new AccountItemModel()
            {
                UserName = AccountController.DefaultUser
            };
            InitializeComponent();
            //
            InitControls();
            InitLanguges();
            InitEvents();
            InitData();
        }

        public frmResetPassword(AccountItemModel user)
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
            lblMessages.Visible = false;
            //
            //Default form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            //End Default form

        }

        private void InitLanguges()
        {
            this.Text = AccountController.SWName;
            lblTitle.Text = AccountController.SWName + " - " + Languages.Languages.ResetPassword.ToUpper();
            //
            lblUserName.Text = Languages.Languages.Username;
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
            LoadUserData();
        }
        #endregion//End Inits

        #region Events
        private void button_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    if (sender == mlBtnOK)
                    {
                        string strErrors = "";
                        #region Reset password
                        //Check data
                        //Check Null data
                        if (txtNewPassword.Text == "")
                        {
                            strErrors = Languages.Languages.NewPassword + " " + Languages.Languages.CannotBeNull.ToLower() + "\r\n";
                        }
                        else if (txtRetypePassword.Text == "")
                        {
                            strErrors = Languages.Languages.RetypePassword + " " + Languages.Languages.CannotBeNull.ToLower() + "\r\n";
                        }
                        if (strErrors != "")
                        {
                            lblMessages.Visible = true;
                            lblMessages.Text = strErrors;
                            lblMessages.ForeColor = Color.Red;
                            return;
                        }
                        //End Check Null data
                        //Check password and confirm password
                        //End Check password and confirm password
                        if (txtNewPassword.Text != txtRetypePassword.Text)
                        {
                            strErrors = Languages.Languages.PasswordsDoesNotMatch;
                        }
                        if (strErrors != "")
                        {
                            lblMessages.Visible = true;
                            lblMessages.Text = strErrors;
                            lblMessages.ForeColor = Color.Red;
                            return;
                        }
                        //End Check data
                        //Check user exits
                        int indexUser = AccountController.User.UserModelList.FindIndex(u => u.UserName.Equals(txtUserName.Text));
                        if (indexUser < 0)
                        {
                            strErrors = Languages.Languages.Username + " " + Languages.Languages.Exit.ToLower();
                        }
                        if (strErrors != "")
                        {
                            lblMessages.Visible = true;
                            lblMessages.Text = strErrors;
                            lblMessages.ForeColor = Color.Red;
                            return;
                        }
                        //End Check user exits
                        //Save accounts
                        try
                        {
                            string curUser = AccountController.User.UserModelList[indexUser].UserName;
                            string newPass = txtNewPassword.Text;
                            AccountController.ChangePasswordUser(curUser, newPass);
                            //End Save accounts
                            //Write logs
                            ML.LoggingControls.Controller.LoggingController.AddHistory(
                                           Languages.Languages.Account,
                                          Languages.Languages.ResetPassword + " " + Languages.Languages.User.ToLower(),
                                           Languages.Languages.Username + " " + ": " + _User.UserName,
                                           AccountController.LogedInUserName,
                                           LoggingControls.Model.LoggingType.Info);
                            //End Write logs
                            lblMessages.Text = Languages.Languages.TheOperationCompletedSuccessfully;
                            lblMessages.ForeColor = Color.Green;
                        }
                        catch (Exception ex)
                        {
                            lblMessages.Visible = true;
                            lblMessages.Text = ex.Message;
                            lblMessages.ForeColor = Color.Red;
                        }
                        #endregion//End Reset password
                    }
                    else if (sender == mlBtnCancel)
                    {
                        #region Cancel
                        this.Close();
                        #endregion//End Cancel
                    }
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }
        #endregion//End Events

        #region Methods
        private void LoadUserData()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                txtUserName.Enabled = false;
                txtUserName.Text = _User.UserName;
            }));
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

                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
