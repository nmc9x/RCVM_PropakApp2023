using ML.DeviceTransfer.PVCFCDM60X.Model;
using ML.SDK.DM60X.Controller;
using ML.SDK.PRINTER.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCDM60X.Controller
{
    public class CognexSharedValues
    {
        public static string SocketName = "ML.DeviceTransfer.PVCFCDM60X";
        public static int SocketIndex = 0;
        public static int UISocketPort = 20400;//Printer: 10400; BarcodeReader: 10410 // device transfer -> ui
        public static int BridgeSocketPort = 20401; // ui -> device transfer
        public static string DeviceIP = "169.254.10.11";
        public static int DevicePort = 23;
        public static uint Timeout = 0;
        public static int SendPort = 20400;

        //Printer
        public static string PrinterIP = "192.168.15.152";
        public static string PrinterPort = "12500";
        

        public static DM60XDeviceHandler DeviceHandler;

        public static DM60XUIBridgeSocket UIBridgeSocket;
        
        public static DM60XDeviceRunningModel Running;//Linh.Tran_230911: Run data when Start scan

        public static PrinterHandler PrinterHandler;
    }
}
