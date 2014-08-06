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


using org.omg.dds.core.policy;
using org.omg.dds.pub;
using System.Collections.Generic;

namespace org.omg.dds.core.status
{

    public abstract class OfferedIncompatibleQosStatus<TYPE> : Status<OfferedIncompatibleQosStatus<TYPE>, DataWriter<TYPE>>
    {

        // -----------------------------------------------------------------------
        // Object Life Cycle
        // -----------------------------------------------------------------------

        /**
         * @param bootstrap Identifies the Service instance to which the new
         *                  object will belong.
         */
        public static OfferedIncompatibleQosStatus<TYPE>
        newOfferedIncompatibleQosStatus(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().newOfferedIncompatibleQosStatus<TYPE>();
        }


        // -----------------------------------------------------------------------

        protected OfferedIncompatibleQosStatus(DataWriter<TYPE> source)
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
         * @return the lastPolicyId
         */
        public abstract QosPolicyId getLastPolicyId();

        /**
         * @return  an unmodifiable set of policy counts.
         */
        public abstract ISet<QosPolicyCount> getPolicies();

    }
}