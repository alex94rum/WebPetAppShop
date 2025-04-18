using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductRepos productRepos;

        public CartController()
        {
            this.productRepos = new ProductRepos();
        }

        public IActionResult Index()
        {
            var cart = CartRepos.TyGetByUserId(Constans.UserId);

            return View("Index", cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = this.productRepos.TryByGuid(productId);
            CartRepos.Add(product, Constans.UserId);

            return RedirectToAction("Index"); // повторный вызов Index
        }

    }
}
