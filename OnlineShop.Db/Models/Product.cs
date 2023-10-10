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
        public string ImgLink { get; set; }
        public List<CartItem> Items { get; set; }
        public Product()
        {
            Items = new List<CartItem>();
        }
        public Product(string name, string description, decimal cost, string imgLink)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Cost = cost;
            ImgLink = imgLink;
        }
    }
}
