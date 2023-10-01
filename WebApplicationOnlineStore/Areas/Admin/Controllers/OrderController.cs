using Microsoft.AspNetCore.Mvc;
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
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
