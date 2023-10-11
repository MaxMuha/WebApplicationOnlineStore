using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace WebApplicationOnlineStore.Views.Shared.ViewsComponent.CartViewsComponent
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
            var productCounts = watchListRepository.GetAll(Constants.UserId).Count();

            return View("WatchList", productCounts);
        }
    }
}
