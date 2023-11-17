using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System.Linq;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly ImagesProvider imagesProvider;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ImagesProvider imagesProvider)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.imagesProvider = imagesProvider;
        }

        public IActionResult Index()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user.ToUserViewModel());
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль!");
                }
            }

            return View(login);
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl });
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
                var user = new User { Email = register.UserName,  UserName = register.UserName, AvatarPath = "/images/Profiles/BIG.png" };
                //добавил пользователя
                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    //установка куки
                    signInManager.SignInAsync(user, false).Wait();
                    TryAssignUserRole(user);
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

        public void TryAssignUserRole(User user)
        {
            try
            {
                userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch
            {
                //log
            }
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
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
                var imagePath = imagesProvider.SafeFile(user.UploadedFile, ImageFolders.Profiles);

                var existingUser = userManager.FindByNameAsync(User.Identity.Name).Result;

                existingUser.Update(imagePath);

                userManager.UpdateAsync(existingUser).Wait();

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult AvatarPath()
        {
            var avatarPath = userManager.FindByNameAsync(User.Identity.Name).Result.AvatarPath;
            return Content(avatarPath);
        }
    }
}
