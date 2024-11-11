using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IFavoritesStorage favoritesStorage;
        private readonly UserManager<User> userManager;


        public FavoritesController(IFavoritesStorage favoritesStorage, IProductsStorage productsStorage, UserManager<User> userManager)
        {
            this.favoritesStorage = favoritesStorage;
            this.productsStorage = productsStorage;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var favorites = await favoritesStorage.TryGetByUserNameAsync(user.UserName);
            return View(favorites.ToFavoritesViewModel());
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
            return PartialView("NavbarIcons");
        }
        public async Task<IActionResult> Delete(Guid productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            await favoritesStorage.DeleteAsync(productId, user.UserName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            await favoritesStorage.ClearAsync(user.UserName);
            return RedirectToAction("Index");
        }
        private async Task AddAsync(Guid productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var product = await productsStorage.TryGetByIdAsync(productId);
            await favoritesStorage.AddAsync(product, user.UserName);
        }
    }
}
