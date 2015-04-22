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
    public class TypeConsistencyEnforcementQosPolicyImpl: QosPolicyImpl,TypeConsistencyEnforcementQosPolicy
    {
        public TypeConsistencyEnforcementQosPolicyKind KindQos { get; protected internal set; }

        public TypeConsistencyEnforcementQosPolicyImpl(TypeConsistencyEnforcementQosPolicyKind getKind,Bootstrap boostrap)
            :base(boostrap)
        {
            this.KindQos = getKind;
        }
        public TypeConsistencyEnforcementQosPolicyKind GetKind()
        {
            return KindQos;
        }

        
        public ModifiableTypeConsistencyEnforcementQosPolicy Modify()
        {
            return new ModifiableTypeConsistencyEnforcementQosPolicyImpl(this);
        }
    }
}
