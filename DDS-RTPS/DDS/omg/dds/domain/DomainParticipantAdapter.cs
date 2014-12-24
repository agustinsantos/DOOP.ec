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


using org.omg.dds.core.status;


namespace org.omg.dds.domain
{

    public class DomainParticipantAdapter : DomainParticipantListener
    {
        public void OnInconsistentTopic<TYPE>(InconsistentTopicStatus<TYPE> status)
        {
            // empty
        }

        public void OnLivelinessLost<TYPE>(LivelinessLostStatus<TYPE> status)
        {
            // empty
        }

        public void OnOfferedDeadlineMissed<TYPE>(OfferedDeadlineMissedStatus<TYPE> status)
        {
            // empty
        }

        public void OnOfferedIncompatibleQos<TYPE>(OfferedIncompatibleQosStatus<TYPE> status)
        {
            // empty
        }

        public void OnPublicationMatched<TYPE>(PublicationMatchedStatus<TYPE> status)
        {
            // empty
        }

        public void OnDataOnReaders(DataOnReadersStatus status)
        {
            // empty
        }

        public void OnDataAvailable<TYPE>(DataAvailableStatus<TYPE> status)
        {
            // empty
        }

        public void OnLivelinessChanged<TYPE>(LivelinessChangedStatus<TYPE> status)
        {
            // empty
        }

        public void OnRequestedDeadlineMissed<TYPE>(RequestedDeadlineMissedStatus<TYPE> status)
        {
            // empty
        }

        public void OnRequestedIncompatibleQos<TYPE>(RequestedIncompatibleQosStatus<TYPE> status)
        {
            // empty
        }

        public void OnSampleLost<TYPE>(SampleLostStatus<TYPE> status)
        {
            // empty
        }

        public void OnSampleRejected<TYPE>(SampleRejectedStatus<TYPE> status)
        {
            // empty
        }

        public void OnSubscriptionMatched<TYPE>(SubscriptionMatchedStatus<TYPE> status)
        {
            // empty
        }
    }
}