using DDS.ConversionUtils;
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
    /// <summary>
    /// Class to create an object that will be used as a message to be sent using the Publisher
    /// </summary>
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
    /// <summary>
    ///  Main class that contains all the details of sending and receiving messages
    /// </summary>
    class MainChat
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected static int domainId = -1;
        /// <summary>
        /// Method running to launch the application
        /// </summary>
        /// <param name="args"></param>
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
            // Create the DomainFactory
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            // Create the DomainParticipant with reference to the configuration file with the domain ID
            DomainParticipant dp = factory.CreateParticipant(domainId);
            Console.WriteLine("Domain ID = {0} has been created", domainId);
            // Implicitly create TypeSupport and register type:
            Topic<ChatMessage> tp = dp.CreateTopic<ChatMessage>("Greetings Topic");
            // Create the subscriber
            Subscriber sub = dp.CreateSubscriber();
            // Create a Listener for the publishing data
            DataReaderListener<ChatMessage> ls = new MyListener();
            // Create the DataReader using the topic, politics of QoS for DataReader and implemented listener
            DataReader<ChatMessage> dr = sub.CreateDataReader<ChatMessage>(tp,
                                                                            sub.GetDefaultDataReaderQos(),
                                                                            ls,
                                                                            null );



            
            // Create the publisher
            Publisher pub = dp.CreatePublisher();
            // Create the DataWriter using the topic specified
            DataWriter<ChatMessage> dw = pub.CreateDataWriter(tp);
            // Create a message
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
        /// <summary>
        /// Class that inherits the type DataReaderAdapter and overrides the method OnDataAvaliable 
        /// to read the message publisher and present this in console
        /// </summary>
        private class MyListener : DataReaderAdapter<ChatMessage>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            /// <summary>
            /// Method is called when a new message arrives from the Publisher
            /// </summary>
            /// <param name="status">get data avaliable</param>
            public override void OnDataAvailable(DataAvailableStatus<ChatMessage> status)
            {
                // Obtain the source of DataReader 
                DataReader<ChatMessage> dr = status.GetSource();
                // Obtain the stack of messages published
                SampleIterator<ChatMessage> it = dr.Take();
                // Iterator of the list of messages, to present it in console
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

        /// <summary>
        /// Create a file .log to register all actions of the application
        /// </summary>
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
