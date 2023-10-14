using ML.Common.Model;
using ML.SDK.DM60X.Model;
using ML.SDK.RDIF_FX9600.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        // Minh Chau Comment 20231002
        //private RFID_FX9600SettingsModel _RFID = new RFID_FX9600SettingsModel();
        //public RFID_FX9600SettingsModel RFID
        //{
        //    get { return _RFID; }
        //    set { _RFID = value; }
        //}

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
