using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doopec.Utils.Transport;

namespace RTPSMonitor
{
    class Monitor
    {
        static void Main(string[] args)
        {
            UDPReceiver rec = new UDPReceiver(new Uri("udp://172.16.0.169:9999"), 256);
            rec.Start();

            Console.WriteLine("Enter finish to end");
            Console.ReadLine();
            rec.Close();
            rec.Dispose();
        }
    }
}
