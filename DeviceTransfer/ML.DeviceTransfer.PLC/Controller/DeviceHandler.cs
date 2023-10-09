using ML.Connections.Controller;
using ML.Connections.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.DeviceTransfer.PLC.Controller
{
    public class DeviceHandler
    {
        #region Properties
        private static MainListener _PLCListener = null;
        private static Thread _ThreadDeviceStatusChecking = null;
        private static string _IP = "192.168.10.50";
        private static int _Port = 80;
        private static byte _DeviceAddress = 255;
        //
        public static ConnectionsType.StatusEnum ConnectionStatus = ConnectionsType.StatusEnum.Unknown;
        #endregion//End Properties

        #region Inits Connections
        public static string Connect(string ip, int port, byte deviceAddress)
        {
            try
            {
                _IP = ip;
                _Port = port;
                _DeviceAddress = deviceAddress;
                //
                _PLCListener = new TCPIPServerListener(_IP, _Port);
                if (_PLCListener != null)
                {
                    if (_PLCListener.Connect())
                    {
                        //
                        _ThreadDeviceStatusChecking = new Thread(DeviceStatusChecking);
                        _ThreadDeviceStatusChecking.IsBackground = true;
                        _ThreadDeviceStatusChecking.Priority = ThreadPriority.Highest;
                        _ThreadDeviceStatusChecking.Start();
                        //
                        _PLCListener.ReceiveDataEvent += _PLCListener_ReceiveDataEvent;
                    }
                    else
                    {
                        _PLCListener = null;
                    }

                }
                if (_PLCListener != null)
                {
                    return null;
                }
                return ConnectionsType.ResultEnum.Failed.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Distroys()
        {
            try
            {
                //Kill thread insert database
                if (_ThreadDeviceStatusChecking != null && _ThreadDeviceStatusChecking.IsAlive)
                {
                    //release thread
                    _ThreadDeviceStatusChecking.Abort();
                    _ThreadDeviceStatusChecking = null;
                    //
                }
                //
                if (_PLCListener != null)
                {
                    _PLCListener.Disconnect();
                    _PLCListener = null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void DeviceStatusChecking()
        {
            while (true)
            {
                #region Check connection status
                ConnectionsType.StatusEnum oldRFIDStatus = ConnectionsType.StatusEnum.Unknown;
                ConnectionsType.StatusEnum newRFIDStatus = ConnectionsType.StatusEnum.Unknown;
                //
                if (_PLCListener != null)
                {
                    oldRFIDStatus = ConnectionStatus;
                    if (_PLCListener.CheckAlive())
                    {
                        newRFIDStatus = ConnectionsType.StatusEnum.Connected;
                    }
                    else if (_PLCListener.CheckConnections())
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
                    if (_PLCListener != null)
                    {
                        ConnectionStatus = newRFIDStatus;
                        //
                        ConnectionEvents.RaiseDeviceStatusChanged(ConnectionStatus, EventArgs.Empty);
                    }
                }
                #endregion//End Check connection status
                //
                Thread.Sleep(100);
            }
        }
        #endregion//End Inits Connections

        #region Events
        private static void _PLCListener_ReceiveDataEvent(object sender, EventArgs e)
        {
            try
            {
                byte[] resultBytes = (sender as byte[]);
                //

                //
                System.Threading.Thread.Sleep(1);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        #endregion//End Events

        #region Methods
        
        #endregion//End Methods
    }
}
