using ML.DeviceTransfer.CVX450.Model;
using ML.DeviceTransfer.CVX450.Model;
using ML.SDK.CVX450.Controller;
using ML.SDK.PRINTER.Controller;

namespace ML.DeviceTransfer.CVX450.Controller
{
    public class KeyenceSharedValues
    {
        public static string SocketName = "ML.DeviceTransfer.CVX450";
        public static int SocketIndex = 2;
        public static string DeviceIP = "192.168.0.10";
        public static int DevicePort = 8500;
        public static uint Timeout = 0;
        public static int UISocketPort = 20400;//Printer: 10400; BarcodeReader: 10410 // device transfer -> ui
        public static int BridgeSocketPort = 20401; // ui -> device transfer
        public static int SendPort = 20400;

        //Printer
        public static string PrinterIP = "192.168.0.30";
        public static string PrinterPort = "12500";


        public static CVX450FDeviceHandler DeviceHandler;

        public static CVX450DeviceRunningModel Running;

        public static PrinterHandler PrinterHandler;

    }
}
