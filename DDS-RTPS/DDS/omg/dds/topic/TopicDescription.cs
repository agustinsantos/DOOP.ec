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
using org.omg.dds.domain;
using org.omg.dds.type;
using System;

namespace org.omg.dds.topic
{
    public interface ITopicDescription : DDSObject
    {
        string Name { get; set; }
        Type Type { get; }
    }

    /// <summary>
    /// This interface is the base for {@link Topic}, {@link ContentFilteredTopic},
    /// and {@link MultiTopic}
    /// 
    /// TopicDescription represents the fact that both publications and
    /// subscriptions are tied to a single data type. Its attribute typeName
    /// defines a unique resulting type for the publication or the subscription
    /// and therefore creates an implicit association with a {@link TypeSupport}.
    /// TopicDescription has also a name that allows it to be retrieved locally.
    /// </summary>
    /// <typeparam name="TYPE">The concrete type of the data that will be published and/
    ///                        or subscribed by the readers and writers that use this
    ///                        topic description
    /// </typeparam>
    public interface TopicDescription<TYPE> : ITopicDescription, DDSObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The type parameter if this object's class</returns>
        Type getType();

        /// <summary>
        /// Cast this topic description to the given type, or throw an exception if
        /// the cast fails
        /// 
        /// @throws          ClassCastException if the cast fails
        /// </summary>
        /// <typeparam name="OTHER">The type of the data exchanged on this topic,
        ///                         according to the caller
        /// </typeparam>
        /// <returns>This topic description</returns>
        TopicDescription<OTHER> cast<OTHER>();

        string getTypeName();
        string getName();

        DomainParticipant getParent();

        /// <summary>
        /// Dispose the resources held by this object
        /// </summary>
        void Close();
    }
}