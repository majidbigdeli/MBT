using Hik.Communication.Mbt.Communication.Protocols;

namespace CommonLib
{
    public class MyWireProtocolFactory : IMbtWireProtocolFactory
    {
        public IMbtWireProtocol CreateWireProtocol()
        {
            return new MyWireProtocol();
        }
    }
}
