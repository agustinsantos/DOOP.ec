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

using ExampleDDS.Common;
using org.omg.dds.core;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.topic;
using System;


namespace org.omg.example.dds.helloworld
{

    public class GreetingPublishingApp
    {
        public static void RunExample(string[] args)
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipant dp = factory.CreateParticipant();

            // Implicitly create TypeSupport and register type:
            Topic<Greeting> tp = dp.CreateTopic<Greeting>("My Topic");

            // OR explicitly create TypeSupport, registered with default name:
            // Topic<Greeting> tp = dp.CreateTopic(
            //         "My Topic",
            //         ctx.createTypeSupport(Greeting.class));
            // OR explicitly create TypeSupport, registered with custom name:
            // Topic<Greeting> tp = dp.CreateTopic(
            //         "My Topic",
            //         ctx.createTypeSupport(Greeting.class, "MyType"));

            Publisher pub = dp.CreatePublisher();
            DataWriter<Greeting> dw = pub.CreateDataWriter(tp);

            try
            {
                dw.Write(new Greeting("Hello, World"));
            }
            catch (Exception tx)
            {
                Console.WriteLine(tx);
            }

            dp.Close();
        }


        private GreetingPublishingApp()
        {
            // do nothing
        }
    }
}