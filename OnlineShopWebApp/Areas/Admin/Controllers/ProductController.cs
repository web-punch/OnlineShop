using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductsStorage productsStorage;
        private static int indexSlide;

        public ProductController(IProductsStorage productsStorage, IWebHostEnvironment webHostEnvironment)
        {
            this.productsStorage = productsStorage;
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productsStorage.GetAllAsync();
            return View(products.ToProductsViewModel());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(Guid productId)
        {
            await productsStorage.DeleteAsync(productId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            indexSlide = product.ActiveIndexImagePath;
            return View(product.ToProductViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductViewModel productViewModel)
        {
            SaveDownloadedImages(productViewModel);
            if (ModelState.IsValid)
            {
                await productsStorage.AddAsync(productViewModel.ToProductDb());
                return RedirectToAction("Index");
            }
            return View(productViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(ProductViewModel productViewModel)
        {
            SaveDownloadedImages(productViewModel);
            if (ModelState.IsValid)
            {
                productViewModel.ActiveIndexImagePath = indexSlide;
                await productsStorage.EditAsync(productViewModel.ToProductDb());
                return RedirectToAction("Index");
            }
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult SetActiveSlide(int index)
        {
            indexSlide = index;
            return Ok();
        }
        private void SaveDownloadedImages(ProductViewModel productViewModel)
        {
            if (productViewModel.UploadedFiles != null)
            {
                foreach (var file in productViewModel.UploadedFiles)
                {
                    if (file.ContentType.StartsWith("image/"))
                    {
                        var fileDownloadPath = Path.Combine($"{webHostEnvironment.WebRootPath}/images/products/");
                        if (!Directory.Exists(fileDownloadPath))
                        {
                            Directory.CreateDirectory(fileDownloadPath);
                        }
                        var fileName = $"{Guid.NewGuid()}.{file.FileName.Split('.').Last()}";
                        using (var fileStream = new FileStream($"{fileDownloadPath}{fileName}", FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        productViewModel.ImagesPaths.Add($"/images/products/{fileName}");
                    }
                }
            }
        }
    }
}
