using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using System.ComponentModel;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ICartsStorage cartsStorage;
        private readonly UserManager<User> userManager;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsStorage, UserManager<User> userManager)
        {
            this.productsStorage = productsStorage;
            this.cartsStorage = cartsStorage;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = await cartsStorage.TryGetByUserNameAsync(user.UserName);
            return View(cart.ToCartViewModel());
        }

        public async Task<IActionResult> AddProductAsync(Guid productId, string comeBackUrl)
        {
            await AddAsync(productId);
            return Redirect(comeBackUrl);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductPartialAsync(Guid productId)
        {
            await AddAsync(productId);
            return UpdateProductsCartPartial();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuantityProductPartialAsync(Guid productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cartItemId = (await cartsStorage.TryGetByUserNameAsync(user.UserName))?.Items?.FirstOrDefault(item => item.Product.Id == productId)?.Id;
            return PartialView("_CartItem", cartItemId);
        }

        [HttpPost]
        public async Task<IActionResult> ReduceQuantityProductPartialAsync(Guid productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cartItem = (await cartsStorage.TryGetByUserNameAsync(user.UserName))?.Items?.FirstOrDefault(item => item.Product.Id == productId);
            if (cartItem?.Amount > 1)
            {
                await cartsStorage.ReduceAsync(cartItem.Id, user.UserName);
            }
            return PartialView("_CartItem", cartItem?.Id);
        }

        public async Task<IActionResult> DeleteAsync(Guid cartItemId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            await cartsStorage.DeleteItemAsync(cartItemId, user.UserName);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            await cartsStorage.ClearAsync(user.UserName);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateProductsCartPartial()
        {
            return PartialView("NavbarIcons");
        }

        [HttpPost]
        public IActionResult UpdateCartCostPartial()
        {
            return PartialView("_CartCost");
        }
        private async Task AddAsync(Guid productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var product = await productsStorage.TryGetByIdAsync(productId);
            await cartsStorage.AddAsync(product, user.UserName);
        }

    }
}
