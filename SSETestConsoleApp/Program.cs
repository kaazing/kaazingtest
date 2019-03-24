﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EvtSource;

namespace SSETestConsoleApp
{
    class Program
    {
        private static string _kaazingSSE = "https://streams.kaazing.net/sportsbook/scores";
        private static string _coralSSE = "https://cd.push.datafabric.aws.ladbrokescoral.com/sportsbook/categories/21";
        private static string _ladbrokesSSE = "https://ld.push.datafabric.aws.ladbrokescoral.com/sportsbook/categories/21";

        static void Main(string[] args)
        {
            string url = _kaazingSSE;

            if (args.Length > 0)
                url = args[0];
        
            var evt = new EventSourceReader(new Uri(url)).Start();

            evt.MessageReceived += (object sender, EventSourceMessageEventArgs e) => {
                Console.WriteLine($"{e.Message}");
            };
            evt.Disconnected += async (object sender, DisconnectEventArgs e) => {
                Console.WriteLine($"Retry: {e.ReconnectDelay} - Error");
                await Task.Delay(e.ReconnectDelay);
                evt.Start(); // Reconnect to the same URL
            };

            Console.WriteLine($"Opening SSE Stream: {url}");
            while (true)
            {
                Thread.Sleep(1000000);
            }
        }
    }
}
