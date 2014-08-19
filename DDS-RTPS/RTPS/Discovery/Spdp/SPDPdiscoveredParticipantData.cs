using Rtps.Behavior.Types;

namespace Rtps.Discovery.Spdp
{
    public class SPDPdiscoveredParticipantData
    {
        public const string PARTICIPANT_TOPIC = "DCPSParticipant";

        //TODO  public ParticipantBuiltinTopicData ddsParticipantData;
        public ParticipantProxy ParticipantProxy { get; set; }
        public Duration LeaseDuration { get; set; }
    }
}
