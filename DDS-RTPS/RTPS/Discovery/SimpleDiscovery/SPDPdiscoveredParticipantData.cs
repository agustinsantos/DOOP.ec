using org.omg.dds.topic;
using Rtps.Behavior.Types;
using Rtps.Messages.Types;
using Rtps.Structure;
using Rtps.Structure.Types;
using System.Collections.Generic;

namespace Rtps.Discovery.Spdp
{
    public class SPDPdiscoveredParticipantData : ParticipantBuiltinTopicData
    {
        public const string PARTICIPANT_TOPIC = "DCPSParticipant";

        public SPDPdiscoveredParticipantData(Participant participant)
        {
            ParticipantProxyData = new ParticipantProxy(participant);
         }

        public ParticipantProxy ParticipantProxyData { get; set; }

        public Duration LeaseDuration { get; set; }

        public override BuiltinTopicKey Key
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.UserDataQosPolicy UserData
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override ParticipantBuiltinTopicData CopyFrom(ParticipantBuiltinTopicData other)
        {
            throw new System.NotImplementedException();
        }

        public override ParticipantBuiltinTopicData finishModification()
        {
            throw new System.NotImplementedException();
        }

        public override ParticipantBuiltinTopicData Clone()
        {
            throw new System.NotImplementedException();
        }

        public override ParticipantBuiltinTopicData Modify()
        {
            throw new System.NotImplementedException();
        }

        public override org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return PARTICIPANT_TOPIC + string.Format("{key: {0}, QoS: {1}}", this.Key, this.UserData);
        }
    }
}
