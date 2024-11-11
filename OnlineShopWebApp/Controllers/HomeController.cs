using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly int pageSize = 3;
        private readonly int rangeNumbering = 10;
        public HomeController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var products = await productsStorage.GetAllAsync();
            return View(PaginationInfo(products, pageNumber, pageSize, rangeNumbering));
        }
        public async Task<IActionResult> SearchAsync(string lineSearch, int pageNumber = 1)
        {
            if (!string.IsNullOrWhiteSpace(lineSearch))
            {
                var products = (await productsStorage.GetAllAsync()).Where(p => p.Name!.ToLower().Contains(lineSearch.ToLower().Trim())).ToList();
                ViewData["lineSearch"] = lineSearch;
                if (products.Count == 0)
                {
                    return View("NoSearchResults");
                }
                return View("SearchResult", PaginationInfo(products, pageNumber, pageSize, rangeNumbering));
            }
            return RedirectToAction(nameof(Index));
        }
        private ProductsPaginationViewModel PaginationInfo(List<Product> products, int pageNumber, int pageSize, int rangeNumbering)
        {
            var pageItems = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var pagination = new Pagination(products.Count(), pageNumber, pageSize);
            var startNumbering = pagination.PageNumber - rangeNumbering / 2;
            var endNumbering = rangeNumbering % 2 == 0 ? pagination.PageNumber + (rangeNumbering / 2 - 1) : pagination.PageNumber + rangeNumbering / 2;
            if (startNumbering <= 0)
            {
                endNumbering = endNumbering - (startNumbering - 1);
                startNumbering = 1;
            }
            if (endNumbering > pagination.TotalPages)
            {
                endNumbering = pagination.TotalPages;
                if (endNumbering >= rangeNumbering)
                {
                    startNumbering = endNumbering - (rangeNumbering - 1);
                }
            }
            pagination.StartNumbering = startNumbering;
            pagination.EndNumbering = endNumbering;
            return new ProductsPaginationViewModel(pageItems.ToProductsViewModel(), pagination);
        }
    }
}
