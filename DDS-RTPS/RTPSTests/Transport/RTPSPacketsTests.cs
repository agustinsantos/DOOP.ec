using Common.Logging;
using Doopec.Utils.Transport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rtps.Messages;
using Rtps.Messages.Submessages;
using Rtps.Messages.Types;
using Rtps.Structure.Types;
using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using Data = Rtps.Messages.Submessages.Data;

namespace Rtps.Tests.Transport
{
    [TestClass]
    public class RTPSPacketsTests
    {
        //private static string Host = "localhost"; //192.168.4.111";
        //private static string Host = "172.16.0.111";
        private static string Host = "224.0.1.111";
        private const int Port = 9999;

        private UDPSimulator simulator;

        [TestInitialize]
        public void SetUp()
        {
            simulator = new UDPSimulator();
        }

        [TestMethod]
        public void TestPublishData()
        {
            object key = new object();
            UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);
            
            rec.MessageReceived += (s, m) =>
            {
                Message msg = m.Message;
                Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);
                Debug.WriteLine("Message Header: {0}", msg.Header);
                Assert.AreEqual(ProtocolId.PROTOCOL_RTPS, msg.Header.Protocol);
                Assert.AreEqual(VendorId.OCI, msg.Header.VendorId);
                Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1, msg.Header.Version);
                Assert.AreEqual(2, msg.SubMessages.Count);
                foreach (var submsg in msg.SubMessages)
                {
                    Debug.WriteLine("SubMessage: {0}", submsg);
                    if (submsg is Data)
                    {
                        Data d = submsg as Data;
                        foreach (var par in d.InlineQos.Value)
                            Debug.WriteLine("InlineQos: {0}", par);
                    }
                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/packet1.dat", Host, Port);
            lock (key)
            {
               Assert.IsTrue( Monitor.Wait(key, 1000),"Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }
    }
}
