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
using org.omg.dds.sub;

namespace org.omg.dds.core.status
{

    public abstract class SampleLostStatus<TYPE>
     : Status<SampleLostStatus<TYPE>, DataReader<TYPE>>
    {

        /// <summary>
        /// Object Life Cycle
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the new
        ///                 object will belong.</param>
        /// <returns></returns>
        public static SampleLostStatus<TYPE> newSampleLostStatus(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().newSampleLostStatus<TYPE>();
        }


        // -----------------------------------------------------------------------

        protected SampleLostStatus(DataReader<TYPE> source)
            : base(source)
        {
        }



        // -----------------------------------------------------------------------
        // Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// Methods
        /// </summary>
        /// <returns>the totalCount</returns>
        public abstract int getTotalCount();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>the totalCountChange</returns>
        public abstract int getTotalCountChange();

    }
}