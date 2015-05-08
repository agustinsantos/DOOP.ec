using Doopec.Configuration;
using Doopec.Configuration.Rtps;
using Doopec.Rtps.Behavior;
using Doopec.Rtps.Structure;
using Rtps.Behavior.Types;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Net;

namespace Doopec.Rtps.Discovery
{
    public class SPDPbuiltinParticipantReaderImpl : RtpsStatelessReader<SPDPdiscoveredParticipantData>
    {
        public SPDPbuiltinParticipantReaderImpl(Transport transportconfig, ParticipantImpl participant)
            : base(participant.Guid)
        {
            this.TopicKind = TopicKind.WITH_KEY;
            this.ReliabilityLevel = ReliabilityKind.BEST_EFFORT;
            this.ExpectsInlineQos = false;
            //The following timing-related values are used as the defaults in order to facilitate 
            // ‘out-of-the-box’ interoperability between implementations.
            this.HeartbeatResponseDelay = new Duration(transportconfig.RtpsReader.HeartbeatResponseDelay.Val); // default is 500 milliseconds
            this.HeartbeatSuppressionDuration = new Duration(transportconfig.RtpsReader.HeartbeatSuppressionDuration.Val);// default is 0 milliseconds


            SetLocatorListFromConfig(transportconfig, participant);
            InitReceivers();
            foreach (var rec in this.UDPReceivers)
            {
                rec.IsDiscovery = true;
            }
        }

        public void Start()
        {
            StartReceivers();
        }

        protected void SetLocatorListFromConfig(Transport transport, ParticipantImpl participant)
        {
            IList<Locator> unicastLocatorList = new List<Locator>();
            IList<Locator> multicastLocatorList = new List<Locator>();

            int PB = transport.Discovery.PortBase.Val;
            int DG = transport.Discovery.DomainGain.Val;
            int PG = transport.Discovery.ParticipantGain.Val;
            int d0 = transport.Discovery.OffsetMetatrafficMulticast.Val;
            int d1 = transport.Discovery.OffsetMetatrafficUnicast.Val;

            string[] unicastStr = transport.Discovery.MetatrafficUnicastLocatorList.Val.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string addr in unicastStr)
            {
                string[] parts = addr.Split(':');
                IPAddress[] addresses = System.Net.Dns.GetHostAddresses(parts[0]);
                IPAddress ipaddr = null;
                if (addresses != null)
                {
                    foreach (var ipa in addresses)
                        if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipaddr = ipa;
                            break;
                        }
                }
                else
                    throw new ArgumentException("Invalid unicast address " + parts[0]);

                int port;
                if (parts.Length <= 1)
                {
                    port = PB + DG * participant.DomainId + d1 + PG * participant.ParticipantId;
                }
                else
                    port = int.Parse(parts[1]);

                if (ipaddr != null)
                {
                    Locator locator = new Locator(ipaddr, port);
                    log.DebugFormat("Using unicast Addr:{0} and Port:{0} for SPDP Discovery", ipaddr, port);
                    unicastLocatorList.Add(locator);
                }
            }

            string[] multicastStr = transport.Discovery.MetatrafficMulticastLocatorList.Val.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string addr in multicastStr)
            {
                string[] parts = addr.Split(':');
                IPAddress[] addresses = System.Net.Dns.GetHostAddresses(parts[0]);
                IPAddress ipaddr = null;
                if (addresses != null)
                {
                    foreach (var ipa in addresses)
                        if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipaddr = ipa;
                            break;
                        }
                }
                else
                    throw new ArgumentException("Invalid multicast address " + parts[0]);

                int port;
                if (parts.Length <= 1)
                {
                    port = PB + DG * participant.DomainId + d0;
                }
                else
                    port = int.Parse(parts[1]);
                if (ipaddr != null)
                {
                    Locator locator = new Locator(ipaddr, port);
                    log.DebugFormat("Using multicast Addr:{0} and Port:{0} for SPDP Discovery", ipaddr, port);
                    multicastLocatorList.Add(locator);
                }
            }

            this.UnicastLocatorList = unicastLocatorList;
            this.MulticastLocatorList = multicastLocatorList;
        }
    }
}
