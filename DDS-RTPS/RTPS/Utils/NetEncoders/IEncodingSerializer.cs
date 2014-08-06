using Sxta.GenericProtocol.Encoding;

namespace Sxta.Rti1516e.Encoding
{
    public interface IEncodingSerializer<T>
    {
        /// <summary>
        /// Deserialize data from the specified stream, rebuilding
        /// the object hierarchy
        /// </summary>
        /// <param name="buffer">the serialization buffer</param>
        /// <param name="obj"> the object to deserialized is provided</param>
        /// <returns>the new deserialized object </returns>
        T Decode(ByteWrapper buffer);

        /// <summary>
        /// Serialize the specified object to the specified stream.
        /// </summary>
        /// <param name="buffer">the serialization buffer</param>
        /// <param name="obj">the object to serialize</param>
        void Encode(ByteWrapper buffer, T obj);
    }
}
