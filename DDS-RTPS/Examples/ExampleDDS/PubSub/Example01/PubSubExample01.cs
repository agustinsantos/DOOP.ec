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

namespace ExampleDDS.PubSubExamples
{
    class PubSubExample01 : ExampleApp
    {
        public override void RunExample(string[] args)
        {
            base.RunExample(args);

            DomainParticipantFactory factory = DomainParticipantFactory.getInstance(Bootstrap.CreateInstance());
            DomainParticipant dp = factory.createParticipant();

            // Implicitly create TypeSupport and register type:
            Topic<Greeting> tp = dp.createTopic<Greeting>("Greetings Topic");

            // Create the publisher
            Publisher pub = dp.createPublisher();
            DataWriter<Greeting> dw = pub.createDataWriter(tp);

            // Create the subscriber
            Subscriber sub = dp.createSubscriber();
            DataReaderListener<Greeting> ls = new MyListener();
            DataReader<Greeting> dr = sub.createDataReader<Greeting>(tp,
                                                                    sub.getDefaultDataReaderQos(),
                                                                    ls,
                                                                    null /* all status changes */);

            // Now Publish some piece of data
            Greeting data = new Greeting("Hello, World with DDS");
            log.InfoFormat("Sending data:\"{0}\"", data.Value);
            dw.write(data);

            //and check that the reader has this data
            dr.waitForHistoricalData(10, TimeUnit.SECONDS);

            dp.Close();
        }

        private class MyListener : DataReaderAdapter<Greeting>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            public override void onDataAvailable(DataAvailableStatus<Greeting> status)
            {
                DataReader<Greeting> dr = status.getSource();
                SampleIterator<Greeting> it = dr.take();
                foreach (Sample<Greeting> smp in it)
                {
                    // SampleInfo stuff is built into Sample:
                    // InstanceHandle inst = smp.getInstanceHandle();
                    // Data accessible from Sample; null if invalid:
                    Greeting dt = smp.getData();
                    log.InfoFormat("Received data:\"{0}\"", dt.Value);
                }
            }
        }
    }
}
