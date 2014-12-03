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

namespace org.omg.dds.core.modifiable
{
    public abstract class ModifiableDuration : Duration, ModifiableValue<Duration, ModifiableDuration>
    {

        // -----------------------------------------------------------------------
        // Methods
        // -----------------------------------------------------------------------

        // --- Data access: ------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        public abstract ModifiableDuration setDuration(long duration, TimeUnit unit);


        // --- Manipulation: -----------------------------------------------------

        /// <summary>
        /// Increase this duration by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns>this</returns>
        public abstract ModifiableDuration add(Duration duration);

        /// <summary>
        /// Increase this duration by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        public abstract ModifiableDuration add(long duration, TimeUnit unit);

        /// <summary>
        /// Decrease this duration by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns>this</returns>
        public abstract ModifiableDuration subtract(Duration duration);

        /// <summary>
        /// Decrease this duration by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        public abstract ModifiableDuration subtract(long duration, TimeUnit unit);


        // --- From Object: ------------------------------------------------------


        //public abstract ModifiableDuration clone();

        public abstract ModifiableDuration CopyFrom(Duration other);

        public abstract Duration finishModification();
    }
}