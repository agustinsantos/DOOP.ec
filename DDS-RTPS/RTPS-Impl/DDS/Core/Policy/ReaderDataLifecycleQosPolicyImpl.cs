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
    public class ReaderDataLifecycleQosPolicyImpl : QosPolicyImpl,ReaderDataLifecycleQosPolicy
    {
        public Duration AutoPurgeNoWriterSamplesDelay { get; protected internal set; }
        public Duration AutoPurgeDisposedSamplesDelay { get; protected internal set; }
        public ReaderDataLifecycleQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public ReaderDataLifecycleQosPolicyImpl(Duration getAutoPurgeNoWriterSamplesDelay , Duration getAutoPurgeDisposedSamplesDelay,Bootstrap boostrap )
            :base(boostrap)
        {
            this.AutoPurgeNoWriterSamplesDelay = getAutoPurgeNoWriterSamplesDelay;
            this.AutoPurgeDisposedSamplesDelay = getAutoPurgeDisposedSamplesDelay;
        }
        public Duration GetAutoPurgeNoWriterSamplesDelay()
        {
            return AutoPurgeNoWriterSamplesDelay;
        }

        public Duration GetAutoPurgeDisposedSamplesDelay()
        {
            return AutoPurgeDisposedSamplesDelay;
        }

        

        public ModifiableReaderDataLifecycleQosPolicy Modify()
        {
            return new ModifiableReaderDataLifecycleQosPolicyImpl(this);
        }
    }
}
