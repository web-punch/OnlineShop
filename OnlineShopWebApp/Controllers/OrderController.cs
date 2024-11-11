using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsStorage cartsStorage;
        private readonly IOrdersStorage ordersStorage;
        private readonly UserManager<User> userManager;

        public OrderController(ICartsStorage cartsStorage, IOrdersStorage ordersStorage, UserManager<User> userManager)
        {
            this.cartsStorage = cartsStorage;
            this.ordersStorage = ordersStorage;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = await cartsStorage.TryGetByUserNameAsync(user.UserName);
            var orderPageInfo = new OrderPageInfo() { Cart = cart.ToCartViewModel() };
            return View(orderPageInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderPageInfo orderPageInfo)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = await cartsStorage.TryGetByUserNameAsync(user.UserName);
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    UserName = user.UserName,
                    Info = orderPageInfo.OrderInfo.ToOrderInfoDb(),
                    Items = cart.Items!
                };
                await ordersStorage.AddAsync(order);
                await cartsStorage.ClearAsync(user.UserName);
                return View("Success");
            }
            orderPageInfo.Cart = cart.ToCartViewModel();
            return View(orderPageInfo);

        }
    }
}
