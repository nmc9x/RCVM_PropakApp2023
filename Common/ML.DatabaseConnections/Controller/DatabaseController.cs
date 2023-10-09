using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Threading;
using ML.DatabaseConnections;

namespace ML.DatabaseConnections.Controller
{
    /// <summary>
    /// @Author: Linh.Tran
    /// Raise all events for database connection
    /// </summary>
    public class DatabaseController
    {
        #region Static properties

        public static ConnectionDatabase DbObject = null;

        public static int PrintedPage = 0;

        #endregion Static properties

        public static event EventHandler OnConnectedDatabase;

        public static void RaiseConnectedDatabase(bool connectedStatus)
        {
            if (OnConnectedDatabase != null)
            {
                OnConnectedDatabase(connectedStatus, EventArgs.Empty);
            }
        }

        public static void LoadDatabase(string strDatabaseFiles, Encoding encode)
        {
            DatabaseController.DbObject = new ConnectionDatabaseCSV();
            DatabaseController.DbObject.ConnectionString = strDatabaseFiles;
            DatabaseController.DbObject.CodePage = encode.CodePage;
            DatabaseController.DbObject.LoadToDatatable();
            string a = DatabaseController.DbObject.Tables.Rows[0][0].ToString();
        }

        public static void RemoveDatabase()
        {
            DbObject = null;
            if (OnConnectedDatabase != null)
            {
                OnConnectedDatabase(false, EventArgs.Empty);
            }
        }
    }
}
