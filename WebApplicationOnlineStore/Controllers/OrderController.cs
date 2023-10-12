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
        public IActionResult Buy(DeliveryOrderFormViewModel form)
        {
            if(ModelState.IsValid)
            {
                var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);

                var orderDb = new Order
                {
                    Form = form.ToDeliveryOrderForm(),
                    Items = existingCart.Items,
                };

                ordersRepository.Add(orderDb);

                cartsRepository.Clear(Constants.UserId);

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }
    }
}
