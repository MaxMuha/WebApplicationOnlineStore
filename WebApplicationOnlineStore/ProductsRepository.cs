using WebApplicationOnlineStore.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationOnlineStore
{
    public class ProductsRepository : IProducts
    {
        private List<Product> products = new List<Product>()
        {
            new Product ("Колонка","Никаких проводов. Никаких сложностей. Чистая магия.",1590, "/image/Prod/audiobox.png"),
            new Product ("Наушники","Пространственное аудио и функция динамического отслеживания движений головы",1990 , "/image/Prod/headphones.png"),
            new Product ("Ноутбук","Активное шумоподавление и Прозрачный режим",2550, "/image/Prod/laptop.png"),
            new Product ("Часы","До 20 часов прослушивания аудио без подзарядки",5900, "/image/Prod/watch.png"),
        };

        public List<Product> GetAll() 
        {
            return products;
        }

        public Product TryGetById(Guid id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            existingProduct.ImgLink = product.ImgLink;
        }

        public void Remove(Product product)
        {
            products.Remove(product);
        }
    }
}
