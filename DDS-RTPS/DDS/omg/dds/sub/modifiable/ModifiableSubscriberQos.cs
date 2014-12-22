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

namespace org.omg.dds.sub.modifiable
{

    public interface ModifiableSubscriberQos : SubscriberQos,
            ModifiableEntityQos<SubscriberQos, ModifiableSubscriberQos>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presentation">The presentation to set</param>
        /// <returns>this</returns>
        ModifiableSubscriberQos SetPresentation(PresentationQosPolicy presentation);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="partition">The partition to set</param>
        /// <returns>this</returns>
        ModifiableSubscriberQos SetPartition(PartitionQosPolicy partition);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupData">The groupData to set</param>
        /// <returns>this</returns>
        ModifiableSubscriberQos SetGroupData(GroupDataQosPolicy groupData);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityFactory">The entityFactory to set</param>
        /// <returns>this</returns>
        ModifiableSubscriberQos SetEntityFactory(EntityFactoryQosPolicy entityFactory);
    }
}