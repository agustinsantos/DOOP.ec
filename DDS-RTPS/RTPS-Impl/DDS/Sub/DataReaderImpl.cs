using DDS.ConversionUtils;
using Doopec.DDS.Core;
using Doopec.DDS.Sub;
using Doopec.Rtps;
using Doopec.Rtps.Behavior;
using Doopec.Rtps.SharedMem;
using Doopec.Rtps.Structure;
using org.omg.dds.core.status;
using org.omg.dds.sub;
using org.omg.dds.topic;
using Rtps.Behavior;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Doopec.Dds.Sub
{
    public class DataReaderImpl<TYPE> : DataReader<TYPE>
    {
        TopicDescription<TYPE> topic_;
        Subscriber sub_;
        DataReaderListener<TYPE> listener;
        public readonly ManualResetEvent ManualResetEvent = new ManualResetEvent(false);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="?"></param>
        /// <returns></returns>
        protected readonly Reader<TYPE> rtpsReader;


        public DataReaderImpl(Subscriber sub, TopicDescription<TYPE> topic, DataReaderQos qos, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            this.sub_ = sub;
            this.topic_ = topic;
            this.listener = listener;

            Participant participant = new ParticipantImpl();
            RtpsReader<TYPE> reader = new RtpsReader<TYPE>(participant);
            reader.ReaderCache.Changed += NewMessage;
            this.rtpsReader = reader;
        }

        public DataReaderImpl(Subscriber sub, TopicDescription<TYPE> topic)
            : this(sub, topic, sub.GetDefaultDataReaderQos(), null, null)
        {
        }

        public Type GetType()
        {
            throw new NotImplementedException();
        }

        public DataReader<OTHER> Cast<OTHER>()
        {
            throw new NotImplementedException();
        }

        public ReadCondition<TYPE> CreateReadCondition()
        {
            throw new NotImplementedException();
        }

        public ReadCondition<TYPE> CreateReadCondition(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public QueryCondition<TYPE> CreateQueryCondition(string queryExpression, List<string> queryParameters)
        {
            throw new NotImplementedException();
        }

        public QueryCondition<TYPE> CreateQueryCondition(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates, string queryExpression, List<string> queryParameters)
        {
            throw new NotImplementedException();
        }

        public void CloseContainedEntities()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.TopicDescription<TYPE> GetTopicDescription()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleRejectedStatus<TYPE> GetSampleRejectedStatus(org.omg.dds.core.status.SampleRejectedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessChangedStatus<TYPE> GetLivelinessChangedStatus(org.omg.dds.core.status.LivelinessChangedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedDeadlineMissedStatus<TYPE> GetRequestedDeadlineMissedStatus(org.omg.dds.core.status.RequestedDeadlineMissedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedIncompatibleQosStatus<TYPE> GetRequestedIncompatibleQosStatus(org.omg.dds.core.status.RequestedIncompatibleQosStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SubscriptionMatchedStatus<TYPE> GetSubscriptionMatchedStatus(org.omg.dds.core.status.SubscriptionMatchedStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleLostStatus<TYPE> GetSampleLostStatus(org.omg.dds.core.status.SampleLostStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        public void WaitForHistoricalData(org.omg.dds.core.Duration maxWait)
        {
            throw new NotImplementedException();
        }
        private void NewMessage(object sender, EventArgs e)
        {
            ManualResetEvent.Set();
        }

        public void WaitForHistoricalData(long maxWait, TimeUnit unit)
        {
            long tiks = 0;
            switch (unit)
            {
                case TimeUnit.DAYS:
                    tiks = maxWait * TimeSpan.TicksPerDay;
                    break;
                case TimeUnit.HOURS:
                    tiks = maxWait * TimeSpan.TicksPerHour;
                    break;
                case TimeUnit.MILLISECONDS:
                    tiks = maxWait * TimeSpan.TicksPerMillisecond;
                    break;
                case TimeUnit.MINUTES:
                    tiks = maxWait * TimeSpan.TicksPerMinute;
                    break;
                case TimeUnit.SECONDS:
                    tiks = maxWait * TimeSpan.TicksPerSecond;
                    break;
                default:
                    throw new NotSupportedException("Time Unit " + unit);
            }
            if (rtpsReader.ReaderCache.Changes.Count > 0  || ManualResetEvent.WaitOne(new TimeSpan(tiks)))
            {
                if (rtpsReader.ReaderCache.Changes.Count <= 0) return;
                if (this.listener != null)
                {
                    DataAvailableStatus<TYPE> status = new DataAvailableStatusImpl<TYPE>(this);

                    this.listener.OnDataAvailable(status);
                }
            }
        }

        public ICollection<org.omg.dds.core.InstanceHandle> GetMatchedPublications(ICollection<org.omg.dds.core.InstanceHandle> publicationHandles)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.PublicationBuiltinTopicData GetMatchedPublicationData(org.omg.dds.topic.PublicationBuiltinTopicData publicationData, org.omg.dds.core.InstanceHandle publicationHandle)
        {
            throw new NotImplementedException();
        }

        public Sample<TYPE> CreateSample()
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Read()
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Read(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void Read(IList<Sample<TYPE>> samples)
        {
            throw new NotImplementedException();
        }

        public void Read(IList<Sample<TYPE>> samples, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Take()
        {
            SampleIterator<TYPE> it = new SampleIteratorImpl<TYPE>();
            it.Add(new SampleImpl<TYPE>(rtpsReader.ReaderCache.GetChange()));
            return it;
        }

        public SampleIterator<TYPE> Take(ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void Take(IList<Sample<TYPE>> samples)
        {
            throw new NotImplementedException();
        }

        public void Take(IList<Sample<TYPE>> samples, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Read(ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void Read(IList<Sample<TYPE>> samples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void Read(IList<Sample<TYPE>> samples, int maxSamples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Take(ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void Take(IList<Sample<TYPE>> samples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void Take(IList<Sample<TYPE>> samples, int maxSamples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public bool ReadNext(Sample<TYPE> sample)
        {
            throw new NotImplementedException();
        }

        public bool TakeNext(Sample<TYPE> sample)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Read(org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Read(org.omg.dds.core.InstanceHandle handle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void Read(IList<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void Read(IList<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Take(org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> Take(org.omg.dds.core.InstanceHandle handle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void Take(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void Take(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle handle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> ReadNext(org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> ReadNext(org.omg.dds.core.InstanceHandle previousHandle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void ReadNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public void ReadNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> TakeNext(org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> TakeNext(org.omg.dds.core.InstanceHandle previousHandle, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void TakeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle)
        {
            throw new NotImplementedException();
        }

        public void TakeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> ReadNext(org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void ReadNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void ReadNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public SampleIterator<TYPE> TakeNext(org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void TakeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, ReadCondition<TYPE> condition)
        {
            throw new NotImplementedException();
        }

        public void TakeNext(List<Sample<TYPE>> samples, org.omg.dds.core.InstanceHandle previousHandle, int maxSamples, ReadCondition<TYPE> condition)
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

        public Subscriber GetParent()
        {
            throw new NotImplementedException();
        }

        public DataReaderListener<TYPE> GetListener()
        {
            throw new NotImplementedException();
        }

        public void SetListener(DataReaderListener<TYPE> listener)
        {
            throw new NotImplementedException();
        }

        public DataReaderQos GetQos()
        {
            throw new NotImplementedException();
        }

        public void SetQos(DataReaderQos qos)
        {
            throw new NotImplementedException();
        }

        public void SetQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.StatusCondition<DataReader<TYPE>> GetStatusCondition()
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
