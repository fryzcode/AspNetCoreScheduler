using NCrontab;

namespace AspNetCoreScheduler.BackgroundService
{
    public abstract class ScheduledProcesor : ScopedProcessor
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        protected abstract string Schedule { get; }
        public ScheduledProcesor(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.UtcNow;

                if (now > _nextRun)
                {
                    await Process();

                    _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
                }

                await Task.Delay(5000, stoppingToken);
             
            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
