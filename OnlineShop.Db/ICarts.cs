using OnlineShop.Db.Models;
namespace OnlineShop.Db
{
    public interface ICarts
    {
        Task<Cart> TryGetByUserIdAsync(string userId);
        Task AddAsync(Product product, string userId);
        Task RemoveAsync(Product product, string userId);
        Task ClearAsync(string userId);
    }
}
