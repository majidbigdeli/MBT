using System;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.MbtServices.Service;
using PhoneBookCommonLib;

/* This is a simple phone book server application that runs on MBT framework.
 */

namespace PhoneBookServer
{
    class Program
    {
        static void Main()
        {
            //Create a Mbt Service application that runs on 10048 TCP port.
            var server = MbtServiceBuilder.CreateService(new MbtTcpEndPoint(10048));

            //Add Phone Book Service to service application
            server.AddService<IPhoneBookService, PhoneBookService>(new PhoneBookService());
            
            //Start server
            server.Start();

            //Wait user to stop server by pressing Enter
            Console.WriteLine("Phone Book Server started successfully. Press enter to stop...");
            Console.ReadLine();
            
            //Stop server
            server.Stop();
        }
    }
}
