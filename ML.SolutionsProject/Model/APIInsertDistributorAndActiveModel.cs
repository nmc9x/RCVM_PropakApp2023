using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SolutionsProject.Model
{
    public class APIInsertDistributorAndActiveModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public bool success { get; set; }
            public string error { get; set; }
            public string errcode { get; set; }
            public string content { get; set; }
        }

        public class Params
        {
            public string Data { get; set; }
        }

        public class ParamsDataValues
        {
            public string _idagentproduct { get; set; }
            public string BarData { get; set; }
            public string CreatedBy { get; set; }
            public string LotCode { get; set; }
            public string PackingDate { get; set; }
            public string ExpirationDate { get; set; }
        }
    }
}
