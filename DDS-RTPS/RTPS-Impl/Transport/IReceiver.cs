﻿using Rtps.Structure.Types;

namespace Doopec.Utils.Transport
{
    /// <summary>
    /// Receiver will be used to receive packets from the source. Typically, source is from the network, but
    /// it can be anything. Like memory, file etc.
    /// </summary>
    public interface IReceiver
    {
        /// <summary>
        /// Gets the locator associated with this Receiver. This locator will be transmitted 
        /// to remote participants.
        /// </summary>
        /// <returns></returns>
        Locator Locator { get; }

        /// <summary>
        /// Gets the participantId associated with this receiver. During creation of receiver,
        /// participantId may be given as -1, indicating that provider should generate one.
        /// This method returns the Value assigned by the provider.
        /// </summary>
        GUID ParticipantId { get; }

        void Start();

        /// <summary>
        /// Close this Receiver
        /// </summary>
        void Close();
    }
}
