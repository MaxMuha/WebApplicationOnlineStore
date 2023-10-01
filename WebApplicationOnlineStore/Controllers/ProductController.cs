using Microsoft.AspNetCore.Mvc;

namespace WebApplicationOnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducts productsRepository;
        public ProductController(IProducts productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index(Guid id)
        {
            var product = productsRepository.TryGetById(id);

            return View(product);
        }
    }
}

