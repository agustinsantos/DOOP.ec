

namespace Rtps.Messages.Types
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p30: Enumeration used to identify the kind of
    /// Submessage. The following values are reserved by this version of the protocol:
    /// DATA, GAP, HEARTBEAT, ACKNACK, PAD, INFO_TS, INFO_REPLY, INFO_DST, INFO_SRC, 
    /// DATA_FRAG, NACK_FRAG, HEARTBEAT_FRAG
    /// </summary>
    public enum SubMessageKind : byte
    {
        PAD = 0x01,            /* Pad */
        ACKNACK = 0x06,        /* AckNack */
        HEARTBEAT = 0x07,      /* Heartbeat */
        GAP = 0x08,            /* Gap */
        INFO_TS = 0x09,        /* InfoTimestamp */
        INFO_SRC = 0x0c,       /* InfoSource */
        INFO_REPLY_IP4 = 0x0d, /* InfoReplyIp4 */
        INFO_DST = 0x0e,       /* InfoDestination */
        INFO_REPLY = 0x0f,     /* InfoReply */
        NACK_FRAG = 0x12,      /* NackFrag */
        HEARTBEAT_FRAG = 0x13, /* HeartbeatFrag */
        DATA = 0x15,           /* Data */
        DATA_FRAG = 0x16,      /* DataFrag */
    }
}
