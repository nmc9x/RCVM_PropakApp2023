using ML.SDK.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ML.SDK.DM60X.DataType.DM60XDataType;

namespace ML.SDK.DM60X.Controller
{
    public class DM60XUIBridgeSocketHandler : TransferUIBridgeSocket 
    {
        #region Feedback
        
        public void SendStartFeedbackToUI(bool isStatus, string strErrors)
        {
        
        }
        public void SendStopFeedbackToUI(bool isStatus, string strErrors)
        {

        }
        

        #endregion


        #region Action
        public void SendStartToDeviceTransfer(bool isOffline, string deliveryID, string fullPath)
        {
            byte[] command = new byte[1];
            command[0] = (byte)ML.Connections.DataType.ConnectionsType.UISocketCommandEnum.Start;
            SendUICommandToPort(command);
        }
        public void SendStopToDeviceTransfer()
        {
            byte[] command = new byte[1]; 
            command[0] = (byte)ML.Connections.DataType.ConnectionsType.UISocketCommandEnum.Stop;
            SendUICommandToPort(command);
        }

        // Software trigger
        public void SendOperationToDeviceTransfer(byte[] operationData)
        {
            var tempArr = new byte[2];
            tempArr[0] = (byte)DM60X_MODE_TYPE.Operation;

            Array.Copy(operationData, 0, tempArr, 1, operationData.Length);

            switch ((DM60X_OPERATION_TYPE)tempArr[1]) // This case is only 1 byte
            {
                case DM60X_OPERATION_TYPE.StartRead:
                    SendDataToPort(tempArr);
                    break;
                case DM60X_OPERATION_TYPE.StopRead:
                    SendDataToPort(tempArr);
                    break;
                    // More
            }
        }
        #endregion

        #region DEVICE -> UI
        public void SendConfigFeedbackToUI(bool[] result)
        {
            byte[] command = new byte[6];
            // Data
            command[0] = (byte)DM60X_MODE_TYPE.Config;
            command[1] = (byte)(result[0] ? 1 : 0); // Trigger 
            command[2] = (byte)(result[1] ? 1 : 0); // Ip 
            command[3] = (byte)(result[2] ? 1 : 0); // Symbol 
            command[4] = (byte)(result[3] ? 1 : 0); // Reboot
            command[5] = (byte)(result[4] ? 1 : 0); // ResetConfigAndReboot
            SendDataToPort(command);
        }
       
        #endregion

        #region UI -> DEVICE
        public void SendConfigToDeviceTransfer(byte[] configData)
        {
            configData[3] = (byte)DM60X_MODE_TYPE.Config;
            SendDataToPort(configData.Skip(3).ToArray());
        }

        public void SenOperationToDeviceTransfer(byte[] operationData)
        {
            operationData[3] = (byte)DM60X_MODE_TYPE.Operation;
            SendDataToPort(operationData.Skip(3).ToArray());
        }

        #endregion


    }
}
