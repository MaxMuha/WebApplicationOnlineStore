﻿namespace WebApplicationOnlineStore.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set;}
        public decimal Total //итоговая сумма
        {
            get
            {
                return Items?.Sum(i => i.Amount) ?? 0;
            } 
        }

        public int Quantity //количество товара
        {
            get
            {
                return Items?.Sum(i => i.Quantity) ?? 0;
            }
        }
    }
}
