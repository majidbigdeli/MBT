﻿using System;
using System.Diagnostics;
using CommonLib;
using Hik.Communication.Mbt.Communication.EndPoints.Tcp;
using Hik.Communication.Mbt.Communication.Messages;
using Hik.Communication.Mbt.Server;

namespace ServerApp
{
    public class DuplexServerCustomProtocol
    {
        private static int _messageCount;
        private static Stopwatch _stopwatch;

        public static void Run()
        {
            var server = MbtServerFactory.CreateServer(new MbtTcpEndPoint(10033));

            server.WireProtocolFactory = new MyWireProtocolFactory();
            server.ClientConnected += server_ClientConnected;

            server.Start();

            Console.WriteLine("Press enter to stop server");
            Console.ReadLine();

            server.Stop();
        }

        static void server_ClientConnected(object sender, ServerClientEventArgs e)
        {
            e.Client.MessageReceived += Client_MessageReceived;
        }

        static void Client_MessageReceived(object sender, MessageEventArgs e)
        {
            ++_messageCount;

            var client = (IMbtServerClient) sender;
            client.SendMessage(new MbtTextMessage("Hello from server!"));

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
