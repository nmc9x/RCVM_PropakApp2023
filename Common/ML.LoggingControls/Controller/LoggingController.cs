using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Security.Permissions;
using System.IO.MemoryMappedFiles;
using System.Xml;
using System.Xml.Linq;
using ML.LoggingControls.Model;

namespace ML.LoggingControls.Controller
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class LoggingController
    {
        #region Properties

        public static String LoggingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MLSolutions\" + @"\Histories\Viewlogs\";
        private static String _KeyAccess = "_mylan_loggin_access_control_management_";
        private static bool _AllowAccess = false;
        public static bool AllowAccess
        {
            get { return LoggingController._AllowAccess; }
        }
        public static string LogedInUsername = "";

        #endregion//End Properties

        #region Events
        #endregion//End Events

        #region Methods

        public static void ShowViewLogs(bool isAdmin)
        {
            if (_AllowAccess)
            {
                ML.LoggingControls.View.frmViewLogs frm = new ML.LoggingControls.View.frmViewLogs(isAdmin);
                frm.ShowDialog();
            }
        }

        public static List<LoggingModel> LoadHistory(DateTime dateForm, DateTime dateTo, List<LoggingType> logTypeList, List<string> lstCommand = null)
        {
            //check security
            if (!_AllowAccess)
            {
                return null;
            }
            List<LoggingModel> result = new List<LoggingModel>();
            try
            {
                bool isExistLog = false;
                DataSet dtSet = new DataSet();
                List<string> fileNames = GetLogFileNames(dateForm, dateTo);
                if (fileNames.Count > 0)
                {
                    foreach (string file in fileNames)
                    {
                        if (File.Exists(file))
                        {
                            isExistLog = true;
                            DataSet temp = LoadLogFiles(file);
                            //Linh.Tran_221116: Fix errors log have NUL chars
                            if (temp == null)
                            {
                                string tempData = File.ReadAllText(file);
                                tempData = tempData.Replace("\0", string.Empty);
                                File.WriteAllText(file, tempData);//Write files with remove ('NUL' = "\0") chars
                                temp = LoadLogFiles(file);
                            }
                            //End Linh.Tran_221116: Fix errors log have Null chars
                            //
                            if (temp != null)
                            {
                                dtSet.Merge(temp);
                            }
                        }
                    }
                    if (isExistLog)
                    {
                        //
                        result = dtSet.Tables[0].AsEnumerable()
                                       .Select(row => new LoggingModel
                                                    {
                                                        // assuming column 0's type is Nullable<long>
                                                        //Id = row.Field<int?>(0).GetValueOrDefault(),
                                                        LogType = (LoggingType)Convert.ToInt16(row.Field<string>("logtype")),
                                                        KeyWord = row.Field<string>("keyword"),
                                                        Command = row.Field<string>("command"),
                                                        Message = row.Field<string>("message"),
                                                        Date = DateTime.ParseExact(row.Field<string>("date"), "dd-MM-yyyy HH:mm:ss tt",
                                                                                   System.Globalization.CultureInfo.InvariantCulture),
                                                        User = row.Field<string>("user")
                                                    }).ToList();
                        //
                        if (lstCommand != null)
                        {
                            return result.Where(i => logTypeList.Contains(i.LogType) && lstCommand.Contains(i.Command)).ToList();
                        }
                        else
                        {
                            return result.Where(i => logTypeList.Contains(i.LogType)).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            //
            return result;
        }

        public static void AddHistory(LoggingModel model, DateTime dateTime)
        {
            //check security
            if (!_AllowAccess)
            {
                return;
            }

            try
            {
                string logFiles = GetNewLogFilesName(dateTime);
                StringBuilder sbuilder = new StringBuilder();
                using (StringWriter sw = new StringWriter(sbuilder))
                {
                    using (XmlTextWriter w = new XmlTextWriter(sw))
                    {
                        w.WriteStartElement("log");
                        w.WriteElementString("logtype", ((int)model.LogType).ToString());
                        w.WriteElementString("keyword", model.KeyWord);
                        w.WriteElementString("command", model.Command);
                        w.WriteElementString("message", model.Message);
                        w.WriteElementString("date", model.Date.ToString("dd-MM-yyyy HH:mm:ss tt"));
                        w.WriteElementString("user", model.User);
                        // w.WriteElementString("Info2", info2);
                        w.WriteEndElement();
                    }
                }
                //
                using (StreamWriter w = new StreamWriter(logFiles, true, Encoding.UTF8))
                {
                    w.WriteLine(sbuilder.ToString());
                    w.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void AddHistory(List<LoggingModel> modelList, DateTime dateTime)
        {
            //check security
            if (!_AllowAccess)
            {
                return;
            }

            try
            {
                string logFiles = GetNewLogFilesName(dateTime);
                StringBuilder sbuilder = new StringBuilder();
                using (StringWriter sw = new StringWriter(sbuilder))
                {
                    using (XmlTextWriter w = new XmlTextWriter(sw))
                    {
                        //foreach (LoggingModel model in modelList)
                        //{
                        //    w.WriteStartElement("log");
                        //    w.WriteElementString("logtype", ((int)model.LogType).ToString());
                        //    w.WriteElementString("keyword", model.KeyWord);
                        //    w.WriteElementString("command", model.Command);
                        //    w.WriteElementString("message", model.Message);
                        //    w.WriteElementString("date", model.Date.ToString("dd-MM-yyyy HH:mm:ss tt"));
                        //    w.WriteElementString("user", model.User);
                        //    // w.WriteElementString("Info2", info2);
                        //    w.WriteEndElement();
                        //    //
                        //    System.Threading.Thread.Sleep(1);
                        //}
                        //
                        XElement xml = new XElement("logs", modelList.Select(model => new XElement("log",
                                                                    new XElement("logtype", ((int)model.LogType).ToString()),
                                                                    new XElement("keyword", model.KeyWord),
                                                                    new XElement("command", model.Command),
                                                                    new XElement("message", model.Message),
                                                                    new XElement("date", model.Date.ToString("dd-MM-yyyy HH:mm:ss tt")),
                                                                    new XElement("user", model.User))));
                        xml.WriteTo(w);
                        //
                    }
                }
                //
                using (StreamWriter w = new StreamWriter(logFiles, true, Encoding.UTF8))
                {
                    sbuilder.Remove(0, 6);//Linh.Tran_211122: Remove <logs>
                    sbuilder.Remove((sbuilder.Length - 1) - 6, 7);//Linh.Tran_211122: Remove <logs/>
                    w.Write(sbuilder.ToString());
                    w.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void AddHistory(String command, String keyword, String message, String username, LoggingType logtype)
        {
            AddHistory(
                new LoggingModel
                {
                    Command = command,
                    Date = DateTime.Now,
                    KeyWord = keyword,
                    LogType = logtype,
                    Message = message,
                    User = username
                }, DateTime.Now
                );
        }

        public static bool ClearHistory(DateTime dateFrom, DateTime dateTo)
        {
            //check security
            if (!_AllowAccess)
            {
                return false;
            }
            //
            List<string> logFilesArr = GetLogFileNames(dateFrom, dateTo);
            if (logFilesArr.Count > 0)
            {
                foreach (string file in logFilesArr)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
            //
            try
            {
                return true;
            }
            catch { }
            return false;
        }

        public static DataSet LoadLogFiles(string logFiles)
        {
            try
            {
                using (XmlLogfileStream logfileStream = new XmlLogfileStream(logFiles))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(logfileStream);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static List<string> GetLogFileNames(DateTime dateFrom, DateTime dateTo)
        {
            List<string> fileNameArr = new List<string>();
            DateTime tempDateFrom = DateTime.ParseExact(dateFrom.ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);//Linh.Tran_211118: Remove times in dates
            DateTime tempDateTo = DateTime.ParseExact(dateTo.ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);//Linh.Tran_211118: Remove times in dates
            for (DateTime date = tempDateFrom; date <= tempDateTo; date = date.AddDays(1))
            {
                fileNameArr.Add(GetNewLogFilesName(date));
            }
            //
            return fileNameArr;
        }

        public static bool LoginToAccess(String key)
        {
            if (key == _KeyAccess)
            {
                _AllowAccess = true;
            }
            else
            {
                _AllowAccess = false;
            }
            //
            if (!Directory.Exists(LoggingPath))
            {
                Directory.CreateDirectory(LoggingPath);
            }
            return _AllowAccess;
        }

        private static string GetCurrentDate()
        {
            return DateTime.Now.Year.ToString()
                                       + DateTime.Now.Month.ToString().PadLeft(2, '0')
                                       + DateTime.Now.Day.ToString().PadLeft(2, '0');
        }

        private static string GetCurrentDate(DateTime date)
        {
            return date.Year.ToString()
                                       + date.Month.ToString().PadLeft(2, '0')
                                       + date.Day.ToString().PadLeft(2, '0');
        }

        private static string GetCurrentTime()
        {
            return DateTime.Now.Hour.ToString().PadLeft(2, '0')
                   + DateTime.Now.Minute.ToString().PadLeft(2, '0')
                   + DateTime.Now.Second.ToString().PadLeft(2, '0')
                   + DateTime.Now.Millisecond.ToString().PadLeft(3, '0');
        }

        public static string GetNewLogFilesName(DateTime date)
        {
            //return String.Format(@"{0}\{1}_{2}_logs.evl", path, GetCurrentDate(), GetCurrentTime());//Linh.Tran_211116
            return String.Format(@"{0}\{1}_logs.evl", LoggingPath, GetCurrentDate(date));//Linh.Tran_211116
        }

        private static string GetFullLogFiles(string fileName)
        {
            return String.Format(@"{0}\{1}", LoggingPath, fileName);
        }
        #endregion//End Methods

        #region Command methods
        public static void Invoke(System.Windows.Forms.Form frm, Action a)
        {
            if (frm.InvokeRequired)
            {
                frm.Invoke((System.Windows.Forms.MethodInvoker)delegate()
                {
                    a();
                });
            }
            else
            {
                a();
            }
        }
        //
        public static void Invoke(System.Windows.Forms.UserControl uc, Action a)
        {
            if (uc.InvokeRequired)
            {
                uc.Invoke((System.Windows.Forms.MethodInvoker)delegate()
                {
                    a();
                });
            }
            else
            {
                a();
            }
        }

        public static void UpdateIcon(System.Windows.Forms.Form frm)
        {
            Invoke(frm, new Action(() =>
            {
                String path = System.Windows.Forms.Application.StartupPath + "\\Label\\icon.ico";
                if (System.IO.File.Exists(path))
                {
                    frm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(path);
                }
                else
                {
                    frm.ShowIcon = false;
                }
            }));
        }
        #endregion//End Command methods
    }
}
