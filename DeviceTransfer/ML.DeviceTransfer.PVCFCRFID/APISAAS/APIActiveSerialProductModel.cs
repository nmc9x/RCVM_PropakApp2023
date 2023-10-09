using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCRFID.APISAASModel
{
    public class APIActiveSerialProductModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public bool success { get; set; }
            public string content { get; set; }
            public string error { get; set; }
            public string errcode { get; set; }
        }

        public class Params
        {
            public string PBarData { get; set; }
            public string PackingDate { get; set; }
            public string ExpirationDate { get; set; }
            public string LotCode { get; set; }
        }
    }
}
