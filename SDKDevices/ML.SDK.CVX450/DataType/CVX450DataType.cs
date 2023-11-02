using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.CVX450.DataType
{
    public class CVX450DataType
    {
        public enum TRIGGER_TYPE
        {
           SINGLE,
           BRUST
        }

        public enum DELAY_TYPE
        {
            NONE,
            TIME
        }
        public enum UNIT_TYPE
        {
            microSecond,
            imagePerSecond
        }
        public enum CVX450_MODE_TYPE
        {
            Data = 0,
            Config = 1,
            Operation = 2
        }
        public enum OUTPUT_DELAY_TYPE
        {
            NONE = 0,
            TIME = 1,
            DISTANCE = 2
        }
        public enum CVX450_OPERATION_TYPE
        {
            Disconnect = 0,
            StartRead = 1,
            StopRead = 2,
            None = 8
        }
        public enum BARCODE_SYMBOL_TYPE
        {
            // Code 2D
            DATAMATRIX = 1,
            QRCODE =2,
            MAXICODE =3,
            AZTECCODE =4,

            // Code 1D
            CODE128 =5,
            CODE25 = 6,
            CODE93 = 7,
            CODE39 = 8,
            PHARMACODE = 9,
            CODABAR = 10,
            INTERLEAVED2OF5 = 11,
            UPCEAN =12,
            MSI = 13,

            // Stacked
            PDF417=14,
            EANUCC = 15,
            MICROPDF417= 16,
            DATABAR = 17,

            // POSTAL
            POSTNET = 18,
            PLANET = 19,
            JAPANPOST= 20,
            UPU = 21,   
            AUSTRALIAPOST = 22,
            INTELLIGENT = 23
        }
    }
}
