using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartRepos cartRepos;
        private readonly IOrderRepos orderRepos;
        private readonly IMapper mapper;

        public OrderController(ICartRepos cartRepos, IOrderRepos orderRepos, IMapper mapper)
        {
            this.cartRepos = cartRepos;
            this.orderRepos = orderRepos;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel userInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), userInfo);
            }

            var existCart = this.cartRepos.TyGetByUserId(Constans.UserId);

            var order = new Order
            {
                UserInfo = this.mapper.Map<UserDeliveryInfo>(userInfo), // маппинг моделей
                Items = existCart.Items,
            };

            if (existCart != null)
            {
                this.orderRepos.Add(order);
            }

            this.cartRepos.Clear(Constans.UserId);

            return View(nameof(Buy));
        }
    }
}
