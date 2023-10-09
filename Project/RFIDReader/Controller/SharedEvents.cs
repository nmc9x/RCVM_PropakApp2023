using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Controller
{
    public class SharedEvents : CommonEvents
    {
        #region RFID
        public static event EventHandler StationDeviceStatusChanged;
        public static event EventHandler RFIDDeviceDataReceived;
        //
        public static void RaiseStationDeviceStatusChanged(int stationIndex)
        {
            if (StationDeviceStatusChanged != null)
            {
                StationDeviceStatusChanged(stationIndex, EventArgs.Empty);
            }
        }

        public static void RaiseRFIDDeviceDataReceived()
        {
            if (RFIDDeviceDataReceived != null)
            {
                RFIDDeviceDataReceived(null, EventArgs.Empty);
            }
        }
        #endregion//End RFID

        #region PLC
        public static event EventHandler PLCDeviceStatusChanged;
        public static event EventHandler PLCDeviceDataReceived;
        //
        public static void RaisePLCDeviceStatusChanged()
        {
            if (PLCDeviceStatusChanged != null)
            {
                PLCDeviceStatusChanged(null, EventArgs.Empty);
            }
        }

        public static void RaisePLCDeviceDataReceived()
        {
            if (PLCDeviceDataReceived != null)
            {
                PLCDeviceDataReceived(null, EventArgs.Empty);
            }
        }
        #endregion//End PLC

        #region Scan data
        public static event EventHandler ScanDataFinishInTimesEvents;
        //Raise event to UI
        public static void RaiseScanDataFinishInTimesEvents(string strErrors, EventArgs e)
        {
            if (ScanDataFinishInTimesEvents != null)
            {
                ScanDataFinishInTimesEvents(null, EventArgs.Empty);
            }
        }
        #endregion//End Scan data
    }
}
