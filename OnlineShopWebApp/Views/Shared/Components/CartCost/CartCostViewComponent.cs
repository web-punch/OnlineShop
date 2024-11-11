using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.CartCost
{
    public class CartCostViewComponent: ViewComponent
    {
        private readonly ICartsStorage cartsStorage;
        public CartCostViewComponent(ICartsStorage cartsStorage)
        {
           this.cartsStorage = cartsStorage;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await cartsStorage.TryGetByUserNameAsync(User.Identity.Name);
            var cost = cart.ToCartViewModel().Cost;
            return View("CartCost", cost);
        }
    }
}
