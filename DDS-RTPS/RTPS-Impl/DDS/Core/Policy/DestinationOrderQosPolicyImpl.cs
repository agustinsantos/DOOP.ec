using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doopec.Dds.Core.Policy.modifiable;
using Doopec.DDS.Core.Policy;

namespace Doopec.Dds.Core.Policy
{
    public class DestinationOrderQosPolicyImpl: QosPolicyImpl, DestinationOrderQosPolicy
    {
       
        public DestinationOrderQosPolicyKind KindQos { get; protected internal set; }


        public DestinationOrderQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public DestinationOrderQosPolicyImpl(DestinationOrderQosPolicyKind kind, Bootstrap boostrap)
            : base(boostrap)
        {
            this.KindQos = kind;
        }
        public DestinationOrderQosPolicyKind GetKind()
        {
            return KindQos;
        }

        
        public ModifiableDestinationOrderQosPolicy Modify()
        {
            return new ModifiableDestinationOrderQosPolicyImpl(this);
        }
    }
}
