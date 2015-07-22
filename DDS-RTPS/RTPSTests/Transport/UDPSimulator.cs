using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Rtps.Tests.Transport
{
   [TestClass]
    public class UDPSimulator
    {
        public void SendUDPPacket(string fileName, string host, int port)
        {
            using (UdpClient sock = new UdpClient())
            {
                sock.Connect(host, port);
                sock.Client.EnableBroadcast = true;
                //sock.Client.ExclusiveAddressUse = false;
                byte[] data = File.ReadAllBytes(fileName);
                if (data.Length > 0)
                {
                    try
                    {
                        int len = sock.Send(data, data.Length);
                        Debug.WriteLine("Sent {0}/{1} bytes to {2}", len, data.Length, sock.Client.RemoteEndPoint.ToString());
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Exception : " + e);
                    }
                }
            }
        }
    }
}
