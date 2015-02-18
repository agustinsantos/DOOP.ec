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
using org.omg.dds.core.status;
using org.omg.dds.topic;
using System.Collections.Generic;
using org.omg.dds.core.modifiable;
using System;

namespace org.omg.dds.pub
{

    public interface DataWriter<TYPE> : DomainEntity<DataWriter<TYPE>,
                                        Publisher,
                                        DataWriterListener<TYPE>,
                                        DataWriterQos>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The type parameter if this object's class.</returns>
        System.Type GetType();

        /// <summary>
        /// Cast this data writer to the given type, or throw an exception if
        /// the Cast fails.
        /// </summary>
        /// <typeparam name="OTHER">The type of the data published by this writer,
        ///                         according to the caller</typeparam>
        /// <returns>This data writer</returns>
        /// <exception cref="ClassCastException"></exception>
        DataWriter<OTHER> Cast<OTHER>();

        Topic<TYPE> GetTopic();

        void WaitForAcknowledgments(Duration maxWait);

        void WaitForAcknowledgments(long maxWait, TimeUnit unit);

        LivelinessLostStatus<TYPE> GetLivelinessLostStatus(LivelinessLostStatus<TYPE> status);

        OfferedDeadlineMissedStatus<TYPE> GetOfferedDeadlineMissedStatus(OfferedDeadlineMissedStatus<TYPE> status);

        OfferedIncompatibleQosStatus<TYPE> GetOfferedIncompatibleQosStatus(OfferedIncompatibleQosStatus<TYPE> status);

        PublicationMatchedStatus<TYPE> GetPublicationMatchedStatus(PublicationMatchedStatus<TYPE> status);

        void AssertLiveliness();

        ICollection<InstanceHandle> GetMatchedSubscriptions(ICollection<InstanceHandle> subscriptionHandles);
        SubscriptionBuiltinTopicData GetMatchedSubscriptionData(SubscriptionBuiltinTopicData subscriptionData,
               InstanceHandle subscriptionHandle);


        // --- Type-specific interface: ------------------------------------------
        InstanceHandle RegisterInstance(TYPE instanceData);
        InstanceHandle RegisterInstance(TYPE instanceData,
               Time sourceTimestamp);
        InstanceHandle RegisterInstance(TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);

        void UnregisterInstance(InstanceHandle handle);
        void UnregisterInstance(InstanceHandle handle,
               TYPE instanceData);
        void UnregisterInstance(InstanceHandle handle,
               TYPE instanceData,
               Time sourceTimestamp);
        void UnregisterInstance(InstanceHandle handle,
               TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);

        void Write(TYPE instanceData);
        void Write(TYPE instanceData,
               Time sourceTimestamp);
        void Write(TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);
        void Write(TYPE instanceData,
               InstanceHandle handle);
        void Write(TYPE instanceData,
               InstanceHandle handle,
               Time sourceTimestamp);
        void Write(TYPE instanceData,
               InstanceHandle handle,
               long sourceTimestamp,
               TimeUnit unit);

        void Dispose(InstanceHandle instanceHandle);
        void Dispose(InstanceHandle instanceHandle,
               TYPE instanceData);
        void Dispose(InstanceHandle instanceHandle,
               TYPE instanceData,
               Time sourceTimestamp);
        void Dispose(InstanceHandle instanceHandle,
               TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);

        TYPE GetKeyValue(TYPE keyHolder,
               InstanceHandle handle);

        ModifiableInstanceHandle LookupInstance(ModifiableInstanceHandle handle,
               TYPE keyHolder);
    }
}