using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PLC.Model
{
    public class PLCDeviceSettingsModel
    {
        #region Properties
        private String _COMPort = "COM1";//Linh.Tran_210316
        public String COMPort
        {
            get { return _COMPort; }
            set { _COMPort = value; }
        }

        private int _BaudRate = 115200;
        public int BaudRate
        {
            get { return _BaudRate; }
            set { _BaudRate = value; }
        }

        private int _DataBit = 8;
        public int DataBit
        {
            get { return _DataBit; }
            set { _DataBit = value; }
        }

        private Parity _Parity = Parity.None;
        public Parity Parity
        {
            get { return _Parity; }
            set { _Parity = value; }
        }

        private StopBits _StopBits = StopBits.One;
        public StopBits StopBits
        {
            get { return _StopBits; }
            set { _StopBits = value; }
        }

        private bool _AutoConnections = true;
        public bool AutoConnections
        {
            get { return _AutoConnections; }
            set { _AutoConnections = value; }
        }

        private int _DelayTriggerTime = 100;
        public int DelayTriggerTime
        {
            get { return _DelayTriggerTime; }
            set { _DelayTriggerTime = value; }
        }
        #endregion//End Properties

        #region Send command
        public void SendCommand(ML.DeviceTransfer.PLC.DataType.PLCEnum.CommandEnum command)
        {

        }
        #endregion//End Send command
    }
}
