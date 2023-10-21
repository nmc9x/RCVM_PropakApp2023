using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML.Common.Controller
{
    public class TcpClientHelper
    {
        private TcpClient _client;
        private NetworkStream _networkStream;
        private Thread _sendThread;
        private Thread _receiveThread;
        private bool _isConnected = false;
        private readonly int _sendIntervalMilliseconds;

        public event Action<string> MessageReceived;

        public bool IsConnected => _isConnected;

        public TcpClientHelper(string serverIp, int serverPort, int sendIntervalMilliseconds)
        {
            _client = new TcpClient(serverIp, serverPort);
            _networkStream = _client.GetStream();
            _isConnected = true;

            _sendThread = new Thread(SendLoop);
            _receiveThread = new Thread(ReceiveLoop);

            //_sendThread.Start();
            _receiveThread.Start();
            _sendIntervalMilliseconds = sendIntervalMilliseconds;
        }

        public void Send(string message)
        {
            if (!_isConnected)
                return;

            var data = Encoding.ASCII.GetBytes(message);
            _networkStream.Write(data, 0, data.Length);
        }

        public void Disconnect()
        {
            _isConnected = false;
            _networkStream?.Close();
            _client?.Close();
        }

        private void SendLoop()
        {
            while (_isConnected)
            {
                // Logic để gửi dữ liệu
            }
        }

        private void ReceiveLoop()
        {
            var buffer = new byte[1024];
            while (_isConnected)
            {
                try
                {
                    var bytesRead = _networkStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        Disconnect();
                        return;
                    }

                    var message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    MessageReceived?.Invoke(message);
                }
                catch
                {
                    // Xử lý các ngoại lệ có thể xảy ra
                    Disconnect();
                    return;
                }
                Thread.Sleep(1);
            }
        }

        public void StartSending(string message)
        {
            if (!_isConnected)
                return;

            var sendThread = new Thread(() =>
            {
                while (_isConnected)
                {
                    //Console.Write("Enter message to send (or 'exit' to quit): ");
                   // var message = Console.ReadLine();

                    //if (string.Equals(message, "exit", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    Disconnect();
                    //    return;
                    //}

                    Send(message);
                    Thread.Sleep(_sendIntervalMilliseconds); // Tạm dừng để chờ đến lần gửi tiếp theo
                }
            });

            sendThread.Start();
            sendThread.Join();
        }
    }
}
