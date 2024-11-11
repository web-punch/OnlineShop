using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.ReviewsApi;
using OnlineShopWebApp.ReviewsApi.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ReviewApiClient reviewApiClient;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ReviewApiClient reviewApiClient)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.reviewApiClient = reviewApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = userManager.Users.ToList();
            var usersViewModel = new List<UserViewModel>();
            foreach (var user in users)
            {
                var convertedUser = user.ToUserViewModel();
                var roles = await userManager.GetRolesAsync(user);
                convertedUser.Role = roles.FirstOrDefault();
                usersViewModel.Add(convertedUser);
            }
            return View(usersViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return View(user?.ToUserViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return View(user?.ToUserViewModel());
        }

        [HttpGet]
        public IActionResult ChangePassword(string userName)
        {
            var passwordChangePage = new PasswordChangePage() { UserName = userName };
            return View(passwordChangePage);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditRoleAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            var roleChangePage = new RoleChangePage()
            {
                UserName = userName,
                RoleName = (await userManager.GetRolesAsync(user)).FirstOrDefault(),
                Roles = roleManager.Roles.Select(role => role.ToRoleViewModel()).ToList()
            };
            return View(roleChangePage);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Register register)
        {
            if (await userManager.FindByNameAsync(register.UserName) != null)
            {
                ModelState.AddModelError("UserName", "Логин занят");
            }
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = register.UserName };
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
                    if (!await reviewApiClient.CheckLoginAsync(user.UserName))
                    {
                        var loginReview = new LoginReview
                        {
                            UserName = user.UserName,
                            Password = user.PasswordHash,
                        };
                        await reviewApiClient.AddLoginAsync(loginReview);
                    }
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Password", "Пароль должен содержать прописные и строчные буквы, цифры и символы");
            }
            return View(register);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var editUser = await userManager.FindByNameAsync(user.Name);
                if (editUser != null)
                {
                    editUser.FirstName = user.FirstName;
                    editUser.LastName = user.LastName;
                    editUser.PhoneNumber = user.Phone;
                    await userManager.UpdateAsync(editUser);
                }
                return RedirectToAction("Details", new { userName = editUser.UserName });
            }
            return View(user);
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
        [HttpPost]
        public async Task<IActionResult> EditRoleAsync(RoleChangePage roleChange)
        {
            var user = await userManager.FindByNameAsync(roleChange.UserName);
            if (user != null)
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
                await userManager.AddToRoleAsync(user, roleChange.RoleName);
            }
            return RedirectToAction("Index");
        }
    }
}
