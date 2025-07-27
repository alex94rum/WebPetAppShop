using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using WebPetAppShop.Helpers;

namespace WebPetAppShop.Controllers;

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
        var products = this.favoriteRepos.GetAll(Constans.UserId);
        return View(Mapping.ToProductsViewModel(products));
    }

    public IActionResult Add(Guid productId)
    {
        var product = this.productRepos.TryByGuid(productId);
        this.favoriteRepos.Add(Constans.UserId, product);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(Guid productId)
    {
        this.favoriteRepos.Remove(Constans.UserId, productId);

        return RedirectToAction(nameof(Index));
    }
}
