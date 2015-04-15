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
    public class ReaderDataLifecycleQosPolicyImpl : QosPolicy,ReaderDataLifecycleQosPolicy
    {
        private readonly Duration getAutoPurgeNoWriterSamplesDelay;
        private readonly Duration getAutoPurgeDisposedSamplesDelay;
        public ReaderDataLifecycleQosPolicyImpl(Duration getAutoPurgeNoWriterSamplesDelay , Duration getAutoPurgeDisposedSamplesDelay )
        {
            this.getAutoPurgeNoWriterSamplesDelay = getAutoPurgeNoWriterSamplesDelay;
            this.getAutoPurgeDisposedSamplesDelay = getAutoPurgeDisposedSamplesDelay;
        }
        public Duration GetAutoPurgeNoWriterSamplesDelay()
        {
            return getAutoPurgeNoWriterSamplesDelay;
        }

        public Duration GetAutoPurgeDisposedSamplesDelay()
        {
            return getAutoPurgeDisposedSamplesDelay;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableReaderDataLifecycleQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
