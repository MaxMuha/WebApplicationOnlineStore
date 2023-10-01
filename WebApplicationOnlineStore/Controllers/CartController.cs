using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Models;

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
            return View(cart);
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImgLink = product.ImgLink,
            };
            cartsRepository.Add(productViewModel, usersRepository.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImgLink = product.ImgLink,
            };
            cartsRepository.Remove(productViewModel, usersRepository.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(string userId)
        {
            cartsRepository.Clear(userId);
            return RedirectToAction("Index");
        }
    }
}
