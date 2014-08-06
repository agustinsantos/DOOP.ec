using Mina.Core.Buffer;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
    public static class Int16Encoder
    {
        #region Encodign Little-Endian
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutShortLE(this IoBuffer buffer, short val)
        {
            for (int i = 0; i < sizeof(short); i++)
            {
                buffer.Put(unchecked((byte)(val & 0xFF)));
                val = unchecked((short)(val >> 8));
            }

        }
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutShortLE(this Stream buffer, short val)
        {
            for (int i = 0; i < sizeof(short); i++)
            {
                buffer.WriteByte(unchecked((byte)(val & 0xFF)));
                val = unchecked((short)(val >> 8));
            }
            //This implementation is a little bit slower with MemoryStream
            // and a pain with IoBuffer
            //buffer.Write(BitConverter.GetBytes(val));

        }

        public static short GetShortLE(this IoBuffer buffer)
        {
            short ret = 0;
            for (byte i = 0; i < sizeof(short); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((short)((short)(b << (8 * i)) | ret));
            }
            return ret;
        }

        public static short GetShortLE(this Stream buffer)
        {
            short ret = 0;
            for (byte i = 0; i < sizeof(short); i++)
            {
                byte b = (byte)buffer.ReadByte();
                ret = unchecked((short)((short)(b << (8 * i)) | ret));
            }
            return ret;
        }
        public static void GetShortLE(this IoBuffer buffer, out short obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(short); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((short)((obj << 8) | b));
            }
        }
        #endregion

        #region Encodign Big-Endian
        public static void PutShortBE(this IoBuffer buffer, short val)
        {
            //buffer.Put(unchecked((byte)((val & 0xFF00U) >> 8)));
            //buffer.Put(unchecked((byte)(val & 0xFFU)));
            for (byte i = sizeof(short) - 1; i >= 0; i--)
            {
                buffer.Put(unchecked((byte)((val >> (8 * i)) & 0xFF)));
            }
        }

        public static short GetShortBE(this IoBuffer buffer)
        {
            short ret = 0;
            for (int i = 0; i < sizeof(short); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((short)((ret << 8) | b));
            }
            return ret;
        }

        public static void GetShortBE(this IoBuffer buffer, out short obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(short); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((short)((obj << 8) | b));
            }
        }
        #endregion

        public static int EncodingSize
        {
            get { return sizeof(short); }
        }
    }
}
