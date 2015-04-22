using Doopec.Dds.Core.Policy.modifiable;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;

namespace Doopec.Dds.Core.Policy
{
    public class GroupDataQosPolicyImpl : QosPolicyImpl, GroupDataQosPolicy
    {
        public byte[] Value { get; protected internal set; }

        public GroupDataQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
        public GroupDataQosPolicyImpl(byte[] value, Bootstrap boostrap)
            : base(boostrap)
        {
            this.Value  = value;
        }
        
        public int GetValue(byte[] value, int offset)
        {
            Array.Copy(Value, 0, value, offset, Value.Length - offset);

            return Value.Length;
        }

        public int GetLength()
        {

            return Value.Length;
        }

        public ModifiableGroupDataQosPolicy Modify()
        {
            return new ModifiableGroupDataQosPolicyImpl(this);
        }
    }
}
