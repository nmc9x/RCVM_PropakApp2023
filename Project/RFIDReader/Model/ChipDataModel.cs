using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Model
{
    public class ChipDataModel
    {
        private string _ChipID = "";
        public string ChipID
        {
            get { return _ChipID; }
            set { _ChipID = value; }
        }

        private string _Data = "";
        public string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
    }
}
