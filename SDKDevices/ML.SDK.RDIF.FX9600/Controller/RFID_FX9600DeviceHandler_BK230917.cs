using ML.Connections.Controller;
using ML.Connections.DataType;
using ML.SDK.RDIF_FX9600.DataType;
using ML.SDK.RDIF_FX9600.Model;
using Symbol.RFID3;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Net.NetworkInformation;
using System.Threading;

namespace ML.SDK.RDIF_FX9600.Controller
{
    public class RFID_FX9600DeviceHandler_BK230917
    {
        #region Properties
        public event EventHandler ReceiveDataEvent;//Get data to exc

        private bool _IsConnecting = false;
        public RFIDReader _RFIDReaderAPI;
        private string _IP;
        private uint _Port;
        private uint _Timeout;

        private ConnectionsType.StatusEnum _ConnectionStatus;
        private STATUS_EVENT_TYPE _RFIDEventStatus;
        protected ConcurrentQueue<TagModel> MessageBufferReceivedArr;
        private Thread _ThreadDeviceStatusChecking;

        //--Event Status--//
        private delegate void _UpdateStatus(Events.StatusEventData e);
        private delegate void _UpdateReader(Events.ReadEventData e);
        private _UpdateStatus _UpdateStatusHandler;
        private _UpdateReader _UpdateReaderHandler;
        private Hashtable _TagTable; //

        private TriggerInfo _TriggerInfo;
        private TagStorageSettings _TagStorageSettings;
        private ReaderManagement _ReaderManagement;
        private bool _IsDetectedTag;
        private bool _IsTrigger;
        public bool IsReading { get; private set; }
        public int RSSIValueSet { get; set; }
        public bool RSSIEnable { get; set; }

        #endregion

        public RFID_FX9600DeviceHandler_BK230917(string deviceIP, uint devicePort, uint timeout)
        {
            //
            _IP = deviceIP;// "127.0.0.1";
            _Port = devicePort;//5084;
            _Timeout = timeout;//0;
            //
            _ReaderManagement = new ReaderManagement();//Login to RFID
            _RFIDReaderAPI = null;
            _ConnectionStatus = ConnectionsType.StatusEnum.DisConnected;//ConnectionsType.StatusEnum.Unknown;
            _ThreadDeviceStatusChecking = null;
            _UpdateStatusHandler = new _UpdateStatus(UpdateStatusMethod);
            _UpdateReaderHandler = new _UpdateReader(ActionRead);
            _RFIDEventStatus = STATUS_EVENT_TYPE.UNKNOWN;
            MessageBufferReceivedArr = new ConcurrentQueue<TagModel>();
            _TagTable = new Hashtable();

            //Thread checking status
            _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking)
            {
                Name = "CheckStsDeviceThread",
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            _ThreadDeviceStatusChecking.Start();
            //End Thread checking status

#if DEBUG
            Console.WriteLine("Login to Reader: " + Login(_IP, "admin", "Mylangroup@2023"));
#endif

        }


        #region RFID Zebra
        #region Events
        private void Events_ReadNotify(object sender, Events.ReadEventArgs e)
        {
            _UpdateReaderHandler.Invoke(e.ReadEventData);
        }
        private void Events_StatusNotify(object sender, Events.StatusEventArgs e)
        {
            _UpdateStatusHandler.Invoke(e.StatusEventData);
        }
        #endregion//End Events

        #region Methods
        private void ActionRead(Events.ReadEventData e)
        {

            _IsDetectedTag = true;
            var tagData = _RFIDReaderAPI.Actions.GetReadTags(1);
            if (tagData != null)
            {
                for (int i = 0; i < tagData.Length; i++)
                {
                    if (tagData[i].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                       (tagData[i].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                        tagData[i].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                    {
                        var tag = tagData[i];
                        var tagID = tag.TagID;
                        var keyTag = tagID;
                        var isFound = false;
#if DEBUG
                        Console.WriteLine("===> " + tag.MemoryBankData.ToString() + "+_TagTable: " + _TagTable.Count);
#endif
                        lock (_TagTable.SyncRoot) // lock sync access to hashtable
                        {
                                keyTag = tag.TagID + tag.MemoryBankData.ToString();
                                isFound = _TagTable.ContainsKey(keyTag);
                        }

                        if (isFound)
                        {

                            var item = new TagModel
                            {
                                EPCCode = tagID,
                                AntennaID = tag.AntennaID.ToString(),
                                TIDCode = tag.MemoryBankData.ToString(),
                                RSSIValue = tag.PeakRSSI,
                            };
                            if (RSSIEnable && tag.PeakRSSI >= RSSIValueSet)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Remove(keyTag);
                                    _TagTable.Add(keyTag, item);
                                }
                            }
                            else if (!RSSIEnable)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Remove(keyTag);
                                    _TagTable.Add(keyTag, item);
                                }
                            }
                        }
                        else
                        {
                            var item = new TagModel
                            {
                                EPCCode = tagID,
                                AntennaID = tag.AntennaID.ToString(),
                                TIDCode = tag.MemoryBankData.ToString(),
                                RSSIValue = tag.PeakRSSI,
                            };
                            if (RSSIEnable && tag.PeakRSSI >= RSSIValueSet)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Add(keyTag, item);
                                }
                                new Thread(() => ProccessReceivedMessage(item)).Start();
                            }
                            else if (!RSSIEnable)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Add(keyTag, item);
                                }
                                new Thread(() => ProccessReceivedMessage(item)).Start();
                            }
                        }
                    }
                }
            }
        }
        private void UpdateStatusMethod(Events.StatusEventData e)
        {
            switch (e.StatusEventType)
            {
                case Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    break;

                case Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    break;
                case Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    break;
                case Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    _IsTrigger = false;
                    if (!_IsDetectedTag)
                    {
                        AddNoneTag();
                    }
                    if (_TagTable.Count > 0)
                    {
                        _TagTable.Clear();
                    }
                    //End MinhChau.Nguyen_230915: Addnew
                    break;
                case Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    _IsDetectedTag = false;
                    _IsTrigger = true;   
                    break;
                case Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    break;

                case Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    break;

                case Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    break;

                case Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    break;

                case Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    break;

                case Events.STATUS_EVENT_TYPE.TEMPERATURE_ALARM_EVENT:
                    break;
            }
#if DEBUG
            //Console.WriteLine(startAccess);
#endif
        }
        #endregion//End Methods
        #endregion//End RFID Zebra

        #region Ethernet

        private IPStatus PingIP(string ip, int timeout = 1000)
        {
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send(ip);
                if (reply != null)
                {
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
        #endregion//end Ethernet

        #region Customize

        /// Note: Uncheck Refer 32bit => Properties => Build => Prefer 32-bit
        // Connect Reader RFID FX9600

        public bool Connect()
        {
            if (!_IsConnecting)
            {
                try
                {
                    _IsConnecting = true;
                    _RFIDReaderAPI = new RFIDReader(_IP, _Port, 0);//Only set timeout  = 0
                    if (_RFIDReaderAPI != null)
                    {

                        _RFIDReaderAPI.Connect();
                        if (!_RFIDReaderAPI.IsConnected)
                        {
                            IsReading = false;
                            return false;
                        }

                        // Proccess Excute Message Thread

                        var threadProccessExcMessage = new Thread(ProccessExcMessage)
                        {
                            IsBackground = true,
                            Priority = ThreadPriority.Highest
                        };
                        threadProccessExcMessage.Start();

                        // Event registration procedure
                        _RFIDReaderAPI.Events.StatusNotify += Events_StatusNotify;
                        _RFIDReaderAPI.Events.ReadNotify += Events_ReadNotify; // same as Receive Data Event
                        _RFIDReaderAPI.Events.AttachTagDataWithReadEvent = false;
                        _RFIDReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                        _RFIDReaderAPI.Events.NotifyGPIEvent = true;
                        _RFIDReaderAPI.Events.NotifyBufferFullEvent = true;
                        _RFIDReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                        _RFIDReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                        _RFIDReaderAPI.Events.NotifyReaderExceptionEvent = true;
                        _RFIDReaderAPI.Events.NotifyAccessStartEvent = true;
                        _RFIDReaderAPI.Events.NotifyAccessStopEvent = true;
                        _RFIDReaderAPI.Events.NotifyInventoryStartEvent = true;
                        _RFIDReaderAPI.Events.NotifyInventoryStopEvent = true;


                        return _RFIDReaderAPI.IsConnected;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    //Avoid complict connect
                    _RFIDReaderAPI = null;
                    //End Avoid complict connect
                    //
#if DEBUG
                    Console.WriteLine("CONNECTION ERRORS: " + ex.Message);
#endif
                    return false;// ex.Message;
                }
                finally
                {
                    _IsConnecting = false;
                }
            }
            return false;//null;
        }

        public bool Connect(string ip, uint port, uint timeout)
        {
#if DEBUG
            Console.WriteLine("CONNECT");
            Console.WriteLine("IP: " + ip);
            Console.WriteLine("PORT: " + port.ToString());
            Console.WriteLine("TIMEOUT: " + timeout.ToString());
#endif
            _IP = ip;
            _Port = port;
            _Timeout = timeout;
            return Connect();
        }

        public string Destroys()
        {
            try
            {
                if (Disconnect())
                {
                    return null;
                }
                return ConnectionsType.ResultEnum.Failed.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void DeviceStatusChecking()
        {
            ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);//The First
            //																						 

            while (true)
            {
                try
                {
                    var oldStatus = _ConnectionStatus;
                    var newStatus = ConnectionsType.StatusEnum.Unknown;
                    //
                    if (_RFIDReaderAPI != null)
                    {
                        //newStatus = _RFIDReaderAPI.IsConnected ? ConnectionsType.StatusEnum.Connected : ConnectionsType.StatusEnum.Processing;
                        newStatus = _RFIDReaderAPI.IsConnected ? ConnectionsType.StatusEnum.Connected : ConnectionsType.StatusEnum.Processing;
                    }
                    else
                    {
                        newStatus = ConnectionsType.StatusEnum.DisConnected;
                    }
                    //
                    if (!_IsConnecting)
                    {
                        switch (newStatus)
                        {
                            case ConnectionsType.StatusEnum.Processing:
                                switch (PingIP(_IP))
                                {
                                    case IPStatus.Success:
                                        //if (Connect(_IP, _Port, _Timeout))
                                        if (Connect())
                                        {
                                            newStatus = ConnectionsType.StatusEnum.Connected;
                                        }
                                        else
                                        {
                                            newStatus = ConnectionsType.StatusEnum.Processing;//Ping ok but no connected with devices
                                        }
                                        break;
                                    default:
                                        Disconnect();
                                        newStatus = ConnectionsType.StatusEnum.DisConnected;
                                        break;
                                }
                                break;
                            //
                            case ConnectionsType.StatusEnum.DisConnected:
                                switch (PingIP(_IP))
                                {
                                    case IPStatus.Success:
                                        //if (Connect(_IP, _Port, _Timeout))
                                        if (Connect())
                                        {
                                            newStatus = ConnectionsType.StatusEnum.Connected;
                                        }
                                        else
                                        {
                                            newStatus = ConnectionsType.StatusEnum.Processing;//Ping ok but no connected with devices
                                        }
                                        break;
                                    case IPStatus.Unknown:
                                        //Disconnected
                                        break;
                                    default:
                                        //newStatus = ConnectionsType.StatusEnum.Processing;//Ping ok but no connected with devices
                                        newStatus = ConnectionsType.StatusEnum.DisConnected;//Ping ok but no connected with devices
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
                Thread.Sleep(1000);
            }
        }

        private void ProccessReceivedMessage(TagModel tagData)
        {
#if DEBUG
            // Console.WriteLine("new");
#endif
            MessageBufferReceivedArr.Enqueue(tagData);

        }

        private void ProccessExcMessage()
        {
            while (true)
            {
                if (MessageBufferReceivedArr.Count > 0)
                {
                    try
                    {
                        TagModel resultData = new TagModel();
                        bool resDequeue = MessageBufferReceivedArr.TryDequeue(out resultData);

                        if (resDequeue)
                        {
                            #region Exc Get data
                            /*//Linh.Tran_230914: Command to send TagData
                            byte[] command = new byte[300];
                            //
                            command[0] = (byte)RFID_FX9600DataType.Data;//Command Header ,byte index 4

                            // Byte count data (max: 255)
                            command[1] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.EPCCode), 255)[0]; //byte index 5
                            command[2] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.TIDCode), 255)[0]; //byte index 6
#if DEBUG
                            Console.WriteLine(CommonFunctions.ConvertByteArrayToNumber(new byte[] { command[1], command[2] }));
#endif
                            // Detail data
                            var antID = CommonFunctions.ConvertNumberToByteArray(int.Parse(resultData.AntennaID), 65535);
                            command[3] = antID[0]; //byte index 7
                            command[4] = antID[1]; //byte index 8

                            var rssiVal = CommonFunctions.ConvertNumberToByteArray(int.Parse(resultData.RSSIValue.ToString()), 65535);
                            command[5] = rssiVal[0]; //byte index 9
                            command[6] = rssiVal[1]; // //byte index 10

                            var tagCount = CommonFunctions.ConvertNumberToByteArray(int.Parse(resultData.TotalTagCount.ToString()), 65535);
                            command[7] = tagCount[0]; //byte index 11
                            command[8] = tagCount[1]; //byte index 12

                            // Data
                            byte[] EPCItemsByteArr = Encoding.UTF8.GetBytes(resultData.EPCCode); //EPC ,byte index 13 + length epc
                            byte[] TIDItemsByteArr = Encoding.UTF8.GetBytes(resultData.TIDCode); //TID, 13 + length epc + 1 to end

                            // Command = Header + EPC + TID
                            Array.Copy(EPCItemsByteArr, 0, command, 9, EPCItemsByteArr.Length);
                            Array.Copy(TIDItemsByteArr, 0, command, 9 + EPCItemsByteArr.Length, TIDItemsByteArr.Length);
                            //				
                            */
                            #endregion//End Get Data
                            //
                            //Send data to UI
                            //ConnectionEvents.RaiseDeviceDataReceived(command, EventArgs.Empty);
                            ConnectionEvents.RaiseDeviceDataReceived(resultData, EventArgs.Empty);

#if DEBUG
                            //for (int i = 0; i < command.Length; i++)
                            //{
                            //    Console.Write(command[i] + ";");
                            //}

                            Console.WriteLine("Tag Data -> UI: - EPC: " + resultData.EPCCode + " - TID: " + resultData.TIDCode + " - RSSI: " + resultData.RSSIValue);

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

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        bool isSendDebug = false;
        public void DEBUGAddMessageBuffer(int index)
        {
            var threadProccessExcMessage = new Thread(ProccessExcMessage)
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            threadProccessExcMessage.Start();
            //
            isSendDebug = true;
            //
            new Thread(() =>
            {
                MessageBufferReceivedArr = new ConcurrentQueue<TagModel>();
                int i = 0;
                if (i > 0)
                {
                    while (isSendDebug)
                    {
                        i++;
                        MessageBufferReceivedArr.Enqueue(new TagModel()
                        {
                            TIDCode = index.ToString().PadLeft(5) + i.ToString().PadLeft(7, '0'),
                            EPCCode = index.ToString().PadLeft(5) + i.ToString().PadLeft(11, '0'),
                        });
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    while (isSendDebug)
                    {
                        i++;
                        MessageBufferReceivedArr.Enqueue(new TagModel()
                        {
                            TIDCode = "",
                            EPCCode = "",
                        });
                        Thread.Sleep(50);
                    }
                }
            }).Start();
        }

        public void DEBUGAddMessageBufferStop()
        {
            isSendDebug = false;
        }
        #region Helper Method
        private void AddNoneTag()
        {
            var nullTag = new TagModel
            {
                AntennaID = "1",
                EPCCode = "",
                TIDCode = "",
                RSSIValue = 0,
                TotalTagCount = 0
            };

            new Thread(() => ProccessReceivedMessage(nullTag)).Start();
        }

        #endregion

        #region Settings
        public bool Disconnect()
        {
            if (_RFIDReaderAPI == null) return true;
            try
            {
                if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    _RFIDReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                }
                else
                {
                    _RFIDReaderAPI.Actions.Inventory.Stop();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("DISCONNECTION ERRORS: " + ex.Message);
#endif
            }
            //
            try
            {
                _RFIDReaderAPI.Disconnect();
                bool temp = _RFIDReaderAPI.IsConnected;
                _RFIDReaderAPI = null;
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("DISCONNECTION ERRORS: " + ex.Message);
#endif
                return false;
            }
        }

        public bool StartReadding()
        {
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    //Setting Memorybank
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length <= 0)
                    {
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.DeleteAll();
                        var operation = new TagAccess.Sequence.Operation
                        {
                            AccessOperationCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ
                        };
                        operation.ReadAccessParams.MemoryBank = MEMORY_BANK.MEMORY_BANK_TID;
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.Add(operation);
                    }
                    //
                    //Start operation
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                    {
                        _RFIDReaderAPI.Actions.PurgeTags();
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(new AccessFilter(), _TriggerInfo, new AntennaInfo());
                        IsReading = true;
                        _IsTrigger = false;//MinhChau.Nguyen: Reset trigger params
#if DEBUG
                        Console.WriteLine("Start Read: " + IsReading);
#endif
                        return true;

                    }
                }

                return false;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Start Readding Fail: " + ex.Message);
#endif
                return false;
            }
        }

        public bool StopReadding()
        {
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                    {
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();

#if DEBUG
                        Console.WriteLine("Stop Read: " + !IsReading);
#endif
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Stop Readding Fail: " + ex.Message);
#endif
                return false;
            }
        }

        public bool Login(string ip, string username, string password)
        {
#if DEBUG
            return true;
#endif
            if (ip == null)
            {
                ip = _IP;
            }
            try
            {
                if (_ReaderManagement == null) return false;

                LoginInfo loginInfo = new LoginInfo
                {
                    HostName = ip,
                    UserName = username,
                    Password = password,
                    SecureMode = SECURE_MODE.HTTPS,
                    ForceLogin = true
                };
                _ReaderManagement.Login(loginInfo, READER_TYPE.FX);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Logout()
        {
            try
            {
                if (_ReaderManagement == null) return false;
                _ReaderManagement.Logout();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClearReport()
        {
            try
            {
                // Do somthing
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Reboot()
        {
            try
            {
                if (_ReaderManagement == null) return false;
                _ReaderManagement.Restart();
                return true;
            }
            catch (Exception)
            {
                //
                return false;
            }
        }

        public bool ResetFactoryDefault()
        {
            try
            {
                if (_RFIDReaderAPI == null || !_RFIDReaderAPI.IsConnected) return false;
                _RFIDReaderAPI.Config.ResetFactoryDefaults();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AnthennaConfig(int antID, int transPowrId)
        {
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    var antIDArr = _RFIDReaderAPI.Config.Antennas.AvailableAntennas;
                    var antCfg = _RFIDReaderAPI.Config.Antennas[antIDArr[antID]].GetConfig();
                    var transmitPowerValues = _RFIDReaderAPI.ReaderCapabilities.TransmitPowerLevelValues; // get list to UI
                    antCfg.TransmitPowerIndex = (ushort)transPowrId < (ushort)(transmitPowerValues.Length - 1) ? (ushort)transPowrId : (ushort)(transmitPowerValues.Length - 1);
                    _RFIDReaderAPI.Config.Antennas[antIDArr[antID]].SetConfig(antCfg);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GPIOConfig(bool[] numGPIPortArr, bool[] numGPOPortArr)
        {
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    // GPI enable
                    for (int j = 0; j < numGPIPortArr.Length; j++)
                    {
                        _RFIDReaderAPI.Config.GPI[j + 1].Enable = numGPIPortArr[j];
                    }

                    // GPO state change
                    for (int i = 0; i < numGPOPortArr.Length; i++)
                    {
                        _RFIDReaderAPI.Config.GPO[i + 1].PortState = numGPOPortArr[i] ? GPOs.GPO_PORT_STATE.TRUE : GPOs.GPO_PORT_STATE.FALSE;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TriggerConfig(
            START_TRIGGER_TYPE modeStart,
            STOP_TRIGGER_TYPE modeStop,
            int gpiStart,
            bool gpiStartEvent,
            int durationStop,
            int tagRpTrigger,
            int gpiStop,
            bool gpiStopEvent,
            uint timeoutStop
            )
        {
            if (_TriggerInfo == null)
                _TriggerInfo = new TriggerInfo();
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    //Start Trigger
                    switch (modeStart)
                    {
                        case START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE: // Immediate
                            _TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE;
                            break;
                        case START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI: // GPI
                            _TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI;
                            _TriggerInfo.StartTrigger.GPI.PortNumber = gpiStart;
                            _TriggerInfo.StartTrigger.GPI.GPIEvent = gpiStartEvent;
                            break;
                        default:
                            return false;
                    }

                    //Stop Trigger
                    switch (modeStop)
                    {
                        case STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE: // Imediate
                            _TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE;
                            break;
                        case STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION: // Duration
                            _TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                            _TriggerInfo.StopTrigger.Duration = (uint)durationStop;

                            break;
                        case STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_GPI_WITH_TIMEOUT:
                            _TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_GPI_WITH_TIMEOUT;
                            _TriggerInfo.StopTrigger.GPI.PortNumber = gpiStop;
                            _TriggerInfo.StopTrigger.GPI.Timeout = timeoutStop;
                            _TriggerInfo.StopTrigger.GPI.GPIEvent = gpiStopEvent;
                            break;

                        default:
                            return false;
                    }
                    // Tag Report Trigger
                    _TriggerInfo.TagReportTrigger = (uint)tagRpTrigger;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TagStorageConfig(int maxTagCount, int maxSizeMemoryBank, int maxTagIDLength)
        {
            _TagStorageSettings = new TagStorageSettings();
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    //Setting
                    _TagStorageSettings.MaxSizeMemoryBank = (uint)maxSizeMemoryBank;
                    _TagStorageSettings.MaxTagCount = (uint)maxTagCount;
                    _TagStorageSettings.MaxTagIDLength = (uint)maxTagIDLength;
#if DEBUG
                    // Console.WriteLine(maxTagCount + " - " + maxSizeMemoryBank + " -" + maxTagIDLength);
#endif
                    _RFIDReaderAPI.Config.SetTagStorageSettings(_TagStorageSettings);
#if DEBUG
                    // Console.WriteLine(maxTagCount + " - " + maxSizeMemoryBank + " -" + maxTagIDLength);
#endif
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return false;
            }
        }
        // public bool
        #endregion//Settings

        #endregion//End Customize
    }
}
