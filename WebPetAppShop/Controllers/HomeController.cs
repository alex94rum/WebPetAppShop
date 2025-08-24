using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepos productRepos;
    private readonly IMapper mapper;

    public HomeController(IProductRepos productRepos, IMapper mapper)
    {
        this.productRepos = productRepos;
        this.mapper = mapper;
    }

    public IActionResult Index(string name)
    {
        var productsDb = productRepos.GetAll();
        var productsViewModel = this.mapper.Map<List<ProductViewModel>>(productsDb);

        return View(nameof(Index), productsViewModel);
    }
}
