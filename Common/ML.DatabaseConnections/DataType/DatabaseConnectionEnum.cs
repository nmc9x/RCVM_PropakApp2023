using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML.DatabaseConnections.DataType
{
    public enum ConnectionType
    {
        CSVFile,
        XLSFile,
        XLSXFile,
        AccessFile,
        TXTFile,
        SQL,
        MySQL,
        Oracle,
        XML,
        SQLite
    }

    public enum DatabaseShow
    {
        Table,
        Views,
        StoreProcedures
    }

    public enum SplitCharacter
    {
        Tab = '\t',
        Space = ' ',
        Dot = '.',
        Comma = ',',
        SemiColon = ';',
        Star = '*',
        Colon = ':',
        Hash = '#',
        AT = '@',
        Mod = '%',
        And = '&',
        Question = '?',
        VerticalBar = '|'
    }

    public enum ReadTextMode
    {
        Normal = 0,
        Schema = 1,
        //Split = 2
    }

}
