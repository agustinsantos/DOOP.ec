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

namespace org.omg.dds.sub
{

    public class DataReaderAdapter<TYPE> : DataReaderListener<TYPE>
    {
        public virtual void OnDataAvailable(DataAvailableStatus<TYPE> status)
        {
            // empty
        }

        public virtual void OnLivelinessChanged(LivelinessChangedStatus<TYPE> status)
        {
            // empty
        }

        public virtual void OnRequestedDeadlineMissed(RequestedDeadlineMissedStatus<TYPE> status)
        {
            // empty
        }

        public virtual void OnRequestedIncompatibleQos(RequestedIncompatibleQosStatus<TYPE> status)
        {
            // empty
        }

        public virtual void OnSampleLost(SampleLostStatus<TYPE> status)
        {
            // empty
        }

        public virtual void OnSampleRejected(SampleRejectedStatus<TYPE> status)
        {
            // empty
        }

        public virtual void OnSubscriptionMatched(SubscriptionMatchedStatus<TYPE> status)
        {
            // empty
        }
    }
}