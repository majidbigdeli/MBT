using System;
using System.Runtime.Serialization;

namespace Hik.Communication.MbtServices.Communication.Messages
{
    /// <summary>
    /// Represents a MBT Remote Exception.
    /// This exception is used to send an exception from an application to another application.
    /// </summary>
    [Serializable]
    public class MbtRemoteException : Exception
    {
        /// <summary>
        /// Contstructor.
        /// </summary>
        public MbtRemoteException()
        {

        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        public MbtRemoteException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public MbtRemoteException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public MbtRemoteException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
