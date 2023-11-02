
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

    public class CVX450FDeviceHandler
    {
        #region Declaration
        private bool _IsConnecting = false;
        private CVX cvx;
        private string _IP;
        private int _Port;
        private int _SocketIndex;
        private ConnectionsType.StatusEnum _ConnectionStatus;
        private Thread _ThreadDeviceStatusChecking;
        private readonly object _ObjectSyncLock = new object();
        protected ConcurrentQueue<GotCodeModel> MessageBufferReceivedArr = new ConcurrentQueue<GotCodeModel>();
        private int countEventGetRes = 0;
        public CVX450FDeviceHandler(string ip, int port, int socketIndex)
        {
            _ConnectionStatus = ConnectionsType.StatusEnum.DisConnected;

            _IP = ip;
            _Port = port;
            _SocketIndex = socketIndex;

#if DEBUG
            Console.WriteLine("Camera IP: " + _IP + ", Port: " + _Port);
#endif
            //Thread checking status
            _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking)
            {
                Name = "CheckStsDeviceThread",
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            _ThreadDeviceStatusChecking.Start();
            //End Thread checking status

            Connect(_IP, _Port);


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
        #region Connection
        public bool Connect(string ip, int port)
        {
            if (!_IsConnecting)
            {
                try
                {
                    // Setting for Read
                    cvx = new CVX();
                    if(cvx.Connect("192.168.0.10", 8500, 2000))
                    {
                        connState = true;
                        return true;
                    }
                   

                    var threadProccessResult = new Thread(ProcessResult);
                    threadProccessResult.IsBackground = true;
                    threadProccessResult.Start();

                    //Thread Listen Config via MMF
                    var threadListenConfig = new Thread(ListenConfig)
                    {
                        IsBackground = true
                    };
                    threadListenConfig.Start();

                    //Thread Dequeue Data
                    var threadProccessExcMessage = new Thread(ProccessExcMessage)
                    {
                        IsBackground = true,
                        Priority = ThreadPriority.Highest
                    };
                    threadProccessExcMessage.Start();

                   
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("Connection Fail: " + ex.Message);
#endif
                    return false;
                }
            }
            return false;
        }

        private void ListenConfig()
        {
            
        }

     

        private IPStatus PingIP(string ip, int timeout = 1000)
        {
            try
            {
                var myPing = new Ping();
                var reply = myPing.Send(ip);
                if (reply != null)
                {
                    if (reply.Status == IPStatus.Success)
                    {

                    }
#if DEBUG
                    //Console.WriteLine("PingIP Camera :  " +
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
               // Console.WriteLine("PingIP ERROR: You have Some TIMEOUT issue");
#endif
            }
            return IPStatus.Unknown;
        }

        private void DeviceStatusChecking()
        {
            ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
            var mmf = new MemoryMapHelper("mmf_connectStatus_camera" + _SocketIndex, 1);
            mmf.WriteData(Encoding.ASCII.GetBytes(StatusToNum(_ConnectionStatus).ToString()), 0);

            while (true)
            {
                try
               {
                    var oldStatus = _ConnectionStatus;
                    var newStatus = ConnectionsType.StatusEnum.Unknown;
                    //
                    if (cvx != null)
                        newStatus =
                            connState == true ?
                            ConnectionsType.StatusEnum.Connected :
                            ConnectionsType.StatusEnum.Processing;
                    else
                        newStatus = ConnectionsType.StatusEnum.DisConnected;

                    if (!_IsConnecting)
                    {
                        switch (newStatus)
                        {
                            case ConnectionsType.StatusEnum.Processing:
                                switch (PingIP(_IP))
                                {
                                    case IPStatus.Success:
                                        if (Connect(_IP, _Port))
                                            newStatus = ConnectionsType.StatusEnum.Connected;
                                        else
                                            newStatus = ConnectionsType.StatusEnum.Processing;
                                        break;
                                    default:
                                        newStatus = ConnectionsType.StatusEnum.DisConnected;
                                        break;
                                }
                                break;
                            case ConnectionsType.StatusEnum.DisConnected:
                                switch (PingIP(_IP))
                                {
                                    case IPStatus.Success:
                                        if (Connect(_IP, _Port))
                                            newStatus = ConnectionsType.StatusEnum.Connected;
                                        else
                                            newStatus = ConnectionsType.StatusEnum.Processing;
                                        break;
                                    case IPStatus.Unknown:
                                        break;
                                    default:
                                        newStatus = ConnectionsType.StatusEnum.DisConnected;
                                        break;
                                }
                                break;
                        }
                    }
                    //
                    if (newStatus != oldStatus)
                    {
                        _ConnectionStatus = newStatus;
                        ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
                        mmf.WriteData(Encoding.ASCII.GetBytes(StatusToNum(_ConnectionStatus).ToString()), 0);

#if DEBUG
                        Console.WriteLine("Camera Status: " + newStatus);
#endif
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("ERRORS - DeviceStatusChecking: " + ex.Message);
#endif
                }
                if (_ConnectionStatus == ConnectionsType.StatusEnum.Connected)
                {
                    //MMFRegister();
                }
                Thread.Sleep(1000);
            }
        }
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

       
        private void ProcessResult()
        {
            try
            {
                var getRes = CVX.resultReceivedData;


                   // new Thread(() => ProccessReceivedMessage(codeModel)).Start();
             }


            
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ProcessResult: " + ex.Message);
#endif       
            }

        }

       

        //private void ProccessReceivedMessage(CodeModel codeModel)
        //{
        //    MessageBufferReceivedArr.Enqueue(codeModel);
        //}
        private void ProccessExcMessage()
        {
            while (true)
            {
                if (MessageBufferReceivedArr.Count > 0)
                {
                    try
                    {
                        //var resultData = new CodeModel();
                       // bool resDequeue = MessageBufferReceivedArr.TryDequeue(out resultData);

//                        if (resDequeue)
//                        {
//                            //Send data to UI
//                           // ConnectionEvents.RaiseDeviceDataReceived(resultData, EventArgs.Empty);
//#if DEBUG
//                            Console.WriteLine("Data Read: " + "\n" +
//                                "ID: " + resultData.ID + "\n" +
//                                "Code: " + resultData.Code + "\n" +
//                                "Symbol: " + resultData.Symbol + "\n" +
//                                "DecodeTime: " + resultData.DecodeTime + "\n" +
//                                "Status: " + resultData.Status + "\n"
//                                );
//#endif
//                        }
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
