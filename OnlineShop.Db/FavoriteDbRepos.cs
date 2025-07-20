using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class FavoriteDbRepos : IFavoriteRepos
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteDbRepos(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, Product product)
        {
            var existingProduct = this.databaseContext.FavoriteProducts
                .FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);

            if (existingProduct == null)
            {
                this.databaseContext.FavoriteProducts
                        .Add(new FavoriteProduct
                            {
                                UserId = userId,
                                Product = product,
                            });
                this.databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userFavoriteProducts = this.databaseContext.FavoriteProducts.Where(p => p.UserId == userId).ToList();
            this.databaseContext.FavoriteProducts.RemoveRange(userFavoriteProducts);
            this.databaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return this.databaseContext.FavoriteProducts.Where(x => x.UserId == userId)
                                                        .Include(x => x.Product)
                                                        .Select(x => x.Product)
                                                        .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removingFavorite = this.databaseContext.FavoriteProducts
                                        .FirstOrDefault(u => u.UserId == userId && u.Product.Id == productId);
            if (removingFavorite != null)
            {
                this.databaseContext.FavoriteProducts.Remove(removingFavorite);
                this.databaseContext.SaveChanges();
            }
        }
    }
}
