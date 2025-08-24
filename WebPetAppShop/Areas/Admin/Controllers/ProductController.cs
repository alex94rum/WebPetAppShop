using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Model;
using OnlineShop.Db;
using System;
using WebPetAppShop.Models;
using AutoMapper;
using System.Collections.Generic;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepos productRepos;
        private readonly IMapper mapper;

        public ProductController(IProductRepos productRepos, IMapper mapper)
        {
            this.productRepos = productRepos;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Product>? productsDb = this.productRepos.GetAll();
            var productsViewModel = this.mapper.Map<List<ProductViewModel>>(productsDb); // маппинг моделей

            return View(productsViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = this.mapper.Map<Product>(product); // маппинг моделей

            productRepos.Add(productDb);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid productId)
        {
            Product? productDb = productRepos.TryByGuid(productId);
            var productViewModel = this.mapper.Map<ProductViewModel>(productDb); // маппинг моделей

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = this.mapper.Map<Product>(product); // маппинг моделей

            this.productRepos.Update(productDb);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            var productDb = productRepos.TryByGuid(productId);
            this.productRepos.Remove(productDb);

            return RedirectToAction(nameof(Index));
        }
    }
}
