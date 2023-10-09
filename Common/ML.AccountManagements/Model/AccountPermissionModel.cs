using ML.AccountManagements.DataType;
using ML.Languages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ML.AccountManagements.Controller
{
    public class AccountModel
    {
        private List<AccountItemModel> _UserModelList = new List<AccountItemModel>();
        public List<AccountItemModel> UserModelList
        {
            get { return _UserModelList; }
            set { _UserModelList = value; }
        }

        public virtual void SaveSettings(String fileName)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }


        public static AccountModel LoadSetting(String fileName)
        {
            AccountModel info = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(AccountModel);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        info = (AccountModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                return new AccountModel();
            }

            return info;
        }
    }

    public class AccountItemModel
    {
        private string _ID = "";
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _UserName = "";
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Password = "";
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _PermissionLevel = "";
        public string PermissionLevel
        {
            get { return _PermissionLevel; }
            set { _PermissionLevel = value; }
        }

        private bool _IsLocked = false;
        /// <summary>
        /// Linh.Tran_220912: Add new
        /// </summary>
        public bool IsLocked
        {
            get { return _IsLocked; }
            set { _IsLocked = value; }
        }

        private DateTime _SaveTime = DateTime.Now;
        public DateTime SaveTime
        {
            get { return _SaveTime; }
            set { _SaveTime = value; }
        }

        private List<FunctionsEnum> _FunctionsList = new List<FunctionsEnum>();
        [XmlIgnore]
        public List<FunctionsEnum> FunctionsList
        {
            get
            {
                var permission = Controller.AccountController.Permission.PermissionList.Where(p => p.PermissionLevel == _PermissionLevel).FirstOrDefault();
                if (permission != null)
                {
                    return ((PermissionItemModel)permission).FunctionsList;
                }
                else
                {
                    return null;
                }
            }
        }

        private string[] _FunctionsAllowManagement;
        [XmlIgnore]
        //Linh.Tran_221116
        public string[] FunctionsAllowManagement
        {
            get
            {
                int index = Array.IndexOf(AccountController.PermissionLevelArr, _PermissionLevel);
                _FunctionsAllowManagement = AccountController.PermissionLevelArr.Skip(index).ToArray();
                return _FunctionsAllowManagement;
            }
        }

        private string _FunctionsStr = "";
        [XmlIgnore]
        public string FunctionsStr
        {
            get
            {
                string str = "";
                if (FunctionsList != null)
                {
                    foreach (FunctionsEnum f in FunctionsList)
                    {
                        str += f.ToFriendlyString();
                        //str += "\r\n";
                        str += " - ";
                    }
                }
                if (str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 3);
                }
                return str;
            }
        }

        /// <summary>
        /// Linh.Tran_220912: Add to get permission name
        /// </summary>
        /// <returns></returns>
        [XmlIgnore]
        public string PermissionName
        {
            get
            {
                var permission = Controller.AccountController.Permission.PermissionList.Where(p => p.PermissionLevel == _PermissionLevel).FirstOrDefault();
                if (permission != null)
                {
                    return permission.PermissionName;
                }
                else
                {
                    return Languages.Languages.Unknown;
                }
            }
        }

        private int _LoginFailedTimes = 0;
        /// <summary>
        /// Linh.Tran_220912: Add new
        /// </summary>
        [XmlIgnore]
        public int LoginFailedTimes
        {
            get { return _LoginFailedTimes; }
            set { _LoginFailedTimes = value; }
        }
    }
    //

    public class PermissionModel
    {
        private List<PermissionItemModel> _PermissionList = new List<PermissionItemModel>();
        public List<PermissionItemModel> PermissionList
        {
            get { return _PermissionList; }
            set { _PermissionList = value; }
        }

        public virtual void SaveSettings(String fileName)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }

        public static PermissionModel LoadSetting(String fileName)
        {
            PermissionModel info = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(PermissionModel);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        info = (PermissionModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                return new PermissionModel();
            }

            return info;
        }
    }

    public class PermissionItemModel
    {
        private string _PermissionLevel = "";
        /// <summary>
        /// Linh.Tran_220912: Add level to permisstion
        /// </summary>
        public string PermissionLevel
        {
            get { return _PermissionLevel; }
            set { _PermissionLevel = value; }
        }


        private string _PermissionName = "";
        public string PermissionName
        {
            get { return _PermissionName; }
            set { _PermissionName = value; }
        }

        List<FunctionsEnum> _FunctionsList = new List<FunctionsEnum>();
        public List<FunctionsEnum> FunctionsList
        {
            get { return _FunctionsList; }
            set { _FunctionsList = value; }
        }

        private string _FunctionsStr = "";
        [XmlIgnore]
        public string FunctionsStr
        {
            get
            {
                string str = "";
                if (FunctionsList != null)
                {
                    foreach (FunctionsEnum f in FunctionsList)
                    {
                        str += f.ToFriendlyString();
                        //str += "\r\n";
                        str += " - ";
                    }
                }
                if (str.Length > 0)
                {
                    str = str.Trim().Substring(0, str.Length - 3);
                }
                return str;
            }
        }

        private DateTime _SaveTime = DateTime.Now;
        public DateTime SaveTime
        {
            get { return _SaveTime; }
            set { _SaveTime = value; }
        }

        public virtual void SaveSettings(String fileName)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }

        public static PermissionModel LoadSetting(String fileName)
        {
            PermissionModel info = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(PermissionModel);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        info = (PermissionModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                return new PermissionModel();
            }

            return info;
        }
    }



    

}
