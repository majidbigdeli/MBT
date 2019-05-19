namespace Hik.Communication.Mbt.Communication.Messages
{
    /// <summary>
    /// Represents a message that is sent and received by server and client.
    /// </summary>
    public interface IMbtMessage
    {
        /// <summary>
        /// Unique identified for this message. 
        /// </summary>
        string MessageId { get; }

        /// <summary>
        /// Unique identified for this message. 
        /// </summary>
        string RepliedMessageId { get; set; }
    }
}
