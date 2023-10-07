using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProducts productsRepository;

        private readonly ICarts cartsRepository;

        private readonly IUsers usersRepository;
        public CartController(IProducts productsRepository, ICarts cartsRepository, IUsers usersReprository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.usersRepository = usersReprository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(usersRepository.UserId);
            return View(cart.ToCartViewModel());
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, usersRepository.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Remove(product, usersRepository.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear(string userId)
        {
            cartsRepository.Clear(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
