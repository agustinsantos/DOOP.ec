using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Doopec.Serializer;
using Rtps.Structure.Types;
using Rtps.Messages.Submessages.Elements;
using Doopec.Rtps.Messages;
using Mina.Core.Buffer;
using System.Net;
using Doopec.Serializer.Attributes;
using Doopec.Rtps.Encoders;
using org.omg.dds.type;
using Rtps.Discovery.Spdp;

namespace Rtps.Tests.Encoders
{
    [TestClass]
    public class MessageElementsTests
    {
        private const int CDRHeaderSize = 2 + 2;
        private const int PL_CDRHeaderSize = 2 + 2 + 4 + 4;


        [TestInitialize]
        public void SetUp()
        {
            List<System.Type> rootTypes = new List<System.Type>();
            rootTypes.Add(typeof(SPDPdiscoveredParticipantData));

            ITypeSerializer[] customSerializers = new ITypeSerializer[]
            {
                new LocatorSerializer(),
                new EntityIdSerializer(),
                new GuidPrefixSerializer(),
                new GUIDSerializer(),
                new VendorIdSerializer(),
                new ProtocolIdSerializer(),
                new ProtocolVersionSerializer(),
            };

            Serializer.Initialize(rootTypes, customSerializers);
        }

        #region LOCATOR

        #region CDR Tests
        [TestMethod]
        public void TestLocatorIpV4CDR_BE()
        {
            Encapsulation Scheme = Encapsulation.CDR_BE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("10.20.30.40"), 2700);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 00 00 00 00 00 00 01 00 00 0A 8C 00 00 00 00 00 00 00 00 00 00 00 00 0A 14 1E 28", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLocatorIpV4CDR_LE()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("10.20.30.40"), 2700);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 01 00 00 00 8C 0A 00 00 00 00 00 00 00 00 00 00 00 00 00 00 0A 14 1E 28", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLocatorIpV6CDR_BE()
        {
            Encapsulation Scheme = Encapsulation.CDR_BE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("::1"), 2700);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 00 00 00 00 00 00 02 00 00 0A 8C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLocatorIpV6CDR_LE()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("::1"), 2700);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 02 00 00 00 8C 0A 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }
        [TestMethod]
        public void TestLocatorIpV6CDR_BE2()
        {
            Encapsulation Scheme = Encapsulation.CDR_BE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("FF00:4501:0:0:0:0:0:32"), 2700);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 00 00 00 00 00 00 02 00 00 0A 8C FF 00 45 01 00 00 00 00 00 00 00 00 00 00 00 32", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLocatorIpV6CDR_LE2()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("FF00:4501:0:0:0:0:0:32"), 2700);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 02 00 00 00 8C 0A 00 00 FF 00 45 01 00 00 00 00 00 00 00 00 00 00 00 32", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLocatorFromSample1()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("172.16.0.128"), 36945);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 01 00 00 00 51 90 00 00 00 00 00 00 00 00 00 00 00 00 00 00 AC 10 00 80", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLocatorFromSample2()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("239.255.0.1"), 9652);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 01 00 00 00 B4 25 00 00 00 00 00 00 00 00 00 00 00 00 00 00 EF FF 00 01", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLocatorFromSample3()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 16 + 4 + 4 + CDRHeaderSize;

            Locator v1 = new Locator(IPAddress.Parse("127.0.0.1"), 12345);
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<Locator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 01 00 00 00 39 30 00 00 00 00 00 00 00 00 00 00 00 00 00 00 7F 00 00 01", buffer.GetHexDump());
            Locator v2 = EncapsulationManager.Deserialize<Locator>(buffer);

            Assert.AreEqual(v1, v2);
        }
        #endregion CDR Tests

        #region PL_CDR Tests
        [TestMethod]
        public void TestLocatorIpV4PL_CDR__BE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_BE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("10.20.30.40"), 2700) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 02 00 00 00 48 00 18 00 00 00 01 00 00 0A 8C 00 00 00 00 00 00 00 00 00 00 00 00 0A 14 1E 28 00 01 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorIpV4PL_CDR_LE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_LE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("10.20.30.40"), 2700) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 03 00 00 48 00 18 00 01 00 00 00 8C 0A 00 00 00 00 00 00 00 00 00 00 00 00 00 00 0A 14 1E 28 01 00 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorIpV6PL_CDR_BE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_BE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("::1"), 2700) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 02 00 00 00 48 00 18 00 00 00 02 00 00 0A 8C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 01 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorIpV6PL_CDR_LE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_LE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("::1"), 2700) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 03 00 00 48 00 18 00 02 00 00 00 8C 0A 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 01 00 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorIpV6PL_CDR_BE2()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_BE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("FF00:4501:0:0:0:0:0:32"), 2700) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 02 00 00 00 48 00 18 00 00 00 02 00 00 0A 8C FF 00 45 01 00 00 00 00 00 00 00 00 00 00 00 32 00 01 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorIpV6PL_CDR_LE2()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_LE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("FF00:4501:0:0:0:0:0:32"), 2700) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 03 00 00 48 00 18 00 02 00 00 00 8C 0A 00 00 FF 00 45 01 00 00 00 00 00 00 00 00 00 00 00 32 01 00 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorFromSample1PL_CDR_LE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_LE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("172.16.0.128"), 36945) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 03 00 00 48 00 18 00 01 00 00 00 51 90 00 00 00 00 00 00 00 00 00 00 00 00 00 00 AC 10 00 80 01 00 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorFromSample2PL_CDR_LE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_LE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("239.255.0.1"), 9652) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 03 00 00 48 00 18 00 01 00 00 00 B4 25 00 00 00 00 00 00 00 00 00 00 00 00 00 00 EF FF 00 01 01 00 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }

        [TestMethod]
        public void TestLocatorFromSample3PL_CDR_LE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_LE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("127.0.0.1"), 12345) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);
            Assert.AreEqual("00 03 00 00 48 00 18 00 01 00 00 00 39 30 00 00 00 00 00 00 00 00 00 00 00 00 00 00 7F 00 00 01 01 00 00 00", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1.Locator, v2.Locator);
        }
        #endregion PL_CDR Tests

        #endregion LOCATOR

        #region GUID
        #region CDR Tests
        [TestMethod]
        public void TestGUIDCDR_BE()
        {
            Encapsulation Scheme = Encapsulation.CDR_BE;
            int bufferSize = 16 + CDRHeaderSize;

            GUID v1 = new GUID(new GuidPrefix(new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xA, 0xB }),
                               new EntityId(new byte[] { 0x0, 0x1, 0x2 }, EntityKinds.BUILT_IN_PARTICIPANT));
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<GUID>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 00 00 00 00 01 02 03 04 05 06 07 08 09 0A 0B 00 01 02 C1", buffer.GetHexDump());
            GUID v2 = EncapsulationManager.Deserialize<GUID>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestGUIDCDR_LE()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 16 + CDRHeaderSize;

            GUID v1 = new GUID(new GuidPrefix(new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xA, 0xB }),
                               new EntityId(new byte[] { 0x0, 0x1, 0x2 }, EntityKinds.BUILT_IN_PARTICIPANT));
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<GUID>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 00 01 02 03 04 05 06 07 08 09 0A 0B 00 01 02 C1", buffer.GetHexDump());
            GUID v2 = EncapsulationManager.Deserialize<GUID>(buffer);

            Assert.AreEqual(v1, v2);
        }
        #endregion CDR Tests
        #endregion GUID

        #region VendorId
        #region CDR Tests
        [TestMethod]
        public void TestVendorIdCDR_BE()
        {
            Encapsulation Scheme = Encapsulation.CDR_BE;
            int bufferSize = 2 + CDRHeaderSize;

            VendorId v1 = VendorId.Doopec;
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<VendorId>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 00 00 00 01 0F", buffer.GetHexDump());
            VendorId v2 = EncapsulationManager.Deserialize<VendorId>(buffer);

            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestVendorIDCDR_LE()
        {
            Encapsulation Scheme = Encapsulation.CDR_LE;
            int bufferSize = 2 + CDRHeaderSize;

            VendorId v1 = VendorId.Doopec; ;
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<VendorId>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 01 00 00 01 0F", buffer.GetHexDump());
            VendorId v2 = EncapsulationManager.Deserialize<VendorId>(buffer);

            Assert.AreEqual(v1, v2);
        }
        #endregion CDR Tests
        #endregion VendorId

        #region SPDPdiscoveredParticipantData
        [TestMethod]
        public void TestSPDPdiscoveredParticipantDataPL_CDR_BE()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_BE;
            int bufferSize = 180;

            SPDPdiscoveredParticipantData v1 = new SPDPdiscoveredParticipantData();
            v1.ProtocolVersion = ProtocolVersion.PROTOCOLVERSION_2_1;
            v1.VendorId = VendorId.Doopec;
            v1.Key = GUID.GUID_UNKNOWN;
            v1.DefaultMulticastLocatorList = new List<Locator>() { new Locator(IPAddress.Parse("10.20.30.40"), 2700) };
            v1.DefaultUnicastLocatorList = new List<Locator>() { new Locator(IPAddress.Parse("10.20.30.40"), 2700) };
            v1.MetatrafficMulticastLocatorList = new List<Locator>() { new Locator(IPAddress.Parse("10.20.30.40"), 2700) };
            v1.MetatrafficUnicastLocatorList = new List<Locator>() { new Locator(IPAddress.Parse("10.20.30.40"), 2700) };

            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<SPDPdiscoveredParticipantData>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            //Assert.AreEqual("00 00 00 00 00 00 00 01 00 00 0A 8C 00 00 00 00 00 00 00 00 00 00 00 00 0A 14 1E 28", buffer.GetHexDump());
            SPDPdiscoveredParticipantData v2 = EncapsulationManager.Deserialize<SPDPdiscoveredParticipantData>(buffer);

            Assert.AreEqual(v1, v2);
        }
        #endregion
    }


    #region Sample Classes

    public class ClassWithLocator
    {
        [ID(0x0048)]
        public Locator Locator;
    }
    public class ClassWithGUID
    {
        [ID(0x0050)]
        [Key]
        public GUID Key { get; set; }

    }
    public class ClassWithVendorId
    {
        [ID(0x0016)]
        public VendorId VendorId { get; set; }

    }
    #endregion Sample Classes

}
