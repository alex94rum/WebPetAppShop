using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepos orderRepos;
        private readonly IMapper mapper;

        public OrderController(IOrderRepos orderRepos, IMapper mapper)
        {
            this.orderRepos = orderRepos;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var orders = orderRepos.GetAll();
            var ordersViewModel = this.mapper.Map<List<OrderViewModel>>(orders);

            return View(ordersViewModel);
        }

        public IActionResult Detail(Guid orderId)
        {
            var order = orderRepos.TryGetById(orderId);
            var orderViewModel = this.mapper.Map<OrderViewModel>(order);

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatusViewModel status)
        {
            this.orderRepos.UpdateStatus(orderId, (OrderStatus)(int)status);

            return RedirectToAction(nameof(Index));
        }
    }
}
