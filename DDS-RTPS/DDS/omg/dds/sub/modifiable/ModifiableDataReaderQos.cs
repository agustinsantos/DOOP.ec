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
using org.omg.dds.sub;
using org.omg.dds.topic;

namespace org.omg.dds.sub.modifiable
{

    public interface ModifiableDataReaderQos : DataReaderQos, ModifiableEntityQos<DataReaderQos, ModifiableDataReaderQos>
    {
        /**
         * @param durability the durability to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setDurability(DurabilityQosPolicy durability);

        /**
       * @param deadline the deadline to set
       * 
       * @return  this
       */
        ModifiableDataReaderQos setDeadline(DeadlineQosPolicy deadline);

        /**
       * @param latencyBudget the latencyBudget to set
       * 
       * @return  this
       */
        ModifiableDataReaderQos setLatencyBudget(LatencyBudgetQosPolicy latencyBudget);


        /**
         * @param liveliness the liveliness to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setLiveliness(LivelinessQosPolicy liveliness);


        /**
         * @param destinationOrder the destinationOrder to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setDestinationOrder(DestinationOrderQosPolicy destinationOrder);


        /**
         * @param history the history to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setHistory(HistoryQosPolicy history);


        /**
         * @param resourceLimits the resourceLimits to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setResourceLimits(ResourceLimitsQosPolicy resourceLimits);


        /**
         * @param userData the userData to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setUserData(UserDataQosPolicy userData);

        /**
        * @param ownership the ownership to set
        * 
        * @return  this
        */
        ModifiableDataReaderQos setOwnership(OwnershipQosPolicy ownership);


        /**
         * @param timeBasedFilter the timeBasedFilter to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setTimeBasedFilter(TimeBasedFilterQosPolicy timeBasedFilter);


        /**
         * @param readerDataLifecycle the readerDataLifecycle to set
         * 
         * @return  this
         */
        ModifiableDataReaderQos setReaderDataLifecycle(ReaderDataLifecycleQosPolicy readerDataLifecycle);


        /**
         * @return  this
         */
        ModifiableDataReaderQos setRepresentation(DataRepresentationQosPolicy representation);


        /**
         * @return  this
         */
        ModifiableDataReaderQos setTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency);

        ModifiableDataReaderQos copyFrom(TopicQos src);
    }
}