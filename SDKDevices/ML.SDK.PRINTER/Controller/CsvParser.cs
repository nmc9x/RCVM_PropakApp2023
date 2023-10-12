using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.PRINTER.Controller
{
    public static class CsvParser
    {
        public static string ParseLine(string line)
        {
            List<string> fields = new List<string>();
            StringBuilder fieldBuilder = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == ',' && !inQuotes)
                {
                    fields.Add(fieldBuilder.ToString());
                    fieldBuilder.Clear();
                }
                else if (c == '"')
                {
                    if (!inQuotes)
                    {
                        inQuotes = true;
                    }
                    else
                    {
                        if (i < line.Length - 1 && line[i + 1] == '"')
                        {
                            fieldBuilder.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                }
                else
                {
                    fieldBuilder.Append(c);
                }
            }

            if (fieldBuilder.Length > 0 || line[line.Length - 1] == ',')
            {
                fields.Add(fieldBuilder.ToString());
            }
            string res = "";
            for (int i = 0; i < fields.Count; i++)
            {
                res = (i == (fields.Count - 1)) ? (res + fields[i].ToString()) : (res += fields[i].ToString() + ";");
            }
            return res;
        }
    }
}
