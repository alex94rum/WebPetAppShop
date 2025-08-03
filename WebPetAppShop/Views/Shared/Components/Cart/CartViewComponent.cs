using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebPetAppShop.Helpers;

namespace WebPetAppShop.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartRepos cartRepos;

        public CartViewComponent(ICartRepos cartRepos)
        {
            this.cartRepos = cartRepos;
        }

        public IViewComponentResult Invoke()
        {
            var cartDb = cartRepos.TyGetByUserId(Constants.UserId);
            var catViewModel = cartDb.ToCartViewModel();
            var productCounts = catViewModel?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
