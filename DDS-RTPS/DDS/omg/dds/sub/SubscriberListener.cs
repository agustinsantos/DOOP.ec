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
 * See the License for the specific Language governing permissions and
 * limitations under the License.
 */


using DDS.ConversionUtils;
using org.omg.dds.core.status;

namespace org.omg.dds.sub
{

    public interface SubscriberListener : EventListener
    {
        void OnRequestedDeadlineMissed<TYPE>(RequestedDeadlineMissedStatus<TYPE> status);

        void OnRequestedIncompatibleQos<TYPE>(RequestedIncompatibleQosStatus<TYPE> status);

        void OnSampleRejected<TYPE>(SampleRejectedStatus<TYPE> status);

        void OnLivelinessChanged<TYPE>(LivelinessChangedStatus<TYPE> status);

        void OnDataAvailable<TYPE>(DataAvailableStatus<TYPE> status);

        void OnSubscriptionMatched<TYPE>(SubscriptionMatchedStatus<TYPE> status);

        void OnSampleLost<TYPE>(SampleLostStatus<TYPE> status);

        void OnDataOnReaders(DataOnReadersStatus status);
    }
}