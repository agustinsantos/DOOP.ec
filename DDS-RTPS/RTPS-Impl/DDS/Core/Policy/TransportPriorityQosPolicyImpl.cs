using org.omg.dds.core.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    class TransportPriorityQosPolicyImpl : QosPolicy,TransportPriorityQosPolicy
    {
        private readonly int getValue;
        public TransportPriorityQosPolicyImpl(int getValue)
        {
            this.getValue = getValue;
        }

        public int GetValue()
        {
            return getValue;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.modifiable.ModifiableTransportPriorityQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
