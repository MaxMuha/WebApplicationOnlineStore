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
        public async Task<IActionResult> Index()
        {
            var productsDb = await watchListRepository.GetAllAsync(User.Identity.Name);
            return View(productsDb.ToProductViewModels());
        }
        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            await watchListRepository.AddAsync(User.Identity.Name, product);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            await watchListRepository.RemoveAsync(User.Identity.Name, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
