using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PLC.DataType
{
    public class PLCEnum
    {
        public enum CommandEnum
        {
            AskFWInfo = 0x01,
            SetAlarm = 0x02,
            SetTrigger = 0x03,
            Start = 0x04,
            ReceviedTrigger = 0x05,
            Stop = 0x0c,
            SetDelayTriggerTime = 0x06
        }
    }
}
