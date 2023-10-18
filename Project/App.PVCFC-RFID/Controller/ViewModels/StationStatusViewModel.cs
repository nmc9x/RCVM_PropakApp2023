using ML.Common.Controller;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.PVCFC_RFID.Controller.ViewModels
{
    public class StationStatusViewModel:ViewModelBase
    {

        #region Declaration
        public static EventHandler CheckStatusEvent = null;
        private Thread _ThreadCheckStatusConnection;
        public static int Index { get; set; }
        private int _Index;

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
            _Index = index;
            _ThreadCheckStatusConnection = new Thread(StatusChecking);
            _ThreadCheckStatusConnection.IsBackground = true;
            _ThreadCheckStatusConnection.Start();
        }
      

        private void StatusChecking()
        {
            try
            {
                while (true)
                {
                    var mmfPrint = new MemoryMapHelper("mmf_connectStatus_printer" + _Index, 1);
                    var status_printer = Encoding.ASCII.GetString(mmfPrint.ReadData(0, 1));
               
                    if (status_printer != null && status_printer != "\0")
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


                    var mmfCam = new MemoryMapHelper("mmf_connectStatus_camera" + _Index, 1);
                    var status_camera = Encoding.ASCII.GetString(mmfCam.ReadData(0, 1));

                    if (status_camera != null && status_camera != "\0")
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
                    Thread.Sleep(1000);
                }
            }
            catch (Exception)
            {


            }
        }

        #endregion
    }
}
