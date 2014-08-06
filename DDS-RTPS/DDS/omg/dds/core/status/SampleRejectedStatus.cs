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

    public abstract class SampleRejectedStatus<TYPE>
     : Status<SampleRejectedStatus<TYPE>, DataReader<TYPE>>
    {
        // -----------------------------------------------------------------------
        // Object Life Cycle
        // -----------------------------------------------------------------------

        /**
         * @param bootstrap Identifies the Service instance to which the new
         *                  object will belong.
         */
        public static SampleRejectedStatus<TYPE> newSampleRejectedStatus(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().newSampleRejectedStatus<TYPE>();
        }


        // -----------------------------------------------------------------------

        protected SampleRejectedStatus(DataReader<TYPE> source)
            : base(source)
        {
        }



        // -----------------------------------------------------------------------
        // Methods
        // -----------------------------------------------------------------------

        /**
         * @return the totalCount
         */
        public abstract int getTotalCount();

        /**
         * @return the totalCountChange
         */
        public abstract int getTotalCountChange();

        /**
         * @return the lastReason
         */
        public abstract Kind getLastReason();

        public abstract ModifiableInstanceHandle getLastInstanceHandle();



        // -----------------------------------------------------------------------
        // Types
        // -----------------------------------------------------------------------

        public enum Kind
        {
            NOT_REJECTED,
            REJECTED_BY_INSTANCES_LIMIT,
            REJECTED_BY_SAMPLES_LIMIT,
            REJECTED_BY_SAMPLES_PER_INSTANCE_LIMIT
        }

    }
}