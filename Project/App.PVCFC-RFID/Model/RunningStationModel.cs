using ML.Common.Enum;
using ML.DeviceTransfer.PVCFCRFID.Model;
using ML.SDK.DM60X.Controller;
using ML.SDK.DM60X.Model;
using ML.SDK.RDIF_FX9600.Controller;
using ML.SDK.RDIF_FX9600.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PVCFC_RFID.Model
{
    public class RunningStationModel : PVCFCRFIDDeviceRunningModel
    {
        private bool _IsReplyStart = false;
        public bool IsReplyStart
        {
            get { return _IsReplyStart; }
            set { _IsReplyStart = value; }
        }
        private bool _IsReplyStop = false;
        public bool IsReplyStop
        {
            get { return _IsReplyStop; }
            set { _IsReplyStop = value; }
        }

        private bool _IsUpdateDataRawList = false;
        public bool IsUpdateDataRawList
        {
            get { return _IsUpdateDataRawList; }
            set { _IsUpdateDataRawList = value; }
        }

        private RFID_FX9600FeedbackModel _RFID_FX9600Feedback = new RFID_FX9600FeedbackModel();
        public RFID_FX9600FeedbackModel RFID_FX9600Feedback
        {
            get { return _RFID_FX9600Feedback; }
            set { _RFID_FX9600Feedback = value; }
        }

        private DM60XFeedbackModel _DM60XFeedback = new DM60XFeedbackModel();
        public DM60XFeedbackModel DM60XFeedback
        {
            get { return _DM60XFeedback; }
            set { _DM60XFeedback = value; }
        }

        private ObservableCollection<GotCodeModel> _DataRawList = new ObservableCollection<GotCodeModel>();
        public ObservableCollection<GotCodeModel> DataRawList
        {
            get { return _DataRawList; }
            set {
                _DataRawList = value; 
            }
        }

        private DM60XUIBridgeSocketHandler _UIBridgeSocket = new DM60XUIBridgeSocketHandler();
        public DM60XUIBridgeSocketHandler UIBridgeSocket
        {
            get { return _UIBridgeSocket; }
            set { _UIBridgeSocket = value; }
        }

        public override void ResetDefault()
        {
            base.ResetDefault();
            _IsReplyStart = false;
            _IsReplyStop = false;
            _RFID_FX9600Feedback = new RFID_FX9600FeedbackModel();
            _DataRawList = new ObservableCollection<GotCodeModel>();
            _UIBridgeSocket = new DM60XUIBridgeSocketHandler();
        }
    }
}
