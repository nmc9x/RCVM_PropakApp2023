using ML.Common.Controller;
using ML.Connections.DataType;
using ML.SDK.CVX450.Controller;
using ML.SDK.CVX450.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ML.SDK.CVX450.DataType.CVX450DataType;

namespace ML.DeviceTransfer.CVX450.Controller
{
    public class CVX450UIBridgeSocket : CVX450UIBridgeSocketHandler
    {
        // Not use now
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
                                switch ((CVX450_MODE_TYPE)receiveBytes[3])
                                {
                                    case CVX450_MODE_TYPE.Config:

                                        //var resTriggerCfg = TriggerConfigFunction(receiveBytes);
                                        //var resIpCfg = IPAddressConfigFunction(receiveBytes);
                                        //var resSymCfg = SymbolicConfigFunction(receiveBytes);
                                        //var resDevRebootFunc = DeviceRebootFunction(receiveBytes);
                                        //var resReset = ConfigResetAndReboot(receiveBytes);

                                        //KeyenceSharedValues.UIBridgeSocket.SendConfigFeedbackToUI(
                                        //   new bool[]
                                        //   {
                                        //            resTriggerCfg,
                                        //            resIpCfg,
                                        //            resSymCfg,
                                        //            resDevRebootFunc,
                                        //            resReset
                                        //   });


//#if DEBUG
//                                        Console.WriteLine("Result setting: " + "\n" +
//                                           "resTriggerCfg: " + resTriggerCfg + "\n" +
//                                           "resIpCfg: " + resIpCfg + "\n" +
//                                           "resSymCfg: " + resSymCfg + "\n" +
//                                           "resDevRebootFunc: " + resDevRebootFunc + "\n" +
//                                           "resReset: " + resReset);
//#endif

                                        break;
                                    case CVX450_MODE_TYPE.Operation:
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
                Console.WriteLine("Device Transfer -> DM60XUIBridgeSocket -> ProcessReceivedMessageFromUI: " + ex.Message);
#endif
            }
        }

        protected override void ConnectionEvents_DeviceDataReceived(object sender, EventArgs e)
        {
            var resultData = (CodeModel)sender;
            byte[] command = new byte[200];

            try
            {
                command[0] = (byte)CVX450_MODE_TYPE.Data;//Command Header ,byte index 3

                // Get length element data
                command[1] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.Code), 255)[0]; // 4 code
                //command[2] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.Symbol), 255)[0]; // 5 symbol
                //var decodeTimeByteCnt = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.DecodeTime), 65535); // decode time
                //command[3] = decodeTimeByteCnt[0]; // 6
                //command[4] = decodeTimeByteCnt[1]; // 7
                //command[5] = CommonFunctions.ConvertNumberToByteArray(Encoding.UTF8.GetByteCount(resultData.Status), 255)[0]; // 8 status
                // Data
                var codeArr = Encoding.UTF8.GetBytes(resultData.Code);
                //var symbolArr = Encoding.UTF8.GetBytes(resultData.Symbol);
                //var decodeTimeArr = Encoding.UTF8.GetBytes(resultData.DecodeTime);
               // var statusArr = Encoding.UTF8.GetBytes(resultData.Status);

                Array.Copy(codeArr, 0, command, 6, codeArr.Length);
                //Array.Copy(symbolArr, 0, command, 6 + codeArr.Length, symbolArr.Length);
                //Array.Copy(decodeTimeArr, 0, command, 6 + codeArr.Length + symbolArr.Length, decodeTimeArr.Length);
                //Array.Copy(statusArr, 0, command, 6 + codeArr.Length + symbolArr.Length + decodeTimeArr.Length, statusArr.Length);
                SendReceivedDataToUI(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Device transfer -> ConnectionEvents_DeviceDataReceived: " + ex.Message);
            }
        }
    }
}
