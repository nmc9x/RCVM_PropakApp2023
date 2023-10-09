using ML.Connections.DataType;
using ML.SDK.RFID.Model;
using ML.SDK.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.Model
{
    public class DeviceRunningModel: TransferRunningModel
    {
        private int _Index = -1;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        private List<RFIDScanDataModel> _ScanDataList = new List<RFIDScanDataModel>();
        public List<RFIDScanDataModel> ScanDataList
        {
            get { return _ScanDataList; }
            set { _ScanDataList = value; }
        }

        public override void ResetDefault()
        {
            base.ResetDefault();
            _ScanDataList = new List<RFIDScanDataModel>();
        }
    }
}
