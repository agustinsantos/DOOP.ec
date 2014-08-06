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

        DataReader<TYPE> createDataReader<TYPE>(TopicDescription<TYPE> topic);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        DataReader<TYPE> createDataReader<TYPE>(TopicDescription<TYPE> topic,
               DataReaderQos qos,
               DataReaderListener<TYPE> listener,
               ICollection<Type> statuses);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        DataReader<TYPE> createDataReader<TYPE>(TopicDescription<TYPE> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<TYPE> listener,
               ICollection<Type> statuses);


        // --- Create DataReader of built-in bytes type: -------------------------

        BytesDataReader createBytesDataReader(TopicDescription<byte[]> topic);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        BytesDataReader createBytesDataReader(TopicDescription<byte[]> topic,
               DataReaderQos qos,
               DataReaderListener<byte[]> listener,
               ICollection<Type> statuses);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        BytesDataReader createBytesDataReader(TopicDescription<byte[]> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<byte[]> listener,
               ICollection<Type> statuses);


        // --- Create DataReader of built-in KeyedBytes type: --------------------

        KeyedBytesDataReader createKeyedBytesDataReader(TopicDescription<KeyedBytes> topic);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        KeyedBytesDataReader createKeyedBytesDataReader(TopicDescription<KeyedBytes> topic,
               DataReaderQos qos,
               DataReaderListener<KeyedBytes> listener,
               ICollection<Type> statuses);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        KeyedBytesDataReader createKeyedBytesDataReader(TopicDescription<KeyedBytes> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<KeyedBytes> listener,
               ICollection<Type> statuses);


        // --- Create DataReader of built-in string type: ------------------------

        stringDataReader createstringDataReader(TopicDescription<string> topic);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        stringDataReader createstringDataReader(TopicDescription<string> topic,
               DataReaderQos qos,
               DataReaderListener<string> listener,
               ICollection<Type> statuses);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        stringDataReader createstringDataReader(TopicDescription<string> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<string> listener,
               ICollection<Type> statuses);


        // --- Create DataReader of built-in Keyedstring type: -------------------

        KeyedstringDataReader createKeyedstringDataReader(TopicDescription<Keyedstring> topic);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        KeyedstringDataReader createKeyedstringDataReader(TopicDescription<Keyedstring> topic,
               DataReaderQos qos,
               DataReaderListener<Keyedstring> listener,
               ICollection<Type> statuses);

        /**
         * Create a new data reader.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        KeyedstringDataReader createKeyedstringDataReader(TopicDescription<Keyedstring> topic,
               string qosLibraryName,
               string qosProfileName,
               DataReaderListener<Keyedstring> listener,
               ICollection<Type> statuses);


        // --- Lookup operations: ------------------------------------------------

        DataReader<TYPE> lookupDataReader<TYPE>(string topicName);
        DataReader<TYPE> lookupDataReader<TYPE>(TopicDescription<TYPE> topicName);

        BytesDataReader lookupBytesDataReader(TopicDescription<byte[]> topicName);
        KeyedBytesDataReader lookupKeyedBytesDataReader(TopicDescription<KeyedBytes> topicName);
        stringDataReader lookupstringDataReader(TopicDescription<string> topicName);
        KeyedstringDataReader lookupKeyedstringDataReader(TopicDescription<Keyedstring> topicName);


        // --- Other operations: -------------------------------------------------

        void closeContainedEntities();

        ICollection<DataReader<TYPE>> getDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers);

        ICollection<DataReader<TYPE>> getDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers,
               ICollection<SampleState> sampleStates,
               ICollection<ViewState> viewStates,
               ICollection<InstanceState> instanceStates);

        void notifyDataReaders();

        void beginAccess();
        void endAccess();

        DataReaderQos getDefaultDataReaderQos();
        void setDefaultDataReaderQos(DataReaderQos qos);
        void setDefaultDataReaderQos(string qosLibraryName,
               string qosProfileName);

        void copyFromTopicQos(DataReaderQos dst, TopicQos src);
    }
}