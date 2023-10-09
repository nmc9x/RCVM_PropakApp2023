using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.Connections.Controller
{
    public class SerialPortListener:MainListener
    {
        private SerialPort _COMPort;

        public SerialPortListener()
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
        public SerialPortListener(string portName, int baudrate, int dataBits, Parity parity, StopBits stopBits, bool DtrEnable, int delayTimeToSendMessage = 1, bool isSendStringData = false, List<string> listAvoidCOM = null)
        {
            _COMPortName = portName;
            _Baudrate = baudrate;
            _Parity = parity;
            _StopBits = stopBits;
            _DtrEnable = DtrEnable;
            _DelayTimeToSendMessage = delayTimeToSendMessage;
            _IsSendStringData = isSendStringData;
            _ListAvoidCOM = listAvoidCOM;
        }

        public override bool CheckAlive()
        {
            try
            {
                if (_COMPort.IsOpen)
                {
                    //return _SendSuccess;//Linh.Tran_210316: Command
                    return true;//Linh.Tran_210316: Update
                }
                else
                {
                    //Linh.Tran_210316: Add new
                    if (_COMPort != null)
                    {
                        _COMPort.Open();
                    }
                    //End Linh.Tran_210316: Add new                 
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Check com port connection
        /// </summary>
        /// <param name="port"></param>
        /// <returns>
        /// 0: Port is invalid
        /// 1: Port in used
        /// 2: Port is ok for use
        /// </returns>
        public override bool CheckConnections()
        {
            if (_COMPort != null && _COMPort.IsOpen)
            {
                return true;
            }
            return false;
        }

        public override bool Connect()
        {
            try
            {
                InitListenter();
                //
                foreach (string tenPort in SerialPort.GetPortNames())
                {
                    if (_ListAvoidCOM != null)
                    {
                        if (_ListAvoidCOM.Contains(tenPort))
                        {
                            continue;
                        }
                    }
                    if (tenPort == _COMPortName)
                    {
                        _COMPort = new SerialPort(_COMPortName, _Baudrate, _Parity, _DataBits, _StopBits);
                        _COMPort.DtrEnable = _DtrEnable;//Linh.Tran_200904
                        //COMPort.RtsEnable = true;

                        //Linh.Tran_200904: Listen COM port
                        _COMPort.DataReceived -= new SerialDataReceivedEventHandler(SerialPortListenning);
                        _COMPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortListenning);
                        _COMPort.Open();
                        //End Linh.Tran_200904: Listen COM port
                        break;
                    }
                }
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
            if (_COMPort != null && _COMPort.IsOpen)
            {
                _COMPort.Close();
            }
            return true;
        }

        private void SerialPortListenning(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] dataBytes;
                //do
                //{
                int bytesLength = _COMPort.BytesToRead;
                dataBytes = new byte[bytesLength];
                _COMPort.Read(dataBytes, 0, bytesLength);
                //string data = _COMPort.ReadTo(">");
                //
                //Linh.Tran_210902: Update fix errors miss Packages
                Thread threadTemp = new Thread(() => this.ProccessReceivedMessage(dataBytes));
                threadTemp.IsBackground = true;
                threadTemp.Start();
                //End Linh.Tran_210902: Update fix errors miss Packages
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("COMPort_DataReceived: " + ex.Message);
#endif
            }
        }

        public override bool Send(byte[] data)
        {
            if (_COMPort != null && _COMPort.IsOpen)
            {
                //Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff") + " " + byteData[0].ToString("x2"));
                _COMPort.Write(data, 0, data.Length);
#if DEBUG
                Console.WriteLine("SW: Send =" + BitConverter.ToString(data) + " " + DateTime.Now.ToString("hh:mm:ss.fff"));
#endif
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Send(string data)
        {
            try
            {
                if (_COMPort != null && _COMPort.IsOpen)
                {
                    char[] dataArray = data.ToCharArray();
                    //
                    if (_COMPort != null && _COMPort.IsOpen)
                        _COMPort.Write(dataArray, 0, dataArray.Length);
                    return true;
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

        #region Static methods
        /// <summary>
        /// Check com port connection
        /// </summary>
        /// <param name="port"></param>
        /// <returns>
        /// 0: Port is invalid
        /// 1: Port in used
        /// 2: Port is ok for use
        /// </returns>
        public static int CheckPort(String port)
        {
            bool valid = false;
            foreach (string tenPort in SerialPort.GetPortNames())
            {
                if (tenPort == port)
                {
                    valid = true;
                    break;
                }
            }
            if (!valid)
            {
                return 0;
            }

            try
            {
                SerialPort COMPort = new SerialPort(port, 115200, Parity.None, 8, StopBits.One);
                COMPort.Open();
                COMPort.Close();
                COMPort.Dispose();
                return 2;
            }
            catch
            {
                return 1;
            }
        }

        #endregion//End Static methods
    }
}
