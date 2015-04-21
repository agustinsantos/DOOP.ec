using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.DDS.Core.Policy
{
    public class EntityFactoryQosPolicyImpl : QosPolicyImpl, EntityFactoryQosPolicy
    {
        private readonly bool isAutoEnable = true;

        public EntityFactoryQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public EntityFactoryQosPolicyImpl(bool isAutoEnable, Bootstrap boostrap)
            : base(boostrap)
        {
            this.isAutoEnable = isAutoEnable;
        }

        public bool IsAutoEnableCreatedEntities()
        {
            return isAutoEnable;
        }

        public ModifiableEntityFactoryQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
