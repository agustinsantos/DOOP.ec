using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    class ModifiableGroupDataQosPolicyImpl : GroupDataQosPolicyImpl, ModifiableGroupDataQosPolicy
    {
        public ModifiableGroupDataQosPolicyImpl(GroupDataQosPolicy qos)
            : base(qos.GetBootstrap())
        {
        }

       
        public ModifiableGroupDataQosPolicy SetValue(byte[] value, int offset, int length)
        {
            throw new NotImplementedException();
        }

        public ModifiableGroupDataQosPolicy CopyFrom(GroupDataQosPolicy other)
        {
            throw new NotImplementedException();
        }

        public GroupDataQosPolicy FinishModification()
        {
            throw new NotImplementedException();
        }
    }
}
