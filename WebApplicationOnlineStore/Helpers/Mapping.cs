using Microsoft.Extensions.Diagnostics.HealthChecks;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System.Net.WebSockets;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImgLink = product.ImgLink,
            };
        }

        public static List<CartItemViewModel> ToCarItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach(var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Quantity = cartDbItem.Quantity,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if(cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCarItemViewModels(cart.Items)
            };
        }
    }
}
