using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.DataType
{
    public class ObjectType
    {
        public enum ProductItemStatusEnum
        {
            None = 0,//
            Success = 1,
            CheckedSuccess = 2,
            CheckedFailed = 3,
            ActivedSuccess = 4,
            ActivedFailed = 5,
            DuplicateCode = 6,
            WrongProductName = 7,//In database but wrong product name
            WrongPallet = 8,
            Unknown = 9,
            PalletExcessQuantity = 10,//Pallet dư số lượng
            PalletLackQuantity = 11,//Pallet thiếu số lượng
            MissProduct = 12,
            UnknownPallet = 13,
            MissPallet = 14
        }
    }
}
