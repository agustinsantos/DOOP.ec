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

using org.omg.dds.type;

namespace org.omg.dds.core.policy
{

    /// <summary>
    /// This class is the abstract root for all the QoS policies. It provides the
    /// basic mechanism for an application to specify quality of service
    /// parameters. It has a name (<code>GetId().GetPolicyName()</code>) that is
    /// used to identify uniquely each QoS policy. All concrete QosPolicy classes
    /// derive from this root and include a Value whose type depends on the
    /// concrete QoS policy.
    /// 
    /// The type of a QosPolicy Value may be atomic, such as an integer or float,
    /// or compound (a structure). Compound types are used whenever multiple
    /// parameters must be Set coherently to define a consistent Value for a
    /// QosPolicy.
    /// 
    /// Each {@link Entity} can be configured with a collection of QosPolicy.
    /// However, any Entity cannot support any QosPolicy. For instance, a
    /// {@link DomainParticipant} supports different QosPolicy than a {@link Topic}
    /// or a {@link Publisher}.
    /// QosPolicy can be Set when the Entity is created, or modified with the
    /// {@link Entity#SetQos(org.omg.dds.core.EntityQos)} method. Each QosPolicy
    /// in collection list is treated independently from the others. This approach
    /// has the advantage of being very extensible. However, there may be cases
    /// where several policies are in conflict. Consistency checking is performed
    /// each time the policies are modified via the
    /// {@link Entity#SetQos(org.omg.dds.core.EntityQos) }operation.
    /// 
    /// When a policy is changed after being Set to a given Value, it is not
    /// required that the new Value be applied instantaneously; the Service is
    /// allowed to apply it after a transition phase. In addition, some QosPolicy
    /// have “immutable” semantics meaning that they can only be specified either
    /// at Entity creation time or else prior to calling the
    /// {@link Entity#Enable()} operation on the Entity.
    /// </summary>
    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface QosPolicy : Value
    {
        QosPolicyId GetId();
    }

    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface QosPolicy<UNMOD_SELF, MOD_SELF> : QosPolicy, Value<UNMOD_SELF, MOD_SELF>
        where UNMOD_SELF : QosPolicy<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
    }

    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public abstract class QosPolicyId
    {
        /// <summary>
        /// Get the QoS policy ID for the given QoS policy class.
        /// </summary>
        /// <param name="policyClass"></param>
        /// <param name="bootstrap">Identifies the Service instance to which the object will belong</param>
        /// <returns></returns>
        public static QosPolicyId GetId(System.Type policyClass, Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().GetQosPolicyId(policyClass);
        }

        // --- Instance Methods: ---------------------------------------------
        public abstract int GetPolicyIdValue();

        public abstract string GetPolicyName();
    }
}