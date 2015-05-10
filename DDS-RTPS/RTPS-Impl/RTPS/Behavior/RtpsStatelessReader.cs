using Doopec.Rtps.Messages;
using Doopec.Serializer;
using Doopec.Utils.Transport;
using log4net;
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
using Data = Rtps.Messages.Submessages.Data;
using DataObj = Rtps.Structure.Types.Data;

namespace Doopec.Rtps.Behavior
{
    public class RtpsStatelessReader<T> : StatelessReader<T>, IDisposable where T : new()
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected List<UDPReceiver> UDPReceivers { get; private set; }

        public RtpsStatelessReader(GUID guid)
            : base(guid)
        {
            Doopec.Serializer.Serializer.Initialize(typeof(T));
            UDPReceivers = new List<UDPReceiver>();
        }

        protected void InitReceivers()
        {
            foreach (var locator in MulticastLocatorList)
            {
                UDPReceiver rec = new UDPReceiver(locator, 1024);
                rec.ParticipantId = this.Guid;
                rec.MessageReceived += NewMessage;
                UDPReceivers.Add(rec);
            }

            foreach (var locator in UnicastLocatorList)
            {
                UDPReceiver rec = new UDPReceiver(locator, 1024);
                rec.ParticipantId = this.Guid;
                rec.MessageReceived += NewMessage;
                UDPReceivers.Add(rec);
            }
        }

        protected void StartReceivers()
        {
            foreach (var rec in UDPReceivers)
            {
                rec.Start();
            }
        }

        protected virtual void NewMessage(object sender, RTPSMessageEventArgs e)
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
                        buf.Order = (d.Header.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian);
                        T obj = EncapsulationManager.Deserialize<T>(buf);
#if TODO
                        CacheChange<T> change = new CacheChange<T>(ChangeKind.ALIVE, new GUID(msg.Header.GuidPrefix, d.WriterId), d.WriterSN, new DataObj(obj), new InstanceHandle());
                        ReaderCache.AddChange(change);
#endif
                        break;
                    default:
                        log.DebugFormat("SubMessage: {0}", submsg.Kind);
                        break;
                }
            }
        }

        public void Dispose()
        {
            foreach (var rec in UDPReceivers)
            {
                rec.MessageReceived -= NewMessage;
                rec.Close();
                rec.Dispose();
            }
            UDPReceivers.Clear();
        }
    }
}
