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
            Value = new byte[length];
            Array.Copy(value, offset, Value, 0, length);
            return this;
        }

        public ModifiableGroupDataQosPolicy CopyFrom(GroupDataQosPolicy other)
        {
            return new ModifiableGroupDataQosPolicyImpl (other);
        }

        public GroupDataQosPolicy FinishModification()
        {
            return new GroupDataQosPolicyImpl (this.GetBootstrap());
        }
    }
}
