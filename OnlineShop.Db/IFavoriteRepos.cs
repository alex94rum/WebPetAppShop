using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IFavoriteRepos
    {
        public void Add(string userId, Product product);

        public void Clear(string userId);

        public List<Product> GetAll(string userId);

        public void Remove(string userId, Guid productId);
    }
}