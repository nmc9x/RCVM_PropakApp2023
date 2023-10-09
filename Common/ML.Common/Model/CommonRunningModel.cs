using ML.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ML.Common.Model
{
    public class CommonRunningModel
    {
        #region Properties
        private RunningStatusEnum _Status = RunningStatusEnum.Stop;
        public RunningStatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion//End Properties

        public virtual void ResetDefault()
        {
            _Status = RunningStatusEnum.Stop;
        }
    }
}
