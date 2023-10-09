using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.RFID.Model
{
    public class RFIDDeviceSettingsModel
    {
        #region Properties
        private string _IP = "";
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        private string _Port = "";
        public string Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        private int _DeviceAddress = 255;
        public int DeviceAddress
        {
            get { return _DeviceAddress; }
            set { _DeviceAddress = value; }
        }

        private bool _AutoConnections = true;
        public bool AutoConnections
        {
            get { return _AutoConnections; }
            set { _AutoConnections = value; }
        }
        #endregion//End Properties

        #region Send command
        public void SendCommand()
        {

        }
        #endregion//End Send command
    }
}
