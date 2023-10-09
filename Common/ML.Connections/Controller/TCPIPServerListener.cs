using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ML.Connections.Controller
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class TCPIPServerListener : MainListener
    {
        private TcpListener _Server = null;
        private TcpClient _Client = null;//Linh.Tran_200713
        private NetworkStream _Stream;
        private StreamReader _Reader = null;
        private StreamWriter _Writer = null;

        public TCPIPServerListener()
        {
            //
        }

        /// <summary>
        /// Linh.Tran: Add to CRLF
        /// On 190725
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Port"></param>
        /// <param name="StartPackage"></param>
        /// <param name="EndPackage"></param>
        /// <param name="SplitChar"></param>
        /// <param name="MyEncoding"></param>
        /// <param name="CheckHeaderData"></param>
        /// <param name="IsCRLF"></param>
        public TCPIPServerListener(String ip, int port, int dataLength = 1024, int delayTimeToSendMessage = 1, bool isSendStringData = false)
        {
            _IP = ip;
            _Port = port;
            _DataLength = dataLength;
            _DelayTimeToSendMessage = 1;
            _IsSendStringData = isSendStringData;
        }

        public override bool CheckAlive()
        {
            //return true;
            //Linh.Tran_200713: Check Alive TCP/IP
            if (_Client != null && _Client.Client.Connected)
            {
                try
                {
                    //client.Client.Send(new byte[1] { 0xf0 });//send to test connection
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
            //End Linh.Tran_200713: Check Alive TCP/IP
        }

        public override bool CheckConnections()
        {
            //return true;
            //Linh.Tran_200713: Check Alive TCP/IP
            if (_Server != null)
            {
                try
                {
                    //client.Client.Send(new byte[1] { 0xf0 });//send to test connection
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
            //End Linh.Tran_200713: Check Alive TCP/IP
        }

        public override bool Connect()
        {
            try
            {
                InitListenter();
                //
                IPAddress address = IPAddress.Parse(_IP);
                _Server = new TcpListener(address, _Port);
                //_Server = new TcpListener(IPAddress.Any, _Port);
                _Server.Start();
                //
                Thread threadTCP = new Thread(TCPIPServerListenning);
                threadTCP.IsBackground = true;
                threadTCP.Priority = ThreadPriority.Highest;
                threadTCP.Start();
                //
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override bool Disconnect()
        {
            try
            {
                if (_Stream != null)
                {
                    _Stream.Close();
                    _Stream = null;
                }
                //Linh.Tran_200713
                if (_Client != null)
                {
                    _Client.Close();
                    _Client = null;
                }
                //End Linh.Tran_200713
                if (_Server != null)
                {
                    _Server.Stop();
                    _Server = null;
                }
            }
            catch { }
            finally
            {
            }
            return true;
        }

        private void TCPIPServerListenning()
        {
            try
            {
                int countData = 0;
                Byte[] bytesReceived = new Byte[_DataLength];
                String data = "";
                while (true)//Linh.Tran_200713
                {
                    _Client = null;//Linh.Tran_200727: Fix errors sometime client status alway connected
                    _Client = _Server.AcceptTcpClient();
                    _Stream = _Client.GetStream();
                    while (true)
                    {
                        _Reader = new StreamReader(_Stream);
                        _Writer = new StreamWriter(_Stream);
                        _Writer.AutoFlush = true;
                        int countRead = 0;
                        try
                        {
                            if (_Client.Client.Connected)
                            {
                                if (_CRLF)
                                {
                                    data = _Reader.ReadLine();//Linh.Tran: Add on 190725
                                }
                                else
                                {
                                    countRead = _Stream.Read(bytesReceived, 0, bytesReceived.Length);
                                    //Linh.Tran_200727: Add to TCPIP disconnected - Fix errors sometime client status alway connected
                                    if (countRead <= 0)
                                    {
                                        break;
                                    }
                                    //End Linh.Tran_200727: Add to TCPIP disconnected - Fix errors sometime client status alway connected
                                    data = _Encoding.GetString(bytesReceived, 0, countRead);
                                }
                                //
                                if (data != "")
                                {
#if DEBUG
                                    countData++;
                                    Console.WriteLine("countData: " + countData.ToString());
#endif
                                    //this.ProcessMessage(data);//Linh.Tran_210902: Command: Fix errors mis packages
                                    //
                                    //Linh.Tran_210902: Update fix errors miss Packages
                                    Thread threadTemp = new Thread(() => this.ProccessReceivedMessage(bytesReceived.Take(countRead).ToArray()));
                                    threadTemp.IsBackground = true;
                                    threadTemp.Start();
                                    //End Linh.Tran_210902: Update fix errors miss Packages
                                }
                            }
                            else
                            {
                                _Stream = _Client.GetStream();
                            }
                        }
                        catch (Exception ex)
                        {
                            //break;
                        }
                        //else
                        //{ break; }
                        Thread.Sleep(1);//Linh.Tran_210902
                    }
                    Thread.Sleep(1);//Linh.Tran_200713
                }//Linh.Tran_200713
            }
            catch
            {
            }
        }

        public override bool Send(byte[] data)
        {
            if (_Stream != null && _Stream.CanWrite)
            {
                _Writer.BaseStream.Write(data, 0, data.Length);
            }
            else
            {
                return false;

            }
            return true;
        }

        /// Linh.Tran: Update to Send data with CRLF
        /// On 190725
        public override bool Send(string data)
        {
            try
            {
                if (_Stream != null && _Stream.CanWrite)
                {
                    //Linh.Tran: Add to have CRLF - on 190725
                    if (_CRLF)//Co CRLF
                    {
                        _Writer.WriteLine(data);//Linh.Tran: Update on 190723 - Khong chay voi \r\n
                    }
                    else
                    {
                        _Writer.Write(data);//Linh.Tran: Update on 190723 - Khong chay voi \r\n
                    }
                    //Linh.Tran: End of Add to have CRLF - on 190725
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Linh.Tran_210927
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public override bool SenDataPackage(string str)
        {
            return true;
        }
    }
}
