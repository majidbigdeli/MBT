using Hik.Communication.Mbt.Communication.Channels;
using Hik.Communication.Mbt.Communication.Channels.Tcp;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;

namespace Hik.Communication.Mbt.Server.Tcp
{
    /// <summary>
    /// This class is used to create a TCP server.
    /// </summary>
    internal class MbtTcpServer : MbtServerBase
    {
        /// <summary>
        /// The endpoint address of the server to listen incoming connections.
        /// </summary>
        private readonly MbtTcpEndPoint _endPoint;

        /// <summary>
        /// Creates a new MbtTcpServer object.
        /// </summary>
        /// <param name="endPoint">The endpoint address of the server to listen incoming connections</param>
        public MbtTcpServer(MbtTcpEndPoint endPoint)
        {
            _endPoint = endPoint;
        }

        /// <summary>
        /// Creates a TCP connection listener.
        /// </summary>
        /// <returns>Created listener object</returns>
        protected override IConnectionListener CreateConnectionListener()
        {
            return new TcpConnectionListener(_endPoint);
        }
    }
}
