using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Common.Enum
{
    public class CommonEnum
    {
    }

    public enum RunningStatusEnum
    {
        Stop,
        Processing,
        Ready,
        Starting,
        Sync,
        Connected,
        Disconnected,
        Error,
        Block,//When customer confirm
    }

    public enum ControlsEventEnum
    {
        Start = 0,
        Stop =1,
        Trigger = 2
    }

    #region Extensions
    
    #endregion//End Extensions
}
