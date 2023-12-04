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
        public async Task AddAsync(string userId, Product product)
        {
            var existingProdcut = await databaseContext.WatchLists.FirstOrDefaultAsync(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProdcut == null)
            {
                databaseContext.WatchLists.Add(new WatchList { Product = product, UserId = userId });
                await databaseContext.SaveChangesAsync();
            }
        }
        public async Task ClearAsync(string userId)
        {
            var userWatchList = await databaseContext.WatchLists.Where(x => x.UserId == userId).ToListAsync();
            databaseContext.WatchLists.RemoveRange(userWatchList);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<List<Product>> GetAllAsync(string userId)
        {
            return await databaseContext.WatchLists.Where(x => x.UserId == userId).Include(x => x.Product).ThenInclude(x => x.Images).Select(x => x.Product).ToListAsync();
        }
        public async Task RemoveAsync(string userId, Guid productId)
        {
            var removeWatchListProduct = await databaseContext.WatchLists.FirstOrDefaultAsync(x => x.UserId == userId && x.Product.Id == productId);
            databaseContext.WatchLists.Remove(removeWatchListProduct);
            await databaseContext.SaveChangesAsync();
        }
    }
}
