using System.Text.Json;
using OnlineShop.Db.Models;
using OnlineShop.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db.Storage
{
    public class ProductsDbStorage : IProductsStorage
    {
        private readonly DatabaseContext databaseContext;
        public ProductsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await databaseContext.Products.ToListAsync();
        }
        public async Task<Product> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Product product)
        {
            await databaseContext.Products.AddAsync(product);
            await databaseContext.SaveChangesAsync();
        }
        public async Task EditAsync(Product editProduct)
        {
            var product = await TryGetByIdAsync(editProduct.Id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
            product.ActiveIndexImagePath = editProduct.ActiveIndexImagePath;
            foreach(var path in editProduct.ImagesPaths)
            {
                product.ImagesPaths.Add(path);
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid productId)
        {
            var product = await TryGetByIdAsync(productId);
            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync();
        }
    }
}
