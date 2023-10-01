using Microsoft.AspNetCore.Mvc;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoles rolesRepository;
        public RoleController(IRoles rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }
        public IActionResult Index()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
        public IActionResult Remove(string name)
        {
            var roles = rolesRepository.TryGetByName(name);
            rolesRepository.Remove(roles);
            return RedirectToAction(nameof(Index));
        }
    }
}
