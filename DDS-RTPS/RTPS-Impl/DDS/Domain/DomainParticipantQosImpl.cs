using Doopec.DDS.Core;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;
using System;
using System.Text;

namespace Doopec.DDS.Domain
{
    public class DomainParticipantQosImpl : EntityQosImpl<DomainParticipantQos, ModifiableDomainParticipantQos>, DomainParticipantQos
    {
        public readonly DomainParticipantQosImpl DDS_PARTICIPANT_QOS_DEFAULT;

        public UserDataQosPolicy UserData {get; internal set;}
        public EntityFactoryQosPolicy EntityFactoryQosPolicy { get; internal set; }

        public DomainParticipantQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {
            // TODO 
            // DDS_PARTICIPANT_QOS_DEFAULT = new DomainParticipantQosImpl(boostrap);
            UserData = new UserDataQosPolicyImpl(boostrap);
            EntityFactoryQosPolicy = new EntityFactoryQosPolicyImpl(boostrap);
        }

        public DomainParticipantQosImpl(UserDataQosPolicy userData, EntityFactoryQosPolicy entityFactoryQosPolicy, Bootstrap boostrap)
            : base(boostrap)
        {
            this.UserData = userData;
            this.EntityFactoryQosPolicy = entityFactoryQosPolicy;
        }

        public UserDataQosPolicy GetUserData()
        {
            return UserData;
        }

        public EntityFactoryQosPolicy GetEntityFactory()
        {
            return EntityFactoryQosPolicy;
        }

        public override ModifiableDomainParticipantQos Modify()
        {
            throw new System.NotImplementedException();
        }

        public static DomainParticipantQosImpl ConvertTo(Doopec.Configuration.Dds.DomainParticipantQoS qosConfig, Bootstrap boostrap)
        {
            DomainParticipantQosImpl rst = new DomainParticipantQosImpl(boostrap);
            rst.UserData = new UserDataQosPolicyImpl(UTF8Encoding.Unicode.GetBytes(qosConfig.UserData.Value), boostrap);
            rst.EntityFactoryQosPolicy = new EntityFactoryQosPolicyImpl(qosConfig.EntityFactory.AutoenableCreatedEntities, boostrap);
            return rst;
        }
    }
}
