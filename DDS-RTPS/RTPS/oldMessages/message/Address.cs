namespace jdds.rtps.messages.message
{
    internal struct Address
    {
        public byte[] addr;// = new byte[16];

        public Address(byte[] address)
        {

            addr = address;
        }

        public static readonly Address ADDRESS_INVALID = new Address();
    }
}
