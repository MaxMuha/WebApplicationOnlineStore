using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICarts cartsRepository;

        private readonly IUsers usersRepository;

        private readonly IOrders ordersRepository;
        public OrderController(ICarts cartsRepository, IUsers usersRepository, IOrders ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.usersRepository = usersRepository;
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
        public IActionResult Buy(DeliveryOrderForm form)
        {
            if(ModelState.IsValid)
            {
                var existingCart = cartsRepository.TryGetByUserId(usersRepository.UserId);

                var existingCartViewModel = Mapping.ToCartViewModel(existingCart);

                var order = new Order
                {
                    Form = form,
                    OrderItems = existingCartViewModel.Items
                };

                ordersRepository.Add(order);

                cartsRepository.Clear(usersRepository.UserId);

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }
    }
}
