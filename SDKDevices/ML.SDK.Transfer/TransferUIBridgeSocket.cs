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

namespace ML.SDK.Transfer
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class TransferUIBridgeSocket
    {
        #region Properties
        private string _SocketName = "";
        private int _SocketIndex = 0;
        private int _UISocketPort = 20400;//Printer: 10400; BarcodeReader: 10410
        private int _StationSocketPort = 20401;
        //
        private int _SendPort = 20400;
        private Thread _ThreadUIListenning;
        #endregion//End Properties

        #region Inits Connections
        public void Inits(int sendPort, int socketIndex)
        {
            _SendPort = sendPort;
            _SocketIndex = socketIndex;
        }

        public void Connect(string devTransName, int socketIndex, int stationSocketPort, int uiSocketPort)
        {
            _SocketName = devTransName;
            _SocketIndex = socketIndex;
            _StationSocketPort = stationSocketPort;
            _UISocketPort = uiSocketPort;
            //
#if DEBUG
            Console.WriteLine("Device Transfer Name: " + _SocketName.ToString());
            Console.WriteLine("Socket Index: " + _SocketIndex.ToString());
            Console.WriteLine("Station Socket Port: " + _StationSocketPort.ToString());
            Console.WriteLine("UI Socket Port: " + _UISocketPort.ToString()+"\n");
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

        public string Destroys()
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
        private void UISocketListenning()
        {
#if DEBUG
           // Console.WriteLine("Listen port: " + _BridgeSocketPort.ToString());
#endif
            UdpClient socketManager = new UdpClient(_StationSocketPort);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] receiveBytes = socketManager.Receive(ref remoteIpEndPoint);
                    ProcessReceivedMessageFromUI(receiveBytes);
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
         protected virtual void ConnectionEvents_DeviceStatusChanged(object sender, EventArgs e)
        {
            SendDeviceStatusToUI((ConnectionsType.StatusEnum)sender);
        }

        protected virtual void ConnectionEvents_DeviceDataReceived(object sender, EventArgs e)
        {
            SendReceivedDataToUI((byte[])sender);
        }
        #endregion//End Events

        #region Methods
        /// <summary>
        /// Send UDP command to local host
        /// </summary>
        /// <param name="commandBytes"></param>
        protected void SendCommandToUI(byte[] commandBytes)
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
               // Console.WriteLine("Send to UI (HEX): " + BitConverter.ToString(commandBytes, 0, commandBytes.Length) + "\n");
#endif

            });
            t.IsBackground = true;
            t.Start();
        }

        protected void SendDeviceStatusToUI(ConnectionsType.StatusEnum status)
        {
            try
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
               // Console.WriteLine("SW UI: " + "SendDeviceStatusToUI" + "-" + status.ToString());
                /*
                if (byteArr[0] == 0x05)
                {
                    int newPrintedPage = (byteArr[1] | byteArr[2] << 8 | byteArr[3] << 16 | byteArr[4] << 24);
                    Console.WriteLine("SEND ===================> " + newPrintedPage);
                }
                 * */
#endif
            }
            catch(Exception ex)
            {
                Console.WriteLine("Errors: " + ex.Message);
            }

        }

        protected void SendReceivedDataToUI(byte[] byteArr)
        {
            byte[] command = new byte[3 + byteArr.Length];
            command[0] = (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType;
            command[1] = (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand;                          //Device data
            command[2] = (byte)_SocketIndex;
            Array.Copy(byteArr, 0, command, 3, byteArr.Length);
#if DEBUG
            Console.WriteLine(command);
#endif
            SendCommandToUI(command);
#if DEBUG
           // Console.WriteLine("FW UI: " + BitConverter.ToString(command, 3, 4));
            /*
            if (byteArr[0] == 0x05)
            {
                int newPrintedPage = (byteArr[1] | byteArr[2] << 8 | byteArr[3] << 16 | byteArr[4] << 24);
                Console.WriteLine("SEND ===================> " + newPrintedPage);
            }
             * */
#endif
        }

        protected void SendCommandToPort(byte[] commandBytes)
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

                    udpClient.Connect(globalIP, _SendPort);
                    udpClient.Send(commandBytes, commandBytes.Length);
                }
                catch 
                {
#if DEBUG
                    Console.WriteLine("SendCommandToPort Fail");
#endif
                }
                udpClient.Close();
#if DEBUG
                //Console.WriteLine("sent a command to UI: " + BitConverter.ToString(commandBytes,3,1));
#endif

            });
            t.IsBackground = true;
            t.Start();
        }

        protected void SendDeviceStatusToPort(ConnectionsType.StatusEnum status)
        {
            try
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
                SendCommandToPort(command);
#if DEBUG
               // Console.WriteLine("SW UI: " + "SendDeviceStatusToUI" + "-" + status.ToString());
                /*
                if (byteArr[0] == 0x05)
                {
                    int newPrintedPage = (byteArr[1] | byteArr[2] << 8 | byteArr[3] << 16 | byteArr[4] << 24);
                    Console.WriteLine("SEND ===================> " + newPrintedPage);
                }
                 * */
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errors: " + ex.Message);
            }

        }

        protected void SendUICommandToPort(byte[] byteArr)
        {
            try
            {
                //[0] Header 
                //[1] Devices
                //[2] Socket index
                //[3] Command
                byte[] command = new byte[3 + byteArr.Length];
                //Header
                command[0] = (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType;
                command[1] = (byte)ConnectionsType.SockTypeCommandEnum.UICommand;                          //Device data
                command[2] = (byte)_SocketIndex;
                //
                Array.Copy(byteArr, 0, command, 3, byteArr.Length);
                //
                SendCommandToPort(command);
#if DEBUG
                Console.WriteLine("SendPort=>" + _SendPort.ToString() + ": " + BitConverter.ToString(command, 3, 1));
                /*
                if (byteArr[0] == 0x05)
                {
                    int newPrintedPage = (byteArr[1] | byteArr[2] << 8 | byteArr[3] << 16 | byteArr[4] << 24);
                    Console.WriteLine("SEND ===================> " + newPrintedPage);
                }
                 * */
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errors - SendUICommandToPort: " + ex.Message);
            }

        }

        protected void SendDataToPort(byte[] byteArr)
        {
            byte[] command = new byte[3 + byteArr.Length];
            //Header
            command[0] = (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType;
            command[1] = (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand;                          //Device data
            command[2] = (byte)_SocketIndex;
            //End Header
            Array.Copy(byteArr, 0, command, 3, byteArr.Length);
            //
            SendCommandToPort(command);
#if DEBUG
            Console.WriteLine("SDK.Transfer -> SendDataToPort: " + command);
#endif
        }

        public virtual void ProcessReceivedMessageFromUI(byte[] receivedByteArr)
        {
            //
        }
        #endregion//End Methods
    }
}
