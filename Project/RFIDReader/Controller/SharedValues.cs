using ML.Common.Controller;
using ML.DatabaseConnections;
using App.DevCodeActivatorRFID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DevCodeActivatorRFID.Controller
{
    public class SharedValues: CommonValues
    {
        public static string DisShInfoPath = "";
        //
        public static RunningModel Running = new RunningModel(Properties.Settings.Default.NumberOfStation);
        public static SettingsModel Settings = new SettingsModel();
        public static ConnectionDatabase DatabaseObj = new ConnectionDatabase();
    }
}
