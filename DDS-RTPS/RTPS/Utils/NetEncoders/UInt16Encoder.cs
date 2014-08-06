using Mina.Core.Buffer;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
    public static class UInt16Encoder
    {
        #region Encodign Little-Endian
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutUShortLE(this IoBuffer buffer, ushort val)
        {
            for (int i = 0; i < sizeof(ushort); i++)
            {
                buffer.Put(unchecked((byte)(val & 0xFF)));
                val = unchecked((ushort)(val >> 8));
            }

        }
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutUShortLE(this Stream buffer, ushort val)
        {
            for (int i = 0; i < sizeof(ushort); i++)
            {
                buffer.WriteByte(unchecked((byte)(val & 0xFF)));
                val = unchecked((ushort)(val >> 8));
            }
            //This implementation is a little bit slower with MemoryStream
            // and a pain with IoBuffer
            //buffer.Write(BitConverter.GetBytes(val));

        }

        public static ushort GetUShortLE(this IoBuffer buffer)
        {
            ushort ret = 0;
            for (byte i = 0; i < sizeof(ushort); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((ushort)((ushort)(b << (8 * i)) | ret));
            }
            return ret;
        }

        public static ushort GetUShortLE(this Stream buffer)
        {
            ushort ret = 0;
            for (byte i = 0; i < sizeof(ushort); i++)
            {
                byte b = (byte)buffer.ReadByte();
                ret = unchecked((ushort)((ushort)(b << (8 * i)) | ret));
            }
            return ret;
        }
        public static void GetUShortLE(this IoBuffer buffer, out ushort obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(ushort); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((ushort)((obj << 8) | b));
            }
        }
        #endregion

        #region Encodign Big-Endian
        public static void PutUShortBE(this IoBuffer buffer, ushort val)
        {
            //buffer.Put(unchecked((byte)((val & 0xFF00U) >> 8)));
            //buffer.Put(unchecked((byte)(val & 0xFFU)));
            for (byte i = sizeof(ushort) - 1; i >= 0; i--)
            {
                buffer.Put(unchecked((byte)((val >> (8 * i)) & 0xFF)));
            }
        }

        public static ushort GetUShortBE(this IoBuffer buffer)
        {
            ushort ret = 0;
            for (int i = 0; i < sizeof(ushort); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((ushort)((ret << 8) | b));
            }
            return ret;
        }

        public static void GetUShortBE(this IoBuffer buffer, out ushort obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(ushort); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((ushort)((obj << 8) | b));
            }
        }
        #endregion

        public static int EncodingSize
        {
            get { return sizeof(ushort); }
        }
    }
}
