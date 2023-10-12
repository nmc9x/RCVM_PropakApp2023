using ML.Common.Controller;
using ML.Connections.Controller;
using ML.Connections.DataType;
using System;
using System.Data;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.SDK.PRINTER.Controller
{
    public class PrinterHandler : SocketClient
    {
        #region Declaration
        //private string _IP;
        //private string _Port;
        private int _SocketIndex;
        private MainListener _PrinterListener;

        private SocketClient _SockClient;
        private TcpClient _Client;
        private NetworkStream _Stream;
        private readonly string _IP;
        private readonly string _Port;


        private Thread _ThreadDeviceStatusChecking = null;
        private int _ConnectionStatus = 0;
        #endregion

      

        public PrinterHandler(string ip, string port, int socketIndex)
        {
            _IP = ip;
            _Port = port;
            _SocketIndex = socketIndex;
           

            //Thread checking status
            _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking)
            {
                Name = "CheckStsDeviceThread",
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            _ThreadDeviceStatusChecking.Start();
            //End Thread checking status
        }
        public async void Test()
        {
            await StartAndLoadData();
        }
        private IPStatus PingIP()
        {
            try
            {
                var myPing = new Ping();
                var reply = myPing.Send(_IP);
                if (reply != null)
                {
                    if (reply.Status == IPStatus.Success)
                    {

                    }
#if DEBUG
                    Console.WriteLine("PingIP Status :  " +
                        reply.Status + ", Time : " +
                        reply.RoundtripTime.ToString() + ", Address : " +
                        reply.Address + ", Reconnect...");
#endif
                    return reply.Status;
                }
            }
            catch
            {
#if DEBUG
                Console.WriteLine("PingIP ERROR: You have Some TIMEOUT issue");
#endif
            }
            return IPStatus.Unknown;
        }

        public override bool Connect()
        {
            try
            {
                _Client = new TcpClient(_IP, int.Parse(_Port));
                _Stream = _Client.GetStream();
#if DEBUG
                Console.WriteLine("Connected");
#endif
                return true;
            }
            catch (Exception)
            {
#if DEBUG
                Console.WriteLine("Connected fail");
#endif
                return false;
            }
        }
        public override async Task Send(string message)
        {

            if (_Stream == null)
                throw new InvalidOperationException("Not connected to server.");
            byte[] data = Encoding.ASCII.GetBytes((char)2 + message + (char)3);
            _Stream.Write(data, 0, data.Length);
            Console.WriteLine($"Sent Data: {message}");
            await Task.Delay(100);

        }
        public override string Receive()
        {
            if (_Stream == null)
                throw new InvalidOperationException("Not connected to server.");
            byte[] data = new byte[1024];
            int bytes = _Stream.Read(data, 0, data.Length);
            var receivedMessage = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine($"Received: {receivedMessage}");
            return receivedMessage;
        }
        public override async Task StartAndLoadData()
        {
            //SocketClient client = new SocketClient("192.168.15.154", 12500);
            var filePath = "C:\\Users\\minhchau.nguyen\\Documents\\MyLanGroup\\Projects\\Propak\\output.csv";
            string[] tableData = File.ReadAllLines(filePath);
            string command;
            string readySts = (char)2 + "RYES" + (char)3 + (char)2 + "STAR;READY" + (char)3;
            Connect();

            #region ConnectAsync
            bool isReady = false;
            while (!isReady)
            {
                await Send("STAR;TestTemplate;1;1");
                if (Receive() == readySts)
                {
                    isReady = true;
                }
                else
                {
                    await Task.Delay(1000);
                }
            }
            #endregion

            #region ProcessData
            Console.WriteLine("Start send data...");
            for (int i = 1; i < tableData.Length; i++)
            {
                string formattedData = CsvParser.ParseLine(tableData[i]);
                command = "DATA;" + formattedData;
                await Send(command);
            }
            Disconnect();

            #endregion
        }
        public override async Task StopPrinting()
        {
            Connect();
            await Send("STOP");
            Disconnect();
        }
        public override void Disconnect()
        {
            _Stream?.Close();
            _Client?.Close();
            Console.WriteLine($"Disconnected from {_IP}:{_Port}");
        }

        //public bool Connect()
        //{

        //            try
        //            {

        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }
        //            try
        //            {
        //                _PrinterListener = new TCPIPServerListener(_IP, int.Parse(_Port));
        //                if( _PrinterListener != null )
        //                {
        //                    if (_PrinterListener.Connect())
        //                    {
        //                        //--Status Checking Thread--//
        //                        _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking);
        //                        _ThreadDeviceStatusChecking.IsBackground = true;
        //                        _ThreadDeviceStatusChecking.Priority = ThreadPriority.Highest;
        //                        _ThreadDeviceStatusChecking.Start();

        //                        //--Received Data Event--//
        //                        _PrinterListener.ReceiveDataEvent += _PrinterListener_ReceiveDataEvent;
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        _ConnectionStatus = ConnectionsType.StatusEnum.DisConnected;
        //                        ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
        //                        return false;
        //                    }
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //#if DEBUG
        //                Console.WriteLine("ERRORS: " + ex.Message);
        //#endif
        //                return false;
        //            }
        //}

        private void _PrinterListener_ReceiveDataEvent(object sender, EventArgs e)
        {
            
        }

        private void DeviceStatusChecking()
        {
            int oldConnectionSts = _ConnectionStatus;
            int newConnectedSts = 0;
            while (true)
            {
                var printerConnSts = PingIP();
                if (printerConnSts == IPStatus.Success)
                {
                    newConnectedSts = 1;
                    
                }
                else
                {
                    newConnectedSts = 0;
                   
                }
                if(oldConnectionSts != newConnectedSts)
                {
                    _ConnectionStatus = newConnectedSts;
                    CommonFunctions.SetToMemoryFile("mmf_conn_" + _SocketIndex, 1, _ConnectionStatus.ToString());
                }
                Thread.Sleep(1000);
            }
        }
    }
}
