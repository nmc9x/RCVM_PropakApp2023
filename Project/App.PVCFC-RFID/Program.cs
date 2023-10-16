using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.Design;
using ML.AccountManagements.Controller;
using ML.AccountManagements.Design;
using ML.Common.Controller;
using ML.Controls;
using ML.DeviceTransfer.PVCFCRFID.APISAASModel;
using ML.Languages;
using ML.LoggingControls.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.PVCFC_RFID
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //
            #region Show loadings
            ControlFunctions.ShowLoading(new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            #endregion//End Show loadings
            //
            #region Setup Firewall
            #region Delete rule Firewall
            //string strNameSpace = typeof(Program).Namespace;
            string strProductName = Application.ProductName;
            CommonFunctions.ExecuteShellCommand("netsh advfirewall firewall delete rule \"" + strProductName + ".exe" + "\"");
            //
            CommonFunctions.ExecuteShellCommand("netsh advfirewall firewall delete rule \"" + strProductName + ".OUT" + "\"");
            CommonFunctions.ExecuteShellCommand("netsh advfirewall firewall delete rule \"" + strProductName + ".IN" + "\"");
            //
#if DEBUG
            CommonFunctions.ExecuteShellCommand("netsh advfirewall firewall delete rule \"" + strProductName + ".vshost.exe" + "\"");//SW debugs
#endif
            #endregion//End of Delete rule Firewall
            #region Add rule Firewall
            try
            {
                string _RunFileName = System.AppDomain.CurrentDomain.FriendlyName;
                //add main controller port 11900
                CommonFunctions.AddUDPFirewall(strProductName + ".OUT", _RunFileName, 80, "out", "Any", true);
                CommonFunctions.AddUDPFirewall(strProductName + ".IN", _RunFileName, 80, "in", "Any", true);
                //
            }
            catch { }
            #endregion//Linh.Tran: Add rule Firewall-End
            #endregion Setup Firewall
           
            #region Inits Languages
            Languages.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN");
            //
            //Linh.Tran: Register messageBox Languages
            //Set language for button of message box
            //Unregister manager
            MessageBoxManager.Unregister();
            //Set button text from resources
            MessageBoxManager.OK = Languages.OK;
            MessageBoxManager.Cancel = Languages.Cancel;
            //MessageBoxManager.Retry = "Thử lại";
            MessageBoxManager.Ignore = Languages.Ignore;
            //MessageBoxManager.Abort = "Hủy bỏ";
            MessageBoxManager.Yes = Languages.Yes;
            MessageBoxManager.No = Languages.No;

            //Register manager
            MessageBoxManager.Register();
            //END Set language for button of message box
            //
            //Linh.Tran: End Register messageBox Languages
            //
            #endregion//End Inits Languages

            #region Init Config Path
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MLSolutions\" + "PCVFC_RFID" + "\\";
            SharedFunctions.SetPath(rootPath);
            #endregion//End Init Config Path
            //
            #region Inits View logs
            LoggingController.LoggingPath = rootPath + "Histories\\";
            LoggingController.LoginToAccess("_mylan_loggin_access_control_management_");
            #endregion//End Init View logs
            //
            #region Load Settings
            SharedFunctions.LoadSettings();
            //Schedules
            //SharedValues.Running.StationList[0].Schedules = App.PVCFC_RFID.Model.PVCFCDistributionSchedulesModel.LoadSetting(@"C:\a.xml");
            //new System.Threading.Thread(() =>
            //    {
            //        for (int i = 0; i < 100000; i++)
            //        {
            //            SharedValues.Running.StationList[0].Schedules.ProductItemsList.Add(new Model.PVCFCProductItemModel()
            //            {
            //                TagID = i.ToString(),
            //                Status = DataType.ProductItemStatusEnum.CheckedSuccess,
            //                Results = DataType.ProductItemResultEnum.WaitToSync,
            //                ProductCode = i.ToString().PadLeft(10, '0'),
            //                ScanDatetime = DateTime.Now
            //            });
            //            System.Threading.Thread.Sleep(1000);
            //        }
            //    }).Start();
            
            //SharedValues.Running.StationList[0].Schedules.SaveSettings(@"C:\a.xml");
            //End Schedules
            #endregion//End Load Settings
            //
            #region Check Folder
            try
            {
                if (!System.IO.Directory.Exists(SharedValues.DisShInfoPath))
                {
                    System.IO.Directory.CreateDirectory(SharedValues.DisShInfoPath);
                }
            }
            catch (Exception ex)
            {
                //
                ControlFunctions.CloseLoading();
                //
                MessageBox.Show(new Form { TopMost = true }, Languages.CreatFolderFailed + "\n" + ex.Message, Languages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion//End Check Folder

            //
            ControlFunctions.CloseLoading();
            //
            AccountController.InitAccount(SharedValues.RootPath + "User\\", "SYSTEM\\PCVFC_RFID\\", Properties.Settings.Default.SoftwareName, Properties.Settings.Default.Version, APIController.LinkAPI);
            frmLogin loginform = new frmLogin();
            DialogResult result = loginform.ShowDialog();
            if (result == DialogResult.OK)
            {
                SharedValues.Running.IsOffline = !AccountController.Settings.IsOnlineUser;
                //
                //SharedValues.Running.IsOffline = true;//Every account have functions
                Application.Run(new MainPage());
            }
        }
    }
}
