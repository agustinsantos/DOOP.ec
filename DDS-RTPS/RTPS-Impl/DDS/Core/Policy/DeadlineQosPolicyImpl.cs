using org.omg.dds.core;
using org.omg.dds.core.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.omg.dds.core.policy.modifiable;
using Doopec.Dds.Core.Policy.modifiable;
using Doopec.DDS.Core.Policy;




namespace Doopec.Dds.Core.Policy
{
    public class DeadlineQosPolicyImpl : QosPolicyImpl, DeadlineQosPolicy
    {
        

        public Duration PeriodQos { get; protected internal set; }

         public DeadlineQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

         public DeadlineQosPolicyImpl(Duration getPeriod, Bootstrap boostrap)
            : base(boostrap)
        {
            this.PeriodQos = getPeriod;
        }

        
        
        public Duration GetPeriod()
        {
            return PeriodQos;
        }

        

        public ModifiableDeadlineQosPolicy Modify()
        {
          
            return new ModifiableDeadlineQosPolicyImpl(this);
        }
    }
}
