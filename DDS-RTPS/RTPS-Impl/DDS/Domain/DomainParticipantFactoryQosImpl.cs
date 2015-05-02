using Doopec.DDS.Core;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Domain
{
    public class DomainParticipantFactoryQosImpl : EntityQosImpl<DomainParticipantFactoryQos, ModifiableDomainParticipantFactoryQos>, DomainParticipantFactoryQos
    {

        public static  DomainParticipantFactoryQosImpl ConvertTo(Doopec.Configuration.Dds.DomainParticipantFactoryQoS qos, Bootstrap boostrap)
        {
            DomainParticipantFactoryQosImpl rst = new DomainParticipantFactoryQosImpl(boostrap);
            rst.EntityFactoryQosPolicy = new EntityFactoryQosPolicyImpl(qos.EntityFactory.AutoenableCreatedEntities, boostrap);
            return rst;
        }

        public DomainParticipantFactoryQosImpl(Bootstrap boostrap) : base(boostrap)
        {
 
        }

        protected internal EntityFactoryQosPolicy EntityFactoryQosPolicy { get; set; }
 
        public override ModifiableDomainParticipantFactoryQos Modify()
        {
            throw new NotImplementedException();
        }

        public EntityFactoryQosPolicy GetEntityFactory()
        {
            return EntityFactoryQosPolicy;
        }
    }
}
