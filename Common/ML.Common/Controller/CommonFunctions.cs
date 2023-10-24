using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ML.Common.Controller
{
    public class CommonFunctions
    {
   
        #region Init Path
        public static void SetPath(string rootpath)
        {
            CommonValues.RootPath = rootpath;
            CommonValues.SettingsPath = rootpath + "Settings\\";
        }
        #endregion//End Init Path

        #region Invoke
        public static void Invoke(System.Windows.Forms.Form frm, Action a)
        {
            try
            {
                if (frm.InvokeRequired)
                {
                    frm.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
                    {
                        a();
                    });
                }
                else
                {
                    a();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                //System.Windows.Forms.MessageBox.Show("Invoke: " + ex.Message);
#endif
            }
        }

        public static void Invoke(System.Windows.Forms.UserControl uc, Action a)
        {
            try
            {
                if (uc.InvokeRequired)
                {
                    uc.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
                    {
                        a();
                    });
                }
                else
                {
                    a();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                //System.Windows.Forms.MessageBox.Show("Invoke: " + ex.Message);
#endif
            }
        }

        #endregion//End Invoke

        #region Firewall
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

        #region Security - Firewall
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
        #endregion Security - Firewall
        #endregion//End Firewall

        #region Common
        

        public static List<string> GetTemplatePod(string path)
        {
            var templates = File.ReadAllText(path).Split(';').ToList();
            return ProcessItems(templates.Skip(1).Take(templates.Count - 2).ToList());
        }

        static List<string> ProcessItems(List<string> items)
        {
            items = items.Select(item => item.EndsWith(".dsj") ? item.Substring(0, item.Length - 4) : item).ToList();
            return items.Count > 2 ? items.Skip(1).Take(items.Count - 2).ToList() : new List<string>();
        }

        public static void WriteLogFile(string content)
        {
            string folderPath = @"C:\Users\minhchau.nguyen\Documents\Visual Studio 2022";
            string fileName = "logs.txt";
            string fullPath = Path.Combine(folderPath, fileName);
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                File.WriteAllText(fullPath, content);
            }
            catch (Exception)
            {
                //
            }
        }
        public static string HextoString(string inputText, Encoding encoding)
        {
            try
            {
                byte[] bb = Enumerable.Range(0, inputText.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(inputText.Substring(x, 2), 16))
                                 .ToArray();
                ////return Convert.ToBase64String(bb);
                return encoding.GetString(bb, 0, bb.Length);
                //
                //char[] chars = new char[bb.Length / sizeof(char)];
                ////
                //System.Buffer.BlockCopy(bb, 0, chars, 0, bb.Length);
                //return new string(chars);
            }
            catch (Exception ex)
            {
                return inputText;
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Encoding UTF8
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ConvertStringToByteArray(string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        /// <summary>
        /// Encoding UTF8
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static string ConvertByteArrayToString(byte[] byteArray)
        {
            return Encoding.UTF8.GetString(byteArray);
        }

        public static int ConvertByteArrayToNumber(byte[] byteArray)
        {
            try
            {
                int number = 0;
                foreach (byte b in byteArray)
                {
                    number <<= 8;
                    number |= b;
                }
                return number;
            }
            catch
            {
                return int.MaxValue;
            }
        }

        public static byte[] ConvertNumberToByteArray(int number, int maxValue)
        {
            try
            {
                int bytesNeeded = (int)Math.Ceiling(Math.Log(maxValue + 1, 256));
                byte[] byteArray = new byte[bytesNeeded];

                for (int i = byteArray.Length - 1; i >= 0; i--)
                {
                    byteArray[i] = (byte)(number & 0xFF);
                    number >>= 8;
                }
                return byteArray;
            }
            catch
            {
                return null;
            }
        }
        public static bool[] BytesToBooleanArray(byte[] bytes)
        {
            return bytes.Select(b => b != 0).ToArray();
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // You can change the format to the desired image format
                return ms.ToArray();
            }
        }
        public static ImageSource ByteArrayToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static bool IntToBool(int number)
        {
            return number != 0;
        }

        public static byte[] BitmapToByteArray(Bitmap bitmap, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, format);
                return ms.ToArray();
            }
        }

        public static Bitmap ByteArrayToBitmap(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return new Bitmap(ms);
            }
        }

        public static System.Net.NetworkInformation.PingReply PingIPAdrress(string adress, int timeout = 1000)
        {
            System.Net.NetworkInformation.PingReply pingResult = null;
            try
            {
                System.Net.NetworkInformation.Ping myPing = new System.Net.NetworkInformation.Ping();
                pingResult = myPing.Send(adress, timeout);
                if (pingResult != null)
                {
#if DEBUG
                    Console.WriteLine("Status :  " + pingResult.Status + " \n Time : " + pingResult.RoundtripTime.ToString() + " \n Address : " + pingResult.Address);
                    //Console.WriteLine(reply.ToString());
#endif
                }
            }
            catch
            {
#if DEBUG
                Console.WriteLine("ERROR: You have Some TIMEOUT issue");
#endif
            }
            //
            return pingResult;
        }

        public static string PingHost(string hostUri, int portNumber)
        {
            try
            {
                using (var client = new System.Net.Sockets.TcpClient(hostUri, portNumber))
                    return "";
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return ex.Message;
            }
        }

        public static bool PingURLAdrress(string url, int timeout = 3000)
        {
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                request.Timeout = timeout; //3000;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";

                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void OpenFolder(string folder)
        {
            //// opens the folder in explorer
            //Process.Start(@"c:\temp");
            //// opens the folder in explorer
            //Process.Start("explorer.exe", @"c:\temp");
            //// throws exception
            //Process.Start(@"c:\does_not_exist");
            //// opens explorer, showing some other folder)
            //Process.Start("explorer.exe", @"c:\does_not_exist");
            Process.Start(folder);
        }

        #endregion//End Common

        #region Settings
        public static string GetSettingsName()
        {
            //return CommonValues.SettingsPath + "settings.xml";
            return CommonValues.SettingsPath + "settings.cf";
        }
        #endregion//End Settings

        #region Device transfer
        public static int DeviceTransferStartProcess(string socketName, string fullPath, string arguments)
        {
            System.Diagnostics.Process process = null;
            System.Diagnostics.ProcessStartInfo processInfo = null;
            try
            {
                processInfo = new ProcessStartInfo(fullPath);
                processInfo.Arguments = arguments;
                processInfo.Verb = "runas";//Run as administrators => Thử với máy anh LÝ => Linh add on 04/10/2017
                processInfo.WindowStyle = ProcessWindowStyle.Hidden;
#if DEBUG
                processInfo.WindowStyle = ProcessWindowStyle.Normal;
#endif
                //
                process = new System.Diagnostics.Process();
                process.StartInfo = processInfo;
                process.Start();
                //
                return process.Id;

            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                //
            }
            return -1;
        }

        public static bool DeviceTransferCheckAlive(int id)
        {
            try
            {
                Process processes = Process.GetProcessById(id);
                //if(processes!=null && processes.HasExited)
                if (processes != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public static int DeviceTransferCheckAlive(string deviceName)
        {
            try
            {
                // SocketControl.PrinterController.WaitOne();
                //select all process by name
                Process[] processes = Process.GetProcessesByName(deviceName);
                //kill all selected process
                if (processes != null && processes.Length > 0)
                {
                    return processes.Length;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static void DeviceTransferKillProcess(int id)
        {
            try
            {
                // SocketControl.PrinterController.WaitOne();
                //select all process by name
                Process processes = Process.GetProcessById(id);
                //kill all selected process
                processes.Kill();
            }
            catch (Exception ex)
            {

            }
        }

        public static void DeviceTransferKillProcess(string deviceName)
        {
            // SocketControl.PrinterController.WaitOne();
            //select all process by name
            Process[] processes = Process.GetProcessesByName(deviceName);
            //kill all selected process
            foreach (Process p in processes)
            {
                p.Kill();
            }
            // SocketControl.PrinterController.ReleaseMutex();
        }
        #endregion//End Device transfer



        #region Memory Mapping File
        public static void SetToMemoryFile(string mapName, long capacity, string dataString, byte[] dataBytes = null)
        {

            using (var mutexSync = new Mutex(true, "MMFMutex", out bool mutexCreated))
            {
                try
                {
                    Task.Run(() =>
                    {
                        using (var mmf = MemoryMappedFile.CreateNew(mapName, capacity))
                        {
                            using (var accessor = mmf.CreateViewAccessor())
                            {
                                if (dataBytes == null)
                                {
                                    var data = Encoding.UTF8.GetBytes(dataString);
                                    accessor.WriteArray(0, data, 0, data.Length);
                                }
                                else
                                {
                                    var data = dataBytes;
                                    accessor.WriteArray(0, data, 0, data.Length);
                                }

                                using (var waitForDisposeMmfEvt = new EventWaitHandle(false, EventResetMode.AutoReset, mapName + "Done"))
                                {
                                    waitForDisposeMmfEvt.WaitOne();
                                }
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine($"SetToMemoryFile: {ex.Message}");
#endif
                }
                finally
                {
                    if (mutexCreated)
                    {
                        mutexSync.ReleaseMutex();
                    }
                }
            }
        }


        public static void GetFromMemoryFile(string mapName, long capacity, out string dataString, out byte[] dataBytes)
        {
            dataString = null;
            dataBytes = null;


            using (var mutexSync = new Mutex(false, "MMFMutex"))
            {
                try
                {
                    mutexSync.WaitOne();
                    using (var mmf = MemoryMappedFile.OpenExisting(mapName))
                    {
                        using (var accessor = mmf.CreateViewAccessor())
                        {
                            var data = new byte[capacity];
                            accessor.ReadArray(0, data, 0, data.Length);
                            dataString = Encoding.UTF8.GetString(data).TrimEnd('\0');
                            dataBytes = data;
                            using (var waitForDisposeMmfEvt = EventWaitHandle.OpenExisting(mapName + "Done"))
                            {
                                waitForDisposeMmfEvt.Set();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    //Console.WriteLine($"GetFromMemoryFile: {ex.Message}");
#endif
                }
                finally
                {
                    mutexSync.ReleaseMutex();
                }
            }
        }
        #endregion
    }
}