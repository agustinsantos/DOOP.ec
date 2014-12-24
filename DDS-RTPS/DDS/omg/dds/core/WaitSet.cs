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


using DDS.ConversionUtils;

using System.Collections.Generic;

namespace org.omg.dds.core
{

    /// <summary>
    /// A WaitSet object allows an application to wait until one or more of the
    /// attached {@link Condition} objects has a triggerValue of true or else until
    /// the timeout expires.
    /// 
    /// WaitSet is not necessarily associated with a single
    /// {@link DomainParticipant} and could be used to wait on Condition objects
    /// associated with different DomainParticipant objects.
    /// </summary>
    public abstract class WaitSet : DDSObject
    {
        // -----------------------------------------------------------------------
        // Factory Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the new object will belong</param>
        /// <returns></returns>
        public static WaitSet NewWaitSet(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().NewWaitSet();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        public abstract void WaitForConditions();

        public abstract void WaitForConditions(ICollection<Condition> activeConditions);

        public abstract void WaitForConditions(Duration timeout)
         ;

        public abstract void WaitForConditions(long timeout, TimeUnit unit);

        public abstract void WaitForConditions(ICollection<Condition> activeConditions,
                Duration timeout);

        public abstract void WaitForConditions(ICollection<Condition> activeConditions,
                long timeout,
                TimeUnit unit);

        public abstract void AttachCondition(Condition cond);
        public abstract void DetachCondition(Condition cond);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An unmodifiable collection of the conditions attached to this wait Set</returns>
        public abstract ICollection<Condition> GetConditions();

        public abstract Bootstrap GetBootstrap();
    }
}