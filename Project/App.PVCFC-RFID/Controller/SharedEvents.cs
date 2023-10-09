using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PVCFC_RFID.Controller
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

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        public static event EventHandler StartFeedbackFromTransferEvents;
        public static void RaiseStartFeedbackFromTransferEvents(object sender)
        {
            if (StartFeedbackFromTransferEvents != null)
            {
                StartFeedbackFromTransferEvents(sender, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        public static event EventHandler StopFeedbackFromTransferEvents;
        public static void RaiseStopFeedbackFromTransferEvents(object sender)
        {
            if (StopFeedbackFromTransferEvents != null)
            {
                StopFeedbackFromTransferEvents(sender, EventArgs.Empty);
            }
        }

        public static event EventHandler PageFeedbackFromTransferEvents;
        public static void RaisePageFeedbackFromTransferEvents(object sender)
        {
            if (PageFeedbackFromTransferEvents != null)
            {
                PageFeedbackFromTransferEvents(sender, EventArgs.Empty);
            }
        }
        #endregion//End Scan data

        #region Sync data
        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        public static event EventHandler StartSyncDataEvents;
        public static void RaiseStartSyncDataEvents(object sender)
        {
            if (StartSyncDataEvents != null)
            {
                StartSyncDataEvents(sender, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        public static event EventHandler StopSyncDataEvents;
        public static void RaiseStopSyncDataEvents(object sender)
        {
            if (StopSyncDataEvents != null)
            {
                StopSyncDataEvents(sender, EventArgs.Empty);
            }
        }

        #endregion//end Sync data

        #region Common
        public static event EventHandler RestartAppEvents;
        public static void RaiseRestartAppEvents(object sender)
        {
            if (RestartAppEvents != null)
            {
                RestartAppEvents(sender, EventArgs.Empty);
            }
        }

        public static event EventHandler DataRawListChanged;
        public static void RaiseDataRawListChanged(object sender)
        {
            if (DataRawListChanged != null)
            {
                DataRawListChanged(sender, EventArgs.Empty);
            }
        }

        #endregion//End Common
    }
}
