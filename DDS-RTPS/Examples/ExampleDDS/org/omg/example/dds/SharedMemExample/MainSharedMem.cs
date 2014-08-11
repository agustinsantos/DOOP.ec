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

namespace org.omg.example.dds.helloworld
{
    class MainSharedMem : ExampleApp
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
            dw.write(new Greeting("Hello, World"));

            //and check that the reader has this data
            dr.waitForHistoricalData(10, TimeUnit.SECONDS);

            dp.Close();
        }

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
