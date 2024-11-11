using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IProductsStorage
    {
        Task <List<Product>> GetAllAsync();
        Task<Product> TryGetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task EditAsync(Product editProduct);
        Task DeleteAsync(Guid productId);
    }
}
