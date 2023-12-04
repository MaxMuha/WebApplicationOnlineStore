using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProducts
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await databaseContext.Products.Include(x => x.Images).ToListAsync();
        }

        public async Task<Product> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Products.Include(x => x.Images).FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            databaseContext.Products.Add(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await databaseContext.Products.Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;

            foreach (var image in product.Images)
            {
                image.ProductId = product.Id;
                databaseContext.Images.Add(image);
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product product)
        {
            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync();
        }
    }
}
