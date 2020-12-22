using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Clock.SignalR.Client.Console
{
    class Program
    {
        const string DefaultUrl = "http://localhost:8080/clock";

        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl(DefaultUrl)
                .ConfigureLogging(logging => { 
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();

            connection.On<DateTimeOffset>("ReceiveTimeUpdate", dto => Log(dto.ToString("u")));

            await connection.StartAsync();

            System.Console.Read();
        }

        private static void Log(string msg) => System.Console.WriteLine(msg);
    }
}
