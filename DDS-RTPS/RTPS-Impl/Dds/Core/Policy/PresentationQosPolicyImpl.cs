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
    public class PresentationQosPolicyImpl : QosPolicyImpl, PresentationQosPolicy
    {
        public AccessScopeKind AccessScopeKindQos { get; protected internal set; }


        public bool IsCoherentAccessQos { get; protected internal set; }


        public bool IsOrderedAccessQos { get; protected internal set; }

        public PresentationQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
        public PresentationQosPolicyImpl(AccessScopeKind kind,bool isCoherentAccess,bool isOrderedAccess, Bootstrap boostrap)
            : base(boostrap)
        {
            this.AccessScopeKindQos = kind;
            this.IsCoherentAccessQos = isCoherentAccess;
            this.IsOrderedAccessQos = isOrderedAccess;
        }
        public AccessScopeKind GetAccessScope()
        {
            return AccessScopeKindQos;
        }

        public bool IsCoherentAccess()
        {
            return IsCoherentAccessQos;
        }

        public bool IsOrderedAccess()
        {
            return IsOrderedAccessQos;
        }

        public ModifiablePresentationQosPolicy Modify()
        {
            return new ModifiablePresentationQosPolicyImpl(this);
        }
    }
}
