using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ML.Common.Model
{
    public class CommonSettingsModel
    {
        #region Prperties
        #endregion//End Properties

        #region Methods
        public virtual void SaveSettings(string filePath)
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
                    xmlDocument.Save(filePath);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
        #endregion//End Methods
    }
}
