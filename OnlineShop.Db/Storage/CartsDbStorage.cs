using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using System.Data;


namespace OnlineShop.Db.Storage
{
    public class CartsDbStorage : ICartsStorage
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Cart> TryGetByUserNameAsync(string userName)
        {
            return await databaseContext.Carts.Include(c => c.Items).ThenInclude(c => c.Product).FirstOrDefaultAsync(c => c.UserName == userName);
        }
        public async Task AddAsync(Product product, string userName)
        {
            var newCart = await TryGetByUserNameAsync(userName);
            if (newCart == null)
            {
                newCart = new Cart()
                {
                    UserName = userName,
                    Items = new List<CartItem>()
                    {
                        new CartItem()
                        {
                            Product = product,
                            Amount = 1,
                        }
                    }
                };
                await databaseContext.Carts.AddAsync(newCart);
            }
            else
            {
                var cartItem = newCart?.Items?.FirstOrDefault(i => i?.Product?.Id == product.Id);
                if (cartItem != null)
                {
                    cartItem.Amount += 1;
                }
                else
                {
                    cartItem = new CartItem()
                    {
                        Product = product,
                        Amount = 1,
                    };
                    newCart?.Items?.Add(cartItem);
                }
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task DeleteItemAsync(Guid cartItemId, string userName)
        {
            var cart = await TryGetByUserNameAsync(userName);
            var item = cart?.Items?.SingleOrDefault(i => i.Id == cartItemId);
            if (item != null && cart?.Items?.Count > 1)
            {
                cart?.Items?.Remove(item);
            }
            else
            {
                await ClearAsync(userName);
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task ReduceAsync(Guid cartItemId, string userName)
        {
            var item = (await TryGetByUserNameAsync(userName)).Items?.FirstOrDefault(item => item.Id == cartItemId);
            if (item?.Amount > 1)
            {
                item.Amount--;
                await databaseContext.SaveChangesAsync();
            }
            else
            {
                await DeleteItemAsync(cartItemId, userName);
            }
        }
        public async Task ClearAsync(string userName)
        {
            var cart = await TryGetByUserNameAsync(userName);
            databaseContext.Carts.Remove(cart);
            await databaseContext.SaveChangesAsync();
        }
    }

}
