using System;

namespace Hik.Communication.MbtServices.Service
{
    /// <summary>
    /// Stores service client informations to be used by an event.
    /// </summary>
    public class ServiceClientEventArgs : EventArgs
    {
        /// <summary>
        /// Client that is associated with this event.
        /// </summary>
        public IMbtServiceClient Client { get; private set; }

        /// <summary>
        /// Creates a new ServiceClientEventArgs object.
        /// </summary>
        /// <param name="client">Client that is associated with this event</param>
        public ServiceClientEventArgs(IMbtServiceClient client)
        {
            Client = client;
        }
    }
}
