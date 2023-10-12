using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ML.SDK.PRINTER.Controller
{
    public abstract class SocketClient
    {
        

       
        public abstract bool Connect();
        public abstract Task Send(string message);
        public abstract string Receive();
        public abstract Task StopPrinting();
        public abstract Task StartAndLoadData();
        public abstract void Disconnect();
    }
}
