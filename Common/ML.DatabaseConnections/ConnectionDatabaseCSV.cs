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

namespace ML.DatabaseConnections
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public class ConnectionDatabaseCSV : ConnectionDatabase
    {
        public ConnectionDatabaseCSV()
        {
            FirstRowHeader = true;
        }

        public ConnectionDatabaseCSV(string fullPath, int codePage)
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
                Encoding encoding = Encoding.GetEncoding(CodePage);
                using (StreamReader rd = new StreamReader(ConnectionString, encoding))
                {
                    String firstrow = rd.ReadLine();
                    columslist = firstrow.Split(',');
                    if (!FirstRowHeader)
                    {
                        for (int i = 0; i < columslist.Length; i++)
                        {
                            columslist[i] = PrefixOfFieldNameSplit + (i + 1);
                        }
                    }
                    rd.Close();
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

        private int LoadNormalMode() {
            try
            {
                Encoding encoding = Encoding.GetEncoding(CodePage);

                using (var fs = new FileStream(ConnectionString, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))//Read files still files being open and edit
                using (var rd = new StreamReader(fs, encoding))
                {
                    // read the stream
                    //...
                    String firstrow = rd.ReadLine();
                    //String[] columslist = firstrow.Split(','); //quangle20031602 comment

                    ////quangle20031602{
                    TextFieldParser parser = new TextFieldParser(new StringReader(firstrow));
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(",");
                    string[] columslist = parser.ReadFields();
                    //parser.Close();
                    //}quangle20031602


                    int columnCount = columslist.Length;
                    Columns.Clear();

                    DataTable database = new DataTable("ML");
                    if (FirstRowHeader)
                    {
                        int emptyIndex = 1;
                        foreach (String str in columslist)
                        {
                            if (str.Trim() == "")
                            {
                                Columns.Add(PrefixOfFieldNameSplit + emptyIndex);
                            }
                            else
                            {
                                //Columns.Add(str.Trim());//quangle 190207
                                //quangle 190207, donot use trim, allow user use a header like "  Header1", and GetAllFieldName() above donot use trim()
                                //so that TemplateInfo.cs, UpdateShapesAutoSplitDatabase() will generate wrong FieldName, As it not recorgize " Header1" 
                                //so it will named the FieldName is F1_n with n is belong [1,2,...,n]
                                Columns.Add(str);
                            }
                            database.Columns.Add(Columns[Columns.Count - 1]);
                            emptyIndex++;
                        }
                    }
                    else
                    {
                        int emptyIndex = 1;
                        foreach (String str in columslist)
                        {
                            Columns.Add(PrefixOfFieldNameSplit + emptyIndex);
                            database.Columns.Add(Columns[Columns.Count - 1]);
                            emptyIndex++;
                        }
                        DataRow dr = database.NewRow();
                        for (int i = 0; i < columslist.Length; i++)
                        {
                            dr[Columns[i]] = columslist[i];
                        }
                        database.Rows.Add(dr);
                    }
                    int countLine = 0;
                    while (rd.Peek() != -1)
                    {
                        if (hasLimit)
                        {
                            if (countLine >= limit)
                            {
                                break;
                            }
                        }
                        countLine++;
                        String line = rd.ReadLine();
                        //String[] columns = line.Split(','); //quangle20031602 comment

                        ////quangle20031602{
                        parser = new TextFieldParser(new StringReader(line));
                        parser.HasFieldsEnclosedInQuotes = true;
                        parser.SetDelimiters(",");
                        string[] columns = parser.ReadFields();
                        //parser.Close();
                        //}quangle20031602

                        DataRow dr = database.NewRow();
                        for (int i = 0; i < columns.Length && i < columnCount; i++)
                        {
                            dr[i] = columns[i];
                        }
                        database.Rows.Add(dr);
                    }
                    if (this.Tables != null)
                    {
                        this.Tables.Dispose();
                    }
                    this.Tables = database;
                    RowCount = database.Rows.Count;
                    rd.Close();
                }
                return 0;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message +"\n"+ ex.StackTrace);
#endif
                return 4;
            }
        }

        private int LoadSplitMode()
        {
            try
            {
                Encoding encoding = Encoding.GetEncoding(CodePage);

                using (StreamReader rd = new StreamReader(ConnectionString, encoding))
                {
                    String firstrow = rd.ReadLine();
                    //String[] columslist = firstrow.Split(',');//Linh.Tran_210205: Fix errors split database
                    //Linh.Tran_210205: Fix errors split database
                    ////quangle20031602{
                    TextFieldParser parser = new TextFieldParser(new StringReader(firstrow));
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(",");
                    string[] columslist = parser.ReadFields();
                    //parser.Close();
                    //}quangle20031602
                    //End Linh.Tran_210205: Fix errors split database
                    //
                    int columnCount = columslist.Length;
                    Columns.Clear();
                    DataRow dr = null;
                    DataTable database = new DataTable("mylan");
                    int indexClone = 0;
                    int countLine = 0;
                    if (FirstRowHeader)
                    {
                        for (int clone = 1; clone <= NumberOfStepSplit; clone++)
                        {
                            for (int i = 1; i <= columslist.Length; i++)
                            {
                                Columns.Add(PrefixOfFieldNameSplit + i + "_" + clone);
                                DataColumn dataColumn = new DataColumn(Columns[Columns.Count - 1]);
                                dataColumn.Caption = columslist[i - 1];
                                database.Columns.Add(dataColumn);
                            }
                        }
                        indexClone = -1;

                        dr = database.NewRow();
                    }
                    else
                    {
                        countLine++;
                        for (int clone = 1; clone <= NumberOfStepSplit; clone++)
                        {
                            for (int i = 1; i <= columslist.Length; i++)
                            {
                                Columns.Add(PrefixOfFieldNameSplit + i + "_" + clone);
                                DataColumn dataColumn = new DataColumn(Columns[Columns.Count - 1]);
                                dataColumn.Caption = PrefixOfFieldNameSplit + i;
                                database.Columns.Add(dataColumn);
                            }
                        }

                        dr = database.NewRow();
                        for (int i = 0; i < columslist.Length; i++)
                        {
                            dr[i] = columslist[i];
                        }
                        indexClone = 0;
                        if (rd.EndOfStream)
                        {
                            database.Rows.Add(dr);
                        }
                    }

                    while (rd.Peek() != -1)
                    {
                        countLine++;
                        String line = rd.ReadLine();
                        //String[] columns = line.Split(',');//Linh.Tran_210205: Fix errors split database
                        //Linh.Tran_210205: Fix errors split database
                        ////quangle20031602{
                        parser = new TextFieldParser(new StringReader(line));
                        parser.HasFieldsEnclosedInQuotes = true;
                        parser.SetDelimiters(",");
                        string[] columns = parser.ReadFields();
                        //parser.Close();
                        //}quangle20031602
                        //End Linh.Tran_210205: Fix errors split database
                        //
                        if (indexClone < NumberOfStepSplit - 1)
                        {
                            indexClone++;
                        }
                        else
                        {
                            dr = database.NewRow();
                            indexClone = 0;
                        }

                        for (int i = 0; i < columns.Length && i < columnCount; i++)
                        {
                            dr[columnCount * indexClone + i] = columns[i];
                        }

                        if (indexClone == NumberOfStepSplit - 1 || rd.EndOfStream)
                        {
                            database.Rows.Add(dr);
                        }
                    }
                    if (this.Tables != null)
                    {
                        this.Tables.Dispose();
                    }
                    this.Tables = database; 
                    RowCount = countLine;
                    rd.Close();
                }

                return 0;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
                return 4;
            }
        }

        private int LoadSchemaMode(DataSchemaCollection schema)
        {
            try
            {
                Encoding encoding = Encoding.GetEncoding(CodePage);
                using (StreamReader rd = new StreamReader(ConnectionString, encoding))
                {
                    String[] columslist = (from h in schema select h.FieldName).ToArray();
                    int columnCount = columslist.Length;
                    Columns.Clear();

                    DataTable database = new DataTable("mylan");
                    foreach (String str in columslist)
                    {
                        Columns.Add(str);
                        database.Columns.Add(str);
                    }
                    char splitchar = (char)_SplitChar;
                    while (rd.Peek() != -1)
                    {
                        String line = rd.ReadLine();
                        DataRow dr = database.NewRow();
                        foreach (DataSchemaModel mode in schema)
                        {
                            dr[mode.FieldName] = line.Substring(mode.Position, mode.Length);
                        }
                        database.Rows.Add(dr);
                    }
                    if (this.Tables != null)
                    {
                        this.Tables.Dispose();
                    }
                    this.Tables = database;
                    RowCount = database.Rows.Count;
                    rd.Close();
                }

                return 0;
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
