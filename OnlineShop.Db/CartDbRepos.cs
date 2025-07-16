using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;

namespace OnlineShop.Db
{
    public class CartDbRepos : ICartRepos
    {
        private readonly DatabaseContext databaseContext;

        public CartDbRepos(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Cart? TyGetByUserId(string userId)
        {
            return this.databaseContext.Carts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            Cart? existCart = TyGetByUserId(userId);

            if (existCart == null)
            {
                var newCart = new Cart()
                {
                    UserId = userId,
                };


                newCart.Items = new List<CartItem>()
                {
                    new CartItem
                    {
                        Amount = 1,
                        Product = product,
                        Cart = newCart,
                    }
                };

                this.databaseContext.Carts.Add(newCart);
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
                        Amount = 1,
                        Product = product,
                        Cart = existCart,
                    });
                }
            }

            this.databaseContext.SaveChanges();
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

            this.databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            Cart? existCart = TyGetByUserId(userId);

            if (existCart != null)
            {
                this.databaseContext.Remove(existCart);
            }

            this.databaseContext.SaveChanges();
        }
    }
}
