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
        private readonly QosPolicyId getPolicyId;

        private readonly int getCount;

        public QosPolicyCountImpl(QosPolicyId getPolicyId,int getCount)
        {
            this.getPolicyId = getPolicyId;
            this.getCount = getCount;
        }


        public QosPolicyId GetPolicyId()
        {
            return getPolicyId;
        }

        public int GetCount()
        {
            return getCount;
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
            throw new NotImplementedException();
        }

        public QosPolicyCount FinishModification()
        {
            throw new NotImplementedException();
        }

        public QosPolicyCount Modify()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
