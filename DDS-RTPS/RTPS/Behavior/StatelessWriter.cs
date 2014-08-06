using Rtps.Behavior.Types;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Behavior
{
    /// <summary>
    /// Specialization of RTPS Writer used for the Stateless Reference Implementation. The RTPS StatelessWriter has no 
    /// knowledge of the number of matched readers, nor does it maintain any state for each matched RTPS Reader endpoint. 
    /// The RTPS StatelessWriter maintains only the RTPS Locator_t list that should be used to send information to 
    /// the matched readers.
    /// </summary>
    public class StatelessWriter : Writer
    {
        private Duration resendDataPeriod;

        /// <summary>
        ///  Protocol tuning parameter that indicates that the StatelessWriter resends all the 
        ///  changes in the writer’s HistoryCache to all the Locators periodically each resendPeriod
        /// </summary>
        public Duration ResendDataPeriod
        {
            get { return resendDataPeriod; }
            set { resendDataPeriod = value; }
        }

        /// <summary>
        /// The StatelessWriter maintains the list of locators to which it sends the 
        ///CacheChanges. This list may include both unicast and multicast locators.
        /// </summary>
        public IList<ReaderLocator> reader_locators = new List<ReaderLocator>();

        public StatelessWriter(Participant participant)
            : base(participant)
        {
        }

        /// <summary>
        /// This operation adds the Locator a_locator to the StatelessWriter.reader_locators.
        /// </summary>
        public void ReaderLocatorAdd(ReaderLocator a_locator)
        {
            reader_locators.Add(a_locator);
        }

        /// <summary>
        /// This operation removes the Locator a_locator from the StatelessWriter.reader_locators.
        /// </summary>
        /// <param name="a_locator"></param>
        public void ReaderLocatorRemove(ReaderLocator a_locator)
        {
            reader_locators.Remove(a_locator);
        }

        /// <summary>
        /// This operation modifies the set of ‘unsent_changes’ for all the ReaderLocators in the 
        /// StatelessWriter::reader_locators. 
        /// The list of unsent changes is reset to match the complete list of changes available in
        /// the writer’s HistoryCache.
        /// </summary>
        public void UnsentChangesReset()
        {
            foreach (var readerLocator in this.reader_locators)
            {
                readerLocator.UnsentChanges = this.writer_cache.Changes;
            }
        }
    }
}
