using ML.Common.Controller;
using ML.Connections.DataType;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using ML.DeviceTransfer.PVCFCRFID.Model;
using ML.SDK.RDIF_FX9600.Controller;
using ML.SDK.RDIF_FX9600.DataType;
using Symbol.RFID3;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ML.DeviceTransfer.PVCFCRFID.Controller
{
    public class PVCFCRFIDUIBridgeSocketModel : RFID_FX9600UIBridgeSocketHandler
    {
        // Frame 
        // [0] ConnectionsType.SocketTransferTypeCommandEnum.DeviceType
        // [1] ConnectionsType.SockTypeCommandEnum.UICommand
        // [2] socketIndex
        // [3] mode

        public override void ProcessReceivedMessageFromUI(byte[] receiveBytes)
        {

#if DEBUG
            //receiveBytes[0] = (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType;
            //receiveBytes[1] = (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand;
            //receiveBytes[2] = 0;
            //receiveBytes[3] = (byte)RFID_FX9600DataType.Config;
#endif
            try
            {
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

                                        break;
                                    case (byte)ConnectionsType.UISocketCommandEnum.Start://Linh.Tran_230911
                                        #region Start - Linh.Tran_230911
                                        bool isResults = false;
                                        string strErrors = "";
                                        try
                                        {
                                            string strId = "";
                                            string schedulesFiles = "";
                                            #region Get Params
                                            try
                                            {
                                                PVCFCSharedValues.Running.IsOffline = (receiveBytes[4] != 0);
                                                int lengthId = (receiveBytes[5] | (receiveBytes[6] << 8));
                                                int lengthSchedulesFiles = (receiveBytes[7 + lengthId] | (receiveBytes[8 + lengthId] << 8));
                                                //
                                                strId = Common.Controller.CommonFunctions.ConvertByteArrayToString(receiveBytes.Skip(7).Take(lengthId).ToArray());//3 + 1+ 1+ 2
                                                schedulesFiles = Common.Controller.CommonFunctions.ConvertByteArrayToString(receiveBytes.Skip(9 + lengthId).Take(lengthSchedulesFiles).ToArray());//3 + 1+ 1+ 2
                                                //
                                            }
                                            catch (Exception ex)
                                            {
                                                isResults = false;
                                                strErrors = ex.Message;
                                                return;
                                            }
#if DEBUG
                                            Console.WriteLine("START-------");
                                            Console.WriteLine("IsOffline: " + PVCFCSharedValues.Running.IsOffline.ToString());
                                            Console.WriteLine("_id: " + strId);
                                            Console.WriteLine("File: " + schedulesFiles);
#endif
                                            #endregion//End Get Params
                                            //
                                            #region Start Process
                                            //Check id
                                            if (!PVCFCSharedValues.Running.IsOffline)
                                            {
                                                if (strId.Length <= 0)
                                                {
                                                    strErrors = Languages.Languages.NullDeliveryID;
                                                    return;
                                                }
                                            }
                                            //Check files exist
                                            if (!File.Exists(schedulesFiles))
                                            {
                                                strErrors = Languages.Languages.SchedulesFilesDoseNotExist;
                                                return;
                                            }
                                            //Load Schedules - Check save files
                                            PVCFCSharedValues.Running.Schedules = PVCFCDistributionSchedulesModel.LoadSetting(schedulesFiles);
                                            //Check strId
                                            if (!PVCFCSharedValues.Running.Schedules.DeliveryID.Equals(strId))
                                            {
                                                strErrors = Languages.Languages.DeliveryID + " " + Languages.Languages.NotMatch.ToLower();
                                                return;
                                            }
                                            //Start scan
                                            isResults = PVCFCSharedValues.DeviceHandler.StartReadding();
#if DEBUG
                                            isResults = true;//For start RFID
#endif
                                            if (!isResults)
                                            {
                                                strErrors = Languages.Languages.CannotStartRFIDDevices;
                                                return;
                                            }
                                            //
                                            //Set Start
                                            PVCFCSharedValues.Running.Status = Common.Enum.RunningStatusEnum.Ready;
                                            //
                                        }
                                        catch (Exception ex)
                                        {
                                            strErrors = ex.Message;
                                        }
                                        finally
                                        {
                                            PVCFCSharedValues.UIBridgeSocket.SendStartFeedbackToUI(isResults, strErrors);
#if DEBUG
                                            Console.WriteLine("Results: " + isResults + ": " + strErrors);
                                            Console.WriteLine("END START---");
#endif
                                        }
                                            #endregion//End Start Process
                                        //
#if DEBUG
                                        PVCFCSharedValues.DeviceHandler.DEBUGAddMessageBuffer(PVCFCRFID.Controller.PVCFCSharedValues.SocketIndex);
#endif
                                        #endregion//End Start - Linh.Tran_230911
                                        break;
                                    case (byte)ConnectionsType.UISocketCommandEnum.Stop://Linh.Tran_230911
                                        #region Stop - Linh.Tran_230911
#if DEBUG
                                        PVCFCSharedValues.DeviceHandler.DEBUGAddMessageBufferStop();
                                        Console.WriteLine("STOP-------");
#endif
                                        isResults = false;
                                        strErrors = "";
                                        try
                                        {
                                            PVCFCSharedValues.Running.Status = Common.Enum.RunningStatusEnum.Stop;
                                            PVCFCSharedValues.DeviceHandler.StopReadding();
                                            //Save files
                                            PVCFCSharedValues.Running.Schedules.SaveSettings();
                                            isResults = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            strErrors = ex.Message;
                                        }
                                        finally
                                        {
                                            PVCFCSharedValues.UIBridgeSocket.SendStopFeedbackToUI(isResults, strErrors);
#if DEBUG
                                            Console.WriteLine("Results: " + isResults + ": " + strErrors);
                                            Console.WriteLine("END STOP---");
#endif
                                        }
                                        #endregion//End Stop - Linh.Tran_230911
                                        break;
                                }
                                #endregion//End UI
                                break;
                            case (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand:
                                #region Device command
                                switch ((RFID_MODE_TYPE)receiveBytes[3])
                                {
                                    case RFID_MODE_TYPE.Config:
                                        try
                                        {
                                            var res1 = GPIOConfigFunction(receiveBytes);
                                            var res2 = TagStorageConfigFunction(receiveBytes);
                                            var res3 = AntennaConfigFunction(receiveBytes);
                                            var res4 = TriggerConfigFunction(receiveBytes);
                                            var res5 = RSSIConfig(receiveBytes);
                                            PVCFCSharedValues.UIBridgeSocket.SendConfigFeedbackToUI(
                                                new bool[]
                                                {
                                                    res1,
                                                    res2,
                                                    res3,
                                                    res4
                                                });

                                        }
                                        catch (Exception ex)
                                        {
#if DEBUG
                                            Console.WriteLine("Fail setting ! " + ex.Message);
#endif
                                        }
                                        break;
                                    case RFID_MODE_TYPE.Operation:
                                        switch ((RFID_OPERATION_TYPE)receiveBytes[4])
                                        {
                                            case RFID_OPERATION_TYPE.Disconnect:

                                                var temp1 = RFID_OPERATION_TYPE.Disconnect;
                                                var temp2 = PVCFCSharedValues.DeviceHandler.Disconnect();
                                                PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI(temp1, temp2);
                                                break;

                                            case RFID_OPERATION_TYPE.StartRead:
                                                var temp3 = RFID_OPERATION_TYPE.StartRead;
                                                var temp4 = PVCFCSharedValues.DeviceHandler.StartReadding();
                                                PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI(temp3, temp4);
                                                break;

                                            case RFID_OPERATION_TYPE.StopRead:
                                                var temp5 = RFID_OPERATION_TYPE.StopRead;
                                                var temp6 = PVCFCSharedValues.DeviceHandler.StopReadding();
                                                PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI(temp5, temp6);
                                                break;

                                            case RFID_OPERATION_TYPE.Login:
                                                //PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI
                                                //   (
                                                //   RFID_OPERATION_TYPE.Login,
                                                //  // Login(receiveBytes)
                                                //   );

                                                break;
                                            case RFID_OPERATION_TYPE.Logout:
                                                var temp7 = RFID_OPERATION_TYPE.Logout;
                                                var temp8 = PVCFCSharedValues.DeviceHandler.Logout();
                                                PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI(temp7, temp8);
                                                break;

                                            case RFID_OPERATION_TYPE.ClearReport:
                                                var temp9 = RFID_OPERATION_TYPE.ClearReport;
                                                var temp10 = PVCFCSharedValues.DeviceHandler.ClearReport();
                                                PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI(temp9, temp10);
                                                break;

                                            case RFID_OPERATION_TYPE.Reboot:
                                                var temp11 = RFID_OPERATION_TYPE.Reboot;
                                                var temp12 = PVCFCSharedValues.DeviceHandler.Reboot();
                                                PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI(temp11, temp12);
                                                break;

                                            case RFID_OPERATION_TYPE.ResetFactoryDefault:

                                                var temp13 = RFID_OPERATION_TYPE.ResetFactoryDefault;
                                                var temp14 = PVCFCSharedValues.DeviceHandler.ResetFactoryDefault();
                                                PVCFCSharedValues.UIBridgeSocket.SendOperFeedbackToUI(temp13, temp14);
                                                break;

                                            default:
                                                break;
                                        }
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
                //Console.WriteLine("UIBridgeSocket - ThreadListenUIInit: " + PVCFCSharedValues.SocketName + ": " + ex.Message);
#endif
            }
        }

        #region Config Functions

        private bool GPIOConfigFunction(byte[] receiveBytes)
        {
            try
            {
                bool[] numGPIArr = new bool[4];
                bool[] numGPOArr = new bool[4];

                for (int i = 0; i < 4; i++)
                {
                    numGPIArr[i] = receiveBytes[4 + i] != 0; // byte[4] - byte[7]
                    numGPOArr[i] = receiveBytes[8 + i] != 0; // byte[8] - byte[11]
                }
#if DEBUG
                //numGPIArr = new bool[] { true, true, true, true };
                //numGPOArr = new bool[] { false, false, false, false };
#endif
                var res = PVCFCSharedValues.DeviceHandler.GPIOConfig(numGPIArr, numGPOArr);
#if DEBUG
                if (!res)
                    Console.WriteLine("GPIO Setting Fail !");
                else Console.WriteLine("GPIO Setting OK");
#endif
                return res;
            }
            catch (Exception)
            {
#if DEBUG
                Console.WriteLine("GPIO Setting Fail !");

#endif
                return false;
            }
        }

        private bool TagStorageConfigFunction(byte[] receiveBytes)
        {
            try
            {
                int maxTagCount = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[12], receiveBytes[13] });
                int maxSizeMB = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[14], receiveBytes[15] });
                int maxTagIDLength = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[16], receiveBytes[17] });
#if DEBUG
                //maxTagCount = 4096;
                //maxSizeMB = 64;
                //maxTagIDLength = 64;
#endif
                var res = PVCFCSharedValues.DeviceHandler.TagStorageConfig(maxTagCount, maxSizeMB, maxTagIDLength);
#if DEBUG
                if (!res)
                    Console.WriteLine("Tag Storage Setting Fail !");
                else Console.WriteLine("Tag Storage Setting OK");
#endif
                return res;
            }
            catch (Exception)
            {
                Console.WriteLine("Tag Storage Setting Fail !");
                return false;
            }

        }

        private bool AntennaConfigFunction(byte[] receiveBytes)
        {
            try
            {
                int aid = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[18], receiveBytes[19] });
                int transPowrId = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[20], receiveBytes[21] });

#if DEBUG
                //aid = 0;
                //transPowrId = 130;
#endif

                var res = PVCFCSharedValues.DeviceHandler.AnthennaConfig(aid, transPowrId);
#if DEBUG
                if (!res)
                    Console.WriteLine("Antenna Setting Fail !");
                else Console.WriteLine("Antenna Setting OK");
#endif
                return res;
            }
            catch (Exception)
            {
                Console.WriteLine("Antenna Setting Fail !");
                return false;
            }

        }

        private bool TriggerConfigFunction(byte[] receiveBytes)
        {
            try
            {
                var modeStart = (START_TRIGGER_TYPE)Enum.ToObject(typeof(START_TRIGGER_TYPE), receiveBytes[22]);
                var modeStop = (STOP_TRIGGER_TYPE)Enum.ToObject(typeof(STOP_TRIGGER_TYPE), receiveBytes[23]);
                int gpiStart = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[24], receiveBytes[25] });
                bool gpiStartEvent = (receiveBytes[26] != 0);
                int durationStop = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[27], receiveBytes[28] });
                int tagRpTrigger = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[29], receiveBytes[30] });
                int gpiStop = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[31], receiveBytes[32] });
                bool gpiStopEvent = (receiveBytes[33] != 0);
                int timeoutStop = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[34], receiveBytes[35] });
#if DEBUG
                //modeStart = START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI;
                //modeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                //gpiStart = 1;
                //gpiStartEvent = false;
                //durationStop = 3000;
                //tagRpTrigger = 1;
                //gpiStop = 2;
                //gpiStopEvent = false;
                //timeoutStop = 0;
#endif
                var res = PVCFCSharedValues.DeviceHandler.TriggerConfig(
                        modeStart,
                        modeStop,
                        gpiStart,
                        gpiStartEvent,
                        durationStop,
                        tagRpTrigger,
                        gpiStop,
                        gpiStopEvent,
                        (uint)timeoutStop
                        );
#if DEBUG
                //if (!res)
                //    Console.WriteLine("Trigger Setting Fail !");
                //else Console.WriteLine("Trigger Setting OK" +
                //    "\nModeStart:" + modeStart.ToString() +
                //    "\nModeStop:" + modeStop.ToString() +
                //    "\ngpiStart:" + gpiStart.ToString() +
                //    "\ngpiStartEvent:" + gpiStartEvent.ToString() +
                //    "\ndurationStop:" + durationStop.ToString() +
                //    "\ntagRpTrigger:" + tagRpTrigger.ToString() +
                //    "\ngpiStop:" + gpiStop.ToString() +
                //    "\ngpiStopEvent:" + gpiStopEvent.ToString() +
                //    "\ntimeoutStop:" + timeoutStop.ToString()
                //    );
#endif
                return res;
            }
            catch (Exception)
            {
                Console.WriteLine("Trigger Setting Fail !");
                return false;
            }
        }

        private bool RSSIConfig(byte[] receiveBytes)
        {
            try
            {
                PVCFCSharedValues.DeviceHandler.RSSIEnable = receiveBytes[36] != 0;
                PVCFCSharedValues.DeviceHandler.RSSIValueSet = Common.Controller.CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[37], receiveBytes[38] }) - 65536;
#if DEBUG
                //PVCFCSharedValues.DeviceHandler.RSSIEnable = false;
                //PVCFCSharedValues.DeviceHandler.RSSIValueSet = -60;
#endif
#if DEBUG
                //Console.WriteLine("RSSI Filter: " +
                //    PVCFCSharedValues.DeviceHandler.RSSIEnable.ToString() + "\n"
                //    + "Value: " + PVCFCSharedValues.DeviceHandler.RSSIValueSet);
#endif
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool Login()
        {
            try
            {
                //var userNameArr = new byte[5];  // only 5
                //Array.Copy(receiveBytes, 5, userNameArr, 0, userNameArr.Length);

                //var passWordArr = new byte[6];  // only 6
                //Array.Copy(receiveBytes, 5 + userNameArr.Length, passWordArr, 0, passWordArr.Length);

                //var username = Common.Controller.CommonFunctions.ConvertByteArrayToString(userNameArr);
                //var password = Common.Controller.CommonFunctions.ConvertByteArrayToString(passWordArr);

                return PVCFCSharedValues.DeviceHandler.Login(null, "admin", "Mylangroup@2023");
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ConnectionEvents_DeviceDataReceived(object sender, EventArgs e)
        {
            try
            {
                string strErrors = "";
                ML.SDK.RDIF_FX9600.Model.TagModel resultData = (ML.SDK.RDIF_FX9600.Model.TagModel)sender;
                //
                resultData.EPCCode = CommonFunctions.HextoString(resultData.EPCCode, Encoding.ASCII);
                //
                switch (PVCFCSharedValues.Running.Status)
                {
                    case Common.Enum.RunningStatusEnum.Processing:
                    case Common.Enum.RunningStatusEnum.Ready:
                    case Common.Enum.RunningStatusEnum.Starting:
                        #region Start
                        //Check data
                        PVCFCProductItemModel productItems = PVCFCSharedValues.Running.Schedules.GetNewProductItems(resultData);
                        //Sync to server
                        if (!PVCFCSharedValues.Running.IsOffline)
                        {
                            strErrors = PVCFCSharedValues.Running.Schedules.SyncDeliveryDataToServer(ref productItems);
                        }
                        //Add to list
                        PVCFCSharedValues.Running.Schedules.ProductItemsList.Add(productItems);
                        //Cal sum status
                        switch (productItems.Status)
                        {
                            case PVCFCProductItemStatusEnum.CheckedSuccess:
                                PVCFCSharedValues.Running.Schedules.ScanSucess++;
                                break;
                            case PVCFCProductItemStatusEnum.CheckedFailed:
                                PVCFCSharedValues.Running.Schedules.ScanFailed++;
                                break;
                            case PVCFCProductItemStatusEnum.ActivedSuccess:
                                PVCFCSharedValues.Running.Schedules.ScanSucess++;
                                PVCFCSharedValues.Running.Schedules.ActiveSuccess++;
                                break;
                            case PVCFCProductItemStatusEnum.ActivedFailed:
                                PVCFCSharedValues.Running.Schedules.ScanSucess++;
                                PVCFCSharedValues.Running.Schedules.ActiveFailed++;
                                break;
                        }
                        PVCFCSharedValues.Running.Schedules.Total++;
                        //Save to files - 10 page/times and when stop
                        if ((PVCFCSharedValues.Running.Schedules.Total % 10) == 0)
                        {
                            PVCFCSharedValues.Running.Schedules.SaveSettings();
                        }
#if DEBUG
                        int scanSucess = 0;
                        int scanFailed = 0;
                        int activeSuccess = 0;
                        int activeFailed = 0;
                        int total = 0;
                        PVCFCProductItemModel temp = PVCFCProductItemModel.GetProductTagItems(productItems.GetItemsToByteArr(PVCFCSharedValues.Running.Schedules.ScanSucess,
                            PVCFCSharedValues.Running.Schedules.ScanFailed,
                            PVCFCSharedValues.Running.Schedules.ActiveSuccess,
                            PVCFCSharedValues.Running.Schedules.ActiveFailed,
                            PVCFCSharedValues.Running.Schedules.Total), ref scanSucess, ref scanFailed, ref activeSuccess, ref activeFailed, ref total);
                        Console.WriteLine(temp.TagID + "; " + temp.ProductCode + "; " + temp.ScanDatetime + ";  " + temp.Errors);
                        Console.WriteLine(scanSucess + "; " + scanFailed + "; " + activeSuccess + ";  " + activeFailed + "; " + total);
#endif
                        //Send to UI
                        PVCFCSharedValues.UIBridgeSocket.SendPageFeedbackToUI(productItems.GetItemsToByteArr(
                            PVCFCSharedValues.Running.Schedules.ScanSucess,
                            PVCFCSharedValues.Running.Schedules.ScanFailed,
                            PVCFCSharedValues.Running.Schedules.ActiveSuccess,
                            PVCFCSharedValues.Running.Schedules.ActiveFailed,
                            PVCFCSharedValues.Running.Schedules.Total)
                            );
                        //
                        #endregion//End start
                        break;
                    case Common.Enum.RunningStatusEnum.Stop:
                    default:
                        #region Send data
                        #region Exc Get data
                        byte[] command = new byte[100];
                        //
                        command[0] = (byte)RFID_FX9600DataType.Data;//Command Header ,byte index 3

                        // Byte count data (max: 255)
                        command[1] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.EPCCode), 255)[0]; //byte index 4
                        command[2] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.TIDCode), 255)[0]; //byte index 5
#if DEBUG
                        //Console.WriteLine("====> " + resultData.EPCCode + "; " + resultData.TIDCode);
                        //Console.WriteLine(CommonFunctions.ConvertByteArrayToNumber(new byte[] { command[1], command[2] }));
#endif
                        // Detail data
                        var antID = CommonFunctions.ConvertNumberToByteArray(int.Parse(resultData.AntennaID), 65535);
                        command[3] = antID[0]; //byte index 6
                        command[4] = antID[1]; //byte index 7

                        var rssiVal = CommonFunctions.ConvertNumberToByteArray(int.Parse(resultData.RSSIValue.ToString()), 65535);
                        command[5] = rssiVal[0]; //byte index 8
                        command[6] = rssiVal[1]; // //byte index 9

                        var tagCount = CommonFunctions.ConvertNumberToByteArray(int.Parse(resultData.TotalTagCount.ToString()), 65535);
                        command[7] = tagCount[0]; //byte index 10
                        command[8] = tagCount[1]; //byte index 11

                        // Data
                        byte[] EPCItemsByteArr = Encoding.UTF8.GetBytes(resultData.EPCCode); //EPC ,byte index 12 + length epc
                        byte[] TIDItemsByteArr = Encoding.UTF8.GetBytes(resultData.TIDCode); //TID, 13 + length epc + 1 to end

                        // Command = Header + EPC + TID
                        Array.Copy(EPCItemsByteArr, 0, command, 9, EPCItemsByteArr.Length);
                        Array.Copy(TIDItemsByteArr, 0, command, 9 + EPCItemsByteArr.Length, TIDItemsByteArr.Length);
                        //
                        #endregion//End Get Data
                        SendReceivedDataToUI(command);
                        #endregion//End send data

                        break;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ConnectionEvents_DeviceDataReceived: " + ex.Message);
                Console.ReadLine();
#endif
            }
        }
    }
}
