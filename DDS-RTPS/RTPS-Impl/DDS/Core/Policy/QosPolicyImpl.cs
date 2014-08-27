using org.omg.dds.core;
using org.omg.dds.core.policy;
using System;

namespace Doopec.DDS.Core.Policy
{
    public class QosPolicyImpl : QosPolicy
    {
        public QosPolicyId getId()
        {
            throw new NotImplementedException();
        }

        public  Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }

    public class QosPolicyIdImpl : QosPolicyId
    {
        protected int policyIdValue;
        protected string policyName;

        public override int getPolicyIdValue()
        {
            return policyIdValue;
        }

        public override string getPolicyName()
        {
            return policyName;
        }
    }
}
