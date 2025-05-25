using Microsoft.AspNetCore.Mvc;
using WebPetAppShop.Data;

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
            var cart = cartRepos.TyGetByUserId(Constans.UserId);
            var productCounts = cart?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
