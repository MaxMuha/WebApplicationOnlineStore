using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Areas.Admin.Models;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {

        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> rolesManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> rolesManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.rolesManager = rolesManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            return View(users.Select(x => x.ToUserViewModel()).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                var user = new User { Email = register.UserName, UserName = register.UserName };
                //добавил пользователя
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    //signInManager.SignInAsync(user, false).Wait();
                    TryAssignUserRoleAsync(user);
                    return Redirect(register.ReturnUrl ?? "/Admin/User");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

        public async Task TryAssignUserRoleAsync(User user)
        {
            try
            {
                await userManager.AddToRoleAsync(user, Constants.UserRoleName);
            }
            catch
            {
                //log
            }
        }

        public async Task<IActionResult> DetailsAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            return View(user.ToUserViewModel());
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name
            };

            return View(changePassword);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(changePassword.UserName);
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                await userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(ChangePassword));
        }

        public async Task<IActionResult> EditAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            return View(user.ToUserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await userManager.UpdateAsync(user.ToUser());
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> RemoveAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditRightsAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            var userRoles = await userManager.GetRolesAsync(user);
            var roles = await rolesManager.Roles.ToListAsync();
            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(role => new RoleViewModel { Name = role }).ToList(),
                AllRoles = roles.Select(role => new RoleViewModel { Name = role.Name }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRightsAsync(string name, Dictionary<string, string> userRolesViewModel)
        {
            var userSelectdRoles = userRolesViewModel.Select(x => x.Key);
            var user = await userManager.FindByNameAsync(name);
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);
            await userManager.AddToRolesAsync(user, userSelectdRoles);
            return RedirectToAction("Details", new { name });
        }
    }
}
