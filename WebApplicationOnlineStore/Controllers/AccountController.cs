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

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return View(user.ToUserViewModel());
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);

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
        public async Task<IActionResult> RegisterAsync(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                var user = new User { Email = register.UserName,  UserName = register.UserName, AvatarPath = "/images/Profiles/BIG.png" };
                //добавил пользователя
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    //установка куки
                    await signInManager.SignInAsync(user, false);
                    await TryAssignUserRoleAsync(user);
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

        public async Task<IActionResult> LogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
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
                var imagePath = imagesProvider.SafeFile(user.UploadedFile, ImageFolders.Profiles);

                var existingUser = await userManager.FindByNameAsync(User.Identity.Name);

                existingUser.Update(imagePath);

                await userManager.UpdateAsync(existingUser);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> AvatarPathAsync()
        {
            var avatarPath = await userManager.FindByNameAsync(User.Identity.Name);
            return Content(avatarPath.AvatarPath);
        }
    }
}
