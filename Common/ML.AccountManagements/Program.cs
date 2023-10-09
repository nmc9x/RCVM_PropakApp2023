using ML.AccountManagements.Controller;
using ML.AccountManagements.Design;
using ML.LoggingControls.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ML.AccountManagements
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AccountController.InitAccount(@"C:\Users\mailinh.tran\AppData\Roaming\MLSolutions\", "SYSTEM\\MLSolutions\\", "PVCFC RFID", "1.0.0.0 build 230918", "http://113.163.69.8:9594");
            //AccountController.InitAccount(@"C:\User\", "PVCFC RFID", "http://113.163.69.8:959");
            LoggingController.LoginToAccess("_mylan_loggin_access_control_management_"); 
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ML.AccountManagements.Design.frmLogin());
            //
            frmLogin loginform = new Design.frmLogin();
            DialogResult result = loginform.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new ML.AccountManagements.Design.frmChangePassword());
                //Application.Run(new ML.AccountManagements.Design.frmResetPassword());
            }
        }
    }
}
