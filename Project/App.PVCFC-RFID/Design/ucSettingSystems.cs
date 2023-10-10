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
using ML.Languages;
using ML.Common.Controller;
using App.PVCFC_RFID.Model;

namespace App.PVCFC_RFID.Design
{
    public partial class ucSettingSystems : UserControl
    {
        #region Properties
        private bool _IsBinding = false;
        private List<ucSettingSystemsJobItems> _JobList = new List<ucSettingSystemsJobItems>();
        #endregion//End Properties

        public ucSettingSystems()
        {
            InitializeComponent();
            //
            InitControls();
            InitLanguages();
            InitEvents();
            InitData();
        }

        #region Init
        private void InitControls()
        {
            CommonFunctions.Invoke(this, new Action(() =>
            {
                //First Job
                ucSettingSystemsJobItems1.Index = 0;
                ucSettingSystemsJobItems1.Title = SharedFunctions.GetStationName(ucSettingSystemsJobItems1.Index);
                _JobList = new List<ucSettingSystemsJobItems>();
                _JobList.Add(ucSettingSystemsJobItems1);
                //
                //Table layout
                this.tbJobConfig.RowCount = 2;//Properties.Settings.Default.NumberOfStation;
                for (int i = 1; i < tbJobConfig.RowCount; i++)
                {
                    tbJobConfig.RowStyles.Insert(i, new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                }
                //End Table layoutf
                //
                for (int i = 1; i < tbJobConfig.RowCount; i++)
                {
                    #region Station Parameters
                    //Parameters
                    ucSettingSystemsJobItems ucParams = new ucSettingSystemsJobItems();
                    ucParams.Name = "ucSettingSystemsJobItems" + (i + 1).ToString();
                    ucParams.Title = SharedFunctions.GetStationName(i);
                    ucParams.Index = i;
                    ucParams.Anchor = ucSettingSystemsJobItems1.Anchor;
                    ucParams.Location = ucSettingSystemsJobItems1.Location;
                    ucParams.Margin = ucSettingSystemsJobItems1.Margin;
                    ucParams.MaximumSize = ucSettingSystemsJobItems1.MaximumSize;
                    ucParams.Size = ucSettingSystemsJobItems1.Size ;
                    ucParams.TabIndex = i;
                    //End Parameters
                    #endregion//End Station Parameters
                    //
                    //Add to Table layout
                    tbJobConfig.Controls.Add(ucParams, 0, i);
                    //
                    //Add to UI List
                    _JobList.Add(ucParams);
                }
            }));
        }

        private void InitLanguages()
        {
            SharedFunctions.Invoke(this, new Action(() =>
                {
                    gServerConfig.Text = Languages.ServerActivation;
                    lblURL.Text = Languages.IPAddress + "/ " + Languages.URL;
                    lblPort.Text = Languages.Port;
                    btnPing.Text = Languages.Ping;
                    //
                    gSaveDataConfig.Text = Languages.SaveDataLocations;
                    lblFileDataPath.Text = Languages.Path;
                    btnFileDataBrowser.Text = "...";
                    btnBackup.Text = Languages.Backup;
                    btnRestore.Text = Languages.Restore;
                    btnApply.Text = Languages.Apply;
                    //
                    gJobConfig.Text = Languages.Config + " " + Properties.Settings.Default.StationName;
                }));
        }

        private void InitEvents()
        {
            btnPing.Click+=btnPing_Click;
            //
            txtFileDataPath.Click += txtFileDataPath_Click;
            btnFileDataBrowser.Click+=btnFileDataBrowser_Click;
            //
            btnApply.Click+=btnApply_Click;
            btnBackup.Click += BtnBackup_Click;
            btnRestore.Click += BtnRestore_Click;
        }

        private void InitData()
        {
            LoadData();
        }

        #endregion//End Init

        #region Events
        private void btnPing_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                string pingAddress = "";
                try
                {
                    _IsBinding = true;
                    pingAddress = txtIPAddressURL.Text + ":" + numPort.Value.ToString();
                    MessageBoxIcon pingIcon = MessageBoxIcon.Information;
                    string strResult = "";
                    //
                    if (SharedFunctions.PingURLAdrress(pingAddress))
                    {
                        pingIcon = MessageBoxIcon.Information;
                        strResult = Languages.Status + " :  " + Languages.Success;
                        strResult += "\n" + Languages.Address + ": " + pingAddress;
                    }
                    else
                    {
                        pingIcon = MessageBoxIcon.Error;
                        strResult = Languages.Status + ":  " + Languages.Failed;
                        strResult += "\n" + Languages.Address + ": " + pingAddress;
                    }
                    MessageBox.Show(strResult, Languages.PingResult, MessageBoxButtons.OK, pingIcon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Languages.PingResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _IsBinding = false;
                }
            }
        }

        private void txtFileDataPath_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    string folder = txtFileDataPath.Text;
                    if (System.IO.Directory.Exists(folder))
                    {
                        SharedFunctions.OpenFolder(folder);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(new System.Windows.Forms.Form { TopMost = true }, Languages.FolderDoseNotExist, Languages.SystemSettings, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
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

        private void btnFileDataBrowser_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        txtFileDataPath.Text = fbd.SelectedPath;
                    }
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!_IsBinding)
            {
                try
                {
                    _IsBinding = true;
                   
                    DialogResult result = DialogResult.OK;
                    result = MessageBox.Show(Languages.TheApplicationsMustBeRestartToComplete + "\n" + Languages.MsgDoYouWantToContinue,
                        Languages.SystemSettings, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        SaveData();
                        SharedEvents.RaiseRestartAppEvents(null);
                    }
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

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                using (var file = new OpenFileDialog())
                {
                    file.Filter = "Config Files (*.cf)|*.cf";
                    file.Title = "Select config file to restore";
                    file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        if (file.CheckFileExists)
                        {
                            LoadDataByUser(file.FileName);
                            MessageBox.Show(Languages.MsgRestoreParameterSuccessfully, Languages.RestoreNotify, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch
            {
                MessageBox.Show(Languages.MsgRestoreParameterUnsuccessfully, Languages.RestoreNotify, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = Languages.ChooseAFolder;
                    folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        var selectedFolderPath = folderBrowserDialog.SelectedPath;
                        var fullpath = selectedFolderPath + "//config" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".cf";
                        SaveDataByUser(fullpath);
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch
            {
                MessageBox.Show(Languages.MsgBackupParameterUnsuccessfully, Languages.BackupNotify, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }
        #endregion//End Events

        #region Methods
        private void LoadData()
        {
            txtIPAddressURL.Text = SharedValues.Settings.SysServerURL;
            numPort.Value = SharedValues.Settings.SysServerPort;
            txtFileDataPath.Text = SharedValues.Settings.SysDisShInfoPath;
            //
            //
            foreach (ucSettingSystemsJobItems job in _JobList)
            {
                job.LoadData();
            }
            //
        }

        private void SaveData()
        {
            try
            {
                SharedValues.Settings.SysServerURL = txtIPAddressURL.Text;
                SharedValues.Settings.SysServerPort = (int)numPort.Value;
                SharedValues.Settings.SysDisShInfoPath = txtFileDataPath.Text;
                //
                foreach (ucSettingSystemsJobItems job in _JobList)
                {
                    job.SaveData();
                }
                //
                SharedFunctions.SaveSettings();
                MessageBox.Show(Languages.TheOperationCompletedSuccessfully + "\n" + Languages.TheApplicationsWillBeRestart, Languages.Save + " " + Languages.SystemSettings, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Languages.Failed + "\n" + ex.Message, Languages.Save + " " + Languages.SystemSettings, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private void LoadDataByUser(string fileName)
        {
            var newSt = SettingsModel.LoadSetting(fileName);
            txtIPAddressURL.Text = newSt.SysServerURL;
            numPort.Value = newSt.SysServerPort;
            txtFileDataPath.Text = newSt.SysDisShInfoPath;

            //

            //
            foreach (ucSettingSystemsJobItems job in _JobList)
            {
                job.LoadData();
            }
            //
        }

        private void SaveDataByUser(string fullpath)
        {
            try
            {
                SharedValues.Settings.SysServerURL = txtIPAddressURL.Text;
                SharedValues.Settings.SysServerPort = (int)numPort.Value;
                SharedValues.Settings.SysDisShInfoPath = txtFileDataPath.Text;
                //
                foreach (ucSettingSystemsJobItems job in _JobList)
                {
                    job.SaveData();
                }
                //
                SharedValues.Settings.SaveSettings(fullpath);
                MessageBox.Show(Languages.MsgBackupParameterSuccessfully, Languages.BackupNotify, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show(Languages.MsgBackupParameterUnsuccessfully, Languages.BackupNotify, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {

            }
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
