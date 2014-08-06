using Rtps.Messages.Types;
using System.Text;

namespace Rtps.Messages
{

    public enum EndiannessFlag
    {
        BigEndian = 0,
        LittleEndian = 1
    }

    /// <summary>
    /// A Header of the SubMessage. see 8.3.3.2 Submessage structure
    /// 
    /// In case octetsToNextHeader > 0, it is the number of octets from the first octet of the contents of the Submessage until the
    /// first octet of the header of the next Submessage (in case the Submessage is not the last Submessage in the Message) OR
    /// it is the number of octets remaining in the Message (in case the Submessage is the last Submessage in the Message). An
    /// interpreter of the Message can distinguish these two cases as it knows the total length of the Message.
    /// 
    /// In case octetsToNextHeader==0 and the kind of Submessage is NOT PAD or INFO_TS, the Submessage is the last
    /// Submessage in the Message and  : up to the end of the Message. This makes it possible to send Submessages
    /// larger than 64k (the size that can be stored in the octetsToNextHeader field), provided they are the last Submessage in the
    /// Message.
    /// 
    /// In case the octetsToNextHeader==0 and the kind of Submessage is PAD or INFO_TS, the next Submessage header starts
    /// immediately after the current Submessage header OR the PAD or INFO_TS is the last Submessage in the Message.
    /// 
    /// </summary>
    public class SubMessageHeader
    {
        /// <summary>
        /// Default value for endianness in sub messages.
        /// </summary>
        private static readonly byte DEFAULT_ENDIANNESS_FLAG = 0x00;

        public const int MAXIMUM_SUBMESSAGE_LENGTH = 64000;

        private SubMessageKind kind;
        private Flags flags; // 8 flags
        private ushort submessageLength;

        internal SubMessageHeader()
            : this((SubMessageKind)0, DEFAULT_ENDIANNESS_FLAG)
        {
        }

        /// <summary>
        /// Constructs this SubMessageHeader with given kind and
        /// DEFAULT_ENDIANESS_FLAG. Length of the SubMessage is set to 0. Length will
        /// be calculated during marshalling of the Message.
        /// </summary>
        /// <param name="kind"></param>
        public SubMessageHeader(SubMessageKind kind)
            : this(kind, DEFAULT_ENDIANNESS_FLAG)
        {
        }


        /// <summary>
        /// Constructs this SubMessageHeader with given kind and flags. Length of the
        /// SubMessage is set to 0. Length will be calculated during marshalling of
        /// the Message.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="flags"></param>
        public SubMessageHeader(SubMessageKind kind, byte flags)
        {
            this.kind = kind;
            this.flags.Value = flags;
            this.submessageLength = 0; // Length will be calculated at runtime 
        }

        /// <summary>
        /// Get the endianness for SubMessage. If endianness flag is set,
        /// little-endian is used by SubMessage, otherwise big-endian is used.
        /// 
        /// Checks, if endianness flag of this SubMessageHeader represents little endian
        ///  byte order.
        /// </summary>
        /// <returns>true for little endian byte order</returns>
        public bool IsLittleEndian
        {
            get { return flags.IsLittleEndian; }
        }


        /// <summary>
        /// Checks, if endianness flag of this SubMessageHeader represents big endian
        ///  byte order.
        /// </summary>
        /// <returns>true for big endian byte order</returns>
        public bool IsBigEndian
        {
            get { return flags.IsBigEndian; }
        }

        /// <summary>
        /// Get the kind of SubMessage
        /// </summary>
        public SubMessageKind SubMessageKind
        {
            get { return kind; }
            set { kind = value; }
        }

        /// <summary>
        /// Get the Flags of SubMessage as byte
        /// </summary>
        public byte FlagsValue
        {
            get { return flags.Value; }
            set { flags.Value = value; }
        }

        /// <summary>
        /// Get the Flags of SubMessage
        /// </summary>
        public Flags Flags
        {
            get { return flags; }
            set { flags = value; }
        }

        /// <summary>
        /// Get the length of the sub message.
        /// </summary>
        /// <returns>length of the sub message</returns>
        public ushort SubMessageLength
        {
            get { return submessageLength; }
            set { submessageLength = value; }
        }


        public override string ToString()
        {
            return string.Format("header[{0}, {1}, {2}]", (int)kind, flags.Value, ((int)submessageLength) & 0xffff);
        }
    }
}
