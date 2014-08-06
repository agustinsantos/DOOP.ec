using Mina.Core.Buffer;
using System;
using System.Diagnostics;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
    public static class UInt64Encoder
    {
        #region Encodign Little-Endian
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutULongLE(this IoBuffer buffer, ulong val)
        {
            for (int i = 0; i < sizeof(ulong); i++)
            {
                buffer.Put(unchecked((byte)(val & 0xFF)));
                val = unchecked((ulong)(val >> 8));
            }

        }
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutULongLE(this Stream buffer, ulong val)
        {
            for (int i = 0; i < sizeof(ulong); i++)
            {
                buffer.WriteByte(unchecked((byte)(val & 0xFF)));
                val = unchecked((ulong)(val >> 8));
            }
            //This implementation is a little bit slower with MemoryStream
            // and a pain with IoBuffer
            //buffer.Write(BitConverter.GetBytes(val));

        }

        public static ulong GetULongLE(this IoBuffer buffer)
        {
            ulong ret = 0;
            for (byte i = 0; i < sizeof(ulong); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((ulong)((ulong)b << (8 * i) | ret));
            }
            return ret;
        }

        public static ulong GetULongLE(this Stream buffer)
        {
            ulong ret = 0;
            for (byte i = 0; i < sizeof(ulong); i++)
            {
                byte b = (byte)buffer.ReadByte();
                ret = unchecked((ulong)((ulong)b << (8 * i) | ret));
            }
            return ret;
        }
        public static void GetULongLE(this IoBuffer buffer, out ulong obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(ulong); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((ulong)((obj << 8) | b));
            }
        }
        #endregion

        #region Encodign Big-Endian
        public static void PutULongBE(this IoBuffer buffer, ulong val)
        {
            //buffer.Put(unchecked((byte)((val & 0xFF00U) >> 8)));
            //buffer.Put(unchecked((byte)(val & 0xFFU)));
            for (byte i = sizeof(ulong) - 1; i >= 0; i--)
            {
                buffer.Put(unchecked((byte)((val >> (8 * i)) & 0xFF)));
            }
        }

        public static ulong GetULongBE(this IoBuffer buffer)
        {
            ulong ret = 0;
            for (int i = 0; i < sizeof(ulong); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((ulong)((ret << 8) | b));
            }
            return ret;
        }

        public static void GetULongBE(this IoBuffer buffer, out ulong obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(ulong); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((ulong)((obj << 8) | b));
            }
        }
        #endregion

        public static int EncodingSize
        {
            get { return sizeof(ulong); }
        }
    }
}
