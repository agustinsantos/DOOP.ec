using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mina.Core.Buffer;

namespace SerializerTests
{
    [TestClass]
    public class PrimitiveTests
    {
        [TestMethod]
        public void TestDouble()
        {
            double v1 = 1.0;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(double));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            double v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestSingle()
        {
            float v1 = 1.0f;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(float));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            float v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestShort()
        {
            short v1 = 1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(short));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            short v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestUShort()
        {
            ushort v1 = 1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(ushort));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            ushort v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestInt()
        {
            int v1 = 1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(int));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            int v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestUInt()
        {
            uint v1 = 1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(uint));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            uint v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestLong()
        {
            long v1 = 1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(long));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            long v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestULong()
        {
            ulong v1 = 1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(ulong));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            ulong v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestChar()
        {
            char v1 = 'a';
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(char));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            char v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestByte()
        {
            byte v1 = 1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(byte));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            byte v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestSByte()
        {
            sbyte v1 = -1;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(sbyte));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            sbyte v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestBool()
        {
            bool v1 = true;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(bool));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            bool v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestDateTime()
        {
            DateTime v1 = DateTime.Now;
            var buffer = ByteBufferAllocator.Instance.Allocate(sizeof(long));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            DateTime v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }

        [TestMethod]
        public void TestString()
        {
            string v1 = "this is a string!";
            var buffer = ByteBufferAllocator.Instance.Allocate(1 + v1.Length * sizeof(char));
            Doopec.Serializer.Primitives.WritePrimitive(buffer, v1);

            buffer.Rewind();
            string v2;
            Doopec.Serializer.Primitives.ReadPrimitive(buffer, out v2);
            Assert.AreEqual(v1, v2);
        }
    }
}
