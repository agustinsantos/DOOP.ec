using Rtps.Behavior;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{
    public class SEDPbuiltinSubscriptionsReader : StatefulReader<DiscoveredReaderData>
    {
        public SEDPbuiltinSubscriptionsReader(GUID guid)
            : base(guid)
        {
            this.guid = new GUID(guid.Prefix, EntityId.ENTITYID_SEDP_BUILTIN_SUBSCRIPTIONS_READER);
        }

    }
}
