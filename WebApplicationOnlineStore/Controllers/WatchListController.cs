using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Controllers
{
    public class WatchListController : Controller
    {
        private readonly IProducts productsRepository;

        private readonly IWatchList watchListRepository;

        private readonly IUsers usersRepository;
        public WatchListController(IProducts productsRepository, IWatchList watchListRepository, IUsers usersRepository)
        {
            this.productsRepository = productsRepository;
            this.watchListRepository = watchListRepository;
            this.usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            var productsDb = watchListRepository.GetAll(usersRepository.UserId);
            return View(productsDb.ToProductViewModels());
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            watchListRepository.Add(usersRepository.UserId, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            watchListRepository.Remove(usersRepository.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
