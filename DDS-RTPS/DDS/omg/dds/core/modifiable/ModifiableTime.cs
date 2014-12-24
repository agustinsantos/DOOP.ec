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

    public abstract class ModifiableTime : Time, ModifiableValue<Time, ModifiableTime>
    {


        // -----------------------------------------------------------------------
        // Methods
        // -----------------------------------------------------------------------

        // --- Data access: ------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        public abstract ModifiableTime SetTime(long time, TimeUnit unit);


        // --- Manipulation: -----------------------------------------------------

        /// <summary>
        /// Increment this time by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns>this</returns>
        public abstract ModifiableTime Add(Duration duration);

        /// <summary>
        /// Increment this time by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        public abstract ModifiableTime Add(long duration, TimeUnit unit);

        /// <summary>
        /// Decrement this time by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns>this</returns>
        public abstract ModifiableTime Subtract(Duration duration);

        /// <summary>
        /// Decrement this time by the given amount.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        public abstract ModifiableTime Subtract(long duration, TimeUnit unit);


        // --- From Object: ------------------------------------------------------

        //public  abstract ModifiableTime clone();

        public abstract ModifiableTime CopyFrom(Time other);

        public abstract Time FinishModification();


        //  public abstract Value modify();
    }
}