using ML.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.RDIF_FX9600.Model
{
    public class TagModel
    {
        public string EPCCode { get; set; }
        public string AntennaID { get; set; }
        public string TIDCode { get; set; }
        public sbyte RSSIValue { get; set; }
        public ushort TotalTagCount { get; set; }
    }
}
