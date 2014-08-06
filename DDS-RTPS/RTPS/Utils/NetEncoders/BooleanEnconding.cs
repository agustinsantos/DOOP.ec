using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sxta.GenericProtocol.Encoding
{
	public class BooleanEnconding
	{
		public enum EndianTypes
		{
			LittleEndian,
			BigEndian
		}
		
		public static readonly EndianTypes Endian = (BitConverter.IsLittleEndian ? EndianTypes.LittleEndian : EndianTypes.BigEndian);

    
		/// <summary> 
		/// Encodes the specified parameterValue, returning the result as a byte array.
		/// </summary>
		/// <param name="parameterValue">the parameterValue to Encode
		/// </param>
		/// <returns> a byte array containing the encoded parameterValue
		/// An array of bytes with length 1.
		/// </returns>
		public static byte[] Encode (bool val)
		{
			return BitConverter.GetBytes (val);
		}
		
		/// <summary>
		/// Encodes the boolean.
		/// </summary>
		/// <param name='buffer'>
		/// Buffer.
		/// </param>
		/// <param name='val'>
		/// Value.
		/// </param> 						// Why this stream...
		public static void Encode (Stream buffer, bool val)
		{
			byte[] buf = BitConverter.GetBytes (val);
			if (Endian != EndianTypes.LittleEndian)
				EncodingHelpers.ReverseBytes (buf);
			buffer.Write (buf);
		}

		/// <summary> 
		/// Decodes and returns the parameterValue stored in the specified bufferStream.
		/// </summary>
		/// <param name="bufferStream">the bufferStream containing the encoded parameterValue
		/// </param>
		/// <returns> the decoded parameterValue
		/// </returns>
		/// <exception cref="System.IO.System.IO.IOException"> if the parameterValue could not be decoded
		/// </exception>
		public static bool Decode (byte[] buffer)
		{
			if (buffer == null)
				throw new Exception ();
			if (buffer.Length < sizeof(bool))
				throw new Exception ();
			return BitConverter.ToBoolean (buffer, 0);
		}
		
		//new, it is stream parameter
		public static bool Decode (Stream buffer)
		{
			if (buffer == null)
				throw new Exception ();
			if (buffer.Length < sizeof(bool))
				throw new Exception ();
			return BitConverter.ToBoolean (buffer.ToByteArray (), 0);
		}
		
		public static bool Decode (byte[] buffer, int startPos)
		{
			if (buffer == null)
				throw new Exception ();
			if (buffer.Length < startPos + sizeof(bool))
				throw new Exception ();
			return BitConverter.ToBoolean (buffer, startPos);
		}

		public static int BoolSize {
			get { return sizeof(bool); }
		}
   	

	}
}
	
	
	


