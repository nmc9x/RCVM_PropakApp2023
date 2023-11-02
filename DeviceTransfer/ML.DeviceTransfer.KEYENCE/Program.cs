using ML.DeviceTransfer.CVX450.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                args = new string[12];
                args[0] = "ML.DeviceTransfer.CVX450"; // socketName
                args[1] = "2";                                // socketIndex
                args[2] = "20400";                            // uiSocketPort
                args[3] = "20401";                            // bridgeSocketPort
                args[4] = "192.168.0.10";                    // deviceIP
                args[5] = "8500";                             // port
                args[6] = "0";                                // timeout
                args[7] = "http://113.163.69.8";              // Link API
                args[8] = "9594";                             // port
                args[9] = "true";                                // isOffline
                args[7] = "192.168.0.30"; // Printer IP
                args[8] = "2030"; // Printer Port
#endif
                #region Arguments
                KeyenceSharedValues.SocketName = args[0];
                KeyenceSharedValues.SocketIndex = int.Parse(args[1]);
                KeyenceSharedValues.UISocketPort = int.Parse(args[2]);
                KeyenceSharedValues.BridgeSocketPort = int.Parse(args[3]);
                KeyenceSharedValues.DeviceIP = args[4];
                KeyenceSharedValues.DevicePort = int.Parse(args[5]);
                KeyenceSharedValues.Timeout = uint.Parse(args[6]);
                KeyenceSharedValues.PrinterIP = args[7];
                KeyenceSharedValues.PrinterPort = args[8];
                KeyenceSharedValues.SendPort = KeyenceSharedValues.UISocketPort;

                #endregion
            }
            catch (Exception)
			{

				
			}
        }
    }
}
