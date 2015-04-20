using Doopec.DDS.Core;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;

namespace Doopec.DDS.Domain
{
    public class DomainParticipantQosImpl : EntityQosImpl<DomainParticipantQos, ModifiableDomainParticipantQos>, DomainParticipantQos
    {
        public readonly DomainParticipantQosImpl DDS_PARTICIPANT_QOS_DEFAULT;

        private readonly UserDataQosPolicy userData;
        private readonly EntityFactoryQosPolicy entityFactoryQosPolicy;

        public DomainParticipantQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {
            // TODO 
            // DDS_PARTICIPANT_QOS_DEFAULT = new DomainParticipantQosImpl(boostrap);
            userData = new UserDataQosPolicyImpl(boostrap);
            entityFactoryQosPolicy = new EntityFactoryQosPolicyImpl(boostrap);
        }

        public DomainParticipantQosImpl(UserDataQosPolicy userData, EntityFactoryQosPolicy entityFactoryQosPolicy, Bootstrap boostrap)
            : base(boostrap)
        {
            this.userData = userData;
            this.entityFactoryQosPolicy = entityFactoryQosPolicy;
        }

        public UserDataQosPolicy GetUserData()
        {
            return userData;
        }

        public EntityFactoryQosPolicy GetEntityFactory()
        {
            return entityFactoryQosPolicy;
        }

        public override ModifiableDomainParticipantQos Modify()
        {
            throw new System.NotImplementedException();
        }
    }
}
