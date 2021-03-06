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
using org.omg.dds.core.modifiable;
using org.omg.dds.core.policy;
using org.omg.dds.type;
using org.omg.dds.type.typeobject;
using System.Collections.Generic;

namespace org.omg.dds.topic
{

    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    public abstract class SubscriptionBuiltinTopicData : ModifiableValue<SubscriptionBuiltinTopicData,
                               SubscriptionBuiltinTopicData>
    {

        // -----------------------------------------------------------------------
        // Factory Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the new
        ///                         object will belong
        /// </param>
        /// <returns></returns>
        public static SubscriptionBuiltinTopicData NewSubscriptionBuiltinTopicData(
                Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().NewSubscriptionBuiltinTopicData();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        [ID(0x005A)]
        [Key]
        public abstract BuiltinTopicKey Key { get; }

        /// <summary>
        /// Return the participantKey
        /// </summary>
        [ID(0x0050)]
        public abstract BuiltinTopicKey ParticipantKey { get; }

        /// <summary>
        /// Return the topicName
        /// </summary>
        [ID(0x0005)]
        public abstract string TopicName { get; }

        /// <summary>
        /// Return the typeName
        /// </summary>
        [ID(0x0007)]
        public abstract string TypeName { get; }

        [ID(0x0075)]
        [Optional]
        public abstract List<string> EquivalentTypeName { get; }

        [ID(0x0076)]
        [Optional]
        public abstract List<string> BaseTypeName { get; }

        [ID(0x0072)]
        [Optional]
        public abstract TypeObject Type { get; }

        /// <summary>
        /// Return the durability
        /// </summary>
        [ID(0x001D)]
        public abstract DurabilityQosPolicy Durability { get; }

        /// <summary>
        /// Return the deadline
        /// </summary>
        [ID(0x0023)]
        public abstract DeadlineQosPolicy Deadline { get; }

        /// <summary>
        /// Return the latencyBudget
        /// </summary>
        [ID(0x0027)]
        public abstract LatencyBudgetQosPolicy LatencyBudget { get; }

        /// <summary>
        /// Return the liveliness
        /// </summary>
        [ID(0x001B)]
        public abstract LivelinessQosPolicy Liveliness { get; }

        /// <summary>
        /// Return the reliability
        /// </summary>
        [ID(0x001A)]
        public abstract ReliabilityQosPolicy Reliability { get; }

        /// <summary>
        /// Return the ownership
        /// </summary>
        [ID(0x001F)]
        public abstract OwnershipQosPolicy Ownership { get; }

        /// <summary>
        /// Return the destinationOrder
        /// </summary>
        [ID(0x0025)]
        public abstract DestinationOrderQosPolicy DestinationOrder { get; }

        /// <summary>
        /// Return the userData
        /// </summary>
        [ID(0x002C)]
        public abstract UserDataQosPolicy UserData { get; }

        /// <summary>
        /// Return the timeBasedFilter
        /// </summary>
        [ID(0x0004)]
        public abstract TimeBasedFilterQosPolicy TimeBasedFilter { get; }

        /// <summary>
        /// Return the presentation
        /// </summary>
        [ID(0x0021)]
        public abstract PresentationQosPolicy Presentation { get; }

        /// <summary>
        /// Return the partition
        /// </summary>
        [ID(0x0029)]
        public abstract PartitionQosPolicy Partition { get; }

        /// <summary>
        /// Return the topicData
        /// </summary>
        [ID(0x002E)]
        public abstract TopicDataQosPolicy TopicData { get; }

        /// <summary>
        /// Return the groupData
        /// </summary>
        [ID(0x002D)]
        public abstract GroupDataQosPolicy GroupData { get; }

        [ID(0x0073)]
        public abstract DataRepresentationQosPolicy Representation { get; }

        [ID(0x0074)]
        public abstract TypeConsistencyEnforcementQosPolicy TypeConsistency { get; }


        // --- From Object: ------------------------------------------------------

        //public abstract SubscriptionBuiltinTopicData clone();

        public abstract SubscriptionBuiltinTopicData CopyFrom(SubscriptionBuiltinTopicData other);

        public abstract SubscriptionBuiltinTopicData FinishModification();

        public abstract SubscriptionBuiltinTopicData Modify();

        public abstract Bootstrap GetBootstrap();
    }
}