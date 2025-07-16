using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Data;
using WebPetAppShop.Helpers;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepos productRepos;
        private readonly ICartRepos cartRepos;

        public CartController(IProductRepos productRepos, ICartRepos cartRepos)
        {
            this.productRepos = productRepos;
            this.cartRepos = cartRepos;
        }

        public IActionResult Index()
        {
            var cartDb = this.cartRepos.TyGetByUserId(Constans.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cartDb);

            return View(nameof(Index), cartViewModel);
        }

        public IActionResult Add(Guid productId)
        {
            var productDb = this.productRepos.TryByGuid(productId);
            this.cartRepos.Add(productDb, Constans.UserId);

            return RedirectToAction(nameof(Index)); // повторный вызов Index
        }

        public IActionResult DecreasItemAmount(Guid productId)
        {
            this.cartRepos.DecreasItem(productId, Constans.UserId);

            return RedirectToAction(nameof(Index)); // повторный вызов Index
        }

        public IActionResult Clear(Guid productId)
        {
            this.cartRepos.Clear(Constans.UserId);

            return RedirectToAction(nameof(Index)); // повторный вызов Index
        }
    }
}
