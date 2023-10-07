using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {

        private readonly IOrders ordersRepository;
        public OrderController(IOrders ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(orders.ToOrderViewModels());
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order.ToOrderViewModel());
        }
        public IActionResult UpdateStatus(Guid orderId, OrderStatusViewModels status)
        {
            ordersRepository.UpdateStatus(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }
    }
}
