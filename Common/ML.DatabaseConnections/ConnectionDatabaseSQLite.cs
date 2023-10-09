using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Diagnostics;
using ML.DatabaseConnections.Model;
using Microsoft.VisualBasic.FileIO;
using ML.DatabaseConnections.DataType;
using System.Data.SQLite;

namespace ML.DatabaseConnections
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class ConnectionDatabaseSQLite : ConnectionDatabase
    {
        public ConnectionDatabaseSQLite()
        {
            FirstRowHeader = true;
        }

        public ConnectionDatabaseSQLite(string fullPath, int codePage)
        {
            ConnectionString = fullPath;
            CodePage = codePage;
            FirstRowHeader = true;
        }

        #region Properties

        private ReadTextMode _LoadingMode = ReadTextMode.Normal;

        public ReadTextMode LoadingMode
        {
            get { return _LoadingMode; }
            set { _LoadingMode = value; }
        }
        private String _SchemaPath;

        public String SchemaPath
        {
            get { return _SchemaPath; }
            set { _SchemaPath = value; }
        }
        private SplitCharacter _SplitChar = SplitCharacter.Tab;

        public SplitCharacter SplitChar
        {
            get { return _SplitChar; }
            set { _SplitChar = value; }
        }

        #endregion Properties

        #region Override Methods

        public override int CheckConnection()
        {
            return File.Exists(ConnectionString) ? 0 : 1;
        }

        public override int LoadToDatatable()
        {
            if (!File.Exists(ConnectionString))
            {
                return 1;
            }
            if (NumberOfStepSplit <= 1)
            {
                //FirstRowHeader = true;
                return LoadNormalMode();
            }
            else
            {
                return LoadSplitMode();
            }
        }

        public override bool CheckMaxRowsForSupport(int maxRows)
        {
            Encoding encoding = Encoding.GetEncoding(CodePage);
            using (StreamReader rd = new StreamReader(ConnectionString, encoding))
            {
                string file = rd.ReadToEnd();
                var lines = file.Split(new char[] { '\n' });           // big array
                if (lines.Count() > maxRows)
                    return false;
            }
            return true;
        }

        public override int LoadToMemoryMapFile()
        {
            if (!File.Exists(ConnectionString))
            {
                return 1;
            }

            //FirstRowHeader = true;
            return this.LoadToDatatable();
        }

        public override List<String> ListTableName()
        {
            List<String> result = new List<String>{ "simpleTable" };
            return result;
        }

        public override string[] GetAllFieldName()
        {
            String[] columslist = null;
            try
            {
                using (System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(SQLiteConnectionString))
                {
                    connection.Open();
                    String querytbalename = String.Format("SELECT * FROM '{0}'", TableName);
                    SQLiteCommand command = new SQLiteCommand(querytbalename, connection);
                    SQLiteDataAdapter odbcDataAdapter_Object = new SQLiteDataAdapter(command);
                    DataTable tableData = new DataTable();
                    odbcDataAdapter_Object.Fill(tableData);
                    odbcDataAdapter_Object.Dispose();
                    connection.Close();

                    if (tableData != null && tableData.Columns.Count > 0)
                    {
                        columslist = new String[tableData.Columns.Count];

                        for (int i = 0; i < tableData.Columns.Count; i++)
                        {
                            columslist[i] = tableData.Columns[i].Caption;
                            //columslist[i] = tableData.Columns[i].ColumnName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
            }
            return columslist;
        }

        #endregion Override Methods

        #region Methods

        public String SQLiteConnectionString
        {
            get { return String.Format("Data Source={0};Version=3", ConnectionString); }
        }

        private int LoadNormalMode()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(SQLiteConnectionString))
                {
                    connection.Open();
                    String querytbalename = String.Format("SELECT * FROM '{0}'", TableName);
                    if (hasLimit)
                    {
                        querytbalename = String.Format("SELECT * FROM '{0}' LIMIT {1}", TableName, limit);
                    }
                    SQLiteCommand command = new SQLiteCommand(querytbalename, connection);
                    SQLiteDataAdapter odbcDataAdapter_Object = new SQLiteDataAdapter(command);
                    DataTable tableData = new DataTable();
                    odbcDataAdapter_Object.Fill(tableData);
                    odbcDataAdapter_Object.Dispose();
                    connection.Close();
                    Tables = tableData;
                    RowCount = tableData.Rows.Count;
                    Columns.Clear();
                    for (int i = 0; i < Tables.Columns.Count; i++)
                    {
                        Columns.Add(Tables.Columns[i].Caption);
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
                return 4;
            }
        }

        private int LoadSplitMode()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(SQLiteConnectionString))
                {
                    connection.Open();
                    String querytbalename = String.Format("SELECT * FROM '{0}'", TableName);
                    SQLiteCommand command = new SQLiteCommand(querytbalename, connection);
                    SQLiteDataAdapter odbcDataAdapter_Object = new SQLiteDataAdapter(command);
                    DataTable tableData = new DataTable();
                    odbcDataAdapter_Object.Fill(tableData);
                    odbcDataAdapter_Object.Dispose();
                    connection.Close();
                    Columns.Clear();

                    DataTable tableSplit = new DataTable("mylan");
                    if (tableData != null && tableData.Columns.Count > 0)
                    {

                        //Update field name
                        for (int clone = 1; clone <= NumberOfStepSplit; clone++)
                        {
                            for (int i = 1; i <= tableData.Columns.Count; i++)
                            {
                                Columns.Add(PrefixOfFieldNameSplit + i + "_" + clone);
                                DataColumn dataColumn = new DataColumn(Columns[Columns.Count - 1]);
                                dataColumn.Caption = tableData.Columns[i - 1].Caption;
                                tableSplit.Columns.Add(dataColumn);
                            }
                        }
                        //END Update field name

                        //Split table
                        int indexClone = 0;
                        int columnCount = tableData.Columns.Count;
                        DataRow dataRow = tableSplit.NewRow();
                        RowCount = tableData.Rows.Count;
                        for (int rowIndex = 0; rowIndex < tableData.Rows.Count; rowIndex++)
                        {
                            for (int i = 0; i < columnCount; i++)
                            {
                                dataRow[columnCount * indexClone + i] = tableData.Rows[rowIndex].ItemArray[i];
                            }

                            if (indexClone == NumberOfStepSplit - 1 || (rowIndex == tableData.Rows.Count - 1))
                            {
                                tableSplit.Rows.Add(dataRow);
                            }

                            if (indexClone < NumberOfStepSplit - 1)
                            {
                                indexClone++;
                            }
                            else
                            {
                                dataRow = tableSplit.NewRow();
                                indexClone = 0;
                            }
                        }
                        //END Split table
                    }
                    Tables = tableSplit;

                    return 0;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
                return 4;
            }
        }

        #endregion Methods
    }
}
