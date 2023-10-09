using ML.Common.Enum;
using ML.Connections.DataType;
using ML.SDK.DM60X.Model;
using ML.SDK.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCDM60X.Model
{
    public class DM60XDeviceRunningModel : TransferRunningModel
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

        private List<CodeModel> _DetailsTagList = new List<CodeModel>();
        public List<CodeModel> DetailsTagList
        {
            get { return _DetailsTagList; }
            set { _DetailsTagList = value; }
        }

        private DM60XDistributionSchedulesModel _Schedules = new DM60XDistributionSchedulesModel();
        public DM60XDistributionSchedulesModel Schedules
        {
            get { return _Schedules; }
            set { _Schedules = value; }
        }

        public override void ResetDefault()
        {
            base.ResetDefault();
            _DetailsTagList = new List<CodeModel>();
            _Index = 0;
            _Status = RunningStatusEnum.Disconnected;
            _IsOffline = false;
            //_Schedules = new DM60XDistributionSchedulesModel();
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
