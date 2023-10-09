using ML.Connections.Controller;
using ML.Common.Controller;
using ML.DeviceTransfer.PVCFCRFID.Controller;
using ML.SDK.RDIF_FX9600.Controller;
using System;
using System.Threading;
using ML.DeviceTransfer.PVCFCRFID.APISAASModel;

namespace ML.DeviceTransfer.PVCFCRFID
{
    class Program
    {

        static void Main(string[] args)
        {


#if DEBUG
            args = new string[10];
            args[0] = "ML.DeviceTransfer.PVCFCRFID.RFID"; // socketName
            args[1] = "0";                                // socketIndex
            args[2] = "20400";                            // uiSocketPort
            args[3] = "20401";                            // bridgeSocketPort
            args[4] = "192.168.18.3";                    // deviceIP
            args[5] = "5085";                             // port
            args[6] = "0";                                // timeout
            args[7] = "http://113.163.69.8";              // Link API
            args[8] = "9594";                             // port
            args[9] = "true";                                // isOffline
#endif
            #region Exit Events
            #endregion//End Exit Events

            #region Arguments
            //Asign public values
            PVCFCSharedValues.SocketName = args[0];
            PVCFCSharedValues.SocketIndex = int.Parse(args[1]);
            PVCFCSharedValues.UISocketPort = int.Parse(args[2]);
            PVCFCSharedValues.BridgeSocketPort = int.Parse(args[3]);
            PVCFCSharedValues.DeviceIP = args[4];
            PVCFCSharedValues.DevicePort = uint.Parse(args[5]);
            PVCFCSharedValues.Timeout = uint.Parse(args[6]);
            APIController.LinkAPI = args[7] + ":" + uint.Parse(args[8]);
            //
            PVCFCSharedValues.SendPort = PVCFCSharedValues.UISocketPort;
            //End asign public values
            //
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
                    // ConnectionFunctions.AddUDPFirewall(strProductName + ".UDP" + ".OUT", _RunFileName, uiSocketPort, "out", "UDP", false);
                    //  ConnectionFunctions.AddUDPFirewall(strProductName + ".UDP" + ".IN", _RunFileName, bridgeSocketPort, "in", "UDP", false);
                    //
                    ConnectionFunctions.AddUDPFirewall(strProductName + ".TCP" + ".OUT", _RunFileName, (int)PVCFCSharedValues.DevicePort, "out", "TCP", false);
                    ConnectionFunctions.AddUDPFirewall(strProductName + ".TCP" + ".IN", _RunFileName, (int)PVCFCSharedValues.DevicePort, "in", "TCP", false);
                }
                catch { }

                #endregion Setup Firewall
                //
            }
            catch (Exception)
            {

            }
            finally
            {
#if DEBUG
                //  Console.WriteLine("Init firewall - port:" + uiSocketPort);
                Console.WriteLine("Device IP: " + PVCFCSharedValues.DeviceIP);
#endif
            }
            #endregion//End Setup Firewall

            #region Init Running
            PVCFCSharedValues.Running = new Model.PVCFCRFIDDeviceRunningModel() { Index = PVCFCSharedValues.SocketIndex, IsOffline = bool.Parse(args[9]) };
            #endregion//End Inits Running

            #region Init UI Socket
            PVCFCSharedValues.UIBridgeSocket = new PVCFCRFIDUIBridgeSocketModel();
            PVCFCSharedValues.UIBridgeSocket.Inits(PVCFCSharedValues.SendPort, PVCFCSharedValues.SocketIndex);
            PVCFCSharedValues.UIBridgeSocket.Connect(PVCFCSharedValues.SocketName, PVCFCSharedValues.SocketIndex, PVCFCSharedValues.BridgeSocketPort, PVCFCSharedValues.UISocketPort);
            #endregion//End Init UI Socket

            /*
             * 
             * 
             */

            #region Init Device handler
            PVCFCSharedValues.DeviceHandler = new RFID_FX9600DeviceHandler(PVCFCSharedValues.DeviceIP, PVCFCSharedValues.DevicePort, PVCFCSharedValues.Timeout);
            //PVCFCSharedValues.DeviceHandler.Connect(PVCFCSharedValues.DeviceIP, PVCFCSharedValues.DevicePort, PVCFCSharedValues.Timeout);



            PVCFCSharedValues.DeviceHandler.ReceiveDataEvent += PVCFCSharedFunctions.DeviceHandler_ReceiveDataEvent;
            #endregion//End Init Device handler

#if DEBUG
            // SharedValues.UIBridgeSocket.ConfigEvent?.Invoke(new byte[36], EventArgs.Empty);
            //PVCFCSharedValues.UIBridgeSocket.ProcessReceivedMessageFromUI(new byte[36]);

            //PVCFCSharedValues.DeviceHandler.StartReadding();
            //
            //PVCFCRFIDUIBridgeSocketModel debugUIBridgeSocket = new PVCFCRFIDUIBridgeSocketModel();
            //debugUIBridgeSocket.Inits(PVCFCSharedValues.BridgeSocketPort, PVCFCSharedValues.SocketIndex);
            //debugUIBridgeSocket.SendStartToDeviceTransfer(false,"64fdfa3b2eaf51eb0c2dccf3", @"C:\Users\mailinh.tran\AppData\Roaming\MLSolutions\PCVFC_RFID\DisShInfo - Copy\LINE_1\LOT01.xml");
            //
            //PVCFCSharedValues.Running.Status = Common.Enum.RunningStatusEnum.Starting;
            //PVCFCSharedValues.DeviceHandler.DEBUGAddMessageBuffer(PVCFCSharedValues.SocketIndex);
#endif
            //
            new Thread(() =>
            {
                while (true)
                {

                    Console.ReadKey();
                    Thread.Sleep(10);
                }

            }).Start();
        }


        #region Methods
        #endregion//End Methods

        #region Events
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            PVCFCSharedValues.DeviceHandler.Destroys();
            PVCFCSharedValues.UIBridgeSocket.Destroys();
        }
        #endregion//End Events
    }
}
