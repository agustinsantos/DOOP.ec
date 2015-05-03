using Doopec.Configuration.Rtps;
using Doopec.Rtps.Behavior;
using Doopec.Rtps.Structure;
using Rtps.Behavior;
using Rtps.Behavior.Types;
using Rtps.Discovery.Sedp;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Net;

namespace Doopec.Rtps.Discovery
{
    /// <summary>
    /// For each Participant, the SPDP creates two RTPS built-in Endpoints: the
    /// SPDPbuiltinParticipantWriter and the SPDPbuiltinParticipantReader.
    /// The SPDPbuiltinParticipantWriter is an RTPS Best-Effort StatelessWriter. The HistoryCache of the
    /// SPDPbuiltinParticipantWriter contains a single data-object of type SPDPdiscoveredParticipantData. 
    /// The Value of this data-object is Set from the attributes in the Participant. 
    /// If the attributes change, the data-object is replaced.
    /// </summary>
    public class SPDPbuiltinParticipantWriterImpl : RtpsStatelessWriter<SPDPdiscoveredParticipantData>
    {
        private WriterWorker worker;

        public SPDPbuiltinParticipantWriterImpl(Transport transportconfig, ParticipantImpl participant)
            : base(participant.Guid)
        {
            SetLocatorListFromConfig(transportconfig, participant);
            participant.DefaultMulticastLocatorList = this.MulticastLocatorList as List<Locator>;
            participant.DefaultUnicastLocatorList = this.UnicastLocatorList as List<Locator>;
            SPDPdiscoveredParticipantData data = new SPDPdiscoveredParticipantData(participant);
            // TODO Assign UserData from configuration
            CacheChange<SPDPdiscoveredParticipantData> change = this.NewChange(ChangeKind.ALIVE, new Data(data), null);
            this.HistoryCache.AddChange(change);

            this.TopicKind = TopicKind.WITH_KEY;
            this.ReliabilityLevel = ReliabilityKind.BEST_EFFORT;
            this.ResendDataPeriod = new Duration(transportconfig.Discovery.ResendPeriod.Val);
            this.heartbeatPeriod = new Duration(transportconfig.RtpsWriter.HeartbeatPeriod.Val);

            //The following timing-related values are used as the defaults in order to facilitate 
            // ‘out-of-the-box’ interoperability between implementations.
            this.nackResponseDelay = new Duration(transportconfig.RtpsWriter.NackResponseDelay.Val); //200 milliseconds
            this.nackSuppressionDuration = new Duration(transportconfig.RtpsWriter.NackSuppressionDuration.Val);
            this.pushMode = transportconfig.RtpsWriter.PushMode.Val;

            InitTransmitters();
            foreach (var trans in this.UDPTransmitters)
            {
                trans.IsDiscovery = true;
            }

            worker = new WriterWorker(this.PeriodicWork);
        }

        public void Start()
        {
            StartTransmitters();
            worker.Start((int)this.ResendDataPeriod.AsMillis());
        }

        /// <summary>
        /// The SPDPbuiltinParticipantWriter periodically sends this data-object to a pre-configured list of
        /// locators to announce the Participant’s presence on the network. This is achieved by periodically 
        /// calling StatelessWriter::unsent_changes_reset, which causes the StatelessWriter to resend all 
        /// changes present in its HistoryCache to all locators. The periodic rate at which the
        /// SPDPbuiltinParticipantWriter sends out the SPDPdiscoveredParticipantData defaults to a PSM specified
        /// Value. This period should be smaller than the leaseDuration specified in the SPDPdiscoveredParticipantData
        /// </summary>
        protected override void PeriodicWork()
        {
            foreach (var change in HistoryCache.Changes)
            {
                SendData(change);
            }
            this.UnsentChangesReset();
        }

        protected void SetLocatorListFromConfig(Transport transport, ParticipantImpl participant)
        {
            IList<Locator> unicastLocatorList = new List<Locator>();
            IList<Locator> multicastLocatorList = new List<Locator>();

            int PB = transport.Discovery.PortBase.Val;
            int DG = transport.Discovery.DomainGain.Val;
            int PG = transport.Discovery.ParticipantGain.Val;
            int d0 = transport.Discovery.OffsetMulticast.Val;
            int d1 = transport.Discovery.OffsetUnicast.Val;

            string[] unicastStr = transport.Discovery.UnicastLocatorList.Val.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
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

            string[] multicastStr = transport.Discovery.MulticastLocatorList.Val.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
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
