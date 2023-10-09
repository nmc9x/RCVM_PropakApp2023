using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Model
{
    public class ProductItemModel
    {
        private string _ChipID = "";
        public string ChipID
        {
            get { return _ChipID; }
            set { _ChipID = value; }
        }

        private string _ProductCode = "";
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        private string _PalletCode = "";
        public string PalletCode
        {
            get { return _PalletCode; }
            set { _PalletCode = value; }
        }

        private App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum _Status;
        public App.DevCodeActivatorRFID.DataType.ObjectType.ProductItemStatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private DateTime _ScanDatetime;
        public DateTime ScanDatetime
        {
            get { return _ScanDatetime; }
            set { _ScanDatetime = value; }
        }

        private bool _IsCheckSuccess = false;
        /// <summary>
        /// Linh.Tran_230628: Check success not miss
        /// </summary>
        public bool IsCheckSuccess
        {
            get { return _IsCheckSuccess; }
            set { _IsCheckSuccess = value; }
        }

        private bool _IsActivedSuccess = false;
        public bool IsActivedSuccess
        {
            get { return _IsActivedSuccess; }
            set { _IsActivedSuccess = value; }
        }

        private bool _IsPalletCode = false;
        public bool IsPalletCode
        {
            get { return _IsPalletCode; }
            set { _IsPalletCode = value; }
        }
    }
}
