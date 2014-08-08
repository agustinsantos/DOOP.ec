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
using org.omg.dds.domain;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System;

namespace org.omg.example.dds.helloworld
{

    public class GreetingSubscribingApp
    {
        public static void RunExample(string[] args)
        {
            Bootstrap bstp = Bootstrap.CreateInstance();
            DomainParticipant dp = DomainParticipantFactory.getInstance(bstp).createParticipant();

            // Implicitly create TypeSupport and register type:
            Topic<Greeting> tp = dp.createTopic<Greeting>("My Topic");

            // OR explicitly create TypeSupport, registered with default name:
            // Topic<Greeting> tp = dp.createTopic(
            //         "My Topic",
            //         ctx.createTypeSupport(Greeting.class));
            // OR explicitly create TypeSupport, registered with custom name:
            // Topic<Greeting> tp = dp.createTopic(
            //         "My Topic",
            //         ctx.createTypeSupport(Greeting.class, "MyType"));

            Subscriber sub = dp.createSubscriber();
            DataReaderListener<Greeting> ls = new MyListener();
            DataReader<Greeting> dr = sub.createDataReader<Greeting>(tp,
                                                            sub.getDefaultDataReaderQos(),
                                                            ls,
                                                            null /* all status changes */);

            try
            {
                dr.waitForHistoricalData(10, TimeUnit.SECONDS);
            }
            catch (Exception tx)
            {
                Console.WriteLine(tx);
            }

            dp.Close();
        }


        private GreetingSubscribingApp()
        {
            // do nothing
        }



        // -----------------------------------------------------------------------
        // Types
        // -----------------------------------------------------------------------

        private class MyListener : DataReaderAdapter<Greeting>
        {
            public override void onDataAvailable(DataAvailableStatus<Greeting> status)
            {
                DataReader<Greeting> dr = status.getSource();
                SampleIterator<Greeting> it = dr.take();
                foreach (Sample<Greeting> smp in it)
                {
                    // SampleInfo stuff is built into Sample:
                    InstanceHandle inst = smp.getInstanceHandle();
                    // Data accessible from Sample; null if invalid:
                    Greeting dt = smp.getData();
                    // ...
                }
            }
        }
    }
}