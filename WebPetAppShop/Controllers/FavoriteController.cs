using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Helpers;

namespace WebPetAppShop.Controllers;

[Authorize]
public class FavoriteController : Controller
{
    private readonly IFavoriteRepos favoriteRepos;
    private readonly IProductRepos productRepos;

    public FavoriteController(IFavoriteRepos favoriteRepos, IProductRepos productRepos)
    {
        this.favoriteRepos = favoriteRepos;
        this.productRepos = productRepos;
    }

    public IActionResult Index()
    {
        var products = this.favoriteRepos.GetAll(Constants.UserId);
        return View(products.ToProductsViewModel());
    }

    public IActionResult Add(Guid productId)
    {
        var product = this.productRepos.TryByGuid(productId);
        this.favoriteRepos.Add(Constants.UserId, product);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(Guid productId)
    {
        this.favoriteRepos.Remove(Constants.UserId, productId);

        return RedirectToAction(nameof(Index));
    }
}
