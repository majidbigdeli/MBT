using System;
using Hik.Communication.Mbt.Client;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.Mbt.Communication.Messages;
using Hik.Communication.Mbt.Communication.Messengers;

/* This program is build to demonstrate a client application that connects to a server
 * and sends/receives messages in using SynchronizedMessenger.
 */

namespace SynchronizedClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press enter to connect to the server...");
            Console.ReadLine(); //Wait user to press enter

            //Create a client object to connect a server on 127.0.0.1 (local) IP and listens 10085 TCP port
            using (var client = MbtClientFactory.CreateClient(new MbtTcpEndPoint("127.0.0.1", 10085)))
            {
                //Create a SynchronizedMessenger that uses the client as internal messenger.
                using (var synchronizedMessenger = new SynchronizedMessenger<IMbtClient>(client))
                {
                    synchronizedMessenger.Start(); //Start synchronized messenger messenger
                    client.Connect(); //Connect to the server

                    Console.Write("Write some message to be sent to server: ");
                    var messageText = Console.ReadLine(); //Get a message from user

                    //Send a message to the server
                    synchronizedMessenger.SendMessage(new MbtTextMessage(messageText));

                    //Receive a message from the server
                    var receivedMessage = synchronizedMessenger.ReceiveMessage<MbtTextMessage>();

                    Console.WriteLine("Response to message: " + (receivedMessage.Text));

                    Console.WriteLine("Press enter to disconnect from server...");
                    Console.ReadLine(); //Wait user to press enter
                }
            }
        }
    }
}
