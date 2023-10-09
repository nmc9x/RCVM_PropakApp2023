using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ML.AccountManagements.Model
{
    public class AccountSettingModel
    {
        private bool _IsUserOn = true;
        public bool IsUserOn
        {
            get { return _IsUserOn; }
            set { _IsUserOn = value; }
        }

        private bool _IsOnlineUser = true;
        [XmlIgnore]
        public bool IsOnlineUser
        {
            get { return _IsOnlineUser; }
            set { _IsOnlineUser = value; }
        }

        private bool _IsRememberUsrer = true;
        public bool IsRememberUsrer
        {
            get { return _IsRememberUsrer; }
            set { _IsRememberUsrer = value; }
        }

        private string _UserNameOnline = "";
        public string UserNameOnline
        {
            get { return _UserNameOnline; }
            set { _UserNameOnline = value; }
        }

        private string _PassWordOnline = "";
        public string PassWordOnline
        {
            get { return _PassWordOnline; }
            set { _PassWordOnline = value; }
        }

        private string _UserNameOffline = "Support";
        [XmlIgnore]
        public string UserNameOffline
        {
            get { return _UserNameOffline; }
            set { _UserNameOffline = value; }
        }

        private string _PasswordOffline = "Support@2023";
        [XmlIgnore]
        public string PasswordOffline
        {
            get { return _PasswordOffline; }
            set { _PasswordOffline = value; }
        }

        private void ResetDefault()
        {

        }

        public void SaveSettings(String fileName)
        {
            try
            {
                string path = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //
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

        public static AccountSettingModel LoadSetting(String fileName)
        {
            AccountSettingModel info = null;
            try
            {
                if (File.Exists(fileName))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(fileName);
                    string xmlString = xmlDocument.OuterXml;

                    using (StringReader read = new StringReader(xmlString))
                    {
                        Type outType = typeof(AccountSettingModel);

                        XmlSerializer serializer = new XmlSerializer(outType);
                        using (XmlReader reader = new XmlTextReader(read))
                        {
                            info = (AccountSettingModel)serializer.Deserialize(reader);
                            reader.Close();
                        }

                        read.Close();
                    }
                }
                else
                {
                    return new AccountSettingModel();
                }
            }
            catch (Exception ex)
            {
                return new AccountSettingModel();
            }

            return info;
        }
    }
}
