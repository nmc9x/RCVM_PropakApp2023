using ML.Common.Enum;
using ML.Common.Model;
using ML.DeviceTransfer.PVCFCRFID.Model;
using ML.SDK.RDIF_FX9600.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PVCFC_RFID.Model
{
    public class RunningModel : CommonRunningModel
    {
        private bool _IsOffline = false;
        public bool IsOffline
        {
            get { return _IsOffline; }
            set { _IsOffline = value; }
        }

        private bool _IsSyncData = false;
        public bool IsSyncData
        {
            get { return _IsSyncData; }
            set { _IsSyncData = value; }
        }

        private int _NumberOfStation = -1;
        public int NumberOfStation
        {
            get { return _NumberOfStation; }
            set { _NumberOfStation = value; }
        }

        private List<RunningStationModel> _StationList = new List<RunningStationModel>();
        public List<RunningStationModel> StationList
        {
            get { return _StationList; }
            set { _StationList = value; }
        }

        private Point _DetailsFormLocations = new Point(0, 0);
        public Point DetailsFormLocations
        {
            get { return _DetailsFormLocations; }
            set { _DetailsFormLocations = value; }
        }

        private Size _DetailsFormSize = new Size(1204, 768);
        public Size DetailsFormSize
        {
            get { return _DetailsFormSize; }
            set { _DetailsFormSize = value; }
        }


        private Point _ChildFormLocations = new Point(0, 0);
        public Point ChildFormLocations
        {
            get { return _ChildFormLocations; }
            set { _ChildFormLocations = value; }
        }

        private Size _ChildFormSize = new Size(1204, 768);
        public Size ChildFormSize
        {
            get { return _ChildFormSize; }
            set { _ChildFormSize = value; }
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
            _IsOffline = false;
            _IsSyncData = false;
            _StationList = new List<RunningStationModel>();
            _DetailsFormLocations = new Point(0, 0);
            _DetailsFormSize = new Size(1204, 768);
            _ChildFormLocations = new Point(0, 0);
            _ChildFormSize = new Size(1204, 768);
            for (int i = 0; i < _NumberOfStation; i++)
            {
                RunningStationModel items = new RunningStationModel();
                items.Index = i;
                items.Schedules = new PVCFCDistributionSchedulesModel();
                _StationList.Add(items);
            }
            //
        }

        #region Methods
        public bool IsStarting()
        {
            if (_StationList.Where(s => (new RunningStatusEnum[] { RunningStatusEnum.Processing, RunningStatusEnum.Ready, RunningStatusEnum.Starting, RunningStatusEnum.Sync }).Contains(s.Status)).Count() > 0)
            {
                return true;
            }
            else
            {
                return _IsSyncData;
            }
        }
        #endregion//End Methods

    }
}
