using ML.Common.Controller;
using ML.SDK.RDIF_FX9600.DataType;
using Symbol.RFID3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ML.SDK.RDIF_FX9600.Model
{
    public class RFID_FX9600SettingsModel
    {

        private string _IP = "169.254.76.81";
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        private int _Port = 5084;
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        private string _HostNameURL = "";
        public string HostNameURL
        {
            get { return _HostNameURL; }
            set { _HostNameURL = value; }
        }
        //
        // GPIO 
        private int[] _GPIArray = new int[4] { 1, 1, 1, 1 };
        public int[] GPIArray
        {
            get { return _GPIArray; }
            set { _GPIArray = value; }
        }
        private int[] _GPOArray = new int[4];
        public int[] GPOArray
        {
            get { return _GPOArray; }
            set { _GPOArray = value; }
        }

        // Tag Storage Setting
        private int _MaxTagCount = 4096;
        public int MaxTagCount
        {
            get { return _MaxTagCount; }
            set { _MaxTagCount = value; }
        }

        private int _MaxSizeMemoryBank = 12;
        public int MaxSizeMemoryBank
        {
            get { return _MaxSizeMemoryBank; }
            set
            {
                _MaxSizeMemoryBank = value;
            }
        }

        private int _MaxTagIDLength = 64;
        public int MaxTagIDLength
        {
            get { return _MaxTagIDLength; }
            set { _MaxTagIDLength = value; }
        }

        // Anntenna
        private int _AntennaID = 0;
        public int AntennaID
        {
            get { return _AntennaID; }
            set { _AntennaID = value; }
        }

        private int _TransPowerID = 2220;
        public int TransPowerID
        {
            get { return _TransPowerID; }
            set { _TransPowerID = value; }
        }

        // Trigger
        private START_TRIGGER_TYPE _ModeStart = START_TRIGGER_TYPE.START_TRIGGER_TYPE_GPI;
        public START_TRIGGER_TYPE ModeStart
        {
            get { return _ModeStart; }
            set { _ModeStart = value; }
        }
        private STOP_TRIGGER_TYPE _ModeStop = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
        public STOP_TRIGGER_TYPE ModeStop
        {
            get { return _ModeStop; }
            set { _ModeStop = value; }
        }
        private int _gpiStartPin = 1;
        public int GpiStartPin
        {
            get { return _gpiStartPin; }
            set { _gpiStartPin = value; }
        }

        private int _gpiStartEvent = 0;
        public int GpiStartEvent
        {
            get { return _gpiStartEvent; }
            set { _gpiStartEvent = value; }
        }

        private int _DurationStop = 500;
        public int DurationStop
        {
            get { return _DurationStop; }
            set { _DurationStop = value; }
        }

        private int _TagReportTrigger = 1;
        public int TagReportTrigger
        {
            get { return _TagReportTrigger; }
            set { _TagReportTrigger = value; }
        }
        private int _GPIStopPin = 1;

        public int GPIStopPin
        {
            get { return _GPIStopPin; }
            set { _GPIStopPin = value; }

        }

        private int _GPIStopEvent = 0;

        public int GPIStopEvent
        {
            get { return _GPIStopEvent; }
            set { _GPIStopEvent = value; }
        }

        private int _GPIStopTimeout = 0;

        public int GPIStopTimeout
        {
            get { return _GPIStopTimeout; }
            set { _GPIStopTimeout = value; }
        }

        //
        // Operation
        private RFID_OPERATION_TYPE _TypeOfOperation = RFID_OPERATION_TYPE.None;

        public RFID_OPERATION_TYPE TypeOfOperation
        {
            get { return _TypeOfOperation; }
            set { _TypeOfOperation = value; }
        }
        private int _RSSI_Filter = 0;

        public int RSSI_Filter
        {
            get { return _RSSI_Filter; }
            set { _RSSI_Filter = value; }
        }

        private int _RSSIFilterOn = 0;

        public int RSSIFilterOn
        {
            get { return _RSSIFilterOn; }
            set { _RSSIFilterOn = value; }
        }
        //
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
                byte[] _Command = new byte[39];
                int maxValueFor2Byte = 65535;
                int maxValueFor1Byte = 255;

                /* HIDE VALUE (HEADER)
                _Command[0] = 16;
                _Command[1] = 65;
                _Command[2] = 00;
                _Command[3] = 01;
                */

                //GPI
                _Command[4] = CommonFunctions.ConvertNumberToByteArray(GPIArray[0], 1)[0];
                _Command[5] = CommonFunctions.ConvertNumberToByteArray(GPIArray[1], 1)[0];
                _Command[6] = CommonFunctions.ConvertNumberToByteArray(GPIArray[2], 1)[0];
                _Command[7] = CommonFunctions.ConvertNumberToByteArray(GPIArray[3], 1)[0];

                //GPO
                _Command[8] = CommonFunctions.ConvertNumberToByteArray(GPOArray[0], 1)[0];
                _Command[9] = CommonFunctions.ConvertNumberToByteArray(GPOArray[1], 1)[0];
                _Command[10] = CommonFunctions.ConvertNumberToByteArray(GPOArray[2], 1)[0];
                _Command[11] = CommonFunctions.ConvertNumberToByteArray(GPOArray[3], 1)[0];

                var maxTagCount = CommonFunctions.ConvertNumberToByteArray(MaxTagCount, maxValueFor2Byte);
                _Command[12] = maxTagCount[0];
                _Command[13] = maxTagCount[1];

                var maxSizeMB = CommonFunctions.ConvertNumberToByteArray(MaxSizeMemoryBank, maxValueFor2Byte);
                _Command[14] = maxSizeMB[0];
                _Command[15] = maxSizeMB[1];

                var maxTagIDLength = CommonFunctions.ConvertNumberToByteArray(MaxTagIDLength, maxValueFor2Byte);
                _Command[16] = maxTagIDLength[0];
                _Command[17] = maxTagIDLength[1];

                var antennaID = CommonFunctions.ConvertNumberToByteArray(AntennaID, maxValueFor2Byte);
                _Command[18] = antennaID[0];
                _Command[19] = antennaID[1];

                var transPwr = CommonFunctions.ConvertNumberToByteArray(TransPowerID, maxValueFor2Byte);
                _Command[20] = transPwr[0];
                _Command[21] = transPwr[1];

                // Trigger Config
                _Command[22] = CommonFunctions.ConvertNumberToByteArray((byte)ModeStart, maxValueFor1Byte)[0];

                _Command[23] = CommonFunctions.ConvertNumberToByteArray((byte)ModeStop, maxValueFor1Byte)[0];

                var gpiStartP = CommonFunctions.ConvertNumberToByteArray(GpiStartPin, maxValueFor2Byte);
                _Command[24] = gpiStartP[0];
                _Command[25] = gpiStartP[1];

                _Command[26] = CommonFunctions.ConvertNumberToByteArray(GpiStartEvent, maxValueFor1Byte)[0];

                var durationStp = CommonFunctions.ConvertNumberToByteArray(DurationStop, maxValueFor2Byte);
                _Command[27] = durationStp[0];
                _Command[28] = durationStp[1];

                var tagRP = CommonFunctions.ConvertNumberToByteArray(TagReportTrigger, maxValueFor2Byte);
                _Command[29] = tagRP[0];
                _Command[30] = tagRP[1];


                var gpiStopP = CommonFunctions.ConvertNumberToByteArray(GPIStopPin, maxValueFor2Byte);
                _Command[31] = gpiStopP[0];
                _Command[32] = gpiStopP[1];

                _Command[33] = CommonFunctions.ConvertNumberToByteArray(GPIStopEvent, maxValueFor1Byte)[0];

                var timeout = CommonFunctions.ConvertNumberToByteArray(GPIStopTimeout, maxValueFor2Byte);
                _Command[34] = timeout[0];
                _Command[35] = timeout[1];

                //RSSI
                _Command[36] = CommonFunctions.ConvertNumberToByteArray(RSSIFilterOn, maxValueFor1Byte)[0];

                var rssiValue = CommonFunctions.ConvertNumberToByteArray(RSSI_Filter, maxValueFor2Byte);
                _Command[37] = rssiValue[0];
                _Command[38] = rssiValue[1];
                return _Command;
            }

        }
    }
}
