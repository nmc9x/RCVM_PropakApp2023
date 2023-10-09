using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PVCFCRFID.DataType
{
    public class ObjectType
    {

    }
    //

    #region Enum
    public enum PVCFCProductItemStatusEnum
    {
        None = 0,//
        CheckedSuccess = 1,
        CheckedFailed = 2,
        ActivedSuccess = 3,
        ActivedFailed = 4
    }

    public enum PVCFCProductItemResultEnum
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
    public static class PVCFCProductItemStatusExtensions
    {
        public static List<PVCFCProductItemResultEnum> GetResult(this PVCFCProductItemStatusEnum productStatus)
        {
            List<PVCFCProductItemResultEnum> resultList = new List<PVCFCProductItemResultEnum>();
            switch (productStatus)
            {
                case PVCFCProductItemStatusEnum.CheckedSuccess:
                    resultList.Add(PVCFCProductItemResultEnum.WaitToSync);
                    resultList.Add(PVCFCProductItemResultEnum.DuplicateCode);
                    resultList.Add(PVCFCProductItemResultEnum.WrongIDCode);
                    resultList.Add(PVCFCProductItemResultEnum.WrongProductCode);
                    resultList.Add(PVCFCProductItemResultEnum.ActivedSuccess);
                    resultList.Add(PVCFCProductItemResultEnum.ActivedFailed);
                    break;

                case PVCFCProductItemStatusEnum.CheckedFailed:
                    resultList.Add(PVCFCProductItemResultEnum.MissProduct);
                    break;

                case PVCFCProductItemStatusEnum.ActivedSuccess:
                    resultList.Add(PVCFCProductItemResultEnum.ActivedSuccess);
                    break;

                case PVCFCProductItemStatusEnum.ActivedFailed:
                    resultList.Add(PVCFCProductItemResultEnum.ActivedFailed);
                    break;
                default:
                    break;
            }
            return resultList;
        }


        //Define color for text
        public static string GetText(this PVCFCProductItemStatusEnum productStatus)
        {
            string text = ML.Languages.Languages.None;
            switch (productStatus)
            {
                case PVCFCProductItemStatusEnum.CheckedSuccess:
                    text = ML.Languages.Languages.CheckedSuccess;
                    break;
                case PVCFCProductItemStatusEnum.CheckedFailed:
                    text = ML.Languages.Languages.CheckedFailed;
                    break;
                case PVCFCProductItemStatusEnum.ActivedSuccess:
                    text = ML.Languages.Languages.ActivedSuccess;
                    break;
                case PVCFCProductItemStatusEnum.ActivedFailed:
                    text = ML.Languages.Languages.ActivedFailed;
                    break;
            }
            return text;
        }


        //Define color for text
        public static Color GetColor(this PVCFCProductItemStatusEnum productStatus)
        {
            Color color = Color.Black;
            switch (productStatus)
            {
                case PVCFCProductItemStatusEnum.CheckedSuccess:
                    //color = Color.LightSeaGreen;
                    color = SystemColors.HotTrack;
                    break;
                case PVCFCProductItemStatusEnum.CheckedFailed:
                    color = Color.DarkOrange;//Color.Maroon;
                    break;
                case PVCFCProductItemStatusEnum.ActivedSuccess:
                    color = Color.Green;
                    break;
                case PVCFCProductItemStatusEnum.ActivedFailed:
                    color = Color.Red;
                    break;
            }
            return color;
        }
    }

    //Extension get string of enum
    public static class PVCFCProductItemResultExtensions
    {
        public static PVCFCProductItemStatusEnum GetStatus(this PVCFCProductItemResultEnum productResult)
        {
            PVCFCProductItemStatusEnum status = PVCFCProductItemStatusEnum.None;
            switch (productResult)
            {
                case PVCFCProductItemResultEnum.Unknown:
                case PVCFCProductItemResultEnum.WaitToSync:
                //case PVCFCProductItemResultEnum.ActivedSuccess:
                //case PVCFCProductItemResultEnum.ActivedFailed:
                case PVCFCProductItemResultEnum.DuplicateCode:
                case PVCFCProductItemResultEnum.WrongIDCode:
                case PVCFCProductItemResultEnum.WrongProductCode:
                    status = PVCFCProductItemStatusEnum.CheckedSuccess;
                    break;

                case PVCFCProductItemResultEnum.MissProduct:
                    status = PVCFCProductItemStatusEnum.CheckedFailed;
                    break;
                default:
                    break;
                case PVCFCProductItemResultEnum.ActivedSuccess:
                    status = PVCFCProductItemStatusEnum.ActivedSuccess;
                    break;
                case PVCFCProductItemResultEnum.ActivedFailed:
                    status = PVCFCProductItemStatusEnum.ActivedFailed;
                    break;
            }

            return status;
        }

        //Define color for text
        public static string GetText(this PVCFCProductItemResultEnum results)
        {
            string strResults = ML.Languages.LanguagesFunctions.GetTranslate(results.ToString());
            
            return strResults;
        }


        public static Color GetColor(this PVCFCProductItemResultEnum results)
        {
            Color clrResults = Color.Red;
            switch (results)
            {
                case PVCFCProductItemResultEnum.WaitToSync:
                    //clrResults = Color.LightSeaGreen;
                    clrResults = SystemColors.HotTrack;
                    break;
               
                case PVCFCProductItemResultEnum.DuplicateCode:
                case PVCFCProductItemResultEnum.WrongIDCode:
                case PVCFCProductItemResultEnum.WrongProductCode:
                //
                case PVCFCProductItemResultEnum.WrongProductName:
                case PVCFCProductItemResultEnum.WrongPallet:
                case PVCFCProductItemResultEnum.PalletExcessQuantity: 
                case PVCFCProductItemResultEnum.UnknownPallet:
                    clrResults = Color.OrangeRed;
                    break;
                case PVCFCProductItemResultEnum.MissProduct:
                case PVCFCProductItemResultEnum.MissPallet:
                case PVCFCProductItemResultEnum.PalletLackQuantity:
                    clrResults = Color.Red;
                    break;
                case PVCFCProductItemResultEnum.ActivedSuccess:
                    clrResults = Color.Green;
                    break;
                case PVCFCProductItemResultEnum.ActivedFailed:
                    clrResults = Color.Red;
                    break;
            }
            return clrResults;
        }
    }

    public static class PVCFCOparationExtensions
    {
        //Define color for text
        public static string GetText(this PVCFCOperationEnum op)
        {
            switch(op)
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
