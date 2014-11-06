using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.Utils.Transport;
using Rtps.Messages;
using Rtps.Messages.Submessages.Elements;
using Data = Rtps.Messages.Submessages.Data;
using Rtps.Structure.Types;
using Doopec.Utils.Network.Encoders;
using Mina.Core.Buffer;

namespace Rtps.Tests.Transport
{
    [TestClass]
    public class UDPTransportTests
    {
        UDPReceiver rec;
        UDPTransmitter trans;

        [TestInitialize]
        public void SetUp()
        {
            rec = new UDPReceiver(new Uri("udp://localhost:9999"), 256);
            rec.Start();
            trans = new UDPTransmitter(new Uri("udp://localhost:9999"), 256);
            trans.Start();
        }

        [TestCleanup]
        public void TearDown()
        {
            rec.Close();
            rec.Dispose();
            trans.Close();
        }

        [TestMethod]
        public void TestMethod1()
        {
            int number = 10;

            Message msg = new Message();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            msg.SubMessages.Clear();
            byte[] buff = BitConverter.GetBytes(number);
            SerializedPayload payload = new SerializedPayload();
            //TODO payload.DataEncapsulation = buff.EncapsuleCDRData(BitConverter.IsLittleEndian ? ByteOrder.BigEndian : ByteOrder.BigEndian);
            throw new NotImplementedException();
            msg.SubMessages.Add(new Data(id1, id2, 1, null, payload));

            trans.SendMessage(msg);
        }
    }
}
