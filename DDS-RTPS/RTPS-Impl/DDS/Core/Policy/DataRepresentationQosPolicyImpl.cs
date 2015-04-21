using Doopec.Dds.Core.Policy.modifiable;
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
        
        public List<short> GetValueQos { get; protected internal set; }
        public DataRepresentationQosPolicyImpl(List<short> getValue)
        {
            this.GetValueQos = getValue;
        }
        public List<short> GetValue()
        {
            return GetValueQos;
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
            return new ModifiableDataRepresentationQosPolicyImpl(this);
        }
    }
}
