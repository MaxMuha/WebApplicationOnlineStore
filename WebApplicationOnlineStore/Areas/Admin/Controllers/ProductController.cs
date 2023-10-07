using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProducts productsRepository;
        public ProductController(IProducts productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products.ToProductViewModels());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Add(product.ToProduct());
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Update(product.ToProduct());
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Remove(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            productsRepository.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
