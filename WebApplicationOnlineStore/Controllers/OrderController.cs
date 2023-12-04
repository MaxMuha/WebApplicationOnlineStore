using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICarts cartsRepository;

        private readonly IOrders ordersRepository;
        public OrderController(ICarts cartsRepository, IOrders ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyAsync(DeliveryOrderFormViewModel form)
        {
            if(ModelState.IsValid)
            {
                var existingCart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);

                var orderDb = new Order
                {
                    Form = form.ToDeliveryOrderForm(),
                    Items = existingCart.Items,
                };

                await ordersRepository.AddAsync(orderDb);

                await cartsRepository.ClearAsync(User.Identity.Name);

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }
    }
}
