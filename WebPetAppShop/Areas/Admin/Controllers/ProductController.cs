using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Model;
using OnlineShop.Db;
using System;
using WebPetAppShop.Models;
using WebPetAppShop.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductRepos productRepos;

        public ProductController(IProductRepos productRepos)
        {
            this.productRepos = productRepos;
        }

        public IActionResult Index()
        {
            var productsDb = this.productRepos.GetAll();
            var products = productsDb.ToProductsViewModel();

            return View(products);
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

            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };

            productRepos.Add(productDb);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid productId)
        {
            var productDb = productRepos.TryByGuid(productId);

            var productViewModel = new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Cost = productDb.Cost,
                Description = productDb.Description,
                ImagePath = productDb.ImagePath,
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };

            productRepos.Update(productDb);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            var productDb = productRepos.TryByGuid(productId);

            productRepos.Remove(productDb);

            return RedirectToAction(nameof(Index));
        }
    }
}
