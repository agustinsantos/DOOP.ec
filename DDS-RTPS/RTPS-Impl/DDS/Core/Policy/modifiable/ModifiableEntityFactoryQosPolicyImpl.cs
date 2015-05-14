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
    public class ModifiableEntityFactoryQosPolicyImpl : ModifiableEntityFactoryQosPolicy
    {

        private EntityFactoryQosPolicyImpl innerQos;

        public ModifiableEntityFactoryQosPolicyImpl(EntityFactoryQosPolicy qos)
        {
            this.innerQos = qos as EntityFactoryQosPolicyImpl;
        }

        public ModifiableEntityFactoryQosPolicyImpl(bool autoEnableCreatedEntities, Bootstrap boostrap)
        {
            this.innerQos = new EntityFactoryQosPolicyImpl(autoEnableCreatedEntities, boostrap);
        }


        public ModifiableEntityFactoryQosPolicy SetAutoEnableCreatedEntities(bool autoEnableCreatedEntities)
        {
            this.innerQos.AutoenableCreatedEntities = autoEnableCreatedEntities;
            return this;
        }

        public ModifiableEntityFactoryQosPolicy CopyFrom(EntityFactoryQosPolicy other)
        {
            return new ModifiableEntityFactoryQosPolicyImpl(other.IsAutoEnableCreatedEntities(), other.GetBootstrap());
        }

        public EntityFactoryQosPolicy FinishModification()
        {
            return this.innerQos;
        }

        public bool IsAutoEnableCreatedEntities()
        {
            return innerQos.IsAutoEnableCreatedEntities();
        }

        public QosPolicyId GetId()
        {
            return innerQos.GetId();
        }

        public Bootstrap GetBootstrap()
        {
            return innerQos.GetBootstrap();
        }

        public ModifiableEntityFactoryQosPolicy Modify()
        {
            return this;
        }
    }
}
