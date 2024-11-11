using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.ReviewsApi;
using OnlineShopWebApp.ReviewsApi.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ReviewApiClient reviewApiClient;
        public AuthorizationController(UserManager<User> userManager, SignInManager<User> signInManager, ReviewApiClient reviewApiClient)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.reviewApiClient = reviewApiClient;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = Constants.HomeUrl, string comeBackUrl = "")
        {
            if (string.IsNullOrEmpty(comeBackUrl)) 
            {
                return View(new Login() { ReturnUrl = returnUrl });
            };
            return View(new Login() { ReturnUrl = returnUrl + "&comeBackUrl=" + comeBackUrl });
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = Constants.HomeUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl });
        }
        public async Task<IActionResult> LogoutAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var removeResult = await userManager.RemoveAuthenticationTokenAsync(user, "ReviewsApi", "AuthToken");
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Login login)
        {
            var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, login.IsRemember, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password", "Не верный логин или пароль");
                return View(login);
            }
            var user = await userManager.FindByNameAsync(login.UserName);
            var loginReview = new LoginReview()
            {
                UserName = user.UserName,
                Password = user.PasswordHash
            };
            if (!await reviewApiClient.CheckLoginAsync(login.UserName))
            {
                await reviewApiClient.AddLoginAsync(loginReview);
            }
            var responseTokenFromReviewApi = await reviewApiClient.LoginAsync(loginReview);
            if (!string.IsNullOrEmpty(responseTokenFromReviewApi))
            {
                await userManager.SetAuthenticationTokenAsync(user, "ReviewsApi", "AuthToken", responseTokenFromReviewApi);
            }
            return Redirect(login.ReturnUrl);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Register register)
        {
            if (await userManager.FindByNameAsync(register.UserName) != null)
            {
                ModelState.AddModelError("UserName", "Логин занят");
            }
            else
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
                    return RedirectToAction(nameof(Login), new { returnUrl = register.ReturnUrl });
                }
                ModelState.AddModelError("Password", "Пароль должен содержать прописные и строчные буквы, цифры и символы");
            }
            return View(register);
        }
    }
}
