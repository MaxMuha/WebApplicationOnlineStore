using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public class CartsRepository : ICarts
    {
        private List<Cart> carts = new List<Cart>();
        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(ProductViewModel product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Product = product,
                            Quantity = 1
                        }
                    }
                };

                carts.Add(newCart);
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
                        Id = Guid.NewGuid(),
                        Quantity = 1,
                        Product = product
                    });
                }
            }
        }
        public void Remove(ProductViewModel product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingCartItem.Quantity > 1)
            {
                existingCartItem.Quantity -= 1;
            }
            else
            {
                existingCart.Items.Remove(existingCartItem);
            }
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            carts.Remove(existingCart);
        }
    }
}
