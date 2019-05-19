using Hik.Samples.Mbt.IrcChat.Arguments;

namespace Hik.Samples.Mbt.IrcChat.Controls
{
    /// <summary>
    /// This interface defines methods of windows which contains a MessagingAreaControl.
    /// </summary>
    public interface IMessagingAreaContainer
    {
        /// <summary>
        /// This method is used by MessagingAreaControl to send messages.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        void SendMessage(ChatMessage message);
    }
}