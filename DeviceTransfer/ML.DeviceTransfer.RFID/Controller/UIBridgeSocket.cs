using ML.Connections.Controller;
using ML.Connections.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.RFID.Controller
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    class UIBridgeSocket
    {
        #region Properties
        private static string _SocketName = "";
        private static int _SocketIndex = 0;
        private static int _UISocketPort = 20400;//Printer: 10400; BarcodeReader: 10410
        private static int _BridgeSocketPort = 20401;
        private static Thread _ThreadUIListenning;
        #endregion//End Properties

        #region Inits Connections
        public static void Connect(string socketName, int socketIndex, int socketPort, int uiSocketPort)
        {
            _SocketName = socketName;
            _SocketIndex = socketIndex;
            _BridgeSocketPort = socketPort;
            _UISocketPort = uiSocketPort;
            //
#if DEBUG
            Console.WriteLine("_SocketName: " + _SocketName.ToString());
            Console.WriteLine("_SocketIndex: " + _SocketIndex.ToString());
            Console.WriteLine("_UISocketPort: " + _UISocketPort.ToString());
            Console.WriteLine("_BridgeSocketPort: " + _BridgeSocketPort.ToString());
#endif
            //
            ConnectionEvents.DeviceStatusChanged+=ConnectionEvents_DeviceStatusChanged;
            ConnectionEvents.DeviceDataReceived += ConnectionEvents_DeviceDataReceived;
            //
            _ThreadUIListenning = new Thread(UISocketListenning);
            _ThreadUIListenning.IsBackground = true;
            _ThreadUIListenning.Priority = ThreadPriority.Highest;
            _ThreadUIListenning.Start();
            //
        }

        public static string Distroys()
        {
            try
            {
                //Kill thread insert database
                if (_ThreadUIListenning != null && _ThreadUIListenning.IsAlive)
                {
                    //release thread
                    _ThreadUIListenning.Abort();
                    _ThreadUIListenning = null;
                    //
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                SendDeviceStatusToUI(ConnectionsType.StatusEnum.DisConnected);
            }
        }

        /// <summary>
        /// Initial thread listen UDP
        /// </summary>
        private static void UISocketListenning()
        {
#if DEBUG
            Console.WriteLine("Listen port: " + _BridgeSocketPort.ToString());
#endif
            UdpClient socketManager = new UdpClient(_BridgeSocketPort);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] receiveBytes = socketManager.Receive(ref remoteIpEndPoint);
#if DEBUG
                    //Console.WriteLine("PC: Receive udp, command = " + BitConverter.ToString(receiveBytes,3,1));
#endif

                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("UIBridgeSocket - ThreadListenUIInit: " + _SocketName + ": " + ex.Message);
#endif
                }
            }
        }

        #endregion//End Inits Connections

        #region Events
        private static void ConnectionEvents_DeviceStatusChanged(object sender, EventArgs e)
        {
            SendDeviceStatusToUI((ConnectionsType.StatusEnum)sender);
        }

        private static void ConnectionEvents_DeviceDataReceived(object sender, EventArgs e)
        {
            SendReceivedDataToUI((byte[])sender);
        }
        #endregion//End Events

        #region Methods
        /// <summary>
        /// Send UDP command to local host
        /// </summary>
        /// <param name="commandBytes"></param>
        protected static void SendCommandToUI(byte[] commandBytes)
        {
            Thread t = new Thread(() =>
            {
                IPAddress globalIP;
                UdpClient udpClient = new UdpClient();
                try
                {
#if DEBUG
                    //Console.WriteLine("Send UI: " + _UISocketPort.ToString());
#endif
                    globalIP = IPAddress.Parse("127.0.0.1");

                    udpClient.Connect(globalIP, _UISocketPort);
                    udpClient.Send(commandBytes, commandBytes.Length);
                }
                catch { }
                udpClient.Close();
#if DEBUG
                //Console.WriteLine("sent a command to UI: " + BitConverter.ToString(commandBytes,3,1));
#endif

            });
            t.IsBackground = true;
            t.Start();
        }

        protected static void SendDeviceStatusToUI(ConnectionsType.StatusEnum status)
        {
            //[0] Header 
            //[1] Devices
            //[2] Socket index
            //[3] Command
            byte[] command = { (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType,                    //0
                               (byte)ConnectionsType.SockTypeCommandEnum.UICommand,                    //1 //UI
                               (byte)_SocketIndex,      //2
                               (byte)ConnectionsType.UISocketCommandEnum.DeviceStatus,                    //3 //Status
                               (byte)status             //4
                             };
            //
            SendCommandToUI(command);
#if DEBUG
            Console.WriteLine("SW UI: " + "SendDeviceStatusToUI" + "-" + status.ToString());
            /*
            if (byteArr[0] == 0x05)
            {
                int newPrintedPage = (byteArr[1] | byteArr[2] << 8 | byteArr[3] << 16 | byteArr[4] << 24);
                Console.WriteLine("SEND ===================> " + newPrintedPage);
            }
             * */
#endif
        }

        protected static void SendReceivedDataToUI(byte[] byteArr)
        {
            byte[] command = new byte[4 + byteArr.Length];
            command[0] = (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType;
            command[1] = (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand;                          //Device data
            command[2] = (byte)_SocketIndex;
            Array.Copy(byteArr, 0, command, 3, byteArr.Length);
            //
            SendCommandToUI(command);
#if DEBUG
            Console.WriteLine("FW UI: " + BitConverter.ToString(command, 3, 4));
            /*
            if (byteArr[0] == 0x05)
            {
                int newPrintedPage = (byteArr[1] | byteArr[2] << 8 | byteArr[3] << 16 | byteArr[4] << 24);
                Console.WriteLine("SEND ===================> " + newPrintedPage);
            }
             * */
#endif
        }
        #endregion//End Methods
    }
}
