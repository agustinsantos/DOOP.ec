/* Copyright 2010, Object Management Group, Inc.
 * Copyright 2010, PrismTech, Inc.
 * Copyright 2010, Real-Time Innovations, Inc.
 * All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific Language governing permissions and
 * limitations under the License.
 */



using System.Collections.Generic;
using DDS.ConversionUtils;
using org.omg.dds.core;
using org.omg.dds.topic;
using org.omg.dds.core.status;
using org.omg.dds.core.modifiable;

namespace org.omg.dds.sub
{
    public interface IDataReader : IDomainEntity
    { }

    public interface DataReader<TYPE> : IDataReader, DomainEntity<DataReader<TYPE>,
                                             Subscriber,
                                             DataReaderListener<TYPE>,
                                             DataReaderQos>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The type parameter if this object's class</returns>
        System.Type GetType();
        ///TODO how I comment a throw???
        /// <summary>
        /// Cast this data reader to the given type, or throw an exception if
        /// the Cast fails
        /// @throws          ClassCastException if the Cast fails
        /// </summary>
        /// <typeparam name="OTHER">The type of the data subscribed to by this reader,
        ///                         according to the caller
        ///</typeparam>
        /// <returns>This data reader</returns>
        DataReader<OTHER> Cast<OTHER>();

        ReadCondition<TYPE> CreateReadCondition();
        ReadCondition<TYPE> CreateReadCondition(
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        QueryCondition<TYPE> CreateQueryCondition(
              string queryExpression,
              List<string> queryParameters);
        QueryCondition<TYPE> CreateQueryCondition(
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates,
              string queryExpression,
              List<string> queryParameters);

        void CloseContainedEntities();

        TopicDescription<TYPE> GetTopicDescription();

        SampleRejectedStatus<TYPE> GetSampleRejectedStatus(SampleRejectedStatus<TYPE> status);

        LivelinessChangedStatus<TYPE> GetLivelinessChangedStatus(LivelinessChangedStatus<TYPE> status);

        RequestedDeadlineMissedStatus<TYPE> GetRequestedDeadlineMissedStatus(RequestedDeadlineMissedStatus<TYPE> status);

        RequestedIncompatibleQosStatus<TYPE> GetRequestedIncompatibleQosStatus(RequestedIncompatibleQosStatus<TYPE> status);

        SubscriptionMatchedStatus<TYPE> GetSubscriptionMatchedStatus(SubscriptionMatchedStatus<TYPE> status);
        SampleLostStatus<TYPE> GetSampleLostStatus(SampleLostStatus<TYPE> status);

        void WaitForHistoricalData(Duration maxWait);

        void WaitForHistoricalData(long maxWait, TimeUnit unit);

        ICollection<InstanceHandle> GetMatchedPublications(ICollection<InstanceHandle> publicationHandles);
        PublicationBuiltinTopicData GetMatchedPublicationData(PublicationBuiltinTopicData publicationData,
              InstanceHandle publicationHandle);


        // --- Type-specific interface: ------------------------------------------

        ///TODO how I can comment the tag @see
        /// <summary>
        /// Create and return a new Sample of the same type as may be accessed by
        /// this DataReader.
        /// 
        /// Applications may use this method, for example, to preallocate samples
        /// to be overwritten by the <code>Read</code> and/or <code>Take</code>
        /// methods of this interface.
        /// 
        /// @see #Read(List)
        /// @see #Take(List)
        /// </summary>
        /// <returns></returns>
        Sample<TYPE> CreateSample();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> Read();
        SampleIterator<TYPE> Read(ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// Copy samples into the provided collection, overwriting any samples that
        /// might already be present
        /// </summary>
        /// <param name="samples"></param>
        void Read(IList<Sample<TYPE>> samples);
        void Read(IList<Sample<TYPE>> samples,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> Take();
        SampleIterator<TYPE> Take(ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void Take(IList<Sample<TYPE>> samples);
        void Take(IList<Sample<TYPE>> samples,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> Read(ReadCondition<TYPE> condition);

        void Read(IList<Sample<TYPE>> samples,
              ReadCondition<TYPE> condition);
        void Read(IList<Sample<TYPE>> samples,
              int maxSamples,
              ReadCondition<TYPE> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> Take(ReadCondition<TYPE> condition);

        void Take(IList<Sample<TYPE>> samples,
              ReadCondition<TYPE> condition);
        void Take(IList<Sample<TYPE>> samples,
              int maxSamples,
              ReadCondition<TYPE> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sample"></param>
        /// <returns>True if data was Read or false if no data was available</returns>
        bool ReadNext(Sample<TYPE> sample);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sample"></param>
        /// <returns>True if data was taken or false if no data was available</returns>
        bool TakeNext(Sample<TYPE> sample);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> Read(InstanceHandle handle);
        SampleIterator<TYPE> Read(InstanceHandle handle,
            ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void Read(IList<Sample<TYPE>> samples,
              InstanceHandle handle);
        void Read(IList<Sample<TYPE>> samples,
              InstanceHandle handle,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> Take(InstanceHandle handle);
        SampleIterator<TYPE> Take(InstanceHandle handle,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void Take(List<Sample<TYPE>> samples,
              InstanceHandle handle);
        void Take(List<Sample<TYPE>> samples,
              InstanceHandle handle,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousHandle"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> ReadNext(InstanceHandle previousHandle);
        SampleIterator<TYPE> ReadNext(InstanceHandle previousHandle,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void ReadNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle);
        void ReadNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousHandle"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> TakeNext(InstanceHandle previousHandle);
        SampleIterator<TYPE> TakeNext(InstanceHandle previousHandle,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void TakeNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle);
        void TakeNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousHandle"></param>
        /// <param name="condition"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> ReadNext(InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);

        void ReadNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);
        void ReadNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              int maxSamples,
              ReadCondition<TYPE> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousHandle"></param>
        /// <param name="condition"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> TakeNext(InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);

        void TakeNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);
        void TakeNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              int maxSamples,
              ReadCondition<TYPE> condition);

        TYPE GetKeyValue(TYPE keyHolder,
              InstanceHandle handle);

        ModifiableInstanceHandle LookupInstance(ModifiableInstanceHandle handle,
              TYPE keyHolder);
    }
}