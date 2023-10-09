using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Connections.Controller
{
    public class ConnectionFunctions
    {
        #region Methods Firewall

        /// <summary>
        /// Linh.Tran_230505
        /// </summary>
        /// <param name="CommandLine"></param>
        /// <returns></returns>
        public static string ExecuteShellCommand(string CommandLine)
        {
            System.Diagnostics.Process Process = null;
            System.Diagnostics.ProcessStartInfo ProcessStartInfo = null;
            string output = "";
            try
            {
                Process = new System.Diagnostics.Process();

                string CMDProcess = string.Format("{0}\\cmd.exe", Environment.SystemDirectory);

                string Arguments = string.Format("/C {0}", CommandLine);

                ProcessStartInfo = new System.Diagnostics.ProcessStartInfo(CMDProcess, Arguments);
                ProcessStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //
                ProcessStartInfo.CreateNoWindow = true;
                ProcessStartInfo.UseShellExecute = false;
                ProcessStartInfo.RedirectStandardOutput = true;
                ProcessStartInfo.RedirectStandardInput = true;
                ProcessStartInfo.RedirectStandardError = true;
                Process.StartInfo = ProcessStartInfo;
                Process.StartInfo.Verb = "runas";//Run as administrators => Thử với máy anh LÝ => Linh add on 04/10/2017
                //
                Process.Start();
                output = Process.StandardOutput.ReadToEnd();
                Process.WaitForExit();
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                // close process and do cleanup
                Process.Close();
                Process.Dispose();
                Process = null;
            }
            return output;
        }

        public static void AddUDPFirewall(String name, String assambly, int port, String dir, String protocol, bool isAny)
        {
            try
            {
                String assamblyPath = System.Windows.Forms.Application.StartupPath;
                lock ("mylan.firewall")
                {
                    String data = "netsh advfirewall firewall show rule name=\"{0}\" >nul\r\n";
                    data += "if %errorlevel%== 0 ( netsh advfirewall firewall delete rule name=\"{0}\"\r\n";
                    if (isAny)
                    {
                        data += ")\r\nnetsh advfirewall firewall add rule name=\"{0}\" dir={1} program=\"{4}\\{2}\" action=allow enable=yes protocol={5}\r\n";
                        data = String.Format(data, name, dir, assambly, port, assamblyPath, "Any");
                    }
                    else
                    {
                        data += ")\r\nnetsh advfirewall firewall add rule name=\"{0}\" dir={1} program=\"{4}\\{2}\" action=allow enable=yes protocol={5} localport={3}\r\n";
                        data = String.Format(data, name, dir, assambly, port, assamblyPath, protocol);
                        //data = String.Format(data, name, dir, assambly, port, assamblyPath, "Any");
                    }
                    //String path = Program.SettingsPath + "Settings\\";
                    //String path = ShareValues.SettingsPath;//Linh.Tran_230523: Save path in Temp folder Windows
                    String path = Path.GetTempPath();
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    path += name + "." + dir + ".bat";
                    File.WriteAllText(path, data);
                    ProcessStartInfo pInfo = new ProcessStartInfo(path);
                    pInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(pInfo);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //Add list port (11901,11902,11903) or range port (11901-11903)
        public static void AddUDPFirewall(String name, String assambly, string listPort, String dir, String protocol, bool isAny)
        {
            try
            {
                String assamblyPath = System.Windows.Forms.Application.StartupPath;
                lock ("mylan.firewall")
                {
                    String data = "netsh advfirewall firewall show rule name=\"{0}\" >nul\r\n";
                    data += "if %errorlevel%== 0 ( netsh advfirewall firewall delete rule name=\"{0}\"\r\n";
                    if (isAny)
                    {
                        data += ")\r\nnetsh advfirewall firewall add rule name=\"{0}\" dir={1} program=\"{4}\\{2}\" action=allow enable=yes protocol={5}\r\n";
                        data = String.Format(data, name, dir, assambly, listPort, assamblyPath, "Any");
                    }
                    else
                    {
                        data += ")\r\nnetsh advfirewall firewall add rule name=\"{0}\" dir={1} program=\"{4}\\{2}\" action=allow enable=yes protocol={5} localport={3}\r\n";
                        data = String.Format(data, name, dir, assambly, listPort, assamblyPath, protocol);
                    }
                    //String path = Program.SettingsPath + "Settings\\";
                    //String path = ShareValues.SettingsPath;//Linh.Tran_230523: Save path in Temp folder Windows
                    String path = Path.GetTempPath();
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    path += name + "." + dir + ".bat";
                    File.WriteAllText(path, data);
                    ProcessStartInfo pInfo = new ProcessStartInfo(path);
                    pInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(pInfo);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion//End Methods Firewall


    }
}
