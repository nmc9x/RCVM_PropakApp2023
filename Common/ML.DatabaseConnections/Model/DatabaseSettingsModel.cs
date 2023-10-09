using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DatabaseConnections.Model
{
    public class DatabaseSettingsModel
    {
        private string _FullPath = "";
        public string FullPath
        {
            get { return _FullPath; }
            set { _FullPath = value; }
        }

        private int _CodePage = Encoding.UTF7.CodePage;
        public int CodePage
        {
            get { return _CodePage; }
            set { _CodePage = value; }
        }
    }
}
