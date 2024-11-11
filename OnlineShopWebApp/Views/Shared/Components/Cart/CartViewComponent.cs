using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsStorage cartsStorage;

        public CartViewComponent(ICartsStorage cartsStorage)
        {
            this.cartsStorage = cartsStorage;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var cart = await cartsStorage.TryGetByUserNameAsync(User.Identity.Name);
                var productsCount = cart != null ? cart.ToCartViewModel().Amount : 0;
                return View("Cart", productsCount == 0 ? string.Empty : productsCount.ToString());
            }
            return View("Cart", string.Empty);
        }
    }
}
