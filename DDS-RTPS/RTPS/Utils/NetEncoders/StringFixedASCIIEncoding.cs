using System;
using System.Diagnostics;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
    #region Encodign Fixed-Size
    public class StringFixedASCIIEncoding
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
            byte[] buf = System.Text.Encoding.ASCII.GetBytes(val);
            return buf;
        }

        public static void Encode(Stream stream, String val, int maxSize)
        {
            byte[] buf = new byte[maxSize];
            if (val != null)
            {
                System.Text.Encoding.ASCII.GetBytes(val).CopyTo(buf, 0);
            }
            stream.Write(buf, 0, buf.Length);
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
            string rst =  System.Text.Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            int nullLoc = rst.IndexOf('\0');
            if (nullLoc > -1) rst = rst.Substring(0, nullLoc);
            return rst;
        }
        public static String Decode(byte[] buffer, int startPos)
        {
            throw new NotImplementedException();
        }

        public static String Decode(Stream stream, int maxSize)
        {
            byte[] buf = stream.ReadBytes(maxSize);
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
}
