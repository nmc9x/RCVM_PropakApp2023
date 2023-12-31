﻿using App.PVCFC_RFID.DataType;
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using static ML.SDK.CVX450.DataType.CVX450DataType;
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
        public static int NumberOfStation = Properties.Settings.Default.NumberOfStation;
        public static bool EnableCamera;


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
            SharedControlHandler SCHObject = new SharedControlHandler();
           
            // Cognex - UDP
            Thread threadProccessExcMessage = new Thread(DeviceTransferExcMessages);
            threadProccessExcMessage.IsBackground = true;
            threadProccessExcMessage.Priority = ThreadPriority.Highest;
            threadProccessExcMessage.Start();
            // Keyence - MMF
            Thread threadProcessExcMessageMMF = new Thread(DeviceTransferExcMessagesMMF);
            threadProcessExcMessageMMF.IsBackground = true;
            threadProcessExcMessageMMF.Priority = ThreadPriority.Highest;
            threadProcessExcMessageMMF.Start();


            // Run Thread
            _ThreadListenDeviceTransferListenning = new Thread(DeviceTransferListenning);
            _ThreadListenDeviceTransferListenning.IsBackground = true;
            _ThreadListenDeviceTransferListenning.Priority = ThreadPriority.Highest;
            _ThreadListenDeviceTransferListenning.Start();
            //End Run Thread
            StationType[] stationSet = { StationType.COGNEX_DATAMAN, StationType.COGNEX_DATAMAN, StationType.COGNEX_DATAMAN, StationType.KEYENCE };
            #region Run Stations - Device transfer
            for (int i = 0; i < NumberOfStation; i++)
            {
                //string socketName = Properties.Settings.Default.DeviceTransferName;
                var stationType = SharedValues.Settings.StationList[i].CameraModel; // stationSet[i];
                object curStation = null;

                switch (stationType)
                {
                    case StationType.COGNEX_DATAMAN:
                        curStation = SharedValues.Settings.StationList[i].DMCamera;
                        break;
                    case StationType.KEYENCE:
                        curStation = SharedValues.Settings.StationList[i].KeyenceCamera;
                        break;
                     default: break;
                }

                var dynamicCurStation = (dynamic)curStation;
                int socketIndex = i;
                string deviceTransferName = dynamicCurStation.DeviceTransferName;
                int uiSocketPort = _UISocketPort;//Port received
                int stationsSocketPort = _StationSocketPort + i;//Port send
                //
                string deviceIP = dynamicCurStation.IPAddress; //dynamicCurStation.IPAddress;//Properties.Settings.Default.RFIDIP + (i + 1).ToString();
                int devicePort =  int.Parse(dynamicCurStation.Port); 
                byte timeout = 0;
                string printerIP = dynamicCurStation.PrinterIP;
                string printerPort = dynamicCurStation.PrinterPort;

                //
                string fullPath = Application.StartupPath + "\\" + deviceTransferName + ".exe";
                string arguments = "";

                arguments += deviceTransferName;//socketName
                arguments += "  " + socketIndex;//socketIndex = int.Parse(args[1]);
                arguments += "  " + uiSocketPort;//uiSocketPort = int.Parse(args[2]);
                arguments += "  " + stationsSocketPort;//bridgeSocketPort = int.Parse(args[3]);
                //
                arguments += "  " + deviceIP;//deviceIP = args[4];
                arguments += "  " + devicePort;//devicePort = int.Parse(args[5]);
                arguments += "  " + timeout;//deviceAddress = (byte)int.Parse(args[6]);
                arguments += "  " + printerIP; //7
                arguments += "  " + printerPort; //8
                //
                SharedValues.Running.StationList[i].TransferID = CommonFunctions.DeviceTransferStartProcess(deviceTransferName, fullPath, arguments);
                //
                //Init Send socket
                SharedValues.Running.StationList[i].UIBridgeSocket = new DM60XUIBridgeSocketHandler();
                SharedValues.Running.StationList[i].UIBridgeSocket.Inits(stationsSocketPort, socketIndex);
                //End Init Send socket
            }
            #endregion//End Run Stations - Device transfers
            #endregion//End Station
        }

        private static void DeviceTransferExcMessagesMMF()
        {
            try
            {
                while (true)
                {

                    Thread.Sleep(1);
                }
            }
            catch (Exception)
            {

#if DEBUG
                Console.WriteLine("DeviceTransferExcMessagesMMF Fail !");
#endif
            }
         
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
                                    case (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand:
                                        #region Device command
                                        switch (receiveBytes[3])
                                        {
                                            case 0:
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
                Thread.Sleep(1);
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

        public static GotCodeModel newCodeItem;
        public static bool isTriggerOn;

        public static ImageSource ImgSrc { get; private set; }

        public static ImageSource[] ImgSrcList { get; set; } = new ImageSource[3];
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
                    newCodeItem = new GotCodeModel
                    {
                        Code = code,
                        Symbol = symb,
                        DecodeTime = dec,
                        Status = sts,
                        DateTimeStr = DateTime.Now.ToString("yyyy-MM-dd") + "/" + DateTime.Now.ToString("HH:mm:ss"),
                        ErrorStr = "Origin"

                    };
                    
                    if (!isTriggerOn)
                    {
                        SharedValues.Running.StationList[index].DataRawList.Add(newCodeItem);
                    }
                    else
                    {
                        SharedValues.Running.StationList[index].DataTriggerList.Add(newCodeItem);
                        //isTriggerOn = false;
                    }
                    var codeBytes = Encoding.ASCII.GetBytes(code);
                    if (codeBytes.Length < 1 || codeBytes == null)
                    {
                        var tempArr = new byte[1] {1};
                        codeBytes = new byte[100];
                        Array.Copy(tempArr, 0, codeBytes, 0,1);
                    }
                    var mmfCodeData = new MemoryMapHelper("mmf_CurrentCodeData_" + index, 100);
                    mmfCodeData.WriteData(codeBytes, 0);
                    OnDataRawListChanged(index);
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
        private static void OnDataRawListChanged(int index)
        {
            if (index == 2) return;
            //var mmf_ImageByteLength = new MemoryMapHelper("mmf_ImageByteLength", 5); // max 5 numbers
            //var lennum = Encoding.ASCII.GetString(mmf_ImageByteLength.ReadData(0, 5)).Trim('\0');
            var mmf_ImageTrigger = new MemoryMapHelper("mmf_ImageTrigger" + index, 100000);
            var imgBytes = mmf_ImageTrigger.ReadData(0, 100000);
            if (imgBytes != null)
            {
                ImgSrc = CommonFunctions.ByteArrayToBitmapImage(imgBytes);
                ImgSrcList[index] = CommonFunctions.ByteArrayToBitmapImage(imgBytes);
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
                byte[] sendCommand = SharedValues.Settings.StationList[index].DMCamera.ConfigsCommand;
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
