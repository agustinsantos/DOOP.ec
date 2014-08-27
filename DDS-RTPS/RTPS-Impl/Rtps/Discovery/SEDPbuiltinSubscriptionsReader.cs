using Rtps.Behavior;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{
    public class SEDPbuiltinSubscriptionsReader : StatefulReader<DiscoveredReaderData>
    {
        public SEDPbuiltinSubscriptionsReader(Participant participant)
            : base(participant)
        {
             this.guid = new GUID(participant.Guid.Prefix, EntityId.ENTITYID_SEDP_BUILTIN_SUBSCRIPTIONS_READER);
        }

    }
}
