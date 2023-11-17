using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Views.Shared.Components.Account.AccountViewComponent
{
    public class AccountViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;
        public AccountViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userDb = userManager.FindByNameAsync(User.Identity.Name).Result;

            var userAvatar = userDb.AvatarPath;

            return View("Account", userAvatar);
        }
    }
}
