using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCRFID.APISAASModel
{
    public class APIGetAgentProductByIdModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public bool success { get; set; }
            public string error { get; set; }
            public Data data { get; set; }
        }

        public class AgentCodeFromData
        {
            public string _id { get; set; }
            public string AgentCode { get; set; }
            public int AgentLevel { get; set; }
            public string AgentName { get; set; }
        }

        public class Data
        {
            public string _id { get; set; }
            public string Code { get; set; }
            public int AgentLevel { get; set; }
            public string AgentCode { get; set; }
            public string BranchCode { get; set; }
            public Idagent _idagent { get; set; }
            public string ProCode { get; set; }
            public Idproduct _idproduct { get; set; }
            public string DistributorDate { get; set; }
            public int DistributorCount { get; set; }
            public string CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public object DeletedDate { get; set; }
            public object DeletedBy { get; set; }
            public int Hidden { get; set; }
            public int SoLuongDaQuet { get; set; }
            public object LenhXuatKho { get; set; }
            public object _idPhieuXuatKhoNhaMay { get; set; }
            public object _idPhieuXuatKho { get; set; }
            public object _idLenhXuatHang { get; set; }
            public object LenhPhanPhoi { get; set; }
            public int TypeSync { get; set; }
            public int StatusSyncOffline { get; set; }
            public string NoteSyncQuantity { get; set; }
            public int TimeSyncQuantity { get; set; }
            public int SyncQuantityToDMS { get; set; }
            public string NoteSyncStatus { get; set; }
            public int TimeSyncStatus { get; set; }
            public int SyncStatusToDMS { get; set; }
            public int Status { get; set; }
            public object GroupLevelId { get; set; }
            public object ProgramCode { get; set; }
            public int FreeItem { get; set; }
            public object OrderNumber { get; set; }
            public object From_Sale_Order_ID { get; set; }
            public long Sale_Order_ID { get; set; }
            public int TotalScanBarcode { get; set; }
            public string AgentCodeFrom { get; set; }
            public object SaleNumber { get; set; }
            public object DistributeTo { get; set; }
            public AgentCodeFromData AgentCodeFromData { get; set; }
        }

        public class Idagent
        {
            public string _id { get; set; }
            public string AgentCode { get; set; }
            public int AgentLevel { get; set; }
            public string AgentName { get; set; }
        }

        public class Idproduct
        {
            public string _id { get; set; }
            public string PCode { get; set; }
            public string PName { get; set; }
        }
    }
}
