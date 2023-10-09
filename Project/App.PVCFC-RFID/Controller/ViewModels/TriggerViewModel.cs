using ML.Common.Controller;
using ML.SDK.DM60X.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace App.PVCFC_RFID.Controller
{
    public class TriggerViewModel: ViewModelBase
    {

        #region Define
        public int Index { get; set; }
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
                CodeList = SharedValues.Running.StationList[Index].DataRawList;  
            });
            SharedControlHandler.DataRawListChanged += OnDataRawListChanged;

        }
        private void OnDataRawListChanged(object sender, EventArgs e)
        {
            
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                CommonFunctions.GetFromMemoryFile("memoryMapFile_ImageTrigger", _MaxImageByteSize, out _, out byte[] imageData);
                if (imageData != null)
                {
                    ImgSrc = CommonFunctions.ByteArrayToBitmapImage(imageData);
                }
                CodeList = new ObservableCollection<GotCodeModel>(SharedValues.Running.StationList[(int)sender].DataRawList);
            });
            
        }
       

        internal void CloseForm()
        {
            SharedControlHandler.DataRawListChanged -= OnDataRawListChanged;
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
