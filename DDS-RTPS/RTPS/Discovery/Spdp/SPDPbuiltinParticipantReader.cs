using Rtps.Behavior;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{

    /// <summary>
    /// TODO esta clase ya no vale. Tengo que borrarla y poner en su lugar la que se 
    /// llama SPDPbuiltinParticipantReaderImpl
    /// </summary>
    public class SPDPbuiltinParticipantReader : StatelessReader<SPDPdiscoveredParticipantData>
    {
        public SPDPbuiltinParticipantReader(GUID guid)
            : base(guid)
        {
            this.TopicKind = TopicKind.WITH_KEY;
            this.ReliabilityLevel = ReliabilityKind.BEST_EFFORT;
        }
    }
}
