
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreScheduler.BackgroundService
{
    public abstract class ScopedProcessor : BackgroundService
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public ScopedProcessor(IServiceScopeFactory serviceScopeFactory):base()
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.UtcNow;
               
            } while (!stoppingToken.IsCancellationRequested);
        }

    }
}
