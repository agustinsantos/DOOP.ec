using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.Config
{
    public class WellKnownPortsConfig : ConfigurationElement
    {
        private WellKnownPortsConfig() { }

        /// <summary>
        /// Port Base number. This number sets the starting
        /// point for deriving port numbers used for Simple
        /// Endpoint Discovery Protocol (SEDP). This property
        /// is used in conjunction with DG, PG, D0 (or DX), and D1
        /// to construct the necessary Endpoints for RTPS
        /// discovery communication. (see section 9.6.1.1 in the
        /// OMG DDS-RTPS specification in how these
        /// Endpoints are constructed)
        /// </summary>
        [ConfigurationProperty("portBase", DefaultValue = "7400", IsRequired = true)]
        public int PortBase
        {
            get { return (int)this["portBase"]; }
            set { this["portBase"] = value; }
        }

        /// <summary>
        /// An integer Value representing the Domain Gain. This
        /// is a multiplier that assists in formulating Multicast
        /// or Unicast ports for RTPS.
        /// </summary>
        [ConfigurationProperty("domainIdGain", DefaultValue = "250", IsRequired = true)]
        public int DomainIdGain
        {
            get { return (int)this["domainIdGain"]; }
            set { this["domainIdGain"] = value; }
        }

        /// <summary>
        /// An integer that assists in configuring SPDP Unicast
        /// ports and serves as an offset multiplier as
        /// participants are assigned addresses using the
        /// formula:
        /// PB + DG * domainId + d1 + PG * participantId
        /// (see section 9.6.1.1 in the OMG DDS-RTPS
        /// specification in how these Endpoints are
        /// constructed)
        /// </summary>
        [ConfigurationProperty("participantIdGain", DefaultValue = "2", IsRequired = true)]
        public int ParticipantIdGain
        {
            get { return (int)this["participantIdGain"]; }
            set { this["participantIdGain"] = value; }
        }

        /// <summary>
        /// An integer Value that assists in providing an offset
        /// for calculating an assignable port in SPDP Multicast
        /// configurations. The formula used is:
        /// PB + DG * domainId + d0 
        /// (see section 9.6.1.1 in the OMG DDS-RTPS
        /// specification in how these Endpoints are
        /// constructed)
        /// </summary>
        [ConfigurationProperty("offsetd0", DefaultValue = "0", IsRequired = true)]
        public int Offsetd0
        {
            get { return (int)this["offsetd0"]; }
            set { this["offsetd0"] = value; }
        }

        /// <summary>
        /// An integer Value that assists in providing an offset
        /// for calculating an assignable port in SPDP Unicast
        /// configurations. The formula used is:
        /// PB + DG * domainId + d1 + PG * participantId
        /// (see section 9.6.1.1 in the OMG DDS-RTPS
        /// specification in how these Endpoints are
        /// constructed)
        /// </summary>
        [ConfigurationProperty("offsetd1", DefaultValue = "10", IsRequired = true)]
        public int Offsetd1
        {
            get { return (int)this["offsetd1"]; }
            set { this["offsetd1"] = value; }
        }

        [ConfigurationProperty("offsetd2", DefaultValue = "1", IsRequired = true)]
        public int Offsetd2
        {
            get { return (int)this["offsetd2"]; }
            set { this["offsetd2"] = value; }
        }

        [ConfigurationProperty("offsetd3", DefaultValue = "11", IsRequired = true)]
        public int Offsetd3
        {
            get { return (int)this["offsetd3"]; }
            set { this["offsetd3"] = value; }
        }
    }
}
