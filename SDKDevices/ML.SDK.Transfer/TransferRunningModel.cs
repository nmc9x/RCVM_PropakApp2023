using ML.Connections.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.Transfer
{
    public class TransferRunningModel
    {
        private int _TransferID = -1;
        public int TransferID
        {
            get { return _TransferID; }
            set { _TransferID = value; }
        }

        private ConnectionsType.StatusEnum _TransferStatus = ConnectionsType.StatusEnum.Unknown;
        public ConnectionsType.StatusEnum TransferStatus
        {
            get { return _TransferStatus; }
            set { _TransferStatus = value; }
        }

        public virtual void ResetDefault()
        {
            _TransferID = -1;
            TransferStatus = ConnectionsType.StatusEnum.Unknown;
        }

    }
}
