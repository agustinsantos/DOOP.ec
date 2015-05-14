using org.omg.dds.core;
using org.omg.dds.core.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class QosPolicyCountImpl : QosPolicy, QosPolicyCount
    {
        public QosPolicyId PolicyIdQos{ get; protected internal set; }

        public int CountQos{ get; protected internal set; }


        public QosPolicyCountImpl(Bootstrap boostrap)
            : base()
        {
        }

        public QosPolicyCountImpl(QosPolicyId getPolicyId, int getCount)
            : base()
        {
            this.PolicyIdQos = getPolicyId;
            this.CountQos = getCount;
        }
      


        public QosPolicyId GetPolicyId()
        {
            return PolicyIdQos;
        }

        public int GetCount()
        {
            return CountQos;
        }
        /// <summary>
        /// To Review
        /// </summary>
        /// <returns>No se implemento automaticamente pero fue necesario para no tener errores en la compilacion</returns>
        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }
        public QosPolicyCount CopyFrom(QosPolicyCount other)
        {
            return new QosPolicyCountImpl(other.GetPolicyId(),other.GetCount());
        }

        public QosPolicyCount FinishModification()
        {
            return new QosPolicyCountImpl (this.GetPolicyId(),this.GetCount());
        }

        public QosPolicyCount Modify()
        {
            return new QosPolicyCountImpl(this.GetPolicyId(), this.GetCount());
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
