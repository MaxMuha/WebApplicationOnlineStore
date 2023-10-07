using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IOrders
    {
        void Add(Order order);
        List<Order>? GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}