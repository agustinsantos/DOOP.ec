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
    public interface ModifiablePresentationQosPolicy : PresentationQosPolicy,
            ModifiableQosPolicy<PresentationQosPolicy, ModifiablePresentationQosPolicy>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessScope">The accessScope to Set</param>
        /// <returns>this</returns>
        ModifiablePresentationQosPolicy SetAccessScope(AccessScopeKind accessScope);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coherentAccess">The coherentAccess to Set</param>
        /// <returns>this</returns>
        ModifiablePresentationQosPolicy SetCoherentAccess(bool coherentAccess);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderedAccess">The orderedAccess to Set</param>
        /// <returns>this</returns>
        ModifiablePresentationQosPolicy SetOrderedAccess(bool orderedAccess);
    }
}