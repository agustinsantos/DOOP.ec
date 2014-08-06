using Mina.Core.Buffer;
using rtps.messages.submessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTPS.Utils.NetEncoders;
using RTPS.Utils.Network.Encoders.RTPS;
using rtps.messages.elements;
using rtps.messages.submessage.interpreter;
using log4net;
using System.Reflection;
using rtps.messages.submessage.entity;

namespace RTPS.Utils.Network.Encoders
{
    public static class SubMessageEncoder
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static int PutSubMessage(this IoBuffer buffer, SubMessage msg)
        {
            buffer.Align(4);
            buffer.Order = msg.Header.EndiannessFlag; // Set the endianess
            buffer.PutSubMessageHeader(msg.Header);
            int position = buffer.Position;
            switch (msg.Kind)
            {
                case SubMessageKind.PAD:
                    buffer.PutPad((Pad)msg);
                    break;
                case SubMessageKind.ACKNACK:
                    buffer.PutAckNack((AckNack)msg);
                    break;
                case SubMessageKind.HEARTBEAT:
                    buffer.PutHeartbeat((Heartbeat)msg);
                    break;
                case SubMessageKind.GAP:
                    buffer.PutGap((Gap)msg);
                    break;
                case SubMessageKind.INFO_TS:
                    buffer.PutInfoTimestamp((InfoTimestamp)msg);
                    break;
                case SubMessageKind.INFO_SRC:
                    buffer.PutInfoSource((InfoSource)msg);
                    break;
                case SubMessageKind.INFO_REPLY_IP4:
                    buffer.PutInfoReplyIp4((InfoReplyIp4)msg);
                    break;
                case SubMessageKind.INFO_DST:
                    buffer.PutInfoDestination((InfoDestination)msg);
                    break;
                case SubMessageKind.INFO_REPLY:
                    buffer.PutInfoReply((InfoReply)msg);
                    break;
                case SubMessageKind.NACK_FRAG:
                    buffer.PutNackFrag((NackFrag)msg);
                    break;
                case SubMessageKind.HEARTBEAT_FRAG:
                    buffer.PutHeartbeatFrag((HeartbeatFrag)msg);
                    break;
                case SubMessageKind.DATA:
                    buffer.PutDataSubMessage((Data)msg);
                    break;
                case SubMessageKind.DATA_FRAG:
                    buffer.PutDataFrag((DataFrag)msg);
                    break;
                default:
                    break;
            }
            int subMessageLength = buffer.Position - position;

            // Position to 'submessageLength' -2 is for short (2 bytes)
            // buffers current position is not changed
            buffer.PutInt16(position - 2, (short)subMessageLength);
            return position;
        }

        public static SubMessage GetSubMessage(this IoBuffer buffer)
        {
            SubMessage obj = new SubMessage();
            buffer.GetSubMessage(ref obj);
            return obj;
        }

        public static void GetSubMessage(this IoBuffer buffer, ref SubMessage obj)
        {
            buffer.Align(4);
            int smhPosition = buffer.Position;

            SubMessageHeader header = buffer.GetSubMessageHeader();
            int smStart = buffer.Position;

            switch (header.SubMessageKind)
            { // @see 9.4.5.1.1
                case SubMessageKind.PAD:
                    Pad smPad = new Pad();
                    smPad.Header = header;
                    buffer.GetPad(ref smPad);
                    obj = smPad;
                    break;
                case SubMessageKind.ACKNACK:
                    AckNack smAckNack = new AckNack();
                    smAckNack.Header = header;
                    buffer.GetAckNack(ref smAckNack);
                    obj = smAckNack;
                    break;
                case SubMessageKind.HEARTBEAT:
                    Heartbeat smHeartbeat = new Heartbeat();
                    smHeartbeat.Header = header;
                    buffer.GetHeartbeat(ref smHeartbeat);
                    obj = smHeartbeat;
                    break;
                case SubMessageKind.GAP:
                    Gap smgap = new Gap();
                    smgap.Header = header;
                    buffer.GetGap(ref smgap);
                    obj = smgap;
                    break;
                case SubMessageKind.INFO_TS:
                    InfoTimestamp sminfots = new InfoTimestamp();
                    sminfots.Header = header;
                    buffer.GetInfoTimestamp(ref sminfots);
                    obj = sminfots;
                    break;
                case SubMessageKind.INFO_SRC:
                    InfoSource smInfoSource = new InfoSource();
                    smInfoSource.Header = header;
                    buffer.GetInfoSource(ref smInfoSource);
                    obj = smInfoSource;
                    break;
                case SubMessageKind.INFO_REPLY_IP4:
                    InfoReplyIp4 smInfoReplyIp4 = new InfoReplyIp4();
                    smInfoReplyIp4.Header = header;
                    buffer.GetInfoReplyIp4(ref smInfoReplyIp4);
                    obj = smInfoReplyIp4;
                    break;
                case SubMessageKind.INFO_DST:
                    InfoDestination smInfoDestination = new InfoDestination();
                    smInfoDestination.Header = header;
                    buffer.GetInfoDestination(ref smInfoDestination);
                    obj = smInfoDestination;
                    break;
                case SubMessageKind.INFO_REPLY:
                    InfoReply smInfoReply = new InfoReply();
                    smInfoReply.Header = header;
                    buffer.GetInfoReply(ref smInfoReply);
                    obj = smInfoReply;
                    break;
                case SubMessageKind.NACK_FRAG:
                    NackFrag smNackFrag = new NackFrag();
                    smNackFrag.Header = header;
                    buffer.GetNackFrag(ref smNackFrag);
                    obj = smNackFrag;
                    break;
                case SubMessageKind.HEARTBEAT_FRAG:
                    HeartbeatFrag smHeartbeatFrag = new HeartbeatFrag();
                    smHeartbeatFrag.Header = header;
                    buffer.GetHeartbeatFrag(ref smHeartbeatFrag);
                    obj = smHeartbeatFrag;
                    break;
                case SubMessageKind.DATA:
                    Data smdata = new Data();
                    smdata.Header = header;
                    buffer.GetDataSubMessage(ref smdata);
                    obj = smdata;
                    break;
                case SubMessageKind.DATA_FRAG:
                    DataFrag smdDataFrag = new DataFrag();
                    smdDataFrag.Header = header;
                    buffer.GetDataFrag(ref smdDataFrag);
                    obj = smdDataFrag;
                    break;

                default:
                    throw new NotSupportedException();
                    break;
            }

            int smEnd = buffer.Position;
            int smLength = smEnd - smStart;
            if (smLength != header.SubMessageLength && header.SubMessageLength != 0)
            {
                log.WarnFormat("SubMessage length differs for {0} != {1} for {2}", smLength, header.SubMessageLength, obj);
                if (smLength < header.SubMessageLength)
                {
                    byte[] unknownBytes = new byte[header.SubMessageLength - smLength];
                    log.DebugFormat("Trying to skip {0} bytes", unknownBytes.Length);

                    buffer.Get(unknownBytes, 0, unknownBytes.Length);
                }
            }

            log.DebugFormat("SubMsg in:  {0}", obj);
        }
    }
}
