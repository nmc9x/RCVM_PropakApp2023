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
            try
            {
#if DEBUG
                //args = new string[12];
                //args[0] = "ML.DeviceTransfer.PVCFCDM60X"; // socketName
                //args[1] = "0";                                // socketIndex
                //args[2] = "20400";                            // uiSocketPort
                //args[3] = "20401";                            // bridgeSocketPort
                //args[4] = "169.254.10.11";                    // deviceIP
                //args[5] = "21";                             // port
                //args[6] = "0";                                // timeout
                ////args[7] = "http://113.163.69.8";              // Link API
                ////args[8] = "9594";                             // port
                ////args[9] = "true";                                // isOffline
                //args[7] = "192.168.15.154"; // Printer IP
                //args[8] = "12500"; // Printer Port
#endif

                #region Arguments
                CognexSharedValues.SocketName = args[0];
                CognexSharedValues.SocketIndex = int.Parse(args[1]);
                CognexSharedValues.UISocketPort = int.Parse(args[2]);
                CognexSharedValues.BridgeSocketPort = int.Parse(args[3]);
                CognexSharedValues.DeviceIP = args[4];
                CognexSharedValues.DevicePort = int.Parse(args[5]);
                CognexSharedValues.Timeout = uint.Parse(args[6]);
                CognexSharedValues.PrinterIP = args[7];
                CognexSharedValues.PrinterPort = args[8];
                CognexSharedValues.SendPort = CognexSharedValues.UISocketPort;
             
                #endregion

                #region Init Running
                //CognexSharedValues.Running = new Model.DM60XDeviceRunningModel() { Index = CognexSharedValues.SocketIndex, IsOffline = bool.Parse(args[9]) };
                #endregion//End Inits Running

                #region Init UI Socket
                CognexSharedValues.UIBridgeSocket = new DM60XUIBridgeSocket();
                CognexSharedValues.UIBridgeSocket.Inits(CognexSharedValues.SendPort, CognexSharedValues.SocketIndex);
                CognexSharedValues.UIBridgeSocket.Connect(CognexSharedValues.SocketName, CognexSharedValues.SocketIndex, CognexSharedValues.BridgeSocketPort, CognexSharedValues.UISocketPort);
                #endregion//End Init UI Socket

                #region Init Device handler
                Task.Run(() =>
                {
                    CognexSharedValues.DeviceHandler = new SDK.DM60X.Controller.DM60XDeviceHandler(CognexSharedValues.DeviceIP, CognexSharedValues.DevicePort, CognexSharedValues.SocketIndex);
                });
                Task.Run(() =>
                {
                    CognexSharedValues.PrinterHandler = new SDK.PRINTER.Controller.PrinterHandler(CognexSharedValues.PrinterIP, CognexSharedValues.PrinterPort, CognexSharedValues.SocketIndex);
                });

                #endregion//End Init Device handler
                
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source+": "+ex.Message);
#endif 
            }
            finally
            {
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
}
