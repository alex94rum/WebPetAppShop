using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Models;

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
            var productDb = this.productRepos?.TryByGuid(guid);

            var productViewModel = new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                ImagePath = productDb.ImagePath,
                Cost = productDb.Cost,
                Description = productDb.Description,
            };

            return View(nameof(Index), productViewModel);
        }
    }
}
