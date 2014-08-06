using RTPS.Messages.submessage.attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    /// <summary>
    /// IEncoder is used to transform Object to/from different data encodings.
    /// </summary>
    /// <typeparam name="T">
    /// Type of this Marshaller. Type is used to enforce symmetry between
    ///            unmarshall and marshall methods.
    ///</typeparam>
    public interface IEncoder<T>
    {
        /// <summary>
        /// Determines whether or not a key is associated with type T.
        /// </summary>
        bool HasKey { get; }

        /// <summary>
        /// Extracts a key from given object. If null is returned, it is assumed to
        /// be the same as a byte array of length 0. Returned byte array can be of any length.
        /// However, if the byte arrays length is greater than 15, it is internally converted to
        /// a MD5 hash.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] ExtractKey(T data);

        /// <summary>
        /// Unmarshalls given DataEncapsulation to Object.
        /// </summary>
        /// <param name="dEnc"></param>
        /// <returns></returns>
        T Decode(DataEncapsulation dEnc);

        /// <summary>
        /// Marshalls given Object to DataEncapsulation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataEncapsulation Encode(T data);
    }
}
