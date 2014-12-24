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
        /// <param name="topicData">The topicData to Set</param>
        /// <returns>This</returns>
        ModifiableTopicQos SetTopicData(TopicDataQosPolicy topicData);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="durability">The durability to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetDurability(DurabilityQosPolicy durability);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="durabilityService">The durabilityService to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetDurabilityService(DurabilityServiceQosPolicy durabilityService);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deadline">The deadline to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetDeadline(DeadlineQosPolicy deadline);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latencyBudget">The latencyBudget to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetLatencyBudget(LatencyBudgetQosPolicy latencyBudget);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="liveliness">The liveliness to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetLiveliness(LivelinessQosPolicy liveliness);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reliability">The reliability to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetReliability(ReliabilityQosPolicy reliability);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinationOrder">The destinationOrder to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetDestinationOrder(DestinationOrderQosPolicy destinationOrder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="history">The history to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetHistory(HistoryQosPolicy history);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceLimits">The resourceLimits to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetResourceLimits(ResourceLimitsQosPolicy resourceLimits);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportPriority">The transportPriority to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetTransportPriority(TransportPriorityQosPolicy transportPriority);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lifespan">The lifespan to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetLifespan(LifespanQosPolicy lifespan);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownership">The ownership to Set</param>
        /// <returns>this</returns>
        ModifiableTopicQos SetOwnership(OwnershipQosPolicy ownership);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="representation"></param>
        /// <returns>this</returns>
        ModifiableTopicQos SetRepresentation(DataRepresentationQosPolicy representation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeConsistency"></param>
        /// <returns>this</returns>
        ModifiableTopicQos SetTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency);
    }
}