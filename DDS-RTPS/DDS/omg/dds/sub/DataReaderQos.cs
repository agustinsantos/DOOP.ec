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
using org.omg.dds.core.policy;
using org.omg.dds.sub.modifiable;

namespace org.omg.dds.sub
{

    public interface DataReaderQos : EntityQos<DataReaderQos, ModifiableDataReaderQos>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The durability</returns>
        DurabilityQosPolicy GetDurability();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The deadline</returns>
        DeadlineQosPolicy GetDeadline();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The latencyBudget</returns>
        LatencyBudgetQosPolicy GetLatencyBudget();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The liveliness</returns>
        LivelinessQosPolicy GetLiveliness();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The destinationOrder</returns>
        DestinationOrderQosPolicy GetDestinationOrder();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The history</returns>
        HistoryQosPolicy GetHistory();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ResourceLimitsQosPolicy GetResourceLimits();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The userData</returns>
        UserDataQosPolicy GetUserData();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The ownership</returns>
        OwnershipQosPolicy GetOwnership();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The timeBasedFilter</returns>
        TimeBasedFilterQosPolicy GetTimeBasedFilter();

        /// <summary>
        ///
        /// </summary>
        /// <returns>The readerDataLifecycle</returns>
        ReaderDataLifecycleQosPolicy GetReaderDataLifecycle();

        DataRepresentationQosPolicy GetRepresentation();

        TypeConsistencyEnforcementQosPolicy GetTypeConsistency();
    }
}