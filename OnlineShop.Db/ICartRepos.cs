using OnlineShop.Db.Model;
using System;

namespace OnlineShop.Db
{
    public interface ICartRepos
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void DecreasItem(Guid productId, string userId);
        Cart? TyGetByUserId(string userId);
    }
}