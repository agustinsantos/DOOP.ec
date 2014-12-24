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


using org.omg.dds.core.modifiable;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.sub;
using org.omg.dds.topic;

namespace org.omg.dds.sub.modifiable
{

    public interface ModifiableDataReaderQos : DataReaderQos, ModifiableEntityQos<DataReaderQos, ModifiableDataReaderQos>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="durability">The durability to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetDurability(DurabilityQosPolicy durability);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deadline">The deadline to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetDeadline(DeadlineQosPolicy deadline);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latencyBudget">The latencyBudget to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetLatencyBudget(LatencyBudgetQosPolicy latencyBudget);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="liveliness">The liveliness to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetLiveliness(LivelinessQosPolicy liveliness);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinationOrder">The destinationOrder to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetDestinationOrder(DestinationOrderQosPolicy destinationOrder);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="history">The history to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetHistory(HistoryQosPolicy history);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceLimits">The resourceLimits to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetResourceLimits(ResourceLimitsQosPolicy resourceLimits);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userData">The userData to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetUserData(UserDataQosPolicy userData);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownership">The ownership to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetOwnership(OwnershipQosPolicy ownership);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeBasedFilter">The timeBasedFilter to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetTimeBasedFilter(TimeBasedFilterQosPolicy timeBasedFilter);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerDataLifecycle">The readerDataLifecycle to Set</param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetReaderDataLifecycle(ReaderDataLifecycleQosPolicy readerDataLifecycle);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="representation"></param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetRepresentation(DataRepresentationQosPolicy representation);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeConsistency"></param>
        /// <returns>this</returns>
        ModifiableDataReaderQos SetTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency);

        ModifiableDataReaderQos CopyFrom(TopicQos src);
    }
}