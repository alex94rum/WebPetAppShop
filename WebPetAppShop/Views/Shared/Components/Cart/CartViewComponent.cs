﻿using Microsoft.AspNetCore.Mvc;
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
            var cartDb = cartRepos.TyGetByUserId(Constans.UserId);
            var catViewModel = Mapping.ToCartViewModel(cartDb);
            var productCounts = catViewModel?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
