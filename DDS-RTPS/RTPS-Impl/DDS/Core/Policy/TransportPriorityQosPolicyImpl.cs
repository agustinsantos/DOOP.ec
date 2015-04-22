using Doopec.Dds.Core.Policy.modifiable;
using Doopec.DDS.Core.Policy;
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
    class TransportPriorityQosPolicyImpl : QosPolicyImpl,TransportPriorityQosPolicy
    {
        public int ValueQos { get; protected internal set; }

        public TransportPriorityQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
        public TransportPriorityQosPolicyImpl(int getValue, Bootstrap boostrap)
            :base(boostrap)
        {
            this.ValueQos = getValue;
        }

        public int GetValue()
        {
            return ValueQos;
        }

        
        public ModifiableTransportPriorityQosPolicy Modify()
        {
            return new ModifiableTransportPriorityQosPolicyImpl(this) ;
        }
    }
}
