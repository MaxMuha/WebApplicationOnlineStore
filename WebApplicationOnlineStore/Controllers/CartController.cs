using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProducts productsRepository;

        private readonly ICarts cartsRepository;
        public CartController(IProducts productsRepository, ICarts cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }
        public async Task<IActionResult> Index()
        {
            var cart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);
            return View(cart.ToCartViewModel());
        }
        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            await cartsRepository.AddAsync(product, User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            await cartsRepository.RemoveAsync(product, User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ClearAsync(string userId)
        {
            await cartsRepository.ClearAsync(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
