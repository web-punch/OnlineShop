using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Storage
{
    public class FavoritesDbStorage : IFavoritesStorage
    {
        private readonly DatabaseContext databaseContext;

        public FavoritesDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Favorites> TryGetByUserNameAsync(string userName)
        {
            return await databaseContext.Favorites.Include(f => f.Products).FirstOrDefaultAsync(f => f.UserName == userName);
        }
        public async Task AddAsync(Product product, string userName)
        {
            var newFavorites = await TryGetByUserNameAsync(userName);
            if (newFavorites == null)
            {
                newFavorites = new Favorites()
                {
                    UserName = userName,
                    Products = new List<Product>(){product}
                };
                await databaseContext.Favorites.AddAsync(newFavorites);
            }
            else
            {
                if (!newFavorites.Products!.Contains(product))
                {
                    newFavorites.Products.Add(product);
                }
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id, string userName)
        {
            var favorites = await TryGetByUserNameAsync(userName);
            var product = favorites?.Products?.FirstOrDefault(p => p.Id == id);
            if (product != null && favorites?.Products?.Count > 1)
            {
                favorites?.Products?.Remove(product);
            }
            else
            {
                await ClearAsync(userName);
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task ClearAsync(string userName)
        {
            var favorites = await TryGetByUserNameAsync(userName);
            databaseContext.Favorites.Remove(favorites);
            await databaseContext.SaveChangesAsync();
        }
    }
}

