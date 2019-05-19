using System;
using Hik.Communication.Mbt.Communication.Messages;

namespace Hik.Communication.MbtServices.Communication.Messages
{
    /// <summary>
    /// This message is sent as response message to a MbtRemoteInvokeMessage.
    /// It is used to send return value of method invocation.
    /// </summary>
    [Serializable]
    public class MbtRemoteInvokeReturnMessage : MbtMessage
    {
        /// <summary>
        /// Return value of remote method invocation.
        /// </summary>
        public object ReturnValue { get; set; }

        /// <summary>
        /// If any exception occured during method invocation, this field contains Exception object.
        /// If no exception occured, this field is null.
        /// </summary>
        public MbtRemoteException RemoteException { get; set; }

        /// <summary>
        /// Represents this object as string.
        /// </summary>
        /// <returns>String representation of this object</returns>
        public override string ToString()
        {
            return string.Format("MbtRemoteInvokeReturnMessage: Returns {0}, Exception = {1}", ReturnValue, RemoteException);
        }
    }
}
