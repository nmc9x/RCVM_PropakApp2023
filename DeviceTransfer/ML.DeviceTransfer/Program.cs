using ML.Connections.Controller;
using ML.DeviceTransfer.Controller;
using ML.DeviceTransfer.Model;
using ML.SDK.RFID.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.DeviceTransfer
{
    class Program
    {
        //
        private static UIBridgeSocketModel UIBridgeSocket;
        private static RFIDDeviceHandler DeviceHandler;
        //
        static void Main(string[] args)
        {
#if DEBUG
            //args = new string[8];
            //string _socketName = "ML.DeviceTransfer.RFID";
            //int _socketIndex = 0;
            //int _uiSocketPort = 20400;
            //int _bridgeSocketPort = 20401;
            ////
            //string _deviceIP = "192.168.10.50";
            //int _devicePort = 80;
            //byte _deviceAddress = 255;
            ////
            //args[0] = _socketName.ToString();
            //args[1] = _socketIndex.ToString();
            //args[2] = _uiSocketPort.ToString();
            //args[3] = _bridgeSocketPort.ToString();
            //args[4] = _deviceIP.ToString();
            //args[5] = _devicePort.ToString();
            //args[6] = _deviceAddress.ToString();
#endif
            #region Exit Events
            #endregion//End Exit Events

            #region Arguments
            string socketName = "";
            int socketIndex = 0;
            int uiSocketPort = 20400;//Printer: 10400; BarcodeReader: 10410
            int bridgeSocketPort = 20401;

            //
            string deviceIP = "127.0.0.1";
            int devicePort = 80;
            byte deviceAddress = 255;
            //
            socketName = args[0];
            socketIndex = int.Parse(args[1]);
            uiSocketPort = int.Parse(args[2]);
            bridgeSocketPort = int.Parse(args[3]);
            //
            deviceIP = args[4];
            devicePort = int.Parse(args[5]);
            deviceAddress = (byte)int.Parse(args[6]);

            #endregion//End Arguments

            #region Setup Firewall - Linh.Tran_200818: Not put in thread - avoid lost communication between R20 DevicePackage and MainUI -Linh.Tran_230505: Command
            try
            {
                #region Delete rule Firewall
                //string strNameSpace = typeof(Program).Namespace;
                string strProductName = System.Windows.Forms.Application.ProductName;
                //Linh.Tran_230505: Delete old rulels - Before change ProductName or domain auto add or block
                ConnectionFunctions.ExecuteShellCommand("netsh advfirewall firewall delete rule \"" + strProductName + "\"");
                //End Linh.Tran_230505: Delete old rulels- Before change ProductName or domain auto add or block
                #endregion//End of Delete rule Firewall

                string _RunFileName = System.AppDomain.CurrentDomain.FriendlyName;
                string _RunFileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(_RunFileName);
                #region Setup Firewall
                try
                {
                    ConnectionFunctions.AddUDPFirewall(strProductName + ".UDP" + ".OUT", _RunFileName, uiSocketPort, "out", "UDP", false);
                    ConnectionFunctions.AddUDPFirewall(strProductName + ".UDP" + ".IN", _RunFileName, bridgeSocketPort, "in", "UDP", false);
                    //
                    ConnectionFunctions.AddUDPFirewall(strProductName + ".TCP" + ".OUT", _RunFileName, devicePort, "out", "TCP", false);
                    ConnectionFunctions.AddUDPFirewall(strProductName + ".TCP" + ".IN", _RunFileName, devicePort, "in", "TCP", false);
                }
                catch { }

                #endregion Setup Firewall
                //
            }
            catch (Exception ex)
            {

            }
            finally
            {
#if DEBUG
                Console.WriteLine("Init firewall - port:" + uiSocketPort);
                Console.WriteLine("IP: " + deviceIP);
#endif
            }
            #endregion//End Setup Firewall



            #region Init UI Socket
            UIBridgeSocket = new UIBridgeSocketModel();
            UIBridgeSocket.Connect(socketName, socketIndex, bridgeSocketPort, uiSocketPort);
            #endregion//End Init UI Socket
            //
            #region Init Device handler
            DeviceHandler = new RFIDDeviceHandler();
            DeviceHandler.Connect(deviceIP, devicePort, deviceAddress);
            #endregion//End Init Device handler
            //
            //
            new Thread(() =>
            {
                while (true)
                {
                    Console.ReadKey();
                }

            }).Start();
        }

        #region Methods
        #endregion//End Methods

        #region Events
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            DeviceHandler.Destroys();
            UIBridgeSocket.Destroys();
        }
        #endregion//End Events
    }
}
