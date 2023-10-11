using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Areas.Admin.Models;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userAccounts = userManager.GetAll();
            return View(userAccounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Register user)
        {
            if (ModelState.IsValid)
            {
                userManager.Add(new UserAccount
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Password = user.Password,
                    Role = user.Role,
                });
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Details(Guid id)
        {
            var userAccount = userManager.TryGetById(id);
            return View(userAccount);
        }

        public IActionResult ChangePassword(Guid id)
        {
            var userAccount = userManager.TryGetById(id);

            var changePassword = new ChangePassword()
            {
                Id = id,
                UserName = userAccount.Name
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
                userManager.ChangePassword(changePassword.Id, changePassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(ChangePassword));
        }

        public IActionResult Edit(Guid id)
        {
            var userAccount = userManager.TryGetById(id);
            return View(userAccount);
        }
        [HttpPost]
        public IActionResult Edit(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userManager.Update(userAccount);
                return RedirectToAction(nameof(Index));
            }
            return View(userAccount);
        }

        public IActionResult Remove(Guid id)
        {
            var userAccount = userManager.TryGetById(id);
            userManager.Remove(userAccount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditRights(Guid id)
        {
            var userAccount = userManager.TryGetById(id);
            return View(userAccount);
        }

        [HttpPost]
        public IActionResult EditRights(Guid id, Role role)
        {
            if (ModelState.IsValid)
            {
                userManager.UpdateRole(id, role);
                return RedirectToAction(nameof(Index));
            }
            return View(id);
        }
    }
}
