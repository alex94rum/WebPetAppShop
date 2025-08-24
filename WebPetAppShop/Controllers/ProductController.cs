using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepos productRepos;
        private readonly IMapper mapper;

        public ProductController(IProductRepos productRepos, IMapper mapper)
        {
            this.productRepos = productRepos;
            this.mapper = mapper;
        }

        public IActionResult Index(Guid guid)
        {
            var productDb = this.productRepos?.TryByGuid(guid);
            var productViewModel = this.mapper.Map<ProductViewModel>(productDb); // маппинг моделей

            return View(nameof(Index), productViewModel);
        }
    }
}
