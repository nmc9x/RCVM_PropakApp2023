using ML.DeviceTransfer.PVCFCRFID.Model;
using ML.SDK.RDIF_FX9600.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCRFID.Controller
{
    public class PVCFCSharedValues
    {
        public static string SocketName = "";
        public static int SocketIndex = 0;
        public static int UISocketPort = 20400;//Printer: 10400; BarcodeReader: 10410 // device transfer -> ui
        public static int BridgeSocketPort = 20401; // ui -> device transfer
        public static string DeviceIP = "127.0.0.1";
        public static uint DevicePort = 5084;
        public static uint Timeout = 0;
        public static int SendPort = 20400;
        //
        //Linh.Tran_230909
        public static int TIDLength = 24;
        public static int EPCLength = 32;
        public static string StationName = "LINE";
        //End //Linh.Tran_230909
        //
        //
        public static PVCFCRFIDUIBridgeSocketModel UIBridgeSocket;//Communicate with UI
        public static RFID_FX9600DeviceHandler DeviceHandler;//Communicate with Device - RFID FX9600
        public static PVCFCRFIDDeviceRunningModel Running;//Linh.Tran_230911: Run data when Start scan
        //
    }
}
