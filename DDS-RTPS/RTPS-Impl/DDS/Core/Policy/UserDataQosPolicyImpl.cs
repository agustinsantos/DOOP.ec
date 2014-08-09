﻿using org.omg.dds.core.policy;
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

        public UserDataQosPolicyImpl()
        {
            this.value = new byte[0];
        }

        public UserDataQosPolicyImpl(byte[] value)
        {
            this.value = value;
        }

        public int getValue(byte[] result, int offset)
        {
            int length = this.value.Length;
            Array.Copy(this.value, offset, result, 0, length);
            return offset + length;
        }

        public int getLength()
        {
            return this.value.Length;
        }

        public org.omg.dds.core.policy.modifiable.ModifiableUserDataQosPolicy modify()
        {
            throw new NotImplementedException();
        }
    }
}
