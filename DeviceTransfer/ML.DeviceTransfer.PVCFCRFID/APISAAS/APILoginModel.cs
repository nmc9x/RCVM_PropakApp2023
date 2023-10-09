using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ML.DeviceTransfer.PVCFCRFID.APISAASModel
{
    public class APILoginModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public bool success { get; set; }
            public string error { get; set; }
            public string errcode { get; set; }
            public Data data { get; set; }
        }

        public class AgentInfo
        {
            public string _id { get; set; }
            public string AgentCode { get; set; }
            public List<object> ListProduct { get; set; }
            public int TrangThaiDuyet { get; set; }
            public string GroupCode { get; set; }
            public int IsGranary { get; set; }
            public string AreaName { get; set; }
            public int AgentLevel { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string ContactName { get; set; }
            public string AgentName { get; set; }
        }

        public class Data
        {
            public string _id { get; set; }
            public string UserCode { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string BirthDay { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public int Role { get; set; }
            public string RoleName { get; set; }
            public int Status { get; set; }
            public int Gender { get; set; }
            public string CreateBy { get; set; }
            public string AgentCode { get; set; }
            public string BranchCode { get; set; }
            public SettingsPermision SettingsPermision { get; set; }
            public string GroupCode { get; set; }
            public List<string> ListAgentCode { get; set; }
            public AgentInfo AgentInfo { get; set; }
            public List<ListAgentInfo> ListAgentInfo { get; set; }
        }

        public class ListAgentInfo
        {
            public string _id { get; set; }
            public string AgentCode { get; set; }
            public List<object> ListProduct { get; set; }
            public int TrangThaiDuyet { get; set; }
            public string GroupCode { get; set; }
            public int IsGranary { get; set; }
            public string AreaName { get; set; }
            public int AgentLevel { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string ContactName { get; set; }
            public string AgentName { get; set; }
        }

        public class SettingsPermision
        {
            public int AllowLoginAppTest { get; set; }
            public int AllowLoginApp { get; set; }
            public int System { get; set; }
            public int AdminLoginApp { get; set; }
            public int CreateSchedule { get; set; }
            public int NhanVienThiTruong { get; set; }
            public int QuanLyThiTruong { get; set; }
        }

        public class Params
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
