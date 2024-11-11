using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IOrdersStorage
    {
        Task<List<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task<Order> TryGetByIdAsync(Guid id);
        Task UpdateStatusAsync(Guid id, OrderStatus status);
        Task StatusTrackingAsync(int formationTime);
    }
}