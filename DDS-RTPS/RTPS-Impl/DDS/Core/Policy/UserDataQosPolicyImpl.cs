using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.DDS.Core.Policy
{
    public class UserDataQosPolicyImpl : QosPolicyImpl, UserDataQosPolicy
    {
        private readonly byte[] value;

        public UserDataQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
            this.value = new byte[0];
        }

        public UserDataQosPolicyImpl(byte[] value, Bootstrap boostrap)
            : base(boostrap)
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

        public ModifiableUserDataQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
