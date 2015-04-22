using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    public class ModifiableEntityFactoryQosPolicyImpl : EntityFactoryQosPolicyImpl, ModifiableEntityFactoryQosPolicy
    {

        public ModifiableEntityFactoryQosPolicyImpl(EntityFactoryQosPolicy qos)
            : base(qos.IsAutoEnableCreatedEntities(), qos.GetBootstrap())
        {
        }

        public ModifiableEntityFactoryQosPolicyImpl(bool autoEnableCreatedEntities, Bootstrap boostrap)
            : base(autoEnableCreatedEntities, boostrap)
        {

        }


        public ModifiableEntityFactoryQosPolicy SetAutoEnableCreatedEntities(bool autoEnableCreatedEntities)
        {
            this.IsAutoEnableQos=autoEnableCreatedEntities;
            return this;
        }

        public ModifiableEntityFactoryQosPolicy CopyFrom(EntityFactoryQosPolicy other)
        {
            return new ModifiableEntityFactoryQosPolicyImpl (other.IsAutoEnableCreatedEntities(),other.GetBootstrap());
        }

        public EntityFactoryQosPolicy FinishModification()
        {
            return new EntityFactoryQosPolicyImpl(this.IsAutoEnableCreatedEntities(), this.GetBootstrap());
        }
    }
}
