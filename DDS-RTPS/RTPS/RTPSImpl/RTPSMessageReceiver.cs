using log4net;
using Rtps.messages.elements;
using Rtps.messages.message;
using Rtps.messages.submessage;
using Rtps.messages.submessage.entity;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.RTPSImpl
{
    /// <summary>
    /// The interpretation and meaning of a Submessage within a Message may depend on the previous Submessages contained
    /// within that same Message. Therefore, the receiver of a Message must maintain state from previously deserialized
    /// Submessages in the same Message. This state is modeled as the state of an RTPS Receiver that is reset each time a new
    /// message is processed and provides context for the interpretation of each Submessage.
    /// 
    /// Successfully parsed messages are split into submessages, which are passed to
    /// corresponding RTPS reader entities.
    /// </summary>
    public class RTPSMessageReceiver
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Participant participant;

        private ISet<GuidPrefix> ignoredParticipants = new HashSet<GuidPrefix>();

        RTPSMessageReceiver(Participant p)
        {
            this.participant = p;
        }

        /// <summary>
        /// Handles incoming Message. Each sub message is transferred to
        ///  corresponding reader.
        /// </summary>
        /// <param name="msg"></param>
        private void HandleMessage(Message msg)
        {
#if TODO
            int msgId = msg.GetHashCode();
            Time timestamp = null;
            GuidPrefix destGuidPrefix = GuidPrefix.GUIDPREFIX_UNKNOWN;
            GuidPrefix sourceGuidPrefix = msg.Header.GuidPrefix;

            if (participant.Guid.Prefix.Equals(sourceGuidPrefix))
            {
                log.Debug("Discarding message originating from this participant");
                return;
            }

            ISet<Reader> dataReceivers = new HashSet<Reader>();
            IList<SubMessage> subMessages = msg.SubMessages;

            foreach (SubMessage subMsg in subMessages)
            {
                switch (subMsg.Kind)
                {
                    case SubMessageKind.ACKNACK:
                        if (ignoredParticipants.Contains(sourceGuidPrefix))
                        {
                            continue;
                        }

                        handleAckNack(sourceGuidPrefix, (AckNack)subMsg);
                        break;
                    case SubMessageKind.DATA:
                        if (ignoredParticipants.Contains(sourceGuidPrefix))
                        {
                            continue;
                        }

                        try
                        {
                            Data data = (Data)subMsg;
                            Reader r = participant.getReader(data.getReaderId(), data.getWriterId());

                            if (r != null)
                            {
                                if (dataReceivers.Add(r))
                                {
                                    r.StartMessageProcessing(msgId);
                                }
                                r.CreateSample(msgId, sourceGuidPrefix, data, timestamp);
                            }
                            else
                            {
                                log.WarnFormat("No Reader({0}) to handle Data from {1}", data.getReaderId(), data.getWriterId());
                            }
                        }
                        catch (Exception ioe)
                        {
                            log.WarnFormat("Failed to handle data: {0}", ioe);
                        }
                        break;
                    case SubMessageKind.HEARTBEAT:
                        if (ignoredParticipants.Contains(sourceGuidPrefix))
                        {
                            continue;
                        }

                        HandleHeartbeat(sourceGuidPrefix, (Heartbeat)subMsg);
                        break;
                    case SubMessageKind.INFO_DST:
                        destGuidPrefix = ((InfoDestination)subMsg).getGuidPrefix();
                        break;
                    case SubMessageKind.INFO_SRC:
                        sourceGuidPrefix = ((InfoSource)subMsg).getGuidPrefix();
                        break;
                    case SubMessageKind.INFO_TS:
                        timestamp = ((InfoTimestamp)subMsg).getTimeStamp();
                        break;
                    case SubMessageKind.INFO_REPLY: // TODO: HB, AC & DATA needs to use replyLocators,
                        // if present
                        InfoReply ir = (InfoReply)subMsg;
                        List<Locator> replyLocators = ir.getUnicastLocatorList();
                        if (ir.multicastFlag())
                        {
                            replyLocators.Add(ir.getMulticastLocatorList());
                        }
                        log.Warn("InfoReply not handled");
                        break;
                    case SubMessageKind.INFO_REPLY_IP4: // TODO: HB, AC & DATA needs to use these
                        // Locators, if present
                        InfoReplyIp4 ir4 = (InfoReplyIp4)subMsg;
                        LocatorUDPv4 unicastLocator = ir4.getUnicastLocator();
                        if (ir4.multicastFlag())
                        {
                            LocatorUDPv4 multicastLocator = ir4.getMulticastLocator();
                        }
                        log.Warn("InfoReplyIp4 not handled");
                        break;
                    case SubMessageKind.GAP:
                        HandleGap(sourceGuidPrefix, (Gap)subMsg);
                        break;
                    default:
                        log.WarnFormat("SubMessage not handled: {0}", subMsg);
                }
            }

            log.DebugFormat("Releasing samples for {0} readers", dataReceivers.Count);
            foreach (Reader reader in dataReceivers)
            {
                reader.stopMessageProcessing(msgId);
            }
#endif
            throw new NotImplementedException();
        }

        private void handleAckNack(GuidPrefix sourceGuidPrefix, AckNack ackNack)
        {
#if TODO
            Writer writer = participant.getWriter(ackNack.getWriterId(), ackNack.getReaderId());

            if (writer != null)
            {
                writer.onAckNack(sourceGuidPrefix, ackNack);
            }
            else
            {
                log.DebugFormat("No Writer({0}) to handle AckNack from {1}", ackNack.getWriterId(), ackNack.getReaderId());
            }
#endif
            throw new NotImplementedException();
        }

        private void HandleGap(GuidPrefix sourceGuidPrefix, Gap gap)
        {
#if TODO
           Reader reader = participant.getReader(gap.getReaderId(), gap.getWriterId());
            reader.handleGap(sourceGuidPrefix, gap);
#endif
            throw new NotImplementedException();
        }

        private void HandleHeartbeat(GuidPrefix senderGuidPrefix, Heartbeat hb)
        {
#if TODO
            Reader reader = participant.getReader(hb.getReaderId(), hb.getWriterId());

            if (reader != null)
            {
                reader.onHeartbeat(senderGuidPrefix, hb);
            }
            else
            {
                log.DebugFormat("No Reader({0}) to handle Heartbeat from {1}", hb.getReaderId(), hb.getWriterId());
            }
#endif
            throw new NotImplementedException();
        }

        void IgnoreParticipant(GuidPrefix prefix)
        {
            ignoredParticipants.Add(prefix);
        }
    }
}
