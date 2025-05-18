using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductRepos productRepos;

    public HomeController(ILogger<HomeController> logger, IProductRepos productRepos)
    {
        _logger = logger;
        this.productRepos = productRepos;
    }

    public IActionResult Index(string name)
    {
        var products = productRepos.GetAll();

        return View("Index", products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
