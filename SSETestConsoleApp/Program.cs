using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSETestConsoleApp
{
    class Program
    {
        private static string _kaazingSSE = "https://streams.kaazing.net/sportsbook/scores";
        private static string _coralSSE = "https://cd.push.datafabric.aws.ladbrokescoral.com/sportsbook/categories/21";
        private static string _ladbrokesSSE = "https://ld.push.datafabric.aws.ladbrokescoral.com/sportsbook/categories/21";

        static void Main(string[] args)
        {
            try
            {
                ProcessKaazingSSE(_kaazingSSE);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"----- Ran for {ex}");
            }
        }

        static private void ProcessKaazingSSE(string url)
        {
            bool exit = false;
            var eventSource = new Kaazing.HTML5.EventSource();

            eventSource.OpenEvent += new Kaazing.HTML5.OpenEventHandler((object sender, Kaazing.HTML5.OpenEventArgs e) =>
            {
                Trace.WriteLine($"EventArgsSource Open {e}");
            });

            eventSource.MessageEvent += new Kaazing.HTML5.MessageEventHandler((object sender, Kaazing.HTML5.MessageEventArgs e) =>
            {

                Trace.WriteLine($"EventArgsSource Message {e}");
            }); ;

            eventSource.ErrorEvent += new Kaazing.HTML5.ErrorEventHandler((object sender, Kaazing.HTML5.ErrorEventArgs e) =>
            {
                var evntSrc = sender as Kaazing.HTML5.EventSource;
                switch(evntSrc.ReadyState)
                {
                    case 2://closed
                        break;

                    case 1://connecting
                        break;
                }

                Trace.WriteLine($"EventArgsSource Error {e}");
                exit = true;
            });

            eventSource.Connect(url);

            while ( !exit )
            {
                int i = 0;
            }

            eventSource.Disconnect();
        }
    }
}
