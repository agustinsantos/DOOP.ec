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

using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using org.omg.dds.core.policy;
using org.omg.dds.type;

namespace org.omg.dds.topic
{


    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    public abstract class ParticipantBuiltinTopicData : ModifiableValue<ParticipantBuiltinTopicData,
                               ParticipantBuiltinTopicData>
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
        public static ParticipantBuiltinTopicData NewParticipantBuiltinTopicData(
                Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().NewParticipantBuiltinTopicData();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        [ID(0x0050)]
        [Key]
        public abstract BuiltinTopicKey Key { get; }

        [ID(0x002C)]
        public abstract UserDataQosPolicy UserData { get; }


        // --- From Object: ------------------------------------------------------

        //public abstract ParticipantBuiltinTopicData clone();

        public abstract ParticipantBuiltinTopicData CopyFrom(ParticipantBuiltinTopicData other);

        public abstract ParticipantBuiltinTopicData FinishModification();

        public abstract ParticipantBuiltinTopicData Clone();

        public abstract ParticipantBuiltinTopicData Modify();

        public abstract Bootstrap GetBootstrap();
    }
}