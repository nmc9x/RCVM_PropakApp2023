using App.DevCodeActivatorRFID.Model;
using ML.Common.Controller;
using ML.Connections.Controller;
using ML.Connections.DataType;
using ML.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace App.DevCodeActivatorRFID.Controller
{
    public class SharedControlHandler
    {
        private static int _NumberOfStation = Properties.Settings.Default.NumberOfStation;
        private static int _UISocketPort = Properties.Settings.Default.SocketPortUI;
        private static int _StationSocketPort = Properties.Settings.Default.SocketPortStation;
        //
         private static Thread _ThreadCheckDeviceTransferAliving;
        private static Thread _ThreadListenDeviceTransferListenning;
        //
        private static bool _IsStopThreadRunWhenStarting = false;
        private static DateTime _DatetimeCheckTimeOutScanData = DateTime.Now;
        //
        private static List<ProductItemModel> _CurrentProductListInScanTimes = new List<ProductItemModel>();
        private static List<ProductItemModel> _CurrentPalletListInScanTimes = new List<ProductItemModel>();

        public static void InitDeviceTransfer()
        {
            #region Thread check alive device transfer
            _ThreadCheckDeviceTransferAliving = new Thread(CheckDeviceTransferAliving);
            _ThreadCheckDeviceTransferAliving.IsBackground = true;
            _ThreadCheckDeviceTransferAliving.Priority = ThreadPriority.Highest;
            _ThreadCheckDeviceTransferAliving.Start();
            #endregion//End Thread check alive device transfer

            #region Station
            // Run Thread
            _ThreadListenDeviceTransferListenning = new Thread(DeviceTransferListenning);
            _ThreadListenDeviceTransferListenning.IsBackground = true;
            _ThreadListenDeviceTransferListenning.Priority = ThreadPriority.Highest;
            _ThreadListenDeviceTransferListenning.Start();
            //End Run Thread

            #region Run Stations - Device transfer
            for (int i = 0; i < SharedValues.Running.NumberOfStation; i++)
            {
                string socketName = Properties.Settings.Default.DeviceTransferName;
                int socketIndex = i;
                int uiSocketPort = _UISocketPort;//Port received
                int stationsSocketPort = _StationSocketPort + i;//Port send
                //
                string deviceIP = "192.168.10.5" + (i).ToString();
                int devicePort = 80 + i;
                byte deviceAddress = 255;
                //
                string fullPath = Application.StartupPath + "\\" + Properties.Settings.Default.DeviceTransferName + ".exe";
                string arguments = "";

                arguments += socketName;//socketName
                arguments += "  " + socketIndex;//socketIndex = int.Parse(args[1]);
                arguments += "  " + uiSocketPort;//uiSocketPort = int.Parse(args[2]);
                arguments += "  " + stationsSocketPort;//bridgeSocketPort = int.Parse(args[3]);
                //
                arguments += "  " + deviceIP;//deviceIP = args[4];
                arguments += "  " + devicePort;//devicePort = int.Parse(args[5]);
                arguments += "  " + deviceAddress;//deviceAddress = (byte)int.Parse(args[6]);
                //
                SharedValues.Running.StationList[i].TransferID = CommonFunctions.DeviceTransferStartProcess(socketName, fullPath, arguments);
            }
            #endregion//End Run Stations - Device transfers
            #endregion//End Station
        }

        public static void KillDeviceTransfer(int index = -1)
        {
            if (index < 0)
            {
                //Kill all
                for (int i = 0; i < SharedValues.Running.NumberOfStation; i++)
                {
                    SharedFunctions.DeviceTransferKillProcess(SharedValues.Running.StationList[i].TransferID);
                }
            }
            else
            {
                SharedFunctions.DeviceTransferKillProcess(SharedValues.Running.StationList[index].TransferID);
            }
        }

        #region Running thread
        private static void CheckDeviceTransferAliving()
        {
            while (true)
            {
                foreach(ML.DeviceTransfer.Model.DeviceRunningModel running in SharedValues.Running.StationList)
                {
                    ConnectionsType.StatusEnum stationsTransferStatus = running.TransferStatus;
                    if (stationsTransferStatus != ConnectionsType.StatusEnum.Unknown)
                    {
                        if (running.TransferID > 0)
                        {
                            //Check RFID transfers
                            if (!SharedFunctions.DeviceTransferCheckAlive(running.TransferID))
                            {
                                running.TransferStatus = ConnectionsType.StatusEnum.Unknown;
                               // running.Status = running.RefreshStatus();
                                SharedEvents.RaiseStationDeviceStatusChanged(running.Index);
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }
        
        /// <summary>
        /// Communicate with Device transfer - Linh.Tran_230719
        /// </summary>
        private static void DeviceTransferListenning()
        {
            try
            {
                UdpClient socketManager = new UdpClient(_UISocketPort);
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    try
                    {
                        byte[] receiveBytes = socketManager.Receive(ref remoteIpEndPoint);
                        switch (receiveBytes[0])
                        {
                            case (byte)ConnectionsType.SocketTransferTypeCommandEnum.DeviceType:
                                int socketIndex = receiveBytes[2];
                                switch (receiveBytes[1])
                                {
                                    case (byte)ConnectionsType.SockTypeCommandEnum.UICommand:
                                        #region UI
                                        switch (receiveBytes[3])
                                        {
                                            case (byte)ConnectionsType.UISocketCommandEnum.DeviceStatus:
                                                #region Device status
                                                SharedValues.Running.StationList[socketIndex].TransferStatus = (ConnectionsType.StatusEnum)receiveBytes[4];
                                                SharedEvents.RaiseStationDeviceStatusChanged(socketIndex);
                                                #endregion//End Device status
                                                break;
                                        }
                                        #endregion//End UI
                                        break;
                                    case (byte)ConnectionsType.SockTypeCommandEnum.DeviceCommand:
                                        #region Device command

                                        #endregion//End Device command
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        MessageBox.Show("Error: USBCollectionsController - ThreadListenUDPInit: " + ex.Message);
#endif
                    }
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Languages.Errors, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            }
        }

        private static void ThreadRunWhenStarting()
        {
            _IsStopThreadRunWhenStarting = true;
            new Thread(() =>
            {
                while (_IsStopThreadRunWhenStarting)
                {

                    Thread.Sleep(1);//Wait 50s
                }
            }).Start();
        }

        #region Destroy
        private static string DistroysThreadListenDeviceTransferListenning()
        {
            try
            {
                //Kill thread insert database
                if (_ThreadListenDeviceTransferListenning!= null && _ThreadListenDeviceTransferListenning.IsAlive)
                {
                    //release thread
                    _ThreadListenDeviceTransferListenning.Abort();
                    _ThreadListenDeviceTransferListenning = null;
                    //
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void DisponseThreadRunWhenStarting()
        {
            _IsStopThreadRunWhenStarting = false;
        }
        #endregion//End Destroy
        #endregion//End Running thread

        #region Start/Stop
        public static void StartScan()
        {
            //SharedValues.Settings.PLC.SendCommand(ML.DeviceTransfer.PLC.DataType.PLCEnum.CommandEnum.Start);
            //
            SharedValues.Running.Status = ML.Common.Enum.RunningStatusEnum.Starting;
            //
            //
            ThreadRunWhenStarting();
        }

        public static void StopScan()
        {
            DisponseThreadRunWhenStarting();
            //
            //SharedValues.Settings.PLC.SendCommand(ML.DeviceTransfer.PLC.DataType.PLCEnum.CommandEnum.Stop);
            //
            SharedValues.Running.Status = ML.Common.Enum.RunningStatusEnum.Stop;
            SharedValues.Running.StartProcess.IsErrorsInCheckingDataPerTime = false;
            //
            _DatetimeCheckTimeOutScanData = DateTime.Now;
        }
        #endregion//End Start/Stop

    }
}
