﻿using Hik.Communication.Mbt.Communication;
using Hik.Communication.Mbt.Communication.Messengers;
using Hik.Communication.Mbt.Server;

namespace Hik.Communication.MbtServices.Service
{
    /// <summary>
    /// This class is used to create service client objects that is used in server-side.
    /// </summary>
    internal static class MbtServiceClientFactory
    {
        /// <summary>
        /// Creates a new service client object that is used in server-side.
        /// </summary>
        /// <param name="serverClient">Underlying server client object</param>
        /// <param name="requestReplyMessenger">RequestReplyMessenger object to send/receive messages over serverClient</param>
        /// <returns></returns>
        public static IMbtServiceClient CreateServiceClient(IMbtServerClient serverClient, RequestReplyMessenger<IMbtServerClient> requestReplyMessenger)
        {
            return new MbtServiceClient(serverClient, requestReplyMessenger);
        }
    }
}
