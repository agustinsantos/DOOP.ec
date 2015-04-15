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
    public class DataRepresentationQosPolicyImpl : QosPolicy,DataRepresentationQosPolicy
    {
        private readonly List<short> getValue;

        public DataRepresentationQosPolicyImpl(List<short> getValue)
        {
            this.getValue = getValue;
        }
        public List<short> GetValue()
        {
            return getValue;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableDataRepresentationQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
