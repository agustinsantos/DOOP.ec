using Doopec.Dds.Core.Policy.modifiable;
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
        public byte[] ValueQos { get; protected internal set; }

        public UserDataQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
            this.ValueQos = new byte[0];
        }

        public UserDataQosPolicyImpl(byte[] value, Bootstrap boostrap)
            : base(boostrap)
        {
            this.ValueQos = value;
        }

        public int GetValue(byte[] result, int offset)
        {
            int length = this.ValueQos.Length;
            Array.Copy(this.ValueQos, offset, result, 0, length);
            return offset + length;
        }

        public int GetLength()
        {
            return this.ValueQos.Length;
        }

        public ModifiableUserDataQosPolicy Modify()
        {
            return new ModifiableUserDataQosPolicyImpl(this);
        }
    }
}
