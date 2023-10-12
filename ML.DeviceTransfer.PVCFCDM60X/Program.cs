using ML.Connections.Controller;
using ML.DeviceTransfer.PVCFCDM60X.Controller;
using ML.DeviceTransfer.PVCFCDM60X.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCDM60X
{
    public class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            args = new string[10];
            args[0] = "ML.DeviceTransfer.PVCFCDM60X"; // socketName
            args[1] = "0";                                // socketIndex
            args[2] = "20400";                            // uiSocketPort
            args[3] = "20401";                            // bridgeSocketPort
            args[4] = "169.254.10.11";                    // deviceIP
            args[5] = "21";                             // port
            args[6] = "0";                                // timeout
            args[7] = "http://113.163.69.8";              // Link API
            args[8] = "9594";                             // port
            args[9] = "true";                                // isOffline
#endif

            #region Arguments
            DM60XSharedValues.SocketName = args[0];
            DM60XSharedValues.SocketIndex = int.Parse(args[1]);
            DM60XSharedValues.UISocketPort = int.Parse(args[2]);
            DM60XSharedValues.BridgeSocketPort = int.Parse(args[3]);
            DM60XSharedValues.DeviceIP = args[4];
            DM60XSharedValues.DevicePort = int.Parse(args[5]);
            DM60XSharedValues.Timeout = uint.Parse(args[6]);
            DM60XSharedValues.SendPort = DM60XSharedValues.UISocketPort;
            #endregion

           

          
            #region Init Running
            DM60XSharedValues.Running = new Model.DM60XDeviceRunningModel() { Index = DM60XSharedValues.SocketIndex, IsOffline = bool.Parse(args[9]) };
            #endregion//End Inits Running

            #region Init UI Socket
            DM60XSharedValues.UIBridgeSocket = new DM60XUIBridgeSocket();
            //DM60XSharedValues.UIBridgeSocket.Inits(DM60XSharedValues.SendPort, DM60XSharedValues.SocketIndex);
            //DM60XSharedValues.UIBridgeSocket.Connect(DM60XSharedValues.SocketName, DM60XSharedValues.SocketIndex, DM60XSharedValues.BridgeSocketPort, DM60XSharedValues.UISocketPort);
            #endregion//End Init UI Socket

            #region Init Device handler
            //DM60XSharedValues.DeviceHandler = new SDK.DM60X.Controller.DM60XDeviceHandler(DM60XSharedValues.DeviceIP, DM60XSharedValues.DevicePort, DM60XSharedValues.SocketIndex);
            DM60XSharedValues.PrinterHandler = new SDK.PRINTER.Controller.PrinterHandler("192.168.15.154", "12500", 0);
            #endregion//End Init Device handler
            new Thread(() =>
            {
                while (true)
                {

                    Console.ReadKey();
                    Thread.Sleep(10);
                }

            }).Start();
        }
    }
}
