using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Doopec.Serializer
{
    public static class Primitives
    {
        public static MethodInfo GetWritePrimitive(Type type)
        {
            return typeof(Primitives).GetMethod("WritePrimitive",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.ExactBinding, null,
                new Type[] { typeof(IoBuffer), type }, null);
        }

        public static MethodInfo GetReaderPrimitive(Type type)
        {
            return typeof(Primitives).GetMethod("ReadPrimitive",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.ExactBinding, null,
                new Type[] { typeof(IoBuffer), type.MakeByRefType() }, null);
        }

        static uint EncodeZigZag32(int n)
        {
            return (uint)((n << 1) ^ (n >> 31));
        }

        static ulong EncodeZigZag64(long n)
        {
            return (ulong)((n << 1) ^ (n >> 63));
        }

        static int DecodeZigZag32(uint n)
        {
            return (int)(n >> 1) ^ -(int)(n & 1);
        }

        static long DecodeZigZag64(ulong n)
        {
            return (long)(n >> 1) ^ -(long)(n & 1);
        }

        static uint ReadVarint32(IoBuffer buffer)
        {
            int result = 0;
            int offset = 0;

            for (; offset < 32; offset += 7)
            {
                int b = buffer.Get();
                if (b == -1)
                    throw new BufferUnderflowException();

                result |= (b & 0x7f) << offset;

                if ((b & 0x80) == 0)
                    return (uint)result;
            }

            throw new InvalidDataException();
        }

        static void WriteVarint32(IoBuffer buffer, uint value)
        {
            for (; value >= 0x80u; value >>= 7)
                buffer.Put((byte)(value | 0x80u));

            buffer.Put((byte)value);
        }

        static ulong ReadVarint64(IoBuffer buffer)
        {
            long result = 0;
            int offset = 0;

            for (; offset < 64; offset += 7)
            {
                int b = buffer.Get();
                if (b == -1)
                    throw new BufferUnderflowException();

                result |= ((long)(b & 0x7f)) << offset;

                if ((b & 0x80) == 0)
                    return (ulong)result;
            }

            throw new InvalidDataException();
        }

        static void WriteVarint64(IoBuffer buffer, ulong value)
        {
            for (; value >= 0x80u; value >>= 7)
                buffer.Put((byte)(value | 0x80u));

            buffer.Put((byte)value);
        }


        public static void WritePrimitive(IoBuffer buffer, bool value)
        {
            buffer.Put(value ? (byte)1 : (byte)0);
        }

        public static void ReadPrimitive(IoBuffer buffer, out bool value)
        {
            var b = buffer.Get();
            value = b != 0;
        }

        public static void WritePrimitive(IoBuffer buffer, byte value)
        {
            buffer.Put(value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out byte value)
        {
            value = (byte)buffer.Get();
        }

        public static void WritePrimitive(IoBuffer buffer, sbyte value)
        {
            buffer.Put((byte)value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out sbyte value)
        {
            value = (sbyte)buffer.Get();
        }

        public static void WritePrimitive(IoBuffer buffer, char value)
        {
            buffer.PutChar(value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out char value)
        {
            value = buffer.GetChar();
        }

        public static void WritePrimitive(IoBuffer buffer, ushort value)
        {
            buffer.PutInt16((short)value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out ushort value)
        {
            value = (ushort)buffer.GetInt16();
        }

        public static void WritePrimitive(IoBuffer buffer, short value)
        {
            buffer.PutInt16(value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out short value)
        {
            value = buffer.GetInt16();
        }

        public static void WritePrimitive(IoBuffer buffer, uint value)
        {
            buffer.PutInt32((int)value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out uint value)
        {
            value = (uint)buffer.GetInt32();
        }

        public static void WritePrimitive(IoBuffer buffer, int value)
        {
            buffer.PutInt32(value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out int value)
        {
            value = buffer.GetInt32();
        }

        public static void WritePrimitive(IoBuffer buffer, ulong value)
        {
            buffer.PutInt64((long)value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out ulong value)
        {
            value = (ulong)buffer.GetInt64();
        }

        public static void WritePrimitive(IoBuffer buffer, long value)
        {
            buffer.PutInt64(value);
        }

        public static void ReadPrimitive(IoBuffer buffer, out long value)
        {
            value = buffer.GetInt64();
        }

        public static unsafe void WritePrimitive(IoBuffer buffer, float value)
        {
            buffer.PutSingle(value);
        }

        public static unsafe void ReadPrimitive(IoBuffer buffer, out float value)
        {
            value = buffer.GetSingle();
        }

        public static unsafe void WritePrimitive(IoBuffer buffer, double value)
        {
            buffer.PutDouble(value);
        }

        public static unsafe void ReadPrimitive(IoBuffer buffer, out double value)
        {
            value = buffer.GetDouble();
        }

        public static unsafe void WritePrimitive(IoBuffer buffer, decimal value)
        {
            throw new NotImplementedException();
        }

        public static unsafe void ReadPrimitive(IoBuffer buffer, out decimal value)
        {
            throw new NotImplementedException();
        }

        public static void WritePrimitive(IoBuffer buffer, DateTime value)
        {
            long v = value.ToBinary();
            WritePrimitive(buffer, v);
        }

        public static void ReadPrimitive(IoBuffer buffer, out DateTime value)
        {
            long v;
            ReadPrimitive(buffer, out v);
            value = DateTime.FromBinary(v);
        }

#if NO_UNSAFE
		public static void WritePrimitive(IoBuffer buffer, string value)
		{
			if (value == null)
			{
				WritePrimitive(buffer, (uint)0);
				return;
			}

			var encoding = new UTF8Encoding(false, true);

			int len = encoding.GetByteCount(value);

			WritePrimitive(buffer, (uint)len + 1);

			var buf = new byte[len];

			encoding.GetBytes(value, 0, value.Length, buf, 0);

			buffer.Write(buf, 0, len);
		}

		public static void ReadPrimitive(IoBuffer buffer, out string value)
		{
			uint len;
			ReadPrimitive(buffer, out len);

			if (len == 0)
			{
				value = null;
				return;
			}
			else if (len == 1)
			{
				value = string.Empty;
				return;
			}

			len -= 1;

			var encoding = new UTF8Encoding(false, true);

			var buf = new byte[len];

			int l = 0;

			while (l < len)
			{
				int r = buffer.Read(buf, l, (int)len - l);
				if (r == 0)
					throw new EndOfIoBufferException();
				l += r;
			}

			value = encoding.GetString(buf);
		}
#else
        sealed class StringHelper
        {
            public StringHelper()
            {
                this.Encoding = new UTF8Encoding(false, true);
            }

            public const int BYTEBUFFERLEN = 256;
            public const int CHARBUFFERLEN = 128;

            Encoder m_encoder;
            Decoder m_decoder;

            byte[] m_byteBuffer;
            char[] m_charBuffer;

            public UTF8Encoding Encoding { get; private set; }
            public Encoder Encoder { get { if (m_encoder == null) m_encoder = this.Encoding.GetEncoder(); return m_encoder; } }
            public Decoder Decoder { get { if (m_decoder == null) m_decoder = this.Encoding.GetDecoder(); return m_decoder; } }

            public byte[] ByteBuffer { get { if (m_byteBuffer == null) m_byteBuffer = new byte[BYTEBUFFERLEN]; return m_byteBuffer; } }
            public char[] CharBuffer { get { if (m_charBuffer == null) m_charBuffer = new char[CHARBUFFERLEN]; return m_charBuffer; } }
        }

        [ThreadStatic]
        static StringHelper s_stringHelper;

        public unsafe static void WritePrimitive(IoBuffer buffer, string value)
        {
            if (value == null)
            {
                WritePrimitive(buffer, (uint)0);
                return;
            }
            else if (value.Length == 0)
            {
                WritePrimitive(buffer, (uint)1);
                return;
            }

            var helper = s_stringHelper;
            if (helper == null)
                s_stringHelper = helper = new StringHelper();

            var encoder = helper.Encoder;
            var buf = helper.ByteBuffer;

            int totalChars = value.Length;
            int totalBytes;

            fixed (char* ptr = value)
                totalBytes = encoder.GetByteCount(ptr, totalChars, true);

            WritePrimitive(buffer, (uint)totalBytes + 1);
            WritePrimitive(buffer, (uint)totalChars);

            int p = 0;
            bool completed = false;

            while (completed == false)
            {
                int charsConverted;
                int bytesConverted;

                fixed (char* src = value)
                fixed (byte* dst = buf)
                {
                    encoder.Convert(src + p, totalChars - p, dst, buf.Length, true,
                        out charsConverted, out bytesConverted, out completed);
                }

                buffer.Put(buf, 0, bytesConverted);

                p += charsConverted;
            }
        }

        public static void ReadPrimitive(IoBuffer buffer, out string value)
        {
            uint totalBytes;
            ReadPrimitive(buffer, out totalBytes);

            if (totalBytes == 0)
            {
                value = null;
                return;
            }
            else if (totalBytes == 1)
            {
                value = string.Empty;
                return;
            }

            totalBytes -= 1;

            uint totalChars;
            ReadPrimitive(buffer, out totalChars);

            var helper = s_stringHelper;
            if (helper == null)
                s_stringHelper = helper = new StringHelper();

            var decoder = helper.Decoder;
            var buf = helper.ByteBuffer;
            char[] chars;
            if (totalChars <= StringHelper.CHARBUFFERLEN)
                chars = helper.CharBuffer;
            else
                chars = new char[totalChars];

            int bufferBytesLeft = (int)totalBytes;

            int cp = 0;

            while (bufferBytesLeft > 0)
            {
                int bytesInBuffer = Math.Min(buf.Length, bufferBytesLeft);
                buffer.Get(buf, 0, bytesInBuffer);
                if (bytesInBuffer == 0)
                    throw new BufferUnderflowException();

                bufferBytesLeft -= bytesInBuffer;
                bool flush = bufferBytesLeft == 0 ? true : false;

                bool completed = false;

                int p = 0;

                while (completed == false)
                {
                    int charsConverted;
                    int bytesConverted;

                    decoder.Convert(buf, p, bytesInBuffer - p,
                        chars, cp, (int)totalChars - cp,
                        flush,
                        out bytesConverted, out charsConverted, out completed);

                    p += bytesConverted;
                    cp += charsConverted;
                }
            }

            value = new string(chars, 0, (int)totalChars);
        }
#endif

        public static void WritePrimitive(IoBuffer buffer, byte[] value)
        {
            if (value == null)
            {
                WritePrimitive(buffer, (uint)0);
                return;
            }

            WritePrimitive(buffer, (uint)value.Length + 1);

            buffer.Put(value, 0, value.Length);
        }

        static readonly byte[] s_emptyByteArray = new byte[0];

        public static void ReadPrimitive(IoBuffer buffer, out byte[] value)
        {
            uint len;
            ReadPrimitive(buffer, out len);

            if (len == 0)
            {
                value = null;
                return;
            }
            else if (len == 1)
            {
                value = s_emptyByteArray;
                return;
            }

            len -= 1;

            value = new byte[len];
            int l = 0;

            while (l < len)
            {
                int r = (int)len - l;
                buffer.Get(value, l, r);
                if (r == 0)
                    throw new BufferUnderflowException();
                l += r;
            }
        }
    }
}
