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

            DomainParticipantFactory factory = DomainParticipantFactory.getInstance(Bootstrap.CreateInstance());
            DomainParticipant dp1 = factory.createParticipant();
            DomainParticipant dp = factory.createParticipant(MY_DOMAIN);

            // Get unmodifiable QoS for inspection:
            DomainParticipantQos dpqUnmod = dp.getQos();
            EntityFactoryQosPolicy polUnmod = dpqUnmod.getEntityFactory();
            Console.WriteLine(polUnmod);
            // Set QoS:
            ModifiableDomainParticipantQos dpqMod = dpqUnmod.modify();
            ModifiableEntityFactoryQosPolicy polMod = (ModifiableEntityFactoryQosPolicy)dpqMod.getEntityFactory();
            polMod.setAutoEnableCreatedEntities(false);
            dp.setQos(dpqMod);

            // Concise version:
            dpqMod = dp.getQos().modify();
            ModifiableEntityFactoryQosPolicy polMod2 = (ModifiableEntityFactoryQosPolicy)dpqMod.getEntityFactory();
            polMod2.setAutoEnableCreatedEntities(false);
            dp.setQos(dpqMod);
            // Restore QoS to default:
            dp.setQos(factory.getDefaultParticipantQos());

            dp.Close();
        }
    }
}
