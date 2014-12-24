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
using org.omg.dds.core.status;
using org.omg.dds.domain;

namespace org.omg.dds.topic
{
    public interface ITopic : ITopicDescription, IDomainEntity
    { }

    /// <summary>
    ///  Topic is the most basic description of the data to be published and
    ///  subscribed.
    ///  
    /// A Topic is identified by its name, which must be unique in the whole
    /// Domain.
    /// Topic is the only TopicDescription that can be used for publications and
    /// therefore associated to a {@link DataWriter}. All operations except for
    /// the inherited operations {@link #SetQos(org.omg.dds.core.EntityQos)},
    /// {@link #Qos()}, {@link #SetListener(java.util.EventListener)},
    /// {@link #GetListener()}, {@link #Enable()}, and
    /// {@link #GetStatusCondition()} may fail with the exception
    /// {@link NotEnabledException}
    /// </summary>
    /// <typeparam name="TYPE">The concrete type of the data that will be published and/
    ///                        or subscribed by the readers and writers that use this
    ///                        topic
    /// </typeparam>
    public interface Topic<TYPE> : TopicDescription<TYPE>, DomainEntity<Topic<TYPE>,
                                                 DomainParticipant,
                                                 TopicListener<TYPE>,
                                                 TopicQos>,
                                                    ITopic
    {
        InconsistentTopicStatus<TYPE> GetInconsistentTopicStatus(InconsistentTopicStatus<TYPE> status);
    }
}