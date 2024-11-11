using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static Product ToProductDb(this ProductViewModel productViewModel)
        {
            var product = new Product()
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name!,
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                ActiveIndexImagePath = productViewModel.ActiveIndexImagePath,
            };
            foreach(var path in productViewModel.ImagesPaths)
            {
                product.ImagesPaths.Add(path);
            }
            return product;
        }
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ActiveIndexImagePath = product.ActiveIndexImagePath,
            };
            foreach (var path in product.ImagesPaths)
            {
                productViewModel.ImagesPaths.Add(path);
            }
            return productViewModel;
        }
        public static List<ProductViewModel> ToProductsViewModel(this List<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModel.Add(ToProductViewModel(product));
            }
            return productsViewModel;
        }
        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
            {
                return null!;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                Items = ToCartItemsViewModel(cart.Items!)
            };
        }
        public static CartItem ToCartItemDb(this CartItemViewModel cartItemViewModel)
        {
            return new CartItem
            {
                Id = cartItemViewModel.Id,
                Product = ToProductDb(cartItemViewModel.Product!),
                Amount = cartItemViewModel.Amount
            };
        }
        public static CartItemViewModel ToCartItemViewModel(this CartItem cartItem)
        {
            return new CartItemViewModel
            {
                Id = cartItem.Id,
                Product = ToProductViewModel(cartItem.Product!),
                Amount = cartItem.Amount
            };
        }
        public static List<CartItem> ToCartItemsDb(this List<CartItemViewModel> cartItemViewModels)
        {
            var cartItems = new List<CartItem>();
            foreach (var item in cartItemViewModels)
            {
                cartItems.Add(ToCartItemDb(item));
            }
            return cartItems;
        }
        public static List<CartItemViewModel> ToCartItemsViewModel(this List<CartItem> cartItems)
        {
            var cartItemsViewModel = new List<CartItemViewModel>();
            foreach (var item in cartItems)
            {
                cartItemsViewModel.Add(ToCartItemViewModel(item));
            }
            return cartItemsViewModel;
        }
        public static FavoritesViewModel ToFavoritesViewModel(this Favorites favorites)
        {
            if (favorites == null)
            {
                return null;
            }
            return new FavoritesViewModel
            {
                Id = favorites.Id,
                UserName = favorites.UserName,
                Products = ToProductsViewModel(favorites.Products!)
            };
        }
        public static OrderInfo ToOrderInfoDb(this OrderInfoViewModel orderInfoViewModel)
        {
            return new OrderInfo
            {
                Id = orderInfoViewModel.Id,
                FullName = orderInfoViewModel.FullName,
                Email = orderInfoViewModel.Email,
                Tel = orderInfoViewModel.Tel,
                Address = orderInfoViewModel.Address,
                Comment = orderInfoViewModel.Comment
            };
        }
        public static OrderInfoViewModel ToOrderInfoViewModel(this OrderInfo orderInfo)
        {
            if (orderInfo == null)
            {
                return null;
            }
            return new OrderInfoViewModel
            {
                Id = orderInfo.Id,
                FullName = orderInfo.FullName,
                Email = orderInfo.Email,
                Tel = orderInfo.Tel,
                Address = orderInfo.Address,
                Comment = orderInfo.Comment
            };
        }
        public static Order ToOrderDb(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                Id = orderViewModel.Id,
                DateTime = orderViewModel.DateTime,
                UserName = orderViewModel.UserName,
                Info = ToOrderInfoDb(orderViewModel.Info),
                Items = ToCartItemsDb(orderViewModel.Items)
            };
        }
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                DateTime = order.DateTime,
                UserName = order.UserName,
                Info = ToOrderInfoViewModel(order.Info),
                Items = ToCartItemsViewModel(order.Items),
                Status = order.Status
            };
        }
        public static List<OrderViewModel> ToOrdersViewModel(this List<Order> orders)
        {
            var ordersViewModel = new List<OrderViewModel>();
            foreach (var item in orders)
            {
                ordersViewModel.Add(ToOrderViewModel(item));
            }
            return ordersViewModel;
        }
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel()
            {
                Name = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
            };
        }
        public static RoleViewModel ToRoleViewModel(this IdentityRole role)
        {
            return new RoleViewModel()
            {
                Name = role.Name
            };
        }
    }
}
