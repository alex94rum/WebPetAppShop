using OnlineShop.Db.Model;

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