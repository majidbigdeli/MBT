using System;

namespace Hik.Communication.Mbt.Communication.Messages
{
    /// <summary>
    /// This message is used to send/receive ping messages.
    /// Ping messages is used to keep connection alive between server and client.
    /// </summary>
    [Serializable]
    public sealed class MbtPingMessage : MbtMessage
    {
        ///<summary>
        /// Creates a new PingMessage object.
        ///</summary>
        public MbtPingMessage()
        {

        }

        /// <summary>
        /// Creates a new reply PingMessage object.
        /// </summary>
        /// <param name="repliedMessageId">
        /// Replied message id if this is a reply for
        /// a message.
        /// </param>
        public MbtPingMessage(string repliedMessageId)
            : this()
        {
            RepliedMessageId = repliedMessageId;
        }

        /// <summary>
        /// Creates a string to represents this object.
        /// </summary>
        /// <returns>A string to represents this object</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(RepliedMessageId)
                       ? string.Format("MbtPingMessage [{0}]", MessageId)
                       : string.Format("MbtPingMessage [{0}] Replied To [{1}]", MessageId, RepliedMessageId);
        }
    }
}
