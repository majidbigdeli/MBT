using System;
using Hik.Communication.Mbt.Communication.Messages;

namespace Hik.Communication.MbtServices.Communication.Messages
{
    /// <summary>
    /// This message is sent to invoke a method of a remote application.
    /// </summary>
    [Serializable]
    public class MbtRemoteInvokeMessage : MbtMessage
    {
        /// <summary>
        /// Name of the remove service class.
        /// </summary>
        public string ServiceClassName { get; set; }

        /// <summary>
        /// Method of remote application to invoke.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Parameters of method.
        /// </summary>
        public object[] Parameters { get; set; }

        /// <summary>
        /// Represents this object as string.
        /// </summary>
        /// <returns>String representation of this object</returns>
        public override string ToString()
        {
            return string.Format("MbtRemoteInvokeMessage: {0}.{1}(...)", ServiceClassName, MethodName);
        }
    }
}
