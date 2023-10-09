using ML.Common.Controller;
using ML.Connections.Controller;
using ML.Connections.DataType;
using ML.SDK.RDIF_FX9600.DataType;
using ML.SDK.RDIF_FX9600.Model;
using ML.SDK.Transfer;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ML.SDK.RDIF_FX9600.Controller
{
    public class RFID_FX9600UIBridgeSocketHandler : TransferUIBridgeSocket
    {
        #region Properties
        private readonly short _EPCByteSize = 24;  //EPC 24 Char = 24 byte
        private readonly short _TIDByteSize = 36;  //TID 36 Char = 36 byte
        #endregion//End Properties
        //
        #region DEVICE TRANSFER -> UI
        public void SendConfigFeedbackToUI(bool[] result)
        {
            byte[] command = new byte[5];
            // Data
            command[0] = (byte)RFID_MODE_TYPE.Config;
            command[1] = (byte)(result[0] ? 1 : 0); //resultGPIOConfig
            command[2] = (byte)(result[1] ? 1 : 0); //resultTagStorageConfig
            command[3] = (byte)(result[2] ? 1 : 0); //resultAnthennaConfig
            command[4] = (byte)(result[3] ? 1 : 0); //resTriggerCfg

            SendDataToPort(command);
        }

        public void SendOperFeedbackToUI(RFID_OPERATION_TYPE type, bool result)
        {
            byte[] command = new byte[3];
            //Data
            command[0] = (byte)RFID_MODE_TYPE.Operation;
            switch (type)
            {
                case RFID_OPERATION_TYPE.StartRead:
                    command[1] = (byte)RFID_OPERATION_TYPE.StartRead;
                    break;
                case RFID_OPERATION_TYPE.StopRead:
                    command[1] = (byte)RFID_OPERATION_TYPE.StopRead;
                    break;
                case RFID_OPERATION_TYPE.Disconnect:
                    command[1] = (byte)RFID_OPERATION_TYPE.Disconnect;
                    break;
                case RFID_OPERATION_TYPE.ClearReport:
                    command[1] = (byte)RFID_OPERATION_TYPE.ClearReport;
                    break;
                case RFID_OPERATION_TYPE.Reboot:
                    command[1] = (byte)RFID_OPERATION_TYPE.Reboot;
                    break;
                case RFID_OPERATION_TYPE.ResetFactoryDefault:
                    command[1] = (byte)RFID_OPERATION_TYPE.ResetFactoryDefault;
                    break;
                case RFID_OPERATION_TYPE.Login:
                    command[1] = (byte)RFID_OPERATION_TYPE.Login;
                    break;
                case RFID_OPERATION_TYPE.Logout:
                    command[1] = (byte)RFID_OPERATION_TYPE.Logout;
                    break;
            }
            command[2] = (byte)(result ? 1 : 0);


            SendDataToPort(command);
        }


        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        /// <param name="isStatus"></param>
        /// <param name="strErrors"></param>
        public void SendStartFeedbackToUI(bool isStatus, string strErrors)
        {
            byte[] byteStrErrorsArr = CommonFunctions.ConvertStringToByteArray(strErrors);
            byte[] command = new byte[4 + byteStrErrorsArr.Length]; //frame data 28 byte Config
            command[0] = (byte)ML.Connections.DataType.ConnectionsType.UISocketCommandEnum.Start;
            if (isStatus)
            {
                command[1] = 1;
            }
            else
            {
                command[1] = 0;
            }
            //
            command[2] = (byte)byteStrErrorsArr.Length;
            command[3] = (byte)(byteStrErrorsArr.Length >> 8);
            Array.Copy(byteStrErrorsArr, 0, command, 4, byteStrErrorsArr.Length);
            //
            SendUICommandToPort(command);
        }

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        /// <param name="isStatus"></param>
        /// <param name="strErrors"></param>
        public void SendStopFeedbackToUI(bool isStatus, string strErrors)
        {
            byte[] byteStrErrorsArr = CommonFunctions.ConvertStringToByteArray(strErrors);
            byte[] command = new byte[4 + byteStrErrorsArr.Length]; //frame data 28 byte Config
            command[0] = (byte)ML.Connections.DataType.ConnectionsType.UISocketCommandEnum.Stop;
            if (isStatus)
            {
                command[1] = 1;
            }
            else
            {
                command[1] = 0;
            }
            //
            command[2] = (byte)byteStrErrorsArr.Length;
            command[3] = (byte)(byteStrErrorsArr.Length >> 8);
            Array.Copy(byteStrErrorsArr, 0, command, 4, byteStrErrorsArr.Length);
            //
            SendUICommandToPort(command);
        }

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        /// <param name="byteArr"></param>
        public void SendPageFeedbackToUI(byte[] byteArr)
        {
            byte[] command = new byte[1 + byteArr.Length]; //frame data 28 byte Config
            command[0] = (byte)ML.Connections.DataType.ConnectionsType.UISocketCommandEnum.Page;
            Array.Copy(byteArr, 0, command, 1, byteArr.Length);
            //
            SendUICommandToPort(command);
        }
        #endregion // End DEVICE TRANSFER -> UI

        #region UI -> DEVICE TRANSFER
        public void SendConfigToDeviceTransfer(byte[] configData)
        {
            configData[3] = (byte)RFID_MODE_TYPE.Config;
            SendDataToPort(configData.Skip(3).ToArray());
        }
        public void SendOperationToDeviceTransfer(byte[] operationData)
        {
            var tempArr = new byte[2];
            tempArr[0] = (byte)RFID_MODE_TYPE.Operation;

            Array.Copy(operationData, 0, tempArr, 1, operationData.Length);

            switch ((RFID_OPERATION_TYPE)tempArr[1]) // This case is only 1 byte
            {
                case RFID_OPERATION_TYPE.StartRead:
                    SendDataToPort(tempArr);
                    break;
                case RFID_OPERATION_TYPE.StopRead:
                    SendDataToPort(tempArr);
                    break;
               // More
            }
            
        }


        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        public void SendStartToDeviceTransfer(bool isOffline, string deliveryID, string fullPath)
        {
            byte[] byteIdArr = CommonFunctions.ConvertStringToByteArray(deliveryID);
            byte[] bytePathArr = CommonFunctions.ConvertStringToByteArray(fullPath);
            byte[] command = new byte[2 + 2 + byteIdArr.Length + 2 + bytePathArr.Length];//frame data 28 byte Config
            //
            command[0] = (byte)ML.Connections.DataType.ConnectionsType.UISocketCommandEnum.Start;
            command[1] = Convert.ToByte(isOffline);
            //
            command[2] = (byte)byteIdArr.Length;
            command[3] = (byte)(byteIdArr.Length >> 8);
            Array.Copy(byteIdArr, 0, command, 4, byteIdArr.Length);
            //
            command[4 + byteIdArr.Length] = (byte)bytePathArr.Length;
            command[5 + byteIdArr.Length] = (byte)(bytePathArr.Length >> 8);
            Array.Copy(bytePathArr, 0, command, 6 + byteIdArr.Length, bytePathArr.Length);
            //
            SendUICommandToPort(command);
        }

        /// <summary>
        /// Linh.Tran_230911
        /// </summary>
        public void SendStopToDeviceTransfer()
        {
            byte[] command = new byte[1]; //frame data 28 byte Config
            command[0] = (byte)ML.Connections.DataType.ConnectionsType.UISocketCommandEnum.Stop;
            SendUICommandToPort(command);
        }

        #endregion // End UI -> DEVICE TRANSFER
    }
}
