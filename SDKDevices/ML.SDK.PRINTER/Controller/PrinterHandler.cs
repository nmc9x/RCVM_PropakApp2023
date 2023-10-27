﻿using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using ML.Common.Controller;
using ML.Connections.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.SDK.PRINTER.Controller
{
    public class PrinterHandler : SocketClient
    {
        #region Declaration

        private int _SocketIndex;
        private MainListener _PrinterListener;

        private SocketClient _SockClient;
        private TcpClient _Client;
        private NetworkStream _Stream;
        private readonly string _IP;
        private readonly string _Port;


        private Thread _ThreadDeviceStatusChecking = null;
        private Thread _ThreadListenPrintedPage = null;

        private int _ConnectionStatus = 0;
        private int countPrintedPage = 0;

        private int goodCount = 0;
        private int failCount = 0;
        private int totalCount = 0;
        private MemoryMapHelper mmfCamCounting;
        private MemoryMapHelper mmfCountPrintedPage;
        private MemoryMapHelper mmf_classifyCode;
        private MemoryMapHelper mmf_TemplateName;
        private MemoryMapHelper mmf_DBFilePath;
        private MemoryMapHelper mmf_ResetDataOption;
        private TcpClientHelper _TcpClient;
        private static bool isStopPress;
        private Thread threadSendStart;
        private Thread threadListenAndCompareData;
        private readonly int _sendIntervalMilliseconds = 1000; // Thời gian giữa các lần gửi tin (1 giây)
        private string _ReceivedMessage;
        private string tempStr = "";
        private string _TemplateName;
        byte startPackage = 0x02;
        byte endPackage = 0x03;
        private StringBuilder buffer = new StringBuilder();
        #endregion
        public PrinterHandler(string ip, string port, int socketIndex)
        {

            _IP = ip;
            _Port = port;
            _SocketIndex = socketIndex;
#if DEBUG
            Console.WriteLine($"Printer IP: {_IP}, Port: {_Port}");
#endif

            mmfCamCounting = new MemoryMapHelper("mmf_VerifyCheckCode" + _SocketIndex, 20);
            mmfCountPrintedPage = new MemoryMapHelper("mmf_PrintedPage" + _SocketIndex, 5);
            mmf_classifyCode = new MemoryMapHelper("mmf_CheckCodeFlag" + _SocketIndex, 1);
            mmf_TemplateName = new MemoryMapHelper("mmf_TemplateName" + _SocketIndex, 100);
            mmf_DBFilePath = new MemoryMapHelper("mmf_DBFilePath" + _SocketIndex, 260);
            mmf_ResetDataOption = new MemoryMapHelper("mmf_ResetDataOption" +_SocketIndex, 1);

            try
            {
                _TcpClient = new TcpClientHelper(ip, int.Parse(port), 100);
                _TcpClient.MessageReceived += _TcpClient_MessageReceived;
            }
            catch (Exception)
            {
#if DEBUG
                // Console.WriteLine($"Printer IP not found !");
#endif
                _ConnectionStatus = 0;
                var mmf = new MemoryMapHelper("mmf_connectStatus_printer" + _SocketIndex, 1);
                mmf.WriteData(Encoding.ASCII.GetBytes(_ConnectionStatus.ToString()), 0);
                return;
            }
            finally
            {
                _ThreadListenPrintedPage = new Thread(ListenDataFeedback);
                _ThreadListenPrintedPage.Start();


                //Thread checking status
                _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking)
                {
                    Name = "CheckStsDeviceThread",
                    IsBackground = true,
                    Priority = ThreadPriority.Highest
                };
                _ThreadDeviceStatusChecking.Start();


                //Thread Listen Config via MMF
                var threadListenUIAction = new Thread(ListenUIACtion)
                {
                    IsBackground = true
                };
                threadListenUIAction.Start();

                //Thread get and update template
                var threadUpdateTemplate = new Thread(GetTemplate)
                {
                    IsBackground = true
                };
                threadUpdateTemplate.Start();

                //Thread reset data
                var threadResetData = new Thread(ResetData)
                {
                    IsBackground = true
                };
                threadResetData.Start();

            }

            

        }

        
        #region TCP
        private void _TcpClient_MessageReceived(string obj)
        {
            _ReceivedMessage = null;
            buffer.Append(obj);

            while (true)
            {
                int startIndex = buffer.ToString().IndexOf(Convert.ToChar(startPackage).ToString());
                int endIndex = buffer.ToString().IndexOf(Convert.ToChar(endPackage).ToString());

                if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
                {
                    string command = buffer.ToString().Substring(startIndex + 
                        Convert.ToChar(startPackage).ToString().Length, endIndex - 
                        (startIndex + Convert.ToChar(startPackage).ToString().Length));
                    _ReceivedMessage = command;
                    if(_ReceivedMessage != null && _ReceivedMessage.Contains("RSFP"))
                    {
                        Console.WriteLine("Printed page: " + countPrintedPage++);
                    }

#if DEBUG
                    Console.WriteLine("MEss Received: " + command);
#endif

                    buffer.Remove(startIndex, (endIndex - startIndex) +
                        Convert.ToChar(endPackage).ToString().Length);
                }
                else
                {
                    break;
                }
#if DEBUG
                //Console.WriteLine("tempStr: "+ tempStr);
#endif


#if DEBUG
                // Console.WriteLine("Recived MEssage: " + _ReceivedMessage.ToString());
#endif
            }
        }

        private void _TcpClient_SendMessage(string message)
        {
            Console.WriteLine("Mess Send: " + message);
            _TcpClient.Send(message);
        }
        #endregion


        #region Get Template
        public void SaveTemplateList(string data)
        {

            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MLSolutions";
            string filePath = Path.Combine(directoryPath, "Template" + _SocketIndex + ".txt");
            try
            {
                Directory.CreateDirectory(directoryPath);
                File.WriteAllText(filePath, data);

#if DEBUG
                if (data.Length > 0)
                {
                    Console.WriteLine("Done save template !");
                }
                else
                {
                    Console.WriteLine("Fail save template, No data found !");
                }
#endif

            }
            catch (Exception)
            {
#if DEBUG
                Console.WriteLine("Fail save template !");
#endif
            }
        }
        private void GetTemplate()
        {
            try
            {
                while (true)
                {

                    var mmf = new MemoryMapHelper("mmf_UpdateTemplate" + _SocketIndex, 1);
                    var state = Encoding.ASCII.GetString(mmf.ReadData(0, 1));
                    if (state == "1")
                    {
                        _TcpClient_SendMessage((char)2 + "RQLI" + (char)3);
                        Thread.Sleep(200);
                        SaveTemplateList(_ReceivedMessage);
                    }
                    mmf.WriteData(new byte[1] { 0 }, 0); // change another value
                    Thread.Sleep(1);
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("Loi Gưi TemPlate: "+ ex.Message);
            }
        }
        #endregion

        #region Data Processing
        private void ListenUIACtion()
        {

            try
            {
                bool isStart = false;
                while (true)
                {
                    // Check Start
                    var mmf = new MemoryMapHelper("mmf_StartProcess_" + _SocketIndex, 1);
                    var res1 = Encoding.ASCII.GetString(mmf.ReadData(0, 1));
                    if (res1 == "1" && !isStart)
                    {
                        isStart = true;
                        mmf.WriteData(new byte[1] { 2 }, 0); // change another value
#if DEBUG
                        //Console.WriteLine("Start Print ...");
#endif  
                        StartAndSendData();
                    }

                    if (res1 == "0")
                    {
                        isStart = false;
                        mmf.WriteData(new byte[1] { 2 }, 0);
#if DEBUG
                        // Console.WriteLine("Stop Print ...");
#endif
                        StopPrint();
                    }

                    // Check Save 
                    var mmf_Save = new MemoryMapHelper("mmf_Save", 1);
                    var saveState = Encoding.ASCII.GetString(mmf_Save.ReadData(0, 1));

                    if (saveState == Encoding.ASCII.GetString(new byte[1] { 1}))
                    {
#if DEBUG
                        Console.WriteLine("Start Thread Compare Data !");
#endif
                        mmf_Save.WriteData(new byte[] { 2 }, 0); // change state

                        threadListenAndCompareData?.Abort();

                        threadListenAndCompareData = new Thread(ListenAndCompareData)
                        {
                            IsBackground = true
                        };
                        threadListenAndCompareData.Start();
                    }
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ListenUIACtion: " + ex.Message);
#endif
            }
        }


        private void StartAndSendData()
        {
            threadSendStart?.Abort(); // Abort the previous thread
            try
            {
                countPrintedPage = 0;
                var path = Encoding.ASCII.GetString(mmf_DBFilePath.ReadData(0, 260)).Trim('\0');
#if DEBUG
                Console.WriteLine("File Path: " + @path);
#endif

                var filePath = @path;//"C:\\Users\\minhchau.nguyen\\Documents\\MyLanGroup\\Projects\\Propak\\output.csv";
                string[] tableData = File.ReadAllLines(filePath).Skip(1).ToArray(); // skip header

                string command;
                //string readySts1 = (char)2 + "RYES" + (char)3 + (char)2 + "STAR;READY" + (char)3;
                //string readySts2 = (char)2 + "STAR;READY" + (char)3;
                string readySts1 = "RYES" + "STAR;READY";
                string readySts2 = "STAR;READY";

                #region ConnectAsync
                bool isReady = false;
                isStopPress = false;
                threadSendStart = new Thread(() =>
                {
                    while (!isReady)
                    {
                        var templateName = Encoding.ASCII.GetString(mmf_TemplateName.ReadData(0, 100));
#if DEBUG
                        Console.WriteLine("Template seleted: " + templateName);
#endif
                        if (!isStopPress)
                        {
                            _TcpClient_SendMessage((char)2 + "STAR;" + templateName + ";1;1" + (char)3);
                        }
                        if ((_ReceivedMessage == readySts1 || _ReceivedMessage == readySts2) && !isStopPress)
                        {

                            isReady = true;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                        Thread.Sleep(1);
                    }
                    #region ProcessData
                    Thread.Sleep(2000);
                    for (int i = 0; i < tableData.Length; i++)
                    {
                        string formattedData = CsvParser.ParseLine(tableData[i]);
                        command = (char)2 + "DATA;" + formattedData + (char)3;
                        _TcpClient_SendMessage(command);
                        Thread.Sleep(20);
                    }
                    #endregion
                });
                threadSendStart.Start();
                #endregion



            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("StartAndSendData: " + ex.Message);
#endif
            }
        }
        public void CompareData(string[] sourceData, string sampleData = "", int colIndex = 0)
        {
            try
            {
                var uniqueData = new HashSet<string>();
                var duplicateData = new HashSet<string>();
                var unknownData = new HashSet<string>();
                var checkCodeFlag = 0;
                foreach (string data in sourceData)
                {
                    var col = data.Split(',');
                    var currentValue = col[colIndex].TrimStart('"').TrimEnd('"');

                    if (currentValue == sampleData)
                    {
                        if (!uniqueData.Add(currentValue))
                        {
                            duplicateData.Add(currentValue);
                            uniqueData.Remove(currentValue);
                        }
                    }
                }

                if ((duplicateData.Count == 0 && uniqueData.Count == 0) || (duplicateData.Count > 0))
                {
                    failCount++;
                    checkCodeFlag = 1;
                }
                if (uniqueData.Count > 0)
                {
                    goodCount++;
                    checkCodeFlag = 2;
                }
                totalCount++;

                mmf_classifyCode.WriteData(Encoding.ASCII.GetBytes(checkCodeFlag.ToString()), 0);
                Console.WriteLine("Count Print:" + "Good: " + goodCount.ToString() + "Fail: " + failCount.ToString());
                mmfCamCounting.WriteData(
                    Encoding.ASCII.GetBytes(
                    goodCount.ToString() + 
                    "-" + 
                    failCount.ToString() + 
                    "-" +
                    totalCount.ToString()), 0);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif
            }
        }
       
        private void ResetData()
        {
#if DEBUG
           // Console.WriteLine("Listen for Reset Data");
#endif
            try
            {
                while (true)
                {
                    var byteRes = mmf_ResetDataOption.ReadData(0, 1);
                    var a = Encoding.ASCII.GetString(byteRes).Trim('\0');
                    int option = 0;
                    try
                    {
                        option = int.Parse(a);
                    }
                    catch (Exception)
                    {
                        option = 0;
                    }
                    switch(option)
                    {
                        case 1: // Reset Total
                            totalCount = 0;
#if DEBUG
                            Console.WriteLine("Done delete total count !");
#endif
                            break;
                        case 3: // Reset Printed
                            countPrintedPage = 0;
#if DEBUG
                            Console.WriteLine("Done delete printed count !");
#endif
                            break;

                        case 2: // Reset Good
                            goodCount = 0;
#if DEBUG
                            Console.WriteLine("Done delete good count !");
#endif
                            break;

                        case 4: // Reset Fail
                            failCount = 0;
#if DEBUG
                            Console.WriteLine("Done delete fail count !");
#endif
                            break;

                        case 5: // Reset All
                            totalCount =
                            countPrintedPage =
                            goodCount =
                            failCount = 0;
#if DEBUG
                            Console.WriteLine("Done delete all count !");
#endif
                            break;
                        default:
                            break;
                    }
                    mmf_ResetDataOption.WriteData(Encoding.ASCII.GetBytes("0"), 0);
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ResetData Fail: " + ex.Message);
#endif
            }
           
        }
        private void ListenAndCompareData()
        {
            try
            {
                var mmf_DBFilePath = new MemoryMapHelper("mmf_DBFilePath" + _SocketIndex, 260);
                var mmf_PODIndex = new MemoryMapHelper("mmf_PODIndex" + _SocketIndex, 2); // max 20
                var mmfCodeData = new MemoryMapHelper("mmf_CurrentCodeData_" + _SocketIndex, 100);

                var emtyStr = Encoding.ASCII.GetString(new byte[100]);
                var filePath = Encoding.ASCII.GetString(mmf_DBFilePath.ReadData(0, 260)).Trim('\0');
                var podIndex = Encoding.ASCII.GetString(mmf_PODIndex.ReadData(0, 2)).Trim('\0');
                var db = File.ReadAllLines(filePath).Skip(1).ToArray();
#if DEBUG
                Console.WriteLine("Start Listen And Compare Data !");
                Console.WriteLine("Database Path: "+ filePath);
                Console.WriteLine("POD Index seleted: " + podIndex);
#endif
                while (true)
                {
                    var stringRes = Encoding.ASCII.GetString(mmfCodeData.ReadData(0, 100));
                    if (stringRes != null && stringRes != emtyStr)
                    {
                        Console.WriteLine(stringRes + stringRes.Length);
                        CompareData(db, stringRes.Trim('\0'), int.Parse(podIndex));
                    }
                    mmfCodeData.WriteData(new byte[100], 0);
                    Thread.Sleep(1);
                }
            }

            catch (Exception ex)
            {

#if DEBUG
                Console.WriteLine("ListenAndCompareData Fail:" + ex.Message);
#endif
            }
        }
        public void ListenDataFeedback()
        {
            while (true)
            {
                try
                {
#if DEBUG

#endif
                    var donePrintStr = "RSFP";
                    if (_ReceivedMessage != null && _ReceivedMessage.Contains(donePrintStr))
                    {
                        mmfCountPrintedPage.WriteData(Encoding.ASCII.GetBytes(countPrintedPage.ToString()), 0);
#if DEBUG
                        // Console.WriteLine("Printed Page: " + countPrintedPage);
#endif
                    }
                    Thread.Sleep(1);
                }
                catch (Exception) { }
            }
        }
        public void StopPrint()
        {
            isStopPress = true;
            _TcpClient_SendMessage((char)2 + "STOP" + (char)3);
        }
        #endregion

        #region Status Checking
        private IPStatus PingIP()
        {
            try
            {
                var myPing = new Ping();
                var reply = myPing.Send(_IP);
                if (reply != null)
                {
#if DEBUG
                    //Console.WriteLine("PingIP Printer :  " +
                    //    reply.Status + ", Time : " +
                    //    reply.RoundtripTime.ToString() + ", Address : " +
                    //    reply.Address + ", Reconnect...");
#endif
                    return reply.Status;
                }
            }
            catch
            {
#if DEBUG
                //  Console.WriteLine($"Printer PingIP ERROR : {_IP}");
#endif
            }
            return IPStatus.Unknown;
        }
        private void DeviceStatusChecking()
        {
            int oldConnectionSts;
            int newConnectedSts;

            while (true)
            {
                oldConnectionSts = _ConnectionStatus;
                var mmf = new MemoryMapHelper("mmf_connectStatus_printer" + _SocketIndex, 1);
                mmf.WriteData(Encoding.ASCII.GetBytes(_ConnectionStatus.ToString()), 0);
                var printerConnSts = PingIP();
                if (printerConnSts == IPStatus.Success)
                {
                    newConnectedSts = 1;
                }
                else
                {
                    newConnectedSts = 3;
                }
                mmf.WriteData(Encoding.ASCII.GetBytes(_ConnectionStatus.ToString()), 0);
                if (oldConnectionSts != newConnectedSts)
                {
                    _ConnectionStatus = newConnectedSts;

                    mmf.WriteData(Encoding.ASCII.GetBytes(_ConnectionStatus.ToString()), 0);
#if DEBUG
                    string connSts = _ConnectionStatus == 1 ? "Conneted" : "Disconnected";
                    Console.WriteLine($"Printer Status: {connSts}");
#endif
                }

                Thread.Sleep(1000);
            }
        }
        #endregion

        private void _PrinterListener_ReceiveDataEvent(object sender, EventArgs e)
        {

        }
    }
}
