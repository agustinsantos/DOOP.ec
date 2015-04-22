using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    class ModifiableTopicDataQosPolicyImpl : TopicDataQosPolicyImpl, ModifiableTopicDataQosPolicy
    {
        public ModifiableTopicDataQosPolicyImpl(TopicDataQosPolicy qos)
            : base(qos.GetBootstrap())
        {
        }


        public ModifiableTopicDataQosPolicy SetValue(byte[] value, int offset, int length)
        {
            ValueQos = new byte[length];
            Array.Copy(value, offset, ValueQos, 0, length);
            return this;
        }

        public ModifiableTopicDataQosPolicy CopyFrom(TopicDataQosPolicy other)
        {
            return new ModifiableTopicDataQosPolicyImpl (other);
        }

        public TopicDataQosPolicy FinishModification()
        {
            return new TopicDataQosPolicyImpl(this.GetBootstrap());
        }
    }
}
