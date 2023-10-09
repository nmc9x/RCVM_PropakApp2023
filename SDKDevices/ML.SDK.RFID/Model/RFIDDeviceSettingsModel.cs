using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.RFID.Model
{
    public class RFIDDeviceSettingsModel
    {
        #region Properties

        private string _HostNameURL = "";
        public string HostNameURL
        {
            get { return _HostNameURL; }
            set { _HostNameURL = value; }
        }

        private string _IP = "";
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        private int _Port = 0;
        public int Port
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
