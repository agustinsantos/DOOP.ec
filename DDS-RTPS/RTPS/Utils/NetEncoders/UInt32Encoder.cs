using Mina.Core.Buffer;
using System;
using System.Diagnostics;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
    public static class UInt32Encoder
    {
        #region Encodign Little-Endian
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutUIntLE(this IoBuffer buffer, uint val)
        {
            for (int i = 0; i < sizeof(uint); i++)
            {
                buffer.Put(unchecked((byte)(val & 0xFF)));
                val = unchecked((uint)(val >> 8));
            }

        }
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutUIntLE(this Stream buffer, uint val)
        {
            for (int i = 0; i < sizeof(uint); i++)
            {
                buffer.WriteByte(unchecked((byte)(val & 0xFF)));
                val = unchecked((uint)(val >> 8));
            }
            //This implementation is a little bit slower with MemoryStream
            // and a pain with IoBuffer
            //buffer.Write(BitConverter.GetBytes(val));

        }

        public static uint GetUIntLE(this IoBuffer buffer)
        {
            uint ret = 0;
            for (byte i = 0; i < sizeof(uint); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((uint)((uint)(b << (8 * i)) | ret));
            }
            return ret;
        }

        public static uint GetUIntLE(this Stream buffer)
        {
            uint ret = 0;
            for (byte i = 0; i < sizeof(uint); i++)
            {
                byte b = (byte)buffer.ReadByte();
                ret = unchecked((uint)((uint)(b << (8 * i)) | ret));
            }
            return ret;
        }
        public static void GetUIntLE(this IoBuffer buffer, out uint obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(uint); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((uint)((obj << 8) | b));
            }
        }
        #endregion

        #region Encodign Big-Endian
        public static void PutUIntBE(this IoBuffer buffer, uint val)
        {
            //buffer.Put(unchecked((byte)((val & 0xFF00U) >> 8)));
            //buffer.Put(unchecked((byte)(val & 0xFFU)));
            for (byte i = sizeof(uint) - 1; i >= 0; i--)
            {
                buffer.Put(unchecked((byte)((val >> (8 * i)) & 0xFF)));
            }
        }

        public static uint GetUIntBE(this IoBuffer buffer)
        {
            uint ret = 0;
            for (int i = 0; i < sizeof(uint); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((uint)((ret << 8) | b));
            }
            return ret;
        }

        public static void GetUIntBE(this IoBuffer buffer, out uint obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(uint); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((uint)((obj << 8) | b));
            }
        }
        #endregion

        public static int EncodingSize
        {
            get { return sizeof(uint); }
        }
    }
}
