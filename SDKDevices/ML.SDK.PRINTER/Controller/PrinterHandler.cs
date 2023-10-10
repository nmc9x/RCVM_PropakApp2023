using ML.Connections.Controller;
using ML.Connections.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.SDK.PRINTER.Controller
{
    public class PrinterHandler
    {
        #region Declaration
        private string _IP;
        private string _Port;
        private int _SocketIndex;
        private MainListener _PrinterListener;
        private Thread _ThreadDeviceStatusChecking = null;
        private ConnectionsType.StatusEnum _ConnectionStatus = ConnectionsType.StatusEnum.Unknown;
        #endregion

        public PrinterHandler(string ip, string port, int socketIndex)
        {
            _IP = ip;
            _Port = port;
            _SocketIndex = socketIndex;
        }
        public bool Connect()
        {
            try
            {
                _PrinterListener = new TCPIPServerListener(_IP, int.Parse(_Port));
                if( _PrinterListener != null )
                {
                    if (_PrinterListener.Connect())
                    {
                        //--Status Checking Thread--//
                        _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking);
                        _ThreadDeviceStatusChecking.IsBackground = true;
                        _ThreadDeviceStatusChecking.Priority = ThreadPriority.Highest;
                        _ThreadDeviceStatusChecking.Start();

                        //--Received Data Event--//
                        _PrinterListener.ReceiveDataEvent += _PrinterListener_ReceiveDataEvent;
                        return true;
                    }
                    else
                    {
                        _ConnectionStatus = ConnectionsType.StatusEnum.DisConnected;
                        ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("ERRORS: " + ex.Message);
#endif
                return false;
            }
        }

        private void _PrinterListener_ReceiveDataEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeviceStatusChecking()
        {
#if DEBUG
            Console.WriteLine("DeviceStatusChecking");
#endif
            while (true)
            {
                try
                {
                    #region Check connection status
                    ConnectionsType.StatusEnum oldRFIDStatus = ConnectionsType.StatusEnum.Unknown;
                    ConnectionsType.StatusEnum newRFIDStatus = ConnectionsType.StatusEnum.Unknown;
                    //
                    if (_PrinterListener != null)
                    {
                        oldRFIDStatus = _ConnectionStatus;
                        if (_PrinterListener.CheckAlive())
                        {
                            newRFIDStatus = ConnectionsType.StatusEnum.Connected;
                        }
                        else if (_PrinterListener.CheckConnections())
                        {
                            newRFIDStatus = ConnectionsType.StatusEnum.Processing;
                        }
                        else
                        {
                            newRFIDStatus = ConnectionsType.StatusEnum.DisConnected;
                        }
                    }
                    else
                    {
                        newRFIDStatus = ConnectionsType.StatusEnum.DisConnected;
                    }
                    //
                    if (newRFIDStatus != oldRFIDStatus)
                    {
                        if (_PrinterListener != null)
                        {
                            _ConnectionStatus = newRFIDStatus;
                            //
                            ConnectionEvents.RaiseDeviceStatusChanged(_ConnectionStatus, EventArgs.Empty);
                        }
                    }
                    #endregion//End Check connection status
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRORS: " + ex.Message);
                }
                //
                Thread.Sleep(100);
            }
        }
    }
}
