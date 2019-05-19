using System;
using Hik.Communication.Mbt.Client;
using Hik.Communication.Mbt.Client.Tcp;
using Hik.Communication.Mbt.Server;
using Hik.Communication.Mbt.Server.Tcp;

namespace Hik.Communication.Mbt.Communication.EndPoints.Tcp
{
    /// <summary>
    /// Represens a TCP end point in MBT.
    /// </summary>
    public sealed class MbtTcpEndPoint : MbtEndPoint
    {
        ///<summary>
        /// IP address of the server.
        ///</summary>
        public string IpAddress { get; set; }

        ///<summary>
        /// Listening TCP Port for incoming connection requests on server.
        ///</summary>
        public int TcpPort { get; private set; }

        /// <summary>
        /// Creates a new MbtTcpEndPoint object with specified port number.
        /// </summary>
        /// <param name="tcpPort">Listening TCP Port for incoming connection requests on server</param>
        public MbtTcpEndPoint(int tcpPort)
        {
            TcpPort = tcpPort;
        }

        /// <summary>
        /// Creates a new MbtTcpEndPoint object with specified IP address and port number.
        /// </summary>
        /// <param name="ipAddress">IP address of the server</param>
        /// <param name="port">Listening TCP Port for incoming connection requests on server</param>
        public MbtTcpEndPoint(string ipAddress, int port)
        {
            IpAddress = ipAddress;
            TcpPort = port;
        }
        
        /// <summary>
        /// Creates a new MbtTcpEndPoint from a string address.
        /// Address format must be like IPAddress:Port (For example: 127.0.0.1:10085).
        /// </summary>
        /// <param name="address">TCP end point Address</param>
        /// <returns>Created MbtTcpEndpoint object</returns>
        public MbtTcpEndPoint(string address)
        {
            var splittedAddress = address.Trim().Split(':');
            IpAddress = splittedAddress[0].Trim();
            TcpPort = Convert.ToInt32(splittedAddress[1].Trim());
        }

        /// <summary>
        /// Creates a Mbt Server that uses this end point to listen incoming connections.
        /// </summary>
        /// <returns>Mbt Server</returns>
        internal override IMbtServer CreateServer()
        {
            return new MbtTcpServer(this);
        }

        /// <summary>
        /// Creates a Mbt Client that uses this end point to connect to server.
        /// </summary>
        /// <returns>Mbt Client</returns>
        internal override IMbtClient CreateClient()
        {
            return new MbtTcpClient(this);
        }

        /// <summary>
        /// Generates a string representation of this end point object.
        /// </summary>
        /// <returns>String representation of this end point object</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(IpAddress) ? ("tcp://" + TcpPort) : ("tcp://" + IpAddress + ":" + TcpPort);
        }
    }
}