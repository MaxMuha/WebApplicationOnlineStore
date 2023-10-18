using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducts productsRepository;
        public ProductController(IProducts productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);

            return View(product.ToProductViewModel());
        }
    }
}

