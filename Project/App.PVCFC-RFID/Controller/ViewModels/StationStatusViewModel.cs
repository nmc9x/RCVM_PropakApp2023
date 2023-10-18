using ML.Common.Controller;
using System;
using System.Threading;

namespace App.PVCFC_RFID.Controller.ViewModels
{
    public class StationStatusViewModel:ViewModelBase
    {

        #region Declaration
        public static EventHandler CheckStatusEvent = null;
        private Thread _ThreadCheckStatusConnection;
        public static int Index { get; set; }

        #region DataBinding
        private int _StatusPrinter;
        public int StatusPrinter
        {
            get { return _StatusPrinter; }
            set { _StatusPrinter = value; OnPropertyChanged(); }
        }

        private int _StatusCamera;
        public int StatusCamera
        {
            get { return _StatusCamera; }
            set { _StatusCamera = value; OnPropertyChanged(); }
        }
        #endregion


        #endregion Declaration

        #region Functions

        public StationStatusViewModel(int index)
        {
            //Status Checking Thread
            _ThreadCheckStatusConnection = new Thread(new ParameterizedThreadStart(StatusChecking));
            _ThreadCheckStatusConnection.IsBackground = true;
            _ThreadCheckStatusConnection.Start(index);

        }
      

        private void StatusChecking(object index)
        {
            try
            {
                while(true)
                {
                    CommonFunctions.GetFromMemoryFile("mmf_connectStatus_printer" + index, 1, out string status_printer, out _);
                    if(status_printer != null)
                    switch (int.Parse(status_printer))
                    {
                        case 0:
                            StatusPrinter = 0;
                            break;
                        case 1:
                            StatusPrinter = 1;
                            break;
                        case 2:
                            StatusPrinter = 2;
                            break;
                        case 3:
                            StatusPrinter = 3;
                            break;
                        default:
                            break;
                    }

                    //mmf_connectStatus_camera
                    CommonFunctions.GetFromMemoryFile("mmf_connectStatus_camera" + index, 1, out string status_camera, out _);
                    if (status_camera != null)
                        switch (int.Parse(status_camera))
                        {
                            case 0:
                                StatusCamera = 0;
                                break;
                            case 1:
                                StatusCamera = 1;
                                break;
                            case 2:
                                StatusCamera = 2;
                                break;
                            case 3:
                                StatusCamera = 3;
                                break;
                            default:
                                break;
                        }
                    Thread.Sleep(10);
                }
            }
            catch (Exception)
            {

                
            }
        }

        #endregion
    }
}
