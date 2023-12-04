using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrders
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task AddAsync(Order order)
        {
            await databaseContext.Orders.AddAsync(order);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await databaseContext.Orders.Include(x => x.Form).Include(x => x.Items).ThenInclude(x => x.Product).ToListAsync();
        }

        public async Task<Order> TryGetByIdAsync(Guid orderId)
        {
            return await databaseContext.Orders.Include(x => x.Form).Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            var order = await TryGetByIdAsync(orderId);
            if(order != null)
            {
                order.Status = newStatus;
            }
            await databaseContext.SaveChangesAsync();
        }
    }
}
