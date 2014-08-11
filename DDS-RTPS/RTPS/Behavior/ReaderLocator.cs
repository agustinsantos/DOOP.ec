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
    /// Valuetype used by the RTPS StatelessWriter to keep track of the locators of all matching remote Readers. 
    /// </summary>
    public class ReaderLocator
    {
        private IList<ICacheChange> requested_changes_;
        private IList<ICacheChange> unsent_changes_;
        private Locator locator;
        private bool expectsInlineQos;

        /// <summary>
        /// A list of changes in the writer’s HistoryCache that were requested by 
        /// remote Readers at this ReaderLocator.
        /// </summary>
        public IList<ICacheChange> RequestedChanges
        {
            get { return requested_changes_; }
            set { requested_changes_ = value; }
        }

        /// <summary>
        /// A list of changes in the writer’s HistoryCache that have not been sent yet to 
        /// this ReaderLocator.
        /// </summary>
        public IList<ICacheChange> UnsentChanges
        {
            get { return unsent_changes_; }
            set { unsent_changes_ = value; }
        }

        /// <summary>
        /// Unicast or multicast locator through which the readers represented by this 
        /// ReaderLocator can be reached.
        /// </summary>
        public Locator Locator
        {
            get { return locator; }
            set { locator = value; }
        }

        /// <summary>
        /// Specifies whether the readers represented by this ReaderLocator expect inline QoS to 
        /// be sent with every Data Message.
        /// </summary>
        public bool ExpectsInlineQos
        {
            get { return expectsInlineQos; }
            set { expectsInlineQos = value; }
        }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <returns></returns>
        public IChangeForReader NextRequestedChange()
        { throw new NotImplementedException(); }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <returns></returns>
        public IChangeForReader NextUnsentChange()
        { throw new NotImplementedException(); }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <param name="req_seq_num_set"></param>
        public void RequestedChangesSet(ISet<SequenceNumber> req_seq_num_set)
        { throw new NotImplementedException(); }

    }
}
