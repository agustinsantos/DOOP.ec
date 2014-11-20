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
    /// Each concrete {<link>Entity</link> } is associated with a set of Status objects
    /// whose value represents the "communication status" of that entity. These
    /// status values can be accessed with corresponding methods on the Entity.
    /// The changes on these status values are the ones that both cause activation
    /// of the corresponding {<link>StatusCondition</link> } objects and trigger invocation
    /// of the proper Listener objects to asynchronously inform the application.
    /// </summary>
    /// <typeparam name="SELF"></typeparam>
    /// <typeparam name="SOURCE"></typeparam>
    public abstract class Status<SELF, SOURCE>
     : EventObject, ModifiableValue<SELF, SELF>
        where SELF : Status<SELF, SOURCE>
        where SOURCE : IEntity
    {

        /// <summary>
        /// Object Life Cycle
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the
        ///                 object will belong.</param>
        /// <returns></returns>
        public static ISet<Type> allStatuses(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().allStatusKinds();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the
        ///                 object will belong.</param>
        /// <returns></returns>
        public static ISet<Type> noStatuses(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().noStatusKinds();
        }


        // -----------------------------------------------------------------------

        protected Status(SOURCE source)
            : base(source)
        {
        }



        /// <summary>
        /// Methods
        /// API
        /// </summary>
        /// <returns></returns>
        public abstract SOURCE getSource();

        /// <summary>
        /// public abstract SELF clone();
        /// SPI:
        /// </summary>
        /// <param name="source"></param>
        protected void setSource(SOURCE source)
        {
            base.source = source;
        }

        public abstract SELF copyFrom(SELF other);

        public abstract SELF finishModification();

        public abstract SELF Clone();

        public abstract SELF modify();

        public abstract Bootstrap getBootstrap();

    }
}