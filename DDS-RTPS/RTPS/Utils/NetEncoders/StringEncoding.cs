using System;
using System.Diagnostics;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
#if TODO
    #region Encodign Little-Endian
    public class StringEncodingLE
    {
        /// <summary> 
        /// Encodes the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="parameterValue">the value to Encode
        /// </param>
        /// <returns> 
        /// a byte array containing the encoded value
        /// An array of bytes with length 2.
        /// </returns>
        public static byte[] Encode(String val)
        {
            byte[] buf = System.Text.Encoding.Unicode.GetBytes(val);
            return buf;
        }

        public static void Encode(Stream stream, String val)
        {
            if (val == null)
                Int32EncodingLE.Encode(stream, -1);
            else
            {
                byte[] buf = Encode(val);
                Int32EncodingLE.Encode(stream, buf.Length);
                stream.Write(buf, 0, buf.Length);
            }
        }

        /// <summary> 
        /// Decodes and returns the parameterValue stored in the specified bufferStream.
        /// </summary>
        /// <param name="bufferStream">the bufferStream containing the encoded parameterValue
        /// </param>
        /// <returns> the decoded parameterValue
        /// </returns>
        public static String Decode(byte[] buffer)
        {
            return System.Text.Encoding.Unicode.GetString(buffer);
        }
        public static String Decode(byte[] buffer, int startPos)
        {
            throw new NotImplementedException();
        }

        public static String Decode(Stream stream)
        {
            int len = Int32EncodingLE.Decode(stream);
            if (len == -1) return null;
            byte[] buf = stream.ReadBytes(len);
            return Decode(buf);
        }

        public static int Size
        {
            get
            {
                //throw new NotImplementedException();
				return 0;
            }
        }
    }
    #endregion

    #region Encodign Big-Endian
    public class StringEncodingBE 
    {

        /// <summary> 
        /// Encodes the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="parameterValue">the value to Encode
        /// </param>
        /// <returns> 
        /// a byte array containing the encoded value
        /// An array of bytes with length 2.
        /// </returns>
        public static byte[] Encode(String val)
        {
            byte[] buf = System.Text.Encoding.Unicode.GetBytes(val);
            return buf;
        }

        public static void Encode(Stream stream, String val) 
        {
            if (val == null)
                Int32EncodingBE.Encode(stream, -1);
            else
            {
                byte[] buf = Encode(val);
                Int32EncodingBE.Encode(stream, buf.Length);
                stream.Write(buf, 0, buf.Length);
            }
        }

        /// <summary> 
        /// Decodes and returns the parameterValue stored in the specified bufferStream.
        /// </summary>
        /// <param name="bufferStream">the bufferStream containing the encoded parameterValue
        /// </param>
        /// <returns> the decoded parameterValue
        /// </returns>
        public static String Decode(byte[] buffer)
        {
            return System.Text.Encoding.Unicode.GetString(buffer);
        }
        public static String Decode(byte[] buffer, int startPos)
        {
            throw new NotImplementedException();
        }

        public static String Decode(Stream stream)
        {
            int len = Int32EncodingBE.Decode(stream);
            if (len == -1) return null;
            byte[] buf = stream.ReadBytes(len);
            return Decode(buf);
        }

        public static int Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
    #endregion
#endif
}
