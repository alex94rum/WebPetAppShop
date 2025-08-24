using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers;

public class FavoriteController : Controller
{
    private readonly IFavoriteRepos favoriteRepos;
    private readonly IProductRepos productRepos;
    private readonly IMapper mapper;

    public FavoriteController(IFavoriteRepos favoriteRepos, IProductRepos productRepos, IMapper mapper)
    {
        this.favoriteRepos = favoriteRepos;
        this.productRepos = productRepos;
        this.mapper = mapper;
    }

    public IActionResult Index()
    {
        var products = this.favoriteRepos.GetAll(Constans.UserId);
        return View(this.mapper.Map<List<ProductViewModel>>(products));
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
