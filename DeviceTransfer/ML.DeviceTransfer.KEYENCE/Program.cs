using ML.Common.Controller;
using ML.DeviceTransfer.CVX450.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.CVX450
{
    public class Program
    {
        static void Main(string[] args)
        {
			try
			{
#if DEBUG
                //args = new string[12];
                //args[0] = "ML.DeviceTransfer.CVX450"; // socketName
                //args[1] = "2";                                // socketIndex
                //args[2] = "20400";                            // uiSocketPort
                //args[3] = "20401";                            // bridgeSocketPort
                //args[4] = "169.254.10.15";                    // deviceIP
                //args[5] = "8500";                             // port
                //args[6] = "0";                                // timeout
                //args[7] = "http://113.163.69.8";              // Link API
                //args[8] = "9594";                             // port
                //args[9] = "true";                                // isOffline
                //args[7] = "192.168.0.30"; // Printer IP
                //args[8] = "2030"; // Printer Port
#endif
                #region Arguments
                CVX450SharedValues.SocketName = args[0];
                CVX450SharedValues.SocketIndex = int.Parse(args[1]);
                CVX450SharedValues.UISocketPort = int.Parse(args[2]);
                CVX450SharedValues.BridgeSocketPort = int.Parse(args[3]);
                CVX450SharedValues.DeviceIP = args[4];
                CVX450SharedValues.DevicePort = int.Parse(args[5]);
                CVX450SharedValues.Timeout = uint.Parse(args[6]);
                CVX450SharedValues.PrinterIP = args[7];
                CVX450SharedValues.PrinterPort = args[8];
                CVX450SharedValues.SendPort = CVX450SharedValues.UISocketPort;

                #endregion


                #region Init UI Socket
                CVX450SharedValues.UIBridgeSocket = new CVX450UIBridgeSocket();

                CVX450SharedValues.UIBridgeSocket.Inits(
                    CVX450SharedValues.SendPort, 
                    CVX450SharedValues.SocketIndex);

                CVX450SharedValues.UIBridgeSocket.Connect(
                    CVX450SharedValues.SocketName,
                    CVX450SharedValues.SocketIndex, 
                    CVX450SharedValues.BridgeSocketPort,
                    CVX450SharedValues.UISocketPort);
                #endregion//End Init UI Socket

                #region Init Device handler
                Task.Run(() => { 
                    CVX450SharedValues.DeviceHandler = new SDK.CVX450.Controller.CVX450DeviceHandler(
                        CVX450SharedValues.DeviceIP, 
                        CVX450SharedValues.DevicePort, 
                        CVX450SharedValues.SocketIndex);
                });
                Task.Run(() =>
                {
                    CVX450SharedValues.PrinterHandler = new SDK.PRINTER.Controller.PrinterHandler(
                        CVX450SharedValues.PrinterIP,
                        CVX450SharedValues.PrinterPort,
                        CVX450SharedValues.SocketIndex);
                });
                #endregion//End Init Device handler
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source + ": " + ex.Message);
#endif
                CommonFunctions.WriteLogFile(ex.Source + "\n" + ex.Message);
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
