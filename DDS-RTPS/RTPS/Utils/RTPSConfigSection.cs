using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils
{
    /// <summary>
    /// A configuration section class for RTPS.
    /// </summary>
    public class RTPSConfigSection : ConfigurationSection
    {

        #region Constructors
        static RTPSConfigSection()
        {

        }
        #endregion


        #region Properties

        // ---  RTPS specific tuning parameters  ----------
        [ConfigurationProperty("traffic.port-config", IsRequired = true)]
        public string TrafficPortConfig
        {
            get { return (string)base["traffic.port-config"]; }
        }
        [ConfigurationProperty("writer.push-mode", IsRequired = true)]
        public bool WriterPushMode
        {
            get { return (bool)base["writer.push-mode"]; }
        }
        [ConfigurationProperty("writer.heartbeat-period", IsRequired = true)]
        public int WriterHeartbeatPeriod
        {
            get { return (int)base["writer.heartbeat-period"]; }
        }

        // Delay before writer responds to NACK messages

        [ConfigurationProperty("writer.nack-response-delay", IsRequired = true)]
        public int WriterNackResponseDelay
        {
            get { return (int)base["writer.nack-response-delay"]; }
        }
        [ConfigurationProperty("writer.nack-suppression-duration", IsRequired = true)]
        public int WriterNackSuppressionDuration
        {
            get { return (int)base["writer.nack-suppression-duration"]; }
        }

        // Delay before reader responds to heartbeat messages
        [ConfigurationProperty("reader.heartbeat-response-delay", IsRequired = true)]
        public int ReaderHeartbeatResponseDelay
        {
            get { return (int)base["reader.heartbeat-response-delay"]; }
        }
        [ConfigurationProperty("reader.heartbeat-suppression-duration", IsRequired = true)]
        public int ReaderHeartbeatSuppressionDuration
        {
            get { return (int)base["reader.heartbeat-suppression-duration"]; }
        }

        /// <summary>
        /// Configure whether or not to prefer multicast. 
        /// </summary>
        [ConfigurationProperty("prefer-multicast")]
        public bool PreferMulticast
        {
            get { return (bool)base["prefer-multicast"]; }
        }


        /// <summary>
        /// A comma separated list of URIs, that will be used to start listeners for user traffic.
        /// If port number is omitted, it will be calculated using the algorithm specified 
        /// in RTPS spec (I.e. use PB,DG,PG,d0,d1,d2,d3) ch. 9.6.1.2.  
        /// Currently, udp is the only scheme that is supported
        /// </summary>
        [ConfigurationProperty("listener-uris", IsRequired = true)]
        public string ListenerUris
        {
            get { return (string)base["listener-uris"]; }
        }



        /// <summary>
        /// Gets the discovery.listener-uris setting.
        /// A comma separated list of URIs, that will be used to start listeners for discovery.
        /// If this config is omitted, discovery will use the same listeners as with user data.
        /// </summary>
        [ConfigurationProperty("discovery.listener-uris", IsRequired = true)]
        public string DiscoveryListenerUris
        {
            get { return (string)base["discovery.listener-uris"]; }
        }

        #endregion

        public void GetExampleSettings()
        {
            RTPSConfigSection section = ConfigurationManager.GetSection("RTPSConfig")
                                     as RTPSConfigSection;
            if (section != null)
            {
                string m_string = section.DiscoveryListenerUris;
            }
        }
#if TODO
//
// A Configuration file for jRTPS
//
// ---  RTPS specific tuning parameters  ----------
rtps.traffic.port-config = PB=7400, DG=250, PG=2, d0=0, d1=10, d2=1, d3=11

rtps.writer.push-mode = true
rtps.writer.heartbeat-period = 5000

// Delay before writer responds to NACK messages
rtps.writer.nack-response-delay = 200
rtps.writer.nack-suppression-duration = 0

// Delay before reader responds to heartbeat messages
rtps.reader.heartbeat-response-delay = 500
rtps.reader.heartbeat-suppression-duration = 0
//rtps.reader.expects-inline-qos = false	

// SPDP writers periodical announcement rate
rtps.spdp.resend-data-period = 30000


// ---  jRTPS tuning parameters  ------------------
// jRTPS uses ScheduledThreadPoolExecutor for its thread management. 
jrtps.thread-pool.core-size = 10

// Size of the input queue. UDP packets received are placed into this queue. 
jrtps.message-queue.size = 10

// Configure buffer-size. This is the buffer size used to hold a RTPS Message.
// For readers, this is the size of UDP Datagram buffer.
jrtps.buffer-size = 16384

// Configure whether or not to publish builtin data of builtin entities. 
// Defaults to false, since remote participant can determine this data
jrtps.publish-builtin-data = false

// Configure whether or not to prefer multicast. 
jrtps.prefer-multicast = true

// A comma separated list of URIs, that will be used to start listeners for user traffic.
// If port number is omitted, it will be calculated using the algorithm specified 
// in RTPS spec (I.e. use PB,DG,PG,d0,d1,d2,d3) ch. 9.6.1.2.  
// Currently, udp is the only scheme that is supported
jrtps.listener-uris=udp://239.255.0.1,udp://localhost

// A comma separated list of URIs, that will be used to start listeners for discovery.
// If this config is omitted, discovery will use the same listeners as with user data.
jrtps.discovery.listener-uris=udp://239.255.0.1,udp://localhost
#endif
    }
}
