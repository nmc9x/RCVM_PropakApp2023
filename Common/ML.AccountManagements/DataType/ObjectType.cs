using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.AccountManagements.DataType
{
    class ObjectType
    {
    }

    #region Enum
    public enum FunctionsEnum
    {
        Design = 0,
        Setting = 1,
        Viewlog = 2,
        Update = 3,
        Account = 4,
        Controls = 5,//(Start/Stop process)
        SyncData = 6
    }

    public enum UserTaskEnum
    {
        None = 0,
        AddNew = 1,
        Edit = 2,
        Delete = 3,
        ChangePass = 4,
        ResetPass = 5,
        Login = 6
    }
    #endregion//End Enum


    #region Extension class
    public static class FunctionsEnumExtensions
    {
        public static string ToFriendlyString(this FunctionsEnum functions)
        {
            string strResult = "";
            switch (functions)
            {
                case FunctionsEnum.Account:
                    strResult = Languages.Languages.Account;
                    break;
                case FunctionsEnum.Controls:
                    strResult = Languages.Languages.Control;
                    break;
                case FunctionsEnum.Design:
                    strResult = Languages.Languages.Design;
                    break;
                case FunctionsEnum.Setting:
                    strResult = Languages.Languages.Settings;
                    break;
                case FunctionsEnum.Update:
                    strResult = Languages.Languages.Update;
                    break;
                case FunctionsEnum.Viewlog:
                    strResult = Languages.Languages.ViewLog;
                    break;
                default:
                    break;
            }
            return strResult;
        }
    }

    public static class UserTaskEnumExtensions
    {
        public static string ToFriendlyString(this UserTaskEnum task)
        {
            string strResult = "";
            switch (task)
            {
                case UserTaskEnum.AddNew:
                    strResult = Languages.Languages.Add;
                    break;
                case UserTaskEnum.ChangePass:
                    strResult = Languages.Languages.ChangePassword;
                    break;
                case UserTaskEnum.Delete:
                    strResult = Languages.Languages.Delete;
                    break;
                case UserTaskEnum.Edit:
                    strResult = Languages.Languages.Update;
                    break;
                case UserTaskEnum.None:
                    strResult = Languages.Languages.None;
                    break;
                case UserTaskEnum.ResetPass:
                    strResult = Languages.Languages.ResetPassword;
                    break;
                default:
                    break;
            }
            return strResult;
        }
    }

    public static class UserPermissionExtensions
    {
        public static string ToFriendlyString(string permissionName)
        {
            switch (permissionName)
            {
                case "Manager":
                    return Languages.Languages.Manager;//Linh.Tran_220912: Command
                case "Operator":
                    return Languages.Languages.Operator;//Linh.Tran_220912: Command
                case "Normal":
                    return Languages.Languages.Normal;//Linh.Tran_220912: Command
                default:
                    return permissionName;
            }
        }
    }
    #endregion//End Extension class
}
