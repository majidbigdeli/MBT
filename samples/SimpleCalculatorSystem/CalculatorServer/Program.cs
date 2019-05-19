using System;
using CalculatorCommonLib;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.MbtServices.Service;

namespace CalculatorServer
{
    class Program
    {
        static void Main()
        {
            //Create a service application that runs on 10083 TCP port
            var serviceApplication = MbtServiceBuilder.CreateService(new MbtTcpEndPoint(10083));

            //Create a CalculatorService and add it to service application
            serviceApplication.AddService<ICalculatorService, CalculatorService>(new CalculatorService());
            
            //Start service application
            serviceApplication.Start();

            Console.WriteLine("Calculator service is started. Press enter to stop...");
            Console.ReadLine();

            //Stop service application
            serviceApplication.Stop();
        }
    }

    public class CalculatorService : MbtService, ICalculatorService
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public double Divide(double number1, double number2)
        {
            if(number2 == 0.0)
            {
                throw new DivideByZeroException("number2 can not be zero!");
            }

            return number1 / number2;
        }
    }
}
