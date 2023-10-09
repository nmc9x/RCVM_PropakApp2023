using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.Common.Controller;
using ML.Languages;
using App.PVCFC_RFID.Controller;
using ML.Controls;

namespace App.PVCFC_RFID.Design
{
    public partial class ucSettingSystemsJobItems : UserControl
    {
        #region Properties
        private int _Index = 0;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        private string _Title = "";
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;

                CommonFunctions.Invoke(this, new Action(() =>
                {
                    gRFIDConfig.Text = _Title;
                }));
            }
        }

        private bool _IsBinding = false;
        #endregion//End Properties

        #region Events
        #endregion//End Events

        public ucSettingSystemsJobItems()
        {
            InitializeComponent();
            //
            InitControls();
            InitLanguages();
            InitEvents();
        }

        #region Inits
        private void InitControls()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                    //
                    lblURL.Visible =
                    txtURL.Visible =
                    btnPingUrl.Visible = false;
                }));
        }

        private void InitLanguages()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                gRFIDConfig.Text = Languages.Job;
                lblURL.Text = Languages.HostName;
                lblIP.Text = Languages.IPAddress;
                lblPort.Text = Languages.Port;
                //
                btnPingUrl.Text = Languages.Ping;
                btnPingIP.Text = Languages.Ping;
            }));
        }

        private void InitEvents()
        {
            this.Load += ucStationInfo_Load;
            //
            btnPingUrl.Click+=btnPing_Click;
            btnPingIP.Click += btnPing_Click;
            //
            btnSettings.Click+=btnSettings_Click;
            btnWebConfig.Click+=btnWebConfig_Click;
        }

        private void InitData()
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }
        #endregion//End Inits

        #region Events
        private void ucStationInfo_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                string pingAddress = "";
                try
                {
                    _IsBinding = true;
                    int pingPort = 80;
                    System.Net.NetworkInformation.PingReply pingResult = null;
                    MessageBoxIcon pingIcon = MessageBoxIcon.Information;
                    string strResult = "";
                    if (sender == btnPingUrl)
                    {
                        pingAddress = txtURL.Text;
                        if(SharedFunctions.PingURLAdrress(pingAddress))
                        {
                            pingIcon = MessageBoxIcon.Information;
                            strResult = Languages.Status + " :  " + Languages.Success;
                        }
                        else
                        {
                            pingIcon = MessageBoxIcon.Error;
                            strResult = Languages.Status + " :  " + Languages.Failed;
                        }
                        MessageBox.Show(new Form { TopMost = true }, strResult, Languages.PingResult + " - " + pingAddress, MessageBoxButtons.OK, pingIcon);
                    }
                    else if (sender == btnPingIP)
                    {
                        SharedFunctions.Invoke(this, new Action(() =>
                            {
                                //btnPingIP.BackgroundImage = Properties.Resources.Spinner;
                                btnPingIP.Text = Languages.Waiting;
                            }));
                        ControlFunctions.ShowLoading(this.ParentForm);
                        //
                        new System.Threading.Thread(() =>
                        {
                            pingAddress = txtIPAddrress.Text;
                            pingPort = (int)numPort.Value;
                            //pingResult = SharedFunctions.PingIPAdrress(pingAddress, pingPort);//Only Pind IP not Port
                            string strPingResult = SharedFunctions.PingHost(pingAddress, pingPort);
                            if (strPingResult =="")
                            {
                                strResult = Languages.Status + " :  " + Languages.Success.ToLower();
                                strResult += "\n" + Languages.Address + ": " + pingAddress;
                                strResult += "\n" + Languages.Port + ": " + pingPort;
                                pingIcon = MessageBoxIcon.Information;
                            }
                            else
                            {
                                pingIcon = MessageBoxIcon.Error;
                                strResult = Languages.PleaseCheckIPAndPortOfDevices + "\n" + strPingResult;
                            }
                            SharedFunctions.Invoke(this, new Action(() =>
                            {
                                btnPingIP.BackgroundImage = null;
                                btnPingIP.Text = Languages.Ping;
                            }));
                            ControlFunctions.CloseLoading();
                            MessageBox.Show(new Form{TopMost = true}, strResult, Languages.PingResult + " - " + pingAddress, MessageBoxButtons.OK, pingIcon);
                        }).Start();
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(new Form { TopMost = true }, ex.Message, Languages.PingResult + " - " + pingAddress, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    var frm = new frmSettingDM60X(_Index);
                   
                    //frmSettingsRFIDZebra frm = new frmSettingsRFIDZebra(_Index);
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Location = SharedValues.Running.ChildFormLocations;
                    frm.Size = SharedValues.Running.ChildFormSize;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }

        private void btnWebConfig_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    string url = @"https://" + txtIPAddrress.Text;//txtURL.Text
                    ControlFunctions.ShowLoading(this.ParentForm);
                    frmWebView frm = new frmWebView(_Index, url);
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Location = SharedValues.Running.ChildFormLocations;
                    frm.Size = SharedValues.Running.ChildFormSize;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }
        #endregion//End Events

        #region Methods
        public void LoadData()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                //txtIPAddrress.Text = SharedValues.Settings.StationList[_Index].RFID.IP;
                //numPort.Value = SharedValues.Settings.StationList[_Index].RFID.Port;
                //txtURL.Text = SharedValues.Settings.StationList[_Index].RFID.HostNameURL;

                txtIPAddrress.Text = SharedValues.Settings.StationList[_Index].DM60X.IPAddress;
                numPort.Value = int.Parse(SharedValues.Settings.StationList[_Index].DM60X.Port);
                txtURL.Text = "";
            }));
        }

        public void SaveData()
        {
            //SharedValues.Settings.StationList[_Index].RFID.IP = txtIPAddrress.Text;
            //SharedValues.Settings.StationList[_Index].RFID.Port = (int)numPort.Value;
            //SharedValues.Settings.StationList[_Index].RFID.HostNameURL = txtURL.Text;

             SharedValues.Settings.StationList[_Index].DM60X.IPAddress = txtIPAddrress.Text;
             SharedValues.Settings.StationList[_Index].DM60X.Port = numPort.Value.ToString();
             
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
