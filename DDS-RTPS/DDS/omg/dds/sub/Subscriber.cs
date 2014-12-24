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

using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.topic;
using org.omg.dds.type.builtin;
using System;
using System.Collections.Generic;

namespace org.omg.dds.sub
{

    public interface Subscriber : DomainEntity<Subscriber,
                           DomainParticipant,
                           SubscriberListener,
                           SubscriberQos>
    {
        // --- Create (any) DataReader: ------------------------------------------

        DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <typeparam name="TYPE"></typeparam>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic,
               DataReaderQos qos,
               DataReaderListener<TYPE> listener,
               ICollection<Type> statuses);


        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <typeparam name="TYPE"></typeparam>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic,
                                               string qosLibraryName,
                                               string qosProfileName,
                                               DataReaderListener<TYPE> listener,
                                               ICollection<Type> statuses);


        // --- Create DataReader of built-in bytes type: -------------------------

        BytesDataReader CreateBytesDataReader(TopicDescription<byte[]> topic);

        /// <summary>
        /// Create a new data reader.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        BytesDataReader CreateBytesDataReader(TopicDescription<byte[]> topic,
               DataReaderQos qos,
               DataReaderListener<byte[]> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        BytesDataReader CreateBytesDataReader(TopicDescription<byte[]> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<byte[]> listener,
               ICollection<Type> statuses);


        // --- Create DataReader of built-in KeyedBytes type: --------------------

        KeyedBytesDataReader CreateKeyedBytesDataReader(TopicDescription<KeyedBytes> topic);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        KeyedBytesDataReader CreateKeyedBytesDataReader(TopicDescription<KeyedBytes> topic,
               DataReaderQos qos,
               DataReaderListener<KeyedBytes> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status 
        ///                        changes
        /// </param>
        /// <returns></returns>
        KeyedBytesDataReader CreateKeyedBytesDataReader(TopicDescription<KeyedBytes> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<KeyedBytes> listener,
               ICollection<Type> statuses);


        // --- Create DataReader of built-in string type: ------------------------

        stringDataReader CreatestringDataReader(TopicDescription<string> topic);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        stringDataReader CreatestringDataReader(TopicDescription<string> topic,
               DataReaderQos qos,
               DataReaderListener<string> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        stringDataReader CreatestringDataReader(TopicDescription<string> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<string> listener,
               ICollection<Type> statuses);


        // --- Create DataReader of built-in Keyedstring type: -------------------

        KeyedstringDataReader CreateKeyedstringDataReader(TopicDescription<Keyedstring> topic);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        KeyedstringDataReader CreateKeyedstringDataReader(TopicDescription<Keyedstring> topic,
               DataReaderQos qos,
               DataReaderListener<Keyedstring> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data reader
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes
        /// </param>
        /// <returns></returns>
        KeyedstringDataReader CreateKeyedstringDataReader(TopicDescription<Keyedstring> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<Keyedstring> listener,
               ICollection<Type> statuses);


        // --- Lookup operations: ------------------------------------------------

        DataReader<TYPE> LookupDataReader<TYPE>(string topicName);
        DataReader<TYPE> LookupDataReader<TYPE>(TopicDescription<TYPE> topicName);

        BytesDataReader LookupBytesDataReader(TopicDescription<byte[]> topicName);
        KeyedBytesDataReader LookupKeyedBytesDataReader(TopicDescription<KeyedBytes> topicName);
        stringDataReader LookupstringDataReader(TopicDescription<string> topicName);
        KeyedstringDataReader LookupKeyedstringDataReader(TopicDescription<Keyedstring> topicName);


        // --- Other operations: -------------------------------------------------

        void closeContainedEntities();

        ICollection<DataReader<TYPE>> GetDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers);

        ICollection<DataReader<TYPE>> GetDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers,
               ICollection<SampleState> sampleStates,
               ICollection<ViewState> viewStates,
               ICollection<InstanceState> instanceStates);

        void NotifyDataReaders();

        void BeginAccess();
        void EndAccess();

        DataReaderQos GetDefaultDataReaderQos();
        void SetDefaultDataReaderQos(DataReaderQos qos);
        void SetDefaultDataReaderQos(string qosLibraryName,
               string qosProfileName);

        void CopyFromTopicQos(DataReaderQos dst, TopicQos src);
    }
}