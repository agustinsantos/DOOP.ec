using DDS.ConversionUtils;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Sub
{
    public class DataReaderImpl<TYPE> : DataReader<TYPE>
    {
        TopicDescription<TYPE> topic_;
        Subscriber pub_;

        public DataReaderImpl(Subscriber pub, TopicDescription<TYPE> topic)
        {
            pub_ = pub;
            topic_ = topic;
        }

        public Type getType()
        {
            throw new NotImplementedException();
        }

        public DataReader<OTHER> cast<OTHER>()
        {
            throw new NotImplementedException();
        }

        public ReadCondition<TYPE> createReadCondition()
        {
            throw new NotImplementedException();
        }

        public ReadCondition<TYPE> createReadCondition(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public QueryCondition<TYPE> createQueryCondition(string queryExpression, List<string> queryParameters)
        {
            throw new NotImplementedException();
        }

        public QueryCondition<TYPE> createQueryCondition(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates, string queryExpression, List<string> queryParameters)
        {
            throw new NotImplementedException();
        }

        public void closeContainedEntities()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.TopicDescription<TYPE> getTopicDescription()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleRejectedStatus<TYPE> getSampleRejectedStatus(org.omg.dds.core.status.SampleRejectedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessChangedStatus<TYPE> getLivelinessChangedStatus(org.omg.dds.core.status.LivelinessChangedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedDeadlineMissedStatus<TYPE> getRequestedDeadlineMissedStatus(org.omg.dds.core.status.RequestedDeadlineMissedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedIncompatibleQosStatus<TYPE> getRequestedIncompatibleQosStatus(org.omg.dds.core.status.RequestedIncompatibleQosStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SubscriptionMatchedStatus<TYPE> getSubscriptionMatchedStatus(org.omg.dds.core.status.SubscriptionMatchedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleLostStatus<TYPE> getSampleLostStatus(org.omg.dds.core.status.SampleLostStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public void waitForHistoricalData(org.omg.dds.core.Duration maxWait)
        {
            throw new NotImplementedException();
        }

        public void waitForHistoricalData(long maxWait,  TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ICollection<org.omg.dds.core.InstanceHandle> getMatchedPublications(ICollection<org.omg.dds.core.InstanceHandle> publicationHandles)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.PublicationBuiltinTopicData getMatchedPublicationData(org.omg.dds.topic.PublicationBuiltinTopicData publicationData, org.omg.dds.core.InstanceHandle publicationHandle)
        {
            throw new NotImplementedException();
        }

        public Sample<TYPE> createSample()
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> read()
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> read(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void read(IList<Sample<TYPE>> samples)
        {
            throw new NotImplementedException();
        }

        public void read(IList<Sample<TYPE>> samples, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> take()
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> take(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void take(IList<Sample<TYPE>> samples)
        {
            throw new NotImplementedException();
        }

        public void take(IList<Sample<TYPE>> samples, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> read(ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void read(IList<Sample<TYPE>> samples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void read(IList<Sample<TYPE>> samples, int maxSamples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> take(ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void take(IList<Sample<TYPE>> samples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void take(IList<Sample<TYPE>> samples, int maxSamples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public bool readNext(Sample<TYPE> sample)
        {
            throw new NotImplementedException();
        }

        public bool takeNext(Sample<TYPE> sample)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> read(org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> read(org.omg.dds.core.InstanceHandle handle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void read(IList<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void read(IList<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> take(org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> take(org.omg.dds.core.InstanceHandle handle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void take(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void take(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> readNext(org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> readNext(org.omg.dds.core.InstanceHandle previousHandle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void readNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public void readNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> takeNext(org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> takeNext(org.omg.dds.core.InstanceHandle previousHandle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void takeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public void takeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> readNext(org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void readNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void readNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> takeNext(org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void takeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void takeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ReadCondition<TYPE> condition)
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

        public Subscriber getParent()
        {
            throw new NotImplementedException();
        }

        public DataReaderListener<TYPE> getListener()
        {
            throw new NotImplementedException();
        }

        public void setListener(DataReaderListener<TYPE> listener)
        {
            throw new NotImplementedException();
        }

        public DataReaderQos getQos()
        {
            throw new NotImplementedException();
        }

        public void setQos(DataReaderQos qos)
        {
            throw new NotImplementedException();
        }

        public void setQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.StatusCondition<DataReader<TYPE>> getStatusCondition()
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

        public org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
