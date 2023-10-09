using ML.Connections.Controller;
using ML.Connections.DataType;
using RFID_Reader_Cmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.SDK.RFID.Controller
{
    public class RFIDDeviceHandler
    {
        #region Properties
        private MainListener _RFIDListener = null;
        private Thread _ThreadDeviceStatusChecking = null;
        private string _IP = "192.168.10.50";
        private int _Port = 80;
        private byte _DeviceAddress = 255;
        //
        private ConnectionsType.StatusEnum _ConnectionStatus = ConnectionsType.StatusEnum.Unknown;
        #endregion//End Properties

        #region Inits Connections
        public string Connect(string ip, int port, byte deviceAddress)
        {
            try
            {
#if DEBUG
                Console.WriteLine("CONNECT");
                Console.WriteLine("IP: " + ip);
                Console.WriteLine("PORT: " + port.ToString());
#endif
                _IP = ip;
                _Port = port;
                _DeviceAddress = deviceAddress;
                //
                _RFIDListener = new TCPIPServerListener(_IP, _Port);
                if (_RFIDListener != null)
                {
                    if (_RFIDListener.Connect())
                    {
                        //
                        _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking);
                        _ThreadDeviceStatusChecking.IsBackground = true;
                        _ThreadDeviceStatusChecking.Priority = ThreadPriority.Highest;
                        _ThreadDeviceStatusChecking.Start();
                        //
                        _RFIDListener.ReceiveDataEvent += RFIDListener_ReceiveDataEvent;
                    }
                    else
                    {
                        _ConnectionStatus = ConnectionsType.StatusEnum.DisConnected;
                        ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
                        //
                        _RFIDListener = null;
                    }

                }
                if (_RFIDListener != null)
                {
                    return null;
                }
                return ConnectionsType.ResultEnum.Failed.ToString();
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ERRORS: " + ex.Message);
#endif
                return ex.Message;
            }
        }

        public string Destroys()
        {
            try
            {
                //Kill thread insert database
                if (_ThreadDeviceStatusChecking != null && _ThreadDeviceStatusChecking.IsAlive)
                {
                    //release thread
                    _ThreadDeviceStatusChecking.Abort();
                    _ThreadDeviceStatusChecking = null;
                    //
                }
                //
                if (_RFIDListener != null)
                {
                    _RFIDListener.Disconnect();
                    _RFIDListener = null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void DeviceStatusChecking()
        {
#if DEBUG
            Console.WriteLine("DeviceStatusChecking");
#endif
            while (true)
            {
                try
                {
                    #region Check connection status
                    ConnectionsType.StatusEnum oldRFIDStatus = ConnectionsType.StatusEnum.Unknown;
                    ConnectionsType.StatusEnum newRFIDStatus = ConnectionsType.StatusEnum.Unknown;
                    //
                    if (_RFIDListener != null)
                    {
                        oldRFIDStatus = _ConnectionStatus;
                        if (_RFIDListener.CheckAlive())
                        {
                            newRFIDStatus = ConnectionsType.StatusEnum.Connected;
                        }
                        else if (_RFIDListener.CheckConnections())
                        {
                            newRFIDStatus = ConnectionsType.StatusEnum.Processing;
                        }
                        else
                        {
                            newRFIDStatus = ConnectionsType.StatusEnum.DisConnected;
                        }
                    }
                    else
                    {
                        newRFIDStatus = ConnectionsType.StatusEnum.DisConnected;
                    }
                    //
                    if (newRFIDStatus != oldRFIDStatus)
                    {
                        if (_RFIDListener != null)
                        {
                            _ConnectionStatus = newRFIDStatus;
                            //
                            ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
                        }
                    }
                    #endregion//End Check connection status
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ERRORS: " + ex.Message);
                }
                //
                Thread.Sleep(100);
            }
        }
        #endregion//End Inits Connections

        #region Events
        private void RFIDListener_ReceiveDataEvent(object sender, EventArgs e)
        {
            try
            {
                byte[] resultBytes = (sender as byte[]);
                //
                int indexFF = 0;
                byte byteSeparate = 0xFF;
                int byteLength = 41;
                while (indexFF >= 0)
                {
                    indexFF = Array.IndexOf(resultBytes, byteSeparate);//{AA, AA, FF,...[40]}
                    //int indexFFNext = Array.IndexOf(resultBytes.Skip(indexFF + 1).ToArray(), byteSeparate);
                    //byte[] excByte = resultBytes.Skip(indexFF - 2).Take(indexFFNext + 1 + 1).ToArray();//{AA, AA, FF,...[40]}
                    byte[] excByte = resultBytes.Skip(indexFF - 2).Take(byteLength).ToArray();//{AA, AA, FF,...[40]}
                    resultBytes = resultBytes.Skip(indexFF - 2 + excByte.Length).ToArray();
                    if (excByte.Length < byteLength)
                    {
                        continue;
                    }
                    
                    Commands.ReaderResponseFrameString rxStrPkts = new Commands.ReaderResponseFrameString(true);
                    //rxStrPkts = Commands.GetReaderResponsFrameStringStructFromHexBuffer(resultBytes);
                    rxStrPkts = Commands.GetReaderResponsFrameStringStructFromHexBuffer(excByte);
                    //
                    if (rxStrPkts.strStatus == ConstCode.FAIL_OK)
                    {
                        #region Separate command
                        switch (rxStrPkts.strCmdH)
                        {
                            case ConstCode.CMD_EXE_FAILED:
                                break;
                            case ConstCode.CMD_INVENTORY:         //Succeed to Read EPC    
                                break;
                            case ConstCode.CMD_MULTI_ID:         //Succeed to Read EPC    
                                break;
                            case ConstCode.CMD_STOP_MULTI:
                                break;
                            case ConstCode.CMD_READ_DATA:         //Read Tag Memory
                                break;
                            case ConstCode.CMD_RFM_TAG:         //Read RFM Tag Memory    SureLion
                                break;
                            case ConstCode.CMD_WRITE_DATA:
                                break;
                            case ConstCode.CMD_LOCK_UNLOCK:
                                break;
                            case ConstCode.CMD_KILL:
                                break;
                            case ConstCode.CMD_GET_SELECT_PARA:
                                break;
                            case ConstCode.CMD_IO_CONTROL:
                                break;
                            case ConstCode.CMD_SET_REGION:
                                break;
                            case ConstCode.CMD_GET_REGION:
                                break;
                            case ConstCode.CMD_ANT:
                                break;
                            case "27":
                                break;
                            case ConstCode.CMD_GET_MODULE_INFO:
                                #region CMD_GET_MODULE_INFO
                                switch (rxStrPkts.strCmdL)
                                {
                                    case ConstCode.MODULE_FIRMWARE_VERSION_SUBCMD:
                                        break;
                                    default:
                                        switch (rxStrPkts.strParameters[0])
                                        {
                                            case ConstCode.MODULE_HARDWARE_VERSION_FIELD:
                                                break;
                                            case ConstCode.MODULE_SOFTWARE_VERSION_FIELD:
                                                break;
                                        }
                                        break;
                                }
                                //Ready connected
                                #endregion//End CMD_GET_MODULE_INFO
                                break;
                            //case ConstCode.CMD_IO_CONTROL://"1A"
                            //    break;
                            case ConstCode.CMD_READ_ADDR: //SureLion
                                break;
                        }
                        #endregion//End Separate command

                        #region Send Received data
                        //ConnectionEvents.RaiseDeviceDataReceived(rxStrPkts.strParameters, EventArgs.Empty);
                        #endregion//End Send Received data
                    }
                    //
                    System.Threading.Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        #endregion//End Events

        #region Methods
        
        #endregion//End Methods
    }
}
