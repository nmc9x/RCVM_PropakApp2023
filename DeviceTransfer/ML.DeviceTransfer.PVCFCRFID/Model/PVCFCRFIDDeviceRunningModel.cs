using ML.Common.Enum;
using ML.Connections.DataType;
using ML.SDK.RDIF_FX9600.Controller;
using ML.SDK.RDIF_FX9600.Model;
using ML.SDK.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCRFID.Model
{
    public class PVCFCRFIDDeviceRunningModel : TransferRunningModel
    {
        private int _Index = -1;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        private RunningStatusEnum _Status = RunningStatusEnum.Disconnected;
        public RunningStatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private bool _IsOffline = false;
        public bool IsOffline
        {
            get { return _IsOffline; }
            set { _IsOffline = value; }
        }

        private List<TagModel> _DetailsTagList = new List<TagModel>();
        public List<TagModel> DetailsTagList
        {
            get { return _DetailsTagList; }
            set { _DetailsTagList = value; }
        }

        private PVCFCDistributionSchedulesModel _Schedules = new PVCFCDistributionSchedulesModel();
        public PVCFCDistributionSchedulesModel Schedules
        {
            get { return _Schedules; }
            set { _Schedules = value; }
        }

        public override void ResetDefault()
        {
            base.ResetDefault();
            _DetailsTagList = new List<TagModel>();
            _Index = 0;
            _Status = RunningStatusEnum.Disconnected;
            _IsOffline = false;
            _Schedules = new PVCFCDistributionSchedulesModel();
            //_Index = -1;
        }

        /// <summary>
        /// Linh.Tran_230913
        /// </summary>
        /// <returns></returns>
        public RunningStatusEnum RefreshStatus(RunningStatusEnum? newStatus)
        {
            switch (this.TransferStatus)
            {
                case ConnectionsType.StatusEnum.Connected:
                    switch (_Status)
                    {
                        case RunningStatusEnum.Processing:
                        case RunningStatusEnum.Ready:
                        case RunningStatusEnum.Starting:
                        case RunningStatusEnum.Stop:
                            return (newStatus != null) ? (RunningStatusEnum)newStatus : _Status;
                        case RunningStatusEnum.Connected:
                            return RunningStatusEnum.Stop;
                        default:
                            return RunningStatusEnum.Stop;
                    }
                case ConnectionsType.StatusEnum.DisConnected:
                    return RunningStatusEnum.Disconnected;
                case ConnectionsType.StatusEnum.Processing:
                    return RunningStatusEnum.Block;
                case ConnectionsType.StatusEnum.Unknown:
                    return RunningStatusEnum.Error;
            }
            return RunningStatusEnum.Error;
        }
    }
}
