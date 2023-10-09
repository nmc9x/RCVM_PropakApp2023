using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SolutionsProject.Model
{
    public class APIGetAgentInforByConditionModel
    {
        public class Root
        {
            public bool success { get; set; }
            public int TotalPage { get; set; }
            public int CountData { get; set; }
            public List<Datum> data { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Datum
        {
            public string _id { get; set; }
            public string AgentCode { get; set; }
            public int Status { get; set; }
            public string MaDaiLy { get; set; }
            public List<object> ListAgentCodeParent { get; set; }
            public string MaVung { get; set; }
            public string CodeName { get; set; }
            public string ShortName { get; set; }
            public List<object> ListProduct { get; set; }
            public int TrangThaiDuyet { get; set; }
            public string GroupCode { get; set; }
            public int IsGranary { get; set; }
            public string MobiPhone { get; set; }
            public int? Index { get; set; }
            public int? Co_In_VAT { get; set; }
            public string Ngay_Ket_Thuc { get; set; }
            public string Ngay_Bat_Dau { get; set; }
            public string Dia_Chi_Nhan_Hoa_Don { get; set; }
            public string Chu_TK { get; set; }
            public string Chi_Nhanh_Ngan_Hang { get; set; }
            public string Ten_Ngan_Hang { get; set; }
            public string Ten_Dai_Dien { get; set; }
            public string Ten_Ghi_Hoa_Don { get; set; }
            public string So_Tai_Khoan { get; set; }
            public string MST { get; set; }
            public string Vi_Tri_Ban_Hang { get; set; }
            public string Han_No { get; set; }
            public string Muc_No { get; set; }
            public string Tuyen_Giao_Hang { get; set; }
            public string Tan_Suat { get; set; }
            public string Duong { get; set; }
            public string Phuong_Xa { get; set; }
            public string Quan_Huyen { get; set; }
            public string Tinh_TP { get; set; }
            public string CMND { get; set; }
            public string BranchCode { get; set; }
            public string Birthday { get; set; }
            public string AreaCode { get; set; }
            public string Lng { get; set; }
            public string Lat { get; set; }
            public string StaffCodeInvoice { get; set; }
            public string StaffCodeShip { get; set; }
            public string AgentTypeCode { get; set; }
            public string AgentParent { get; set; }
            public string AreaName { get; set; }
            public string CreatedBy { get; set; }
            //public DateTime CreatedDate { get; set; }
            public string CreatedDate { get; set; }
            public int AgentLevel { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string ContactName { get; set; }
            public string AgentName { get; set; }
            //public DateTime? DistributorDate { get; set; }
            public string DistributorDate { get; set; }
        }


        public class Params
        {
            public int AgentLevel { get; set; }
            public int Page { get; set; }
            public int PageLimit { get; set; }
        }
    }
}
