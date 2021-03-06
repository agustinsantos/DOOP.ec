﻿using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Behavior
{
    /// <summary>
    /// The RTPS ReaderProxy class represents the information an RTPS StatefulWriter maintains on each matched RTPS 
    /// Reader. 
    /// </summary>
    public class ReaderProxy<T>
    {
        /// <summary>
        /// Identifies the remote matched RTPS Reader that is represented by the 
        /// ReaderProxy.
        /// </summary>
        public GUID remoteReaderGuid;

        /// <summary>
        /// List of unicast locators (transport, address, port combinations) that can be 
        /// used to send messages to the matched RTPS Reader. The list may be empty.
        /// </summary>
        public IList<Locator> unicastLocatorList;

        /// <summary>
        /// List of multicast locators (transport, address, port combinations) that can be 
        /// used to send messages to the matched RTPS Reader. The list may be empty.
        /// </summary>
        public IList<Locator> multicastLocatorList;

        /// <summary>
        /// List of CacheChange changes as they relate to the matched RTPS Reader.
        /// </summary>
        public IList<ChangeForReader<T>> changes_for_reader;

        /// <summary>
        /// Specifies whether the remote matched RTPS Reader expects in-line QoS to be 
        /// sent along with any data.
        /// </summary>
        public bool expectsInlineQos;

        /// <summary>
        ///  Specifies whether the remote Reader is responsive to the Writer
        /// </summary>
        public bool isActive;

        /// <summary>
        /// This operation changes the ChangeForReader status of a Set of changes for the reader represented by ReaderProxy
/// ‘the_reader_proxy.’ The Set of changes with sequence number smaller than or equal to the Value ‘committed_seq_num’ 
/// have their status changed to ACKNOWLEDGED. 
        /// </summary>
        /// <param name="committed_seq_num"></param>
        public void acked_changes_set(SequenceNumber committed_seq_num)
        { 
            // FOR_EACH change in this.changes_for_reader 
            //          SUCH-THAT (change.sequenceNumber <= committed_seq_num) DO
            // change.status := ACKNOWLEDGED;
            foreach (var change in this.changes_for_reader)
            {
                if( change.Change.SequenceNumber <= committed_seq_num)
                    change.Status = Types.ChangeForReaderStatusKind.ACKNOWLEDGED;
            }
        }

        /// <summary>
        /// This operation returns the ChangeForReader for the ReaderProxy that has the lowest sequence number among the 
        /// changes with status ‘REQUESTED.’ This represents the next repair packet that should be sent to the RTPS Reader
        /// represented by the ReaderProxy in response to a previous AckNack message (see Section 8.3.7.1) from the Reader.
        /// </summary>
        /// <returns></returns>
        public ChangeForReader<T> next_requested_change()
        { throw new NotImplementedException(); }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <returns></returns>
        public ChangeForReader<T> next_unsent_change()
        { throw new NotImplementedException(); }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <returns></returns>
        public IList<ChangeForReader<T>> unsent_changes()
        { throw new NotImplementedException(); }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <returns></returns>
        public IList<ChangeForReader<T>> requested_changes()
        { throw new NotImplementedException(); }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <param name="req_seq_num_set"></param>
        public void requested_changes_set(ISet<SequenceNumber> req_seq_num_set)
        { throw new NotImplementedException(); }

        /// <summary>
        /// TODO. Comment this method
        /// </summary>
        /// <returns></returns>
        public IList<ChangeForReader<T>> unacked_changes()
        { throw new NotImplementedException(); }
    }
}
