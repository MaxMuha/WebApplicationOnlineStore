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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCounts = await watchListRepository.GetAllAsync(User.Identity.Name);

            return View("WatchList", productCounts.Count());
        }
    }
}
