using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Storage
{
    public class OrdersDbStorage : IOrdersStorage
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await databaseContext.Orders
                .Include(o => o.Items).ThenInclude(i => i.Product)
                .Include(o => o.Info)
                .ToListAsync();
        }
        public async Task<Order> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Orders
                .Include(order => order.Items).ThenInclude(item => item.Product)
                .Include(order => order.Info)
                .FirstOrDefaultAsync(order => order.Id == id);
        }
        public async Task AddAsync(Order order)
        {
            await databaseContext.Orders.AddAsync(order);
            await databaseContext.SaveChangesAsync();
        }


        public async Task UpdateStatusAsync(Guid id, OrderStatus newStatus)
        {
            var order = await TryGetByIdAsync(id);
            if (order != null)
            {
                order.Status = newStatus;
                await databaseContext.SaveChangesAsync();
            }
        }
        public async Task StatusTrackingAsync(int formationTime)
        {
            var orders = await databaseContext.Orders
                .Where(order => (order.Status == OrderStatus.Created && DateTime.Now > order.DateTime.AddMinutes(formationTime)))
                .ToListAsync();
            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    await UpdateStatusAsync(order.Id, OrderStatus.Canceled);
                }
            }
        }
    }
}
