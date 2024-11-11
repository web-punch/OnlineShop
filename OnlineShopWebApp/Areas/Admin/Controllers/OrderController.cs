using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;
        public OrderController(IOrdersStorage ordersStorage)
        {
            this.ordersStorage = ordersStorage;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await ordersStorage.GetAllAsync();
            return View(orders.ToOrdersViewModel());
        }

        public async Task<IActionResult> DetailsAsync(Guid id)
        {
            var order = await ordersStorage.TryGetByIdAsync(id);
            var orders = await ordersStorage.GetAllAsync();
            ViewData["orderNumber"] = orders.IndexOf(order!) + 1;
            return View(order.ToOrderViewModel());
        }

        public async Task<IActionResult> UpdateStatusAsync(Guid id, OrderStatus status)
        {
            await ordersStorage.UpdateStatusAsync(id, status);
            return RedirectToAction("Index");
        }

    }
}
