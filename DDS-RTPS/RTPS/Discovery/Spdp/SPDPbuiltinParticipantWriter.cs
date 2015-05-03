using Rtps.Behavior;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Rtps.Discovery.Sedp
{
    /// <summary>
    /// For each Participant, the SPDP creates two RTPS built-in Endpoints: the
    /// SPDPbuiltinParticipantWriter and the SPDPbuiltinParticipantReader.
    /// The SPDPbuiltinParticipantWriter is an RTPS Best-Effort StatelessWriter. The HistoryCache of the
    /// SPDPbuiltinParticipantWriter contains a single data-object of type SPDPdiscoveredParticipantData. 
    /// The Value of this data-object is Set from the attributes in the Participant. 
    /// If the attributes change, the data-object is replaced.
    /// </summary>
    public class SPDPbuiltinParticipantWriter : StatelessWriter<SPDPdiscoveredParticipantData>
    {
        public SPDPbuiltinParticipantWriter(GUID guid)
            : base(guid)
        {
            this.guid = new GUID(guid.Prefix, EntityId.ENTITYID_SPDP_BUILTIN_PARTICIPANT_WRITER);

            this.TopicKind = TopicKind.WITH_KEY;
            this.ReliabilityLevel = ReliabilityKind.BEST_EFFORT;
        }
    }
}
