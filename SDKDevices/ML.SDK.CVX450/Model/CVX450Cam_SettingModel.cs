using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static ML.SDK.CVX450.DataType.CVX450DataType;

namespace ML.SDK.CVX450.Model
{
 
    public class CVX450Cam_SettingModel
    {
        public string DeviceTransferName { get; set; } = "ML.DeviceTransfer.CVX450";
        public string IPAddress { get; set; } = "169.254.10.11";
        public string Port { get; set; } = "8500";
        public string SubnetMask { get; set; } = "255.255.255.0";
       
        public string PrinterIP { get; set; } = "169.254.10.35";
        public string PrinterPort { get; set; } = "2030";



        public CVX450Cam_SettingModel()
        {
            #region Init Par
            IPAddress = "169.254.10.15";
            Port = "8500";
            SubnetMask = "255.255.255.0";

            #endregion
        }
        private CVX450_OPERATION_TYPE _TypeOfOperation = CVX450_OPERATION_TYPE.None;
        public CVX450_OPERATION_TYPE TypeOfOperation
        {
            get { return _TypeOfOperation; }
            set { _TypeOfOperation = value; }
        }

       

      
        
    }
}
