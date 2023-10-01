using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
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
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Cost = product.Cost,
                    ImgLink = product.ImgLink,
                };
                productsViewModels.Add(productViewModel);
            }
            return View(productsViewModels);
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
                var productDb = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Cost = product.Cost,
                    ImgLink = product.ImgLink,
                };
                productsRepository.Add(productDb);
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
                var productDb = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Cost = product.Cost,
                    ImgLink = product.ImgLink,
                };
                productsRepository.Update(productDb);
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
