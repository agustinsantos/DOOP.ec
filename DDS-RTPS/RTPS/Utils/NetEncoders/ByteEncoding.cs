using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sxta.GenericProtocol.Encoding
{
	public class ByteEncoding
	{
		 public static readonly EndianTypes Endian = (BitConverter.IsLittleEndian ? EndianTypes.LittleEndian : EndianTypes.BigEndian);



        /// <summary> 
        /// Encodes the specified parameterValue, returning the result as a byte array.
        /// </summary>
        /// <param name="parameterValue">the parameterValue to Encode
        /// </param>
        /// <returns> 
        /// a byte array containing the encoded parameterValue
        /// An array of bytes with length 1.
        /// </returns>
        public static byte[] Encode(byte val)
        {
            return new byte[] { val };
        }
        public static void Encode(Stream buffer, byte val)
        {
            buffer.WriteByte(val);
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
        public static byte Decode(byte[] buffer)
        {
            if (buffer == null)
                throw new Exception();
            if (buffer.Length < sizeof(byte))
                throw new Exception();
            return buffer[0];
        }
        public static byte Decode(byte[] buffer, int startPos)
        {
            if (buffer == null)
                throw new Exception();
            if (buffer.Length < startPos + sizeof(byte))
                throw new Exception();
            return buffer[startPos];
        }
        public static byte Decode(Stream buffer)
        {
            if (buffer == null)
                throw new ArgumentException("Buffer is null");
            return (byte)buffer.ReadByte();
        }

        public static int ByteSize
        {
            get { return sizeof(byte); }
        }
    

	}

	public class ByteEncodingLE : ByteEncoding
	{
	}

	public class ByteEncodingBE : ByteEncoding
	{
	}
}

