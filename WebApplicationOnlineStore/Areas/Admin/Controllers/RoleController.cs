using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using System.Data;
using WebApplicationOnlineStore.Areas.Admin.Models;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> rolesManager;
        public RoleController(RoleManager<IdentityRole> rolesManager)
        {
            this.rolesManager = rolesManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await rolesManager.Roles.ToListAsync();
            return View(roles.ToRoleViewModels());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleViewModel role)
        {
            var result = await rolesManager.CreateAsync(new IdentityRole(role.Name));
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(role);
        }
        public async Task<IActionResult> RemoveAsync(string name)
        {
            var role = await rolesManager.FindByNameAsync(name);
            if(role != null)
            {
                await rolesManager.DeleteAsync(role);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
