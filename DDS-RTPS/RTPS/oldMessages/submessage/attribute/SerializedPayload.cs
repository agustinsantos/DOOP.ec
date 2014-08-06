

using Rtps.messages.elements;
namespace Rtps.messages.submessage.attribute
{
    /// <summary>
    /// A SerializedPayload SubmessageElement contains the serialized representation of either value of an applicationdefined
    /// data-object or the value of the key that uniquely identifies the data-object.
    /// The specification of the process used to encapsulate the application-level data-type into a serialized byte-stream is not
    /// strictly part of the RTPS protocol. For the purpose of interoperability, all implementations must however use a consistent
    /// </summary>
    public class SerializedPayload : SubMessageElement
    {
        private byte[] value;

        public SerializedPayload(byte[] val)
            : base(-1)
        {
            value = val;
        }
    }
}
