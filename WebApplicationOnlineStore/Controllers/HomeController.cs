using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
    }
}