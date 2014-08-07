using Rtps.Messages;

namespace Doopec.Utils.Transport
{

    /// <summary>
    /// Transmitter is used to deliver messages to destination.
    /// </summary>
    public interface ITransmitter
    {
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
