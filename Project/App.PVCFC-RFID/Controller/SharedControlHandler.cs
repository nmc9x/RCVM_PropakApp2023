using App.PVCFC_RFID.Model;
using ML.Common.Controller;
using ML.Connections.DataType;
using ML.DeviceTransfer.PVCFCRFID.Model;
using ML.Languages;
using ML.SDK.DM60X.Controller;
using ML.SDK.DM60X.Model;
using ML.SDK.RDIF_FX9600.DataType;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using static ML.SDK.DM60X.DataType.DM60XDataType;

namespace App.PVCFC_RFID.Controller
{
    public class SharedControlHandler
    {
        private static int _NumberOfStation = Properties.Settings.Default.NumberOfStation;
        private static int _UISocketPort = Properties.Settings.Default.SocketPortUI;
        private static int _StationSocketPort = Properties.Settings.Default.SocketPortStation;
        private static ConcurrentQueue<byte[]> _MessageBufferReceivedArr = new ConcurrentQueue<byte[]>();//Received data
        // MinhChau05102323
        public static event EventHandler DataRawListChanged;
        public static Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        //
        private static Thread _ThreadCheckDeviceTransferAliving;
        private static Thread _ThreadListenDeviceTransferListenning;
        //
        private static DateTime _DatetimeCheckTimeOutScanData = DateTime.Now;
        public static readonly object LockObject = new object();
        //
        public static void InitDeviceTransfer()
        {
            #region Thread check alive device transfer
            _ThreadCheckDeviceTransferAliving = new Thread(CheckDeviceTransferAliving);
            _ThreadCheckDeviceTransferAliving.IsBackground = true;
            _ThreadCheckDeviceTransferAliving.Priority = ThreadPriority.Highest;
            _ThreadCheckDeviceTransferAliving.Start();
            #endregion//End Thread check alive device transfer

            #region Station
            //
            Thread threadProccessExcMessage = new Thread(DeviceTransferExcMessages);
            threadProccessExcMessage.IsBackground = true;
            threadProccessExcMessage.Priority = ThreadPriority.Highest;
            threadProccessExcMessage.Start();
            //

            // Run Thread
            _ThreadListenDeviceTransferListenning = new Thread(DeviceTransferListenning);
            _ThreadListenDeviceTransferListenning.IsBackground = true;
            _ThreadListenDeviceTransferListenning.Priority = ThreadPriority.Highest;
            _ThreadListenDeviceTransferListenning.Start();
            //End Run Thread

            #region Run Stations - Device transfer
            for (int i = 0; i < SharedValues.Running.NumberOfStation; i++)
            {
                string socketName = Properties.Settings.Default.DeviceTransferName;
                int socketIndex = i;
                int uiSocketPort = _UISocketPort;//Port received
                int stationsSocketPort = _StationSocketPort + i;//Port send
                //
                string deviceIP = SharedValues.Settings.StationList[i].DM60X.IPAddress;//Properties.Settings.Default.RFIDIP + (i + 1).ToString();
                int devicePort = int.Parse(SharedValues.Settings.StationList[i].DM60X.Port) ; 
                byte timeout = 0;
                //
                string fullPath = Application.StartupPath + "\\" + Properties.Settings.Default.DeviceTransferName + ".exe";
                string arguments = "";

                arguments += socketName;//socketName
                arguments += "  " + socketIndex;//socketIndex = int.Parse(args[1]);
                arguments += "  " + uiSocketPort;//uiSocketPort = int.Parse(args[2]);
                arguments += "  " + stationsSocketPort;//bridgeSocketPort = int.Parse(args[3]);
                //
                arguments += "  " + deviceIP;//deviceIP = args[4];
                arguments += "  " + devicePort;//devicePort = int.Parse(args[5]);
                arguments += "  " + timeout;//deviceAddress = (byte)int.Parse(args[6]);
                arguments += "  " + SharedValues.Settings.SysServerURL;//deviceAddress = (byte)int.Parse(args[7]);
                arguments += "  " + SharedValues.Settings.SysServerPort.ToString();//deviceAddress = (byte)int.Parse(args[8]);
                arguments += "  " + SharedValues.Running.IsOffline.ToString();//deviceAddress = (byte)int.Parse(args[9]);
                //
                SharedValues.Running.StationList[i].TransferID = CommonFunctions.DeviceTransferStartProcess(socketName, fullPath, arguments);
                //
                //Init Send socket
                SharedValues.Running.StationList[i].UIBridgeSocket = new DM60XUIBridgeSocketHandler();
                SharedValues.Running.StationList[i].UIBridgeSocket.Inits(stationsSocketPort, socketIndex);
                //End Init Send socket
            }
            #endregion//End Run Stations - Device transfers
            #endregion//End Station
        }

        public static void KillDeviceTransfer(int index = -1)
        {
            if (index < 0)
            {
                //Kill all
                for (int i = 0; i < SharedValues.Running.NumberOfStation; i++)
                {
                    SharedFunctions.DeviceTransferKillProcess(SharedValues.Running.StationList[i].TransferID);
                }
            }
            else
            {
                SharedFunctions.DeviceTransferKillProcess(SharedValues.Running.StationList[index].TransferID);
            }
        }

        public static void KillDeviceTransferBefore()
        {
            SharedFunctions.DeviceTransferKillProcess(Properties.Settings.Default.DeviceTransferName);
        }


        #region Running thread
        private static void CheckDeviceTransferAliving()
        {
            while (true)
            {
                foreach (RunningStationModel running in SharedValues.Running.StationList)
                {
#if DEBUG
                    if (running.TransferStatus != ConnectionsType.StatusEnum.Connected)
                    {
                        running.TransferStatus = ConnectionsType.StatusEnum.Connected;
                        running.Status = running.RefreshStatus(null);
                        SharedEvents.RaiseStationDeviceStatusChanged(running.Index);
                    }
                    Thread.Sleep(50);
                    continue;
#endif
                    ConnectionsType.StatusEnum stationsTransferStatus = running.TransferStatus;
                    if (stationsTransferStatus != ConnectionsType.StatusEnum.Unknown)
                    {
                        if (running.TransferID > 0)
                        {
                            //Check RFID transfers
                            if (!SharedFunctions.DeviceTransferCheckAlive(running.TransferID))
                            {
                                running.TransferStatus = ConnectionsType.StatusEnum.Unknown;
                                running.Status = running.RefreshStatus(null);
                                SharedEvents.RaiseStationDeviceStatusChanged(running.Index);
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Communicate with Device transfer - Linh.Tran_230719
        /// </summary>
        private static void DeviceTransferListenning()
        {
            try
            {
                UdpClient socketManager = new UdpClient(_UISocketPort);
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    try
                    {
                        byte[] receiveBytes = socketManager.Receive(ref remoteIpEndPoint);
                        //Linh.Tran_210902: Update fix errors miss Packages
                        Thread threadTemp = new Thread(() => ProccessReceivedMessage(receiveBytes));
                        threadTemp.IsBackground = true;
                        threadTemp.Start();
                        //End Linh.Tran_210902: Update fix errors miss Packages
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        MessageBox.Show("DeviceTransferListenning: " + ex.Message);
#endif
                    }
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Languages.Errors, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            }
        }

        protected static void ProccessReceivedMessage(byte[] message)
        {
            _MessageBufferReceivedArr.Enqueue(message);
        }

        private static void DeviceTransferExcMessages()
        {
            while (true)
            {
                if (_MessageBufferReceivedArr.Count > 0)
                {
                    try
                    {
                        byte[] receiveBytes = null;
                        _MessageBufferReceivedArr.TryDequeue(out receiveBytes);
                        
                        switch (receiveBytes[0])
                        {
                            case (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType:
                                int socketIndex = receiveBytes[2];
                                switch (receiveBytes[1])
                                {
                                    case (byte)ConnectionsType.SockTypeCommandEnum.UICommand:
                                        #region UI
                                        switch (receiveBytes[3])
                                        {
                                            case (byte)ConnectionsType.UISocketCommandEnum.DeviceStatus:
                                                #region Device status
                                                SharedValues.Running.StationList[socketIndex].TransferStatus = (ConnectionsType.StatusEnum)receiveBytes[4];
                                                SharedValues.Running.StationList[socketIndex].Status = SharedValues.Running.StationList[socketIndex].RefreshStatus(null);


                                                SharedEvents.RaiseStationDeviceStatusChanged(socketIndex);
                                                #endregion//End Device status
                                                break;
                                            case (byte)ConnectionsType.UISocketCommandEnum.Start:
                                                SharedValues.Running.StationList[socketIndex].IsReplyStart = true;
                                                #region Start - Linh.Tran_230910
                                                bool isResult = (receiveBytes[4] != 0);
                                                int lengthStr = CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[5], receiveBytes[6] });
                                                string strErrors = CommonFunctions.ConvertByteArrayToString(receiveBytes.Skip(7).Take(lengthStr).ToArray());//3 + 
                                                #endregion//End Start - Linh.Tran_230910
                                                SharedEvents.RaiseStartFeedbackFromTransferEvents(new Tuple<int, bool, string>(socketIndex, isResult, strErrors));
                                                break;
                                            case (byte)ConnectionsType.UISocketCommandEnum.Page:
                                                #region Get pages
                                                int scanSucess = 0;
                                                int scanFailed = 0;
                                                int activeSuccess = 0;
                                                int activeFailed = 0;
                                                int total = 0;
                                                PVCFCProductItemModel product = PVCFCProductItemModel.GetProductTagItems(receiveBytes.Skip(4).ToArray(), ref scanSucess, ref scanFailed, ref activeSuccess, ref activeFailed, ref total);
                                                SharedValues.Running.StationList[socketIndex].Schedules.ProductItemsList.Add(product);
                                                SharedValues.Running.StationList[socketIndex].Schedules.ScanSucess = scanSucess;
                                                SharedValues.Running.StationList[socketIndex].Schedules.ScanFailed = scanFailed;
                                                SharedValues.Running.StationList[socketIndex].Schedules.ActiveSuccess = activeSuccess;
                                                SharedValues.Running.StationList[socketIndex].Schedules.ActiveFailed = activeFailed;
                                                SharedValues.Running.StationList[socketIndex].Schedules.Total = total;
                                                //
                                                //
                                                switch (SharedValues.Running.StationList[socketIndex].Status)
                                                {
                                                    case ML.Common.Enum.RunningStatusEnum.Processing:
                                                    case ML.Common.Enum.RunningStatusEnum.Ready:
                                                        SharedValues.Running.StationList[socketIndex].Status = ML.Common.Enum.RunningStatusEnum.Starting;
                                                        SharedEvents.RaiseStationDeviceStatusChanged(socketIndex);
                                                        break;
                                                }
                                                SharedEvents.RaisePageFeedbackFromTransferEvents(socketIndex);
                                                //
                                                #endregion//End Get pages
                                                break;
                                            case (byte)ConnectionsType.UISocketCommandEnum.Stop:
                                                SharedValues.Running.StationList[socketIndex].IsReplyStop = true;
                                                SharedEvents.RaiseStopFeedbackFromTransferEvents(socketIndex);
                                                break;
                                        }
                                        #endregion//End UI
                                        break;
                                    case (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand:
                                        #region Device command
                                        switch (receiveBytes[3])
                                        {
                                            case (byte)DM60X_MODE_TYPE.Data:
                                                GetRawDataToUI(socketIndex, receiveBytes);
                                                break;

                                            case (byte)DM60X_MODE_TYPE.Config:
                                                FeedbackConfigProcess(socketIndex, receiveBytes);
                                                break;

                                            case (byte)DM60X_MODE_TYPE.Operation:
                                                FeedbackOperationProcess(socketIndex, receiveBytes);
                                                break;
                                        }
                                        #endregion//End Device command
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        MessageBox.Show("DeviceTransferProcessMessages: " + ex.Message);
#endif
                    }

                }
                System.Threading.Thread.Sleep(1);
            }
        }

        #region Destroy
        private static string DestroysThreadListenDeviceTransferListenning()
        {
            try
            {
                //Kill thread insert database
                if (_ThreadListenDeviceTransferListenning != null && _ThreadListenDeviceTransferListenning.IsAlive)
                {
                    //release thread
                    _ThreadListenDeviceTransferListenning.Abort();
                    _ThreadListenDeviceTransferListenning = null;
                    //
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion//End Destroy
        #endregion//End Running thread

        #region Start/Stop
        public static void StartProductDelivery(int index)
        {
            //
            SharedValues.Running.StationList[index].UIBridgeSocket.SendStartToDeviceTransfer(SharedValues.Running.IsOffline,
                                                                                             SharedValues.Running.StationList[index].Schedules.DeliveryID,
                                                                                             SharedValues.Running.StationList[index].Schedules.SaveFiles);
        }

        public static void StopProductDelivery(int index)
        {
            SharedValues.Running.StationList[index].UIBridgeSocket.SendStopToDeviceTransfer();
        }
        #endregion//End Start/Stop

        #region RFID Operation
        public static bool SendRFIDOperationCmd(int index)
        {
            //            try
            //            {
            //                byte[] sendCommand = SharedValues.Settings.StationList[index].RFID.OperationsCommand;
            //                SharedValues.Running.StationList[index].UIBridgeSocket.SendOperationToDeviceTransfer(sendCommand);
            //                return true;
            //            }
            //            catch (Exception ex)
            //            {
            //#if DEBUG
            //                Console.WriteLine("SendRFIDOperationCmd: "+ex.Message);
            //#endif
            //                return false;
            //            }
            //try
            //{
            //    byte[] sendCommand = SharedValues.Settings.StationList[index].RFID.OperationsCommand;
            //    SharedValues.Running.StationList[index].UIBridgeSocket.SendOperationToDeviceTransfer(sendCommand);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            //finally
            //{

            //}
            return false;
        }

        #endregion

        #region RFID config
        public static bool SendRFIDSettings(int index)
        {
            #region RFID
            //try
            //{
            //    byte[] sendCommand = SharedValues.Settings.StationList[index].RFID.ConfigsCommand;
            //    SharedValues.Running.StationList[index].UIBridgeSocket.SendConfigToDeviceTransfer(sendCommand);
            //    //
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            //finally
            //{
            //    //
            //}
            return false; // add temp;
            #endregion
        }
        private static void GetRawDataToUI(int index, byte[] receiveByte)
        {
            try
            {
                /*
                 * Byte 3 : Data Header
                */
                // Get length
                var length_code = CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveByte[4] });
                var length_symb = CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveByte[5] });
                var length_dec = CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveByte[6] , receiveByte[7] });
                var length_sts = CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveByte[8] });

                // Get data
                var code = Encoding.UTF8.GetString(receiveByte.Skip(9).Take(length_code).ToArray()); // 
                var symb = Encoding.UTF8.GetString(receiveByte.Skip(9 + length_code).Take(length_symb).ToArray());
                var dec = Encoding.UTF8.GetString(receiveByte.Skip(9 + length_code+ length_symb).Take(length_dec).ToArray());
                var sts = Encoding.UTF8.GetString(receiveByte.Skip(9 + length_code + length_symb + length_dec).Take(length_sts).ToArray());

                // Get Result List
                _dispatcher.Invoke(() =>
                {
                    var foundItem = SharedValues.Running.StationList[index].DataRawList.FirstOrDefault(x => x.Code == code && x.Symbol == symb);
                    if (foundItem == null)
                    {

                        SharedValues.Running.StationList[index].DataRawList.Add(
                                  new GotCodeModel
                                  {
                                      Code = code,
                                      Symbol = symb,
                                      DecodeTime = dec,
                                      Status = sts
                                  }
                                  );
                    }
                    else
                    {
                        int foundItemsIndex = SharedValues.Running.StationList[index].DataRawList.ToList().FindIndex(x => x.Code == code && x.Symbol == symb);
                        SharedValues.Running.StationList[index].DataRawList[foundItemsIndex].Count++;
                    }
                    DataRawListChanged?.Invoke(index, EventArgs.Empty);
                });
#if DEBUG

                Console.WriteLine("code: " + code);
                Console.WriteLine("symbol: " + symb);
                Console.WriteLine("decode time: " + dec);
                Console.WriteLine("Status: " + sts);
                Console.WriteLine(SharedValues.Running.StationList[index].DataRawList.Count);
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Get raw data: " + ex.Message);
#endif
            }
        }

       
        private static void FeedbackConfigProcess(int index, byte[] receiveByte)
        {
            SharedValues.Running.StationList[index].DM60XFeedback.TriggerConfFeedback = (receiveByte[4] == 1);
            SharedValues.Running.StationList[index].DM60XFeedback.NetworkConfFeebback = (receiveByte[5] == 1);
            SharedValues.Running.StationList[index].DM60XFeedback.SymbolicConfFeebback = (receiveByte[6] == 1);
            SharedValues.Running.StationList[index].DM60XFeedback.RebootFeedback = (receiveByte[7] == 1);
            SharedValues.Running.StationList[index].DM60XFeedback.ResetAndRebootFeedback = (receiveByte[8] == 1);

            //SharedValues.Running.StationList[index].RFID_FX9600Feedback.GPIOConfigFeedback = (receiveByte[4] == 1);
            //SharedValues.Running.StationList[index].RFID_FX9600Feedback.TagStorageConfigFeedback = receiveByte[5] == 1;
            //SharedValues.Running.StationList[index].RFID_FX9600Feedback.AntennaConfigFeedback = receiveByte[6] == 1;
            //SharedValues.Running.StationList[index].RFID_FX9600Feedback.TriggerConfigFeedback = receiveByte[7] == 1;
        }
        private static void FeedbackOperationProcess(int index, byte[] receiveByte)
        {
            switch ((RFID_OPERATION_TYPE)receiveByte[4])
            {
                case RFID_OPERATION_TYPE.StartRead:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.StartReadFeedback = receiveByte[5] == 1;
                    break;
                case RFID_OPERATION_TYPE.StopRead:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.StopReadFeedback = receiveByte[5] == 1;
                    break;
                case RFID_OPERATION_TYPE.Disconnect:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.DisconnectFeedback = receiveByte[5] == 1;
                    break;
                case RFID_OPERATION_TYPE.ClearReport:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.ClearRpFeedback = receiveByte[5] == 1;
                    break;
                case RFID_OPERATION_TYPE.Reboot:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.RebootFeedback = receiveByte[5] == 1;
                    break;
                case RFID_OPERATION_TYPE.ResetFactoryDefault:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.ResetFactoryFeedback = receiveByte[5] == 1;
                    break;
                case RFID_OPERATION_TYPE.Login:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.LoginFeedback = receiveByte[5] == 1;
                    break;
                case RFID_OPERATION_TYPE.Logout:
                    SharedValues.Running.StationList[index].RFID_FX9600Feedback.LogoutFeedback = receiveByte[5] == 1;
                    break;
            }
        }
        #endregion//End RFID config

        #region DM60XConfig
        public static bool SendDM60XSettings(int index)
        {
            try
            {
                byte[] sendCommand = SharedValues.Settings.StationList[index].DM60X.ConfigsCommand;
                SharedValues.Running.StationList[index].UIBridgeSocket.SendConfigToDeviceTransfer(sendCommand);
                //
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                //
            }
        }
        #endregion

    }
}
