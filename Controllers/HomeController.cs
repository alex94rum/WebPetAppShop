using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System.Linq;
using WebPetAppShop.Models;

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
        var products = productRepos.GetAll().Select(
            p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Cost = p.Cost,
                Description = p.Description,
                ImagePath = p.ImagePath,
            })
            .ToList();

        return View(nameof(Index), products);
    }
}
