using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ChartApp.Actors
{
    /// <summary>
    ///     Actor responsible for monitoring a specific <see cref="PerformanceCounter" />
    /// </summary>
    public class PerformanceCounterActor : ReceiveActor
    {
        private readonly CancellationTokenSource _cancelPublishing;
        private readonly Func<PerformanceCounter> _performanceCounterGenerator;
        private readonly string _seriesName;
        private readonly HashSet<ActorRef> _subscriptions;
        private PerformanceCounter _counter;

        public PerformanceCounterActor(string seriesName, Func<PerformanceCounter> performanceCounterGenerator)
        {
            _seriesName = seriesName;
            _performanceCounterGenerator = performanceCounterGenerator;
            _subscriptions = new HashSet<ActorRef>();
            _cancelPublishing = new CancellationTokenSource();

            Receive<GatherMetrics>(_ =>
            {
                // publish latest counter value to all subscribers
                var metric = new Metric(_seriesName, _counter.NextValue());
                foreach (var sub in _subscriptions)
                    sub.Tell(metric);
            });
            Receive<SubscribeCounter>(sc => _subscriptions.Add(sc.Subscriber));
            Receive<UnsubscribeCounter>(uc => _subscriptions.Remove(uc.Subscriber));
        }

        #region Actor lifecycle methods

        protected override void PreStart()
        {
            // create a new instance of the performance counter
            _counter = _performanceCounterGenerator();
            Context.System.Scheduler.Schedule(TimeSpan.FromMilliseconds(250), TimeSpan.FromMilliseconds(250), Self,
                new GatherMetrics(), _cancelPublishing.Token);
        }

        protected override void PostStop()
        {
            try
            {
                // terminate the scheduled task
                _cancelPublishing.Cancel(false);
                _counter.Dispose();
            }
            catch
            {
                // we don't care about additional "ObjectDisposed" exceptions
            }
            finally
            {
                base.PostStop();
            }
        }

        #endregion
    }
}