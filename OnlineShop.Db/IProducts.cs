using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IProducts
    {
        void Add(Product product);
        List<Product> GetAll();
        void Remove(Product product);
        Product TryGetById(Guid id);
        void Update(Product product);
    }
}
