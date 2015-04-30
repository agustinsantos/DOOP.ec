using Doopec.Rtps.Encoders;
using log4net;
using Mina.Core.Session;
using Mina.Filter.Codec;
using Mina.Transport.Socket;
using Rtps.Messages;
using Rtps.Structure.Types;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace Doopec.Utils.Transport
{
    /// <summary>
    /// Provides data for <see cref="IoSession"/>'s message receive/sent event.
    /// </summary>
    public class RTPSMessageEventArgs : IoSessionEventArgs
    {
        private readonly Message _message;

        /// <summary>
        /// </summary>
        public RTPSMessageEventArgs(IoSession session, Message message)
            : base(session)
        {
            _message = message;
        }

        /// <summary>
        /// Gets the associated message.
        /// </summary>
        public Message Message
        {
            get { return _message; }
        }
    }

    /// <summary>
    /// This class receives UDP packets from the network. 
    /// </summary>
    public class UDPReceiver : IReceiver, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Uri uri;
        private readonly int bufferSize;

        private readonly Locator locator;
        private readonly int participantId;
        private readonly bool discovery;
        private AsyncDatagramAcceptor acceptor;

        public event EventHandler<RTPSMessageEventArgs> MessageReceived;

        public UDPReceiver(Uri uri, int bufferSize)
        {
            this.uri = uri;
            this.bufferSize = bufferSize;
            var addresses = System.Net.Dns.GetHostAddresses(uri.Host);
            int port = (uri.Port < 0 ? 0 : uri.Port);
            if (addresses != null && addresses.Length >= 1)
                this.locator = new Locator(addresses[0], port);
        }

        public Locator Locator
        {
            get { return locator; }
        }

        public int ParticipantId
        {
            get { return participantId; }
        }

        public void Start()
        {
            if (locator == null)
                throw new ApplicationException();

            IPEndPoint ep = new IPEndPoint(locator.SocketAddress, locator.Port);
            bool isMultiCastAddr;
            if (ep.AddressFamily == AddressFamily.InterNetwork) //IP v4
            {
                byte byteIp = ep.Address.GetAddressBytes()[0];
                isMultiCastAddr = (byteIp >= 224 && byteIp < 240) ? true : false;
            }
            else if (ep.AddressFamily == AddressFamily.InterNetworkV6)
            {
                isMultiCastAddr = ep.Address.IsIPv6Multicast;
            }
            else
            {
                throw new NotImplementedException("Address family not supported yet: " + ep.AddressFamily);
            }
            if (isMultiCastAddr)
            {
                acceptor = new AsyncDatagramAcceptor();
                // Define a MulticastOption object specifying the multicast group  
                // address and the local IPAddress. 
                // The multicast group address is the same as the address used by the client.
                MulticastOption mcastOption = new MulticastOption(locator.SocketAddress, IPAddress.Any);
                acceptor.SessionConfig.MulticastOption = mcastOption;
                acceptor.SessionConfig.ExclusiveAddressUse = false;
                acceptor.SessionConfig.ReuseAddress = true;
            }
            else
                acceptor = new AsyncDatagramAcceptor();

            //acceptor.FilterChain.AddLast("logger", new LoggingFilter());
            acceptor.FilterChain.AddLast("RTPS", new ProtocolCodecFilter(new MessageCodecFactory()));
            acceptor.SessionConfig.EnableBroadcast = true;

            acceptor.ExceptionCaught += (s, e) =>
            {
                Console.WriteLine(e.Exception);
                e.Session.Close(true);
            };
            acceptor.MessageReceived += (s, e) =>
            {
                Message msg = e.Message as Message;
                if (MessageReceived != null)
                    MessageReceived(s, new RTPSMessageEventArgs(e.Session, msg));
                //if (log.IsDebugEnabled)
                //{
                //    log.DebugFormat("New Message has arrived from {0}", e.Session.RemoteEndPoint);
                //    log.DebugFormat("Message Header: {0}", msg.Header);
                //    foreach (var submsg in msg.SubMessages)
                //    {
                //        log.DebugFormat("SubMessage: {0}", submsg);
                //        if (submsg is Data)
                //        {
                //            Data d = submsg as Data;
                //            foreach (var par in d.InlineQos.Value)
                //                log.DebugFormat("InlineQos: {0}", par);
                //        }
                //    }
                //}
            };
            acceptor.SessionCreated += (s, e) =>
            {
                log.Debug("Session created...");
            };
            acceptor.SessionOpened += (s, e) =>
            {
                log.Debug("Session opened...");
            };
            acceptor.SessionClosed += (s, e) =>
            {
                log.Debug("Session closed...");
            };
            acceptor.SessionIdle += (s, e) =>
            {
                log.Debug("Session idle...");
            };
            if (isMultiCastAddr)
                acceptor.Bind(new IPEndPoint(IPAddress.Any, locator.Port));
            else
                acceptor.Bind(new IPEndPoint(locator.SocketAddress, locator.Port));
            log.DebugFormat("Listening on udp://{0}:{1} for {2}", uri.Host, locator.Port, discovery ? "discovery traffic" : "user traffic");
        }

        public void Close()
        {
            if (acceptor != null)
            {
                log.DebugFormat("Closing {0}", acceptor.LocalEndPoint);

                acceptor.Dispose();
            }
        }

        public void Dispose()
        {
            if (acceptor != null)
                acceptor.Dispose();
        }
    }
}
