using System;
using System.Threading;

namespace Clock.SignalR.Server
{
    public class Ticker : IDisposable
    {
        public event Action OnTick;

        private readonly Timer timer;
        private readonly TimeSpan interval = TimeSpan.FromSeconds(1);
        private readonly TimeSpan negOneMs = TimeSpan.FromMilliseconds(-1);

        public Ticker()
        {
            timer = new Timer(DoTick);
        }

        public void Start()
        {
            timer.Change(interval, negOneMs);
        }

        public void Stop()
        {
            timer.Change(negOneMs, negOneMs);
        }

        private void DoTick(object state)
        {
            OnTick?.Invoke();
            Start();
        }

        public void Dispose()
        {
            Stop();
            timer?.Dispose();
        }
    }
}
