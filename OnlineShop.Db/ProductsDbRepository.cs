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

        public List<Product> GetAll()
        {
            return databaseContext.Products.Include(x => x.Images).ToList();
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.Include(x => x.Images).FirstOrDefault(product => product.Id == id);
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = databaseContext.Products.Include(x => x.Images).FirstOrDefault(x => x.Id == product.Id);
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
            databaseContext.SaveChanges();
        }

        public void Remove(Product product)
        {
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }
    }
}
