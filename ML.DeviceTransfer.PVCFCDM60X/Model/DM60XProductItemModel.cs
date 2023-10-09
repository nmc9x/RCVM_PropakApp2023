using ML.Common.Controller;
using ML.DeviceTransfer.PVCFCDM60X.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCDM60X.Model
{
    public class DM60XProductItemModel
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

        //private PVCFCProductItemStatusEnum _Status;
        //public PVCFCProductItemStatusEnum Status
        //{
        //    get { return _Status; }
        //    set { _Status = value; }
        //}


        //private PVCFCProductItemResultEnum _Results;
        //public PVCFCProductItemResultEnum Results
        //{
        //    get { return _Results; }
        //    set { _Results = value; }
        //}

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

        private DM60XProductItemStatusEnum _Status;
        public DM60XProductItemStatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public byte[] GetItemsToByteArr(int scanSuccess, int scanFailed, int activeSuccess, int activeFailed, int total)
        {
            return null;
        }
    }
}
