using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTests.XTypes
{
    /*
     Here we have to tests that the following values are well defined. See Table 9.12 at page 182 of RTPS
        PID_PAD 0x0000 N/A
        PID_SENTINEL 0x0001 N/A
        PID_USER_DATA 0x002c UserDataQosPolicy
        PID_TOPIC_NAME 0x0005 string<256>
        PID_TYPE_NAME 0x0007 string<256>
        PID_GROUP_DATA 0x002d GroupDataQosPolicy
        PID_TOPIC_DATA 0x002e TopicDataQosPolicy
        PID_DURABILITY 0x001d DurabilityQosPolicy
        PID_DURABILITY_SERVICE 0x001e DurabilityServiceQosPolicy
        PID_DEADLINE 0x0023 DeadlineQosPolicy
        PID_LATENCY_BUDGET 0x0027 LatencyBudgetQosPolicy
        PID_LIVELINESS 0x001b LivelinessQosPolicy
        PID_RELIABILITY 0x001A ReliabilityQosPolicy
        PID_LIFESPAN 0x002b LifespanQosPolicy
        PID_DESTINATION_ORDER 0x0025 DestinationOrderQosPolicy
        PID_HISTORY 0x0040 HistoryQosPolicy
        PID_RESOURCE_LIMITS 0x0041 ResourceLimitsQosPolicy
        PID_OWNERSHIP 0x001f OwnershipQosPolicy
        PID_OWNERSHIP_STRENGTH 0x0006 OwnershipStrengthQosPolicy
        PID_PRESENTATION 0x0021 PresentationQosPolicy
        PID_PARTITION 0x0029 PartitionQosPolicy
        PID_TIME_BASED_FILTER 0x0004 TimeBasedFilterQosPolicy
        PID_TRANSPORT_PRIORITY 0x0049 TransportPriorityQoSPolicy
        PID_PROTOCOL_VERSION 0x0015 ProtocolVersion_t
        PID_VENDORID 0x0016 VendorId_t
        PID_UNICAST_LOCATOR 0x002f Locator_t
        PID_MULTICAST_LOCATOR 0x0030 Locator_t
        PID_MULTICAST_IPADDRESS 0x0011 IPv4Address_t
        PID_DEFAULT_UNICAST_LOCATOR 0x0031 Locator_t
        PID_DEFAULT_MULTICAST_LOCATOR 0x0048 Locator_t
        PID_METATRAFFIC_UNICAST_LOCATOR 0x0032 Locator_t
        PID_METATRAFFIC_MULTICAST_LOCATOR 0x0033 Locator_t
        PID_DEFAULT_UNICAST_IPADDRESS 0x000c IPv4Address_t
        PID_DEFAULT_UNICAST_PORT 0x000e Port_t
        PID_METATRAFFIC_UNICAST_IPADDRESS 0x0045 IPv4Address_t
        PID_METATRAFFIC_UNICAST_PORT 0x000d Port_t
        PID_METATRAFFIC_MULTICAST_IPADDRESS 0x000b IPv4Address_t
        PID_METATRAFFIC_MULTICAST_PORT 0x0046 Port_t
        PID_EXPECTS_INLINE_QOS 0x0043 boolean
        PID_PARTICIPANT_MANUAL_LIVELINESS_COUNT 0x0034 Count_t
        PID_PARTICIPANT_BUILTIN_ENDPOINTS 0x0044 unsigned long
        PID_PARTICIPANT_LEASE_DURATION 0x0002 Duration_t
        PID_CONTENT_FILTER_PROPERTY 0x0035 ContentFilterProperty_t
        PID_PARTICIPANT_GUID 0x0050 GUID_t
        PID_PARTICIPANT_ENTITYID 0x0051 EntityId_t
        PID_GROUP_GUID 0x0052 GUID_t
        PID_GROUP_ENTITYID 0x0053 EntityId_t
        PID_BUILTIN_ENDPOINT_SET 0x0058 BuiltinEndpointSet_t
        PID_PROPERTY_LIST 0x0059 sequence<Property_t>
        PID_TYPE_MAX_SIZE_SERIALIZED 0x0060 long
        PID_ENTITY_NAME 0x0062 EntityName_t
        PID_KEY_HASH 0x0070 KeyHash_t
        PID_STATUS_INFO 0x0071 StatusInfo_t
     */

    [TestClass]
    public class QosExplorerTestTests
    {


        [TestMethod]
        public void TestPID_PAD()
        {
            throw new NotImplementedException();
        }
    }
}
