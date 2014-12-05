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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicData">The topicData to set</param>
        /// <returns>This</returns>
        ModifiableTopicQos setTopicData(TopicDataQosPolicy topicData);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="durability">The durability to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setDurability(DurabilityQosPolicy durability);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="durabilityService">The durabilityService to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setDurabilityService(DurabilityServiceQosPolicy durabilityService);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deadline">The deadline to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setDeadline(DeadlineQosPolicy deadline);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latencyBudget">The latencyBudget to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setLatencyBudget(LatencyBudgetQosPolicy latencyBudget);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="liveliness">The liveliness to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setLiveliness(LivelinessQosPolicy liveliness);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reliability">The reliability to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setReliability(ReliabilityQosPolicy reliability);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinationOrder">The destinationOrder to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setDestinationOrder(DestinationOrderQosPolicy destinationOrder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="history">The history to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setHistory(HistoryQosPolicy history);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceLimits">The resourceLimits to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setResourceLimits(ResourceLimitsQosPolicy resourceLimits);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportPriority">The transportPriority to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setTransportPriority(TransportPriorityQosPolicy transportPriority);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lifespan">The lifespan to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setLifespan(LifespanQosPolicy lifespan);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownership">The ownership to set</param>
        /// <returns>this</returns>
        ModifiableTopicQos setOwnership(OwnershipQosPolicy ownership);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="representation"></param>
        /// <returns>this</returns>
        ModifiableTopicQos setRepresentation(DataRepresentationQosPolicy representation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeConsistency"></param>
        /// <returns>this</returns>
        ModifiableTopicQos setTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency);
    }
}