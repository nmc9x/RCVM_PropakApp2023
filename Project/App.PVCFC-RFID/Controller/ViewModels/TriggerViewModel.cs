using ML.Common.Controller;
using ML.SDK.DM60X.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public delegate void CustomEvtHandler(object sender, NotifyCollectionChangedEventArgs e);
        public static event CustomEvtHandler CustomEvt;

        #endregion
        public void RaiseCustomEvent(NotifyCollectionChangedEventArgs e)
        {
            CustomEvt?.Invoke(this, e);
        }
        public TriggerViewModel(int index)
        {
            SharedControlHandler._dispatcher = Dispatcher.CurrentDispatcher;
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                CodeList = SharedValues.Running.StationList[Index].DataRawList;
                
            });
            SharedControlHandler.DataRawListChanged += OnDataRawListChanged;
            CodeList.CollectionChanged += CodeList_CollectionChanged;
        }

        private void CodeList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaiseCustomEvent(e);
           
        }

        private void OnDataRawListChanged(object sender, EventArgs e)
        {
    
            
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                //CommonFunctions.GetFromMemoryFile("mmf_ImageByteLength", 5, out _, out byte[] lengthData);
                //var len = int.Parse(Encoding.ASCII.GetString(lengthData));
                //CommonFunctions.GetFromMemoryFile("mmf_ImageTrigger", len, out _, out byte[] imageData);

                //if (imageData != null)
                //{
                //    ImgSrc = CommonFunctions.ByteArrayToBitmapImage(imageData);
                //}
                CodeList = new ObservableCollection<GotCodeModel>(SharedValues.Running.StationList[(int)sender].DataRawList);
            });
            
        }
       

        internal void CloseForm()
        {
            SharedControlHandler.DataRawListChanged -= OnDataRawListChanged;
            CodeList.CollectionChanged -= CodeList_CollectionChanged;
            ClearDataRawList();
        }
        internal void ClearDataRawList()
        {
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                SharedValues.Running.StationList[Index].DataRawList.Clear();
                CodeList.Clear();
            });
        }

        internal void SoftwareTrigger()
        {
            CommonFunctions.SetToMemoryFile("mmf_TriggerClick"+Index, 1, "1");
          
        }
    }
}
