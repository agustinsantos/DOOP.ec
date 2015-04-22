using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    class ModifiableUserDataQosPolicyImpl: UserDataQosPolicyImpl, ModifiableUserDataQosPolicy
    {
        public ModifiableUserDataQosPolicyImpl(UserDataQosPolicy qos)
            : base(qos.GetBootstrap())
        {
        }

        public ModifiableUserDataQosPolicy SetValue(byte[] value, int offset, int length)
        {
            ValueQos = new byte[length];
            Array.Copy(value, offset, ValueQos, 0, length);
            return this;
        }

        public ModifiableUserDataQosPolicy CopyFrom(UserDataQosPolicy other)
        {
            return new ModifiableUserDataQosPolicyImpl(other);
        }

        public UserDataQosPolicy FinishModification()
        {
            return new UserDataQosPolicyImpl(this.GetBootstrap());
        }
    }
}
