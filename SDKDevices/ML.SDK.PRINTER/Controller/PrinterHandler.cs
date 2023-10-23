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
    public class PrinterHandler: SocketClient
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
        private MemoryMapHelper mmfCamCounting;
        private MemoryMapHelper mmfCountPrintedPage;
        private MemoryMapHelper mmf_classifyCode;
        private TcpClientHelper _TcpClient;
        private readonly int _sendIntervalMilliseconds = 1000; // Thời gian giữa các lần gửi tin (1 giây)
        private string _ReceivedMessage;
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
            mmf_classifyCode = new MemoryMapHelper("mmf_CheckCodeFlag"+_SocketIndex, 1);

            try
            {
                _TcpClient = new TcpClientHelper(ip, int.Parse(port), 100);
                _TcpClient.MessageReceived += _TcpClient_MessageReceived;
            }
            catch (Exception)
            {
#if DEBUG
                Console.WriteLine($"Printer IP not found !");
#endif
                _ConnectionStatus = 0;
                var mmf = new MemoryMapHelper("mmf_connectStatus_printer" + _SocketIndex, 1);
                mmf.WriteData(Encoding.ASCII.GetBytes(_ConnectionStatus.ToString()), 0);
                return;
            }



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



            //End Thread checking status

            //Thread Listen Config via MMF
            var threadListenUIAction = new Thread(ListenUIACtion)
            {
                IsBackground = true
            };
            threadListenUIAction.Start();

         

           
        }

        private void _TcpClient_MessageReceived(string obj)
        {
            _ReceivedMessage = obj;
            Console.WriteLine(_ReceivedMessage);
        }
        private void _TcpClient_SendMessage(string message)
        {
            Console.WriteLine("Mess Send: " + message);
            _TcpClient.Send(message);
        }
        private void ListenAndCompareData()
        {
            try
            {
                var emtyStr = Encoding.ASCII.GetString(new byte[100]);
                var mmf_DBFilePath = new MemoryMapHelper("mmf_DBFilePath"+ _SocketIndex, 260);
                var mmf_PODIndex = new MemoryMapHelper("mmf_PODIndex" + _SocketIndex, 2); // max 20
                var filePath = Encoding.ASCII.GetString(mmf_DBFilePath.ReadData(0, 260)).Trim('\0');
                var podIndex = Encoding.ASCII.GetString(mmf_PODIndex.ReadData(0, 2)).Trim('\0');
                
                var db = File.ReadAllLines(filePath).Skip(1).ToArray();
                var mmfCodeData = new MemoryMapHelper("mmf_CurrentCodeData_" + _SocketIndex, 100);
                while (true)
                {
                    var stringRes = Encoding.ASCII.GetString(mmfCodeData.ReadData(0, 100));
                    if (stringRes != null && stringRes != emtyStr)
                    {
                        Console.WriteLine(stringRes + stringRes.Length);
                        CompareData(db, stringRes.Trim('\0'),int.Parse(podIndex));
                    }
                    mmfCodeData.WriteData(new byte[100], 0);
                    Thread.Sleep(1);
                }
            }
            catch (FileNotFoundException)
            {
               //
            }
            catch (Exception ex)
            {

#if DEBUG
                Console.WriteLine("Fail :" + ex.Message);
#endif
            }
        }

        private void ListenUIACtion()
        {

            try
            {
                while (true)
                {
                    // Check Start
                    var mmf = new MemoryMapHelper("mmf_StartProcess_" + _SocketIndex, 1);
                    var res1 = Encoding.ASCII.GetString(mmf.ReadData(0, 1));


                    if (res1 == "1")
                    {
                        mmf.WriteData(new byte[1] { 2 }, 0); // change another value
#if DEBUG
                        //Console.WriteLine("Start Print ...");
#endif
                        var threadListenAndCompareData = new Thread(ListenAndCompareData)
                        {
                            IsBackground = true
                        };
                        threadListenAndCompareData.Start();

                        StartAndSenData();

                    }
                    if (res1 == "0")
                    {
                        mmf.WriteData(new byte[1] { 2 }, 0);
#if DEBUG
                        // Console.WriteLine("Stop Print ...");
#endif
                        StopPrint();


                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ListenUIACtion" + ex.Message);
#endif
            }
        }

        private static bool isStopPress;
        private Thread threadSendStart;
        void StartAndSenData()
        {
            threadSendStart?.Abort(); // Abort the previous thread
            try
            {
                countPrintedPage = 0;
                var filePath = "C:\\Users\\minhchau.nguyen\\Documents\\MyLanGroup\\Projects\\Propak\\output.csv";
                string[] tableData = File.ReadAllLines(filePath).Skip(1).ToArray(); // skip header

                string command;
                string readySts1 = (char)2 + "RYES" + (char)3 + (char)2 + "STAR;READY" + (char)3;
                string readySts2 = (char)2 + "STAR;READY" + (char)3;

                #region ConnectAsync
                bool isReady = false;
                isStopPress = false;
                threadSendStart = new Thread(() =>
                {
                    while (!isReady)
                    {

                        if (!isStopPress)
                        {
                            _TcpClient_SendMessage((char)2 + "STAR;TestTemplate;1;1" + (char)3);
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
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif
            }
        }
        public void StopPrint()
        {
            isStopPress = true;
            _TcpClient_SendMessage((char)2 + "STOP" + (char)3);
        }
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
                Console.WriteLine($"Printer PingIP ERROR : {_IP}");
#endif
            }
            return IPStatus.Unknown;
        }

        public void ListenDataFeedback()
        {
            while (true)
            {
                try
                {
#if DEBUG
                    //Console.WriteLine("Start Listenning");
#endif

                    var donePrintStr = (char)2 + "RSFP" + (char)3;
                    if (_ReceivedMessage != null && _ReceivedMessage == donePrintStr)
                    {
                        countPrintedPage++;
                        mmfCountPrintedPage.WriteData(Encoding.ASCII.GetBytes(countPrintedPage.ToString()), 0);
#if DEBUG
                        Console.WriteLine("Printed Page: " + countPrintedPage);
#endif
                        _ReceivedMessage = "";
                    }
                    Thread.Sleep(1000);
                }
                catch (Exception) { }
            }
        }
        public static int CheckCodeOccurrences(string filePath, string code)
        {
            var codeOccurrences = new Dictionary<string, int>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(','); // Giả sử rằng bạn sử dụng dấu phẩy làm dấu phân tách

                    foreach (var value in values)
                    {
                        if (codeOccurrences.ContainsKey(value))
                        {
                            codeOccurrences[value]++;
                        }
                        else
                        {
                            codeOccurrences[value] = 1;
                        }
                    }
                }
            }

            return codeOccurrences.ContainsKey(code) ? codeOccurrences[code] : 0;
        }

        public void CompareData(string[] sourceData, string sampleData = "CY170EQ0109", int colIndex = 2)
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
                
                //if (duplicateData.Count > 0)
                //{
                //    //Fail: duplicate
                //    failCount++;
                //    checkCodeFlag = 1;
                //}
                if ((duplicateData.Count == 0 && uniqueData.Count == 0) || (duplicateData.Count > 0))
                {
                    //Fail: Unknow data
                    failCount++;
                    checkCodeFlag = 1;
                }
                if (uniqueData.Count > 0)
                {
                    //good count
                    goodCount++;
                    checkCodeFlag = 2;
                }
                mmf_classifyCode.WriteData(Encoding.ASCII.GetBytes(checkCodeFlag.ToString()), 0);
                Console.WriteLine("Count Print:" + "Good: " + goodCount.ToString() + "Fail: " + failCount.ToString());
                mmfCamCounting.WriteData(Encoding.ASCII.GetBytes(goodCount.ToString() + "-" + failCount.ToString()), 0);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif
            }
        }


       


        private void _PrinterListener_ReceiveDataEvent(object sender, EventArgs e)
        {

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

      
    }
}
