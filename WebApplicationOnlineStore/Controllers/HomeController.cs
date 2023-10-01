using Microsoft.AspNetCore.Mvc;

namespace WebApplicationOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducts productsRepository;
        public HomeController(IProducts productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
    }
}