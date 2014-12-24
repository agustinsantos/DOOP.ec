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


using DDS.ConversionUtils;
using org.omg.dds.domain;

namespace org.omg.dds.core
{
    public interface IDomainEntity : IEntity
    { }

    /// <summary>
    /// DomainEntity is the abstract base class for all DCPS entities, except for
    /// the {@link DomainParticipant}. Its sole purpose is to express that
    /// DomainParticipant is a special kind of Entity, which acts as a container
    /// of all other Entity, but itself cannot contain other DomainParticipant
    /// </summary>
    /// <typeparam name="SELF">The most-derived DDS-standard interface implemented by this entity</typeparam>
    /// <typeparam name="PARENT">The most-derived DDS-standard interface implemented
    ///                          by the entity that creates entities of this type</typeparam>
    /// <typeparam name="LISTENER">The listener interface appropriate for this entity</typeparam>
    /// <typeparam name="QOS">The QoS interface appropriate for this entity</typeparam>
    public interface DomainEntity<SELF, PARENT, LISTENER, QOS> : Entity<SELF, LISTENER, QOS>
        where SELF : Entity<SELF, LISTENER, QOS>
        where PARENT : IEntity
        where LISTENER : EventListener
        where QOS : EntityQos
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The factory object that created this entity</returns>
        PARENT GetParent();
    }
}