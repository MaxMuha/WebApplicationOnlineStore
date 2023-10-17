using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        public List<CartItem> Items { get; set; }
        public List<Image> Images { get; set; }
        public Product(Guid id, string name, string description, decimal cost) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
        }
        public Product()
        {
            Items = new List<CartItem>();
            Images = new List<Image>();
        }
    }
}
