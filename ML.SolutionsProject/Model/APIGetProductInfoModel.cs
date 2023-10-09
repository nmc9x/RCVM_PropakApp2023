using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SolutionsProject.Model
{
    public class APIGetProductInfoModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class Root
        {
            public bool success { get; set; }
            public string error { get; set; }//Linh.Tran_230811: Add optional
            public string errcode { get; set; }//Linh.Tran_230811: Add optional
            public int TotalPage { get; set; }
            public int CountData { get; set; }
            public List<Datum> data { get; set; }
        }

        public class Datum
        {
            public string _id { get; set; }
            public string PCode { get; set; }
            public List<ListAvatar> ListAvatar { get; set; }
            public int IsShow { get; set; }
            public int Status { get; set; }
            public string Ingredient { get; set; }
            public string Use { get; set; }
            public string Effects { get; set; }
            public string LotNumber { get; set; }
            public string PAvatar { get; set; }
            public string BranchCode { get; set; }
            //public DateTime PDateCreate { get; set; }
            public string PDateCreate { get; set; }
            public string PUserCreate { get; set; }
            public object PExpirationDate { get; set; }
            public object PQuantity { get; set; }
            public object PRetails { get; set; }
            public object PPrice { get; set; }
            public object PPackingDate { get; set; }
            public string PDescription { get; set; }
            public string PUnit { get; set; }
            public string PManufacturer { get; set; }
            public string PMadeIn { get; set; }
            public string PBrandName { get; set; }
            public string PSerial { get; set; }
            public string PName { get; set; }
        }

        public class ListAvatar
        {
            public string Title { get; set; }
            public string Link { get; set; }
        }
    }
}
