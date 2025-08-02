using OnlineShop.Db.Model;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductsViewModel(this List<Product> productsDb) =>
            productsDb.Select(ToProductViewModel).ToList();

        public static ProductViewModel ToProductViewModel(this Product productDb)
        {
            return new ProductViewModel()
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Cost = productDb.Cost,
                Description = productDb.Description,
                ImagePath = productDb.ImagePath,
            };
        }

        public static List<CartItemViewModel> ToCartsItemViewModel(this List<CartItem> cartsItemDb)
        {
            return cartsItemDb
                    .Select(c => new CartItemViewModel()
                    {
                        Id = c.Id,
                        Amount = c.Amount,
                        Product = c.Product.ToProductViewModel()
                    })
                    .ToList();
        }


        public static CartViewModel ToCartViewModel(this Cart cartDb)
        {
            if (cartDb == null)
            {
                return null;
            }

            return new CartViewModel()
            {
                Id = cartDb.Id,
                UserId = cartDb.UserId,
                Items = cartDb.Items.ToCartsItemViewModel(),
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreatedDataTime = order.CreatedDataTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                UserInfo = order.UserInfo.ToUserDeliveryInfoViewModel(),
                Items = order.Items.ToCartsItemViewModel(),
            };
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo deliveryInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = deliveryInfo.Name,
                Adress = deliveryInfo.Adress,
                Phone = deliveryInfo.Phone,
            };
        }

        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel user)
        {
            return new UserDeliveryInfo
            {
                Name = user.Name,
                Adress = user.Adress,
                Phone = user.Phone,
            };
        }
    }
}
