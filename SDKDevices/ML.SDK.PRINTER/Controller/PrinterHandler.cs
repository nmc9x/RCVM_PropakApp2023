using ML.Common.Controller;
using ML.Connections.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.SDK.PRINTER.Controller
{
    public class PrinterHandler : SocketClient
    {
        #region Declaration
        //private string _IP;
        //private string _Port;
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
        #endregion
        public PrinterHandler(string ip, string port, int socketIndex)
        {
            _IP = ip;
            _Port = port;
            _SocketIndex = socketIndex;

#if DEBUG
            Console.WriteLine($"Printer IP: {_IP}, Port: {_Port}, SocketIndex: {_SocketIndex}");
#endif

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

            //_ThreadListenPrintedPage = new Thread(ListenData);
            //_ThreadListenPrintedPage.Start();

        }

        private void ListenAndCompareData()
        {
            try
            {
                var filePath = "C:\\Users\\minhchau.nguyen\\Documents\\MyLanGroup\\Projects\\Propak\\output.csv";
                var db = File.ReadAllLines(filePath).Skip(1).ToArray();
                while (true)
                {
                    CommonFunctions.GetFromMemoryFile("mmf_CurrentCodeData_" + _SocketIndex, 20, out string codeStr, out _);
                    if (codeStr != null)
                    {
#if DEBUG
                        //Console.WriteLine("Start Compare");
#endif
                        CompareData(db, codeStr);
                    }

                    Thread.Sleep(1);
                }
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
            string newSts = "0", oldSts = "0", curSts = "0";
            try
            {
                while (true)
                {
                    // Check Start
                    CommonFunctions.GetFromMemoryFile("mmf_StartProcess_" + _SocketIndex, 1, out string res1, out _);
                    if (res1 != null)
                    {
                        newSts = res1;
                    }
                    if (newSts != oldSts)
                    {
                        curSts = newSts;
                        oldSts = curSts;
                        Console.WriteLine("Sts :" + curSts);
                        if (curSts == "1")
                        {
                            StartAndSendDataToPrinter();
                        }
                        else
                        {
                            StopPrint();
                        }
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

        public async void StartAndSendDataToPrinter()
        {
            await StartAndLoadData();
            //Thread ListenData and Compare with Db
            var threadListenAndCompareData = new Thread(ListenAndCompareData)
            {
                IsBackground = true
            };
            threadListenAndCompareData.Start();
        }
        public async void StopPrint()
        {
            await StopPrinting();
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

        public override bool Connect()
        {
            try
            {
                _Client = new TcpClient(_IP, int.Parse(_Port));
                _Stream = _Client.GetStream();
#if DEBUG
                Console.WriteLine("Connected");
#endif
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Connected fail" + ex.Message);
#endif
                return false;
            }
        }
        public override async Task Send(string message)
        {
            try
            {
                if (_Stream == null)
                    throw new InvalidOperationException("Not connected to server.");
                byte[] data = Encoding.ASCII.GetBytes((char)2 + message + (char)3);
                _Stream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent Data: {message}");
                await Task.Delay(100);
            }
            catch (Exception ex)
            {

#if DEBUG
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif

            }

        }

        public override string Receive()
        {
            try
            {
                if (_Stream == null)
                    throw new InvalidOperationException("Not connected to server.");
                byte[] data = new byte[1024];
                int bytes = _Stream.Read(data, 0, data.Length);
                var receivedMessage = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine($"Received: {receivedMessage}");
                return receivedMessage;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif
                return null;
            }

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
                    var receivedMess = Receive();
                    var donePrintStr = (char)2 + "RSFP" + (char)3;
                    if (receivedMess != null && receivedMess == donePrintStr)
                    {
#if DEBUG
                        Console.WriteLine("Printed Page: "+countPrintedPage++);
#endif
                    }
                    Thread.Sleep(1);
                }
                catch (Exception) { }
            }
        }

        public override async Task StartAndLoadData()
        {
            try
            {
                countPrintedPage = 0;
                //SocketClient client = new SocketClient("192.168.15.154", 12500);
                var filePath = "C:\\Users\\minhchau.nguyen\\Documents\\MyLanGroup\\Projects\\Propak\\output.csv";
                string[] tableData = File.ReadAllLines(filePath).Skip(1).ToArray(); // skip header

                string command;
                string readySts = (char)2 + "RYES" + (char)3 + (char)2 + "STAR;READY" + (char)3;
                Connect();
                //if (Connect())
                //{
                //_ThreadListenPrintedPage = new Thread(ListenData);
                //_ThreadListenPrintedPage.Start();

                #region ConnectAsync
                bool isReady = false;
                while (!isReady)
                {
                    await Send("STAR;TestTemplate;1;1");
                    if (Receive() == readySts)
                    {
                        isReady = true;
                        _ThreadListenPrintedPage = new Thread(ListenDataFeedback);
                        _ThreadListenPrintedPage.Start();
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                }
                #endregion

                #region ProcessData
                Console.WriteLine("Start send data...");
                for (int i = 0; i < tableData.Length; i++)
                {
                    string formattedData = CsvParser.ParseLine(tableData[i]);
                    command = "DATA;" + formattedData;
                    await Send(command);
                }
                // Disconnect();

                #endregion
                //}

            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif
            }

        }

        public void CompareData(string[] sourceData, string sampleData = "ITLCD_OLD1162", int colIndex = 2)
        {
            try
            {
                var uniqueData = new HashSet<string>();
                var duplicateData = new HashSet<string>();
                var unknownData = new HashSet<string>();
                foreach (string data in sourceData)
                {
                    var col = data.Split(',');
                    var currentValue = col[colIndex].TrimStart('"').TrimEnd('"');

                    if (currentValue == sampleData)
                    {
                        if (!uniqueData.Add(currentValue))
                        {
                            duplicateData.Add(currentValue);
                        }
                    }
                    else
                    {
                        unknownData.Add(currentValue);
                    }
                }
                string verifyCode = "";
                if (duplicateData.Count == 0 && unknownData.Count == 0)
                {
                    // good
                    verifyCode = "0";
                    Console.WriteLine("Good");
                }
                else if (duplicateData.Count == 1 && unknownData.Count == 0)
                {
                    // duplicateData
                    verifyCode = "1";
                    Console.WriteLine("Fail: Dulicate");
                }
                else if (duplicateData.Count == 0 && unknownData.Count == 1)
                {
                    // unknown
                    verifyCode = "2";
                    Console.WriteLine("Fail: Unknown");
                }
                CommonFunctions.SetToMemoryFile("mmf_VerifyCheckCode"+_SocketIndex, 1, verifyCode);
              
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif
            }
        }


        public override async Task StopPrinting()
        {
            Connect();
            await Send("STOP");
            Disconnect();
        }
        public override void Disconnect()
        {
            _Stream?.Close();
            _Client?.Close();
            Console.WriteLine($"Disconnected from {_IP}:{_Port}");
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
                var mmf = new MemoryMapHelper("mmf_connectStatus_printer"+_SocketIndex + _SocketIndex, 1);
                mmf.WriteData(Encoding.ASCII.GetBytes(_ConnectionStatus.ToString()),0);
                //CommonFunctions.SetToMemoryFile("mmf_connectStatus_printer" + _SocketIndex, 1, _ConnectionStatus.ToString());
                var printerConnSts = PingIP();
                if (printerConnSts == IPStatus.Success)
                {
                    newConnectedSts = 1;
                }
                else
                {
                    newConnectedSts = 3;
                }
                if (oldConnectionSts != newConnectedSts)
                {
                    _ConnectionStatus = newConnectedSts;
                    
                    mmf.WriteData(Encoding.ASCII.GetBytes(_ConnectionStatus.ToString()), 0);
                    // CommonFunctions.SetToMemoryFile("mmf_connectStatus_printer" + _SocketIndex, 1, _ConnectionStatus.ToString());
                }
                Thread.Sleep(1000);
            }
        }
    }
}
