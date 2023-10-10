using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace ML.DatabaseConnections
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class ConnectionDatabaseXML : ConnectionDatabase
    {
        public ConnectionDatabaseXML()
        {
            FirstRowHeader = true;
        }

        public ConnectionDatabaseXML(string fullPath)
        {
            ConnectionString = fullPath;
            FirstRowHeader = true;
        }

        #region Properties

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
            return LoadNormalMode();
        }

        public override bool CheckMaxRowsForSupport(int maxRows)
        {

            return false;
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
            List<String> result = new List<String> { "simpleTable" };
            return result;
        }

        public override string[] GetAllFieldName()
        {
            String[] columslist = null;
            try
            {
                //
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

        private int LoadNormalMode()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(ConnectionString);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader reader = new StringReader(xmlString))
                {
                    Columns.Clear();
                    //
                    this.Tables = new DataTable("ML");
                    this.Tables.ReadXml(reader);
                    //
                    foreach(DataColumn col in this.Tables.Columns)
                    {
                        Columns.Add(col.Caption);
                    }
                    RowCount = this.Tables.Rows.Count;
                    //
                    reader.Close();
                }
                return 0;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message + "\n" + ex.StackTrace);
#endif
                return 4;
            }
        }

        public override void SaveDatabase()
        {
            try
            {
                // Write the schema and data to XML in a memory stream.
                System.IO.MemoryStream xmlStream = new System.IO.MemoryStream();
                this.Tables.WriteXml(xmlStream, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
        #endregion Methods
    }
}
