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
using System;
using System.Reflection;
using System.Collections;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using Doopec.Dds.Core.Policy;
using org.omg.dds.pub.modifiable;

namespace ExampleDDS.PubSubExamples
{
    class PubSubExample03 : ExampleApp
    {
        public override void RunExample(string[] args)
        {
            base.RunExample(args);
            Bootstrap boostrap = Bootstrap.CreateInstance();
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(boostrap);
            DomainParticipant dp = factory.CreateParticipant();

            // Implicitly create TypeSupport and register type:
            Topic<Greeting> tp = dp.CreateTopic<Greeting>("Greetings Topic");

            // Create the publisher
            Publisher pub = dp.CreatePublisher();

            ModifiableDataWriterQos qosDW = pub.GetDefaultDataWriterQos().Modify();
            ModifiableReliabilityQosPolicy dpqMod = qosDW.GetReliability().Modify();
            dpqMod.SetKind(ReliabilityQosPolicyKind.RELIABLE);
            qosDW.SetReliability(dpqMod);

            DataWriterListener<Greeting> lis = new MyListener1();
            DataWriter<Greeting> dw = pub.CreateDataWriter(tp, qosDW, lis, null);
            

            // Create the subscriber
            Subscriber sub = dp.CreateSubscriber();
            DataReaderListener<Greeting> ls = new MyListener();
            DataReader<Greeting> dr = sub.CreateDataReader<Greeting>(tp,
                                                                    sub.GetDefaultDataReaderQos(),
                                                                    ls, null /* all status changes */);

            // Now Publish some piece of data
            Greeting data = new Greeting("Hello, World with DDS");
            log.InfoFormat("Sending data:\"{0}\"", data.Value);
            dw.Write(data);

            //and check that the reader has this data
            dr.WaitForHistoricalData(10, TimeUnit.SECONDS);

            dp.Close();
        }

        private class MyListener : DataReaderAdapter<Greeting>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            public override void OnDataAvailable(DataAvailableStatus<Greeting> status)
            {
                DataReader<Greeting> dr = status.GetSource();
                SampleIterator<Greeting> it = dr.Take();
                foreach (Sample<Greeting> smp in it)
                {
                    // SampleInfo stuff is built into Sample:
                    // InstanceHandle inst = smp.GetInstanceHandle();
                    // Data accessible from Sample; null if invalid:
                    Greeting dt = smp.GetData();
                    log.InfoFormat("Received data:\"{0}\"", dt.Value);
                }
            }
        }

        private class MyListener1 : DataWriterAdapter <Greeting>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            /*public override void OnPublicationMatched(PublicationMatchedStatus<Greeting> status)
            {
                DataWriter<Greeting> dw = status.GetSource();
               /* SampleIterator<Greeting> it = dw.
                foreach (Sample<Greeting> smp in it)
                {
                    // SampleInfo stuff is built into Sample:
                    // InstanceHandle inst = smp.GetInstanceHandle();
                    // Data accessible from Sample; null if invalid:
                    Greeting dt = smp.GetData();
                    log.InfoFormat("Received data:\"{0}\"", dt.Value);
                }
            }*/
        }
        
    }
}
