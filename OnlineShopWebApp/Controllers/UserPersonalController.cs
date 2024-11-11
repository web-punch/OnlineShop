using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class UserPersonalController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IOrdersStorage ordersStorage;
        public UserPersonalController(UserManager<User> userManager, IOrdersStorage ordersStorage)
        {
            this.userManager = userManager;
            this.ordersStorage = ordersStorage;
        }

        [HttpGet]
        private async Task<User> GetUserAsync()
        {
            return await userManager.FindByNameAsync(User.Identity.Name);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetUserAsync();
            return View(user.ToUserViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> OrdersAsync()
        {
            var user = await GetUserAsync();
            var orders = await ordersStorage.GetAllAsync();
            return View(orders.Where(order => order.UserName == user.UserName).ToList().ToOrdersViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailsAsync(Guid orderId)
        {
            var order = await ordersStorage.TryGetByIdAsync(orderId);
            return View(order.ToOrderViewModel());
        }

        [HttpGet]
        public IActionResult ChangePassword(string userName)
        {
            var passwordChangePage = new PasswordChangePage() { UserName = userName };
            return View(passwordChangePage);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(PasswordChangePage passwordChangePage)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(passwordChangePage.UserName);
                var result = await userManager.ChangePasswordAsync(user, passwordChangePage.CurrentPassword, passwordChangePage.NewPassword);
                if (result.Succeeded)
                {
                    return View("PasswordChangedSuccessfully", user.UserName);
                }
                if (result.Errors.Any(error => error.Code == "PasswordMismatch"))
                {
                    ModelState.AddModelError("CurrentPassword", "Неверный пароль");
                }
                else
                {
                    ModelState.AddModelError("NewPassword", "Пароль должен содержать прописные и строчные буквы, цифры и символы");
                }
            }
            return View(passwordChangePage);
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync()
        {
            var user = await GetUserAsync();
            return View(user?.ToUserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var editUser = await GetUserAsync();
                if (editUser != null)
                {
                    editUser.FirstName = user.FirstName;
                    editUser.LastName = user.LastName;
                    editUser.PhoneNumber = user.Phone;
                    await userManager.UpdateAsync(editUser);
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

    }
}
