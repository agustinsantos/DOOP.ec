using DDS.ConversionUtils;
using Doopec.Rtps;
using ExampleDDS.Common;
using log4net;
using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using Rtps.Discovery.Spdp;
using System;
using System.Reflection;
using System.Threading;

namespace ExampleDDS.DiscoveryExamples
{
    class DiscoveryExample01 : ExampleApp
    {
        public override void RunExample(string[] args)
        {
            base.RunExample(args);

            DomainParticipantFactory factory = DomainParticipantFactory.getInstance(Bootstrap.CreateInstance());
            DomainParticipant dp = factory.createParticipant();


            // At this point the Simple Participant Discovery protocol should be running.

           // // Implicitly create TypeSupport and register type:
           // Topic<SPDPdiscoveredParticipantData> tp = dp.CreateTopic<SPDPdiscoveredParticipantData>("DCPSParticipant");

           // // Create the publisher
           // Publisher pub = dp.CreatePublisher();
           // DataWriter<SPDPdiscoveredParticipantData> dw = pub.createDataWriter(tp);
           //// dw.write(data);

            Thread.Sleep(100*1000);
            dp.Close();
        }
    }
}
