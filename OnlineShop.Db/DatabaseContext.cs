using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        //Доступ к таблицам
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade); //Каскадное удаление

            var product1Id = Guid.Parse("88de934e-46ac-41f6-b72a-9a7ceb398d18");
            var product2Id = Guid.Parse("d31c3852-9e03-4b8a-a518-e1d876118fae");
            var product3Id = Guid.Parse("b6962658-3f60-4456-8df0-190e3b214204");
            var product4Id = Guid.Parse("62bf1a28-5acc-473a-9f2f-6b9c122d3223");

            var image1 = new Image
            {
                Id = Guid.Parse("1f9631b1-76cf-42f7-bd64-aee4386c9cad"),
                Url = "/images/Products/audiobox.png",
                ProductId = product1Id
            };
            var image2 = new Image
            {
                Id = Guid.Parse("19687918-a482-4e53-bda0-efb86bafdd86"),
                Url = "/images/Products/headphones.png",
                ProductId = product2Id
            };
            var image3 = new Image
            {
                Id = Guid.Parse("e8ae3598-9860-4d2d-9226-d6b70719aba8"),
                Url = "/images/Products/laptop.png",
                ProductId = product3Id
            };
            var image4 = new Image
            {
                Id = Guid.Parse("e6e1715b-bc6d-4b04-a6d3-dff4af6d44b0"),
                Url = "/images/Products/watch.png",
                ProductId = product4Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2, image3, image4); //создание таблицы image

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id,"Колонка","Никаких проводов. Никаких сложностей. Чистая магия.",1590),
                new Product(product2Id,"Наушники","Пространственное аудио и функция динамического отслеживания движений головы",1990),
                new Product(product3Id,"Ноутбук","Активное шумоподавление и Прозрачный режим",2550),
                new Product(product4Id,"Часы","До 20 часов прослушивания аудио без подзарядки",5900)
            });
        }
    }
}
