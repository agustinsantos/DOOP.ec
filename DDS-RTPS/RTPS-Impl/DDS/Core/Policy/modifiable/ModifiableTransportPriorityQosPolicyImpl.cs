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
    class ModifiableTransportPriorityQosPolicyImpl:TransportPriorityQosPolicyImpl, ModifiableTransportPriorityQosPolicy
    {
        public ModifiableTransportPriorityQosPolicyImpl(TransportPriorityQosPolicy qos)
            : base(qos.GetValue(),qos.GetBootstrap())
        {
        }

        public ModifiableTransportPriorityQosPolicyImpl(int value, Bootstrap boostrap)
            : base(value,boostrap)
        {

        }

        public ModifiableTransportPriorityQosPolicy SetValue(int value)
        {
            this.ValueQos =value;
            return this;
        }

        public ModifiableTransportPriorityQosPolicy CopyFrom(TransportPriorityQosPolicy other)
        {
            return new ModifiableTransportPriorityQosPolicyImpl(other);
        }

        public TransportPriorityQosPolicy FinishModification()
        {
            return new TransportPriorityQosPolicyImpl(this.GetValue(),this.GetBootstrap());
        }
    }
}
