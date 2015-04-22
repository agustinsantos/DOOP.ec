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
    class ModifiableEntityFactoryQosPolicyImpl : EntityFactoryQosPolicyImpl, ModifiableEntityFactoryQosPolicy
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
            throw new NotImplementedException();
        }

        public ModifiableEntityFactoryQosPolicy CopyFrom(EntityFactoryQosPolicy other)
        {
            throw new NotImplementedException();
        }

        public EntityFactoryQosPolicy FinishModification()
        {
            throw new NotImplementedException();
        }
    }
}
