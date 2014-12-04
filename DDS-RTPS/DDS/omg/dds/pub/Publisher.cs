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



using DDS.ConversionUtils;

using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.topic;
using org.omg.dds.type.builtin;
using System.Collections.Generic;
using System;

namespace org.omg.dds.pub
{

    public interface Publisher : DomainEntity<Publisher,
                         DomainParticipant,
                         PublisherListener,
                         PublisherQos>
    {
        // --- Create (any) DataWriter: ------------------------------------------

        DataWriter<TYPE> createDataWriter<TYPE>(
               Topic<TYPE> topic);

        /// <summary>
        /// Create a new data writer.
        /// </summary>
        /// <typeparam name="TYPE"></typeparam>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        DataWriter<TYPE> createDataWriter<TYPE>(
               Topic<TYPE> topic,
               DataWriterQos qos,
               DataWriterListener<TYPE> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <typeparam name="TYPE"></typeparam>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        DataWriter<TYPE> createDataWriter<TYPE>(
               Topic<TYPE> topic,
               string qosLibraryName,
               string qosProfileName,
               DataWriterListener<TYPE> listener,
               ICollection<Type> statuses);


        // --- Create DataWriter for built-in bytes type: ------------------------

        BytesDataWriter createBytesDataWriter(
               Topic<byte[]> topic);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        BytesDataWriter createBytesDataWriter(
               Topic<byte[]> topic,
               DataWriterQos qos,
               DataWriterListener<byte[]> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        BytesDataWriter createBytesDataWriter(
               Topic<byte[]> topic,
               string qosLibraryName,
               string qosProfileName,
               DataWriterListener<byte[]> listener,
               ICollection<Type> statuses);


        // --- Create DataWriter for built-in KeyedBytes type: -------------------

        KeyedBytesDataWriter createKeyedBytesDataWriter(
               Topic<KeyedBytes> topic);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        KeyedBytesDataWriter createKeyedBytesDataWriter(
               Topic<KeyedBytes> topic,
               DataWriterQos qos,
               DataWriterListener<KeyedBytes> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        KeyedBytesDataWriter createKeyedBytesDataWriter(
               Topic<KeyedBytes> topic,
               string qosLibraryName,
               string qosProfileName,
               DataWriterListener<KeyedBytes> listener,
               ICollection<Type> statuses);


        // --- Create DataWriter for built-in string type: -----------------------

        stringDataWriter createstringDataWriter(
               Topic<string> topic);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        stringDataWriter createstringDataWriter(
               Topic<string> topic,
               DataWriterQos qos,
               DataWriterListener<string> listener,
               ICollection<Type> statuses);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        stringDataWriter createstringDataWriter(Topic<string> topic,
               string qosLibraryName,
               string qosProfileName,
               DataWriterListener<string> listener,
               ICollection<Type> statuses);


        // --- Create DataWriter for built-in Keyedstring type: ------------------

        KeyedstringDataWriter createKeyedstringDataWriter(Topic<Keyedstring> topic);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        KeyedstringDataWriter createKeyedstringDataWriter(Topic<Keyedstring> topic,
              DataWriterQos qos,
              DataWriterListener<Keyedstring> listener,
              ICollection<Type> statuses);

        /// <summary>
        /// Create a new data writer
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        KeyedstringDataWriter createKeyedstringDataWriter(Topic<Keyedstring> topic,
              string qosLibraryName,
              string qosProfileName,
              DataWriterListener<Keyedstring> listener,
              ICollection<Type> statuses);


        // --- Lookup operations: ------------------------------------------------

        DataWriter<TYPE> lookupDataWriter<TYPE>(string topicName);
        DataWriter<TYPE> lookupDataWriter<TYPE>(Topic<TYPE> topicName);

        BytesDataWriter lookupBytesDataWriter(Topic<byte[]> topicName);
        KeyedBytesDataWriter lookupKeyedBytesDataWriter(
              Topic<KeyedBytes> topicName);
        stringDataWriter lookupstringDataWriter(Topic<string> topicName);
        KeyedstringDataWriter lookupKeyedstringDataWriter(
              Topic<Keyedstring> topicName);


        // --- Other operations: -------------------------------------------------

        void closeContainedEntities();

        void suspendPublications();
        void resumePublications();

        void beginCoherentChanges();
        void endCoherentChanges();

        void waitForAcknowledgments(Duration maxWait);

        void waitForAcknowledgments(long maxWait, TimeUnit unit);

        DataWriterQos getDefaultDataWriterQos();
        void setDefaultDataWriterQos(DataWriterQos qos);
        void setDefaultDataWriterQos(
              string qosLibraryName,
              string qosProfileName);

        void copyFromTopicQos(DataWriterQos dst, TopicQos src);
    }
}