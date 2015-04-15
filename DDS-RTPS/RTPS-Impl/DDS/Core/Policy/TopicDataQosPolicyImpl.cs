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
    public class TopicDataQosPolicyImpl : QosPolicy,TopicDataQosPolicy
    {
        private readonly byte[] value;

        public TopicDataQosPolicyImpl()
        {
            this.value = new byte[0];
        }

        public TopicDataQosPolicyImpl(byte[] value)
        {
            this.value = value;
        }

        public int GetValue(byte[] result, int offset)
        {
            int length = this.value.Length;
            Array.Copy(this.value, offset, result, 0, length);
            return offset + length;
        }

        public int GetLength()
        {
            return this.value.Length;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableTopicDataQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
