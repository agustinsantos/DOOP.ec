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

        [ConfigurationProperty("portBase", DefaultValue = "7400")]
        public int PortBase
        {
            get { return (int)this["portBase"]; }
            set { this["portBase"] = value; }
        }

        [ConfigurationProperty("domainIdGain", DefaultValue = "250")]
        public int DomainIdGain
        {
            get { return (int)this["domainIdGain"]; }
            set { this["domainIdGain"] = value; }
        }

        [ConfigurationProperty("participantIdGain", DefaultValue = "2")]
        public int ParticipantIdGain
        {
            get { return (int)this["participantIdGain"]; }
            set { this["participantIdGain"] = value; }
        }

        [ConfigurationProperty("offsetd0", DefaultValue = "0")]
        public int Offsetd0
        {
            get { return (int)this["offsetd0"]; }
            set { this["offsetd0"] = value; }
        }

        [ConfigurationProperty("offsetd1", DefaultValue = "10")]
        public int Offsetd1
        {
            get { return (int)this["offsetd1"]; }
            set { this["offsetd1"] = value; }
        }

        [ConfigurationProperty("offsetd2", DefaultValue = "1")]
        public int Offsetd2
        {
            get { return (int)this["offsetd2"]; }
            set { this["offsetd2"] = value; }
        }

        [ConfigurationProperty("offsetd3", DefaultValue = "1")]
        public int Offsetd3
        {
            get { return (int)this["offsetd3"]; }
            set { this["offsetd3"] = value; }
        }
    }
}
