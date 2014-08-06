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

namespace org.omg.dds.pub
{

    public interface DataWriter<TYPE> : DomainEntity<DataWriter<TYPE>,
                                                     Publisher,
                                                     DataWriterListener<TYPE>,
                                                     DataWriterQos>
    {
        /**
         * @return  the type parameter if this object's class.
         */
        System.Type getType();

        /**
         * Cast this data writer to the given type, or throw an exception if
         * the cast fails.
         * 
         * @param <OTHER>   The type of the data published by this writer,
         *                  according to the caller.
         * @return          this data writer
         * @throws          ClassCastException if the cast fails
         */
        DataWriter<OTHER> cast<OTHER>();

        Topic<TYPE> getTopic();

        void waitForAcknowledgments(Duration maxWait);

        void waitForAcknowledgments(long maxWait, TimeUnit unit);

        LivelinessLostStatus<TYPE> getLivelinessLostStatus(LivelinessLostStatus<TYPE> status);

        OfferedDeadlineMissedStatus<TYPE> getOfferedDeadlineMissedStatus(OfferedDeadlineMissedStatus<TYPE> status);

        OfferedIncompatibleQosStatus<TYPE> getOfferedIncompatibleQosStatus(OfferedIncompatibleQosStatus<TYPE> status);

        PublicationMatchedStatus<TYPE> getPublicationMatchedStatus(PublicationMatchedStatus<TYPE> status);

        void assertLiveliness();

        ICollection<InstanceHandle> getMatchedSubscriptions(ICollection<InstanceHandle> subscriptionHandles);
        SubscriptionBuiltinTopicData getMatchedSubscriptionData(SubscriptionBuiltinTopicData subscriptionData,
               InstanceHandle subscriptionHandle);


        // --- Type-specific interface: ------------------------------------------
        InstanceHandle registerInstance(TYPE instanceData);
        InstanceHandle registerInstance(TYPE instanceData,
               Time sourceTimestamp);
        InstanceHandle registerInstance(TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);

        void unregisterInstance(InstanceHandle handle);
        void unregisterInstance(InstanceHandle handle,
               TYPE instanceData);
        void unregisterInstance(InstanceHandle handle,
               TYPE instanceData,
               Time sourceTimestamp);
        void unregisterInstance(InstanceHandle handle,
               TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);

        void write(TYPE instanceData);
        void write(TYPE instanceData,
               Time sourceTimestamp);
        void write(TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);
        void write(TYPE instanceData,
               InstanceHandle handle);
        void write(TYPE instanceData,
               InstanceHandle handle,
               Time sourceTimestamp);
        void write(TYPE instanceData,
               InstanceHandle handle,
               long sourceTimestamp,
               TimeUnit unit);

        void dispose(InstanceHandle instanceHandle);
        void dispose(InstanceHandle instanceHandle,
               TYPE instanceData);
        void dispose(InstanceHandle instanceHandle,
               TYPE instanceData,
               Time sourceTimestamp);
        void dispose(InstanceHandle instanceHandle,
               TYPE instanceData,
               long sourceTimestamp,
               TimeUnit unit);

        TYPE getKeyValue(TYPE keyHolder,
               InstanceHandle handle);

        ModifiableInstanceHandle lookupInstance(ModifiableInstanceHandle handle,
               TYPE keyHolder);
    }
}