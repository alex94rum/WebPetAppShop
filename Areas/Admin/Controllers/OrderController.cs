using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Data;
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
            return View(orders);
        }

        public IActionResult Detail(Guid orderId, int number)
        {
            var order = orderRepos.TryGetById(orderId);
            if (order != null)
            {
                order.Number = number;
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            orderRepos.UpdateStatus(orderId, status);

            return RedirectToAction(nameof(Index));
        }
    }
}
