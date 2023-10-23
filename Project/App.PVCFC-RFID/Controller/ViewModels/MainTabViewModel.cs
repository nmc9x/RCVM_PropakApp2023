using ML.Common.Controller;
using System;
using System.Text;
using System.Threading;
using System.Windows.Documents;

namespace App.PVCFC_RFID.Controller.ViewModels
{
    public class MainTabViewModel:ViewModelBase
    {
        MemoryMapHelper mmf;
        MemoryMapHelper mmf_DBFilePath;
        #region DataBinding

        private int _SelectedStationIndex;

        public int SelectedStationIndex
        {
            get { return _SelectedStationIndex; }
            set 
            { 
                _SelectedStationIndex = value;
                mmf = new MemoryMapHelper("mmf_StartProcess_" + SelectedStationIndex, 1);
                OnPropertyChanged(); 
            }
        }

        private int _StatusCamera;
        public int StatusCamera
        {
            get { return _StatusCamera; }
            set { _StatusCamera = value; OnPropertyChanged(); }
        }

        private int _StatusPrinter;
        public int StatusPrinter
        {
            get { return _StatusPrinter; }
            set { _StatusPrinter = value; OnPropertyChanged(); }
        }

        private int _TabIndex;
        public int TabIndex
        {
            get { return _TabIndex; }
            set { _TabIndex = value; OnPropertyChanged(); }
        }

        public MainTabViewModel()
        {
            mmf = new MemoryMapHelper("mmf_StartProcess_" + SelectedStationIndex, 1);
            
        }
        internal void StartPrint()
        {
            mmf.WriteData(Encoding.ASCII.GetBytes("1"), 0);
        }
        internal void StopPrint()
        {
            mmf.WriteData(Encoding.ASCII.GetBytes("0"), 0);
        }

        internal void SaveDB(System.Collections.Generic.List<string> listpath)
        {
            int index = 0;
            foreach (var item in listpath)
            {
                mmf_DBFilePath = new MemoryMapHelper("mmf_DBFilePath" + index, 260);
                mmf_DBFilePath.WriteData(Encoding.ASCII.GetBytes(item), 0);
                index++;
            }
           
        }
        #endregion
    }
}
