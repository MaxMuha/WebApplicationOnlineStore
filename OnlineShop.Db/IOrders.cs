using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IOrders
    {
        Task AddAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order> TryGetByIdAsync(Guid orderId);
        Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus);
    }
}