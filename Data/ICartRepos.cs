using System;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public interface ICartRepos
    {
        void Add(Product? product, string userId);
        void Clear(string userId);
        void DecreasItem(Guid productId, string userId);
        Cart? TyGetByUserId(string userId);
    }
}