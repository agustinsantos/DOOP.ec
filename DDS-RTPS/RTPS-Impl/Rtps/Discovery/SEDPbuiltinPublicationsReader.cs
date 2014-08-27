using Rtps.Behavior;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{
    public class SEDPbuiltinPublicationsReader : StatefulReader<DiscoveredWriterData>
    {
        public SEDPbuiltinPublicationsReader(Participant participant)
            : base(participant)
        {
            this.guid = new GUID(participant.Guid.Prefix, EntityId.ENTITYID_SEDP_BUILTIN_PUBLICATIONS_READER);
        }
    }
}
