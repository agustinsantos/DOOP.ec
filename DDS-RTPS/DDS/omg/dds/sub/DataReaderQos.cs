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
        /// return the durability
        /// </summary>
        /// <returns></returns>
        DurabilityQosPolicy getDurability();

        /// <summary>
        /// return the deadline
        /// </summary>
        /// <returns></returns>
        DeadlineQosPolicy getDeadline();

        /// <summary>
        /// return the latencyBudget
        /// </summary>
        /// <returns></returns>
        LatencyBudgetQosPolicy getLatencyBudget();

        /// <summary>
        /// return the liveliness
        /// </summary>
        /// <returns></returns>
        LivelinessQosPolicy getLiveliness();

        /// <summary>
        /// return the destinationOrder
        /// </summary>
        /// <returns></returns>
        DestinationOrderQosPolicy getDestinationOrder();

        /// <summary>
        /// return the history
        /// </summary>
        /// <returns></returns>
        HistoryQosPolicy getHistory();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ResourceLimitsQosPolicy getResourceLimits();

        /// <summary>
        /// return the userData
        /// </summary>
        /// <returns></returns>
        UserDataQosPolicy getUserData();

        /// <summary>
        /// return the ownership
        /// </summary>
        /// <returns></returns>
        OwnershipQosPolicy getOwnership();

        /// <summary>
        /// return the timeBasedFilter
        /// </summary>
        /// <returns></returns>
        TimeBasedFilterQosPolicy getTimeBasedFilter();

        /// <summary>
        /// return the readerDataLifecycle
        /// </summary>
        /// <returns></returns>
        ReaderDataLifecycleQosPolicy getReaderDataLifecycle();

        DataRepresentationQosPolicy getRepresentation();

        TypeConsistencyEnforcementQosPolicy getTypeConsistency();
    }
}