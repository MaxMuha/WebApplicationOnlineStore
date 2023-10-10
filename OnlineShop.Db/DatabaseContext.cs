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
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product("Колонка","Никаких проводов. Никаких сложностей. Чистая магия.",1590,"/image/Prod/audiobox.png"),
                new Product("Наушники","Пространственное аудио и функция динамического отслеживания движений головы",1990,"/image/Prod/headphones.png"),
                new Product("Ноутбук","Активное шумоподавление и Прозрачный режим",2550,"/image/Prod/laptop.png"),
                new Product("Часы","До 20 часов прослушивания аудио без подзарядки",5900,"/image/Prod/watch.png")
            });
        }
    }
}
