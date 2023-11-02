using App.PVCFC_RFID.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.CVX450.Model
{
    public class CodeModel : ViewModelBase
    {
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { SetProperty(ref _ID, value); }
        }

        private string _Code;

        public string Code
        {
            get { return _Code; }
            set { SetProperty(ref _Code, value); }
        }

        private string _Symbol;

        public string Symbol
        {
            get { return _Symbol; }
            set { SetProperty(ref _Symbol, value); }
        }

        private string _DecodeTime;

        public string DecodeTime
        {
            get { return _DecodeTime; }
            set { SetProperty(ref _DecodeTime, value); }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }


        private string _DateTimeStr;

        public string DateTimeStr
        {
            get { return _DateTimeStr; }
            set { SetProperty(ref _DateTimeStr, value); }
        }

        private string _ErrorStr;

        public string ErrorStr
        {
            get { return _ErrorStr; }
            set { SetProperty(ref _ErrorStr, value); }
        }

        public CodeModel()
        {
            ID = null; Code = null; Symbol = null; DecodeTime = null; Status = null; DateTimeStr = "";
        }
    }
}
