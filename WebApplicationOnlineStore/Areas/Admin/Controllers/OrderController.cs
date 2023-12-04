using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Helpers;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize (Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrders ordersRepository;
        public OrderController(IOrders ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public async Task<IActionResult> Index()
        {
            int idThreadBefore = Thread.CurrentThread.ManagedThreadId;
            var orders = await ordersRepository.GetAllAsync();
            int idThreadAfter = Thread.CurrentThread.ManagedThreadId;
            return View(orders.ToOrderViewModels());
        }
        public async Task<IActionResult> DetailsAsync(Guid orderId)
        {
            var order = await ordersRepository.TryGetByIdAsync(orderId);
            return View(order.ToOrderViewModel());
        }
        public async Task<IActionResult> UpdateStatusAsync(Guid orderId, OrderStatusViewModels status)
        {
            await ordersRepository.UpdateStatusAsync(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }
    }
}
