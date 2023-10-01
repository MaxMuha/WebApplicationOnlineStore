using Microsoft.AspNetCore.Mvc;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager usersManager;

        public AccountController(IUserManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Login));
            }

            var userAccount = usersManager.TryGetByName(login.UserName);

            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует!");
                return View(nameof(Login));
            }

            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Неправельный пароль!");
                return View(nameof(Login));
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    Name = register.UserName,
                    Password = register.Password,
                    Role = register.Role,
                    Id = register.Id
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(nameof(Register));
        }
    }
}
