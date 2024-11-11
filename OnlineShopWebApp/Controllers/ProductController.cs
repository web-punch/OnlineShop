using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.ReviewsApi;
using OnlineShopWebApp.ReviewsApi.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ReviewApiClient reviewApiClient;
        private readonly UserManager<User> userManager;

        public ProductController(IProductsStorage productsStorage, ReviewApiClient reviewApiClient, UserManager<User> userManager)
        {
            this.productsStorage = productsStorage;
            this.reviewApiClient = reviewApiClient;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(Guid id)
        {
            var reviews = await reviewApiClient.GetReviewsAsync(id);
            var product = (await productsStorage.TryGetByIdAsync(id)).ToProductViewModel();
            product.Reviews = reviews;
            return View(product);
        }
        [Authorize]
        public async Task<IActionResult> AddReviewAsync(Guid productId) 
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var addReview = new AddReview
            {
                ProductId = productId,
                UserId = Guid.Parse(user.Id)
            };
            return View(addReview);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReviewAsync(AddReview newReview)
        {
            await reviewApiClient.AddReviewAsync(newReview);
            return RedirectToAction(nameof(Index), new {id = newReview.ProductId});
        }
    }
}
