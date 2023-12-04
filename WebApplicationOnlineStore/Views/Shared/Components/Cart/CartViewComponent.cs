using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Views.Shared.Components.Cart.CartViewComponent
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICarts cartsRepository;
        public CartViewComponent(ICarts cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartDb = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);

            var cartViewModel = cartDb.ToCartViewModel();

            var productCounts = cartViewModel?.Quantity ?? 0;

            return View("Cart", productCounts);
        }
    }
}
