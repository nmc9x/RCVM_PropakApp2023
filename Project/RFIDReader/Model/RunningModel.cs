using ML.Common.Model;
using ML.DeviceTransfer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Model
{
    public class RunningModel : CommonRunningModel
    {
        private int _NumberOfStation = -1;
        public int NumberOfStation
        {
            get { return _NumberOfStation; }
            set { _NumberOfStation = value; }
        }

        private List<DeviceRunningModel> _StationList = new List<DeviceRunningModel>();
        public List<DeviceRunningModel> StationList
        {
            get { return _StationList; }
            set { _StationList = value; }
        }

        private ProcessingModel _StartProcess = new ProcessingModel();
        public ProcessingModel StartProcess
        {
            get { return _StartProcess; }
            set { _StartProcess = value; }
        }

        public RunningModel(int numberOfStation)
        {
            _NumberOfStation = numberOfStation;
            ResetDefault();
        }

        public override void ResetDefault()
        {
            base.ResetDefault();
            //
            _StationList = new List<DeviceRunningModel>();
            for (int i = 0; i < _NumberOfStation; i++)
            {
                DeviceRunningModel items = new DeviceRunningModel();
                items.Index = i;
                _StationList.Add(items);
            }
            //
            _StartProcess = new ProcessingModel();
        }
    }
}
