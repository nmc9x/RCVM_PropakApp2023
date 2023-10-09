using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ML.DatabaseConnections.DataType
{
    /// <summary>
    /// /// <summary>
    /// Author: quang.le
    /// </summary>
    /// </summary>
    [Serializable]
    public class DataSchemaModel
    {
        private String _FieldName;

        public String FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }

        private int _Position;

        public int Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        private int _Length;

        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

    }
    /// <summary>
    /// Author: quang.le
    /// </summary>
    [Serializable]
    public class DataSchemaCollection : System.Collections.ObjectModel.Collection<DataSchemaModel>
    {
        public void Save(string SavePath)
        {
            FileStream s = File.Create(SavePath);
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(DataSchemaCollection));
            ser.Serialize(s, this);
            s.Flush();
            s.Close();
        }
        public static DataSchemaCollection Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            try
            {
                FileStream s = new FileStream(filePath, FileMode.Open);
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(DataSchemaCollection));
                DataSchemaCollection result = (DataSchemaCollection)ser.Deserialize(s);
                s.Close();
                return result;
            }
            catch { return null; }
        }
    }

}
