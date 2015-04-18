using DDS.ConversionUtils;
using Doopec.Rtps;
using ExampleDDS.Common;
using log4net;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using org.omg.dds.topic.modifiable;
using System;
using System.Reflection;

namespace ExampleDDS.PubSubExamples
{
    class PubSubExample02 : ExampleApp
    {
        public const int MY_DOMAIN = 123;

        public override void RunExample(string[] args)
        {
            base.RunExample(args);

            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipant dp1 = factory.CreateParticipant();
            DomainParticipant dp = factory.CreateParticipant(MY_DOMAIN);

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

            dp.Close();
        }
    }
}
