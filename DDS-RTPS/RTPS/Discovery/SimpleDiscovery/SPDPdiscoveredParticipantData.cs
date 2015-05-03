using org.omg.dds.core.policy;
using org.omg.dds.topic;
using org.omg.dds.type;
using Rtps.Attributes;
using Rtps.Behavior.Types;
using Rtps.Messages.Types;
using Rtps.Structure;
using Rtps.Structure.Types;
using System.Collections.Generic;

namespace Rtps.Discovery.Spdp
{
    /// <summary>
    /// The SPDPdiscoveredParticipantData defines the data exchanged as part of the SPDP. 
    /// </summary>
    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    public class SPDPdiscoveredParticipantData
    {
        [ID(0x0050)]
        [Key]
        public GUID Key { get; set; }

        [ID(0x002C)]
        public byte[] UserData { get; set; }

        public ParticipantProxy ParticipantProxy { get; set; }
        
        public SPDPdiscoveredParticipantData()
        {
        }

        public SPDPdiscoveredParticipantData(Participant participant)
        {
            this.Key = participant.Guid;
            this.ParticipantProxy = new ParticipantProxy(participant);
        }
        public override string ToString()
        {
            return string.Format("DCPSParticipant{key: {0}, QoS: {1}}", this.Key, this.UserData);
        }
    }
    public class SPDPdiscoveredParticipantData_OLD : ParticipantBuiltinTopicData
    {
        public const string PARTICIPANT_TOPIC = "DCPSParticipant";

        // TODO, this constructor is defined just only for testing
        public SPDPdiscoveredParticipantData_OLD()
        { }

        public SPDPdiscoveredParticipantData_OLD(Participant participant)
        {
            ParticipantProxyData = new ParticipantProxy(participant);
        }

        private BuiltinTopicKey key;
        private UserDataQosPolicy userData;

        [NonField]
        public ParticipantProxy ParticipantProxyData { get; set; }

        [NonField]
        public Duration LeaseDuration { get; set; }

        public override BuiltinTopicKey Key { get { return key; } }

        public override UserDataQosPolicy UserData { get { return userData; } }
       

        public override ParticipantBuiltinTopicData CopyFrom(ParticipantBuiltinTopicData other)
        {
            throw new System.NotImplementedException();
        }

        public override ParticipantBuiltinTopicData FinishModification()
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

        public override org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return PARTICIPANT_TOPIC + string.Format("{key: {0}, QoS: {1}}", this.Key, this.UserData);
        }
    }
}
