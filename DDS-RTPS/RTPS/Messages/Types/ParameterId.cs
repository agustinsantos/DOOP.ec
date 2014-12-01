
namespace Rtps.Messages.Types
{
    /// <summary>
    /// ParameterIds for Data submessage. see table 9.12 & table 9.14 & Table 9.17
    /// </summary>
    public enum ParameterId : ushort
    {
        PID_PAD = 0x0000,
        PID_SENTINEL = 0x0001,
        PID_USER_DATA = 0x002c, // UserDataQosPolicy
        PID_TOPIC_NAME = 0x0005, // string<256>
        PID_TYPE_NAME = 0x0007, // string<256>
        PID_GROUP_DATA = 0x002d, // GroupDataQosPolicy
        PID_TOPIC_DATA = 0x002e, // TopicDataQosPolicy
        PID_DURABILITY = 0x001d, // DurabilityQosPolicy
        PID_DURABILITY_SERVICE = 0x001e, // DurabilitServiceyQosPolicy
        PID_DEADLINE = 0x0023, // DeadLineQosPolicy
        PID_LATENCY_BUDGET = 0x0027, // LatencyBudgetQosPolicy
        PID_LIVELINESS = 0x001b, // LivelinessQosPolicy
        PID_RELIABILITY = 0x001a, // ReliabilityQosPolicy
        PID_LIFESPAN = 0x002b, // LifeSpanQosPolicy
        PID_DESTINATION_ORDER = 0x0025,
        PID_HISTORY = 0x0040,
        PID_RESOURCE_LIMITS = 0x0041,
        PID_OWNERSHIP = 0x001f,
        PID_OWNERSHIP_STRENGTH = 0x0006,
        PID_PRESENTATION = 0x0021,
        PID_PARTITION = 0x0029,
        PID_TIME_BASED_FILTER = 0x0004,
        PID_TRANSPORT_PRIORITY = 0x0049,
        PID_PROTOCOL_VERSION = 0x0015,
        PID_VENDORID = 0x0016,
        PID_UNICAST_LOCATOR = 0x002f,
        PID_MULTICAST_LOCATOR = 0x0030,
        PID_MULTICAST_IPADDRESS = 0x0011,
        PID_DEFAULT_UNICAST_LOCATOR = 0x0031,
        PID_DEFAULT_MULTICAST_LOCATOR = 0x0048,
        PID_METATRAFFIC_UNICAST_LOCATOR = 0x0032,
        PID_METATRAFFIC_MULTICAST_LOCATOR = 0x0033,
        PID_DEFAULT_UNICAST_IPADDRESS = 0x000c,
        PID_DEFAULT_UNICAST_PORT = 0x000e,
        PID_METATRAFFIC_UNICAST_IPADDRESS = 0x0045,
        PID_METATRAFFIC_UNICAST_PORT = 0x000d,
        PID_METATRAFFIC_MULTICAST_IPADDRESS = 0x000b,
        PID_METATRAFFIC_MULTICAST_PORT = 0x0046,
        PID_EXPECTS_INLINE_QOS = 0x0043,
        PID_PARTICIPANT_MANUAL_LIVELINESS_COUNT = 0x0034,
        PID_PARTICIPANT_BUILTIN_ENDPOINTS = 0x0044,
        PID_PARTICIPANT_LEASE_DURATION = 0x0002,
        PID_CONTENT_FILTER_PROPERTY = 0x0035,
        PID_PARTICIPANT_GUID = 0x0050,
        PID_PARTICIPANT_ENTITYID = 0x0051,
        PID_GROUP_GUID = 0x0052,
        PID_GROUP_ENTITYID = 0x0053,
        PID_BUILTIN_ENDPOINT_SET = 0x0058,
        PID_PROPERTY_LIST = 0x0059,
        PID_TYPE_MAX_SIZE_SERIALIZED = 0x0060,
        PID_ENTITY_NAME = 0x0062,
        PID_KEY_HASH = 0x0070,
        PID_STATUS_INFO = 0x0071,

        // Table 9.14 adds following PIDs
        PID_CONTENT_FILTER_INFO = 0x0055,
        PID_COHERENT_SET = 0x0056,
        PID_DIRECTED_WRITE = 0x0057,
        PID_ORIGINAL_WRITER_INFO = 0x0061,

        // Table 9.17 lists deprecated PIDs
        PID_PERSISTENCE = 0x0003,
        PID_TYPE_CHECKSUM = 0x0008,
        PID_TYPE2_NAME = 0x0009,
        PID_TYPE2_CHECKSUM = 0x000a,
        PID_EXPECTS_ACK = 0x0010,
        PID_MANAGER_KEY = 0x0012,
        PID_SEND_QUEUE_SIZE = 0x0013,
        PID_RELIABILITY_ENABLED = 0x0014,
        PID_VARGAPPS_SEQUENCE_NUMBER_LAST = 0x0017,
        PID_RECV_QUEUE_SIZE = 0x0018,
        PID_RELIABILITY_OFFERED = 0x0019,

        PID_VENDOR_SPECIFIC = 0x8000, // is just invented, @see 9.6.2.2.1

        // ParameterId space
        PID_UNKNOWN_PARAMETER = ushort.MinValue // it is just invented, @see 9.6.2.2.1
        // ParameterId space
    }
}
