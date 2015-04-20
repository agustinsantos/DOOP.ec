using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;

namespace Doopec.Dds.Core.Policy
{
    public class GroupDataQosPolicyImpl : QosPolicyImpl, GroupDataQosPolicy
    {
        public GroupDataQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public int GetValue(byte[] value, int offset)
        {
            throw new System.NotImplementedException();
        }

        public int GetLength()
        {
            throw new System.NotImplementedException();
        }

        public org.omg.dds.core.policy.modifiable.ModifiableGroupDataQosPolicy Modify()
        {
            throw new System.NotImplementedException();
        }
    }
}
