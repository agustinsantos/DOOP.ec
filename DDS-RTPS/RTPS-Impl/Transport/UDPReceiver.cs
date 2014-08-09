using Doopec.Rtps.Encoders;
using log4net;
using Mina.Filter.Codec;
using Mina.Transport.Socket;
using Rtps.Messages;
using Rtps.Structure.Types;
using System;
using System.Net;
using System.Reflection;

namespace Doopec.Utils.Transport
{
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

            acceptor = new AsyncDatagramAcceptor();
            //acceptor.FilterChain.AddLast("logger", new LoggingFilter());
            acceptor.FilterChain.AddLast("RTPS", new ProtocolCodecFilter(new MessageCodecFactory()));
            acceptor.SessionConfig.ReuseAddress = true;

            acceptor.ExceptionCaught += (s, e) =>
            {
                Console.WriteLine(e.Exception);
                e.Session.Close(true);
            };
            acceptor.MessageReceived += (s, e) =>
            {
                Message msg = e.Message as Message;
                log.DebugFormat("New value for {0}", e.Session.RemoteEndPoint);
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
            throw new NotImplementedException();
        }
    }
}
