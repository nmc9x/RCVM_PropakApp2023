using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ML.DatabaseConnections.Controller;
using ML.DatabaseConnections.DataType;

namespace ML.DatabaseConnections
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class ConnectionDatabase
    {
        #region Properties

        private DataTable _Tables;

        [XmlIgnore]
        public DataTable Tables
        {
            get { return _Tables; }
            set { _Tables = value; }
        }

        private String _ConnectionString = "";

        public String ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private String _TableName;

        public String TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private bool _FirstRowHeader = false;

        /// <summary>
        /// Using first row as header
        /// Apply for TXT, CSV
        /// </summary>
        public bool FirstRowHeader
        {
            get { return _FirstRowHeader; }
            set { _FirstRowHeader = value; }
        }

        private List<String> _Columns = new List<string>();

        [XmlIgnore]
        public List<String> Columns
        {
            get { return _Columns; }
            set { _Columns = value; }
        }

        private int _CodePage = Encoding.UTF8.CodePage;

        public int CodePage
        {
            get { return _CodePage; }
            set { _CodePage = value; }
        }

        private DatabaseShow _DataType = DatabaseShow.Table;

        public DatabaseShow DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        //Use for split database
        private int _NumberOfStepSplit = 1;
        [XmlIgnore]
        public int NumberOfStepSplit
        {
            get { return _NumberOfStepSplit; }
            set { _NumberOfStepSplit = value; }
        }

        private string _PrefixOfFieldNameSplit = "F";
        [XmlIgnore]
        public string PrefixOfFieldNameSplit
        {
            get { return _PrefixOfFieldNameSplit; }
            set { _PrefixOfFieldNameSplit = value; }
        }
        //END Use for split database
        private int _RowCount = 0;
        [XmlIgnore]
        public int RowCount
        {
            get { return _RowCount; }
            set { _RowCount = value; }
        }

        #endregion Properties

        #region Virtual Methods

        /// <summary>
        /// Return code of error
        /// 0: load successfull
        /// 1: database not found
        /// 2: wrong username or password
        /// 3: driver not found
        /// 4: other exception
        /// </summary>
        /// <returns></returns>
        public virtual int CheckConnection()
        {
            return 0;
        }

        public virtual bool ConnectDatabase()
        {
            if (Tables != null)
            {
                DatabaseController.DbObject = this;
                //raise connection event
                DatabaseController.RaiseConnectedDatabase(true);
                return true;
            }
            return false;
        }

        protected int limit = 50;
        [XmlIgnore]
        public bool hasLimit = false;
        /// <summary>
        /// Load database to datatable - Design
        /// Return code of error
        /// 0: load successfull
        /// 1: database not found
        /// 2: wrong username or password
        /// 3: driver not found
        /// 4: other exception
        /// </summary>
        /// <returns></returns>
        public virtual int LoadToDatatable()
        {
            return 1;
        }

        public virtual bool CheckMaxRowsForSupport(int maxRows)
        {
            return true;
        }

        /// <summary>
        /// Load database to memory map file - RIP
        /// Return code of error
        /// 0: load successfull
        /// 1: database not found
        /// 2: wrong username or password
        /// 3: driver not found
        /// 4: other exception
        /// </summary>
        /// <returns></returns>
        public virtual int LoadToMemoryMapFile()
        {
            return 1;
        }

        /// <summary>
        /// Get list of table name of database
        /// </summary>
        /// <returns></returns>
        public virtual List<String> ListTableName() 
        { 
            return new List<String>(); 
        }

        /// <summary>
        /// Get all field name before load database for plit database
        /// </summary>
        /// <returns></returns>
        public virtual String[] GetAllFieldName()
        {
            return null;
        }

        public virtual void SaveDatabase()
        {
            try
            {
               //
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
        #endregion Virtual Methods
    }
}
