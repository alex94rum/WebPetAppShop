using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Helpers;

namespace WebPetAppShop.Controllers
{
    [Authorize]
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
            var cartDb = this.cartRepos.TyGetByUserId(Constants.UserId);
            var cartViewModel = cartDb.ToCartViewModel();

            return View(nameof(Index), cartViewModel);
        }

        public IActionResult Add(Guid productId)
        {
            var productDb = this.productRepos.TryByGuid(productId);
            this.cartRepos.Add(productDb, Constants.UserId);

            return RedirectToAction(nameof(Index)); // повторный вызов Index
        }

        public IActionResult DecreasItemAmount(Guid productId)
        {
            this.cartRepos.DecreasItem(productId, Constants.UserId);

            return RedirectToAction(nameof(Index)); // повторный вызов Index
        }

        public IActionResult Clear(Guid productId)
        {
            this.cartRepos.Clear(Constants.UserId);

            return RedirectToAction(nameof(Index)); // повторный вызов Index
        }
    }
}
