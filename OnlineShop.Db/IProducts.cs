using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IProducts
    {
        Task AddAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task RemoveAsync(Product product);
        Task<Product> TryGetByIdAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}
