using System;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public class CartInMamoryRepos : ICartRepos
    {
        private List<Cart> carts = new List<Cart>();

        public Cart? TyGetByUserId(string userId)
        {
            return carts?.FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Product? product, string userId)
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

        public void DecreasItem(Guid productId, string userId)
        {
            Cart? existCart = TyGetByUserId(userId);
            CartItem? existCarItem = existCart?.Items?.FirstOrDefault(x => x?.Product?.Id == productId);

            if (existCarItem == null)
            {
                return;
            }
            
            existCarItem.Amount -= 1;

            if (existCarItem?.Amount == 0)
            {
                existCart?.Items?.Remove(existCarItem);
            }
        }

        public void Clear(string userId)
        {
            Cart? existCart = TyGetByUserId(userId);

            if (existCart != null)
            {
                carts.Remove(existCart);
            }
        }
    }
}
