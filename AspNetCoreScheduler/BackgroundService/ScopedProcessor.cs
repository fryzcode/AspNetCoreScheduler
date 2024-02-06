
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
        protected override async Task Process()
        {
            using (var scope = _serviceScopeFactory.CreateScope()) 
            {
                await ProcessInScope(scope.ServiceProvider);
            };
        }

        public abstract Task ProcessInScope(IServiceProvider serviceProvider);
    }
}
