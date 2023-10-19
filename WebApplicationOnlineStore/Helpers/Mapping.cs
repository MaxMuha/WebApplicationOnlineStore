using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using WebApplicationOnlineStore.Areas.Admin.Models;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(product.ToProductViewModel());
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImagesPaths = product.Images.Select(x => x.Url).ToArray()
            };
        }

        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                Cost = productViewModel.Cost,
                //Images = ToImages(imagesPaths)
            };
        }

        public static Product ToProduct(this CreateProductViewModel createProductViewModel, List<string> imagesPaths)
        {
            return new Product
            {
                Name = createProductViewModel.Name,
                Description = createProductViewModel.Description,
                Cost = createProductViewModel.Cost,
                Images = ToImages(imagesPaths)
            };
        }

        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImagesPaths = product.Images.ToPaths()
            };
        }

        public static Product ToProduct(this EditProductViewModel editProduct)
        {
            return new Product
            {
                Id = editProduct.Id,
                Name = editProduct.Name,
                Description = editProduct.Description,
                Cost = editProduct.Cost,
                Images = editProduct.ImagesPaths.ToImages()
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }

        public static List<string> ToPaths(this List<Image> paths)
        {
            return paths.Select(x => x.Url).ToList();
        }

        public static List<CartItemViewModel> ToCarItemViewModels(this List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach(var cartDbItem in cartDbItems)
            {
                var cartItemViewModel = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Quantity = cartDbItem.Quantity,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItemViewModel);
            }
            return cartItems;
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
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
        public static DeliveryOrderForm ToDeliveryOrderForm(this DeliveryOrderFormViewModel form)
        {
            return new DeliveryOrderForm
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Address = form.Address,
                City = form.City,
                Email = form.Email,
                Phone = form.Phone,
                PostalCode = form.PostalCode,
                Region = form.Region,
            };
        }

        public static DeliveryOrderFormViewModel ToDeliveryOrderFormViewModel(this DeliveryOrderForm form)
        {
            return new DeliveryOrderFormViewModel
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Address = form.Address,
                City = form.City,
                Email = form.Email,
                Phone = form.Phone,
                PostalCode = form.PostalCode,
                Region = form.Region,
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Items = ToCarItemViewModels(order.Items),
                CreateDateTime = order.CreateDateTime,
                Form = ToDeliveryOrderFormViewModel(order.Form),
                Status = (OrderStatusViewModels)(int)order.Status,
            };
        }
        public static List<OrderViewModel> ToOrderViewModels(this List<Order> orders)
        {
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                orderViewModels.Add(ToOrderViewModel(order));
            }
            return orderViewModels;
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Name = user.UserName,
                Password = user.PasswordHash
            };
        }

        public static User ToUser(this UserViewModel user)
        {
            return new User
            {
                UserName = user.Name,
            };
        }

        public static List<RoleViewModel> ToRoleViewModels(this List<IdentityRole> roles)
        {
            var rolesViewModels = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                rolesViewModels.Add(ToRoleViewModel(role));
            }
            return rolesViewModels;
        }

        public static RoleViewModel ToRoleViewModel(this IdentityRole role)
        {
            return new RoleViewModel
            {
                Name = role.Name
            };
        }
    }
}
