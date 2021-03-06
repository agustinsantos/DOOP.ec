﻿using Doopec.Rtps.Messages;
using Doopec.Serializer;
using Doopec.Serializer.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTests
{
    /// <summary>
    /// In addition to the encapsulation schema identifier, the OMG CDR encapsulation specifies a 16-bit options field followed
    /// by the data encoded using CDR. The options field is left for future extensions. This version of the specification should
    /// not interpret it when it reads it.
    /// 0...2...........8...............16..............24..............32
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |               CDR_BE          |         ushort options        |
    /// +---------------+---------------+---------------+---------------+
    /// ~               Serialized Data (CDR Big Endian)                ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// 
    /// 0...2...........8...............16..............24..............32
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |               CDR_LE          |           ushort options      |
    /// +---------------+---------------+---------------+---------------+
    /// ~               Serialized Data (CDR Little Endian)             ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// 
    /// Where 
    /// CDR_BE {0x00, 0x00} means OMG CDR Big Endian
    /// CDR_LE {0x00, 0x01} means OMG CDR Little Endian
    /// </summary>
    [TestClass]
    public class CDREncapsulationTests
    {
        [TestInitialize]
        public void SetUp()
        {
            var rootTypes = typeof(U8Packet).Assembly.GetTypes().Where(t => PacketAttribute.IsCompatible(t)).ToArray();

            ITypeSerializer[] customSerializers = new ITypeSerializer[0];

            Serializer.Initialize(rootTypes, customSerializers);
        }

        private const int CDRHeaderSize = 2 + 2;
        private const int ArrayHeader = sizeof(int);

        #region CDREncapsulation Little-Endian

        [TestMethod]
        public void TestBoolPacketLE()
        {
            BoolPacket v1 = new BoolPacket(true);
            int bufferSize = sizeof(bool) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 01", buffer.GetHexDump());
            BoolPacket v2 = CDREncapsulation.Deserialize<BoolPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestCharPacketLE()
        {
            CharPacket v1 = new CharPacket('A');
            int bufferSize = sizeof(char) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 41 00", buffer.GetHexDump());
            CharPacket v2 = CDREncapsulation.Deserialize<CharPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestU8PacketLE()
        {
            U8Packet v1 = new U8Packet(0xA);
            int bufferSize = sizeof(byte) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 0A", buffer.GetHexDump());
            U8Packet v2 = CDREncapsulation.Deserialize<U8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestU16PacketLE()
        {
            U16Packet v1 = new U16Packet(0xAB);
            int bufferSize = sizeof(ushort) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 AB 00", buffer.GetHexDump());
            U16Packet v2 = CDREncapsulation.Deserialize<U16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestU32PacketLE()
        {
            U32Packet v1 = new U32Packet(0xABA);
            int bufferSize = sizeof(uint) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 BA 0A 00 00", buffer.GetHexDump());
            U32Packet v2 = CDREncapsulation.Deserialize<U32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestU64PacketLE()
        {
            U64Packet v1 = new U64Packet(0xABCDEF);
            int bufferSize = sizeof(ulong) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 EF CD AB 00 00 00 00 00", buffer.GetHexDump());
            U64Packet v2 = CDREncapsulation.Deserialize<U64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS8PacketLE1()
        {
            S8Packet v1 = new S8Packet(-1);
            int bufferSize = sizeof(sbyte) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 FF", buffer.GetHexDump());
            S8Packet v2 = CDREncapsulation.Deserialize<S8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS8PacketLE2()
        {
            S8Packet v1 = new S8Packet(+1);
            int bufferSize = sizeof(sbyte) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 01", buffer.GetHexDump());
            S8Packet v2 = CDREncapsulation.Deserialize<S8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS16PacketLE1()
        {
            S16Packet v1 = new S16Packet(-10);
            int bufferSize = sizeof(short) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 F6 FF", buffer.GetHexDump());
            S16Packet v2 = CDREncapsulation.Deserialize<S16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS16PacketLE2()
        {
            S16Packet v1 = new S16Packet(+10);
            int bufferSize = sizeof(short) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 0A 00", buffer.GetHexDump());
            S16Packet v2 = CDREncapsulation.Deserialize<S16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }
        [TestMethod]
        public void TestS32PacketLE1()
        {
            S32Packet v1 = new S32Packet(-0xABA);
            int bufferSize = sizeof(int) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 46 F5 FF FF", buffer.GetHexDump());
            S32Packet v2 = CDREncapsulation.Deserialize<S32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS32PacketLE2()
        {
            S32Packet v1 = new S32Packet(0xABA);
            int bufferSize = sizeof(int) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 BA 0A 00 00", buffer.GetHexDump());
            S32Packet v2 = CDREncapsulation.Deserialize<S32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS64PacketLE1()
        {
            S64Packet v1 = new S64Packet(-0xABCD);
            int bufferSize = sizeof(long) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 33 54 FF FF FF FF FF FF", buffer.GetHexDump());
            S64Packet v2 = CDREncapsulation.Deserialize<S64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS64PacketLE2()
        {
            S64Packet v1 = new S64Packet(0xABCD);
            int bufferSize = sizeof(long) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 CD AB 00 00 00 00 00 00", buffer.GetHexDump());
            S64Packet v2 = CDREncapsulation.Deserialize<S64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestSinglePacketLE()
        {
            SinglePacket v1 = new SinglePacket(0.1f);
            int bufferSize = sizeof(float) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 CD CC CC 3D", buffer.GetHexDump());
            SinglePacket v2 = CDREncapsulation.Deserialize<SinglePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }


        [TestMethod]
        public void TestDoublePacketLE()
        {
            DoublePacket v1 = new DoublePacket(0.1);
            int bufferSize = sizeof(double) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 9A 99 99 99 99 99 B9 3F", buffer.GetHexDump());
            DoublePacket v2 = CDREncapsulation.Deserialize<DoublePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestBoolSequencePacketLE()
        {
            BoolSequencePacket v1 = new BoolSequencePacket(new bool[] { true, false, false, true });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 04 00 00 00 01 00 00 01", buffer.GetHexDump());
            BoolSequencePacket v2 = CDREncapsulation.Deserialize<BoolSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestShortSequencePacketLE()
        {
            ShortSequencePacket v1 = new ShortSequencePacket(new short[] { 0xFA1, 0xFF0, 0xB2F, 0x001 });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 04 00 00 00 A1 0F F0 0F 2F 0B 01 00", buffer.GetHexDump());
            ShortSequencePacket v2 = CDREncapsulation.Deserialize<ShortSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEnumSequencePacketLE()
        {
            EnumSequencePacket v1 = new EnumSequencePacket(new MyEnum[] { MyEnum.Four, MyEnum.Three, MyEnum.Three, MyEnum.Zero, MyEnum.One, MyEnum.Five });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 06 00 00 00 04 00 00 00 03 00 00 00 03 00 00 00 00 00 00 00 01 00 00 00 05 00 00 00", buffer.GetHexDump());
            EnumSequencePacket v2 = CDREncapsulation.Deserialize<EnumSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestIntSequencePacketLE()
        {
            IntSequencePacket v1 = new IntSequencePacket(new int[] { 0xFFA1F0, 0xFF230F, 0xB2000F, 0xFFFFF01 });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 04 00 00 00 F0 A1 FF 00 0F 23 FF 00 0F 00 B2 00 01 FF FF 0F", buffer.GetHexDump());
            IntSequencePacket v2 = CDREncapsulation.Deserialize<IntSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyBoolSequencePacketLE()
        {
            BoolSequencePacket v1 = new BoolSequencePacket(new bool[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 00 00 00 00", buffer.GetHexDump());
            BoolSequencePacket v2 = CDREncapsulation.Deserialize<BoolSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyShortSequencePacketLE()
        {
            ShortSequencePacket v1 = new ShortSequencePacket(new short[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 00 00 00 00", buffer.GetHexDump());
            ShortSequencePacket v2 = CDREncapsulation.Deserialize<ShortSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyEnumSequencePacketLE()
        {
            EnumSequencePacket v1 = new EnumSequencePacket(new MyEnum[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 00 00 00 00", buffer.GetHexDump());
            EnumSequencePacket v2 = CDREncapsulation.Deserialize<EnumSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyIntSequencePacketLE()
        {
            IntSequencePacket v1 = new IntSequencePacket(new int[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 01 00 00 00 00 00 00", buffer.GetHexDump());
            IntSequencePacket v2 = CDREncapsulation.Deserialize<IntSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }
        #endregion

        #region CDREncapsulation Big-Endian
        [TestMethod]
        public void TestBoolPacketBE()
        {
            BoolPacket v1 = new BoolPacket(true);
            int bufferSize = sizeof(bool) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 01", buffer.GetHexDump());
            BoolPacket v2 = CDREncapsulation.Deserialize<BoolPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestCharPacketBE()
        {
            CharPacket v1 = new CharPacket('A');
            int bufferSize = sizeof(char) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 41", buffer.GetHexDump());
            CharPacket v2 = CDREncapsulation.Deserialize<CharPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestU8PacketBE()
        {
            U8Packet v1 = new U8Packet(0xA);
            int bufferSize = sizeof(byte) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 0A", buffer.GetHexDump());
            U8Packet v2 = CDREncapsulation.Deserialize<U8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }


        [TestMethod]
        public void TestU16PacketBE()
        {
            U16Packet v1 = new U16Packet(0xAB);
            int bufferSize = sizeof(ushort) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 AB", buffer.GetHexDump());
            U16Packet v2 = CDREncapsulation.Deserialize<U16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }


        [TestMethod]
        public void TestU32PacketBE()
        {
            U32Packet v1 = new U32Packet(0xABA);
            int bufferSize = sizeof(uint) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 0A BA", buffer.GetHexDump());
            U32Packet v2 = CDREncapsulation.Deserialize<U32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestU64PacketBE()
        {
            U64Packet v1 = new U64Packet(0xABCDEF);
            int bufferSize = sizeof(ulong) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 00 00 AB CD EF", buffer.GetHexDump());
            U64Packet v2 = CDREncapsulation.Deserialize<U64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS8PacketBE1()
        {
            S8Packet v1 = new S8Packet(-1);
            int bufferSize = sizeof(sbyte) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 FF", buffer.GetHexDump());
            S8Packet v2 = CDREncapsulation.Deserialize<S8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS8PacketBE2()
        {
            S8Packet v1 = new S8Packet(+1);
            int bufferSize = sizeof(sbyte) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 01", buffer.GetHexDump());
            S8Packet v2 = CDREncapsulation.Deserialize<S8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }


        [TestMethod]
        public void TestS16PacketBE1()
        {
            S16Packet v1 = new S16Packet(-10);
            int bufferSize = sizeof(short) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 FF F6", buffer.GetHexDump());
            S16Packet v2 = CDREncapsulation.Deserialize<S16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS16PacketBE2()
        {
            S16Packet v1 = new S16Packet(+10);
            int bufferSize = sizeof(short) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 0A", buffer.GetHexDump());
            S16Packet v2 = CDREncapsulation.Deserialize<S16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS32PacketBE1()
        {
            S32Packet v1 = new S32Packet(-0xABA);
            int bufferSize = sizeof(int) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 FF FF F5 46", buffer.GetHexDump());
            S32Packet v2 = CDREncapsulation.Deserialize<S32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS32PacketBE2()
        {
            S32Packet v1 = new S32Packet(0xABA);
            int bufferSize = sizeof(int) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 0A BA", buffer.GetHexDump());
            S32Packet v2 = CDREncapsulation.Deserialize<S32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS64PacketBE1()
        {
            S64Packet v1 = new S64Packet(-0xABCD);
            int bufferSize = sizeof(long) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 FF FF FF FF FF FF 54 33", buffer.GetHexDump());
            S64Packet v2 = CDREncapsulation.Deserialize<S64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestS64PacketBE2()
        {
            S64Packet v1 = new S64Packet(0xABCD);
            int bufferSize = sizeof(long) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 00 00 00 AB CD", buffer.GetHexDump());
            S64Packet v2 = CDREncapsulation.Deserialize<S64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestSinglePacketBE()
        {
            SinglePacket v1 = new SinglePacket(0.1f);
            int bufferSize = sizeof(float) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 3D CC CC CD", buffer.GetHexDump());
            SinglePacket v2 = CDREncapsulation.Deserialize<SinglePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }


        [TestMethod]
        public void TestDoublePacketBE()
        {
            DoublePacket v1 = new DoublePacket(0.1);
            int bufferSize = sizeof(double) + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 3F B9 99 99 99 99 99 9A", buffer.GetHexDump());
            DoublePacket v2 = CDREncapsulation.Deserialize<DoublePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestBoolSequencePacketBE()
        {
            BoolSequencePacket v1 = new BoolSequencePacket(new bool[] { true, false, false, true });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 04 01 00 00 01", buffer.GetHexDump());
            BoolSequencePacket v2 = CDREncapsulation.Deserialize<BoolSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestShortSequencePacketBE()
        {
            ShortSequencePacket v1 = new ShortSequencePacket(new short[] { 0xFA1, 0xFF0, 0xB2F, 0x001 });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 04 0F A1 0F F0 0B 2F 00 01", buffer.GetHexDump());
            ShortSequencePacket v2 = CDREncapsulation.Deserialize<ShortSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEnumSequencePacketBE()
        {
            EnumSequencePacket v1 = new EnumSequencePacket(new MyEnum[] { MyEnum.Four, MyEnum.Three, MyEnum.Three, MyEnum.Zero, MyEnum.One, MyEnum.Five });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 06 00 00 00 04 00 00 00 03 00 00 00 03 00 00 00 00 00 00 00 01 00 00 00 05", buffer.GetHexDump());
            EnumSequencePacket v2 = CDREncapsulation.Deserialize<EnumSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestIntSequencePacketBE()
        {
            IntSequencePacket v1 = new IntSequencePacket(new int[] { 0xFFA1F0, 0xFF230F, 0xB2000F, 0xFFFFF01 });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 04 00 FF A1 F0 00 FF 23 0F 00 B2 00 0F 0F FF FF 01", buffer.GetHexDump());
            IntSequencePacket v2 = CDREncapsulation.Deserialize<IntSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyBoolSequencePacketBE()
        {
            BoolSequencePacket v1 = new BoolSequencePacket(new bool[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 00", buffer.GetHexDump());
            BoolSequencePacket v2 = CDREncapsulation.Deserialize<BoolSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyShortSequencePacketBE()
        {
            ShortSequencePacket v1 = new ShortSequencePacket(new short[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 00", buffer.GetHexDump());
            ShortSequencePacket v2 = CDREncapsulation.Deserialize<ShortSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyEnumSequencePacketBE()
        {
            EnumSequencePacket v1 = new EnumSequencePacket(new MyEnum[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 00", buffer.GetHexDump());
            EnumSequencePacket v2 = CDREncapsulation.Deserialize<EnumSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }

        [TestMethod]
        public void TestEmptyIntSequencePacketBE()
        {
            IntSequencePacket v1 = new IntSequencePacket(new int[] { });
            int bufferSize = v1.Size + ArrayHeader + CDRHeaderSize;
            var buffer = ByteBufferAllocator.Instance.Allocate(bufferSize);
            CDREncapsulation.Serialize(buffer, v1, ByteOrder.BigEndian);
            Assert.AreEqual(bufferSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual("00 00 00 00 00 00 00 00", buffer.GetHexDump());
            IntSequencePacket v2 = CDREncapsulation.Deserialize<IntSequencePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(bufferSize, buffer.Position);
        }
        #endregion
    }
}
