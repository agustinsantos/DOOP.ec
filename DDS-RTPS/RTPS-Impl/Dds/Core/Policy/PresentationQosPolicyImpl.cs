using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class PresentationQosPolicyImpl : QosPolicyImpl, PresentationQosPolicy
    {
        public AccessScopeKind getAccessScope()
        {
            throw new NotImplementedException();
        }

        public bool isCoherentAccess()
        {
            throw new NotImplementedException();
        }

        public bool isOrderedAccess()
        {
            throw new NotImplementedException();
        }

        public ModifiablePresentationQosPolicy modify()
        {
            throw new NotImplementedException();
        }
    }
}
