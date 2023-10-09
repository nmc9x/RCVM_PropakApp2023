using ML.Common.Model;
using ML.SDK.RFID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Model
{
    public class StationModel : CommonSettingsModel
    {
        private int _Index = -1;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        private RFIDDeviceSettingsModel _RFID = new RFIDDeviceSettingsModel();
        public RFIDDeviceSettingsModel RFID
        {
            get { return _RFID; }
            set { _RFID = value; }
        }

        private DistributionSchedulesModel _Schedules = new DistributionSchedulesModel();
        public DistributionSchedulesModel Schedules
        {
            get { return _Schedules; }
            set { _Schedules = value; }
        }
    }
}
