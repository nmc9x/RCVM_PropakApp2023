using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.Connections.Controller
{
    public abstract class MainListener
    {
        #region Properties
        #region TCPIP
        protected string _IP = "127.0.0.1";
        protected int _Port = 80;
        protected int _DataLength = 1024;
        #endregion//End TCPIP

        #region COM
        protected string _COMPortName = "COM1";
        protected int _Baudrate = 115200;
        protected int _DataBits =  1;
        protected Parity _Parity = Parity.None;
        protected StopBits _StopBits = StopBits.None;
        protected bool _DtrEnable = false;
        protected List<string> _ListAvoidCOM = new List<string>();
        #endregion COM

        protected bool _IsSendStringData = false;
        /// <summary>
        /// Delay time to send messages, unit ms
        /// </summary>
        protected int _DelayTimeToSendMessage = 1;
        protected bool _CRLF = false;
        protected Encoding _Encoding = Encoding.UTF8;
        protected List<Tuple<string, char>> _SpecialCharacterList = new List<Tuple<string, char>> {
                                                                    new Tuple<string, char>("<STX>", '\u0002'),
                                                                    new Tuple<string, char>("<ETX>", '\u0003'),
                                                                    new Tuple<string, char>("<CR>", '\u000D'),
                                                                    new Tuple<string, char>("<LF>", '\u000A'),
                                                                    new Tuple<string, char>("<RS>", '\u000E'),
                                                                    new Tuple<string, char>("<NL>", '\u0015'),
                                                                    new Tuple<string, char>("<VT>", '\u000B'),
                                                                    new Tuple<string, char>("<FF>", '\u00FF'),
                                                                    new Tuple<string, char>("<LS>", '\u2028'),
                                                                    new Tuple<string, char>("<PS>", '\u2029')};

        protected System.Collections.Concurrent.ConcurrentQueue<byte[]> MessageBufferReceivedArr = new System.Collections.Concurrent.ConcurrentQueue<byte[]>();

        protected System.Collections.Concurrent.ConcurrentQueue<byte[]> MessageBufferSendByteArr = new System.Collections.Concurrent.ConcurrentQueue<byte[]>();

        protected System.Collections.Concurrent.ConcurrentQueue<string> MessageBufferSendStrArr = new System.Collections.Concurrent.ConcurrentQueue<string>(); 
        #endregion//End Properties

        #region Events
        public event EventHandler ReceiveDataEvent;
        #endregion//End Events

        #region Methods
        #region Received messages
        protected void InitListenter()
        {
            //
            Thread threadProccessExcMessage = new Thread(ProccessExcMessage);
            threadProccessExcMessage.IsBackground = true;
            threadProccessExcMessage.Priority = ThreadPriority.Highest;
            threadProccessExcMessage.Start();
            //
            //
            //
            if (_IsSendStringData)
            {
                Thread threadProccessSendMessage = new Thread(ProccessSendMessageStr);
                threadProccessSendMessage.IsBackground = true;
                threadProccessSendMessage.Priority = ThreadPriority.Highest;
                threadProccessSendMessage.Start();
            }
            else
            {
                Thread threadProccessSendMessage = new Thread(ProccessSendMessageByte);
                threadProccessSendMessage.IsBackground = true;
                threadProccessSendMessage.Priority = ThreadPriority.Highest;
                threadProccessSendMessage.Start();
            }
            //
        }

        protected void ProccessReceivedMessage(byte[] message)
        {
            MessageBufferReceivedArr.Enqueue(message);
        }

        protected void ProccessExcMessage()
        {
            while (true)
            {
                if (MessageBufferReceivedArr.Count > 0)
                {
                    try
                    {
                        byte[] resultBytes = null;
                        MessageBufferReceivedArr.TryDequeue(out resultBytes);
                        //
                        if(ReceiveDataEvent!=null)
                        {
                            ReceiveDataEvent(resultBytes,EventArgs.Empty);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }
                }
                System.Threading.Thread.Sleep(1);
            }
        }
        #endregion//End Received messages

        #region Send messages
        protected void ProccessSendMessageStr()
        {
            while (true)
            {
                if (MessageBufferReceivedArr.Count > 0)
                {
                    try
                    {
                        string resultBytes = null;
                        MessageBufferSendStrArr.TryDequeue(out resultBytes);
                        Send(resultBytes);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }
                }
                System.Threading.Thread.Sleep(_DelayTimeToSendMessage);
            }

        }

        protected void ProccessSendMessageByte()
        {
            while (true)
            {
                if (MessageBufferReceivedArr.Count > 0)
                {
                    try
                    {
                        byte[] resultBytes = null;
                        MessageBufferSendByteArr.TryDequeue(out resultBytes);
                        Send(resultBytes);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }
                }
                System.Threading.Thread.Sleep(_DelayTimeToSendMessage);
            }
        }

        public void SendMessages(string strData)
        {
            MessageBufferSendStrArr.Enqueue(strData);
        }

        public void SendMessages(byte[] byteData)
        {
            MessageBufferSendByteArr.Enqueue(byteData);
        }
        #endregion//end Send messages

        public string ReplaceSpecialString(string str)
        {
            //https://en.wikipedia.org/wiki/Newline
            //Update driver
            //https://thegeekpage.com/update-driver-using-command-prompt/
            //https://www.thewindowsclub.com/update-drivers-using-command-prompt
            foreach (Tuple<string, char> t in _SpecialCharacterList)
            {
                str = str.Replace(t.Item1, t.Item2.ToString());
            }
            return str;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public byte[][] Split(byte[] input, byte separator, bool ignoreEmptyEntries = false)
        {
            var subArrays = new List<byte[]>();
            var start = 0;
            for (var i = 0; i <= input.Length; ++i)
            {
                if (input.Length == i || input[i] == separator)
                {
                    if (i - start > 0 || ignoreEmptyEntries)
                    {
                        var destination = new byte[i - start];
                        Array.Copy(input, start, destination, 0, i - start);
                        subArrays.Add(destination);
                    }
                    start = i + 1;
                }
            }
            return subArrays.ToArray();
        }

        #endregion//End Methods

        #region Astract methods
        /// <summary>
        /// Call the connection to server
        /// </summary>
        /// <returns></returns>
        public abstract bool Connect();

        /// <summary>
        /// Close current connection
        /// </summary>
        /// <returns></returns>
        public abstract bool Disconnect();

        /// <summary>
        /// Check current connection
        /// </summary>
        /// <returns></returns>
        public abstract bool CheckAlive();

        /// <summary>
        /// Check current connection
        /// </summary>
        /// <returns></returns>
        public abstract bool CheckConnections();

        /// <summary>
        /// Send data to destinations
        /// </summary>
        /// <param name="data">byte array</param>
        /// <returns></returns>
        public abstract bool Send(byte[] data);

        /// <summary>
        /// Send data to destinations
        /// </summary>
        /// <param name="data">byte array</param>
        /// <returns></returns>
        public abstract bool Send(String data);

        public abstract bool SenDataPackage(string str);
        #endregion//end Astract methods
    }
}
