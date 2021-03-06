﻿using System;
using System.Diagnostics;
using CommonLib;
using Hik.Communication.Mbt.Client;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.Mbt.Communication.Messages;

namespace ClientApp
{
    class DuplexClientCustomProtocol
    {
        private static int _messageCount;
        private static Stopwatch _stopwatch;

        public static void Run()
        {
            Console.WriteLine("Press enter to connect to server and send " + Consts.MessageCount + " messages.");
            Console.ReadLine();

            using (var client = MbtClientFactory.CreateClient(new MbtTcpEndPoint("127.0.0.1", 10033)))
            {
                client.WireProtocol = new MyWireProtocol(); //Set custom wire protocol!
                client.MessageReceived += client_MessageReceived;

                client.Connect();

                for (var i = 0; i < Consts.MessageCount; i++)
                {
                    client.SendMessage(new MbtTextMessage("Hello from client!"));
                }

                Console.WriteLine("Press enter to disconnect from server");
                Console.ReadLine();
            }
        }

        static void client_MessageReceived(object sender, MessageEventArgs e)
        {
            ++_messageCount;

            if (_messageCount == 1)
            {
                _stopwatch = Stopwatch.StartNew();
            }
            else if (_messageCount == Consts.MessageCount)
            {
                _stopwatch.Stop();
                Console.WriteLine(Consts.MessageCount + " message is received in " + _stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " ms.");
            }
        }
    }
}
