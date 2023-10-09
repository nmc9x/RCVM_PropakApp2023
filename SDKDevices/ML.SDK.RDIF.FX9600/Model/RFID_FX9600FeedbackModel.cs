using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.RDIF_FX9600.Model
{
    public class RFID_FX9600FeedbackModel
    {
        // Config
        public bool GPIOConfigFeedback { get; set; }
        public bool TagStorageConfigFeedback { get; set; }
        public bool AntennaConfigFeedback { get; set; }
        public bool TriggerConfigFeedback { get; set; }

        //Operation
        public bool StartReadFeedback { get; set; }
        public bool StopReadFeedback { get; set; }
        public bool LoginFeedback { get; set; }
        public bool LogoutFeedback { get; set; }
        public bool RebootFeedback { get; set; }
        public bool ClearRpFeedback { get; set; }
        public bool ResetFactoryFeedback { get; set; }
        public bool DisconnectFeedback { get; set; }
    }
}
