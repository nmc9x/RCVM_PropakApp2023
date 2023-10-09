using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using ML.AccountManagements.DataType;
using ML.AccountManagements.Model;
using System.Net;
using System.Runtime.Serialization.Json;

namespace ML.AccountManagements.Controller
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class AccountController
    {
        #region Contranst values
        private static string _PassPhrase = "ML@2023";//Linh.Tran_230914
        public static string DefaultUser = "Administrator";
        public static string DefaultUserPassword = "Admin@2023";//"admin@2021";
        public static bool DefaultUserIsLocked = false;
        private static int _DefaultUserLoginFailedTimes = 0;//Linh.Tran_220912: Add to count logined failed times
        //
        //Linh.Tran_220111: Add default user: Reset pass admin and full functions, not allow edit
        public static string DefaultVIPUser = "Support";
        public static string DefaultVIPPassword = "Support@2023";//Linh.Tran_220912: Command "support@tss";

        /// <summary>
        /// Linh.Tran_220912: Add to new values - default 5 level permission => Domino
        /// </summary>
        public static string[] PermissionLevelArr = new string[4] { "Level_1", "Level_2", "Level_3", "Level_4" };
        //End Linh.Tran_210111: Add default user
        //
        //
        #endregion//End Contranst values

        #region Properties
        public static string SWName = "";
        public static string SWVersion = "";
        public static string LinkAPI = "";
        private static string UserPath = "";
        private static string LogPath = "";
        public static AccountSettingModel Settings = new AccountSettingModel();
        public static AccountModel User = new AccountModel();
        public static PermissionModel Permission = new PermissionModel();
        public static AccountItemModel LoginUser = null;
        public static APILoginModel.Root LoginUserOnline = new APILoginModel.Root();
        public static APIGetUserNameInfoModel.Root LoginUserInfoOnline = new APIGetUserNameInfoModel.Root();
        public static string LogedInUserName = "";
        #endregion//End Properties

        /// <summary>
        /// Login account to system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// 0: login success
        /// 1: invalid username
        /// 2: invalid password
        /// </returns>
        public static string Login(String username, String password)
        {
            string strErrors = "";
            //Linh.Tran_210325: Check in _ListUserDefault;
            if(DefaultVIPUser.Equals(username))//Linh.Tran_221011
            {
                #region Linh.Tran_221011 - VIP User - TSS user
                //
                if (!DefaultVIPPassword.Equals(password))
                {
                    strErrors = Languages.Languages.MsgPasswordIsIncorrect;
                }
                else
                {
                    _DefaultUserLoginFailedTimes = 0;//Linh.Tran_220912: Add to logined failed times
                    LoginUser = new AccountItemModel()
                    {
                        UserName = DefaultVIPUser,
                        Password = password,
                        PermissionLevel = PermissionLevelArr[0],//Linh.Tran_220912: Add default permission to highest => Level 1
                        SaveTime = DateTime.Now
                    };
                }
                #endregion//End Linh.Tran_221011 - VIP User - TSS User
            }
            //End Linh.Tran_221011
            else if(DefaultUser.Equals(username))
            {
                #region Linh.Tran_230917: User Admin defaults
                //Read Default password
                object data = AccountSecurityController.ReadRegistry(username);
                if (data != null)
                {
                    String decryptPass = AccountSecurityController.Decrypt(data.ToString(), username);
                    DefaultUserPassword = decryptPass;
                }
                //
                if (!DefaultUserPassword.Equals(password))
                {
                    strErrors = Languages.Languages.MsgPasswordIsIncorrect;
                }
                else
                {
                    _DefaultUserLoginFailedTimes = 0;//Linh.Tran_220912: Add to logined failed times
                    LoginUser = new AccountItemModel()
                    {
                        UserName = DefaultUser,
                        Password = password,
                        PermissionLevel = PermissionLevelArr[1],//Linh.Tran_220912: Add default permission to highest => Level 2
                        SaveTime = DateTime.Now
                    };
                }
                #endregion//End Linh.Tran_230917: User Admin defaults
            }
            //
            //Linh.Tran_210325: Check in User files
            else
            {
                #region Creater user
                int index = AccountController.User.UserModelList.FindIndex(u => u.UserName.Equals(username));
                if (index < 0)
                {
                    strErrors = Languages.Languages.AccountIsNotExist;
                }
                else
                {
                    AccountItemModel user = AccountController.User.UserModelList[index];
                    if (user.IsLocked)
                    {
                        strErrors = Languages.Languages.AccountHasBeenLocked + ". " + Languages.Languages.PleaseContactAdministratorToUnlock;
                    }
                    else
                    {
                        if (!user.Password.Equals(password))
                        {
                            strErrors = Languages.Languages.MsgPasswordIsIncorrect;
                            //Linh.Tran_220912: Add to check the times to login failed
                            AccountController.User.UserModelList[index].LoginFailedTimes++;
                            //if (UserController.User.UserModelList[index].LoginFailedTimes >= 5)
                            //{
                            //    UserController.User.UserModelList[index].IsLocked = true;
                            //    SaveUserAccount();
                            //    strErrors += "\r\n" + Languages.AccountHasBeenLocked + ". " + Languages.PleaseContactAdministratorToUnlock;
                            //}
                            //else
                            //{
                            //    strErrors += "\r\n" + String.Format(Languages.LoginRemainingXTimes, (5 - UserController.User.UserModelList[index].LoginFailedTimes));
                            //}
                            //End Linh.Tran_220912: Add to check the times to login failed
                        }
                        else
                        {
                            _DefaultUserLoginFailedTimes = 0;//Linh.Tran_220912: Add to logined failed times
                            LoginUser = user;
                            //
                        }
                    }
                }
                #endregion//End Creater user
            }
            if (strErrors != "")
            {
                LoginUser = null;
            }
            else
            {
                LogedInUserName = LoginUser.UserName;
            }
            return strErrors;
        }

        /// <summary>
        /// Linh.Tran_230811
        /// API: Login
        /// Method: POST
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string APILogin(string userName, string password)
        {
            string strErrors = "";
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "StaffInfo/Login";
                string requestUrl = String.Format("{0}/{1}",
                                                  serverURL, //0
                                                  pathUrl//1

                                                  );
                //
                try
                {
                    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    //
                    APILoginModel.Params postData = new APILoginModel.Params()
                    {
                        UserName = userName,
                        Password = password
                    };
                    //
                    using (var stream = request.GetRequestStream())
                    {
                        var mstream = new System.IO.MemoryStream();
                        var ser = new DataContractJsonSerializer(typeof(APILoginModel.Params));
                        ser.WriteObject(mstream, postData);
                        byte[] json = mstream.ToArray();
#if DEBUG
                        string strJson = Encoding.UTF8.GetString(json, 0, json.Length);
#endif
                        //
                        //Linh.Tran_230814: Low speed
                        //string strResponseData = Newtonsoft.Json.JsonConvert.SerializeObject(postData);
                        //byte[] json = Encoding.UTF8.GetBytes(strResponseData);
                        //End Linh.Tran_230814: Low speed
                        stream.Write(json, 0, json.Length);
                    }
                    //
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                            throw new Exception(String.Format(
                            "Server error (HTTP {0}: {1}).",
                            response.StatusCode,
                            response.StatusDescription));
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APILoginModel.Root));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        APILoginModel.Root jsonResponse
                        = objResponse as APILoginModel.Root;
                        //ShareFunction.SaveHistory(InternalLanguage.USBKey + ": " + usbKey, InternalLanguage.Login, "", UserController.LogedInUsername, 
                        //    LoggingType.Info, false);
                        //
                        if(jsonResponse.success)
                        {
                            LoginUser = new AccountItemModel()
                            {
                                UserName = jsonResponse.data.UserName,
                                Password = password,
                                PermissionLevel = PermissionLevelArr[3],//Linh.Tran_220912: Add default permission to Operator => Level 4
                                SaveTime = DateTime.Now
                            };
                            LogedInUserName = LoginUser.UserName;
                            LoginUserOnline = jsonResponse;
                            strErrors = "";
                        }
                        else
                        {
                            strErrors = jsonResponse.errcode + ": " + jsonResponse.error;
                        }
                    }
                }
                catch (Exception e)
                {
                    //ShareFunction.SaveHistory(InternalLanguage.Error + "-" + InternalLanguage.Login, InternalLanguage.API, e.Message, 
                    //    UserController.LogedInUsername, LoggingType.Info, false);
                    strErrors = Languages.Languages.ServerIsNotResponse;
                }
            }
            catch (Exception ex)
            {
                strErrors = ex.Message;
            }
            return strErrors;
        }

        public static bool Logout()
        {
            try
            {
                //Write logs
                ML.LoggingControls.Controller.LoggingController.AddHistory(Languages.Languages.Account,
                Languages.Languages.Logout + " " + Languages.Languages.Account,
                Languages.Languages.Logout + " " + Languages.Languages.Success
                + ". \r\n"
                + Languages.Languages.Informations + ":"
                + Languages.Languages.Username + "-" + AccountController.LoginUser.UserName,
                AccountController.LoginUser.UserName,
                ML.LoggingControls.Model.LoggingType.Info);
                //
                //Reset Accounts
                LoginUser = null;
                LoginUserInfoOnline = null;
                LoginUserOnline = null;
                LogedInUserName = "";
                //End Reset Accounts
                //
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Linh.Tran_230811
        /// API: Get info by Username
        /// Method: GET
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APIGetUserNameInfoModel.Root APIGetUserNameInfo(string userName)
        {
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "StaffInfo/GetInfoByUserName";
                string requestUrl = String.Format("{0}/{1}?UserName={2}",
                                                  serverURL, //0
                                                  pathUrl,//1
                                                  userName//2
                                                  );
                //
                try
                {
                    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                    request.Method = "GET";
                    //
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                            throw new Exception(String.Format(
                            "Server error (HTTP {0}: {1}).",
                            response.StatusCode,
                            response.StatusDescription));
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIGetUserNameInfoModel.Root));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        APIGetUserNameInfoModel.Root jsonResponse
                        = objResponse as APIGetUserNameInfoModel.Root;
                        //ShareFunction.SaveHistory(InternalLanguage.USBKey + ": " + usbKey, InternalLanguage.Login, "", UserController.LogedInUsername, 
                        //    LoggingType.Info, false);
                        return jsonResponse;
                    }
                }
                catch (Exception e)
                {
                    //ShareFunction.SaveHistory(InternalLanguage.Error + "-" + InternalLanguage.Login, InternalLanguage.API, e.Message, 
                    //    UserController.LogedInUsername, LoggingType.Info, false);
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool CheckPermission(FunctionsEnum function)
        {
            if(!AccountController.Settings.IsUserOn)
            {
                return true;
            }
            //
            if (LoginUser != null)
            {
                if (LoginUser.UserName.Equals(DefaultUser) || LoginUser.UserName.Equals(DefaultVIPUser))//Linh.Tran_221122: Fix errors Administrator and Support have full permission not follow group permission
                {
                    return true;
                }
                else if (LoginUser.FunctionsList.Contains(function))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ChangePasswordUser(String username, String newPassword)
        {
            try
            {
                if (DefaultUser.Equals(username))
                {
                    #region Linh.Tran_230917: Default user name - Administrator
                    //Read Default password
                    string encryptPass = AccountSecurityController.Encrypt(newPassword, username);
                    AccountSecurityController.WriteRegistry(username, encryptPass);
                    DefaultUserPassword = newPassword;
                    #endregion//End Linh.Tran_230917: Default user name- Administrator
                }
                else
                {
                    //Linh.Tran_230608: Get data
                    int userIndex = AccountController.User.UserModelList.FindIndex(u => u.UserName.Equals(username));
                    AccountController.User.UserModelList[userIndex].Password = newPassword;
                    AccountController.User.UserModelList[userIndex].SaveTime = DateTime.Now;
                    //End Linh.Tran_230608: Get data
                    //
                    String path = AccountController.UserPath;
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    path += "user.xml";
                    AccountController.User.SaveSettings(path);
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                //Linh.Tran_220912: Add Administrator accounts
                if (AccountController.LoginUser.UserName.Equals(AccountController.DefaultVIPUser))
                {
                    //
                }
                //End Linh.Tran_220912: Add Administrator accounts
            }
            return true;
        }

        /// <summary>
        /// Linh.Tran_220912: Add status
        /// </summary>
        /// <param name="username"></param>
        /// <param name="isLocked"></param>
        /// <returns></returns>
        public static bool ChangeStatusDefaultUser(String username, bool isLocked)
        {
            string strTemp = username + "status";
            String encryptStatus = AccountSecurityController.Encrypt(isLocked.ToString(), strTemp);
            AccountSecurityController.WriteRegistry(strTemp, encryptStatus);
            //
            DefaultUserIsLocked = isLocked;//Linh.Tran_220912
            return true;
        }

        public static AccountItemModel GetUserAccount(String username)
        {
            if(username.Equals(DefaultVIPUser))//Linh.Tran_221011
            {
                return new AccountItemModel()
                {
                    UserName = DefaultVIPUser,
                    Password = DefaultVIPPassword,
                    PermissionLevel = PermissionLevelArr[0],//Linh.Tran_220912: Add to permission to highest permission => Level 1
                    SaveTime = DateTime.Now
                };
            }
            else
            {
                var first = AccountController.User.UserModelList.Where(u => u.UserName == username).FirstOrDefault();
                if (first != null)
                {
                    return (AccountItemModel)first;
                }
                return new AccountItemModel();
            }
        }

        public static PermissionItemModel GetPermission(String permissionLevel)
        {
            var pModel = AccountController.Permission.PermissionList.Where(p => p.PermissionLevel == permissionLevel).FirstOrDefault();
            if(pModel!=null)
            {
                return (PermissionItemModel)pModel;
            }
            return null;
        }

        #region Load - Save User/Permission
        public static void InitAccount(string path,string rootRegistry, string swName, string swVersion, string linkAPI)
        {
            UserPath = path;
            SWName = swName;
            SWVersion = swVersion;
            LinkAPI = linkAPI;
            AccountSecurityController.SubPath = rootRegistry;
            //
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            //Init User Accounts
            if (!File.Exists(path))
            {
                //
            }
            else
            {
                //AccountController.User = AccountModel.LoadSetting(path);
                AccountController.User = AccountModel.LoadSetting(path);
            }
            //End Init User Accounts

            #region Init Permission Accounts
            path = AccountController.UserPath + "permission.xml";
            if (!File.Exists(path))
            {
                Permission.PermissionList = new List<PermissionItemModel>();//Linh.Tran_220912: Reset permission list
                //Director
                Permission.PermissionList.Add(new PermissionItemModel()
                {
                    PermissionLevel = PermissionLevelArr[0],//"Level_1",
                    PermissionName = "Manager", //"Director",
                    FunctionsList = new List<FunctionsEnum>() { FunctionsEnum.Design, //0
                                                                FunctionsEnum.Setting, //1
                                                                FunctionsEnum.Viewlog, //2
                                                                FunctionsEnum.Update, //3
                                                                FunctionsEnum.Account, //4
                                                                FunctionsEnum.Controls,//5
                                                                FunctionsEnum.SyncData//6
                    }
                });

                //Manager
                Permission.PermissionList.Add(new PermissionItemModel()
                {
                    PermissionLevel = PermissionLevelArr[1],//"Level_2",
                    PermissionName = "Operator",//"Manager",
                    FunctionsList = new List<FunctionsEnum>() { //FunctionsEnum.Design, //0
                                                                //FunctionsEnum.Setting, //1
                                                                FunctionsEnum.Viewlog, //2
                                                                //FunctionsEnum.Update, //3
                                                                //FunctionsEnum.Account, //4
                                                                FunctionsEnum.Controls ,//5
                                                                FunctionsEnum.SyncData//6
                    }//5
                });

                //Operator
                Permission.PermissionList.Add(new PermissionItemModel()
                {
                    PermissionLevel = PermissionLevelArr[2],//"Level_4",
                    PermissionName = "Normal",//"Supervisor",
                    FunctionsList = new List<FunctionsEnum>() { FunctionsEnum.Design, //0
                                                                //FunctionsEnum.Setting, //1
                                                                FunctionsEnum.Viewlog, //2
                                                                //FunctionsEnum.Update, //3
                                                                //FunctionsEnum.Account, //4
                                                                //FunctionsEnum.Controls. //5
                                                                FunctionsEnum.SyncData//6
                    }
                });

                //Normal
                Permission.PermissionList.Add(new PermissionItemModel()
                {
                    PermissionLevel = PermissionLevelArr[3],//"Level_5",
                    PermissionName = "Operator",
                    FunctionsList = new List<FunctionsEnum>() { //FunctionsEnum.Design, //0
                                                                //FunctionsEnum.Setting, //1
                                                                //FunctionsEnum.Viewlog, //2
                                                                //FunctionsEnum.Update, //3
                                                                //FunctionsEnum.Account, //4
                                                                FunctionsEnum.Controls, //5
                                                                //FunctionsEnum.SyncData//6
                    }
                });
                //SavePermissionAccount();//Linh.Tran_230917: Command
            }
            else
            {
                LoadPermissionAccount();
            }
            #endregion //End Init Permission Accounts
        }

        public static void LoadUserAccount()
        {
            try
            {
                //String path = settingsPath + "Settings\\";
                String path = AccountController.UserPath;
                path += "user.xml";

                //AccountController.User = AccountModel.LoadSetting(path);
                AccountController.User = AccountModel.LoadSetting(path);
            }
            catch
            {
                AccountController.User = new AccountModel();
            }
            //
            //Linh.Tran_220111: Load user with Administrator account
            if (AccountController.LoginUser != null)
            {
                if (AccountController.LoginUser.UserName.Equals(AccountController.DefaultVIPUser))
                {
                    //
                }
            }
            //End Linh.Tran_220111: Load user with Administrator acount
            //
        }

        public static void SaveUserAccount()
        {
            try
            {
                //
                String path = AccountController.UserPath;
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path += "user.xml";
                AccountController.User.SaveSettings(path);
            }
            catch
            {

            }
            finally
            {
                //Linh.Tran_220912: Add Administrator accounts
                if (AccountController.LoginUser.UserName.Equals(AccountController.DefaultVIPUser))
                {
                    //
                }
                //End Linh.Tran_220912: Add Administrator accounts
            }
        }

        public static void LoadPermissionAccount()
        {
            try
            {
                //String path = settingsPath + "Settings\\";
                String path = AccountController.UserPath;
                path += "permission.xml";

                AccountController.Permission = PermissionModel.LoadSetting(path);
            }
            catch
            {
                AccountController.Permission = new PermissionModel();
            }
        }

        public static void SavePermissionAccount()
        {
            try
            {
                String path = AccountController.UserPath;
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path += "permission.xml";
                AccountController.Permission.SaveSettings(path);
            }
            catch { }
        }

        public static void LoadAccountSettings()
        {
            try
            {
                //String path = settingsPath + "Settings\\";
                String path = AccountController.UserPath;
                path += "usersettings.xml";

                AccountController.Settings =AccountSettingModel.LoadSetting(path);
            }
            catch
            {
                AccountController.Settings = new AccountSettingModel();
            }
            //
            //Linh.Tran_220111: Load user with Administrator account
            if (AccountController.LoginUser != null)
            {
                if (AccountController.LoginUser.UserName.Equals(AccountController.DefaultVIPUser))
                {
                    //
                }
            }
            //End Linh.Tran_220111: Load user with Administrator acount
            //
        }

        public static void SaveAccountSettings()
        {
            try
            {
                //
                String path = AccountController.UserPath;
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path += "usersettings.xml";
                //
                if (!AccountController.Settings.IsRememberUsrer)
                {
                    AccountController.Settings.UserNameOnline =
                    AccountController.Settings.PassWordOnline = "";
                }
                //
                AccountController.Settings.SaveSettings(path);
            }
            catch
            {

            }
            finally
            {
                //
            }
        }
        #endregion//End Load - Save User/Permission
    }
}
