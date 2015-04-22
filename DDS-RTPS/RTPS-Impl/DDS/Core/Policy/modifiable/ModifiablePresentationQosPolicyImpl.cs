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
    class ModifiablePresentationQosPolicyImpl: PresentationQosPolicyImpl, ModifiablePresentationQosPolicy
    {
          public ModifiablePresentationQosPolicyImpl(PresentationQosPolicy qos)
            : base(qos.GetAccessScope(),qos.IsCoherentAccess(),qos.IsOrderedAccess(), qos.GetBootstrap())
        {
        }

          public ModifiablePresentationQosPolicyImpl(AccessScopeKind accessScope,bool coherentAccess,bool orderedAccess, Bootstrap boostrap)
            : base(accessScope,coherentAccess,orderedAccess , boostrap)
        {

        }


          public ModifiablePresentationQosPolicy SetAccessScope(AccessScopeKind accessScope)
          {
              this.AccessScopeKindQos=accessScope ;
              return this;
          }

          public ModifiablePresentationQosPolicy SetCoherentAccess(bool coherentAccess)
          {
              this.IsCoherentAccessQos=coherentAccess ;
              return this;
          }

          public ModifiablePresentationQosPolicy SetOrderedAccess(bool orderedAccess)
          {
              this.IsOrderedAccessQos =orderedAccess ;
              return this;
          }

          public ModifiablePresentationQosPolicy CopyFrom(PresentationQosPolicy other)
          {
              return new ModifiablePresentationQosPolicyImpl (other);
          }

          public PresentationQosPolicy FinishModification()
          {
              return new PresentationQosPolicyImpl (this.GetAccessScope(),this.IsCoherentAccess(),this.IsOrderedAccess(),this.GetBootstrap());
          }
    }
}
