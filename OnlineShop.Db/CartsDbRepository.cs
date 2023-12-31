﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICarts
    {
        private readonly DatabaseContext databaseContext;
        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<Cart> TryGetByUserIdAsync(string userId)
        {
            return await databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Images).FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task AddAsync(Product product, string userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>
                {
                    new CartItem
                    {
                        Product = product,
                        Quantity = 1,
                    }
                };

                databaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Quantity = 1,
                        Product = product,
                    });
                }
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(Product product, string userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingCartItem.Quantity > 1)
            {
                existingCartItem.Quantity -= 1;
            }
            else
            {
                existingCart.Items.Remove(existingCartItem);
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task ClearAsync(string userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            databaseContext.Carts.Remove(existingCart);
            await databaseContext.SaveChangesAsync();
        }
    }
}
