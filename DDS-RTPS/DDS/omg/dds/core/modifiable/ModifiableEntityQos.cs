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
using org.omg.dds.core.policy;

namespace org.omg.dds.core.modifiable
{


    public interface ModifiableEntityQos<UNMOD_SELF, MOD_SELF>
     : EntityQos<UNMOD_SELF, MOD_SELF>, ModifiableValue<UNMOD_SELF, MOD_SELF>
        where UNMOD_SELF : EntityQos<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
        /// <summary>
        /// Overwrite the Value of the indicated policy with the given new Value.
        /// Subsequent calls to {@link #Get(Object)} may return the given object
        /// or a copy of it.
        /// 
        /// @throws  NullPointerException    if the given key or Value is <code>null</code>.
        /// </summary>
        /// <typeparam name="POLICY"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>The previous Value of the indicated policy if that policy
        ///          applies to this <code>EntityQos</code>'s {@link Entity} or
        ///          <code>null</code> otherwise. If the returned object is not
        ///          <code>null</code>, changes to it will <em>not</em> be
        ///          reflected by subsequent calls to {@link #Get(Object)}.
        /// </returns>
        POLICY put<POLICY>(QosPolicyId key, POLICY value) where POLICY : QosPolicy;
    }
}