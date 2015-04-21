using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    class ModifiableDataRepresentationQosPolicyImpl : DataRepresentationQosPolicyImpl, ModifiableDataRepresentationQosPolicy
    {

        public ModifiableDataRepresentationQosPolicyImpl(DataRepresentationQosPolicy qos)
            : base(qos.GetValue())
        {
        }

        public ModifiableDataRepresentationQosPolicyImpl(List<short> getValue)
            : base(getValue)
        {

        }
        public ModifiableDataRepresentationQosPolicy SetValue(List<short> value)
        {
            this.GetValueQos = value;
            return this;
        }

        public ModifiableDataRepresentationQosPolicy SetValue(params short[] value)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataRepresentationQosPolicy CopyFrom(DataRepresentationQosPolicy other)
        {
            return new ModifiableDataRepresentationQosPolicyImpl(other.GetValue());
        }

        public DataRepresentationQosPolicy FinishModification()
        {
            return new DataRepresentationQosPolicyImpl(this.GetValue());
        }
    }
}
