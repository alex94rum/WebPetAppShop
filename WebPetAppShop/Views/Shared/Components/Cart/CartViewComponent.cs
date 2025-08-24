using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebPetAppShop.Models;

namespace WebPetAppShop.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartRepos cartRepos;
        private readonly IMapper mapper;

        public CartViewComponent(ICartRepos cartRepos, IMapper mapper)
        {
            this.cartRepos = cartRepos;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var cartDb = cartRepos.TyGetByUserId(Constans.UserId);
            var catViewModel = mapper.Map<CartViewModel>(cartDb); // маппинг моделей
            var productCounts = catViewModel?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
