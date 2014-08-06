using System;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace Sxta.GenericProtocol.Encoding
{
#if TODO
	public class BitArrayEncodingLE
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
		public static byte[] Encode (BitArray val)  /// public static void Encode (Stream stream, Msg1 val)
		{
			byte[] buf = new byte[(int)Math.Ceiling (val.Count / 8.0f) + sizeof(short)];

			Array.Copy (Int16EncodingLE.Encode ((short)val.Length), buf, sizeof(short));

			val.CopyTo (buf, 2);
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buf, 2, buf.Length);
			return buf;

		}

		public static void Encode (Stream stream, BitArray val)
		{
			byte[] buf = new byte[(int)Math.Ceiling (val.Count / 8.0f) + sizeof(short)];
			Array.Copy (Int16EncodingLE.Encode ((short)val.Length), buf, sizeof(short));
			val.CopyTo (buf, 2);
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buf, 2, buf.Length);
			stream.Write (buf, 0, buf.Length);

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
		public static  BitArray Decode (byte[] buffer)   
		{
			if (buffer == null || (buffer.Length <= sizeof(short)))
				throw new Exception ();

			byte [] buffer2 = new byte[buffer.Length -2];

			byte[] buffer3=new byte[2];
			Array.Copy(buffer,0,buffer3,0,2);
			Int16 num = Int16EncodingLE.Decode(buffer3);
			Array.Copy (buffer, 2, buffer2, 0, buffer.Length - 2);

//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer2, 2, buffer2.Length);

			BitArray bitarr = new BitArray (buffer2);
			bitarr.Length=num;
			return bitarr;
		}

		public static void Decode (Stream stream, BitArray val)
		{

			Debug.Assert (stream != null, "Stream is null");
			Int16 num = Int16EncodingLE.Decode (stream);
			byte[] buffer = new byte[stream.Length-2];
			buffer = stream.ReadBytes (2, ((uint)stream.Length - 2));
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer, 2, buffer.Length);
			val = new BitArray (buffer);
			val.Length = num;
		}


//		public static void Decode (Stream stream)
//		{
//
//			Debug.Assert (stream != null, "Stream is null");
//			byte[] buffer = new byte[stream.Length - 2];
//
//			buffer = stream.ReadBytes (2, ((uint)stream.Length - 2));
//
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer);
//
//		}

		public static BitArray Decode (Stream stream)
		{

			Debug.Assert (stream != null, "Stream is null");
			Int16 num = Int16EncodingLE.Decode (stream);
			byte[] buffer = new byte[stream.Length - 2];
			buffer = stream.ReadBytes (2, ((uint)stream.Length) - 2);

//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer, 2, buffer.Length);
			BitArray val = new BitArray (buffer);
			val.Length = num;

			return val;
		}





	}

	public class BitArrayEncodingBE
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
		public static byte[] Encode (BitArray val)  /// public static void Encode (Stream stream, Msg1 val)
		{
			byte[] buf = new byte[(int)Math.Ceiling (val.Count / 8.0f) + sizeof(short)];

			Array.Copy (Int16EncodingBE.Encode ((short)val.Length), buf, sizeof(short));

			val.CopyTo (buf, 2);
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buf, 2, buf.Length);
			return buf;

		}

		public static void Encode (Stream stream, BitArray val)
		{
			byte[] buf = new byte[(int)Math.Ceiling (val.Count / 8.0f) + sizeof(short)];
			Array.Copy (Int16EncodingBE.Encode ((short)val.Length), buf, sizeof(short));
			val.CopyTo (buf, 2);
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buf, 2, buf.Length);
			stream.Write (buf, 0, buf.Length);

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
		public static  BitArray Decode (byte[] buffer)   
		{
			if (buffer == null || (buffer.Length <= sizeof(short)))
				throw new Exception ();

			byte [] buffer2 = new byte[buffer.Length -2];

			byte[] buffer3=new byte[2];
			Array.Copy(buffer,0,buffer3,0,2);
			Int16 num = Int16EncodingBE.Decode(buffer3);
			Array.Copy (buffer, 2, buffer2, 0, buffer.Length - 2);

//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer2, 2, buffer2.Length);

			BitArray bitarr = new BitArray (buffer2);
			bitarr.Length=num;
			return bitarr;
		}

		public static void Decode (Stream stream, BitArray val)
		{

			Debug.Assert (stream != null, "Stream is null");
			Int16 num = Int16EncodingBE.Decode (stream);
			byte[] buffer = new byte[stream.Length-2];
			buffer = stream.ReadBytes (2, ((uint)stream.Length - 2));
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer, 2, buffer.Length);
			val = new BitArray (buffer);
			val.Length = num;
		}


//		public static void Decode (Stream stream)
//		{
//
//			Debug.Assert (stream != null, "Stream is null");
//			byte[] buffer = new byte[stream.Length - 2];
//
//			buffer = stream.ReadBytes (2, ((uint)stream.Length - 2));
//
//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer);
//
//		}

		public static BitArray Decode (Stream stream)
		{

			Debug.Assert (stream != null, "Stream is null");
			Int16 num = Int16EncodingBE.Decode (stream);
			byte[] buffer = new byte[stream.Length - 2];
			buffer = stream.ReadBytes (2, ((uint)stream.Length) - 2);

//			if (EncodingHelpers.Endian != EndianTypes.LittleEndian)
//				EncodingHelpers.ReverseBytes (buffer, 2, buffer.Length);
			BitArray val = new BitArray (buffer);
			val.Length = num;

			return val;
		}





	}



#endif
}