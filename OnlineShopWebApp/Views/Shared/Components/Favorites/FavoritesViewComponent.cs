using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;

namespace OnlineShopWebApp.Views.Shared.Components.Favorites
{
    public class FavoritesViewComponent : ViewComponent
    {
        private readonly IFavoritesStorage favoritesStorage;

        public FavoritesViewComponent(IFavoritesStorage favoritesStorage)
        {
            this.favoritesStorage = favoritesStorage;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var favorites = await favoritesStorage.TryGetByUserNameAsync(User.Identity.Name);
                var productsCount = favorites?.Products?.Count;
                return View("Favorites", productsCount == 0 ? string.Empty : productsCount.ToString());
            }
            return View("Favorites", string.Empty);

        }
    }
}
