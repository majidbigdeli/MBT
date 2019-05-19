using Hik.Communication.Mbt.Communication.EndPoints;

namespace Hik.Communication.MbtServices.Client
{
    /// <summary>
    /// This class is used to build service clients to remotely invoke methods of a MBT service.
    /// </summary>
    public class MbtServiceClientBuilder
    {
        /// <summary>
        /// Creates a client to connect to a MBT service.
        /// </summary>
        /// <typeparam name="T">Type of service interface for remote method call</typeparam>
        /// <param name="endpoint">EndPoint of the server</param>
        /// <param name="clientObject">Client-side object that handles remote method calls from server to client.
        /// May be null if client has no methods to be invoked by server</param>
        /// <returns>Created client object to connect to the server</returns>
        public static IMbtServiceClient<T> CreateClient<T>(MbtEndPoint endpoint, object clientObject = null) where T : class
        {
            return new MbtServiceClient<T>(endpoint.CreateClient(), clientObject);
        }

        /// <summary>
        /// Creates a client to connect to a MBT service.
        /// </summary>
        /// <typeparam name="T">Type of service interface for remote method call</typeparam>
        /// <param name="endpointAddress">EndPoint address of the server</param>
        /// <param name="clientObject">Client-side object that handles remote method calls from server to client.
        /// May be null if client has no methods to be invoked by server</param>
        /// <returns>Created client object to connect to the server</returns>
        public static IMbtServiceClient<T> CreateClient<T>(string endpointAddress, object clientObject = null) where T : class
        {
            return CreateClient<T>(MbtEndPoint.CreateEndPoint(endpointAddress), clientObject);
        }
    }
}
