using Hik.Communication.Mbt.Communication.EndPoints;

namespace Hik.Communication.Mbt.Client
{
    /// <summary>
    /// This class is used to create MBT Clients to connect to a MBT server.
    /// </summary>
    public static class MbtClientFactory
    {
        /// <summary>
        /// Creates a new client to connect to a server using an end point.
        /// </summary>
        /// <param name="endpoint">End point of the server to connect it</param>
        /// <returns>Created TCP client</returns>
        public static IMbtClient CreateClient(MbtEndPoint endpoint)
        {
            return endpoint.CreateClient();
        }

        /// <summary>
        /// Creates a new client to connect to a server using an end point.
        /// </summary>
        /// <param name="endpointAddress">End point address of the server to connect it</param>
        /// <returns>Created TCP client</returns>
        public static IMbtClient CreateClient(string endpointAddress)
        {
            return CreateClient(MbtEndPoint.CreateEndPoint(endpointAddress));
        }
    }
}
