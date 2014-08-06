using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sxta.GenericProtocol.Encoding
{
	public class CharEncoding
	{
		        public static readonly EndianTypes Endian = (BitConverter.IsLittleEndian ? EndianTypes.LittleEndian : EndianTypes.BigEndian);



        /// <summary> 
        /// Encodes the specified parameterValue, returning the result as a byte array.
        /// </summary>
        /// <param name="parameterValue">the parameterValue to Encode
        /// </param>
        /// <returns> 
        /// a byte array containing the encoded parameterValue
        /// An array of bytes with length 2.
        /// </returns>
        public static byte[] EncodeCharLE(char val)
        {
            byte[] buf = BitConverter.GetBytes(val);
            if (Endian != EndianTypes.LittleEndian)
                EncodingHelpers.ReverseBytes(buf);
            return buf;
        }

        /// <summary> 
        /// Decodes and returns the parameterValue stored in the specified bufferStream.
        /// </summary>
        /// <param name="bufferStream">the bufferStream containing the encoded parameterValue
        /// </param>
        /// <returns> the decoded parameterValue
        /// </returns>
        /// <exception cref="System.IO.IOException"> if the parameterValue could not be decoded
        /// </exception>
        public static char DecodeChar(byte[] buffer)
        {
            if (buffer == null)
                throw new Exception();
            if (buffer.Length < sizeof(char))
                throw new Exception();
            return BitConverter.ToChar(buffer, 0);
        }
        public static char DecodeChar(byte[] buffer, int startPos)
        {
            if (buffer == null)
                throw new Exception();
            if (buffer.Length < startPos + sizeof(char))
                throw new Exception();
            return BitConverter.ToChar(buffer, startPos);
        }
        

	}
}

