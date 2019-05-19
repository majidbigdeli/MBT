using System;
using Hik.Communication.Mbt.Client;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.Mbt.Communication.Messages;
using Hik.Communication.Mbt.Communication.Messengers;

/* This program is build to demonstrate a client application that connects to a server
 * and sends/receives messages in using RequestReplyMessenger.
 */

namespace RequestReplyStyleClient
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
                //Create a RequestReplyMessenger that uses the client as internal messenger.
                using (var requestReplyMessenger = new RequestReplyMessenger<IMbtClient>(client))
                {
                    requestReplyMessenger.Start(); //Start request/reply messenger
                    client.Connect(); //Connect to the server

                    Console.Write("Write some message to be sent to server: ");
                    var messageText = Console.ReadLine(); //Get a message from user

                    //Send user message to the server and get response
                    var response = requestReplyMessenger.SendMessageAndWaitForResponse(new MbtTextMessage(messageText));
                    
                    Console.WriteLine("Response to message: " + ((MbtTextMessage) response).Text);

                    Console.WriteLine("Press enter to disconnect from server...");
                    Console.ReadLine(); //Wait user to press enter
                }
            }
        }
    }
}
