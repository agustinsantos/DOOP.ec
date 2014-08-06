using System;
using System.Diagnostics;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{

	#region Encodign Little-Endian
	public class ArrayFixedEncodingLE<T>
	{

		public delegate void EncodeDelegate (Stream stream,T val);

		public delegate T DecodeDelegate (Stream stream);

		/// <summary> 
		/// Encodes the specified value, returning the result as a byte array.
		/// </summary>
		/// <param name="parameterValue">the value to Encode
		/// </param>
		/// <returns> 
		/// a byte array containing the encoded value
		/// An array of bytes with length 2.
		/// </return
		public static void Encode (Stream stream, T[] val, EncodeDelegate encode, int lengthField)
		{
			if (val == null || val.Length != lengthField)
				throw new ArgumentException ("Wrong array argument");

			foreach (T v in val)
				encode (stream, v);
            
		}

		/// <summary> 
		/// Decodes and returns the parameterValue stored in the specified bufferStream.
		/// </summary>
		/// <param name="bufferStream">the bufferStream containing the encoded parameterValue
		/// </param>
		/// <returns> the decoded parameterValue
		/// </returns>
		public static T[] Decode (Stream stream, DecodeDelegate decode, int lengthField)
		{
			T[] rst = new T[lengthField];
			for (int i = 0; i< lengthField; i++)
				rst [i] = decode (stream);
			return rst;
		}

		public static int Size {
			get {
				//throw new NotImplementedException();
				return 0;
			}
		}
	}
	#endregion

	#region Encodign Big-Endian
	public class ArrayFixedEncodingBE<T>
	{

		public delegate void EncodeDelegate (Stream stream,T val);

		public delegate T DecodeDelegate (Stream stream);

		/// <summary> 
		/// Encodes the specified value, returning the result as a byte array.
		/// </summary>
		/// <param name="parameterValue">the value to Encode
		/// </param>
		/// <returns> 
		/// a byte array containing the encoded value
		/// An array of bytes with length 2.
		/// </return
		public static void Encode (Stream stream, T[] val, EncodeDelegate encode, int LengthField)
		{
			if (val.Length != LengthField)
				throw new ArgumentException ();
			else {
				for (int i = 0; i< LengthField; i++)
					encode (stream, val [i]);
			}
		}

		/// <summary> 
		/// Decodes and returns the parameterValue stored in the specified bufferStream.
		/// </summary>
		/// <param name="bufferStream">the bufferStream containing the encoded parameterValue
		/// </param>
		/// <returns> the decoded parameterValue
		/// </returns>
		public static T[] Decode (Stream stream, DecodeDelegate decode, int LengthField)
		{

			T[] rst = new T[LengthField];
			for (int i = 0; i< LengthField; i++)
				rst [i] = decode (stream);
			return rst;
		}

		public static int Size {
			get {
				//throw new NotImplementedException();
				return 0;
			}
		}


	}
	#endregion
}

