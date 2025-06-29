using Microsoft.AspNetCore.Mvc;
using WebPetAppShop.Data;

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
        var products = productRepos.GetAll();

        return View(nameof(Index), products);
    }
}
