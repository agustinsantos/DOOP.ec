using System;
using System.Diagnostics;
using System.IO;

namespace Sxta.GenericProtocol.Encoding
{
#if TODO
	#region Encodign Little-Endian
	public class ArrayEncodingLE<T>
	{

		public delegate void EncodeDelegate(Stream stream, T val);
		public delegate T DecodeDelegate(Stream stream);

        /// <summary> 
        /// Encodes the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="parameterValue">the value to Encode
        /// </param>
        /// <returns> 
        /// a byte array containing the encoded value
        /// An array of bytes with length 2.
        /// </return
        public static void Encode(Stream stream, T[] val, EncodeDelegate encode)
        {
            if (val == null)
                Int32EncodingLE.Encode(stream, -1);
            else
            {
				Int32EncodingLE.Encode(stream, val.Length);
				foreach(T v in val)
					encode(stream, v);
            }
        }

        /// <summary> 
        /// Decodes and returns the parameterValue stored in the specified bufferStream.
        /// </summary>
        /// <param name="bufferStream">the bufferStream containing the encoded parameterValue
        /// </param>
        /// <returns> the decoded parameterValue
        /// </returns>
        public static T[] Decode(Stream stream, DecodeDelegate decode)
        {
            int len = Int32EncodingLE.Decode(stream);
            if (len == -1) return null;
			T[] rst = new T[len];
			for (int i = 0; i< len; i++)
				rst[i] = decode (stream);
            return rst;
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
	public class ArrayEncodingBE<T>
	{

		public delegate void EncodeDelegate(Stream stream, T val);
		public delegate T DecodeDelegate(Stream stream);

        /// <summary> 
        /// Encodes the specified value, returning the result as a byte array.
        /// </summary>
        /// <param name="parameterValue">the value to Encode
        /// </param>
        /// <returns> 
        /// a byte array containing the encoded value
        /// An array of bytes with length 2.
        /// </return
        public static void Encode(Stream stream, T[] val, EncodeDelegate encode)
        {
            if (val == null)
                Int32EncodingBE.Encode(stream, -1);
            else
            {
				Int32EncodingBE.Encode(stream, val.Length);
				foreach(T v in val)
					encode(stream, v);
            }
        }

        /// <summary> 
        /// Decodes and returns the parameterValue stored in the specified bufferStream.
        /// </summary>
        /// <param name="bufferStream">the bufferStream containing the encoded parameterValue
        /// </param>
        /// <returns> the decoded parameterValue
        /// </returns>
        public static T[] Decode(Stream stream, DecodeDelegate decode)
        {
            int len = Int32EncodingBE.Decode(stream);
            if (len == -1) return null;
			T[] rst = new T[len];
			for (int i = 0; i< len; i++)
				rst[i] = decode (stream);
            return rst;
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
#endif
}

