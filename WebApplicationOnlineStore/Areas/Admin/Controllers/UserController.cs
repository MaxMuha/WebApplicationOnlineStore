using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly RoleManager<IdentityRole> rolesManager;

        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> rolesManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.rolesManager = rolesManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users.Select(x => x.ToUserViewModel()).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                var user = new User { Email = register.UserName, UserName = register.UserName };
                //добавил пользователя
                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    //установка куки
                    signInManager.SignInAsync(user, false).Wait();
                    return Redirect(register.ReturnUrl ?? "/Admin/Home");
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

        public IActionResult Details(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
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
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(changePassword.UserName).Result;
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(ChangePassword));
        }

        public IActionResult Edit(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                userManager.UpdateAsync(user.ToUser()).Wait();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Remove(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditRights(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            var roles = rolesManager.Roles.ToList();
            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(role => new RoleViewModel { Name = role }).ToList(),
                AllRoles = roles.Select(role => new RoleViewModel { Name = role.Name }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditRights(string name, Dictionary<string, string> userRolesViewModel)
        {
            var userSelectdRoles = userRolesViewModel.Select(x => x.Key);
            var user = userManager.FindByNameAsync(name).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            userManager.RemoveFromRolesAsync(user, userRoles).Wait();
            userManager.AddToRolesAsync(user, userSelectdRoles).Wait();
            return RedirectToAction("Details", new { name });
        }
    }
}
