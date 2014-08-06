using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sxta.GenericProtocol.Encoding
{
	public enum EndianTypes
	{
		LittleEndian,
		BigEndian
	}

	/// <summary> 
	/// Utility methods for encoding and decoding basic types.
	/// </summary>
	/// <author> 
	/// Agustin Santos.
	/// </author>
	public static class EncodingHelpers
	{

		public static readonly EndianTypes Endian = (BitConverter.IsLittleEndian ? EndianTypes.LittleEndian : EndianTypes.BigEndian);

		/// <summary> 
		/// Reverses the specified byte array in-place.
		/// </summary>
		/// <param name="bufferStream">the byte array to Reverse
		/// </param>
		public static byte[] ReverseBytes (byte[] inArray)
		{
			byte temp;
			int highCtr = inArray.Length - 1;

			for (int ctr = 0; ctr < inArray.Length / 2; ctr++) {
				temp = inArray [ctr];
				inArray [ctr] = inArray [highCtr];
				inArray [highCtr] = temp;
				highCtr -= 1;
			}
			return inArray;
		}

		public static byte[] ReverseBytes (byte[] inArray, int startPos, int length)
		{
			byte temp;
			int highCtr = startPos + length - 1;

			for (int ctr = startPos; ctr < startPos + length / 2; ctr++) {
				temp = inArray [ctr];
				inArray [ctr] = inArray [highCtr];
				inArray [highCtr] = temp;
				highCtr -= 1;
			}
			return inArray;
		}
	}
}
