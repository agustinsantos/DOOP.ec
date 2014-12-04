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
using org.omg.dds.pub.modifiable;

namespace org.omg.dds.pub
{

    public interface DataWriterQos : EntityQos<DataWriterQos, ModifiableDataWriterQos>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The durability</returns>
        DurabilityQosPolicy getDurability();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The durabilityService</returns>
        DurabilityServiceQosPolicy getDurabilityService();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The deadline</returns>
        DeadlineQosPolicy getDeadline();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The latencyBudget</returns>
        LatencyBudgetQosPolicy getLatencyBudget();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The liveliness</returns>
        LivelinessQosPolicy getLiveliness();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The reliability</returns>
        ReliabilityQosPolicy getReliability();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The destinationOrder</returns>
        DestinationOrderQosPolicy getDestinationOrder();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The history</returns>
        HistoryQosPolicy getHistory();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The resourceLimits</returns>
        ResourceLimitsQosPolicy getResourceLimits();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The transportPriority</returns>
        TransportPriorityQosPolicy getTransportPriority();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The lifespan</returns>
        LifespanQosPolicy getLifespan();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The userData</returns>
        UserDataQosPolicy getUserData();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The ownership</returns>
        OwnershipQosPolicy getOwnership();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The ownershipStrength</returns>
        OwnershipStrengthQosPolicy getOwnershipStrength();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The writerDataLifecycle</returns>
        WriterDataLifecycleQosPolicy getWriterDataLifecycle();

        DataRepresentationQosPolicy getRepresentation();

        TypeConsistencyEnforcementQosPolicy getTypeConsistency();
    }
}