using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Diagnostics;

namespace ML.APIServices
{
    public class APIController
    {
        private static string LinkAPI = "";//"http://tijprogrammer.net:8081";

        public static APIReModeLoginCls ReModeLogin (string usbKey, string clientrequestkey)
        {
            try
            {
                string ServerURL = LinkAPI;
                String PathUrl = "requestdata/remotelogin";
                String privateKey = "mlg_priv";
                string eUsbkey = Uri.EscapeDataString(AES256GCMController.EncryptString(usbKey));
                string eClientrequestkey = Uri.EscapeDataString(AES256GCMController.EncryptString(clientrequestkey));
                APIReModeLoginCls response = makerequest_remote_login_to_server(String.Format("{0}/{1}?usbkey={2}&clientrequestkey={3}",
                                                                                        ServerURL,//0
                                                                                        PathUrl, //1
                                                                                        eUsbkey,//2
                                                                                        eClientrequestkey//3
                                                                                        ), usbKey);
                //Decode
                foreach (var prop in response.GetType().GetProperties())
                {
                    var values = AES256GCMController.DecryptString(prop.GetValue(response, null).ToString());
                    prop.SetValue(response, values, null);
                }
                //End of Decode
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static APIGetCodeCls GetCodeData(string usbkey, string clientrequestkey, string user, int datacount, List<string> lotList, List<string> inktypeList, string privatelabel, int bulkinkid)
        {
            try
            {
                string ServerURL = LinkAPI;
                String PathUrl = "requestdata/getcode";
                //
                string eLot = "";
                foreach(string str  in lotList)
                {
                    eLot += Uri.EscapeDataString(AES256GCMController.EncryptString(str)) + ",";
                }
                //
                string einktype = "";
                foreach (string ink in inktypeList)
                {
                    einktype += Uri.EscapeDataString(AES256GCMController.EncryptString((ink).ToString())) + ",";
                }
                string eUsbkey = Uri.EscapeDataString(AES256GCMController.EncryptString(usbkey));
                string eUser = Uri.EscapeDataString(AES256GCMController.EncryptString(user));
                string eDatacount = Uri.EscapeDataString(AES256GCMController.EncryptString(datacount.ToString()));
                string eClientrequestkey = Uri.EscapeDataString(AES256GCMController.EncryptString(clientrequestkey));
                string eprivatelabel = Uri.EscapeDataString(AES256GCMController.EncryptString(privatelabel));
                string ebulkinkid = Uri.EscapeDataString(AES256GCMController.EncryptString(bulkinkid.ToString()));
                APIGetCodeCls respose = makerequest_get_code_data(String.Format("{0}/{1}?usbkey={2}&clientrequestkey={6}&user={3}&datacount={4}&lot={5}&inktype={9}&label={7}&bulkinkid={8}",
                                                                                      ServerURL,//0
                                                                                      PathUrl,//1
                                                                                      eUsbkey,//2
                                                                                      eUser,//3
                                                                                      eDatacount.ToString(),//4
                                                                                      eLot,//5
                                                                                      eClientrequestkey,//6
                                                                                      eprivatelabel,//7
                                                                                      ebulkinkid,//8
                                                                                      einktype//9
                                                                                      ));
                //Decode
                foreach (var prop in respose.GetType().GetProperties())
                {
                    //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(respose, null));
                    if (prop.Name.ToLower() == "data")
                    {
                        foreach (APIGetCodeItemCls item in respose.Data)
                        {
                            //Get data
                            foreach (var subprop in item.GetType().GetProperties())
                            {
                                var subvalues = AES256GCMController.DecryptString(subprop.GetValue(item, null).ToString());
                                subprop.SetValue(item, subvalues, null);
                            }

                        }
                    }
                    else
                    {
                        var values = AES256GCMController.DecryptString(prop.GetValue(respose, null).ToString());
                        prop.SetValue(respose, values, null);
                    }
                }
                //End of Decode
                return respose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static APIUpdateResultCls UpdateStatus(string usbkey, string clientrequestkey, string user, int datacount, List<string> lotList, List<string> resultList)
        {
            try
            {
                string ServerURL = LinkAPI;
                String PathUrl = "requestdata/updatestatus";
                //
                string eLot = "";
                foreach (string str in lotList)
                {
                    eLot += Uri.EscapeDataString(AES256GCMController.EncryptString(str)) + ",";
                }
                //
                string eResult = "";
                foreach (string r in resultList)
                {
                    eResult += Uri.EscapeDataString(AES256GCMController.EncryptString((r).ToString())) + ",";
                }
                string eUsbkey = Uri.EscapeDataString(AES256GCMController.EncryptString(usbkey));
                string eUser = Uri.EscapeDataString(AES256GCMController.EncryptString(user));
                string eDatacount = Uri.EscapeDataString(AES256GCMController.EncryptString(datacount.ToString()));
                string eClientrequestkey = Uri.EscapeDataString(AES256GCMController.EncryptString(clientrequestkey));
                APIUpdateResultCls respose = makerequest_send_result(String.Format("{0}/{1}?usbkey={2}&clientrequestkey={7}&datacount={4}&lot={5}&status={6}",
                                                                                      ServerURL,//0
                                                                                      PathUrl,//1
                                                                                      eUsbkey,//2
                                                                                      eUser,//3
                                                                                      eDatacount.ToString(),//4
                                                                                      eLot,//5
                                                                                      eResult,//6
                                                                                      eClientrequestkey//7
                                                                                      ));

                //Decode
                foreach (var prop in respose.GetType().GetProperties())
                {
                    //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(respose, null));
                    if (prop.Name.ToLower() == "data")
                    {
                        foreach (APIUpdateResultItemCls item in respose.Data)
                        {
                            //Get data
                            foreach (var subprop in item.GetType().GetProperties())
                            {
                                var subvalues = AES256GCMController.DecryptString(subprop.GetValue(item, null).ToString());
                                subprop.SetValue(item, subvalues, null);
                            }
                        }
                    }
                    else
                    {
                        var values = AES256GCMController.DecryptString(prop.GetValue(respose, null).ToString());
                        prop.SetValue(respose, values, null);
                    }
                }
                //End of Decode
                return respose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static APIGetHistoryDataCls GetHistoryData(string usbkey, 
                                                          string clientrequestkey, 
                                                          DateTime from, DateTime to, 
                                                          List<string> logsTypeList,
                                                          string trackingby)
        {
            try
            {
                string ServerURL = LinkAPI;
                String PathUrl = "requestdata/gethistorydata";
                //
                string eLogsType = "";
                foreach (string logs in logsTypeList)
                {
                    eLogsType += Uri.EscapeDataString(AES256GCMController.EncryptString((logs).ToString())) + ",";
                }
                //Encode
                string eUsbkey = Uri.EscapeDataString(AES256GCMController.EncryptString(usbkey));
                string eFrom = Uri.EscapeDataString(AES256GCMController.EncryptString(from.ToString("yyyyMMdd000000")));
                string eTo = Uri.EscapeDataString(AES256GCMController.EncryptString(to.ToString("yyyyMMdd235959")));
                string eClientrequestkey = Uri.EscapeDataString(AES256GCMController.EncryptString(clientrequestkey));
                string eTrackingBy = Uri.EscapeDataString(AES256GCMController.EncryptString((trackingby).ToString()));
                //
                APIGetHistoryDataCls respose = makerequest_get_data_history(String.Format("{0}/{1}?usbkey={2}&clientrequestkey={6}&from={3}&to={4}&status={5}&tracking={7}",
                                                                                      ServerURL,//0
                                                                                      PathUrl,//1
                                                                                      eUsbkey,//2
                                                                                      eFrom,//3//from.ToString("yyyyMMddHHmmss"),//3
                                                                                      eTo,//4//to.ToString("yyyyMMddHHmmss"),//4
                                                                                      eLogsType,//5
                                                                                      eClientrequestkey,//6
                                                                                      eTrackingBy//7
                                                                                      ),
                                                                                      from, to);
                //Decode
                foreach (var prop in respose.GetType().GetProperties())
                {
                    //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(respose, null));
                    if (prop.Name.ToLower() == "data")
                    {
                        foreach (APIGetHistoryDataItemCls item in respose.Data)
                        {
                            //Get data
                            foreach (var subprop in item.GetType().GetProperties())
                            {
                                var subvalues = AES256GCMController.DecryptString(subprop.GetValue(item, null).ToString());
                                subprop.SetValue(item, subvalues, null);
                            }
                        }
                    }
                    else
                    {
                        var values = AES256GCMController.DecryptString(prop.GetValue(respose, null).ToString());
                        prop.SetValue(respose, values, null);
                    }
                }
                return respose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Private methods
        private static APIReModeLoginCls makerequest_remote_login_to_server(String requestUrl, string usbKey)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIReModeLoginCls));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    APIReModeLoginCls jsonResponse
                    = objResponse as APIReModeLoginCls;
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
        private static APIGetCodeCls makerequest_get_code_data(String requestUrl)
        {
            try
            {
                
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIGetCodeCls));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    APIGetCodeCls jsonResponse
                    = objResponse as APIGetCodeCls;
                    //ShareFunction.SaveHistory(InternalLanguage.RequestCodeDataToWebServer, InternalLanguage.API, 
                    //    InternalLanguage.GetCodeData, UserController.LogedInUsername, LoggingType.Info, false);
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                //Save history
                //ShareFunction.SaveHistory(InternalLanguage.Error + "-" + InternalLanguage.GetCodeData, InternalLanguage.API, e.Message,
                //    UserController.LogedInUsername, LoggingType.Info, false);
                return null;
            }
        }
        private static APIUpdateResultCls makerequest_send_result(String requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIUpdateResultCls));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    APIUpdateResultCls jsonResponse
                    = objResponse as APIUpdateResultCls;
                    //ShareFunction.SaveHistory("", InternalLanguage.API, InternalLanguage.SendProgramStatus, UserController.LogedInUsername, LoggingType.Info, false);
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                //ShareFunction.SaveHistory(InternalLanguage.Error + "-" + InternalLanguage.SendProgramStatus, InternalLanguage.API, e.Message, 
                //    UserController.LogedInUsername, LoggingType.Info, false);
                return null;
            }
        }
        private static APIGetHistoryDataCls makerequest_get_data_history(String requestUrl, DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(APIGetHistoryDataCls));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    APIGetHistoryDataCls jsonResponse
                    = objResponse as APIGetHistoryDataCls;
                    //ShareFunction.SaveHistory(String.Format(InternalLanguage.MsgFrom0To1, dateFrom, dateTo), InternalLanguage.API, 
                    //    InternalLanguage.RequestDataHistory, UserController.LogedInUsername, LoggingType.Info, false);
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                //ShareFunction.SaveHistory(InternalLanguage.Error + "-" + InternalLanguage.RequestDataHistory, InternalLanguage.API, e.Message,
                //    UserController.LogedInUsername, LoggingType.Info, false);
                return null;
            }
        }
        #endregion//Ket thuc Private methods
    }
}
