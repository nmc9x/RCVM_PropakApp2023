using ML.Common.Controller;
using App.DevCodeActivatorRFID.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.Languages;
using ML.Controls;
using System.Drawing;

namespace App.DevCodeActivatorRFID
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
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
            #endregion//End Inits Languages

            #region Init Config Path
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MLSolutions\" + "RFIDReader" + "\\";
            SharedFunctions.SetPath(rootPath);
            #endregion//End Init Config Path
            //
            #region Load Settings
            SharedFunctions.LoadSettings();
            #endregion//End Load Settings
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App.DevCodeActivatorRFID.Design.frmMain());
            
        }
    }
}
