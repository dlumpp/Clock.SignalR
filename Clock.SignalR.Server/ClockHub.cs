using Microsoft.AspNetCore.SignalR;

namespace Clock.SignalR.Server
{
    public class ClockHub : Hub<IClockClient>
    {
        
    }
}
