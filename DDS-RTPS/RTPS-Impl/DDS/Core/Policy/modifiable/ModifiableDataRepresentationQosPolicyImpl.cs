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
    class ModifiableDataRepresentationQosPolicyImpl : DataRepresentationQosPolicyImpl, ModifiableDataRepresentationQosPolicy
    {

        public ModifiableDataRepresentationQosPolicyImpl(DataRepresentationQosPolicy qos)
            : base(qos.GetValue(), qos.GetBootstrap())
        {
        }

        public ModifiableDataRepresentationQosPolicyImpl(List<short> getValue, Bootstrap boostrap)
            : base(getValue, boostrap)
        {

        }
        public ModifiableDataRepresentationQosPolicy SetValue(List<short> value)
        {
            this.ValueQos = value;
            return this;
        }

        public ModifiableDataRepresentationQosPolicy SetValue(params short[] value)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataRepresentationQosPolicy CopyFrom(DataRepresentationQosPolicy other)
        {
            return new ModifiableDataRepresentationQosPolicyImpl(other);
        }

        public DataRepresentationQosPolicy FinishModification()
        {
            return new DataRepresentationQosPolicyImpl(this.GetValue(), this.GetBootstrap());
        }
    }
}
