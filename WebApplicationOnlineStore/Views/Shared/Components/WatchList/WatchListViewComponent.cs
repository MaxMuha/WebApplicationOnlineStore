using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace WebApplicationOnlineStore.Views.Shared.Components.Watch.WatchViewComponent
{
    public class WatchListViewComponent : ViewComponent
    {
        private readonly IWatchList watchListRepository;
        public WatchListViewComponent(IWatchList watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productCounts = watchListRepository.GetAll(User.Identity.Name).Count();

            return View("WatchList", productCounts);
        }
    }
}
