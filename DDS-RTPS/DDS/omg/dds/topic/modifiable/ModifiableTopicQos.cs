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



using org.omg.dds.core.modifiable;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.topic;

namespace org.omg.dds.topic.modifiable
{

    public interface ModifiableTopicQos : TopicQos, ModifiableEntityQos<TopicQos, ModifiableTopicQos>
    {
        /**
         * @param topicData the topicData to set
         * 
         * @return  this
         */
        ModifiableTopicQos setTopicData(TopicDataQosPolicy topicData);


        /**
         * @param durability the durability to set
         * 
         * @return  this
         */
        ModifiableTopicQos setDurability(DurabilityQosPolicy durability);

        /**
         * @param durabilityService the durabilityService to set
         * 
         * @return  this
         */
        ModifiableTopicQos setDurabilityService(DurabilityServiceQosPolicy durabilityService);

        /**
         * @param deadline the deadline to set
         * 
         * @return  this
         */
        ModifiableTopicQos setDeadline(DeadlineQosPolicy deadline);

        /**
         * @param latencyBudget the latencyBudget to set
         * 
         * @return  this
         */
        ModifiableTopicQos setLatencyBudget(LatencyBudgetQosPolicy latencyBudget);

        /**
         * @param liveliness the liveliness to set
         * 
         * @return  this
         */
        ModifiableTopicQos setLiveliness(LivelinessQosPolicy liveliness);

        /**
         * @param reliability the reliability to set
         * 
         * @return  this
         */
        ModifiableTopicQos setReliability(ReliabilityQosPolicy reliability);

        /**
         * @param destinationOrder the destinationOrder to set
         * 
         * @return  this
         */
        ModifiableTopicQos setDestinationOrder(DestinationOrderQosPolicy destinationOrder);

        /**
         * @param history the history to set
         * 
         * @return  this
         */
        ModifiableTopicQos setHistory(HistoryQosPolicy history);

        /**
         * @param resourceLimits the resourceLimits to set
         * 
         * @return  this
         */
        ModifiableTopicQos setResourceLimits(ResourceLimitsQosPolicy resourceLimits);

        /**
         * @param transportPriority the transportPriority to set
         * 
         * @return  this
         */
        ModifiableTopicQos setTransportPriority(TransportPriorityQosPolicy transportPriority);

        /**
         * @param lifespan the lifespan to set
         * 
         * @return  this
         */
        ModifiableTopicQos setLifespan(LifespanQosPolicy lifespan);

        /**
         * @param ownership the ownership to set
         * 
         * @return  this
         */
        ModifiableTopicQos setOwnership(OwnershipQosPolicy ownership);

        /**
         * @return  this
         */
        ModifiableTopicQos setRepresentation(DataRepresentationQosPolicy representation);

        /**
         * @return  this
         */
        ModifiableTopicQos setTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency);
    }
}