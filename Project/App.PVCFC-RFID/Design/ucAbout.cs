using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.PVCFC_RFID.Controller;
using System.IO;
using ML.Languages;
using ML.AccountManagements.Controller;

namespace App.PVCFC_RFID.Design
{
    public partial class ucAbout : UserControl
    {
        public ucAbout()
        {
            InitializeComponent();
            InitControls();
            InitLanguages();
            InitEvents();
        }

        #region Inits
        private void InitControls()
        {
            SharedFunctions.Invoke(this, new Action(()=>
                {
                    rchReleaseNote.ReadOnly = true;
                }));
        }

        private void InitLanguages()
        {
            SharedFunctions.Invoke(this, new Action(() =>
               {
                   grbGeneralInfo.Text = Languages.GeneralInfo;
                   gServerActivation.Text = Languages.ServerActivation;
                   grbReleaseNote.Text = Languages.ReleaseNote;
               }));
        }

        private void InitEvents()
        {
            this.Load+=ucAbout_Load;
        }
        #endregion//End Inits

        #region Events
        private void ucAbout_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion//End Evemts

        #region Methods
        private void LoadData()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    //Load Infor
                    string strInfo = Languages.ApplicationName + ": " + Properties.Settings.Default.SoftwareName;
                    strInfo += "\n" + Languages.Version + ": " + Properties.Settings.Default.Version;
                    lblGeneralInfo.Text = strInfo;
                    //
                    //Load Infor Server Activation
                    string strInfoServer = Languages.LinkServer + ": " + SharedValues.Settings.SysServerURL + ":" + SharedValues.Settings.SysServerPort;
                    strInfoServer += "\n" + Languages.LoginAccount + ": " + AccountController.LogedInUserName;
                    lblServerActivation.Text = strInfoServer;
                    //
                    //load readme
                    string path = Application.StartupPath + "\\Label\\Readme.txt";
                    switch(Languages.Culture.ToString())
                    {
                        case "vi-VN":
                            path = Application.StartupPath + "\\Label\\Readme.vi-VN.txt";
                            break;
                    }
                    if (File.Exists(path))
                    {
                        String text = File.ReadAllText(path, Encoding.UTF8);
                        rchReleaseNote.Text = text;
                    }
                }));
        }
        #endregion//End Methods
    }
}
