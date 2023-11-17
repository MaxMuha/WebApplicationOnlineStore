using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Controllers
{
    [Authorize]
    public class WatchListController : Controller
    {
        private readonly IProducts productsRepository;

        private readonly IWatchList watchListRepository;
        public WatchListController(IProducts productsRepository, IWatchList watchListRepository)
        {
            this.productsRepository = productsRepository;
            this.watchListRepository = watchListRepository;
        }
        public IActionResult Index()
        {
            var productsDb = watchListRepository.GetAll(User.Identity.Name);
            return View(productsDb.ToProductViewModels());
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            watchListRepository.Add(User.Identity.Name, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            watchListRepository.Remove(User.Identity.Name, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
