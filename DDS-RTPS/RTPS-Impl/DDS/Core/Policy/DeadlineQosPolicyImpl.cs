using org.omg.dds.core;
using org.omg.dds.core.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.omg.dds.core.policy.modifiable;

namespace Doopec.Dds.Core.Policy
{
    public class DeadlineQosPolicyImpl : QosPolicy, DeadlineQosPolicy
    {
        private readonly Duration getPeriod;
        public DeadlineQosPolicyImpl(Duration getPeriod)
        {
            this.getPeriod = getPeriod;
        }






        public Duration GetPeriod()
        {
            return getPeriod;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableDeadlineQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
