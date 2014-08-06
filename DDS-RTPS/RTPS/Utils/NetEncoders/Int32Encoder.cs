using Mina.Core.Buffer;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
    public static class Int32Encoder
    {
        #region Encodign Little-Endian
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutIntLE(this IoBuffer buffer, int val)
        {
            for (int i = 0; i < sizeof(int); i++)
            {
                buffer.Put(unchecked((byte)(val & 0xFF)));
                val = unchecked((int)(val >> 8));
            }

        }
        /// <summary>
        /// Encodes  in Little Endian the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="buffer">a byte array</param>
        /// <param name="val">the value to encode</param>
        public static void PutIntLE(this Stream buffer, int val)
        {
            for (int i = 0; i < sizeof(int); i++)
            {
                buffer.WriteByte(unchecked((byte)(val & 0xFF)));
                val = unchecked((int)(val >> 8));
            }
            //This implementation is a little bit slower with MemoryStream
            // and a pain with IoBuffer
            //buffer.Write(BitConverter.GetBytes(val));

        }

        public static int GetIntLE(this IoBuffer buffer)
        {
            int ret = 0;
            for (byte i = 0; i < sizeof(int); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((int)((int)(b << (8 * i)) | ret));
            }
            return ret;
        }

        public static int GetIntLE(this Stream buffer)
        {
            int ret = 0;
            for (byte i = 0; i < sizeof(int); i++)
            {
                byte b = (byte)buffer.ReadByte();
                ret = unchecked((int)((int)(b << (8 * i)) | ret));
            }
            return ret;
        }
        public static void GetIntLE(this IoBuffer buffer, out int obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(int); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((int)((obj << 8) | b));
            }
        }
        #endregion

        #region Encodign Big-Endian
        public static void PutIntBE(this IoBuffer buffer, int val)
        {
            //buffer.Put(unchecked((byte)((val & 0xFF00U) >> 8)));
            //buffer.Put(unchecked((byte)(val & 0xFFU)));
            for (byte i = sizeof(int) - 1; i >= 0; i--)
            {
                buffer.Put(unchecked((byte)((val >> (8 * i)) & 0xFF)));
            }
        }

        public static int GetIntBE(this IoBuffer buffer)
        {
            int ret = 0;
            for (int i = 0; i < sizeof(int); i++)
            {
                byte b = buffer.Get();
                ret = unchecked((int)((ret << 8) | b));
            }
            return ret;
        }

        public static void GetIntBE(this IoBuffer buffer, out int obj)
        {
            obj = 0;
            for (int i = 0; i < sizeof(int); i++)
            {
                byte b = buffer.Get();
                obj = unchecked((int)((obj << 8) | b));
            }
        }
        #endregion

        public static int EncodingSize
        {
            get { return sizeof(int); }
        }
    }
}
