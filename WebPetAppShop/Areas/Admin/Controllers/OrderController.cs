using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using System;
using System.Linq;
using WebPetAppShop.Data;
using WebPetAppShop.Helpers;
using WebPetAppShop.Models;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepos orderRepos;

        public OrderController(IOrderRepos orderRepos)
        {
            this.orderRepos = orderRepos;
        }

        public IActionResult Index()
        {
            var orders = orderRepos.GetAll();
            return View(orders.Select(Mapping.ToOrderViewModel).ToList());
        }

        public IActionResult Detail(Guid orderId)
        {
            var order = orderRepos.TryGetById(orderId);

            return View(Mapping.ToOrderViewModel(order));
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatusViewModel status)
        {
            this.orderRepos.UpdateStatus(orderId, (OrderStatus)(int)status);

            return RedirectToAction(nameof(Index));
        }
    }
}
