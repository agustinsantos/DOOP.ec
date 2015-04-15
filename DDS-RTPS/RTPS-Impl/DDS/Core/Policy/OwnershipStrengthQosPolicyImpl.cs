using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class OwnershipStrengthQosPolicyImpl : QosPolicy,OwnershipStrengthQosPolicy
    {
        private readonly int getValue;
        public OwnershipStrengthQosPolicyImpl(int getValue)
        {
            this.getValue=getValue;
        }
        public int GetValue()
        {
            return getValue;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableOwnershipStrengthQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
