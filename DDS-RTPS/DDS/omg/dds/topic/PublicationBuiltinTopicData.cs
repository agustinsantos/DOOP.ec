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


using System.Collections.Generic;

using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using org.omg.dds.core.policy;
using org.omg.dds.type;
using org.omg.dds.type.typeobject;

namespace org.omg.dds.topic
{

    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    public abstract class PublicationBuiltinTopicData : ModifiableValue<PublicationBuiltinTopicData,
                               PublicationBuiltinTopicData>
    {
        // -----------------------------------------------------------------------
        // Factory Methods
        // -----------------------------------------------------------------------

        /*
         * @param bootstrap Identifies the Service instance to which the new
         *                  object will belong.
         */
        public static PublicationBuiltinTopicData newPublicationBuiltinTopicData(
                Bootstrap bootstrap)
        {
            return bootstrap.getSPI().newPublicationBuiltinTopicData();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        [ID(0x005A)]
        [Key]
        public abstract BuiltinTopicKey Key { get; }

        /**
         * [return the participantKey
         */
        [ID(0x0050)]
        public abstract BuiltinTopicKey ParticipantKey { get; }

        /**
         * @return the topicName
         */
        [ID(0x0005)]
        public abstract string TopicName { get; }

        /**
         * @return the typeName
         */
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

        /**
         * @return the durability
         */
        [ID(0x001D)]
        public abstract DurabilityQosPolicy Durability { get; }

        /**
         * @return the durabilityService
         */
        [ID(0x001E)]
        public abstract DurabilityServiceQosPolicy DurabilityService { get; }

        /**
         * @return the deadline
         */
        [ID(0x0023)]
        public abstract DeadlineQosPolicy Deadline { get; }

        /**
         * @return the latencyBudget
         */
        [ID(0x0027)]
        public abstract LatencyBudgetQosPolicy LatencyBudget { get; }

        /**
         * @return the liveliness
         */
        [ID(0x001B)]
        public abstract LivelinessQosPolicy Liveliness { get; }

        /**
         * @return the reliability
         */
        [ID(0x001A)]
        public abstract ReliabilityQosPolicy Reliability { get; }

        /**
         * @return the lifespan
         */
        [ID(0x002B)]
        public abstract LifespanQosPolicy Lifespan { get; }

        /**
         * @return the userData
         */
        [ID(0x002C)]
        public abstract UserDataQosPolicy UserData { get; }

        /**
         * @return the ownership
         */
        [ID(0x001F)]
        public abstract OwnershipQosPolicy Ownership { get; }

        /**
         * @return the ownershipStrength
         */
        [ID(0x0006)]
        public abstract OwnershipStrengthQosPolicy OwnershipStrength { get; }

        /**
         * @return the destinationOrder
         */
        [ID(0x0025)]
        public abstract DestinationOrderQosPolicy DestinationOrder { get; }

        /**
         * @return the presentation
         */
        [ID(0x0021)]
        public abstract PresentationQosPolicy Presentation { get; }

        /**
         * @return the partition
         */
        [ID(0x0029)]
        public abstract PartitionQosPolicy Partition { get; }

        /**
         * @return the topicData
         */
        [ID(0x002E)]
        public abstract TopicDataQosPolicy TopicData { get; }

        /**
         * @return the groupData
         */
        [ID(0x002D)]
        public abstract GroupDataQosPolicy GroupData { get; }

        [ID(0x0073)]
        public abstract DataRepresentationQosPolicy Representation { get; }

        [ID(0x0074)]
        public abstract TypeConsistencyEnforcementQosPolicy TypeConsistency { get; }


        // --- From Object: ------------------------------------------------------


        //public abstract PublicationBuiltinTopicData clone();

        public abstract PublicationBuiltinTopicData CopyFrom(PublicationBuiltinTopicData other);

        public abstract PublicationBuiltinTopicData finishModification();


        public abstract PublicationBuiltinTopicData Clone();

        public abstract PublicationBuiltinTopicData Modify();

        public abstract Bootstrap getBootstrap();
    }
}