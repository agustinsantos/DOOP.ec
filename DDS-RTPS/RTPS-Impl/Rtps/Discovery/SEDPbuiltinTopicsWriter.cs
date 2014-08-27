using Rtps.Behavior;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{
    public class SEDPbuiltinTopicsWriter : StatefulWriter<DiscoveredTopicData>
    {
        public SEDPbuiltinTopicsWriter(Participant participant)
            : base(participant)
        {
            this.guid = new GUID(participant.Guid.Prefix, EntityId.ENTITYID_SEDP_BUILTIN_TOPIC_WRITER);
        }

    }
}
