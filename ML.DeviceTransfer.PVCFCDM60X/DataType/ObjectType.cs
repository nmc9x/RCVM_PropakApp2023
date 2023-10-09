using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCDM60X.DataType
{
    public class ObjectType
    {

    }
    //

    #region Enum

    
    public enum DM60XProductItemStatusEnum
    {
        None = 0,//
        CheckedSuccess = 1,
        CheckedFailed = 2,
        ActivedSuccess = 3,
        ActivedFailed = 4
    }

    public enum DM60XProductItemResultEnum
    {
        None = 0,//
        Unknown = 1,
        //
        //Scan success
        WaitToSync = 2,//Check sucess and wait to sync with server
        DuplicateCode = 6,
        WrongIDCode = 7,
        WrongProductCode = 8,
        //
        ActivedSuccess = 4,
        ActivedFailed = 5,
        //End Scan success
        //
        //Scan failed
        MissProduct = 9,
        //End Scan failed
        //Dont use
        WrongProductName = 10,//In database but wrong product name
        WrongPallet = 11,
        PalletExcessQuantity = 12,//Pallet dư số lượng
        PalletLackQuantity = 13,//Pallet thiếu số lượng
        UnknownPallet = 14,
        MissPallet = 15
        //End Dont use
    }

    public enum PVCFCOperationEnum
    {
        Import = 0,
        Export = 1
    }
    #endregion//End Enum

    #region Extensions
    //Extension get string of enum
   

    public static class PVCFCOparationExtensions
    {
        //Define color for text
        public static string GetText(this PVCFCOperationEnum op)
        {
            switch (op)
            {
                case PVCFCOperationEnum.Export:
                    return Languages.Languages.MsgProductDistributionsModule;
                case PVCFCOperationEnum.Import:
                    return Languages.Languages.MsgProductionBaggingWarehousingModule;
            }
            return Languages.Languages.MsgProductDistributionsModule;
        }
    }

    #endregion//End Extensions
}
