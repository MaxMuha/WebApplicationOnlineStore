using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class WatchListDbRepository : IWatchList
    {
        private readonly DatabaseContext databaseContext;

        public WatchListDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, Product product)
        {
            var existingProdcut = databaseContext.WatchLists.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProdcut == null)
            {
                databaseContext.WatchLists.Add(new WatchList { Product = product, UserId = userId });
                databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userWatchList = databaseContext.WatchLists.Where(x => x.UserId == userId).ToList();
            databaseContext.WatchLists.RemoveRange(userWatchList);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId) 
        {
            return databaseContext.WatchLists.Where(x=>x.UserId == userId).Include(x=>x.Product).Select(x => x.Product).ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removeWatchListProduct = databaseContext.WatchLists.FirstOrDefault(x =>x.UserId == userId && x.Product.Id == productId);
            databaseContext.WatchLists.Remove(removeWatchListProduct);
            databaseContext.SaveChanges();
        }
    }
}
