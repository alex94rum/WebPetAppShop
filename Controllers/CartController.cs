using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Data;
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
            var cart = this.cartRepos.TyGetByUserId(Constans.UserId);

            return View(nameof(Index), cart);
        }

        public IActionResult Add(Guid productId)
        {
            var productDb = this.productRepos.TryByGuid(productId);

            var productViewModel = new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                ImagePath = productDb.ImagePath,
                Cost = productDb.Cost,
                Description = productDb.Description,
            };

            this.cartRepos.Add(productViewModel, Constans.UserId);

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
