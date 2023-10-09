using ML.Common.Controller;
using ML.SDK.DM60X.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;

namespace App.PVCFC_RFID.Controller
{
    public class TriggerViewModel: ViewModelBase
    {

        #region Define
        private int _MaxImageByteSize = 100000;
        private ObservableCollection<GotCodeModel> _CodeList = new ObservableCollection<GotCodeModel>();
        public ObservableCollection<GotCodeModel> CodeList
        {
            get => _CodeList;
            set=> SetProperty(ref _CodeList, value);
        }

        private ImageSource _ImgSrc;
        public ImageSource ImgSrc
        {
            get { return _ImgSrc; }
            set { _ImgSrc = value; OnPropertyChanged(); }
        }

        #endregion

        public TriggerViewModel()
        {
            SharedControlHandler._dispatcher = Dispatcher.CurrentDispatcher;
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                CodeList = SharedValues.Running.StationList[0].DataRawList;
                SharedControlHandler.DataRawListChanged += OnDataRawListChanged;
                
            });
         
        }
        private void OnDataRawListChanged(object sender, EventArgs e)
        {
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                CommonFunctions.GetFromMemoryFile("memoryMapFile_ImageTrigger", _MaxImageByteSize, out _, out byte[] byteOut);
                if (byteOut != null)
                {
                    ImgSrc = CommonFunctions.ByteArrayToBitmapImage(byteOut);
                }
                CodeList = new ObservableCollection<GotCodeModel>(SharedValues.Running.StationList[(int)sender].DataRawList);
            });
        }

        internal void ClearDataRawList()
        {
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                SharedValues.Running.StationList[0].DataRawList.Clear();
                CodeList.Clear();
            });
        }

        internal void SoftwareTrigger()
        {
            CommonFunctions.SetToMemoryFile("memoryMapFile_TriggerClick", 1, "1");
        }
    }
}
