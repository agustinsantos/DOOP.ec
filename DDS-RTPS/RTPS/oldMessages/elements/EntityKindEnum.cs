
namespace rtps.messages.elements
{

    public sealed class EntityKindEnum
    {

        /*
         * These are implementation-specific kinds to include every DDS type
         * in the specification of the kind.<br/>
         * More we introduce another distinction between local entities and
         * remote entities through the 0x30 bits... Remote entities are
         * classified locally as 'proxy'
         */

        /* SUBSCRIBER (LOCAL) */
        public static readonly byte SUBSCRIBER = (byte)0x08;

        /* PUBLISHER (LOCAL) */
        public static readonly byte PUBLISHER = (byte)0x09;

        /* TOPIC */
        public static readonly byte USER_DEF_TOPIC = (byte)0x05;
        public static readonly byte BUILTIN_TOPIC = (byte)0xc5;

        /* INSTANCES ??? */
        public static readonly byte INSTANCE_HANDLE = (byte)0x06;

        /* REMOTE ENTITIES */
        public static readonly byte REMOTE_BUILTIN_UNKNOWN = (byte)0x30;
        public static readonly byte REMOTE_USER_DEF_UNKNOWN = (byte)0xF0;

        public static readonly byte REMOTE_BUILTIN_PARTICIPANT = (byte)0xF1;

        public static readonly byte REMOTE_USER_DEF_WRITER_W_KEY = (byte)0x32;
        public static readonly byte REMOTE_BUILTIN_WRITER_W_KEY = (byte)0xF2;

        public static readonly byte REMOTE_USER_DEF_WRITER_NO_KEY = (byte)0x33;
        public static readonly byte REMOTE_BUILTIN_WRITER_NO_KEY = (byte)0xF3;

        public static readonly byte REMOTE_USER_DEF_READER_W_KEY = (byte)0x34;
        public static readonly byte REMOTE_BUILTIN_READER_W_KEY = (byte)0xF4;

        public static readonly byte REMOTE_USER_DEF_READER_NO_KEY = (byte)0x37;
        public static readonly byte REMOTE_BUILTIN_READER_NO_KEY = (byte)0xF7;

    }
}
