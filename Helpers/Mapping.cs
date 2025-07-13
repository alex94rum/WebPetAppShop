using OnlineShop.Db.Model;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductsViewModel(List<Product> productsDb) =>
            productsDb.Select(ToProductViewModel).ToList();

        public static ProductViewModel ToProductViewModel(Product productDb)
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

        public static List<CartItemViewModel> ToCartsItemViewModel(List<CartItem> cartsItemDb)
        {
            return cartsItemDb
                    .Select(c => new CartItemViewModel()
                    {
                        Id = c.Id,
                        Amount = c.Amount,
                        Product = ToProductViewModel(c.Product)
                    })
                    .ToList();
        }


        public static CartViewModel ToCartViewModel(Cart cartDb)
        {
            return new CartViewModel()
            {
                Id = cartDb.Id,
                UserId = cartDb.UserId,
                Items = ToCartsItemViewModel(cartDb.Items),
            };
        }
    }
}
