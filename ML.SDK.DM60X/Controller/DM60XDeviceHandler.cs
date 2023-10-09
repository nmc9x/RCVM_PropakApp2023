using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Utils;
using Microsoft.SqlServer.Server;
using ML.Common.Controller;
using ML.Connections.Controller;
using ML.Connections.DataType;
using ML.SDK.DM60X.Model;
using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static ML.SDK.DM60X.DataType.DM60XDataType;
using static ML.SDK.DM60X.Model.CodeModel;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using Image = System.Drawing.Image;

namespace ML.SDK.DM60X.Controller
{

    public class DM60XDeviceHandler
    {
        #region Declaration
        private bool _IsConnecting = false;
        private EthSystemConnector _EthSystemConnector = null;
        private DataManSystem _DataManSystem = null;
        private ResultCollector _results;
        private string _IP;
        private int _Port;
        private ConnectionsType.StatusEnum _ConnectionStatus;
        private Thread _ThreadDeviceStatusChecking;
        private readonly object _ObjectSyncLock = new object();
        protected ConcurrentQueue<CodeModel> MessageBufferReceivedArr = new ConcurrentQueue<CodeModel>();
        public DM60XDeviceHandler(string ip, int port)
        {
            _ConnectionStatus = ConnectionsType.StatusEnum.DisConnected;

            _IP = ip;
            _Port = port;
            Console.WriteLine("Init IP & Port: " + _IP + "/" + _Port);
            Connect(_IP, _Port);



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
        #endregion


        #region MemoryMapFileRegistration
        private void MMFRegister()
        {
            try
            {
                #region Save Current Network Params To Memory Map File

                CommonFunctions.SetToMemoryFile(
                    "memoryMapFile_IP",
                    15,
                    _DataManSystem.SendCommand("GET NET-LOCAL.IP-ADDRESS").PayLoad);
                CommonFunctions.SetToMemoryFile(
                    "memoryMapFile_Subnet",
                    15,
                    _DataManSystem.SendCommand("GET NET-LOCAL.SUBNET-MASK").PayLoad);
                CommonFunctions.SetToMemoryFile(
                    "memoryMapFile_Port",
                    4,
                    _DataManSystem.SendCommand("GET TELNET.PORT").PayLoad);

                #endregion
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("MMFRegister: "+ ex.Message);
#endif
            }
           
        }
        #endregion
        #region Connection

        public bool Connect(string ip, int port)
        {
            if (!_IsConnecting)
            {
                try
                {
                    // Setting for Read
                    _EthSystemConnector = new EthSystemConnector(IPAddress.Parse(_IP), _Port);
                    _DataManSystem = new DataManSystem(_EthSystemConnector);
                    _DataManSystem.Connect();

                    var resultTypes =
                        ResultTypes.ReadXml |
                        ResultTypes.Image |
                        ResultTypes.ImageGraphics;

                    _results = new ResultCollector(_DataManSystem, resultTypes);
                    _DataManSystem.SetResultTypes(resultTypes);

                    StartReadding();

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

                    return _DataManSystem.State == ConnectionState.Connected;

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
            try
            {
                while (true)
                {
                    CommonFunctions.GetFromMemoryFile("memoryMapFile_Reboot", 1,out string isRebootStr,out _);
                    if(isRebootStr == "1")
                    {
                        DeviceReboot();

#if DEBUG
                        Console.WriteLine("Rebooting ....");
#endif
                    }
                    
                    CommonFunctions.GetFromMemoryFile("memoryMapFile_Reset", 1, out string isResetStr, out _);
                    if (isResetStr == "1")
                    {
                        ResetConfigToDefault();

#if DEBUG
                        Console.WriteLine("Reset params to default !");
#endif
                    }
                    CommonFunctions.GetFromMemoryFile("memoryMapFile_TriggerClick", 1, out string isTriggerClickStr, out _);
                    if (isTriggerClickStr == "1")
                    {
                        SoftwareTrigger();
                    }

                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
               Console.WriteLine("ListenConfig: "+ex.Message);
#endif
            }
        }

        public bool Disconnect()
        {
            if (_DataManSystem == null)
                return true;
            try
            {
                _DataManSystem.Disconnect();
                return _DataManSystem.State == ConnectionState.Disconnected;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("DISCONNECTION ERRORS: " + ex.Message);
#endif
                return false;
            }
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
        private void DeviceStatusChecking()
        {
            ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
            while (true)
            {
                try
                {
                    var oldStatus = _ConnectionStatus;
                    var newStatus = ConnectionsType.StatusEnum.Unknown;
                    //
                    if (_DataManSystem != null)
                        newStatus =
                            _DataManSystem.State == ConnectionState.Connected ?
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
                                        Disconnect();
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
                        
#if DEBUG
                        Console.WriteLine("DeviceStatusChecking: " + newStatus);
#endif
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("ERRORS - DeviceStatusChecking: " + ex.Message);
#endif
                }
                if(_ConnectionStatus == ConnectionsType.StatusEnum.Connected)
                {
                    MMFRegister();
                }
                Thread.Sleep(1000);
            }
        }
        #endregion

        #region DM60X Read Data
        private void Results_ComplexResultCompleted(object sender, ComplexResult e)
        {
            var resultThread = new Thread(new ParameterizedThreadStart(ProcessResult));
            resultThread.IsBackground = true;
            resultThread.Start(e);
        }
        private void ProcessResult(object obj)
        {
            try
            {
                var complexResult = obj as ComplexResult;
                var codeModel = new CodeModel();
                lock (_ObjectSyncLock)
                {
                    foreach (var simResult in complexResult.SimpleResults)
                    {
                        if (simResult.Id.Type != ResultTypes.Image &&
                           simResult.Id.Type != ResultTypes.ImageGraphics &&
                           simResult.Id.Type != ResultTypes.ReadXml) continue;
                        switch (simResult.Id.Type)
                        {
                            case ResultTypes.Image:
                                var image = ImageArrivedEventArgs.GetImageFromImageBytes(simResult.Data);
                               
                                if (image != null)
                                {
                                    codeModel.ImageList.Add(image);
                                    var first_image = codeModel.ImageList[0];
                                    var image_size = Gui.FitImageInControl(first_image.Size, new Size(400, 400));
                                    var fitted_image = Gui.ResizeImageToBitmap(first_image, image_size);
                                    var byteImage = CommonFunctions.ImageToByteArray(fitted_image);
                                    CommonFunctions.SetToMemoryFile("memoryMapFile_ImageTrigger", byteImage.Length, "", byteImage);
                                }
                                    
                                break;
                            case ResultTypes.ImageGraphics:
                                codeModel.ImageGraphList.Add(simResult.GetDataAsString());
                                break;
                            case ResultTypes.ReadXml:
                                codeModel.XmlResult = GetObjectFrXmlReader(simResult.GetDataAsString());
                                break;
                            default:
                                break;
                        }

                        // Processing IMG
                      
                        //if (codeModel.ImageList.Count > 0)
                        //{
                        //    Image first_image = codeModel.ImageList[0];

                        //    Size image_size = Gui.FitImageInControl(first_image.Size, new Size(400, 400));
                        //    Image fitted_image = Gui.ResizeImageToBitmap(first_image, image_size);

                        //    if (codeModel.ImageGraphList.Count > 0)
                        //    {
                        //        using (Graphics g = Graphics.FromImage(fitted_image))
                        //        {
                        //            foreach (var graphics in codeModel.ImageGraphList)
                        //            {
                        //                ResultGraphics rg = GraphicsResultParser.Parse(graphics, new Rectangle(0, 0, image_size.Width, image_size.Height));
                        //                ResultGraphicsRenderer.PaintResults(g, rg);
                        //            }
                        //        }
                        //    }

                          
//#if DEBUG
//                            //  Console.WriteLine("Size byte image: " + byteImage.Length);
//#endif
//                            //  StorageImageFile(fitted_image);
//                        }

                    }
                    new Thread(() => ProccessReceivedMessage(codeModel)).Start();
#if DEBUG
                    //Console.WriteLine("Data Read: "+"ID: " + codeModel.ID + " Code: "+ codeModel.Code);
#endif
                }
              
               
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ProcessResult: " + ex.Message);
#endif       
            }

        }
        private Result GetObjectFrXmlReader(string xmlContent)
        {
            var xmlSerializer = new XmlSerializer(typeof(Result));
            using (var stringReader = new StringReader(xmlContent))
            {
                return (Result)xmlSerializer.Deserialize(stringReader);
            }
        }
        
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

        #region DM60X

        #region Normal_Operation
        public bool SoftwareTrigger()
        {
            try
            {
                var res = _DataManSystem.SendCommand("TRIGGER ON");
                if(res.PayLoad == "ON")
                {
                    _DataManSystem.SendCommand("TRIGGER OFF");
                }
                return true;
                
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public bool StartReadding()
        {
            try
            {
                _results.ComplexResultCompleted += Results_ComplexResultCompleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool StopReadding()
        {
            try
            {
                _results.ComplexResultCompleted -= Results_ComplexResultCompleted;
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("StopReadding: " + ex.Message);
#endif  
                return false;
            }
        }
        #endregion

        #region PrivateOperation    
        public bool ResetStatistics()
        {
            try
            {
                _DataManSystem.SendCommand("STATISTICS.RESET");
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ResetStatistics: " + ex.Message);
#endif
                return false;
            }

        }
        public bool ResetConfigToDefault()
        {
            try
            {
                _DataManSystem.SendCommand("CONFIG.DEFAULT");
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ResetConfigToDefault: " + ex.Message);
#endif
                return false;
            }

        }
        public bool ResetConfigAndReboot()
        {
            try
            {
                _DataManSystem.SendCommand("REBOOT");
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ResetConfigAndReboot: " + ex.Message);
#endif
                return false;
            }

        }
        #endregion

        #region Settings
        public bool SetTriggerSetting(TRIGGER_TYPE triggerType, DELAY_TYPE delayType, int delayTime, int timeout, int interval = 0, UNIT_TYPE unit = 0, int length = 0)
        {
            try
            {
                switch (triggerType)
                {
                    case TRIGGER_TYPE.SINGLE:
                        _DataManSystem.SendCommand("SET TRIGGER.TYPE 0");
                        TriggerCommonSet(delayType, delayTime, timeout);
                        break;
                    case TRIGGER_TYPE.BRUST:
                        _DataManSystem.SendCommand("SET TRIGGER.TYPE 3");
                        TriggerCommonSet(delayType, delayTime, timeout);

                        break;
                    default:
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void TriggerCommonSet(DELAY_TYPE delayType, int delayTime, int timeout)
        {

            try
            {
                if (delayType == DELAY_TYPE.NONE)
                {
                    _DataManSystem.SendCommand("SET TRIGGER.DELAY-TYPE 0");
                }
                else // Time
                {
                    _DataManSystem.SendCommand("SET TRIGGER.DELAY-TYPE 1");
                    _DataManSystem.SendCommand("SET TRIGGER.DELAY-TIME " + delayTime);
                }
                _DataManSystem.SendCommand("SET DECODER.TIMEOUT " + timeout);
                _DataManSystem.SendCommand("CONFIG.SAVE");
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("TriggerCommonSet :" + ex.Message);
#endif
            }

           
        }
        public void CheckChangeNetworkPar(string ipAddress, string subnet, string port)
        {

            CommonFunctions.GetFromMemoryFile("memoryMapFile_isChangeNetwork", 1, out string isChangedNetwork, out _);
           
            if (isChangedNetwork == "1")
            {
                SetIpAddress(ipAddress, subnet, port);
                _DataManSystem.SendCommand("CONFIG.SAVE");
                _DataManSystem.SendCommand("REBOOT");
            }

        }
        public bool SetIpAddress(string ipAddress, string subnet, string port, bool isDHCP = false)
        {
            try
            {
                _DataManSystem.SendCommand("SET NET-LOCAL.IP-ADDRESS \"" + ipAddress + "\"");
                _DataManSystem.SendCommand("SET NET-LOCAL.SUBNET-MASK \"" + subnet + "\"");
                var res = _DataManSystem.SendCommand($"SET TELNET.PORT {port}");
                Console.WriteLine("Telnet: "+ port + res.PayLoad);
                var state = isDHCP == true ? "ON" : "OFF";
                _DataManSystem.SendCommand("SET NET-LOCAL.DHCP " + state);
                _DataManSystem.SendCommand("CONFIG.SAVE");
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("SetIpAddress" + ex);
#endif
                return false;
            }
        }
        public bool DeviceReboot()
        {
            try
            {
                _DataManSystem.SendCommand("REBOOT");
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("OnlyReboot " + ex.Message);
#endif
                return false;
            }

        }
        public void SetSymbol(bool[] codeSelectArr) // index : 0 - 22
        {
            
#if DEBUG
            //for (int i = 0; i < 25; i++)
            //{
            //    Console.WriteLine(codeSelectArr[i]);
            //}
#endif
            try
            {
                #region CODE 2D
                if (codeSelectArr[0])
                    _DataManSystem.SendCommand("SET SYMBOL.DATAMATRIX ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.DATAMATRIX OFF");
                if (codeSelectArr[1])
                    _DataManSystem.SendCommand("SET SYMBOL.QR ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.QR OFF");
                if (codeSelectArr[2])
                    _DataManSystem.SendCommand("SET SYMBOL.MAXICODE ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.MAXICODE OFF");
                if (codeSelectArr[3])
                    _DataManSystem.SendCommand("SET SYMBOL.AZTECCODE ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.AZTECCODE OFF");
                #endregion

                #region CODE 1D
                if (codeSelectArr[4])
                    _DataManSystem.SendCommand("SET SYMBOL.C128 ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.C128 OFF");
                if (codeSelectArr[5])
                    _DataManSystem.SendCommand("SET SYMBOL.C25 ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.C25 OFF");
                if (codeSelectArr[6])
                    _DataManSystem.SendCommand("SET SYMBOL.C93 ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.C93 OFF");
                if (codeSelectArr[7])
                    _DataManSystem.SendCommand("SET SYMBOL.C39 ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.C39 OFF");

                try
                {
                    if (codeSelectArr[8])
                        _DataManSystem.SendCommand("SET SYMBOL.PHARMACODE ON");
                    else
                        _DataManSystem.SendCommand("SET SYMBOL.PHARMACODE OFF");
                    
                }
                catch (Exception)
                {
                    // Only DM60
                }

                if (codeSelectArr[9])
                    _DataManSystem.SendCommand("SET SYMBOL.CODABAR ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.CODABAR OFF");
                if (codeSelectArr[10])
                    _DataManSystem.SendCommand("SET SYMBOL.I2O5 ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.I2O5 OFF");

                if (codeSelectArr[11])
                    _DataManSystem.SendCommand("SET SYMBOL.UPC-EAN ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.UPC-EAN OFF");

                if (codeSelectArr[12])
                    _DataManSystem.SendCommand("SET SYMBOL.MSI ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.MSI OFF");
                #endregion

                #region STACKED
                if (codeSelectArr[13])
                    _DataManSystem.SendCommand("SET SYMBOL.PDF417 ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.PDF417 OFF");

                try
                {
                    if (codeSelectArr[14])
                        _DataManSystem.SendCommand("SET SYMBOL.EAN-UCC ON");
                    else
                        _DataManSystem.SendCommand("SET SYMBOL.EAN-UCC OFF");
                }
                catch (Exception)
                {
                    // Only DM60
                }

                try
                {
                    if (codeSelectArr[15])
                        _DataManSystem.SendCommand("SET SYMBOL.MICROPDF417 ON");
                    else
                        _DataManSystem.SendCommand("SET SYMBOL.MICROPDF417 OFF");
                }
                catch (Exception)
                {
                    // Only DM60
                }

                if (codeSelectArr[16])
                    _DataManSystem.SendCommand("SET SYMBOL.DATABAR ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.DATABAR OFF");
                #endregion

                #region POSTAL
                if (codeSelectArr[17])
                    _DataManSystem.SendCommand("SET SYMBOL.POSTNET ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.POSTNET OFF");

                if (codeSelectArr[18])
                    _DataManSystem.SendCommand("SET SYMBOL.PLANET ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.PLANET OFF");

                if (codeSelectArr[19])
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-JAP ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-JAP OFF");

                if (codeSelectArr[20])
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-UPU ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-UPU OFF");

                if (codeSelectArr[21])
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-AUS ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-AUS OFF");

                if (codeSelectArr[22])
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-IMB ON");
                else
                    _DataManSystem.SendCommand("SET SYMBOL.4STATE-IMB OFF");

                try
                {
                    if (codeSelectArr[23])
                        _DataManSystem.SendCommand("SET SYMBOL.DOTCODE ON");
                    else
                        _DataManSystem.SendCommand("SET SYMBOL.DOTCODE OFF");

                    if (codeSelectArr[24])
                        _DataManSystem.SendCommand("SET SYMBOL.4STATE-CBC ON");
                    else
                        _DataManSystem.SendCommand("SET SYMBOL.4STATE-CBC OFF");
                }
                catch (Exception)
                {
                    // Only DM280
                }
               

                #endregion
                _DataManSystem.SendCommand("CONFIG.SAVE");
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Set Symbol Fail: " + ex.Message);
#endif
            }

        }
        #endregion

        #region Get Setting Value
        public object[] GetSettingValues()
        {
            try
            {
                return new object[] {
                        _DataManSystem.SendCommand("GET TRIGGER.TYPE").PayLoad,
                        _DataManSystem.SendCommand("GET TRIGGER.DELAY-TYPE").PayLoad,
                        _DataManSystem.SendCommand("GET DECODER.TIMEOUT").PayLoad,
                        _DataManSystem.SendCommand("GET NET-LOCAL.IP-ADDRESS").PayLoad,
                        _DataManSystem.SendCommand("GET NET-LOCAL.SUBNET-MASK").PayLoad,
                        _DataManSystem.SendCommand("GET NET-LOCAL.PORT").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.DATAMATRIX").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.QR").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.MAXICODE").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.AZTECCODE").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.C128").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.C25").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.C93").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.C39").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.PHARMACODE").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.CODABAR").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.I2O5").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.UPC-EAN").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.MSI").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.PDF417").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.EAN-UCC").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.MICROPDF417").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.DATABAR").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.POSTNET").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.PLANET").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.4STATE-JAP").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.4STATE-UPU").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.4STATE-AUS").PayLoad,
                        _DataManSystem.SendCommand("GET SYMBOL.4STATE-IMB").PayLoad,
            };
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ML.SDK.DM60X -> GetSettingValues:" + ex.Message);
#endif
                return null;
            }
        }
        #endregion

        #endregion


    }
}
