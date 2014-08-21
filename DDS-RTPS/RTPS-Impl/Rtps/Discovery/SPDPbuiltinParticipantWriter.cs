using Doopec.Rtps.Behavior;
using Rtps.Behavior;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Net;

namespace Doopec.Rtps.Discovery
{
    /// <summary>
    /// For each Participant, the SPDP creates two RTPS built-in Endpoints: the SPDPbuiltinParticipantWriter and
    /// the SPDPbuiltinParticipantReader.
    /// The SPDPbuiltinParticipantWriter is an RTPS Best-Effort StatelessWriter. The HistoryCache of the
    /// SPDPbuiltinParticipantWriter contains a single data-object of type SPDPdiscoveredParticipantData. 
    /// The value of this data-object is set from the attributes in the Participant. If the attributes change,
    /// the data-object is replaced.
    /// </summary>
    public class SPDPbuiltinParticipantWriter : StatelessWriter<SPDPdiscoveredParticipantData>, IDisposable
    {
        private WriterWorker worker;

        public SPDPbuiltinParticipantWriter(Participant participant)
            : base(participant)
        {
            this.TopicKind = TopicKind.WITH_KEY;
            this.ReliabilityLevel = ReliabilityKind.BEST_EFFORT;

            SPDPdiscoveredParticipantData data = new SPDPdiscoveredParticipantData(participant);
            CacheChange<SPDPdiscoveredParticipantData> change = this.NewChange(ChangeKind.ALIVE, new Data(data), null);
            this.HistoryCache.AddChange(change);

            // this should be done by configuration
            ReaderLocator multicastLocator = new ReaderLocator();
            multicastLocator.Locator = new Locator(IPAddress.Parse("224.5.6.7"), 4567);
            this.ReaderLocatorAdd(multicastLocator);

            worker = new WriterWorker(this.PeriodicWork);
            worker.Start(1000);
        }

        /// <summary>
        /// The SPDPbuiltinParticipantWriter periodically sends this data-object to a pre-configured list of
        /// locators to announce the Participant’s presence on the network. This is achieved by periodically 
        /// calling StatelessWriter::unsent_changes_reset, which causes the StatelessWriter to resend all 
        /// changes present in its HistoryCache to all locators. The periodic rate at which the
        /// SPDPbuiltinParticipantWriter sends out the SPDPdiscoveredParticipantData defaults to a PSM specified
        /// value. This period should be smaller than the leaseDuration specified in the SPDPdiscoveredParticipantData
        /// </summary>
        private void PeriodicWork()
        {
            this.UnsentChangesReset();
        }

        public void Dispose()
        {
            worker.End();
        }
    }
}
