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
using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using System;
using System.Collections.Generic;

namespace org.omg.dds.core.status
{

    /// <summary>
    /// Status is the abstract root class for all communication status objects.
    /// All concrete kinds of Status classes extend this class.
    /// 
    /// Each concrete {@link Entity} is associated with a set of Status objects
    /// whose value represents the "communication status" of that entity. These
    /// status values can be accessed with corresponding methods on the Entity.
    /// The changes on these status values are the ones that both cause activation
    /// of the corresponding {@link StatusCondition} objects and trigger invocation
    /// of the proper Listener objects to asynchronously inform the application.
    /// </summary>
    /// <typeparam name="SELF"></typeparam>
    /// <typeparam name="SOURCE"></typeparam>
    public abstract class Status<SELF, SOURCE>
     : EventObject, ModifiableValue<SELF, SELF>
        where SELF : Status<SELF, SOURCE>
        where SOURCE : IEntity
    {

        // -----------------------------------------------------------------------
        // Object Life Cycle
        // -----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the object will belong</param>
        /// <returns></returns>
        public static ISet<Type> AllStatuses(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().AllStatusKinds();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the object will belong</param>
        /// <returns></returns>
        public static ISet<Type> NoStatuses(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().NoStatusKinds();
        }


        // -----------------------------------------------------------------------

        protected Status(SOURCE source)
            : base(source)
        {
        }



        // -----------------------------------------------------------------------
        // Methods
        // -----------------------------------------------------------------------

        // --- API: --------------------------------------------------------------

        public abstract SOURCE GetSource();

        //public abstract SELF clone();


        // --- SPI: --------------------------------------------------------------

        protected void SetSource(SOURCE source)
        {
            base.source = source;
        }

        public abstract SELF CopyFrom(SELF other);

        public abstract SELF FinishModification();

        public abstract SELF Clone();

        public abstract SELF Modify();

        public abstract Bootstrap GetBootstrap();

    }
}