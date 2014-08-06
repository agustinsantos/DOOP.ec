/**
 * From OMG RTPS Standard v2.1 p35: The interpretation and meaning of a Submessage
 * within a Message may depend on the previous Submessages contained within that 
 * same Message. Therefore, the receiver of a Message must maintain state from 
 * previously deserialized Submessages in the same Message. This state is modeled
 * as the state of an RTPS Receiver that is reset each time a new message is
 * processed and provides context for the interpretation of each Submessage.
 */
#if TODO

using RTPS;
using System.Collections.Generic;
namespace rtps.messages.message
{

    public class Receiver
    {
        public ProtocolVersion_t sourceVersion = ProtocolVersion_t.PROTOCOLVERSION;
        public VendorId_t vendorId = VendorId_t.VENDORID_UNKNOWN;
        public GuidPrefix_t sourceGuidPrefix;
        public GuidPrefix_t destGuidPrefix;
        public IList<Locator_t> unicastReplyLocatorList = new List<Locator_t>();
        public IList<Locator_t> multicastReplyLocatorList = new List<Locator_t>();
        public bool haveTimestamp;
        public Time_t timestamp;

        public Receiver(GuidPrefix_t destination)
        {
            destGuidPrefix = destination;
            unicastReplyLocatorList.Add(LOCATOR_INVALID.value);
            multicastReplyLocatorList.Add(LOCATOR_INVALID.value);
            haveTimestamp = false;
            timestamp = TIME_INVALID.value;
        }

        public Receiver(Header header)
        {
            sourceGuidPrefix = header.guidPrefix;
            sourceVersion = header.version;
            sourceVendorId = header.vendorId;
            haveTimestamp = false;
        }
    }
}
#endif