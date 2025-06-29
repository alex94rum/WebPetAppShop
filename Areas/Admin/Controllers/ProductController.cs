using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepos productRepos;

        public ProductController(IProductRepos productRepos)
        {
            this.productRepos = productRepos;
        }

        public IActionResult Index()
        {
            var products = productRepos.GetAll();

            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid) 
            {
                return View(product);
            }

            productRepos.Add(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid productId)
        {
            var product = productRepos.TryByGuid(productId);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productRepos.Update(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
