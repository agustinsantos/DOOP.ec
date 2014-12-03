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

namespace org.omg.dds.core.policy.modifiable
{

    public interface ModifiableResourceLimitsQosPolicy : ResourceLimitsQosPolicy,
            ModifiableQosPolicy<ResourceLimitsQosPolicy, ModifiableResourceLimitsQosPolicy>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSamples">The maxSamples to set</param>
        /// <returns>this</returns>
        ModifiableResourceLimitsQosPolicy setMaxSamples(int maxSamples);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxInstances">The maxInstances to set</param>
        /// <returns>this</returns>
        ModifiableResourceLimitsQosPolicy setMaxInstances(
              int maxInstances);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSamplesPerInstance">The maxSamplesPerInstance to set</param>
        /// <returns>this</returns>
        ModifiableResourceLimitsQosPolicy setMaxSamplesPerInstance(
              int maxSamplesPerInstance);
    }
}