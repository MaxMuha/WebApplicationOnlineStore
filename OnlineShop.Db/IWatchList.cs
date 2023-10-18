using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IWatchList
    {
        void Add(string userId, Product product);
        void Clear(string userId);
        List<Product> GetAll(string userId);
        void Remove(string userId, Guid productId);

    };
}