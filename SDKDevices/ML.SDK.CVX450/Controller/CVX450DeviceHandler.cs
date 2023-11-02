
using ML.Common.Controller;
using ML.Connections.Controller;
using ML.Connections.DataType;
using ML.SDK.CVX450.Model;
using ML.SDK.CVX450.Controller;
using ML.SDK.CVX450.Model;
using System;
using System.Collections.Concurrent;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace ML.SDK.CVX450.Controller
{

    public class CVX450DeviceHandler
    {
        #region Declaration
        private bool _IsConnecting = false;
        
        private string _IP;
        private int _Port;
        private int _SocketIndex;
        private ConnectionsType.StatusEnum _ConnectionStatus;
        private Thread _ThreadDeviceStatusChecking;
        private readonly object _ObjectSyncLock = new object();
        protected ConcurrentQueue<CodeModel> MessageBufferReceivedArr = new ConcurrentQueue<CodeModel>();
        private int countEventGetRes = 0;

        public CVX450DeviceHandler(string ip, int port, int socketIndex)
        {
            _ConnectionStatus = ConnectionsType.StatusEnum.DisConnected;

            _IP = ip;
            _Port = port;
            _SocketIndex = socketIndex;

#if DEBUG
            Console.WriteLine("Camera IP: " + _IP + ", Port: " + _Port);
#endif

            try
            {
                _TcpClient = new TcpClientHelper(ip, port, 100);
                _TcpClient.MessageReceived += _TcpClient_MessageReceived;
            }
            catch (Exception)
            {
#if DEBUG
                Console.WriteLine($"Camera IP not found !");
#endif
                return;
            }
            finally
            {
                //Thread checking status
                _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking)
                {
                    Name = "CheckStsDeviceThread",
                    IsBackground = true,
                    Priority = ThreadPriority.Highest
                };
                _ThreadDeviceStatusChecking.Start();

                //Thread Dequeue Data
                var threadProccessExcMessage = new Thread(ProccessExcMessage)
                {
                    IsBackground = true,
                    Priority = ThreadPriority.Highest
                };
                threadProccessExcMessage.Start();
            }



           // Connect(_IP, _Port);


        }
        string _ReceivedMessage = null;
        StringBuilder buffer = new StringBuilder();
        private void _TcpClient_MessageReceived(string obj)
        {
            buffer.Append(obj);
            while (true)
            {
                
                int endIndex = buffer.ToString().IndexOf('\r'.ToString());
                if(endIndex != -1)
                {
                    // Lấy tất cả từ đầu buffer đến endIndex
                    string command = buffer.ToString().Substring(0, endIndex);
                    _ReceivedMessage = command;

                    #region Get Only Data
                    var prefix = "T1,";
                    if (_ReceivedMessage != null && _ReceivedMessage.Contains(prefix))
                    {
                        if (_ReceivedMessage.StartsWith(prefix))
                        {
                            var resultDataTrim = _ReceivedMessage.Substring(prefix.Length).Trim();
                            var codeModel = new CodeModel()
                            {
                                Code = resultDataTrim,
                               
                            };
                            new Thread(() => ProccessReceivedMessage(codeModel)).Start();
                            Console.WriteLine(resultDataTrim);
                        }
                    }
                    #endregion

                    // Xóa từ đầu đến endIndex (kể cả ký tự ở endIndex)
                    buffer.Remove(0, endIndex + '\r'.ToString().Length);
                }
                else
                {
                    break;
                }
            }
        }
        #endregion

        
        #region MemoryMapFileRegistration
        private void MMFRegister()
        {
            try
            {
                //#region Save Current Network Params To Memory Map File
                //CommonFunctions.SetToMemoryFile(
                //    "mmf_IP" + _SocketIndex,
                //    15,
                //    _DataManSystem.SendCommand("GET NET-LOCAL.IP-ADDRESS").PayLoad);
                //CommonFunctions.SetToMemoryFile(
                //    "mmf_Subnet" + _SocketIndex,
                //    15,
                //    _DataManSystem.SendCommand("GET NET-LOCAL.SUBNET-MASK").PayLoad);
                //CommonFunctions.SetToMemoryFile(
                //    "mmf_Port" + _SocketIndex,
                //    4,
                //    _DataManSystem.SendCommand("GET TELNET.PORT").PayLoad);

                //#endregion
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("MMFRegister: "+ ex.Message);
#endif
            }

        }
        #endregion

        private static bool connState;
        private TcpClientHelper _TcpClient;
        #region Connection
       

        private void ListenConfig()
        {
            // list cogfig fr UI
        }

        #region Status Checking
        private IPStatus PingIP()
        {
            try
            {
                var myPing = new Ping();
                var reply = myPing.Send(_IP);
                if (reply != null)
                {
#if DEBUG
                    //Console.WriteLine("PingIP Printer :  " +
                    //    reply.Status + ", Time : " +
                    //    reply.RoundtripTime.ToString() + ", Address : " +
                    //    reply.Address + ", Reconnect...");
#endif
                    return reply.Status;
                }
            }
            catch
            {
#if DEBUG
                //  Console.WriteLine($"Printer PingIP ERROR : {_IP}");
#endif
            }
            return IPStatus.Unknown;
        }

        private void DeviceStatusChecking()
        {
            ConnectionsType.StatusEnum oldConnectionSts;
            ConnectionsType.StatusEnum newConnectedSts;

            while (true)
            {
                // Send status to UI
                ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
                var mmf = new MemoryMapHelper("mmf_connectStatus_camera" + _SocketIndex, 1);
                mmf.WriteData(Encoding.ASCII.GetBytes(StatusToNum(_ConnectionStatus).ToString()), 0);

                oldConnectionSts = _ConnectionStatus;
                var printerConnSts = PingIP();
                if (printerConnSts == IPStatus.Success)
                {
                    newConnectedSts = ConnectionsType.StatusEnum.Connected;
                }
                else
                {
                    newConnectedSts = ConnectionsType.StatusEnum.DisConnected;
                }
              
                if (oldConnectionSts != newConnectedSts)
                {
                    _ConnectionStatus = newConnectedSts;

                    // Send to UI
                    ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
                    mmf.WriteData(Encoding.ASCII.GetBytes(StatusToNum(_ConnectionStatus).ToString()), 0);
#if DEBUG
                    string connSts = _ConnectionStatus == ConnectionsType.StatusEnum .Connected? "Conneted" : "Disconnected";
                    Console.WriteLine($"Camera Status: {connSts}");
#endif
                }

                Thread.Sleep(1000);
            }
        }
        #endregion

        #endregion

        private int StatusToNum(ConnectionsType.StatusEnum _connSts)
        {
            int connectionNumStat;
            switch (_connSts)
            {
                case ConnectionsType.StatusEnum.Connected:
                    connectionNumStat = 1;
                    break;
                case ConnectionsType.StatusEnum.Processing:
                    connectionNumStat = 2;
                    break;
                case ConnectionsType.StatusEnum.DisConnected:
                    connectionNumStat = 3;
                    break;
                case ConnectionsType.StatusEnum.Unknown:
                default:
                    connectionNumStat = 0;
                    break;
            }
            return connectionNumStat;
        }
        #region DM60X Read Data

       
      



        private void ProccessReceivedMessage(CodeModel codeModel)
        {
            MessageBufferReceivedArr.Enqueue(codeModel);
        }
        private void ProccessExcMessage()
        {
            while (true)
            {
                if (MessageBufferReceivedArr.Count > 0)
                {
                    try
                    {
                        var resultData = new CodeModel();
                        bool resDequeue = MessageBufferReceivedArr.TryDequeue(out resultData);

                        if (resDequeue)
                        {
                            //Send data to UI
                            ConnectionEvents.RaiseDeviceDataReceived(resultData, EventArgs.Empty);
#if DEBUG
                            Console.WriteLine("Data Read: " + "\n" +
                                "ID: " + resultData.ID + "\n" +
                                "Code: " + resultData.Code + "\n" +
                                "Symbol: " + resultData.Symbol + "\n" +
                                "DecodeTime: " + resultData.DecodeTime + "\n" +
                                "Status: " + resultData.Status + "\n"
                                );
#endif
                        }
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        Console.WriteLine("Error Data: " + ex.Message);
#endif
                    }
                    finally { }
                }
                Thread.Sleep(1);
            }
        }
        #endregion

    

        public bool SoftwareTrigger()
        {
            try
            {
                //var res = _DataManSystem.SendCommand("TRIGGER ON");
                //if (res.PayLoad == "ON")
                //{
                //    _DataManSystem.SendCommand("TRIGGER OFF");
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       

      



       

    }
}
