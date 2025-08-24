using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepos productRepos;
        private readonly ICartRepos cartRepos;
        private readonly IMapper mapper;

        public CartController(IProductRepos productRepos, ICartRepos cartRepos, IMapper mapper)
        {
            this.productRepos = productRepos;
            this.cartRepos = cartRepos;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var cartDb = this.cartRepos.TyGetByUserId(Constans.UserId);
            var cartViewModel = mapper.Map<CartViewModel>(cartDb); // маппинг моделей

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
