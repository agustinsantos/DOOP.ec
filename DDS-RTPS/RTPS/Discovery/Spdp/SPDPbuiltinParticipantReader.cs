using Rtps.Behavior;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{
    public class SPDPbuiltinParticipantReader : StatelessReader<SPDPdiscoveredParticipantData>
    {
        public SPDPbuiltinParticipantReader(Participant participant)
            : base(participant)
        {
            this.guid = new GUID(participant.Guid.Prefix, EntityId.ENTITYID_SPDP_BUILTIN_PARTICIPANT_READER);

            this.TopicKind = TopicKind.WITH_KEY;
            this.ReliabilityLevel = ReliabilityKind.BEST_EFFORT;
        }
    }
}
