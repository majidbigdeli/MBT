using Hik.Communication.Mbt.Communication;
using Hik.Communication.Mbt.Communication.Messengers;

namespace Hik.Communication.Mbt.Client
{
    /// <summary>
    /// Represents a client to connect to server.
    /// </summary>
    public interface IMbtClient : IMessenger, IConnectableClient
    {
        //Does not define any additional member
    }
}
