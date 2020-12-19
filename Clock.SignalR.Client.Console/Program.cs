using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Clock.SignalR.Client.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/clock")
                .Build();

            connection.On<DateTimeOffset>("ReceiveTimeUpdate", dto => Log(dto.ToString("u")));

            await connection.StartAsync();

            System.Console.Read();
        }

        private static void Log(string msg) => System.Console.WriteLine(msg);
    }
}
