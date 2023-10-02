using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Views.Shared.ViewsComponent.CartViewsComponent
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICarts cartsRepository;

        private readonly IUsers usersRepository;
        public CartViewComponent(ICarts cartsRepository, IUsers usersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.usersRepository = usersRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(usersRepository.UserId);

            var cartViewModel = Mapping.ToCartViewModel(cart);

            var productCounts = cartViewModel?.Quantity ?? 0;

            return View("Cart", productCounts);
        }
    }
}
