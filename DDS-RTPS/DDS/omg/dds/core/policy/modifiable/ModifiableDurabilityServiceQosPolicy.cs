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
    public interface ModifiableDurabilityServiceQosPolicy
     : DurabilityServiceQosPolicy,
            ModifiableQosPolicy<DurabilityServiceQosPolicy,
                                ModifiableDurabilityServiceQosPolicy>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCleanupDelay">The serviceCleanupDelay to set</param>
        /// <returns>this</returns>
        ModifiableDurabilityServiceQosPolicy setServiceCleanupDelay(
              Duration serviceCleanupDelay);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCleanupDelay"></param>
        /// <param name="unit"></param>
        /// <returns>this</returns>
        ModifiableDurabilityServiceQosPolicy setServiceCleanupDelay(long serviceCleanupDelay, TimeUnit unit);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="historyKind">The historyKind to set</param>
        /// <returns>this</returns>
        ModifiableDurabilityServiceQosPolicy setHistoryKind(HistoryQosPolicyKind historyKind);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="historyDepth">The historyDepth to set</param>
        /// <returns>this</returns>
        ModifiableDurabilityServiceQosPolicy setHistoryDepth(int historyDepth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSamples">The maxSamples to set</param>
        /// <returns>this</returns>
        ModifiableDurabilityServiceQosPolicy setMaxSamples(int maxSamples);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxInstances">The maxInstances to set</param>
        /// <returns>this</returns>
        ModifiableDurabilityServiceQosPolicy setMaxInstances(int maxInstances);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSamplesPerInstance">The maxSamplesPerInstance to set</param>
        /// <returns>this</returns>
        ModifiableDurabilityServiceQosPolicy setMaxSamplesPerInstance(int maxSamplesPerInstance);
    }
}