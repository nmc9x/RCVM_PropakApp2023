using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security;
using System.Text;
using System.Xml.Serialization;
using static ML.SDK.DM60X.DataType.DM60XDataType;

namespace ML.SDK.DM60X.Model
{
    public class DMCam_SettingModel
    {
        public string DeviceTransferName { get; set; } = "ML.DeviceTransfer.PVCFCDM60X";
        public string IPAddress { get; set; } = "169.254.10.11";
        public string Port { get; set; } = "21";
        public string SubnetMask { get; set; } = "255.255.255.0";
        public int TriggerTypeIndex { get; set; } = 0;
        public int DelayTypeIndex { get; set; } = 0;
        public int DelayTime { get; set; } = 2000;
        public int DecodeTime { get; set; } = 50;
        [XmlIgnore]
        public bool IsReboot { get; set; }
        [XmlIgnore]
        public bool IsResetReboot { get; set; }
        //public Dictionary<string, bool> SymbolSelecList { get; set; }
        public bool[] SymbolState { get; set; }

        public string PrinterIP { get; set; } = "192.168.15.152";
        public string PrinterPort { get; set; } = "12500";
        public DMCam_SettingModel()
        {
            #region Init Par
            IPAddress = "169.254.10.11";
            Port = "23";
            SubnetMask = "255.255.0.0";
            TriggerTypeIndex = 0;
            DelayTypeIndex = 0;
            DelayTime = 2000;
            DecodeTime = 50;
            IsReboot = false;
            IsResetReboot = false;
            SymbolState = new bool[25];
            //{
            //    false, //["DATAMATRIX"]
            //    false, //["QRCODE"] 
            //    false, //["MAXICODE"]
            //    false, //["AZTECCODE"] 

            //    false, //["CODE128"]
            //    false, //["CODE25"]
            //    false, //["CODE93"] 
            //    false, //["CODE39"]
            //    false, //["PHARMACODE"]
            //    false, //["CODABAR"]
            //    false, //["INTERLEAVED2OF5"]
            //    false, //["UPCEAN"]
            //    false, //["MSI"]

            //    false, //["PDF417"]
            //    false, //["EANUCC"]
            //    false, //["MICROPDF417"]
            //    false, //["DATABAR"]

            //    false, //["POSTNET"]
            //    false, //["PLANET"]
            //    false, //["JAPANPOST"] 
            //    false, //["UPU"]
            //    false, //["AUSTRALIAPOST"]
            //    false, //["INTELLIGENT"]
            //    false,
            //    false
            //};
            #endregion
        }
        private DM60X_OPERATION_TYPE _TypeOfOperation = DM60X_OPERATION_TYPE.None;
        public DM60X_OPERATION_TYPE TypeOfOperation
        {
            get { return _TypeOfOperation; }
            set { _TypeOfOperation = value; }
        }

        public byte[] OperationsCommand
        {
            get
            {
                byte[] operationCmd = new byte[1];
                operationCmd[0] = (byte)TypeOfOperation;
                return operationCmd;
            }
        }

        public byte[] ConfigsCommand
        {
            get
            {
                byte[] _Command = new byte[80];
                int maxValueFor2Byte = 65535;
                int maxValueFor1Byte = 255;

                /* HIDE VALUE (HEADER)
               _Command[0] = 16;
               _Command[1] = 65;
               _Command[2] = 00;
               _Command[3] = 01;
               */

                #region TriggerConfig
                //
                _Command[4] = CommonFunctions.ConvertNumberToByteArray(TriggerTypeIndex, maxValueFor1Byte)[0];
                _Command[5] = CommonFunctions.ConvertNumberToByteArray(DelayTypeIndex, maxValueFor1Byte)[0];
                var delayTimeArr = CommonFunctions.ConvertNumberToByteArray(DelayTime, maxValueFor2Byte);
                _Command[6] = delayTimeArr[0];
                _Command[7] = delayTimeArr[1];
                var decodeTimeArr = CommonFunctions.ConvertNumberToByteArray(DecodeTime, maxValueFor2Byte);
                _Command[8] = decodeTimeArr[0];
                _Command[9] = decodeTimeArr[1];

                #endregion

                #region IPConfig
                var countByteIP = Encoding.UTF8.GetByteCount(IPAddress); //max = 15
                var countByteSubnet = Encoding.UTF8.GetByteCount(SubnetMask);  //max = 15
                var countBytePort = Encoding.ASCII.GetByteCount(Port); // max
                var ipArr = Encoding.UTF8.GetBytes(IPAddress);
                var subnetArr = Encoding.UTF8.GetBytes(SubnetMask);
                var portArr = Encoding.UTF8.GetBytes(Port); //Max 5
                Array.Copy(ipArr, 0, _Command, 10, countByteIP); // 10 - 24
                Array.Copy(subnetArr, 0, _Command, 25, countByteSubnet); // 25 39
                Array.Copy(portArr, 0, _Command, 40, countBytePort); // 40 44

                #endregion

                #region SymbolConfig

                for (int i = 45, j = 0; i < 70; i++,j++)
                {
                    _Command[i] = BitConverter.GetBytes(SymbolState[j])[0];
                }
                
                #endregion

                #region Reboot
                _Command[70] = BitConverter.GetBytes(IsReboot)[0];
                #endregion

                #region ResetAndReboot
                _Command[71] = BitConverter.GetBytes(IsReboot)[0];
                #endregion

                return _Command;

            }
        }
    }
}
