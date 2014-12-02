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
using org.omg.dds.core.policy;

namespace org.omg.dds.core.policy.modifiable
{
    public interface ModifiableReliabilityQosPolicy : ReliabilityQosPolicy, ModifiableQosPolicy<ReliabilityQosPolicy, ModifiableReliabilityQosPolicy>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind">The kind to set</param>
        /// <returns>this</returns>
        ModifiableReliabilityQosPolicy setKind(ReliabilityQosPolicyKind kind);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxBlockingTime">The maxBlockingTime to set</param>
        /// <returns>this</returns>
        ModifiableReliabilityQosPolicy setMaxBlockingTime(Duration maxBlockingTime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxBlockingTime"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        ModifiableReliabilityQosPolicy setMaxBlockingTime(long maxBlockingTime, TimeUnit unit);
    }
}