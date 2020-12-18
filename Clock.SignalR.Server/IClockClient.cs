using System;
using System.Threading.Tasks;

namespace Clock.SignalR.Server
{
    public interface IClockClient
    {
        Task ReceiveTimeUpdate(DateTimeOffset time);
    }
}