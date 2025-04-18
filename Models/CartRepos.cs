using System;
using System.Collections.Generic;
using System.Linq;

namespace WebPetAppShop.Models
{
    public static class CartRepos
    {
        private static List<Cart> carts = new List<Cart>();

        public static Cart? TyGetByUserId(string userId)
        {
            return carts?.FirstOrDefault(c => c.UserId == userId);
        }

        public static void Add(Product? product, string userId)
        {
            Cart? existCart = TyGetByUserId(userId);

            if (existCart == null)
            {
                var newCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>()
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product,
                        }
                    }
                };

                carts.Add(newCart);
            }
            else
            {
                var existCarItem = existCart?.Items?.FirstOrDefault(x => x?.Product?.Id == product?.Id);
                if (existCarItem != null)
                {
                    existCarItem.Amount += 1;
                }
                else
                {
                    existCart?.Items?.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product,
                    });
                }
            }
        }
    }
}
