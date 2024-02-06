using AspNetCoreScheduler.BackgroundService;

namespace AspNetCoreScheduler.ScheduleTask
{
    public class SimpleTask1 : ScheduledProcessor
    {
        public SimpleTask1(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            
        }
        protected override string Schedule => "*/1 * * * *"; // every 1 minute

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            Console.WriteLine("SampleTask1 : " + DateTime.UtcNow.ToString());

            return Task.CompletedTask;
        }
    }
}
