using ML.AccountManagements.Controller;
using ML.Common.Controller;
using ML.LoggingControls.Controller;
using ML.LoggingControls.Model;
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

namespace ML.AccountManagements.Design
{
    public partial class frmLogin : Form
    {
        #region Properties
        private bool _IsExc = false;
        #endregion//End Properties
        public frmLogin()
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
            CommonFunctions.Invoke(this, new Action(() =>
               {
                   this.TopMost = true;
                   //Default form
                   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                   this.StartPosition = FormStartPosition.CenterScreen;
                   //this.BackColor = Color.White;
                   //End Default form
                   pictureBox1.Visible = false;
                   lblMsg.Visible = false;
                   tabControlMain.SelectedTab = tabControlMainPageLoginOnline;
               }));
        }

        private void InitLanguges()
        {
            CommonFunctions.Invoke(this, new Action(() =>
                {
                    this.Text = AccountController.SWName + "- " + AccountController.SWVersion;
                    lblLogin.Text = AccountController.SWName + " - " + Languages.Languages.Login.ToUpper();
                    lblMsg.Text = Languages.Languages.MsgPleaseWait;
                    //Online
                    tabControlMainPageLoginOnline.Text = Languages.Languages.Online;
                    lblUserNameOnline.Text = Languages.Languages.Username;
                    lblPasswordOnline.Text = Languages.Languages.Password;
                    //
                    //Offline
                    tabControlMain.Text = Languages.Languages.Offline;
                    lblUserNameOffline.Text = Languages.Languages.Username;
                    lblPasswordOffline.Text = Languages.Languages.Password;
                    //
                    chkRememberAccountOnline.Text = Languages.Languages.RememberLogin;
                    //Button controls
                    mlBtnLogin.Text = Languages.Languages.Login;
                    mlBtnCancel.Text = Languages.Languages.Cancel;
                    //
                    lblLinkServer.Text = Languages.Languages.LinkServer + ": " + AccountController.LinkAPI;
                }));
        }

        private void InitEvents()
        {
            this.Load += frmLogin_Load;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            mlBtnLogin.Click += mlBtnLogin_Click;
            mlBtnCancel.Click += mlBtnCancel_Click;
            //
        }

        private void InitData()
        {
            AccountController.LoadAccountSettings();
            LoadData();
        }
        #endregion//End Inits

        #region Events
        private void frmLogin_Load(object sender, EventArgs e)
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                txtUserNameOnline.Focus();
            }));
            
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //
                    if(tabControlMain.SelectedTab == tabControlMainPageLoginOnline)
                    {
                        txtUserNameOnline.Focus();
                    }
                    else if (tabControlMain.SelectedTab == tabControlMainPageLoginOffline)
                    {
                        txtUserNameOffline.Focus();
                    }
                    //

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

        private void mlBtnLogin_Click(object sender, EventArgs e)
        {
            if(!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    // Start BackgroundWorker
                    string userName = txtUserNameOnline.Text;
                    string password = txtPasswordOnline.Text;
                    bool isLoginOffline = false;
                    //
                    string strErrors = CheckUserData();
                    if (strErrors == "")
                    {
                        CommonFunctions.Invoke(this, new Action(() =>
                        {
                            pictureBox1.Visible = true;
                            lblMsg.Visible = true;
                            
                        }));
                        //
                        Thread loginThread = new Thread(() =>
                            {
                                try
                                {
                                    CommonFunctions.Invoke(this, new Action(() =>
                                    {
                                        mlBtnLogin.Enabled = false;
                                        if (tabControlMain.SelectedTab == tabControlMainPageLoginOffline)
                                        {
                                            userName = txtUserNameOffline.Text;
                                            password = txtPasswordOffline.Text;
                                            isLoginOffline = true;
                                        }
                                    }));
                                    if (isLoginOffline)
                                    {
                                        strErrors = AccountController.Login(userName.Trim(), password);
                                    }
                                    else
                                    {
                                        strErrors = AccountController.APILogin(userName.Trim(), password);
                                    }
                                    AccountController.Settings.IsOnlineUser = !isLoginOffline;
                                    //
                                    CommonFunctions.Invoke(this, new Action(() =>
                                    {
                                        pictureBox1.Visible = false;
                                        lblMsg.Visible = false;
                                        mlBtnLogin.Enabled = true;
                                    }));
                                    if (strErrors == "")
                                    {
                                        //Save Data
                                        SetData();
                                        AccountController.SaveAccountSettings();
                                        //
                                        //Write logs
                                        LoggingController.AddHistory(Languages.Languages.Account,
                                        Languages.Languages.Login + " " + Languages.Languages.Account,
                                        Languages.Languages.Login + " " + Languages.Languages.Success
                                        + ". \r\n"
                                        + Languages.Languages.Informations + ":"
                                        + Languages.Languages.Username + "-" + AccountController.LoginUser.UserName,
                                        AccountController.LoginUser.UserName,
                                        LoggingType.Info);
                                        CommonFunctions.Invoke(this, new Action(() =>
                                        {
                                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                            this.Close();
                                        }));
                                    }
                                    else
                                    {
                                        MessageBox.Show(new Form{TopMost = true}, Languages.Languages.Failed + ".\r\n" + strErrors + "\r\n" + Languages.Languages.PleaseTryAgain, Languages.Languages.Login, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(new Form { TopMost = true }, ex.Message, Languages.Languages.Login, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    _IsExc = false;
                                }
                            });
                        loginThread.IsBackground =true;
                        loginThread.Start();
                    }
                    else
                    {
                        MessageBox.Show(strErrors, Languages.Languages.Login, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _IsExc = false;
                    }
                    
                    //
                    //
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    //_IsExc = false;
                }
            }
        }

        private void mlBtnCancel_Click(object sender, EventArgs e)
        {
            if (!_IsExc)
            {
                try
                {
                    _IsExc = true;
                    //Application.Exit();
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
        private string CheckUserData()
        {
            string strErrors = "";
            CommonFunctions.Invoke(this, new Action(() =>
            {
                if (tabControlMain.SelectedTab == tabControlMainPageLoginOffline)
                {
                    if (txtPasswordOffline.Text.Trim() == "")//Linh.Tran_210326: Check NULL Pass
                    {
                        strErrors = Languages.Languages.Password + " " + Languages.Languages.CannotBeNull.ToLower() + "\r\n" + strErrors;
                        txtPasswordOffline.Focus();
                    }
                    if (txtUserNameOffline.Text.Trim() == "")//Linh.Tran_210326: Check NULL UserName
                    {
                        strErrors = Languages.Languages.Username + " " + Languages.Languages.CannotBeNull.ToLower() + "\r\n" + strErrors;
                        txtUserNameOffline.Focus();
                    }
                }
                else 
                {
                    if (txtPasswordOnline.Text.Trim() == "")//Linh.Tran_210326: Check NULL Pass
                    {
                        strErrors = Languages.Languages.Password + " " + Languages.Languages.CannotBeNull + "\r\n" + strErrors;
                        txtPasswordOnline.Focus();
                    }
                    if (txtUserNameOnline.Text.Trim() == "")//Linh.Tran_210326: Check NULL UserName
                    {
                        strErrors = Languages.Languages.Username + " " + Languages.Languages.CannotBeNull + "\r\n" + strErrors;
                        txtUserNameOnline.Focus();
                    }
                }
            }));
            return strErrors;
        }

        private void LoadData()
        {
            CommonFunctions.Invoke(this, new Action(()=>
                {
                    txtUserNameOnline.Text = AccountController.Settings.UserNameOnline;
                    txtPasswordOnline.Text = AccountController.Settings.PassWordOnline;
                    //
                    chkRememberAccountOnline.Checked = AccountController.Settings.IsRememberUsrer;
                    //
                    txtUserNameOffline.Text = AccountController.Settings.UserNameOffline;
                    txtPasswordOffline.Text = AccountController.Settings.PasswordOffline;
                }));
        }

        private void SetData()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                AccountController.Settings.UserNameOnline = txtUserNameOnline.Text;
                AccountController.Settings.PassWordOnline = txtPasswordOnline.Text;
                //
                AccountController.Settings.IsRememberUsrer = chkRememberAccountOnline.Checked;
                //
                AccountController.Settings.UserNameOffline = txtUserNameOffline.Text;
                AccountController.Settings.PasswordOffline = txtPasswordOffline.Text;
            }));
        }

        #endregion//End Methods

    }
}
