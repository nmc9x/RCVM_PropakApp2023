using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SolutionsProject.Model
{
    public class APIInsertAgentProductModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public bool success { get; set; }
            public string error { get; set; }
            public string errcode { get; set; }
            public string content { get; set; }
            public string _id { get; set; }
            public string _idagentfrom { get; set; }
        }

        public class Params
        {
            public string Data { get; set; }
        }

        public class ParamsDataValues
        {
            public string AgentCodeFrom { get; set; }
            public string AgentCode { get; set; }
            public string ProCode { get; set; }
            public string DistributorDate { get; set; }
            public int DistributorCount { get; set; }
            public string CreatedBy { get; set; }
        }
    }
}
