
namespace rtps.messages.elements
{

    public abstract class SubMessageElement
    {
        //	public static int SEQUENCE_NUMBER_SET_SIZE = 12;
        //	public static int FRAGMENT_NUMBER_SET_SIZE = 8;
        public static int TIMESTAMP_SIZE = 8;
        //	public static int PARAMETER_LIST_SIZE = 4;
        public static int KEY_HASH_SUFFIX_SIZE = 4;
        public static int LOCATOR_UDP_V4_SIZE = 8;
        public static int RTPS_HEADER_SIZE = 20;
 
        protected readonly int size;

        public SubMessageElement(int size)
        {
            this.size = size;
        }

        /// <summary>
        /// Returns the size in bytes of this submessage element
        /// when it is encoded in CDR.
        /// </summary>
        public int Size { get { return size; } }
    }
}