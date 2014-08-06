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

namespace org.omg.dds.pub.modifiable
{

    public interface ModifiablePublisherQos : PublisherQos, ModifiableEntityQos<PublisherQos, ModifiablePublisherQos>
    {
        /**
         * @param presentation the presentation to set
         * 
         * @return  this
         */
        ModifiablePublisherQos setPresentation(
              PresentationQosPolicy presentation);


        /**
         * @param partition the partition to set
         * 
         * @return  this
         */
        ModifiablePublisherQos setPartition(PartitionQosPolicy partition);

        /**
         * @param groupData the groupData to set
         * 
         * @return  this
         */
        ModifiablePublisherQos setGroupData(GroupDataQosPolicy groupData);

        /**
         * @param entityFactory the entityFactory to set
         * 
         * @return  this
         */
        ModifiablePublisherQos setEntityFactory(EntityFactoryQosPolicy entityFactory);

    }
}