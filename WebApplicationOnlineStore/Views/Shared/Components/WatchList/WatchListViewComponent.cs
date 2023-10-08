using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace WebApplicationOnlineStore.Views.Shared.ViewsComponent.CartViewsComponent
{
    public class WatchListViewComponent : ViewComponent
    {
        private readonly IWatchList watchListRepository;

        private readonly IUsers usersRepository;
        public WatchListViewComponent(IWatchList watchListRepository, IUsers usersRepository)
        {
            this.watchListRepository = watchListRepository;
            this.usersRepository = usersRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productCounts = watchListRepository.GetAll(usersRepository.UserId).Count();

            return View("WatchList", productCounts);
        }
    }
}
