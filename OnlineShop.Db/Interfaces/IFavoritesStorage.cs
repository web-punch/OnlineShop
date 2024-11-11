using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IFavoritesStorage
    {
        Task<Favorites> TryGetByUserNameAsync(string userName);
        Task AddAsync(Product product, string userName);
        Task ClearAsync(string userName);
        Task DeleteAsync(Guid id, string userName);
    }
}