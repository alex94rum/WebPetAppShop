using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepos productRepos;

        public AdminController(IProductRepos productRepos)
        {
            this.productRepos = productRepos;
        }

        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = this.productRepos.GetAll();

            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            this.productRepos.Add(product);

            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(Guid productId)
        {
            var product = this.productRepos.TryByGuid(productId);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            this.productRepos.Update(product);

            return RedirectToAction("Products");
        }
    }
}
