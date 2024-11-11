using OnlineShop.Db.Interfaces;
using Serilog;

namespace OnlineShopWebApp.BackgroundServices
{
    public class OrderStatusTracking : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;
        public OrderStatusTracking(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = scopeFactory.CreateAsyncScope())
            {
                var orderStorage = scope.ServiceProvider.GetRequiredService<IOrdersStorage>();
                var formationTime = 5;
                while (!stoppingToken.IsCancellationRequested)
                {
                    Log.Information("Start tracking order status");
                    await orderStorage.StatusTrackingAsync(formationTime);
                    Log.Information("End tracking order status");
                    await Task.Delay(TimeSpan.FromMinutes(formationTime), stoppingToken);
                }
            }
        }
    }
}
