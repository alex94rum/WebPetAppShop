using System;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public class CartInMamoryRepos
    {
        private List<CartViewModel> carts = new List<CartViewModel>();

        public CartViewModel? TyGetByUserId(string userId)
        {
            return carts?.FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(ProductViewModel? product, string userId)
        {
            CartViewModel? existCart = TyGetByUserId(userId);

            if (existCart == null)
            {
                var newCart = new CartViewModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItemViewModel>()
                    {
                        new CartItemViewModel
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
                    existCart?.Items?.Add(new CartItemViewModel
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
            CartViewModel? existCart = TyGetByUserId(userId);
            CartItemViewModel? existCarItem = existCart?.Items?.FirstOrDefault(x => x?.Product?.Id == productId);

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
            CartViewModel? existCart = TyGetByUserId(userId);

            if (existCart != null)
            {
                carts.Remove(existCart);
            }
        }
    }
}
