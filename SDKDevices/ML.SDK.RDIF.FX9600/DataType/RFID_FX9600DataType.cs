namespace ML.SDK.RDIF_FX9600.DataType
{

    public enum RFID_MODE_TYPE
    {
        Data = 0,
        Config = 1,
        Operation = 2

    }
    public enum RFID_OPERATION_TYPE
    {
        Disconnect = 0,
        StartRead = 1,
        StopRead = 2,
        Login = 3,
        Logout = 4,
        ClearReport = 5,
        Reboot = 6,
        ResetFactoryDefault = 7,
        None = 8
    }

    public enum FBK_RESULT_OPR_TYPE
    {

    }

    public enum STATUS_EVENT_TYPE
    {
        INVENTORY_START_EVENT,
        INVENTORY_STOP_EVENT,
        ACCESS_START_EVENT,
        ACCESS_STOP_EVENT,
        GPI_EVENT,
        ANTENNA_EVENT,
        BUFFER_FULL_WARNING_EVENT,
        BUFFER_FULL_EVENT,
        DISCONNECTION_EVENT,
        READER_EXCEPTION_EVENT,
        TEMPERATURE_ALARM_EVENT,
        UNKNOWN
    }

    public enum RFID_FX9600TriggerTypeEnum
    {
        Immediate = 0,
        GPIWithTimeout = 1,
        Duration = 2,
        TagObservation = 3
    }

    public enum RFID_FX9600DataType
    {
        Data = 0,
        Config = 1,
        Operation = 2
    }
}
