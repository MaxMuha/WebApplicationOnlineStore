using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Views.Shared.ViewsComponent.CartViewsComponent
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICarts cartsRepository;
        public CartViewComponent(ICarts cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cartDb = cartsRepository.TryGetByUserId(Constants.UserId);

            var cartViewModel = cartDb.ToCartViewModel();

            var productCounts = cartViewModel?.Quantity ?? 0;

            return View("Cart", productCounts);
        }
    }
}
