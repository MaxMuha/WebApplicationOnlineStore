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
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart.ToCartViewModel());
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Remove(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear(string userId)
        {
            cartsRepository.Clear(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
