

using System;
using System.Collections.Generic;
using System.Linq;

using Rtps.Structure.Types;
using log4net;
using System.Reflection;
namespace Rtps.Structure
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p13: Container class used to temporarily store and
    ///  manage sets of changes to data-objects. On the Writer side it contains the
    ///  history of the changes to data-objects made by the Writer. It is not necessary
    ///  that the full history of all changes ever made is maintained. Rather what is
    ///  needed is the partial history required to service existing and future matched
    ///  RTPS Reader endpoints. The partial history needed depends on the DDS QoS and the
    ///  state of the communications with the matched Reader endpoints. On the Reader
    ///  side it contains the history of the changes to data-objects made by the matched
    ///  RTPS Writer endpoints. It is not necessary that the full history of all changes
    ///  ever received is maintained. Rather what is needed is a partial history
    ///  containing the superposition of the changes received from the matched writers as
    ///  needed to satisfy the needs of the corresponding DDS DataReader. The rules for
    ///  this superposition and the amount of partial history required depend on the DDS
    ///  QoS and the state of the communication with the matched RTPS Writer endpoints.
    /// </summary>
    public class HistoryCache<T>
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// A collection of CacheCahnges contained in the HistoryCache
        /// </summary>
        private IList<CacheChange<T>> changes = new List<CacheChange<T>>();

        public delegate void ChangedEventHandler(object sender, EventArgs e);

        public event ChangedEventHandler Changed;

        /// <summary>
        /// A collection of CacheChanges contained in the HistoryCache
        /// </summary>
        public IList<CacheChange<T>> Changes
        {
            get { return changes; }
        }

        /// <summary>
        /// This operation inserts the CacheChange a_change into the HistoryCache.
        /// This operation will only fail if there are not enough resources to Add the change to the HistoryCache. It is the 
        /// responsibility of the DDS service implementation to configure the HistoryCache in a manner consistent with the DDS 
        /// Entity RESOURCE_LIMITS QoS and to propagate any errors to the DDS-user in the manner specified by the DDS 
        /// specification. 
        /// </summary>
        /// <param name="a_change"></param>
        public void AddChange(CacheChange<T> a_change)
        {
            changes.Add(a_change);
            NotifyNewChanges();
        }

        /// <summary>
        /// This operation indicates that a previously-added CacheChange has become irrelevant and the details regarding the 
        /// CacheChange need not be maintained in the HistoryCache. The determination of irrelevance is made based on the QoS 
        /// associated with the related DDS entity and on the acknowledgment status of the CacheChange. 
        /// </summary>
        /// <param name="a_change"></param>
        public void RemoveChange(CacheChange<T> a_change)
        {
            try { 
                changes.Remove(a_change);
            }
            catch (Exception e)
            {}
        }

        public CacheChange<T> GetChange()
        {
            return changes[0];
        }

        /// <summary>
        /// This operation retrieves the smallest Value of the CacheChange.SequenceNumber attribute among the CacheChange
        /// stored in the HistoryCache. 
        /// </summary>
        /// <returns></returns>
        SequenceNumber get_seq_num_min()
        {
            return changes[0].SequenceNumber;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SequenceNumber get_seq_num_max()
        {
            return changes[changes.Count - 1].SequenceNumber;
        }

        private void NotifyNewChanges()
        {
            log.Debug("This HistoryCache has new changes");
            if (Changed != null)
            {
                Changed(this, EventArgs.Empty);
            }
        }
    }
}
