﻿namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string ImgLink { get; set; }
        public List<CartItem> Items { get; set; }
        public Product()
        {
            Items = new List<CartItem>();
        }
    }
}
