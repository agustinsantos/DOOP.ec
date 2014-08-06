using rtps.messages.elements;

namespace rtps.messages.submessage.attribute
{

    public class SerializedPayloadFragment : SubMessageElement
    {
        private byte[] value;

        public SerializedPayloadFragment(byte[] val) : base(-1)
        {
            value = val;
        }

    }
}
