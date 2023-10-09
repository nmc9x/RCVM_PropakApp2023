using ML.Common.Controller;
using ML.DeviceTransfer.PVCFCRFID.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCRFID.Model
{
    public class PVCFCProductItemModel
    {

        private string _ProductCode = "";
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        private string _TagID = "";
        public string TagID
        {
            get { return _TagID; }
            set { _TagID = value; }
        }

        private string _PalletCode = "";
        public string PalletCode
        {
            get { return _PalletCode; }
            set { _PalletCode = value; }
        }

        private PVCFCProductItemStatusEnum _Status;
        public PVCFCProductItemStatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }


        private PVCFCProductItemResultEnum _Results;
        public PVCFCProductItemResultEnum Results
        {
            get { return _Results; }
            set { _Results = value; }
        }

        private string _Errors = "";
        public string Errors
        {
            get { return _Errors; }
            set { _Errors = value; }
        }

        private DateTime _ScanDatetime;
        public DateTime ScanDatetime
        {
            get { return _ScanDatetime; }
            set { _ScanDatetime = value; }
        }

        private bool _IsPalletCode = false;
        public bool IsPalletCode
        {
            get { return _IsPalletCode; }
            set { _IsPalletCode = value; }
        }

        public byte[] GetItemsToByteArr(int scanSuccess, int scanFailed, int activeSuccess, int activeFailed, int total)
        {
            //
            byte[] tid = CommonFunctions.ConvertStringToByteArray(_TagID);
            byte[] epc = CommonFunctions.ConvertStringToByteArray(_ProductCode);
            byte[] dateScan = BitConverter.GetBytes(_ScanDatetime.Ticks);
            byte[] errors = CommonFunctions.ConvertStringToByteArray(_Errors);
            byte[] byteArr = new byte[15 + 2 + (1 + tid.Length) + (1 + epc.Length) + (1 + dateScan.Length) + (1 + errors.Length)];
            //
            byteArr[0] = (byte)scanSuccess;
            byteArr[1] = (byte)(scanSuccess >> 8);
            byteArr[2] = (byte)(scanSuccess >> 16);

            byteArr[3] = (byte)scanFailed;
            byteArr[4] = (byte)(scanFailed >> 8);
            byteArr[5] = (byte)(scanFailed >> 16);

            byteArr[6] = (byte)activeSuccess;
            byteArr[7] = (byte)(activeSuccess >> 8);
            byteArr[8] = (byte)(activeSuccess >> 16);

            byteArr[9] = (byte)activeFailed;
            byteArr[10] = (byte)(activeFailed >> 8);
            byteArr[11] = (byte)(activeFailed >> 16);

            byteArr[12] = (byte)total;
            byteArr[13] = (byte)(total >> 8);
            byteArr[14] = (byte)(total >> 16);

            byteArr[15] = (byte)_Status;
            byteArr[16] = (byte)_Results;
            //
            byteArr[17] = (byte)tid.Length;
            if (tid.Length > 0)
                Array.Copy(tid, 0, byteArr, 18, tid.Length);
            //
            byteArr[18 + tid.Length] = (byte)epc.Length;
            if (epc.Length > 0)
                Array.Copy(epc, 0, byteArr, 19 + tid.Length, epc.Length);
            //
            byteArr[19 + tid.Length + epc.Length] = (byte)dateScan.Length;
            if (dateScan.Length > 0)
                Array.Copy(dateScan, 0, byteArr, 20 + tid.Length + epc.Length, dateScan.Length);
            //
            byteArr[20 + tid.Length + epc.Length + dateScan.Length] = (byte)errors.Length;
            if (errors.Length > 0)
                Array.Copy(errors, 0, byteArr, 21 + tid.Length + epc.Length + dateScan.Length, errors.Length);
            //
            return byteArr;
        }

        public static PVCFCProductItemModel GetProductTagItems(byte[] byteItems, ref int scanSuccess, ref int scanFailed, ref int activeSuccess, ref int activeFailed, ref int total)
        {
            //
            scanSuccess = (byteItems[0] | (byteItems[1] << 8)|byteItems[2] << 8);
            scanFailed = (byteItems[3] | (byteItems[4] << 8) | byteItems[5] << 8);
            activeSuccess = (byteItems[6] | (byteItems[7] << 8) | byteItems[8] << 8);
            activeFailed = (byteItems[9] | (byteItems[10] << 8) | byteItems[11] << 8);
            total = (byteItems[12] | (byteItems[13] << 8) | byteItems[14] << 8);

            PVCFCProductItemStatusEnum status = (PVCFCProductItemStatusEnum)byteItems[15];
            PVCFCProductItemResultEnum result = (PVCFCProductItemResultEnum)byteItems[16];
            int tidLength = (int)byteItems[17];
            int epcLength = (int)byteItems[18 + tidLength];
            int dateLength = (int)byteItems[19 + tidLength + epcLength];
            int errorLength = (int)byteItems[20 + tidLength + epcLength + dateLength];
            //

            string tid = CommonFunctions.ConvertByteArrayToString(byteItems.Skip(18).Take(tidLength).ToArray());
            string epc = CommonFunctions.ConvertByteArrayToString(byteItems.Skip(19 + tidLength).Take(epcLength).ToArray());
            DateTime dateScan = DateTime.FromBinary(BitConverter.ToInt64(byteItems.Skip(20 + tidLength + epcLength).Take(dateLength).ToArray(), 0));
            string errors = CommonFunctions.ConvertByteArrayToString(byteItems.Skip(21 + tidLength + epcLength + dateLength).Take(errorLength).ToArray());
            //
            return new PVCFCProductItemModel()
            {
                TagID = tid,
                ProductCode = epc,
                Status = status,
                Results = result,
                ScanDatetime = dateScan,
                Errors = errors
            };
        }

    }
}
