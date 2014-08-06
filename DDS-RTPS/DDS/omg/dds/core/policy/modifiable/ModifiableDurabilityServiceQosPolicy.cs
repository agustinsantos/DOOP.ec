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
        /**
         * @param serviceCleanupDelay the serviceCleanupDelay to set
         * 
         * @return  this
         */
        ModifiableDurabilityServiceQosPolicy setServiceCleanupDelay(
              Duration serviceCleanupDelay);

        /**
         * @return  this
         */
        ModifiableDurabilityServiceQosPolicy setServiceCleanupDelay(long serviceCleanupDelay, TimeUnit unit);

        /**
         * @param historyKind the historyKind to set
         * 
         * @return  this
         */
        ModifiableDurabilityServiceQosPolicy setHistoryKind(HistoryQosPolicyKind historyKind);

        /**
         * @param historyDepth the historyDepth to set
         * 
         * @return  this
         */
        ModifiableDurabilityServiceQosPolicy setHistoryDepth(int historyDepth);

        /**
         * @param maxSamples the maxSamples to set
         * 
         * @return  this
         */
        ModifiableDurabilityServiceQosPolicy setMaxSamples(int maxSamples);

        /**
         * @param maxInstances the maxInstances to set
         * 
         * @return  this
         */
        ModifiableDurabilityServiceQosPolicy setMaxInstances(int maxInstances);

        /**
         * @param maxSamplesPerInstance the maxSamplesPerInstance to set
         * 
         * @return  this
         */
        ModifiableDurabilityServiceQosPolicy setMaxSamplesPerInstance(int maxSamplesPerInstance);
    }
}