using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace ML.SDK.DM60X.Model
{
    public class CodeModel
    {
        public Result XmlResult { get; set; }
        public List<Image> ImageList { get; }
        public List<string> ImageGraphList { get; }

        //private string _id;

        //public string ID
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        public string ID  => XmlResult.Id.ToString();
        public string Code => Base64ToString(XmlResult.GeneralInfo.FullStringInfo.Value) == null ? "" : 
            Base64ToString(XmlResult.GeneralInfo.FullStringInfo.Value);
        public string Symbol => XmlResult.GeneralInfo.Symbology == null ? "":XmlResult.GeneralInfo.Symbology;
        public string DecodeTime=> XmlResult.GeneralInfo.DecodeTime.ToString();
        public string Status => XmlResult.GeneralInfo.Status;

        #region Method
        private string Base64ToString(string base64Encoded)
        {
            if (base64Encoded is null) return "";
            byte[] decodedBytes = Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(decodedBytes);
        }
        public CodeModel()
        {
            ImageList = new List<Image>();
            ImageGraphList = new List<string>();
        }
        #endregion

        #region ReadXmlObject
        [XmlRoot("result")]
        public class Result
        {
            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlAttribute("image_id")]
            public int ImageId { get; set; }

            [XmlAttribute("version")]
            public int Version { get; set; }

            [XmlAttribute("origin")]
            public string Origin { get; set; }

            [XmlElement("general")]
            public General GeneralInfo { get; set; }

            [XmlElement("statistics")]
            public Statistics StatisticsInfo { get; set; }
        }

        public class General
        {
            [XmlElement("status")]
            public string Status { get; set; }

            [XmlElement("result_source")]
            public string ResultSource { get; set; }

            [XmlElement("full_string")]
            public FullString FullStringInfo
            {
                get; set;
            }

            [XmlElement("trigger_time")]
            public int TriggerTime { get; set; }

            [XmlElement("decode_time")]
            public int DecodeTime { get; set; }

            [XmlElement("symbology")]
            public string Symbology { get; set; }
        }

        public class FullString
        {
            [XmlAttribute("encoding")]
            public string Encoding { get; set; }

            [XmlText]
            public string Value { get; set; }
        }

        public class Statistics
        {
            [XmlElement("read_stats")]
            public ReadStats ReadStatsInfo { get; set; }
        }

        public class ReadStats
        {
            [XmlElement("good_reads")]
            public int GoodReads { get; set; }

            [XmlElement("bad_reads")]
            public int BadReads { get; set; }

            [XmlElement("passed_validations")]
            public int PassedValidations { get; set; }

            [XmlElement("failed_validations")]
            public int FailedValidations { get; set; }

            [XmlElement("triggers_missed")]
            public int TriggersMissed { get; set; }

            [XmlElement("trigger_overruns")]
            public int TriggerOverruns { get; set; }

            [XmlElement("buffer_overflows")]
            public int BufferOverflows { get; set; }

            [XmlElement("item_count")]
            public int ItemCount { get; set; }
        }
        #endregion
    }
}
