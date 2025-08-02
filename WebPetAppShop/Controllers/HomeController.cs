using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebPetAppShop.Helpers;

namespace WebPetAppShop.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepos productRepos;

    public HomeController(IProductRepos productRepos)
    {
        this.productRepos = productRepos;
    }

    public IActionResult Index(string name)
    {
        var productsDb = productRepos.GetAll();
        var productsViewModel = productsDb.ToProductsViewModel();

        return View(nameof(Index), productsViewModel);
    }
}
