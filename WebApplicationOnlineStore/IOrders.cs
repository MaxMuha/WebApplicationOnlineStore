using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public interface IOrders
    {
        void Add(Order order);
        List<Order>? GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}