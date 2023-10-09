using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Connections.Controller
{
    public class ConnectionEvents
    {
        public static event EventHandler DeviceStatusChanged;
        public static event EventHandler DeviceDataReceived;
        //
        public static void RaiseDeviceStatusChanged(object sender, EventArgs e)
        {
            if(DeviceStatusChanged!=null)
            {
                DeviceStatusChanged(sender, e);
            }
        }
       

        public static void RaiseDeviceDataReceived(object sender, EventArgs e)
        {
            if (DeviceDataReceived != null)
            {
                DeviceDataReceived(sender, e);
            }
        }
    }
}
