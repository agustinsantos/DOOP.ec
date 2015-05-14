﻿using DDS.ConversionUtils;
using log4net;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.sub.modifiable;
using org.omg.dds.topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    public class ChatMessage
    {
        private readonly string value;

        public ChatMessage(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            return this.value;
        }
    }

    class MainChat
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected static int domainId = -1;

        static void Main(string[] args)
        {
#if DEBUG
            LogAssemblyInfo();
#endif

            while (domainId < 0)
            {
                Console.WriteLine("Enter the domain participant id, It should be a positive number >= 0.");
                string id = Console.ReadLine();
                int.TryParse(id, out domainId);
            }

            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipant dp = factory.CreateParticipant(domainId);
            Console.WriteLine("Domain ID = {0} has been created", domainId);
            // Implicitly create TypeSupport and register type:
            Topic<ChatMessage> tp = dp.CreateTopic<ChatMessage>("Greetings Topic");
            // Create the subscriber
            // Create the subscriber
            Subscriber sub = dp.CreateSubscriber();
            DataReaderListener<ChatMessage> ls = new MyListener();

            DataReader<ChatMessage> dr = sub.CreateDataReader<ChatMessage>(tp,
                                                                            sub.GetDefaultDataReaderQos(),
                                                                            ls,
                                                                            null );



            
            // Create the publisher
            Publisher pub = dp.CreatePublisher();
            DataWriter<ChatMessage> dw = pub.CreateDataWriter(tp);

            String msg = "Hello, World with DDS.";
            while (msg != "quit")
            {
                Console.Write(">");
                msg = Console.ReadLine();
                // Now Publish the message
                ChatMessage data = new ChatMessage(msg);
                Console.WriteLine("Sending data:\"{0}\"", data.Value);
                dw.Write(data);
                //and check that the reader has this data
            }
            dp.Close();
        }

        private class MyListener : DataReaderAdapter<ChatMessage>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            public override void OnDataAvailable(DataAvailableStatus<ChatMessage> status)
            {
                DataReader<ChatMessage> dr = status.GetSource();
                SampleIterator<ChatMessage> it = dr.Take();
                foreach (Sample<ChatMessage> smp in it)
                {
                    // SampleInfo stuff is built into Sample:
                    // InstanceHandle inst = smp.GetInstanceHandle();
                    // Data accessible from Sample; null if invalid:
                    ChatMessage dt = smp.GetData();
                    Console.WriteLine("Console {0}.- Received data:\"{1}\"", domainId, dt.Value);
                }
            }
        }


        private static void LogAssemblyInfo()
        {
            AssemblyName mainAn = Assembly.GetExecutingAssembly().GetName();
            log.InfoFormat("This program is Name={0}, Version={1}, Culture={2}, PublicKey token={3}",
                        mainAn.Name, mainAn.Version, mainAn.CultureInfo.Name, (BitConverter.ToString(mainAn.GetPublicKeyToken())));
            log.Info("Referenced assemblies:");
            foreach (AssemblyName an in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                string name = an.Name.ToLowerInvariant();
                if (name == "log4net" || name.Contains("doopec") || name.Contains("dds") || name.Contains("rtps"))
                    log.InfoFormat("Name={0}, Version={1}, Culture={2}, PublicKey token={3}",
                        an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString(an.GetPublicKeyToken())));
            }
        }
    }
}
