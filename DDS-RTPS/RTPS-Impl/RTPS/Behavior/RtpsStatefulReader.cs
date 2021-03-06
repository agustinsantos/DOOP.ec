﻿using log4net;
using Doopec.Rtps.RtpsTransport;
using Doopec.Rtps.SharedMem;
using Doopec.Utils.Transport;
using Mina.Core.Buffer;
using Rtps.Behavior;
using Rtps.Messages;
using Rtps.Messages.Types;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data = Rtps.Messages.Submessages.Data;
using DataObj = Rtps.Structure.Types.Data;
namespace Doopec.Rtps.Behavior
{
    public class RtpsStatefulReader<T> : StatefulReader<T>, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IList<Writer<T>> writers = new List<Writer<T>>();
        private UDPReceiver rec;
        public RtpsStatefulReader(GUID guid)
            : base(guid)
        {
            //TODO use configuration for host and port
            rec = new UDPReceiver(new Uri("udp://224.0.1.111:9999"), 1024);
            rec.Start();
            rec.MessageReceived += NewMessage;
            IRtpsDiscovery discoveryModule = RtpsEngineFactory.Instance.DiscoveryModule;
            discoveryModule.RegisterEndpoint(this);
            discoveryModule.EndpointDiscovery += OnDiscoveryEndpoints;
            AddWriters(discoveryModule);
        }

        private void NewMessage(object sender, RTPSMessageEventArgs e)
        {
            Message msg = e.Message;
            log.DebugFormat("New Message has arrived from {0}", e.Session.RemoteEndPoint);
            log.DebugFormat("Message Header: {0}", msg.Header);
            foreach (var submsg in msg.SubMessages)
            {
                switch (submsg.Kind)
                {
                    case SubMessageKind.DATA:
                        Data d = submsg as Data;
                        log.DebugFormat("SubMessage Data: {0}", submsg.Kind);
                        log.DebugFormat("The KeyFlag value state is: {0}", d.HasKeyFlag);
                        log.DebugFormat("The DataFlag value state is: {0}", d.HasDataFlag);
                        log.DebugFormat("The InlineQoSFlag value state is: {0}", d.HasInlineQosFlag);
                        log.DebugFormat("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                        log.DebugFormat("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                        log.DebugFormat("The extraFlags value is: {0}", d.ExtraFlags.Value);
                        log.DebugFormat("The octetsToInlineQos value is: Aun no logro");
                        log.DebugFormat("The readerID is: {0}", d.ReaderId);
                        log.DebugFormat("The writerID is: {0}", d.WriterId);
                        log.DebugFormat("The writerSN is: {0}", d.WriterSN);
                        IoBuffer buf = IoBuffer.Wrap(d.SerializedPayload.DataEncapsulation.SerializedPayload);
                        buf.Order = ByteOrder.LittleEndian; //(d.Header.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian);
                        object obj = Doopec.Serializer.Serializer.Deserialize<T>(buf);
                        CacheChange<T> change = new CacheChange<T>(ChangeKind.ALIVE, new GUID(msg.Header.GuidPrefix, d.WriterId), d.WriterSN, new DataObj(obj), new InstanceHandle());
                        ReaderCache.AddChange(change);
                        break;
                    default:
                        log.DebugFormat("SubMessage: {0}", submsg.Kind);
                        break;
                }
            }
        }

        public void Dispose()
        {
            rec.MessageReceived -= NewMessage;
            rec.Dispose();

            RemoveAllWriters();
            IRtpsDiscovery discoveryModule = RtpsEngineFactory.Instance.DiscoveryModule;
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

            //writers.Add(writer);
            //writer.HistoryCache.Changed += OnChangedHistoryCache;
        }

        private void AddWriters(IRtpsDiscovery discoveryModule)
        {
            foreach (var endpoint in discoveryModule.Endpoints)
            {
                if (endpoint is Writer<T>)
                    AddWriter(endpoint as Writer<T>);
            }
        }

        private void RemoveAllWriters()
        {
            foreach (var writer in writers)
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
                ReaderCache.AddChange(change);
                whc.RemoveChange(change);
            }
        }
    }
}
