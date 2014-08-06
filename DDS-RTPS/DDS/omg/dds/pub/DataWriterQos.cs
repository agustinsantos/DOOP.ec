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
        /**
         * @return the durability
         */
        DurabilityQosPolicy getDurability();

        /**
         * @return the durabilityService
         */
        DurabilityServiceQosPolicy getDurabilityService();

        /**
         * @return the deadline
         */
        DeadlineQosPolicy getDeadline();

        /**
         * @return the latencyBudget
         */
        LatencyBudgetQosPolicy getLatencyBudget();

        /**
         * @return the liveliness
         */
        LivelinessQosPolicy getLiveliness();

        /**
         * @return the reliability
         */
        ReliabilityQosPolicy getReliability();

        /**
         * @return the destinationOrder
         */
        DestinationOrderQosPolicy getDestinationOrder();

        /**
         * @return the history
         */
        HistoryQosPolicy getHistory();

        /**
         * @return the resourceLimits
         */
        ResourceLimitsQosPolicy getResourceLimits();

        /**
         * @return the transportPriority
         */
        TransportPriorityQosPolicy getTransportPriority();

        /**
         * @return the lifespan
         */
        LifespanQosPolicy getLifespan();

        /**
         * @return the userData
         */
        UserDataQosPolicy getUserData();

        /**
         * @return the ownership
         */
        OwnershipQosPolicy getOwnership();

        /**
         * @return the ownershipStrength
         */
        OwnershipStrengthQosPolicy getOwnershipStrength();

        /**
         * @return the writerDataLifecycle
         */
        WriterDataLifecycleQosPolicy getWriterDataLifecycle();

        DataRepresentationQosPolicy getRepresentation();

        TypeConsistencyEnforcementQosPolicy getTypeConsistency();
    }
}