using ML.Connections.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.RFID.Model
{
    public class DeviceRunningModel
    {
        private int _DeviceTransferID = -1;
        public int DeviceTransferID
        {
            get { return _DeviceTransferID; }
            set { _DeviceTransferID = value; }
        }

        private ConnectionsType.StatusEnum _Status = ConnectionsType.StatusEnum.Unknown;
        public ConnectionsType.StatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private List<RFIDScanDataModel> _ScanDataList = new List<RFIDScanDataModel>();
        public List<RFIDScanDataModel> ScanDataList
        {
            get { return _ScanDataList; }
            set { _ScanDataList = value; }
        }


        public void ResetDefault()
        {
            _DeviceTransferID = -1;
            _Status = ConnectionsType.StatusEnum.Unknown;
            _ScanDataList = new List<RFIDScanDataModel>();
        }

    }
}
