using Microsoft.AspNetCore.SignalR;
using System;

namespace Clock.SignalR.Server
{
    public class TimeBroadcaster : IDisposable
    {
        private readonly IHubContext<ClockHub, IClockClient> hubContext;
        private readonly Ticker ticker;

        public TimeBroadcaster(IHubContext<ClockHub, IClockClient> hubContext, Ticker ticker)
        {
            this.hubContext = hubContext;
            this.ticker = ticker;
            ticker.OnTick += Ticker_OnTick;
        }

        public void Start() {
            ticker.Start();
        }

        private void Ticker_OnTick()
        {
            var currentTime = DateTimeOffset.UtcNow;
            hubContext.Clients.All.ReceiveTimeUpdate(currentTime);
        }

        public void Dispose()
        {
            ticker?.Stop();
            ticker?.Dispose();
        }
    }
}
