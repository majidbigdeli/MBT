using System;
using CalculatorCommonLib;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.MbtServices.Client;

namespace CalculatorClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press enter to connect to server and call methods...");
            Console.ReadLine();

            //Create a client that can call methods of Calculator Service that is running on local computer and 10083 TCP port
            //Since IMbtServiceClient is IDisposible, it closes connection at the end of the using block
            using (var client = MbtServiceClientBuilder.CreateClient<ICalculatorService>(new MbtTcpEndPoint("127.0.0.1", 10083)))
            {
                //Connect to the server
                client.Connect();

                //Call a remote method of server
                var division = client.ServiceProxy.Divide(42, 3);

                //Write the result to the screen
                Console.WriteLine("Result: " + division);
            }

            Console.WriteLine("Press enter to stop client application");
            Console.ReadLine();
        }
    }
}
