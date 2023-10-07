using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

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
            return View(products.ToProductViewModels());
        }
    }
}