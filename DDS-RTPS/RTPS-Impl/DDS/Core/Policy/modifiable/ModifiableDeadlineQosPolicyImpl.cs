using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    class ModifiableDeadlineQosPolicyImpl : DeadlineQosPolicyImpl, ModifiableDeadlineQosPolicy
    {


        public ModifiableDeadlineQosPolicyImpl(DeadlineQosPolicy qos)
            : base(qos.GetPeriod())
        {
        } 
        public ModifiableDeadlineQosPolicyImpl(Duration getPeriod)
            : base(getPeriod)
        {

        }


        public ModifiableDeadlineQosPolicy SetPeriod(Duration period)
        {
            this.GetPeriodQos = period;
            return this;
        }

        public ModifiableDeadlineQosPolicy SetPeriod(long period, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableDeadlineQosPolicy CopyFrom(DeadlineQosPolicy other)
        {
            return new ModifiableDeadlineQosPolicyImpl(other.GetPeriod());
        }

        public DeadlineQosPolicy FinishModification()
        {
            return new DeadlineQosPolicyImpl(this.GetPeriod());
        }
    }
}
