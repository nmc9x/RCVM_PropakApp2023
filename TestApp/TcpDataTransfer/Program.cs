using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataTransfer
{

    #region MyRegion
    class SocketClient
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private readonly string _serverIP;
        private readonly int _serverPort;

        public SocketClient(string serverIP, int serverPort)
        {
            _serverIP = serverIP;
            _serverPort = serverPort;
        }

        public bool Connect()
        {
            try
            {
                _client = new TcpClient(_serverIP, _serverPort);
                _stream = _client.GetStream();
#if DEBUG
                Console.WriteLine("Connected");
#endif
                return true;


            }
            catch (Exception)
            {
#if DEBUG
                Console.WriteLine("Connected fail");
#endif
                return false;
            }
           
            
        }

        public async Task Send(string message)
        {
            if (_stream == null)
                throw new InvalidOperationException("Not connected to server.");
            byte[] data = Encoding.ASCII.GetBytes((char)2 + message + (char)3);
            _stream.Write(data, 0, data.Length);
            Console.WriteLine($"Sent Data: {message}");
            await Task.Delay(100);
        }

        public string Receive()
        {
            if (_stream == null)
                throw new InvalidOperationException("Not connected to server.");
            byte[] data = new byte[1024];
            int bytes = _stream.Read(data, 0, data.Length);
            var receivedMessage = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine($"Received: {receivedMessage}");
            return receivedMessage;
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
            Console.WriteLine($"Disconnected from {_serverIP}:{_serverPort}");
        }

        #region SendCommand
        public void SendControlCommand()
        {

        }
        public void SendDataCommand()
        {

        }
        #endregion
        public static async Task StopStep()
        {
            SocketClient client = new SocketClient("192.168.15.154", 12500);
            client.Connect();
            await client.Send("STOP");
        }
        public static async Task ReadyStep()
        {
            SocketClient client = new SocketClient("192.168.15.154", 12500);
            var filePath = "C:\\Users\\minhchau.nguyen\\Documents\\MyLanGroup\\Projects\\Propak\\output.csv";
            string[] tableData = File.ReadAllLines(filePath);
            string command;
            string readySts = (char)2 + "RYES" + (char)3 + (char)2 + "STAR;READY" + (char)3;

            client.Connect();

            #region ConnectAsync

            bool isReady = false;
            while (!isReady)
            {
                await client.Send("STAR;TestTemplate;1;1");
                if (client.Receive() == readySts)
                {
                    isReady = true;
                }
                else
                {
                    await Task.Delay(1000);
                }
               
            }

            #endregion

            #region ProcessData
            Console.WriteLine("Start send data...");
            for (int i = 1; i < tableData.Length; i++)
            {
                string formattedData = CsvParser.ParseLine(tableData[i]);
                command = "DATA;" + formattedData;
                await client.Send(command);
            }
            client.Disconnect();

            #endregion


        }
        static async Task Main(string[] args)
        {
            try
            {
                await ReadyStep();

                var key = Console.ReadKey();
                if(key.KeyChar == 's')
                {
                    await StopStep();
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
    

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
    #endregion

    

    /*
    class Program
    {
        public static void CreateCsvFile(string filePath, int numberOfRecords)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Write header
                sw.WriteLine("\"name\",\"age\",\"address\"");

                for (int i = 1; i <= numberOfRecords; i++)
                {
                    sw.WriteLine($"\"Name_{i}\",\"{20 + (i % 50)}\",\"Some Street, Some City\"");
                }
            }
        }
        static void Main()
        {
            string filePath = "C:\\Users\\minhchau.nguyen\\Documents\\MyLanGroup\\Projects\\Propak\\output.csv";
            int numberOfRecords = 1000000;

            CreateCsvFile(filePath, numberOfRecords);

            Console.WriteLine($"CSV file with {numberOfRecords} records created at {filePath}");
        }
    }*/
}
