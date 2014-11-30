using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy;

namespace Doopec.Dds.Core.Policy
{
    public class GroupDataQosPolicyImpl : QosPolicyImpl, GroupDataQosPolicy
    {
        public int getValue(byte[] value, int offset)
        {
            throw new System.NotImplementedException();
        }

        public int getLength()
        {
            throw new System.NotImplementedException();
        }

        public org.omg.dds.core.policy.modifiable.ModifiableGroupDataQosPolicy Modify()
        {
            throw new System.NotImplementedException();
        }
    }
}
