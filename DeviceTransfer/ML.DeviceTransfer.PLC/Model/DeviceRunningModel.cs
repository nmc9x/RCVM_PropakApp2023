using ML.Connections.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PLC.Model
{
    public class DeviceRunningModel
    {
        #region Properties
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

        public void ResetDefault()
        {
            _DeviceTransferID = -1;
            _Status = ConnectionsType.StatusEnum.Unknown;
        }
        #endregion//End Properties

        #region Methods
        public void SendCommand()
        {

        }
        #endregion//End Methods
    }
}
