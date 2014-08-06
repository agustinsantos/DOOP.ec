

namespace Rtps.messages.elements
{
    public class KeyHash : SubMessageElement
    {
        public static int KEY_HASH_PREFIX_SIZE = 12;

        public byte[] value; //[12];

        public KeyHash(byte[] value)
            : base(KEY_HASH_PREFIX_SIZE)
        {
            this.value = value;
        }



    }
}
