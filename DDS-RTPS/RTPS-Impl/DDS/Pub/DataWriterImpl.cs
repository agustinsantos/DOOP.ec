using DDS.ConversionUtils;
using Doopec.Rtps.Behavior;
using Doopec.Rtps.Structure;
using org.omg.dds.core;
using org.omg.dds.pub;
using org.omg.dds.topic;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using InstanceHandle = Rtps.Structure.Types.InstanceHandle;

namespace Doopec.Dds.Pub
{
    public class DataWriterImpl<TYPE> : DataWriter<TYPE>
    {
        Topic<TYPE> topic_;
        Publisher pub_;
        DataWriterListener<TYPE> listener;
        DataWriterQos qos;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="?"></param>
        /// <returns></returns>
        protected readonly Writer<TYPE> rtpsWriter;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="?"></param>
        /// <returns></returns>
        protected readonly HistoryCache<TYPE> historyCache;

        public DataWriterImpl(Publisher pub, Topic<TYPE> topic)
        {
            this.pub_ = pub;
            this.topic_ = topic;
            //TODO. Just to test it. The participant should be create at the DomainParticipant level, isnt??
            Participant participant = new ParticipantImpl();
            this.rtpsWriter = new FakeRtpsWriter<TYPE>(participant);
         }

        public Type getType()
        {
            return topic_.getType();
        }

        public DataWriter<OTHER> cast<OTHER>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.Topic<TYPE> getTopic()
        {
            return topic_;
        }

        public void waitForAcknowledgments(org.omg.dds.core.Duration maxWait)
        {
            throw new NotImplementedException();
        }

        public void waitForAcknowledgments(long maxWait, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessLostStatus<TYPE> getLivelinessLostStatus(org.omg.dds.core.status.LivelinessLostStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.OfferedDeadlineMissedStatus<TYPE> getOfferedDeadlineMissedStatus(org.omg.dds.core.status.OfferedDeadlineMissedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.OfferedIncompatibleQosStatus<TYPE> getOfferedIncompatibleQosStatus(org.omg.dds.core.status.OfferedIncompatibleQosStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.PublicationMatchedStatus<TYPE> getPublicationMatchedStatus(org.omg.dds.core.status.PublicationMatchedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public void assertLiveliness()
        {
            throw new NotImplementedException();
        }

        public ICollection<org.omg.dds.core.InstanceHandle> getMatchedSubscriptions(ICollection<org.omg.dds.core.InstanceHandle> subscriptionHandles)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.SubscriptionBuiltinTopicData getMatchedSubscriptionData(org.omg.dds.topic.SubscriptionBuiltinTopicData subscriptionData, org.omg.dds.core.InstanceHandle subscriptionHandle)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle registerInstance(TYPE instanceData)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle registerInstance(TYPE instanceData, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle registerInstance(TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public void unregisterInstance(org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void unregisterInstance(org.omg.dds.core.InstanceHandle handle, TYPE instanceData)
        {
            throw new NotImplementedException();
        }

        public void unregisterInstance(org.omg.dds.core.InstanceHandle handle, TYPE instanceData, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void unregisterInstance(org.omg.dds.core.InstanceHandle handle, TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public void write(TYPE instanceData)
        {
            // A single tick represents one hundred nanoseconds
            long ts = System.DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000);
            this.write(instanceData, ts, TimeUnit.NANOSECONDS);
        }

        public void write(TYPE instanceData, Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void write(TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            // TODO. Implements timestamp and timeunit in write
            CacheChange<TYPE> change = rtpsWriter.NewChange(ChangeKind.ALIVE, new Data(instanceData), new InstanceHandle());
            rtpsWriter.HistoryCache.AddChange(change);
        }

        public void write(TYPE instanceData, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void write(TYPE instanceData, org.omg.dds.core.InstanceHandle handle, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void write(TYPE instanceData, org.omg.dds.core.InstanceHandle handle, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public void dispose(org.omg.dds.core.InstanceHandle instanceHandle)
        {
            throw new NotImplementedException();
        }

        public void dispose(org.omg.dds.core.InstanceHandle instanceHandle, TYPE instanceData)
        {
            throw new NotImplementedException();
        }

        public void dispose(org.omg.dds.core.InstanceHandle instanceHandle, TYPE instanceData, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void dispose(org.omg.dds.core.InstanceHandle instanceHandle, TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public TYPE getKeyValue(TYPE keyHolder, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableInstanceHandle lookupInstance(org.omg.dds.core.modifiable.ModifiableInstanceHandle handle, TYPE keyHolder)
        {
            throw new NotImplementedException();
        }

        public Publisher getParent()
        {
            return this.pub_;
        }

        public DataWriterListener<TYPE> getListener()
        {
            return this.listener;
        }

        public void setListener(DataWriterListener<TYPE> listener)
        {
            this.listener = listener;
        }

        public DataWriterQos getQos()
        {
            return this.qos;
        }

        public void setQos(DataWriterQos qos)
        {
            this.qos = qos;
        }

        public void setQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.StatusCondition<DataWriter<TYPE>> getStatusCondition()
        {
            throw new NotImplementedException();
        }

        public ICollection<TYPE> getStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle getInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Retain()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

    }
}
