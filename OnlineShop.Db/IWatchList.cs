using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IWatchList
    {
        Task AddAsync(string userId, Product product);
        Task ClearAsync(string userId);
        Task<List<Product>> GetAllAsync(string userId);
        Task RemoveAsync(string userId, Guid productId);
    };
}