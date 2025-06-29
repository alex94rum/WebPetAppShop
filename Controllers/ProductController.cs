using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Data;

namespace WebPetAppShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepos productRepos;

        public ProductController(IProductRepos productRepos)
        {
            this.productRepos = productRepos;
        }

        public IActionResult Index(Guid guid)
        {
            var products = this.productRepos?.TryByGuid(guid);

            return View(nameof(Index), products);
        }
    }
}
