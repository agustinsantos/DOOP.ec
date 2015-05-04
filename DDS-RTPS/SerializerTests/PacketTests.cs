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

            var rootTypes = typeof(U8Packet).Assembly.GetTypes().Where(t => PacketAttribute.IsCompatible(t)).ToArray();

            ITypeSerializer[] customSerializers = new ITypeSerializer[0];

            //Serializer.Initialize(rootTypes, customSerializers);
            Serializer.Initialize(typeof(MyClassList));
        }

        [TestMethod]
        public void TestBoolPacket()
        {
            BoolPacket v1 = new BoolPacket(true);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(bool));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(bool), buffer.Position);

            buffer.Rewind();
            BoolPacket v2 = Serializer.Deserialize<BoolPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(bool), buffer.Position);
        }

        [TestMethod]
        public void TestCharPacket()
        {
            CharPacket v1 = new CharPacket('A');
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(char));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(char), buffer.Position);

            buffer.Rewind();
            CharPacket v2 = Serializer.Deserialize<CharPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(char), buffer.Position);
        }

        [TestMethod]
        public void TestU8Packet()
        {
            U8Packet v1 = new U8Packet(0xA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(byte));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(byte), buffer.Position);

            buffer.Rewind();
            U8Packet v2 = Serializer.Deserialize<U8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(byte), buffer.Position);
        }

        [TestMethod]
        public void TestU16Packet()
        {
            U16Packet v1 = new U16Packet(0xAB);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(ushort));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(ushort), buffer.Position);

            buffer.Rewind();
            U16Packet v2 = Serializer.Deserialize<U16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(ushort), buffer.Position);
        }

        [TestMethod]
        public void TestU32Packet()
        {
            U32Packet v1 = new U32Packet(0xABA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(uint));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(uint), buffer.Position);

            buffer.Rewind();
            U32Packet v2 = Serializer.Deserialize<U32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(uint), buffer.Position);
        }

        [TestMethod]
        public void TestU64Packet()
        {
            U64Packet v1 = new U64Packet(0xABCD);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(ulong));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(ulong), buffer.Position);

            buffer.Rewind();
            U64Packet v2 = Serializer.Deserialize<U64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(ulong), buffer.Position);
        }

        [TestMethod]
        public void TestS8Packet()
        {
            S8Packet v1 = new S8Packet(0xA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(sbyte));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(sbyte), buffer.Position);

            buffer.Rewind();
            S8Packet v2 = Serializer.Deserialize<S8Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(sbyte), buffer.Position);
        }

        [TestMethod]
        public void TestS16Packet()
        {
            S16Packet v1 = new S16Packet(0xAB);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(short));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(short), buffer.Position);

            buffer.Rewind();
            S16Packet v2 = Serializer.Deserialize<S16Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(short), buffer.Position);
        }

        [TestMethod]
        public void TestS32Packet()
        {
            S32Packet v1 = new S32Packet(0xABA);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(int));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(int), buffer.Position);

            buffer.Rewind();
            S32Packet v2 = Serializer.Deserialize<S32Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(int), buffer.Position);
        }

        [TestMethod]
        public void TestS64Packet()
        {
            S64Packet v1 = new S64Packet(0xABCD);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(long));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(long), buffer.Position);

            buffer.Rewind();
            S64Packet v2 = Serializer.Deserialize<S64Packet>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(long), buffer.Position);
        }

        [TestMethod]
        public void TestSinglePacket()
        {
            SinglePacket v1 = new SinglePacket(0.1f);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(float));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(float), buffer.Position);

            buffer.Rewind();
            SinglePacket v2 = Serializer.Deserialize<SinglePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(float), buffer.Position);
        }

        [TestMethod]
        public void TestDoublePacket()
        {
            DoublePacket v1 = new DoublePacket(0.1);
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(double));
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(sizeof(double), buffer.Position);

            buffer.Rewind();
            DoublePacket v2 = Serializer.Deserialize<DoublePacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(sizeof(double), buffer.Position);
        }

        [TestMethod]
        public void TestPrimitivesPacket()
        {
            int size = PrimitivesPacket.Size();
            PrimitivesPacket v1 = new PrimitivesPacket(15);
            var buffer = ByteBufferAllocator.Instance.Allocate(size);
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(size, buffer.Position);

            buffer.Rewind();
            PrimitivesPacket v2 = Serializer.Deserialize<PrimitivesPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(size, buffer.Position);
        }

        [TestMethod]
        public void TestEnumPacket()
        {
            int size = EnumPacket.Size();
            EnumPacket v1 = new EnumPacket(MyEnum.Three);
            var buffer = ByteBufferAllocator.Instance.Allocate(size);
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(size, buffer.Position);

            buffer.Rewind();
            EnumPacket v2 = Serializer.Deserialize<EnumPacket>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(size, buffer.Position);
        }

        [TestMethod]
        public void TestStruct1Packet()
        {
            int size = MyStruct1.Size();
            MyStruct1 v1 = new MyStruct1();
            v1.m_byte = 1;
            v1.m_int = 2;
            v1.m_long = 3;
            var buffer = ByteBufferAllocator.Instance.Allocate(size);
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(size, buffer.Position);

            buffer.Rewind();
            MyStruct1 v2 = Serializer.Deserialize<MyStruct1>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(size, buffer.Position);
        }

        [TestMethod]
        public void TestStructMessagePacket()
        {
            int size = StructMessage.Size();
            StructMessage v1 = new StructMessage();
             var buffer = ByteBufferAllocator.Instance.Allocate(size);
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(size, buffer.Position);

            buffer.Rewind();
            StructMessage v2 = Serializer.Deserialize<StructMessage>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(size, buffer.Position);
        }

        [TestMethod]
        public void TestMyClass1MessagePacket()
        {
            int size = MyClass1.Size();
            MyClass1 v1 = new MyClass1();
            var buffer = ByteBufferAllocator.Instance.Allocate(size);
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(size, buffer.Position);

            buffer.Rewind();
            MyClass1 v2 = Serializer.Deserialize<MyClass1>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(size, buffer.Position);
        }

        [TestMethod]
        public void TestMyClassListMessagePacket()
        {
            int size = 16 + 2; // (2 + 1)* 4 + 1 * 4
            MyClassList v1 = new MyClassList();
            v1.m_intlist = new List<int>() { 1, 2 };
            var buffer = ByteBufferAllocator.Instance.Allocate(size);
            Serializer.Serialize(buffer, v1);
            Assert.AreEqual(size, buffer.Position);

            buffer.Rewind();
            MyClassList v2 = Serializer.Deserialize<MyClassList>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(size, buffer.Position);
        }
    }
}
