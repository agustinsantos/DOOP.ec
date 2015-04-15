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
    public class TypeConsistencyEnforcementQosPolicyImpl: QosPolicy,TypeConsistencyEnforcementQosPolicy
    {
        private readonly TypeConsistencyEnforcementQosPolicyKind getKind;
        public TypeConsistencyEnforcementQosPolicyImpl(TypeConsistencyEnforcementQosPolicyKind getKind)
        {
            this.getKind = getKind;
        }
        public TypeConsistencyEnforcementQosPolicyKind GetKind()
        {
            return getKind;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableTypeConsistencyEnforcementQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
