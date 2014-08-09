using org.omg.dds.core.policy;
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

        public EntityFactoryQosPolicyImpl()
        { }

        public EntityFactoryQosPolicyImpl(bool isAutoEnable)
        {
            this.isAutoEnable = isAutoEnable;
        }

        public bool isAutoEnableCreatedEntities()
        {
            return isAutoEnable;
        }

        public org.omg.dds.core.policy.modifiable.ModifiableEntityFactoryQosPolicy modify()
        {
            throw new NotImplementedException();
        }
    }
}
