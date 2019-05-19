using System;
using CommonLib;
using Hik.Communication.Mbt.Client;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.Mbt.Communication.Messages;

/* This application is build to demonstrate a CUSTOM WIRE PROTOCOL usage with MBT framework.
 * This client application connects to a server and sends a message using MyWireProtocol class.
 */

namespace ClientApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press enter to connect to server and say Hello world!");
            Console.ReadLine();

            using (var client = MbtClientFactory.CreateClient(new MbtTcpEndPoint("127.0.0.1", 10033)))
            {
                client.WireProtocol = new MyWireProtocol(); //Set custom wire protocol!

                client.Connect();
                client.SendMessage(new MbtTextMessage("Hello world!"));

                Console.WriteLine("Press enter to disconnect from server");
                Console.ReadLine();
            }
        }
    }
}
