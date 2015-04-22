using Doopec.Dds.Core.Policy.modifiable;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class DataRepresentationQosPolicyImpl : QosPolicyImpl,DataRepresentationQosPolicy
    {
        
        public List<short> ValueQos { get; protected internal set; }

        public DataRepresentationQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public DataRepresentationQosPolicyImpl(List<short> getValue, Bootstrap boostrap)
            : base(boostrap)
        {
            this.ValueQos = getValue;
        }

        public List<short> GetValue()
        {
            return ValueQos;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }


        public ModifiableDataRepresentationQosPolicy Modify()
        {
            return new ModifiableDataRepresentationQosPolicyImpl(this);
        }
    }
}
