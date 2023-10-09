using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Connections.DataType
{
    public class ConnectionsType
    {
        public enum StatusEnum
        {
            Unknown = 0,
            Connected = 1,
            DisConnected = 2,
            Processing = 3,
        }

        public enum ResultEnum
        {
            Unknown = 0,
            Success = 1,
            Failed = 2
        }

        public enum SocketTransferTypeCommandEnum
        {
            DeviceType = 0x10
        }

        public enum SockTypeCommandEnum
        {
            UICommand = 0x40,
            DeviceCommand = 0x41
        }

        public enum UISocketCommandEnum
        {
            DeviceStatus = 0x01,
            Start = 0x02,//Linh.Tran_230911
            Stop = 0x03,//Linh.Tran_230911
            Page = 0x04//Linh.Tran_230911
        }

        #region COM Values
        public static List<string> GetAvailableOMPort()
        {
            List<string> returnCOMList = SerialPort.GetPortNames().ToList();
            if (returnCOMList.Count() <= 0)
            {
                returnCOMList.Add("COM1");
            }
            return returnCOMList;
        }

        public static int GetCOMPortIndex(string COMPort)
        {
            int returnValue = 0;
            returnValue = GetAvailableOMPort().IndexOf(COMPort);
            return returnValue;
        }

        public static List<int> GetBaudRateList()
        {
            return new List<int>(){
                75,110,134,150,300,600,1200,1800,2400,4800,7200,9600,14400,19200,38400,57600,115200,128000
            };
        }

        public static List<int> GetDataBitList()
        {
            return new List<int>(){
                4,5,6,7,8
            };
        }

        public static List<Parity> GetParityList()
        {
            return new List<Parity>(){
                Parity.Even,Parity.Mark,Parity.None,Parity.Odd,Parity.Space
            };
        }

        public static List<StopBits> GetStopBitList()
        {
            return new List<StopBits>(){
                StopBits.None,StopBits.One,StopBits.OnePointFive,StopBits.Two
            };
        }

        public static int GetBaudRateIndex(int baudRate)
        {
            int returnValue = 0;
            returnValue = GetBaudRateList().IndexOf(baudRate);
            return returnValue;
        }

        public static int GetBaudRate(int index)
        {
            int returnBaudReate = 0;
            if (index < GetBaudRateList().Count)
            {
                returnBaudReate = GetBaudRateList()[index];
            }
            return returnBaudReate;
        }

        public static int GetDataBitsIndex(int dataBits)
        {
            int returnValue = 0;
            returnValue = GetDataBitList().IndexOf(dataBits);
            return returnValue;
        }

        public static int GetDataBits(int index)
        {
            int returnDataBits = 0;
            if (index < GetDataBitList().Count)
            {
                returnDataBits = GetDataBitList()[index];
            }
            return returnDataBits;
        }

        public static int GetParityIndex(Parity parity)
        {
            int returnValue = 0;
            returnValue = GetParityList().IndexOf(parity);
            return returnValue;
        }

        public static Parity GetParity(int index)
        {
            Parity returnParity = 0;
            if (index < GetParityList().Count)
            {
                returnParity = GetParityList()[index];
            }
            return returnParity;
        }

        public static int GetStopBitsIndex(StopBits stopBits)
        {
            int returnValue = 0;
            returnValue = GetStopBitList().IndexOf(stopBits);
            return returnValue;
        }

        public static StopBits GetStopBits(int index)
        {
            StopBits returnStopBits = 0;
            if (index < GetStopBitList().Count)
            {
                returnStopBits = GetStopBitList()[index];
            }
            return returnStopBits;
        }
        #endregion//End COM Values

    }
}
