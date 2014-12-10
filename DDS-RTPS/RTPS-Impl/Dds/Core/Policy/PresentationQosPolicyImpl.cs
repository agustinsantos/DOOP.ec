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
        public AccessScopeKind GetAccessScope()
        {
            throw new NotImplementedException();
        }

        public bool IsCoherentAccess()
        {
            throw new NotImplementedException();
        }

        public bool IsOrderedAccess()
        {
            throw new NotImplementedException();
        }

        public ModifiablePresentationQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
