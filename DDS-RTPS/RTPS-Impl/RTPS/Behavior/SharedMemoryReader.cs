using Common.Logging;
using Doopec.Rtps.SharedMem;
using Rtps.Behavior;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.Behavior
{
    public class SharedMemoryReader<T> : StatefulReader<T>, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private IList<Writer<T>> writers = new List<Writer<T>>();

        public SharedMemoryReader(Participant participant)
            : base(participant)
        {
            SharedMemoryDiscovery discoveryModule = ((SharedMemoryEngine)RtpsEngine.Instance).DiscoveryModule;
            discoveryModule.RegisterEndpoint(this);
            discoveryModule.EndpointDiscovery += OnDiscoveryEndpoints;
            AddWriters(discoveryModule);
        }

        public void Dispose()
        {
            RemoveAllWriters();
            SharedMemoryDiscovery discoveryModule = ((SharedMemoryEngine)RtpsEngine.Instance).DiscoveryModule;
            discoveryModule.UnregisterEndpoint(this);
            discoveryModule.EndpointDiscovery -= OnDiscoveryEndpoints;
        }

        private void OnDiscoveryEndpoints(object sender, DiscoveryEventArgs e)
        {
            Writer<T> writer = e.EventData as Writer<T>;
            if (writer == null)
                return;
            if (e.Reason == EventReason.NEW_ENDPOINT)
                writers.Add(writer);
            else if (e.Reason == EventReason.NEW_ENDPOINT)
                writers.Remove(writer);
        }

        private void AddWriter(Writer<T> writer)
        {
            //TODO
            //WriterProxy<T> writerProxy = new WriterProxy<T>();
            //this.MatchedWriterAdd(writerProxy);

            writers.Add(writer);
            writer.HistoryCache.Changed += OnChangedHistoryCache;
        }

        private void AddWriters(SharedMemoryDiscovery discoveryModule)
        {
            foreach (var endpoint in discoveryModule.Endpoints)
            {
                if (endpoint is Writer<T>)
                    AddWriter(endpoint as Writer<T>);
            }
        }

        private void RemoveAllWriters()
        {
            foreach(var writer in writers)
                writer.HistoryCache.Changed -= OnChangedHistoryCache;

            writers.Clear();
        }

        private void OnChangedHistoryCache(object sender, EventArgs e)
        {
            log.Debug("A new change has been detected");
            HistoryCache<T> whc = sender as HistoryCache<T>;
            if (whc != null)
            {
                CacheChange<T> change = whc.GetChange();
                reader_cache.AddChange(change);
                whc.RemoveChange(change);
            }
        }
    }
}
