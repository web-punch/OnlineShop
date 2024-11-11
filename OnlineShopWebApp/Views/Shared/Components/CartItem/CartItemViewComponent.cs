using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.CartItem
{
    public class CartItemViewComponent : ViewComponent
    {
        private readonly ICartsStorage cartsStorage;

        public CartItemViewComponent(ICartsStorage cartsStorage)
        {
            this.cartsStorage = cartsStorage;
        }
        public async Task<IViewComponentResult> InvokeAsync(Guid itemId)
        {
            var cart = await cartsStorage.TryGetByUserNameAsync(User.Identity.Name);
            var cartItem = cart.Items?.FirstOrDefault(item => item.Id == itemId);
            return View("CartItem", cartItem.ToCartItemViewModel());
        }
    }
}
