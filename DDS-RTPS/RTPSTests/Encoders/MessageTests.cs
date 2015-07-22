using Doopec.Rtps.Encoders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mina.Core.Buffer;
using Rtps.Messages;
using Rtps.Messages.Submessages;
using Rtps.Messages.Submessages.Elements;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Net;

namespace Rtps.Tests.Encoders
{
    [TestClass]
    public class MessageTests
    {
        /// <summary>
        /// Tests, that reading and writing of InfoDestination is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestInfoDestination()
        {
            // Create a Message with InfoDestination
            Message m1 = new Message();
            m1.SubMessages.Add(new InfoDestination(GuidPrefix.GUIDPREFIX_UNKNOWN));

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of InfoSource is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestInfoSource()
        {
            // Create a Message with InfoSource
            Message m1 = new Message();
            m1.SubMessages.Add(new InfoSource(GuidPrefix.GUIDPREFIX_UNKNOWN));

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of Data is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestData()
        {
#if TODO
            // Create a Message with InfoSource
            Message m1 = new Message();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;
            DataEncapsulation data = DataEncapsulation.CreateInstance(new byte[] { 0, 0, 0, 0, 1, 10, 150, 255 });
            m1.SubMessages.Add(new Rtps.Messages.Submessages.Data(id1, id2, 1, null, data));

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
#endif
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Tests, that reading and writing of InfoReply is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestInfoReply()
        {
            // Create a Message with InfoReply
            Message m1 = new Message();

            Locator loc1 = new Locator(IPAddress.Loopback, 7111);
            Locator loc2 = new Locator(IPAddress.Loopback, 7222);

            IList<Locator> unicastLocators = new List<Locator>();
            unicastLocators.Add(loc1);
            IList<Locator> multicastLocators = new List<Locator>();
            multicastLocators.Add(loc2);

            m1.SubMessages.Add(new InfoReply(unicastLocators, multicastLocators));

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of InfoReplyIp4 is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestInfoReplyIp4()
        {
            // Create a Message with InfoReplyIp4
            Message m1 = new Message();

            LocatorUDPv4 lc1 = new LocatorUDPv4(IPAddress.Loopback, 7111);
            LocatorUDPv4 lc2 = LocatorUDPv4.LOCATORUDPv4_INVALID;

            m1.SubMessages.Add(new InfoReplyIp4(lc1, lc2));

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of InfoTimestamp is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestInfoTimestamp()
        {
            // Create a Message with InfoDestination
            Message m1 = new Message();
            m1.SubMessages.Add(new InfoTimestamp(123));

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of Gap is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestGap()
        {
            // Create a Message with Gap
            Message m1 = new Message();

            Gap gap = new Gap();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            gap.ReaderId = id1;
            gap.WriterId = id2;
            gap.GapStart = new SequenceNumber(10);
            gap.GapList = new SequenceNumberSet(10, new int[] { 12, 15, 19 });
            m1.SubMessages.Add(gap);

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }


        /// <summary>
        /// Tests, that reading and writing of AckNack is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestAckNack()
        {
            // Create a Message with AckNack
            Message m1 = new Message();

            AckNack ackNack = new AckNack();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            ackNack.ReaderId = id1;
            ackNack.WriterId = id2;
            ackNack.ReaderSNState = new SequenceNumberSet(10, new int[] { 12, 15, 19 });
            ackNack.Count = 10;
            m1.SubMessages.Add(ackNack);

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of Pad is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestPad()
        {
            // Create a Message with Pad
            Message m1 = new Message();

            Pad pad = new Pad();
            pad.Bytes = new byte[] { 12, 15, 19 };
            m1.SubMessages.Add(pad);

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of Heartbeat is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestHeartbeat()
        {
            // Create a Message with Heartbeat
            Message m1 = new Message();

            Heartbeat heartbeat = new Heartbeat();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            heartbeat.readerId = id1;
            heartbeat.writerId = id2;
            heartbeat.firstSN = new SequenceNumber(10);
            heartbeat.lastSN = new SequenceNumber(20);
            heartbeat.count = 5;
            m1.SubMessages.Add(heartbeat);

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of NackFrag is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestNackFrag()
        {
            // Create a Message with Heartbeat
            Message m1 = new Message();

            NackFrag nackFrag = new NackFrag();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            nackFrag.ReaderId = id1;
            nackFrag.WriterId = id2;
            nackFrag.FragmentNumberState = new SequenceNumberSet(5, new int[] { 6, 7, 21 });
            nackFrag.WriterSequenceNumber = new SequenceNumber(20);
            nackFrag.Count = 2;
            m1.SubMessages.Add(nackFrag);

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of HeartbeatFrag is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestHeartbeatFrag()
        {
            // Create a Message with Heartbeat
            Message m1 = new Message();

            HeartbeatFrag heartbeatFrag = new HeartbeatFrag();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            heartbeatFrag.ReaderId = id1;
            heartbeatFrag.WriterId = id2;
            heartbeatFrag.WriterSequenceNumber = new SequenceNumber(10);
            heartbeatFrag.LastFragmentNumber = 30;
            heartbeatFrag.Count = 50;
            m1.SubMessages.Add(heartbeatFrag);

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Tests, that reading and writing of DataFrag is symmetrical.
        /// </summary>
        [TestMethod]
        public void TestDataFrag()
        {
            // Create a Message with DataFrag
            Message m1 = new Message();

            DataFrag dataFrag = new DataFrag();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            dataFrag.ReaderId = id1;
            dataFrag.WriterId = id2;
            dataFrag.WriterSequenceNumber = new SequenceNumber(10);
            dataFrag.FragmentStartingNumber = 30;
            dataFrag.FragmentsInSubmessage = 1;
            dataFrag.FragmentSize = 4;
            dataFrag.SerializedPayload = new byte[] { 100, 10, 1, 0 };
            m1.SubMessages.Add(dataFrag);

            // Write Message to bytes1 array 
            byte[] bytes1 = Write(m1);

            // Read from bytes1 array - tests reading
            Message m2 = Read(bytes1);

            // Write the message Read to bytes2
            byte[] bytes2 = Write(m2);

            // Test, that bytes1 and bytes2 are equal
            AssertArrayEquals(bytes1, bytes2);
        }

        /// <summary>
        /// Writes a message to a byte array. 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private byte[] Write(Message m)
        {
            IoBuffer bb1 = IoBuffer.Allocate(1024);
            bb1.Order = ByteOrder.BigEndian;
            bb1.PutMessage(m);
            byte[] bytes = GetBytes(bb1);

            return bytes;
        }

        /// <summary>
        /// Gets bytes from biven buffer. Buffer is flipped and a new array is created.
        /// </summary>
        /// <param name="bb"></param>
        /// <returns></returns>
        private byte[] GetBytes(IoBuffer bb)
        {
            byte[] bytes = new byte[bb.Position];
            bb.Flip();
            bb.Get(bytes, 0, bytes.Length);

            return bytes;
        }

        /// <summary>
        /// Read message from bytes. Array is first copied to make sure
        /// resulting Message has nothing to do with original byte array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private Message Read(byte[] bytes)
        {
            byte[] __bytes = new byte[bytes.Length];
            Array.Copy(bytes, 0, __bytes, 0, bytes.Length);

            IoBuffer bb2 = IoBuffer.Wrap(__bytes);
            return bb2.GetMessage();
        }

        public void AssertArrayEquals<T>(T[] expecteds, T[] actuals)
        {
            if (expecteds == null || actuals == null)
                Assert.Fail();
            else if (expecteds.Length != actuals.Length)
                Assert.Fail();
            else
                for (int i = 0; i < expecteds.Length; i++)
                    Assert.AreEqual(expecteds[i], actuals[i]);
        }
    }
}
