using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataTransfer
{
    public class Program
    {
        private int goodCount;
        private int failCount;

        public void CompareData(string[] sourceData, string sampleData = "CY170EQ0109", int colIndex = 2)
        {
            try
            {

                var uniqueData = new HashSet<string>();
                var duplicateData = new HashSet<string>();
                var unknownData = new HashSet<string>();
                foreach (string data in sourceData)
                {
                    var col = data.Split(',');
                    var currentValue = col[colIndex].TrimStart('"').TrimEnd('"');

                    if (currentValue == sampleData)
                    {
                        if (!uniqueData.Add(currentValue))
                        {
                            duplicateData.Add(currentValue);
                        }
                    }
                    else
                    {
                        unknownData.Add(currentValue);
                    }
                }
                string verifyCode = "";
                if (duplicateData.Count == 0 && unknownData.Count == 0)
                {
                    // good
                    goodCount++;
                    verifyCode = "0";
                    Console.WriteLine("Good");
                }
                else if (duplicateData.Count == 1 && unknownData.Count == 0)
                {
                    // duplicateData
                    failCount++;
                    verifyCode = "1";
                    Console.WriteLine("Fail: Dulicate");
                }
                else if (duplicateData.Count == 0 && unknownData.Count == 1)
                {
                    // unknown
                    failCount++;
                    verifyCode = "2";
                    Console.WriteLine("Fail: Unknown");
                }
                //count++;
                Console.WriteLine("Count Print:" + goodCount.ToString() + failCount.ToString());

            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Source + "\n" + ex.Message);
#endif
            }
        }
       
    }
    
}
