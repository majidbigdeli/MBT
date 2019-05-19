using Hik.Communication.Mbt.Communication.EndPoints;

namespace Hik.Communication.Mbt.Server
{
    /// <summary>
    /// This class is used to create MBT servers.
    /// </summary>
    public static class MbtServerFactory
    {
        /// <summary>
        /// Creates a new MBT Server using an EndPoint.
        /// </summary>
        /// <param name="endPoint">Endpoint that represents address of the server</param>
        /// <returns>Created TCP server</returns>
        public static IMbtServer CreateServer(MbtEndPoint endPoint)
        {
            return endPoint.CreateServer();
        }
    }
}
