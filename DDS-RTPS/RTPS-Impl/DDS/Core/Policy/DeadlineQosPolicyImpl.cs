using org.omg.dds.core;
using org.omg.dds.core.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.omg.dds.core.policy.modifiable;
using Doopec.Dds.Core.Policy.modifiable;




namespace Doopec.Dds.Core.Policy
{
    public class DeadlineQosPolicyImpl : QosPolicy, DeadlineQosPolicy
    {
        

        public Duration GetPeriodQos { get; protected internal set; }
        public DeadlineQosPolicyImpl(Duration getPeriod)
        {
            this.GetPeriodQos = getPeriod;
        }

        
        public Duration GetPeriod()
        {
            return GetPeriodQos;
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
          
            return new ModifiableDeadlineQosPolicyImpl(this);
        }
    }
}
