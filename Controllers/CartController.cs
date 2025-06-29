using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Data;

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
            var cart = this.cartRepos.TyGetByUserId(Constans.UserId);

            return View(nameof(Index), cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = this.productRepos.TryByGuid(productId);
            this.cartRepos.Add(product, Constans.UserId);

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
