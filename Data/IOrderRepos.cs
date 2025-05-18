using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public interface IOrderRepos
    {
        void Add(Cart cart);
    }
}