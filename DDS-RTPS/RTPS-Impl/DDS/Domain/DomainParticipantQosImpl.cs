using Doopec.DDS.Core;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;

namespace Doopec.DDS.Domain
{
    public class DomainParticipantQosImpl : EntityQosImpl<DomainParticipantQos, ModifiableDomainParticipantQos>, DomainParticipantQos
    {
        public static readonly DomainParticipantQosImpl DDS_PARTICIPANT_QOS_DEFAULT = new DomainParticipantQosImpl();

        private readonly UserDataQosPolicy userData;
        private readonly EntityFactoryQosPolicy entityFactoryQosPolicy;

        public DomainParticipantQosImpl()
        {
            userData = new UserDataQosPolicyImpl();
            entityFactoryQosPolicy = new EntityFactoryQosPolicyImpl();
        }

        public DomainParticipantQosImpl(UserDataQosPolicy userData, EntityFactoryQosPolicy entityFactoryQosPolicy)
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
    }
}
