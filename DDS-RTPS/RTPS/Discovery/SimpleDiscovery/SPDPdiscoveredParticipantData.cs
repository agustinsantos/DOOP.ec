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

        public override BuiltinTopicKey getKey()
        {
            throw new System.NotImplementedException();
        }

        public override org.omg.dds.core.policy.UserDataQosPolicy getUserData()
        {
            throw new System.NotImplementedException();
        }

        public override ParticipantBuiltinTopicData copyFrom(ParticipantBuiltinTopicData other)
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

        public override ParticipantBuiltinTopicData modify()
        {
            throw new System.NotImplementedException();
        }

        public override org.omg.dds.core.Bootstrap GetBootstrap
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override string ToString()
        {
            return PARTICIPANT_TOPIC + "{key: " + getKey() + ", QoS: " + getUserData()+"}";
        }
    }
}
