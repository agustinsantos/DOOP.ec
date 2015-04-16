using DDS.ConversionUtils;
using Doopec.Rtps.Behavior;
using Doopec.Rtps.Structure;
using org.omg.dds.core;
using org.omg.dds.pub;
using org.omg.dds.topic;
using Rtps.Messages;
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
            : this(pub, topic, pub.GetDefaultDataWriterQos(), null, null)
        {
        }

        public DataWriterImpl(Publisher pub, Topic<TYPE> topic, DataWriterQos qos, DataWriterListener<TYPE> listener, ICollection<Type> statuses)
        {
            this.pub_ = pub;
            this.topic_ = topic;
            this.listener = listener;

            Participant participant = new ParticipantImpl();
            this.rtpsWriter = new RtpsWriter<TYPE>(participant);
        }


        public Type GetType()
        {
            return topic_.GetType();
        }

        public DataWriter<OTHER> Cast<OTHER>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.Topic<TYPE> GetTopic()
        {
            return topic_;
        }

        public void WaitForAcknowledgments(org.omg.dds.core.Duration maxWait)
        {
            throw new NotImplementedException();
        }

        public void WaitForAcknowledgments(long maxWait, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessLostStatus<TYPE> GetLivelinessLostStatus(org.omg.dds.core.status.LivelinessLostStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.OfferedDeadlineMissedStatus<TYPE> GetOfferedDeadlineMissedStatus(org.omg.dds.core.status.OfferedDeadlineMissedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.OfferedIncompatibleQosStatus<TYPE> GetOfferedIncompatibleQosStatus(org.omg.dds.core.status.OfferedIncompatibleQosStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.PublicationMatchedStatus<TYPE> GetPublicationMatchedStatus(org.omg.dds.core.status.PublicationMatchedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public void AssertLiveliness()
        {
            throw new NotImplementedException();
        }

        public ICollection<org.omg.dds.core.InstanceHandle> GetMatchedSubscriptions(ICollection<org.omg.dds.core.InstanceHandle> subscriptionHandles)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.SubscriptionBuiltinTopicData GetMatchedSubscriptionData(org.omg.dds.topic.SubscriptionBuiltinTopicData subscriptionData, org.omg.dds.core.InstanceHandle subscriptionHandle)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle RegisterInstance(TYPE instanceData)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle RegisterInstance(TYPE instanceData, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle RegisterInstance(TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public void UnregisterInstance(org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void UnregisterInstance(org.omg.dds.core.InstanceHandle handle, TYPE instanceData)
        {
            throw new NotImplementedException();
        }

        public void UnregisterInstance(org.omg.dds.core.InstanceHandle handle, TYPE instanceData, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void UnregisterInstance(org.omg.dds.core.InstanceHandle handle, TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public void Write(TYPE instanceData)
        {
            // A single tick represents one hundred nanoseconds
            long ts = System.DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000);
            this.Write(instanceData, ts, TimeUnit.NANOSECONDS);
        }

        public void Write(TYPE instanceData, Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void Write(TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            // TODO. Implements timestamp and timeunit in Write
            CacheChange<TYPE> change = rtpsWriter.NewChange(ChangeKind.ALIVE, new Data(instanceData), new InstanceHandle());
            rtpsWriter.HistoryCache.AddChange(change);
        }

        public void Write(TYPE instanceData, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void Write(TYPE instanceData, org.omg.dds.core.InstanceHandle handle, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void Write(TYPE instanceData, org.omg.dds.core.InstanceHandle handle, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public void Dispose(org.omg.dds.core.InstanceHandle instanceHandle)
        {
            throw new NotImplementedException();
        }

        public void Dispose(org.omg.dds.core.InstanceHandle instanceHandle, TYPE instanceData)
        {
            throw new NotImplementedException();
        }

        public void Dispose(org.omg.dds.core.InstanceHandle instanceHandle, TYPE instanceData, org.omg.dds.core.Time sourceTimestamp)
        {
            throw new NotImplementedException();
        }

        public void Dispose(org.omg.dds.core.InstanceHandle instanceHandle, TYPE instanceData, long sourceTimestamp, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public TYPE GetKeyValue(TYPE keyHolder, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableInstanceHandle LookupInstance(org.omg.dds.core.modifiable.ModifiableInstanceHandle handle, TYPE keyHolder)
        {
            throw new NotImplementedException();
        }

        public Publisher GetParent()
        {
            return this.pub_;
        }

        public DataWriterListener<TYPE> GetListener()
        {
            return this.listener;
        }

        public void SetListener(DataWriterListener<TYPE> listener)
        {
            this.listener = listener;
        }

        public DataWriterQos GetQos()
        {
            return this.qos;
        }

        public void SetQos(DataWriterQos qos)
        {
            this.qos = qos;
        }

        public void SetQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.StatusCondition<DataWriter<TYPE>> GetStatusCondition()
        {
            throw new NotImplementedException();
        }

        public ICollection<TYPE> GetStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle GetInstanceHandle()
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
