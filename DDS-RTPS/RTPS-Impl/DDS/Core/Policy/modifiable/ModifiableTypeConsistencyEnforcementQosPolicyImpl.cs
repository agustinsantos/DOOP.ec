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
    class ModifiableTypeConsistencyEnforcementQosPolicyImpl : TypeConsistencyEnforcementQosPolicyImpl, ModifiableTypeConsistencyEnforcementQosPolicy
    {
        public ModifiableTypeConsistencyEnforcementQosPolicyImpl(TypeConsistencyEnforcementQosPolicy qos)
            : base(qos.GetKind(),qos.GetBootstrap())
        {
        }

        public ModifiableTypeConsistencyEnforcementQosPolicyImpl(TypeConsistencyEnforcementQosPolicyKind kind, Bootstrap boostrap)
            : base(kind,boostrap)
        {

        }

        public ModifiableTypeConsistencyEnforcementQosPolicy SetKind(TypeConsistencyEnforcementQosPolicyKind kind)
        {
            this.KindQos=kind;
            return this;
        }

        public ModifiableTypeConsistencyEnforcementQosPolicy CopyFrom(TypeConsistencyEnforcementQosPolicy other)
        {
            return new ModifiableTypeConsistencyEnforcementQosPolicyImpl (other);
        }

        public TypeConsistencyEnforcementQosPolicy FinishModification()
        {
            return new TypeConsistencyEnforcementQosPolicyImpl(this.GetKind(),this.GetBootstrap());
        }
    }
}
