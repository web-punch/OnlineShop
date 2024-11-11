using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface ICartsStorage
    {
        Task<Cart> TryGetByUserNameAsync(string userName);
        Task AddAsync(Product product, string userName);
        Task DeleteItemAsync(Guid id, string userName);
        Task ReduceAsync(Guid id, string userName);
        Task ClearAsync(string userName);
    }
}
