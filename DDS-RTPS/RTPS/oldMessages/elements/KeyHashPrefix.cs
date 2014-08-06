using Rtps.Structure.Types;
namespace rtps.messages.elements
{
    public class KeyHashPrefix : GuidPrefix
    {
        public byte[] value; //[12];

        public KeyHashPrefix(byte[] value)
            : base(value)
        {
            this.value = value;
        }


    }
}