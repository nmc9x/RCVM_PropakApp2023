using ML.Common.Controller;
using ML.SDK.DM60X.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;

namespace App.PVCFC_RFID.Controller
{
    public class TriggerViewModel : ViewModelBase
    {

        #region Define
        private int Index;

        private ObservableCollection<GotCodeModel> _CodeList = new ObservableCollection<GotCodeModel>();
        public ObservableCollection<GotCodeModel> CodeList
        {
            get => _CodeList;
            set
            {
                SetProperty(ref _CodeList, value);

            }
        }

        private ImageSource _ImgSrc;
        public ImageSource ImgSrc
        {
            get { return _ImgSrc; }
            set
            {
                if (ImgSrc != value)
                {
                    _ImgSrc = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _TotalValue;

        public string TotalValue
        {
            get { return _TotalValue; }
            set { _TotalValue = value; OnPropertyChanged(); }
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
            var ThreadListenImgData = new Thread(GetImageData);
            ThreadListenImgData.IsBackground = true;
            ThreadListenImgData.Start();
            Index = index;
            SharedControlHandler._dispatcher = Dispatcher.CurrentDispatcher;
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                CodeList = SharedValues.Running.StationList[index].DataRawList;

            });
            CodeList.CollectionChanged += CodeList_CollectionChanged;
            TotalValue = _CodeList.Count.ToString();

        }

        private void GetImageData()
        {
            while (true)
            {
                ImgSrc = SharedControlHandler.ImgSrc;
                Thread.Sleep(10);
            }

        }

        private void CodeList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            RaiseCustomEvent(e);
            TotalValue = _CodeList.Count.ToString();


        }



        internal void CloseForm()
        {
            //SharedControlHandler.DataRawListChanged -= OnDataRawListChanged;
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
            var mmf_TriggerClick = new MemoryMapHelper("mmf_TriggerClick" + Index, 1);
            mmf_TriggerClick.WriteData(Encoding.UTF8.GetBytes("1"), 0);

        }
    }
}
