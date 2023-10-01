using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public class OrdersRepository : IOrders
    {
        private List<Order> orders = new List<Order>();
        public void Add(Order order)
        {
            orders.Add(order);
        }
        public List<Order>? GetAll()
        {
            return orders;
        }

        public Order TryGetById(Guid orderId)
        {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);
            if(order != null)
            {
                order.Status = newStatus;
            }
        }
    }
}
