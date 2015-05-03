using Rtps.Messages;
using Rtps.Structure.Types;

namespace Doopec.Utils.Transport
{

    /// <summary>
    /// Transmitter is used to deliver messages to destination.
    /// </summary>
    public interface ITransmitter
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

        /// <summary>
        /// Sends a Message to destination.
        /// </summary>
        /// <param name="msg">Message to send</param>
        /// <returns>true, if an overflow occured.</returns>
        void SendMessage(Message msg);

        void Start();

        /// <summary>
        /// Close this Writer
        /// </summary>
        void Close();
    }
}
