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

using System.Collections.Generic;

namespace org.omg.dds.core
{
    /// <summary>
    /// 
    ///
    /// A WaitSet object allows an application to wait until one or more of the
    /// attached {@link Condition} objects has a triggerValue of true or else until
    /// the timeout expires.
    ///
    /// WaitSet is not necessarily associated with a single
    /// {<link name= "DomainParticipant"></link> } and could be used to wait on Condition objects
    ///associated with different DomainParticipant objects.
    /// </summary>
    public abstract class WaitSet : DDSObject
    {
        /// <summary>
        /// Factory Methods
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the new
        ///                 object will belong.</param>
        /// <returns></returns>
       
        public static WaitSet newWaitSet(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().NewWaitSet();
        }
        /// <summary>
        /// Instance Methods
        /// </summary>

        public abstract void waitForConditions();

        public abstract void waitForConditions(ICollection<Condition> activeConditions);

        public abstract void waitForConditions(Duration timeout)
         ;

        public abstract void waitForConditions(long timeout, TimeUnit unit);

        public abstract void waitForConditions(ICollection<Condition> activeConditions,
                Duration timeout);

        public abstract void waitForConditions(ICollection<Condition> activeConditions,
                long timeout,
                TimeUnit unit);

        public abstract void attachCondition(Condition cond);
        public abstract void detachCondition(Condition cond);

       /// <summary>
       /// </summary>
       /// <returns>an unmodifiable collection of the conditions attached to this
       ///        wait set.</returns>
        public abstract ICollection<Condition> getConditions();

        public abstract Bootstrap GetBootstrap { get; }
    }
}