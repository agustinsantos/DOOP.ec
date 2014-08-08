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
using org.omg.dds.core.modifiable;
using org.omg.dds.core.status;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using org.omg.dds.type;
using System;

namespace org.omg.dds.domain
{

    /**
     * The DomainParticipant object plays several roles:
     * <ul>
     * <li>It acts as a container for all other {@link Entity} objects.</li>
     * <li>It acts as factory for the {@link Publisher}, {@link Subscriber},
     *     {@link Topic}, {@link ContentFilteredTopic}, and {@link MultiTopic}
     *     objects.</li>
     * <li>It represents the participation of the application on a communication
     *     plane that isolates applications running on the same set of physical
     *     computers from each other. A domain establishes a "virtual network"
     *     linking all applications that share the same domainId and isolating
     *     them from applications running on different domains. In this way,
     *     several independent distributed applications can coexist in the same
     *     physical network without interfering, or even being aware of each
     *     other.</li>
     * <li>It provides administration services in the domain, offering operations
     *     that allow the application to "ignore" locally any information about a
     *     given participant ({@link #ignoreParticipant(InstanceHandle)}),
     *     publication ({@link #ignorePublication(InstanceHandle)}),
     *     subscription ({@link #ignoreSubscription(InstanceHandle)}), or topic
     *     ({@link #ignoreTopic(InstanceHandle)}).</li>
     * </ul>
     */
    public interface DomainParticipant : Entity<DomainParticipant,
                                                DomainParticipantListener,
                                                DomainParticipantQos>
    {
        // --- Create Publisher: -------------------------------------------------

        Publisher createPublisher();

        /**
         * Create a new publisher.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        Publisher createPublisher(
               PublisherQos qos,
               PublisherListener listener,
               ICollection<Type> statuses);

        /**
         * Create a new publisher.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        Publisher createPublisher(
               string qosLibraryName,
               string qosProfileName,
               PublisherListener listener,
               ICollection<Type> statuses);

        // --- Create Subscriber: ------------------------------------------------

        Subscriber createSubscriber();

        /**
         * Create a new subscriber.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        Subscriber createSubscriber(
               SubscriberQos qos,
               SubscriberListener listener,
               ICollection<Type> statuses);

        /**
         * Create a new subscriber.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        Subscriber createSubscriber(
               string qosLibraryName,
               string qosProfileName,
               SubscriberListener listener,
               ICollection<Type> statuses);

        Subscriber getBuiltinSubscriber();


        /// <summary>
        /// Create a new topic with implicit TypeSupport
        /// </summary>
        Topic<TYPE> createTopic<TYPE>(string topicName);


        /// <summary>
        /// Create a new topic.
        /// </summary>
        /// <typeparam name="TYPE"></typeparam>
        /// <param name="topicName"></param>
        /// <param name="type"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">
        ///             Of which status changes the listener should be
        ///             notified. A null collection signifies all status
        ///             changes
        ///     </param>
        /// <returns></returns>
        Topic<TYPE> createTopic<TYPE>(
               string topicName,
               Type type,
               TopicQos qos,
               TopicListener<TYPE> listener,
               ICollection<Type> statuses);

        /**
         * Create a new topic.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        Topic<TYPE> createTopic<TYPE>(
               string topicName,
               Type type,
               string qosLibraryName,
               string qosProfileName,
               TopicListener<TYPE> listener,
               ICollection<Type> statuses);


        // --- Create Topic with explicit TypeSupport: ---------------------------

        Topic<TYPE> createTopic<TYPE>(
               string topicName,
               TypeSupport<TYPE> type);

        /**
         * Create a new topic.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        Topic<TYPE> createTopic<TYPE>(
               string topicName,
               TypeSupport<TYPE> type,
               TopicQos qos,
               TopicListener<TYPE> listener,
               ICollection<Type> statuses);

        /**
         * Create a new topic.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        Topic<TYPE> createTopic<TYPE>(
               string topicName,
               TypeSupport<TYPE> type,
               string qosLibraryName,
               string qosProfileName,
               TopicListener<TYPE> listener,
               ICollection<Type> statuses);


        // --- Other operations: -------------------------------------------------

        Topic<TYPE> findTopic<TYPE>(
               string topicName,
               Duration timeout);
        Topic<TYPE> findTopic<TYPE>(
               string topicName,
               long timeout,
               TimeUnit unit);
        TopicDescription<TYPE> lookupTopicDescription<TYPE>(string name);

        ContentFilteredTopic<TYPE> createContentFilteredTopic<TYPE>(
               string name,
               Topic<TYPE> relatedTopic,
               string filterExpression,
               IList<string> expressionParameters);

        MultiTopic<TYPE> createMultiTopic<TYPE>(
               string name,
               string typeName,
               string subscriptionExpression,
               List<string> expressionParameters);

        void closeContainedEntities();

        void ignoreParticipant(InstanceHandle handle);
        void ignoreTopic(InstanceHandle handle);
        void ignorePublication(InstanceHandle handle);
        void ignoreSubscription(InstanceHandle handle);

        int getDomainId();

        void assertLiveliness();

        PublisherQos getDefaultPublisherQos();
        void setDefaultPublisherQos(PublisherQos qos);
        void setDefaultPublisherQos(
               string qosLibraryName,
               string qosProfileName);

        SubscriberQos getDefaultSubscriberQos();
        void setDefaultSubscriberQos(SubscriberQos qos);
        void setDefaultSubscriberQos(
               string qosLibraryName,
               string qosProfileName);

        TopicQos getDefaultTopicQos();
        void setDefaultTopicQos(TopicQos qos);
        void setDefaultTopicQos(
               string qosLibraryName,
               string qosProfileName);

        ICollection<InstanceHandle> getDiscoveredParticipants(
               ICollection<InstanceHandle> participantHandles);
        ParticipantBuiltinTopicData getDiscoveredParticipantData(
               ParticipantBuiltinTopicData participantData,
               InstanceHandle participantHandle);

        ICollection<InstanceHandle> getDiscoveredTopics(
               ICollection<InstanceHandle> topicHandles);
        TopicBuiltinTopicData getDiscoveredTopicData(
               TopicBuiltinTopicData topicData,
               InstanceHandle topicHandle);

        bool containsEntity(InstanceHandle handle);

        ModifiableTime getCurrentTime(ModifiableTime currentTime);
    }
}