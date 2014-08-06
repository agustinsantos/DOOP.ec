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
using org.omg.dds.pub;
using org.omg.dds.topic;

namespace org.omg.dds.pub.modifiable
{

    public interface ModifiableDataWriterQos : DataWriterQos, ModifiableEntityQos<DataWriterQos, ModifiableDataWriterQos>
    {
        /**
         * @param durability the durability to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setDurability(DurabilityQosPolicy durability);


        /**
         * @param durabilityService the durabilityService to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setDurabilityService(DurabilityServiceQosPolicy durabilityService);


        /**
         * @param deadline the deadline to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setDeadline(DeadlineQosPolicy deadline);


        /**
         * @param latencyBudget the latencyBudget to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setLatencyBudget(LatencyBudgetQosPolicy latencyBudget);


        /**
         * @param liveliness the liveliness to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setLiveliness(LivelinessQosPolicy liveliness);


        /**
         * @param reliability the reliability to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setReliability(ReliabilityQosPolicy reliability);


        /**
         * @param destinationOrder the destinationOrder to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setDestinationOrder(DestinationOrderQosPolicy destinationOrder);


        /**
         * @param history the history to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setHistory(HistoryQosPolicy history);


        /**
         * @param resourceLimits the resourceLimits to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setResourceLimits(ResourceLimitsQosPolicy resourceLimits);


        /**
         * @param transportPriority the transportPriority to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setTransportPriority(TransportPriorityQosPolicy transportPriority);

        /**
        * @param lifespan the lifespan to set
        * 
        * @return  this
        */
        ModifiableDataWriterQos setLifespan(LifespanQosPolicy lifespan);


        /**
         * @param userData the userData to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setUserData(UserDataQosPolicy userData);


        /**
         * @param ownership the ownership to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setOwnership(OwnershipQosPolicy ownership);

        /**
         * @param ownershipStrength the ownershipStrength to set
         * 
         * @return  this
         */
        ModifiableDataWriterQos setOwnershipStrength(OwnershipStrengthQosPolicy ownershipStrength);

        /**
        * @param writerDataLifecycle the writerDataLifecycle to set
        * 
        * @return  this
        */
        ModifiableDataWriterQos setWriterDataLifecycle(WriterDataLifecycleQosPolicy writerDataLifecycle);


        /**
         * @return  this
         */
        ModifiableDataWriterQos setRepresentation(DataRepresentationQosPolicy representation);


        /**
         * @return  this
         */
        ModifiableDataWriterQos setTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency);

        ModifiableDataWriterQos copyFrom(TopicQos src);
    }
}