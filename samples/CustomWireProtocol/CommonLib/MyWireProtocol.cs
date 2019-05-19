using System.Text;
using Hik.Communication.Mbt.Communication.Messages;
using Hik.Communication.Mbt.Communication.Protocols.BinarySerialization;

namespace CommonLib
{
    /// <summary>
    /// This class is a sample custom wire protocol to use as wire protocol in MBT framework.
    /// It extends BinarySerializationProtocol.
    /// It is used just to send/receive MbtTextMessage messages.
    /// 
    /// Since BinarySerializationProtocol automatically writes message length to the beggining
    /// of the message, a message format of this class is:
    /// 
    /// [Message length (4 bytes)][UTF-8 encoded text (N bytes)]
    /// 
    /// So, total length of the message = (N + 4) bytes;
    /// </summary>
    public class MyWireProtocol : BinarySerializationProtocol
    {
        protected override byte[] SerializeMessage(IMbtMessage message)
        {
            return Encoding.UTF8.GetBytes(((MbtTextMessage)message).Text);
        }

        protected override IMbtMessage DeserializeMessage(byte[] bytes)
        {
            //Decode UTF8 encoded text and create a MbtTextMessage object
            return new MbtTextMessage(Encoding.UTF8.GetString(bytes));
        }
    }
}
