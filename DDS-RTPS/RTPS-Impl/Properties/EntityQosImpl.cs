using org.omg.dds.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.DDS.Core
{
    public abstract class EntityQosImpl<UNMOD_SELF, MOD_SELF> : EntityQos<UNMOD_SELF, MOD_SELF>
        where UNMOD_SELF : EntityQos<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
        public POLICY get<POLICY>(org.omg.dds.core.policy.QosPolicyId id) where POLICY : org.omg.dds.core.policy.QosPolicy
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.QosPolicy Put(org.omg.dds.core.policy.QosPolicyId key, org.omg.dds.core.policy.QosPolicy value)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.QosPolicy Remove(object key)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }

        public void Add(org.omg.dds.core.policy.QosPolicyId key, org.omg.dds.core.policy.QosPolicy value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(org.omg.dds.core.policy.QosPolicyId key)
        {
            throw new NotImplementedException();
        }

        public ICollection<org.omg.dds.core.policy.QosPolicyId> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(org.omg.dds.core.policy.QosPolicyId key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(org.omg.dds.core.policy.QosPolicyId key, out org.omg.dds.core.policy.QosPolicy value)
        {
            throw new NotImplementedException();
        }

        public ICollection<org.omg.dds.core.policy.QosPolicy> Values
        {
            get { throw new NotImplementedException(); }
        }

        public org.omg.dds.core.policy.QosPolicy this[org.omg.dds.core.policy.QosPolicyId key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<org.omg.dds.core.policy.QosPolicyId, org.omg.dds.core.policy.QosPolicy> item)
        {
            throw new NotImplementedException();
        }


        public bool Contains(KeyValuePair<org.omg.dds.core.policy.QosPolicyId, org.omg.dds.core.policy.QosPolicy> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<org.omg.dds.core.policy.QosPolicyId, org.omg.dds.core.policy.QosPolicy>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<org.omg.dds.core.policy.QosPolicyId, org.omg.dds.core.policy.QosPolicy> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<org.omg.dds.core.policy.QosPolicyId, org.omg.dds.core.policy.QosPolicy>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public MOD_SELF modify()
        {
            throw new NotImplementedException();
        }
    }
}
