using App.PVCFC_RFID.DataType;
using ML.Common.Model;
using ML.SDK.DM60X.Model;

namespace App.PVCFC_RFID.Model
{
    public class SettingsStationModel : CommonSettingsModel
    {
        private int _Index = -1;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        private StationType _CameraModel = StationType.COGNEX_DATAMAN;  // 0 cognex, 1 keyence
        public StationType CameraModel
        {
            get { return _CameraModel; }
            set { _CameraModel = value; }
        }

       

        public string LastPathDatabase { get; set; }
        public int LastSeletedIndexColumn { get; set; }
        public int LastSelectedIndexTemplate { get; set; }


        private DMCam_SettingModel _DMCamera = new DMCam_SettingModel();
        public DMCam_SettingModel DMCamera
        {
            get { return _DMCamera; }
            set { _DMCamera = value; }
        }

        private Keyence_SettingModel _KeyenceCamera = new Keyence_SettingModel();
        public Keyence_SettingModel KeyenceCamera
        {
            get { return _KeyenceCamera; }
            set { _KeyenceCamera = value; }
        }
    }
}
