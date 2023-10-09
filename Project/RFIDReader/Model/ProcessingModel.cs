using ML.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Model
{
    public class ProcessingModel
    {
        private List<ChipDataModel> _ScanDataList = new List<ChipDataModel>();
        public List<ChipDataModel> ScanDataList
        {
            get { return _ScanDataList; }
            set { _ScanDataList = value; }
        }

        private List<bool> _AlarmList = new List<bool>() { false, false, false, false };
        /// <summary>
        /// 0: Green, 1: Yellow; 2: Red; 3: Buzzer
        /// </summary>
        public List<bool> AlarmList
        {
            get { return _AlarmList; }
            set { _AlarmList = value; }
        }

        private bool _IsErrorsInCheckingDataPerTime = false;
        public bool IsErrorsInCheckingDataPerTime
        {
            get { return _IsErrorsInCheckingDataPerTime; }
            set { _IsErrorsInCheckingDataPerTime = value; }
        }

        public void ResetDeafault()
        {
            _ScanDataList = new List<ChipDataModel>();
            _AlarmList = new List<bool>() { false, false, false, false };
            _IsErrorsInCheckingDataPerTime = false;
        }
    }
}
