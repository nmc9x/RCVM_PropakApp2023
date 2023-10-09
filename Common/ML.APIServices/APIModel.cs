using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ML.APIServices
{
    public class APIModel
    {
    }

    [DataContract]
    public class APIReModeLoginCls
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "group")]
        public string Other_data { get; set; }
    }

    [DataContract]
    public class APIGetCodeCls
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "datacount")]
        public string DataCount { get; set; }
        [DataMember(Name = "data")]
        public APIGetCodeItemCls[] Data { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "group")]
        public string Other_data { get; set; }
    }

    [DataContract]
    public class APIGetCodeItemCls
    {
        [DataMember(Name = "lot")]
        public string LOT { get; set; }
        [DataMember(Name = "codedata")]
        public string CodeData { get; set; }
        [DataMember(Name = "requestkey")]
        public string RequestKey { get; set; }
        [DataMember(Name = "errors")]
        public string Errors { get; set; }
    }

    [DataContract]
    public class APIUpdateResultCls
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "data")]
        public APIUpdateResultItemCls[] Data { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "group")]
        public string Other_data { get; set; }
    }

    [DataContract]
    public class APIUpdateResultItemCls
    {
        [DataMember(Name = "lot")]
        public string Lot { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "errors")]
        public string Errors { get; set; }
    }

    [DataContract]
    public class APIGetHistoryDataCls
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "datacount")]
        public string DataCount { get; set; }
        [DataMember(Name = "data")]
        public APIGetHistoryDataItemCls[] Data { get; set; }
        [DataMember(Name = "user")]
        public string User { get; set; }
        [DataMember(Name = "dongle")]
        public string Dongle { get; set; }
        [DataMember(Name = "from")]
        public string From { get; set; }
        [DataMember(Name = "to")]
        public string To { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "group")]
        public string Other_data { get; set; }
    }

    [DataContract]
    public class APIGetHistoryDataItemCls
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }
        [DataMember(Name = "privatelabel")]
        public string PrivateLabel { get; set; }
        [DataMember(Name = "bulkinkid")]
        public string BulkInkId { get; set; }
        [DataMember(Name = "lot")]
        public string LOT { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "requestkey")]
        public string RequestKey { get; set; }
        [DataMember(Name = "createdate")]
        public string CreateDate { get; set; }
        [DataMember(Name = "updatedate")]
        public string UpdateDate { get; set; }
        [DataMember(Name = "createserial")]
        public string CreateSerial { get; set; }
        [DataMember(Name = "updateserial")]
        public string UpdateSerial { get; set; }
    }
}
