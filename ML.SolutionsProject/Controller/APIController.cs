using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Diagnostics;
using ML.SolutionsProject.Model;

namespace ML.SolutionsProject.Controller
{
    public class APIController
    {
        public static string LinkAPI = "";//"http://tijprogrammer.net:8081";

        /// <summary>
        /// Linh.Tran_230811
        /// API: Login
        /// Method: POST
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APILoginModel.Root APILogin_BK(string userName, string password)
        {
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "StaffInfo/Login";
                string requestUrl = String.Format("{0}/{1}?UserName={2}&Password={3}",
                                                  serverURL, //0
                                                  pathUrl,//1
                                                  userName,//2
                                                  password//3
                                                  );
                //
                try
                {
                    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                    request.Method = "POST";
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

        /// <summary>
        /// Linh.Tran_230811
        /// API: Login
        /// Method: POST
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APILoginModel.Root APILogin(string userName, string password)
        {
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

        /// <summary>
        /// Linh.Tran_230811
        /// API: Get Agent info: Agent 1: 0; Agent 2: 1
        /// Method: POST
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APIGetAgentInforByConditionModel.Root APIGetAgentInfo(int agentLevel,
                                                                       int page=1,
                                                                       int pageLimit=9999)
        {
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "Agent/GetByCondition";
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
                    APIGetAgentInforByConditionModel.Params postData = new APIGetAgentInforByConditionModel.Params()
                    {
                        AgentLevel = agentLevel,
                        Page = page,
                        PageLimit = pageLimit
                    };
                    //
                    using (var stream = request.GetRequestStream())
                    {
                        var mstream = new System.IO.MemoryStream();
                        var ser = new DataContractJsonSerializer(typeof(APIGetAgentInforByConditionModel.Params));
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
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIGetAgentInforByConditionModel.Root));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        //
                        APIGetAgentInforByConditionModel.Root jsonResponse
                        = objResponse as APIGetAgentInforByConditionModel.Root;
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

        /// <summary>
        /// Linh.Tran_230811
        /// API: Active serial Product - Update barcode
        /// Method: POST
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APIActiveSerialProductModel.Root APIActiveSerialProduct(string pBarData,
                                                                              DateTime? packingDate,
                                                                              DateTime? expirationDate,
                                                                              string lotCode)
        {
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "Barcode/UpdateBarcode";
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
                    APIActiveSerialProductModel.Params postData = new APIActiveSerialProductModel.Params()
                    {
                        PBarData = pBarData,
                        PackingDate = packingDate == null? "": ((DateTime)packingDate).ToString("yyyy/MM/dd"),
                        ExpirationDate = expirationDate == null ? "" : ((DateTime)expirationDate).ToString("yyyy/MM/dd"),
                        LotCode = lotCode
                    };
                    //
                    using (var stream = request.GetRequestStream())
                    {
                        var mstream = new System.IO.MemoryStream();
                        var ser = new DataContractJsonSerializer(typeof(APIActiveSerialProductModel.Params));
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
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIActiveSerialProductModel.Root));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        APIActiveSerialProductModel.Root jsonResponse
                        = objResponse as APIActiveSerialProductModel.Root;
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

        /// <summary>
        /// Linh.Tran_230811
        /// API: InsAgentProduct - Update barcode
        /// Method: POST
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APIInsertAgentProductModel.Root APInsertAgentProduct(string agentCodeFrom,
                                                                            string agentCode,
                                                                            string proCode,
                                                                            DateTime? distributorDate,
                                                                            int distributorCount,
                                                                            string createdBy_UserCode)
        {
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "AgentManager/InsAgentProduct";
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
                    string jsonDataValues = "";
                    using (var mstreamValues = new System.IO.MemoryStream())
                    {
                        APIInsertAgentProductModel.ParamsDataValues postDataValues = (new APIInsertAgentProductModel.ParamsDataValues()
                        {
                            AgentCodeFrom = agentCodeFrom,
                            AgentCode = agentCode,
                            ProCode = proCode,
                            DistributorDate = distributorDate == null ? "" : ((DateTime)distributorDate).ToString("yyyy/MM/dd"),
                            DistributorCount = distributorCount,
                            CreatedBy = createdBy_UserCode,
                        });
                        //
                        var ser = new DataContractJsonSerializer(typeof(APIInsertAgentProductModel.ParamsDataValues));
                        ser.WriteObject(mstreamValues, postDataValues);
                        byte[] json = mstreamValues.ToArray();
                        jsonDataValues = Encoding.UTF8.GetString(json, 0, json.Length);
                    }
                    //
                    APIInsertAgentProductModel.Params postData = new APIInsertAgentProductModel.Params()
                    {
                        Data = jsonDataValues
                    };
                    //
                    using (var stream = request.GetRequestStream())
                    {
                        var mstream = new System.IO.MemoryStream();
                        var ser = new DataContractJsonSerializer(typeof(APIInsertAgentProductModel.Params));
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
                        mstream.Close();
                    }
                    //
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                            throw new Exception(String.Format(
                            "Server error (HTTP {0}: {1}).",
                            response.StatusCode,
                            response.StatusDescription));
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIInsertAgentProductModel.Root));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        APIInsertAgentProductModel.Root jsonResponse
                        = objResponse as APIInsertAgentProductModel.Root;
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

        /// <summary>
        /// Linh.Tran_230811
        /// API: InsDistributorAndActive - Update barcode
        /// Method: POST
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APIInsertDistributorAndActiveModel.Root APIInsertDistributorAndActive(string idagentproduct,
                                                                            string barData,
                                                                            string lotCode,
                                                                            DateTime packingDate,
                                                                            DateTime expirationDate,
                                                                            string createdBy_UserCode)
        {
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "AgentManager/InsDistributorAndActive";
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
                    string jsonDataValues = "";
                    using (var mstreamValues = new System.IO.MemoryStream())
                    {
                        APIInsertDistributorAndActiveModel.ParamsDataValues postDataValues = (new APIInsertDistributorAndActiveModel.ParamsDataValues()
                        {
                            _idagentproduct = idagentproduct,
                            BarData = barData,
                            CreatedBy = createdBy_UserCode,
                            LotCode = lotCode,
                            PackingDate = (packingDate ==null)? "": packingDate.ToString("yyyy/MM/dd"),
                            ExpirationDate = (expirationDate == null) ? "" : expirationDate.ToString("yyyy/MM/dd"),
                        });
                        //
                        var ser = new DataContractJsonSerializer(typeof(APIInsertDistributorAndActiveModel.ParamsDataValues));
                        ser.WriteObject(mstreamValues, postDataValues);
                        byte[] json = mstreamValues.ToArray();
                        jsonDataValues = Encoding.UTF8.GetString(json, 0, json.Length);
                    }
                    //
                    APIInsertDistributorAndActiveModel.Params postData = new APIInsertDistributorAndActiveModel.Params()
                    {
                        Data = jsonDataValues
                    };
                    //
                    using (var stream = request.GetRequestStream())
                    {
                        var mstream = new System.IO.MemoryStream();
                        var ser = new DataContractJsonSerializer(typeof(APIInsertDistributorAndActiveModel.Params));
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
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIInsertDistributorAndActiveModel.Root));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        APIInsertDistributorAndActiveModel.Root jsonResponse
                        = objResponse as APIInsertDistributorAndActiveModel.Root;
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

        /// <summary>
        /// Linh.Tran_230811
        /// API: Get product info
        /// Method: GET
        /// sortName = "PDateCreate" - Default values
        /// sortType = -1
        /// page = 1
        /// pageLimit = 1000
        /// branchCode = "DCM002"
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static APIGetProductInfoModel.Root APIGetProductInfo(int notSumBarcode = 1,//3
                                                                     int sortType = -1,//4
                                                                     int page = 1,//5
                                                                     int pageLimit = 1000,//6
                                                                     string  branchCode = "DCM002",//7
                                                                     string sortName = "PDateCreate"//2
                                                                        )
        {
            try
            {
                string serverURL = LinkAPI;
                string pathUrl = "Product/GetByCondition";
                string requestUrl = String.Format("{0}/{1}?SortName={2}&NotSumBarcode={3}SortType={4}&Page={5}&PageLimit={6}&BranchCode={7}",
                                                  serverURL, //0
                                                  pathUrl,//1
                                                  sortName,//2
                                                  notSumBarcode,//3
                                                  sortType,//4
                                                  page,//5
                                                  pageLimit,//6
                                                  branchCode//7
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
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIGetProductInfoModel.Root));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        APIGetProductInfoModel.Root jsonResponse
                        = objResponse as APIGetProductInfoModel.Root;
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

    }
}
