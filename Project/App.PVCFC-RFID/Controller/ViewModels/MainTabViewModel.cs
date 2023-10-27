using ML.Common.Controller;
using System;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Documents;

namespace App.PVCFC_RFID.Controller.ViewModels
{
    public class MainTabViewModel:ViewModelBase
    {
        MemoryMapHelper mmf_StartProcess;
        MemoryMapHelper mmf_DBFilePath;
        MemoryMapHelper mmf_TemplateName;
        MemoryMapHelper mmf_PODIndex;

        #region DataBinding

        private int _SelectedStationIndex;

        public int SelectedStationIndex
        {
            get { return _SelectedStationIndex; }
            set 
            { 
                _SelectedStationIndex = value;
                mmf_StartProcess = new MemoryMapHelper("mmf_StartProcess_" + SelectedStationIndex, 1);
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
            mmf_StartProcess = new MemoryMapHelper("mmf_StartProcess_" + SelectedStationIndex, 1);
            
        }
        private bool isAllowStart = true;
        private bool isAllowStop = true;
        internal void StartPrint(ref bool isRun)
        {
            try
            {
                if (isAllowStart)
                {
                    SharedControlHandler.EnableCamera = true;
                    mmf_StartProcess.WriteData(Encoding.ASCII.GetBytes("1"), 0);
                    isRun = true;
                }
                else
                {
                    isRun = false;
                }
               
            }
            catch (Exception)
            {
                isRun = false;
            }
           
        }
        internal void StopPrint(ref bool isStop)
        {
            try
            {
                if (isAllowStop)
                {
                    SharedControlHandler.EnableCamera = false;
                    mmf_StartProcess.WriteData(Encoding.ASCII.GetBytes("0"), 0);
                    isStop = true;
                }
                else
                {
                    isStop = false;
                }
                
            }
            catch (Exception)
            {

                isStop = false;
            }
            
        }

        
        internal void SaveDB(System.Collections.Generic.List<string> listPath, 
                             System.Collections.Generic.List<string> listPodIndex, 
                             System.Collections.Generic.List<string> listTemplate)
        {
            int index = 0;
            int index1 = 0;
            int index2 = 0;

            foreach (var item in listPath)
            {
                if(item == null)
                {
                    index++;
                    continue;
                } 
                mmf_DBFilePath = new MemoryMapHelper("mmf_DBFilePath" + index, 260);
                mmf_DBFilePath.WriteData(Encoding.ASCII.GetBytes(item), 0);
                index++;
            }

            foreach (var item in listPodIndex)
            {
                if (item == null)
                {
                    index1++;
                    continue;
                }
                mmf_PODIndex = new MemoryMapHelper("mmf_PODIndex" + index1, 2);
                mmf_PODIndex.WriteData(Encoding.ASCII.GetBytes(item), 0);
                index1++;
            }

            foreach (var item in listTemplate)
            {
                if (item == null)
                {
                    index2++;
                    continue;
                }
                mmf_TemplateName = new MemoryMapHelper("mmf_TemplateName" + index2, 100);
                mmf_TemplateName.WriteData(Encoding.ASCII.GetBytes(item), 0);
                index2++;
            }
           
        }
        #endregion
    }
}
