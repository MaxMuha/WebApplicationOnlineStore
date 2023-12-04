using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducts productsRepository;
        public HomeController(IProducts productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productsRepository.GetAllAsync();
            return View(products.ToProductViewModels());
        }
    }
}