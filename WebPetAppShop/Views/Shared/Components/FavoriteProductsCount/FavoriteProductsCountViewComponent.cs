using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace WebPetAppShop.Views.Shared.Components.FavoriteProductsCount
{
    public class FavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepos favoriteRepos;

        public FavoriteProductsCountViewComponent(IFavoriteRepos favoriteRepos)
        {
            this.favoriteRepos = favoriteRepos;
        }

        public IViewComponentResult Invoke()
        {
            var producCounts = this.favoriteRepos.GetAll(Constants.UserId).Count;

            return View("FavoriteProductsCount", producCounts);
        }
    }
}
