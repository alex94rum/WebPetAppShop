using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepos productRepos;

        public ProductController()
        {
            this.productRepos = new ProductRepos();
        }

        public IActionResult Index(Guid guid)
        {
            var products = this.productRepos?.TryByGuid(guid);

            return View("Index", products);
        }
    }
}
