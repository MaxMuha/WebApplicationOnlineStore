using Microsoft.AspNetCore.Mvc;
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
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Add(product);
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
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Update(product);
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
