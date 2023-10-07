using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        //Доступ к таблицам
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) 
        {
            Database.EnsureCreated(); //Создаем базу данных при первом обращении
        }
    }
}
