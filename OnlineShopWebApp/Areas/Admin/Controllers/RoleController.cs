using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.Select(role => role.ToRoleViewModel()).ToListAsync();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAsync(string name)
        {
            var role = await roleManager.FindByNameAsync(name);
            if (role != null)
            {
                await roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleViewModel role)
        {
            if (await roleManager.RoleExistsAsync(role.Name))
            {
                ModelState.AddModelError("Name", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                var newRole = new IdentityRole() { Name = role.Name };
                var result = await roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Name", error.Description);
                }
            }
            return View(role);
        }
    }
}
