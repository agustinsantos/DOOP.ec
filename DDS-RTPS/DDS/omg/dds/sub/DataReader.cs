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
 * See the License for the specific language governing permissions and
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
        System.Type getType();
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
        DataReader<OTHER> cast<OTHER>();

        ReadCondition<TYPE> createReadCondition();
        ReadCondition<TYPE> createReadCondition(
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        QueryCondition<TYPE> createQueryCondition(
              string queryExpression,
              List<string> queryParameters);
        QueryCondition<TYPE> createQueryCondition(
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates,
              string queryExpression,
              List<string> queryParameters);

        void closeContainedEntities();

        TopicDescription<TYPE> getTopicDescription();

        SampleRejectedStatus<TYPE> getSampleRejectedStatus(SampleRejectedStatus<TYPE> status);

        LivelinessChangedStatus<TYPE> getLivelinessChangedStatus(LivelinessChangedStatus<TYPE> status);

        RequestedDeadlineMissedStatus<TYPE> getRequestedDeadlineMissedStatus(RequestedDeadlineMissedStatus<TYPE> status);

        RequestedIncompatibleQosStatus<TYPE> getRequestedIncompatibleQosStatus(RequestedIncompatibleQosStatus<TYPE> status);

        SubscriptionMatchedStatus<TYPE> getSubscriptionMatchedStatus(SubscriptionMatchedStatus<TYPE> status);
        SampleLostStatus<TYPE> getSampleLostStatus(SampleLostStatus<TYPE> status);

        void waitForHistoricalData(Duration maxWait);

        void waitForHistoricalData(long maxWait, TimeUnit unit);

        ICollection<InstanceHandle> getMatchedPublications(ICollection<InstanceHandle> publicationHandles);
        PublicationBuiltinTopicData getMatchedPublicationData(PublicationBuiltinTopicData publicationData,
              InstanceHandle publicationHandle);


        // --- Type-specific interface: ------------------------------------------

        ///TODO how I can comment the tag @see
        /// <summary>
        /// Create and return a new Sample of the same type as may be accessed by
        /// this DataReader.
        /// 
        /// Applications may use this method, for example, to preallocate samples
        /// to be overwritten by the <code>read</code> and/or <code>take</code>
        /// methods of this interface.
        /// 
        /// @see #read(List)
        /// @see #take(List)
        /// </summary>
        /// <returns></returns>
        Sample<TYPE> createSample();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> read();
        SampleIterator<TYPE> read(ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// Copy samples into the provided collection, overwriting any samples that
        /// might already be present
        /// </summary>
        /// <param name="samples"></param>
        void read(IList<Sample<TYPE>> samples);
        void read(IList<Sample<TYPE>> samples,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> take();
        SampleIterator<TYPE> take(ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void take(IList<Sample<TYPE>> samples);
        void take(IList<Sample<TYPE>> samples,
              int maxSamples,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> read(ReadCondition<TYPE> condition);

        void read(IList<Sample<TYPE>> samples,
              ReadCondition<TYPE> condition);
        void read(IList<Sample<TYPE>> samples,
              int maxSamples,
              ReadCondition<TYPE> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> take(ReadCondition<TYPE> condition);

        void take(IList<Sample<TYPE>> samples,
              ReadCondition<TYPE> condition);
        void take(IList<Sample<TYPE>> samples,
              int maxSamples,
              ReadCondition<TYPE> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sample"></param>
        /// <returns>True if data was read or false if no data was available</returns>
        bool readNext(Sample<TYPE> sample);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sample"></param>
        /// <returns>True if data was taken or false if no data was available</returns>
        bool takeNext(Sample<TYPE> sample);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> read(InstanceHandle handle);
        SampleIterator<TYPE> read(InstanceHandle handle,
            ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void read(IList<Sample<TYPE>> samples,
              InstanceHandle handle);
        void read(IList<Sample<TYPE>> samples,
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
        SampleIterator<TYPE> take(InstanceHandle handle);
        SampleIterator<TYPE> take(InstanceHandle handle,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void take(List<Sample<TYPE>> samples,
              InstanceHandle handle);
        void take(List<Sample<TYPE>> samples,
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
        SampleIterator<TYPE> readNext(InstanceHandle previousHandle);
        SampleIterator<TYPE> readNext(InstanceHandle previousHandle,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void readNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle);
        void readNext(List<Sample<TYPE>> samples,
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
        SampleIterator<TYPE> takeNext(InstanceHandle previousHandle);
        SampleIterator<TYPE> takeNext(InstanceHandle previousHandle,
              ICollection<SampleState> sampleStates,
              ICollection<ViewState> viewStates,
              ICollection<InstanceState> instanceStates);

        void takeNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle);
        void takeNext(List<Sample<TYPE>> samples,
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
        SampleIterator<TYPE> readNext(InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);

        void readNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);
        void readNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              int maxSamples,
              ReadCondition<TYPE> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousHandle"></param>
        /// <param name="condition"></param>
        /// <returns>A non-null unmodifiable iterator over loaned samples</returns>
        SampleIterator<TYPE> takeNext(InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);

        void takeNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              ReadCondition<TYPE> condition);
        void takeNext(List<Sample<TYPE>> samples,
              InstanceHandle previousHandle,
              int maxSamples,
              ReadCondition<TYPE> condition);

        TYPE getKeyValue(TYPE keyHolder,
              InstanceHandle handle);

        ModifiableInstanceHandle lookupInstance(ModifiableInstanceHandle handle,
              TYPE keyHolder);
    }
}