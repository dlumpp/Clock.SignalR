using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Clock.SignalR.Server
{
    public class TimeBroadcastingBackgroundService : BackgroundService
    {
        private readonly TimeBroadcaster timeBroadcaster;

        public TimeBroadcastingBackgroundService(TimeBroadcaster timeBroadcaster)
        {
            this.timeBroadcaster = timeBroadcaster;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            timeBroadcaster.Start();
            return Task.CompletedTask;
        }
    }
}
