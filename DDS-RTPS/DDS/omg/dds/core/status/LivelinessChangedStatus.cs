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
using org.omg.dds.core.modifiable;
using org.omg.dds.sub;

namespace org.omg.dds.core.status
{

    public abstract class LivelinessChangedStatus<TYPE>     : Status<LivelinessChangedStatus<TYPE>, DataReader<TYPE>>
    {

        // -----------------------------------------------------------------------
        // Object Life Cycle
        // -----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the new object will belong</param>
        /// <returns></returns>
        public static LivelinessChangedStatus<TYPE>        NewLivelinessChangedStatus(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().newLivelinessChangedStatus<TYPE>();
        }


        // -----------------------------------------------------------------------

        protected LivelinessChangedStatus(DataReader<TYPE> source)
            : base(source)
        {
        }



        // -----------------------------------------------------------------------
        // Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The aliveCount</returns>
        public abstract int GetAliveCount();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The notAliveCount</returns>
        public abstract int GetNotAliveCount();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The aliveCountChange</returns>
        public abstract int GetAliveCountChange();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The notAliveCountChange</returns>
        public abstract int GetNotAliveCountChange();

        public abstract ModifiableInstanceHandle GetLastPublicationHandle();

    }
}