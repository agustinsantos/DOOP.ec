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


using System.Collections.Generic;
using org.omg.dds.core.policy;
using org.omg.dds.type;
using System;

namespace org.omg.dds.core
{
    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    public interface EntityQos : Value, IDictionary<QosPolicyId, QosPolicy>
    {
    }


    
    /// <summary>
    /// A base interface for all entity QoS types.
    /// </summary>
    /// <typeparam name="UNMOD_SELF"></typeparam>
    /// <typeparam name="MOD_SELF"></typeparam>
    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    public interface EntityQos<UNMOD_SELF, MOD_SELF> : EntityQos,
                                                        Value<UNMOD_SELF, MOD_SELF>,
                                                        IDictionary<QosPolicyId, QosPolicy>
        where UNMOD_SELF : EntityQos<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="POLICY"></typeparam>
        /// <param name="id"></param>
        /// <returns>a reference to the corresponding policy in this
        ///          <code>EntityQos</code>. The returned object is not a copy; changes
        ///          to the returned object will be reflected in subsequent
        ///          accesses.
        /// </returns>
        POLICY Get<POLICY>(QosPolicyId id) where POLICY : QosPolicy;

        /// <summary>
        ///  @throws  UnsupportedOperationException   if this <code>EntityQos</code> is
        ///  not a <code>ModifiableEntityQos</code>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        QosPolicy Put(QosPolicyId key, QosPolicy value);

        /// <summary>
        /// @throws  UnsupportedOperationException   always: the <tt>remove</tt>
        /// operation is not supported by this map.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        QosPolicy Remove(Object key);

        /// <summary>
        /// @throws  UnsupportedOperationException   always: the <tt>clear</tt>
        /// operation is not supported by this map.
        /// </summary>
        void Clear();

    }
}