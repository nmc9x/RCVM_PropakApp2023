using App.PVCFC_RFID.Controller;

namespace ML.SDK.DM60X.Model
{
    public class GotCodeModel : ViewModelBase
    {
        //public string ID { get; set; }
        //public string Code { get; set; }
        //public string Symbol { get; set; }
        //public string DecodeTime { get; set; }
        //public string Status { get; set; }
        //public int Count { get; set; }
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
            set { SetProperty(ref _Code, value);  }
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

        public GotCodeModel() 
        {
            ID = null; Code = null; Symbol = null; DecodeTime = null; Status = null; DateTimeStr = "";
        }
       
    }
}
