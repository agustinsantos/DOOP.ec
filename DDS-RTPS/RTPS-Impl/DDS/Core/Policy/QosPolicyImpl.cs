using org.omg.dds.core;
using org.omg.dds.core.policy;
using System;

namespace Doopec.DDS.Core.Policy
{
    public class QosPolicyImpl : QosPolicy
    {
        public Bootstrap Boostrap { get; internal set; }

        public QosPolicyImpl(Bootstrap boostrap)
        {
            Boostrap = boostrap;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public  Bootstrap GetBootstrap()
        {
            return Boostrap;
        }
    }

    public class QosPolicyIdImpl : QosPolicyId
    {
        protected int policyIdValue;
        protected string policyName;

        public override int GetPolicyIdValue()
        {
            return policyIdValue;
        }

        public override string GetPolicyName()
        {
            return policyName;
        }
    }
}
