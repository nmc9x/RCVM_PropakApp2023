using ML.Common.Controller;
using ML.Connections.DataType;
using ML.SDK.DM60X.Controller;
using ML.SDK.DM60X.DataType;
using ML.SDK.DM60X.Model;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using static ML.SDK.DM60X.DataType.DM60XDataType;

namespace ML.DeviceTransfer.PVCFCDM60X.Controller
{
    public class DM60XUIBridgeSocket : DM60XUIBridgeSocketHandler
    {
       // private DM60X_SettingModel tempReceiveByte = new DM60X_SettingModel(); //test var
        public override void ProcessReceivedMessageFromUI(byte[] receiveBytes)
        {

#if DEBUG
            //var headerByte = new byte[74];
            //headerByte[0] = 16;
            //headerByte[1] = 65;
            //headerByte[2] = 00;
            //headerByte[3] = 01;
            //Array.Copy(tempReceiveByte.ConfigsCommand,4,headerByte,4, tempReceiveByte.ConfigsCommand.Length-4);
            //receiveBytes = headerByte;
#endif


            try
            {
                switch (receiveBytes[0]) // byte 0
                {
                    case (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType:
                        int socketIndex = receiveBytes[2];

                        switch (receiveBytes[1]) // byte 1
                        {
                            case (byte)ConnectionsType.SockTypeCommandEnum.UICommand:
                                switch (receiveBytes[3]) // byte 3
                                {
                                    case (byte)ConnectionsType.UISocketCommandEnum.DeviceStatus:
                                        break;
                                    case (byte)ConnectionsType.UISocketCommandEnum.Start:
                                        break;
                                    case (byte)ConnectionsType.UISocketCommandEnum.Stop:
                                        break;
                                }
                                break;
                            case (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand:
                                switch ((DM60X_MODE_TYPE)receiveBytes[3])
                                {
                                    case DM60X_MODE_TYPE.Config:
                                      
                                            var resTriggerCfg = TriggerConfigFunction(receiveBytes);
                                            var resIpCfg = IPAddressConfigFunction(receiveBytes);
                                            var resSymCfg = SymbolicConfigFunction(receiveBytes);
                                            var resDevRebootFunc = DeviceRebootFunction(receiveBytes);
                                            var resReset = ConfigResetAndReboot(receiveBytes);
                                           
                                            CognexSharedValues.UIBridgeSocket.SendConfigFeedbackToUI(
                                               new bool[]
                                               {
                                                    resTriggerCfg,
                                                    resIpCfg,
                                                    resSymCfg,
                                                    resDevRebootFunc,
                                                    resReset
                                               });


#if DEBUG
                                        Console.WriteLine("Result setting: "+ "\n"+
                                           "resTriggerCfg: " + resTriggerCfg + "\n" +
                                           "resIpCfg: " + resIpCfg + "\n" +
                                           "resSymCfg: " + resSymCfg + "\n" +
                                           "resDevRebootFunc: " + resDevRebootFunc + "\n" +
                                           "resReset: " + resReset);
#endif

                                        break;
                                    case DM60X_MODE_TYPE.Operation:
                                        break;

                                }
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
                Console.WriteLine("Device Transfer -> DM60XUIBridgeSocket -> ProcessReceivedMessageFromUI: "+ex.Message);
#endif
            }
        }
        private bool TriggerConfigFunction(byte[] receiveBytes)
        {
            try
            {
                var triggerType = (TRIGGER_TYPE)Enum.ToObject(typeof(TRIGGER_TYPE), receiveBytes[4]);
                var delayType = (DELAY_TYPE)Enum.ToObject(typeof(DELAY_TYPE), receiveBytes[5]);
                int delayTime = CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[6], receiveBytes[7] });
                int decodeTime = CommonFunctions.ConvertByteArrayToNumber(new byte[] { receiveBytes[8], receiveBytes[9] });
#if DEBUG
                Console.WriteLine("triggerType " + triggerType + "\n" +
                    "delayType " + delayType + "\n" +
                    "delayTime " + delayTime + "\n" +
                    "decodeTime " + decodeTime);
#endif
                return CognexSharedValues.DeviceHandler.SetTriggerSetting(triggerType, delayType, delayTime, decodeTime);

            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool IPAddressConfigFunction(byte[] receiveBytes)
        {
            try
            {
                // IP
                var tempArrIp = new byte[15];
                Array.Copy(receiveBytes, 10, tempArrIp, 0, 15);
                tempArrIp = tempArrIp.Where(b => b != 0).ToArray();
                var ipArr = Encoding.UTF8.GetString(tempArrIp); 

                //Subnet
                var tempArrSubnet = new byte[15];
                Array.Copy(receiveBytes, 25, tempArrSubnet, 0, 15);
                var subnetArr = Encoding.UTF8.GetString(tempArrSubnet);

                //Port
                var tempArrPort = new byte[5];
                Array.Copy(receiveBytes, 40, tempArrPort, 0, 5);
                var portArr = Encoding.UTF8.GetString(tempArrPort);
#if DEBUG
                Console.WriteLine("Ip: " + ipArr + "\n" + "Subnet: " + subnetArr + "\n" +"Port: " + portArr);         
#endif
                CognexSharedValues.DeviceHandler.CheckChangeNetworkPar(ipArr, subnetArr, portArr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool SymbolicConfigFunction(byte[] receiveBytes)
        {
            try
            {
                var arrTemp = new byte[25];
                Array.Copy(receiveBytes, 45, arrTemp, 0, arrTemp.Length); // 45 - 69
                var tempBoolArr = CommonFunctions.BytesToBooleanArray(arrTemp);
                CognexSharedValues.DeviceHandler.SetSymbol(tempBoolArr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool DeviceRebootFunction(byte[] receiveBytes)
        {
            try
            {
                var isReboot = CommonFunctions.IntToBool(receiveBytes[70]);
                if (isReboot)
                {
                    CognexSharedValues.DeviceHandler.DeviceReboot();
                    return true;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool ConfigResetAndReboot(byte[] receiveBytes)
        {
            try
            {
                var isReboot = CommonFunctions.IntToBool(receiveBytes[71]);
                if (isReboot)
                {
                    CognexSharedValues.DeviceHandler.ResetConfigAndReboot();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void ConnectionEvents_DeviceDataReceived(object sender, EventArgs e)
        {
            var resultData = (CodeModel)sender;
            byte[] command = new byte[200];
           
            try
            {
                command[0] = (byte)DM60X_MODE_TYPE.Data;//Command Header ,byte index 3
                   
                // Get length element data
                command[1] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.Code), 255)[0]; // 4 code
                command[2] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.Symbol), 255)[0]; // 5 symbol
                var decodeTimeByteCnt = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.DecodeTime), 65535); // decode time
                command[3] = decodeTimeByteCnt[0]; // 6
                command[4] = decodeTimeByteCnt[1]; // 7
                command[5] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.Status), 255)[0]; // 8 status
                // Data
                var codeArr = Encoding.UTF8.GetBytes(resultData.Code);
                var symbolArr = Encoding.UTF8.GetBytes(resultData.Symbol);
                var decodeTimeArr = Encoding.UTF8.GetBytes(resultData.DecodeTime);
                var statusArr = Encoding.UTF8.GetBytes(resultData.Status);

                Array.Copy(codeArr,0, command, 6, codeArr.Length);
                Array.Copy(symbolArr,0, command, 6 + codeArr.Length, symbolArr.Length);
                Array.Copy(decodeTimeArr, 0, command, 6 + codeArr.Length + symbolArr.Length, decodeTimeArr.Length);
                Array.Copy(statusArr, 0, command, 6 + codeArr.Length + symbolArr.Length + decodeTimeArr.Length, statusArr.Length);
                SendReceivedDataToUI(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Device transfer -> ConnectionEvents_DeviceDataReceived: "+ex.Message);
            }
        }
    }
}
