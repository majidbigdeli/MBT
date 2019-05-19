using Hik.Communication.Mbt.Communication.EndPoints;
using Hik.Communication.Mbt.Server;

namespace Hik.Communication.MbtServices.Service
{
    /// <summary>
    /// This class is used to build MbtService applications.
    /// </summary>
    public static class MbtServiceBuilder
    {
        /// <summary>
        /// Creates a new MBT Service application using an EndPoint.
        /// </summary>
        /// <param name="endPoint">EndPoint that represents address of the service</param>
        /// <returns>Created MBT service application</returns>
        public static IMbtServiceApplication CreateService(MbtEndPoint endPoint)
        {
            return new MbtServiceApplication(MbtServerFactory.CreateServer(endPoint));
        }
    }
}
