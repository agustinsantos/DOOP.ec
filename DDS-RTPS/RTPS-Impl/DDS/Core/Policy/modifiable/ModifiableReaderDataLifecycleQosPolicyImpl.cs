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
    class ModifiableReaderDataLifecycleQosPolicyImpl : ReaderDataLifecycleQosPolicyImpl, ModifiableReaderDataLifecycleQosPolicy
    {
        public ModifiableReaderDataLifecycleQosPolicyImpl(ReaderDataLifecycleQosPolicy qos)
            : base(qos.GetAutoPurgeNoWriterSamplesDelay(),qos.GetAutoPurgeDisposedSamplesDelay(), qos.GetBootstrap())
        {
        }

        public ModifiableReaderDataLifecycleQosPolicyImpl(Duration autoPurgeNoWriterSamplesDelay, Duration autoPurgeDisposedSamplesDelay, Bootstrap boostrap)
            : base(autoPurgeNoWriterSamplesDelay,autoPurgeDisposedSamplesDelay, boostrap)
        {

        }


        public ModifiableReaderDataLifecycleQosPolicy SetAutoPurgeNoWriterSamplesDelay(Duration autoPurgeNoWriterSamplesDelay)
        {
            this.AutoPurgeNoWriterSamplesDelay=autoPurgeNoWriterSamplesDelay;
            return this;
        }

        public ModifiableReaderDataLifecycleQosPolicy SetAutoPurgeNoWriterSamplesDelay(long autoPurgeNoWriterSamplesDelay, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableReaderDataLifecycleQosPolicy SetAutoPurgeDisposedSamplesDelay(Duration autoPurgeDisposedSamplesDelay)
        {
            this.AutoPurgeDisposedSamplesDelay=autoPurgeDisposedSamplesDelay;
            return this;
        }

        public ModifiableReaderDataLifecycleQosPolicy SetAutoPurgeDisposedSamplesDelay(long autoPurgeDisposedSamplesDelay, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableReaderDataLifecycleQosPolicy CopyFrom(ReaderDataLifecycleQosPolicy other)
        {
            return new ModifiableReaderDataLifecycleQosPolicyImpl (other);
        }

        public ReaderDataLifecycleQosPolicy FinishModification()
        {
            return new ReaderDataLifecycleQosPolicyImpl (this.GetAutoPurgeNoWriterSamplesDelay(),this.GetAutoPurgeDisposedSamplesDelay(),this.GetBootstrap());
        }
    }
}
