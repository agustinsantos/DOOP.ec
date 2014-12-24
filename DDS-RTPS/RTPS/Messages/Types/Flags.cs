namespace Rtps.Messages
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p30: Type used to specify a Submessage flag. 
    /// A Submessage flag takes a bool Value and affects the parsing of the
    /// Submessage by the receiver.
    /// There are 8 possible flags. The first flag (index 0) identifies the
    /// endianness used to encapsulate the Submessage. The remaining flags
    /// are interpreted differently depending on the kind of Submessage and
    /// are described separately for each Submessage.
    /// </summary>
    public struct Flags
    {
        /// <summary>
        /// Section 8.3.3.2 in the PIM defines the EndiannessFlag as a flag present
        /// in all Submessages that indicates the endianness used to encode the Submessage. 
        /// The PSM maps the EndiannessFlag flag into the least-significant bit (LSB) of the flags.
        /// This bit is therefore always present in all Submessages and represents the
        /// endianness used to encode the information in the Submessage. 
        /// </summary>
        public const byte EndiannessFlag = 0x01;

        public const byte FinalFlag = 0x02;

        public const byte InlineQosFlag = 0x02;
        public const byte DataFlag = 0x04;
        public const byte KeyFlag = 0x08;

        public const byte LivelinessFlag = 0x04;

        public const byte MulticastFlag = 0x02;

        public const byte InvalidateFlag = 0x02;

        private byte flags;

        public byte Value
        {
            get { return flags; }
            set { flags = value; }
        }

        /// <summary>
        /// Get the endianness for SubMessage. If endianness flag is Set,
        /// little-endian is used by SubMessage, otherwise big-endian is used.
        /// 
        /// Checks, if endianness flag of this SubMessageHeader represents little endian
        ///  byte order.
        /// </summary>
        /// <returns>true for little endian byte order</returns>
        public bool IsLittleEndian
        {
            get { return (flags & EndiannessFlag) == EndiannessFlag; }
        }


        /// <summary>
        /// Checks, if endianness flag of this SubMessageHeader represents big endian
        ///  byte order.
        /// </summary>
        /// <returns>true for big endian byte order</returns>
        public bool IsBigEndian
        {
            get { return !IsLittleEndian; }
        }

        /// <summary>
        /// Indicates to the Reader the presence of a ParameterList containing QoS
        ///  parameters that should be used to interpret the message.
        /// </summary>
        public bool HasInlineQosFlag
        {
            get { return (flags & InlineQosFlag) == InlineQosFlag; }
        }

        /// <summary>
        /// Indicates to the Reader that the dataPayload submessage element contains
        ///  the serialized Value of the data-object.
        /// </summary>
        public bool HasDataFlag
        {
            get { return (flags & DataFlag) == DataFlag; }
        }

        /// <summary>
        /// Indicates to the Reader that the dataPayload submessage element contains
        /// the serialized Value of the key of the data-object.
        /// </summary>
        public bool HasKeyFlag
        {
            get { return (flags & KeyFlag) == KeyFlag; }
        }

        public bool HasLivelinessFlag
        {
            get { return (flags & LivelinessFlag) == LivelinessFlag; }
        }
        public void SetLivelinessFlag(bool value)
        {
            if (value)

                flags |= LivelinessFlag;
            else
                flags = (byte)(flags & ~LivelinessFlag);

        }

        public bool HasMulticastFlag
        {
            get { return (flags & MulticastFlag) == MulticastFlag; }
        }
        public void SetMulticastFlag()
        {
            flags |= MulticastFlag;
        }

        public bool HasInvalidateFlag
        {
            get { return (flags & InvalidateFlag) == InvalidateFlag; }
        }

        public bool HasFinalFlag
        {
            get { return (flags & FinalFlag) == FinalFlag; }
        }
        public void SetFinalFlag(bool value)
        {
            if (value)

                flags |= FinalFlag;
            else
                flags = (byte)(flags & ~FinalFlag);

        }
    }
}
