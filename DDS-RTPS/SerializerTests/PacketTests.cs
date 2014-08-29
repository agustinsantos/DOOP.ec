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
    [TestClass]
    public class PacketTests
    {
        [TestInitialize]
        public void SetUp()
        {
            var rootTypes = typeof(U8Packet).Assembly.GetTypes().Where(t => PacketAttribute.IsCompatible(t))
                //.Concat(new Type[] { typeof(SimpleClass), typeof(SimpleClass2) })
                .ToArray();

            ITypeSerializer[] customSerializers = new ITypeSerializer[0];

            Serializer.Initialize(rootTypes, customSerializers);
        }

        [TestMethod]
        public void TestU8Packet()
        {
            U8Packet v1 = new U8Packet(0xA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(byte) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            U8Packet v2 = Serializer.Deserialize<U8Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestU16Packet()
        {
            U16Packet v1 = new U16Packet(0xAB);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(ushort) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            U16Packet v2 = Serializer.Deserialize<U16Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestU32Packet()
        {
            U32Packet v1 = new U32Packet(0xABA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(uint) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            U32Packet v2 = Serializer.Deserialize<U32Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestU64Packet()
        {
            U64Packet v1 = new U64Packet(0xABCD);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(ulong) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            U64Packet v2 = Serializer.Deserialize<U64Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestS8Packet()
        {
            S8Packet v1 = new S8Packet(0xA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(sbyte) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            S8Packet v2 = Serializer.Deserialize<S8Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestS16Packet()
        {
            S16Packet v1 = new S16Packet(0xAB);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(short) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            S16Packet v2 = Serializer.Deserialize<S16Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestS32Packet()
        {
            S32Packet v1 = new S32Packet(0xABA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(int) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            S32Packet v2 = Serializer.Deserialize<S32Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestS64Packet()
        {
            S64Packet v1 = new S64Packet(0xABCD);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(long) + 2);
            Serializer.Serialize(buffer, v1);

            buffer.Rewind();
            S64Packet v2 = Serializer.Deserialize<S64Packet>(buffer);
            Assert.AreEqual(v1, v2);
        }
    }
}
