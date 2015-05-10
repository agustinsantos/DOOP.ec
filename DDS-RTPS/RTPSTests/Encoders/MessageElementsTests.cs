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
            rootTypes.Add(typeof(Locator));

            ITypeSerializer[] customSerializers = new ITypeSerializer[] { new LocatorSerializer() };

            Serializer.Initialize(rootTypes, customSerializers);
        }

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

            Assert.AreEqual("00 02 00 00 00 48 00 18 00 00 00 01 00 00 0A 8C 00 00 00 00 00 00 00 00 00 00 00 00 0A 14 1E 28", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1, v2);
        }
        [TestMethod]
        public void TestLocatorFromSamplePL()
        {
            Encapsulation Scheme = Encapsulation.PL_CDR_LE;
            int bufferSize = 16 + 4 + 4 + PL_CDRHeaderSize;

            ClassWithLocator v1 = new ClassWithLocator() { Locator = new Locator(IPAddress.Parse("127.0.0.1"), 12345) };
            SerializedPayload payload = new SerializedPayload();
            payload.DataEncapsulation = EncapsulationManager.Serialize<ClassWithLocator>(v1, Scheme);
            IoBuffer buffer = IoBuffer.Wrap(payload.DataEncapsulation.SerializedPayload);
            Assert.AreEqual(bufferSize, buffer.Remaining);

            Assert.AreEqual("00 03 00 00 48 00 18 00 01 00 00 00 39 30 00 00 00 00 00 00 00 00 00 00 00 00 00 00 7F 00 00 01", buffer.GetHexDump());
            ClassWithLocator v2 = EncapsulationManager.Deserialize<ClassWithLocator>(buffer);

            Assert.AreEqual(v1, v2);
        }
        #endregion PL_CDR Tests

    }
    #region Sample Classes

    public class ClassWithLocator
    {
        [ID(0x0048)]
        public Locator Locator;
    }

    #endregion Sample Classes

}
