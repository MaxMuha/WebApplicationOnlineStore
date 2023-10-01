using Microsoft.AspNetCore.Mvc;

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

            var productCounts = cart?.Quantity;

            return View("Cart", productCounts);
        }
    }
}
