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


using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;
using System;

namespace org.omg.example.dds.helloworld
{

    public sealed class QosExample
    {
        public static void RunExample(string[] args)
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipant dp = factory.CreateParticipant();

            // Get unmodifiable QoS for inspection:
            DomainParticipantQos dpqUnmod = dp.GetQos();
            EntityFactoryQosPolicy polUnmod = dpqUnmod.GetEntityFactory();
            Console.WriteLine(polUnmod);
            // Set QoS:
            ModifiableDomainParticipantQos dpqMod = dpqUnmod.Modify();
            ModifiableEntityFactoryQosPolicy polMod = (ModifiableEntityFactoryQosPolicy)dpqMod.GetEntityFactory();
            polMod.SetAutoEnableCreatedEntities(false);
            dp.SetQos(dpqMod);

            // Concise version:
            dpqMod = dp.GetQos().Modify();
            ModifiableEntityFactoryQosPolicy polMod2 = (ModifiableEntityFactoryQosPolicy)dpqMod.GetEntityFactory();
            polMod2.SetAutoEnableCreatedEntities(false);
            dp.SetQos(dpqMod);
            // Restore QoS to default:
            dp.SetQos(factory.GetDefaultParticipantQos());
        }


        private QosExample()
        {
            // do nothing
        }
    }
}